import logging
import httpx
import asyncio
import json
import os
from typing import Optional, Dict
from urllib.parse import quote
from telegram import (Update, KeyboardButton, ReplyKeyboardMarkup, ReplyKeyboardRemove)
from telegram.ext import ( Application, CommandHandler, MessageHandler, filters, CallbackContext, ContextTypes)

ASP_NET_API_URL = "https://10.8.1.1:7283/api/orders"
BOT_TOKEN = "bot_token"
SAVE_FILE = "user_phones.json"

logging.basicConfig(format="%(asctime)s - %(name)s - %(levelname)s - %(message)s", level=logging.INFO)
logger = logging.getLogger(__name__)


class OrderBot:
    def __init__(self):
        self.client = httpx.AsyncClient(timeout=30.0, verify=False)
        self.user_phones = self._load_phones()
        logger.info(f"Loaded {len(self.user_phones)} phone numbers from storage")

    def _load_phones(self) -> Dict[int, str]:
        if os.path.exists(SAVE_FILE):
            try:
                with open(SAVE_FILE, 'r') as f:
                    data = json.load(f)
                    return {int(k): v for k, v in data.items()}
            except Exception as e:
                logger.error(f"Error loading phone numbers: {e}")
                return {}
        return {}

    def _save_phones(self):
        try:
            with open(SAVE_FILE, 'w') as f:
                json.dump(self.user_phones, f, indent=2)
            logger.info("Phone numbers saved to file")
        except Exception as e:
            logger.error(f"Error saving phone numbers: {e}")

    async def start(self, update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
        user = update.effective_user
        logger.info(f"Start command from user {user.id}")

        if user.id in self.user_phones:
            logger.info(f"User {user.id} already has phone number")
            await self._show_status_keyboard(update)
        else:
            logger.info(f"Requesting phone number from user {user.id}")
            await self._request_phone(update)

    async def _request_phone(self, update: Update):
        button = KeyboardButton("📱 Отправить номер телефона", request_contact=True)
        reply_markup = ReplyKeyboardMarkup([[button]], resize_keyboard=True, one_time_keyboard=True)

        await update.message.reply_text(
            "Для проверки заказов мне нужен ваш номер телефона.\n"
            "Нажмите кнопку ниже, чтобы поделиться им:",
            reply_markup=reply_markup
        )

    async def _show_status_keyboard(self, update: Update):
        button = KeyboardButton("🔍 Проверить статус заказов")
        reply_markup = ReplyKeyboardMarkup([[button]], resize_keyboard=True)

        await update.message.reply_text("Вы можете проверить статус ваших заказов:", reply_markup=reply_markup)

    async def handle_contact(self, update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
        user = update.effective_user
        contact = update.message.contact

        if not contact or not contact.phone_number:
            await update.message.reply_text("❌ Не удалось получить номер телефона", reply_markup=ReplyKeyboardRemove())
            return

        self.user_phones[user.id] = contact.phone_number
        self._save_phones() 

        logger.info(f"Saved phone number for user {user.id}")

        await update.message.reply_text("✅ Спасибо! Ваш номер сохранен.", reply_markup=ReplyKeyboardRemove())
        await self._show_status_keyboard(update)

    async def check_status(self, update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
        user = update.effective_user
        phone = self.user_phones.get(user.id)

        if not phone:
            logger.warning(f"No phone number found for user {user.id}")
            await update.message.reply_text("❌ Номер телефона не найден. Пожалуйста, отправьте его снова.", reply_markup=ReplyKeyboardRemove())
            await self._request_phone(update)
            return

        logger.info(f"Checking orders for user {user.id}")
        await update.message.reply_text("🔍 Ищу ваши заказы...")
        await self._process_phone_number(update, phone)

    async def handle_message(self, update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
        text = update.message.text

        if text == "🔍 Проверить статус заказов":
            await self.check_status(update, context)
        else:
            await update.message.reply_text("Пожалуйста, используйте кнопки для взаимодействия с ботом.", reply_markup=ReplyKeyboardRemove())
            await self.start(update, context)

    async def _process_phone_number(self, update: Update, phone: str) -> None:
        try:
            formatted_phone = self._format_phone(phone)
            if not formatted_phone:
                await update.message.reply_text("❌ Неверный формат номера телефона")
                return

            encoded_phone = quote(formatted_phone)
            url = f"{ASP_NET_API_URL}?phoneNumber={encoded_phone}"
            logger.info(f"Request URL: {url}")

            response = await self.client.get(url)
            response.raise_for_status()
            data = response.json()

            if not data.get("success", False):
                await update.message.reply_text(f"⚠ Ошибка: {data.get('error', 'Unknown error')}")
                return

            orders = data.get("orders", [])
            if not orders:
                await update.message.reply_text("🔍 Заказы для вашего номера не найдены.")
                return

            message = "📋 Ваши заказы:\n\n"
            for order in orders:
                message += (
                    f"📅 <b>Дата:</b> {order.get('orderDate', 'N/A')}\n"
                    f"📱 <b>Устройство:</b> {order.get('deviceType', '?')} {order.get('deviceModel', '?')}\n"
                    f"🔧 <b>Тип ремонта:</b> {order.get('repairType', '?')}\n"
                    f"🔄 <b>Статус:</b> {order.get('status', '?')}\n\n"
                )

            await update.message.reply_text(message, parse_mode="HTML")

        except httpx.HTTPStatusError as e:
            logger.error(f"HTTP error: {e.response.status_code}")
            await update.message.reply_text("⚠ Ошибка сервера. Попробуйте позже.")
        except httpx.RequestError as e:
            logger.error(f"Connection error: {e}")
            await update.message.reply_text("⚠ Ошибка подключения. Проверьте интернет.")
        except Exception as e:
            logger.error(f"Unexpected error: {e}")
            await update.message.reply_text("⚠ Произошла непредвиденная ошибка.")


    def _format_phone(self, phone: str) -> Optional[str]:
        digits = ''.join(c for c in phone if c.isdigit())
        if digits.startswith('8') and len(digits) == 11:
            normalized = '+7' + digits[1:]
        elif digits.startswith('7') and len(digits) == 11:
            normalized = '+' + digits
        elif digits.startswith('+7') and len(digits) == 12:
            normalized = digits
        else:
            return None

        return f"+7 ({normalized[2:5]}) {normalized[5:8]}-{normalized[8:10]}-{normalized[10:]}"

    def run_bot(self):
        application = Application.builder().token(BOT_TOKEN).build()
        application.add_handler(CommandHandler("start", self.start))
        application.add_handler(MessageHandler(filters.CONTACT, self.handle_contact))
        application.add_handler(MessageHandler(filters.TEXT & ~filters.COMMAND, self.handle_message))

        try:
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            logger.info("Starting bot...")
            loop.run_until_complete(application.run_polling())
        except KeyboardInterrupt:
            logger.info("Bot stopped by user")
        finally:
            loop.run_until_complete(self.client.aclose())
            loop.close()
            logger.info("Bot shutdown complete")

if __name__ == "__main__":
    bot = OrderBot()
    bot.run_bot()