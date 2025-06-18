using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.DB;
using ServiceCenter.Classes;
using System;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using ServiceCenter;
using Serilog;

namespace ServiceCenter.Services
{
    public class MastersServiceImpl : MastersService.MastersServiceBase
    {
        private readonly AppDbContext _context;

        public MastersServiceImpl(AppDbContext context)
        {
            _context = context;
        }
        private readonly OrdersServiceImpl _ordersServiceImpl;

  
        public override async Task<CreateMasterResponse> CreateMaster(CreateMasterRequest request, ServerCallContext context)
        {
            Log.Information("Creating master with login: {Login}", request.Master.Login);
            var master = request.Master;

            var existingMaster = await _context.Masters
                .FirstOrDefaultAsync(m => m.Login == master.Login);

            if (existingMaster != null)
            {
                Log.Warning("Master creation failed - login already exists: {Login}", master.Login);
                return new CreateMasterResponse
                {
                    Success = false,
                    Message = "Логин уже занят"
                };
            }

            master.Password = PasswordHasher.HashPassword(master.Password);

            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
            Log.Information("Master created successfully. ID: {MasterId}", master.MasterId);
            return new CreateMasterResponse
            {
                Success = true,
                Message = "Мастер успешно добавлен"
            };
        }

        public override async Task<GetMastersResponse> GetMasters(GetMastersRequest request, ServerCallContext context)
        {
            Log.Debug("Fetching list of masters");
            var masters = await _context.Masters.ToListAsync();
            var response = new GetMastersResponse();
            response.Masters.AddRange(masters);
            Log.Information("Returned {MasterCount} masters", masters.Count);
            return response;
        }

        public override async Task<UpdateMasterResponse> UpdateMaster(UpdateMasterRequest request, ServerCallContext context)
        {
            Log.Information("Updating master ID: {MasterId}", request.Master.MasterId);
            var master = request.Master;

            var existingMaster = await _context.Masters
                .FirstOrDefaultAsync(m => m.Login == master.Login && m.MasterId != master.MasterId);

            if (existingMaster != null)
            {
                Log.Warning("Master update failed - login conflict: {Login}", master.Login);
                return new UpdateMasterResponse
                {
                    Success = false,
                    Message = "Логин уже занят"
                };
            }

            var currentMaster = await _context.Masters.AsNoTracking()
                .FirstOrDefaultAsync(m => m.MasterId == master.MasterId);

            if (currentMaster != null && master.Password != currentMaster.Password)
            {
                master.Password = PasswordHasher.HashPassword(master.Password);
                Log.Debug("Password updated for master ID: {MasterId}", master.MasterId);
            }

            _context.Masters.Update(master);
            await _context.SaveChangesAsync();
            Log.Information("Master updated successfully. ID: {MasterId}", master.MasterId);
            return new UpdateMasterResponse
            {
                Success = true,
                Message = "Мастер успешно обновлен"
            };
        }
        public override async Task<DeleteMasterResponse> DeleteMaster(DeleteMasterRequest request, ServerCallContext context)
        {
            Log.Information("Deleting master ID: {MasterId}", request.MasterId);
            var master = await _context.Masters.FindAsync(request.MasterId);
            if (master != null)
            {
                _context.Masters.Remove(master);
                await _context.SaveChangesAsync();
                Log.Information("Master deleted. ID: {MasterId}", request.MasterId);
            }
            else
            {
                Log.Warning("Master not found for deletion. ID: {MasterId}", request.MasterId);
            }

            return new DeleteMasterResponse { Success = true, Message = "Мастер успешно удален" };
        }
        public override async Task<AuthenticateMasterResponse> AuthenticateMaster(AuthenticateMasterRequest request, ServerCallContext context)
        {
            Log.Information("Authentication attempt for login: {Login}", request.Login);
            var master = await _context.Masters.FirstOrDefaultAsync(m => m.Login == request.Login);

            if (master == null || !PasswordHasher.VerifyPassword(request.Password, master.Password))
            {
                Log.Warning("Authentication failed for login: {Login}", request.Login);
                return new AuthenticateMasterResponse { Success = false, Message = "Неверный логин или пароль" };
            }
            Log.Information("Authentication successful. Master ID: {MasterId}", master.MasterId);
            return new AuthenticateMasterResponse
            {
                Success = true,
                Message = "Аутентификация успешна",
                Master = new Master
                {
                    MasterId = master.MasterId.ToString(),
                    FullName = master.FullName,
                    Specialization = master.Specialization,
                    BirthDate = master.BirthDate,
                    ContactInfo = master.ContactInfo,
                    Login = master.Login
                }
            };

        }
       
    }
}
