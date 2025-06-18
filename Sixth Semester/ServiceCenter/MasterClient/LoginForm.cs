using System;
using System.Windows.Forms;
using Grpc.Net.Client;
using Serilog;
using ServiceCenter;

namespace MasterClient
{
    public partial class LoginForm : Form
    {
        private MastersService.MastersServiceClient _mastersClient;
        public Master AuthenticatedMaster { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            Log.Information("LoginForm initialization started");

            try
            {
                InitializeGrpcClient();
                Log.Information("LoginForm initialized successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "LoginForm initialization failed");
                throw;
            }
        }

        private void InitializeGrpcClient()
        {
            Log.Debug("Initializing gRPC client");
            try
            {
                var channel = GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS"));
                _mastersClient = new MastersService.MastersServiceClient(channel);
                Log.Information("gRPC client initialized successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to initialize gRPC client");
                throw;
            }
        }

        private void ShowNotification(string message, string type)
        {

            Log.Debug("Showing notification: {Type} - {Message}", type, message); notifyIcon1.BalloonTipText = message;

            if (type.Equals("Ошибка"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            }
            else if (type.Equals("Предупреждение"))
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            }
            else
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }

            notifyIcon1.ShowBalloonTip(3000);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            Log.Information("Login attempt for user: {Login}", login);

            try
            {
                var request = new AuthenticateMasterRequest
                {
                    Login = login,
                    Password = txtPassword.Text
                };

                Log.Debug("Sending authentication request");
                var response = await _mastersClient.AuthenticateMasterAsync(request);

                if (response.Success)
                {
                    Log.Information("Authentication successful for user: {Login}", login);
                    AuthenticatedMaster = new Master
                    {
                        MasterId = response.Master.MasterId,
                        FullName = response.Master.FullName,
                        Specialization = response.Master.Specialization,
                        BirthDate = response.Master.BirthDate,
                        ContactInfo = response.Master.ContactInfo,
                        Login = response.Master.Login
                    };

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Log.Warning("Authentication failed for user: {Login}", login);
                    ShowNotification("Неверный логин или пароль.", "Ошибка авторизации");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Authentication error for user: {Login}", login);
                ShowNotification($"Ошибка при авторизации: {ex.Message}", "Ошибка");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Log.Information("LoginForm closing");
            base.OnFormClosing(e);
        }
    }
    
}
