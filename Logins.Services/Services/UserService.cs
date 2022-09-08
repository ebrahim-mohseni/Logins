using AutoMapper;
using Logins.ApiService.Interfaces;
using Logins.ApiService.Properties;
using Logins.Data;
using Logins.Domain.Classes;
using Logins.Helper;
using Logins.Model;
using Logins.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace Logins.ApiService.Services
{
    public class UserService : DataService, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, DataContext contex) : base(contex)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserListDto>>> GetUsers()
        {
            var output = new ServiceResult<List<UserListDto>>();
            try
            {
                output.Data = await (from u in Context.Users
                                        join l in Context.Lookup on u.UserTypeId equals l.LookupId
                                        join l1 in Context.Lookup on u.PositionId equals l1.LookupId
                                        where l.LookupTypeId == (int)EnumLookup.UserType
                                           && l1.LookupTypeId == (int)EnumLookup.Position
                                           && u.UserId != -1
                                        select new UserListDto
                                        {
                                            Id = EncryptHelper.Encrypt(u.UserId.ToString()),
                                            Email = u.Email,
                                            FirstName = u.FirstName,
                                            LastName = u.LastName,
                                            UserType = l.Caption,
                                            Position = l1.Caption,
                                            Locked = u.Locked
                                        }).ToListAsync();
            }
            catch (Exception ex)
            {
                output.SetException(ex, "GetUsers");
            }

            return output;
        }

        public async Task<ServiceResult<CreateUserDto>> AddNewUser()
        {
            var output = new ServiceResult<CreateUserDto>();
            try
            {
                output.Data = new CreateUserDto
                {
                    UserTypeList = await (from l in Context.Lookup
                                          where l.LookupTypeId == (int)EnumLookup.UserType
                                          select new LookupDto
                                          {
                                              Id = l.LookupId,
                                              Caption = l.Caption
                                          }).ToListAsync(),

                    PositionList = await (from l in Context.Lookup
                                          where l.LookupTypeId == (int)EnumLookup.Position
                                          select new LookupDto
                                          {
                                              Id = l.LookupId,
                                              Caption = l.Caption
                                          }).ToListAsync()
                };

                output.SeInformation("GetUserProfile");
            }
            catch (Exception ex)
            {
                output.SetException(ex, "GetUserProfile");
            }

            return output;
        }

        public async Task<ServiceResult<UpdateUserDto>> GetUserProfile(string id)
        {
            var output = new ServiceResult<UpdateUserDto>();
            try
            {
                Users? result = await Context.Users.FindAsync(Convert.ToInt32(EncryptHelper.Decrypt(id)));
                output.Data = _mapper.Map<UpdateUserDto>(result);

                output.Data.UserTypeList = await (from l in Context.Lookup
                                                     where l.LookupTypeId == (int)EnumLookup.UserType
                                                     select new LookupDto
                                                     {
                                                         Id = l.LookupId,
                                                         Caption = l.Caption
                                                     }).ToListAsync();

                output.Data.PositionList = await (from l in Context.Lookup
                                                     where l.LookupTypeId == (int)EnumLookup.Position
                                                     select new LookupDto
                                                     {
                                                         Id = l.LookupId,
                                                         Caption = l.Caption
                                                     }).ToListAsync();

                output.SeInformation("GetUserProfile");
            }
            catch (Exception ex)
            {
                output.SetException(ex, "GetUserProfile");
            }

            return output;
        }

        public async Task<ServiceResult<bool>> CreateUser(NewUserDto input)
        {
            var output = new ServiceResult<bool>();
            try
            {
                Users users = _mapper.Map<Users>(input);
                Context.Users.Add(users);
                await Context.SaveChangesAsync();
                output.SeInformation("CreateUser");

            }
            catch (Exception ex)
            {
                output.SetException(ex, "CreateUser");
            }

            return output;
        }

        public async Task<ServiceResult<bool>> UpdateUser(UserDto input)
        {
            var output = new ServiceResult<bool>();
            try
            {
                Users user = _mapper.Map<Users>(input);

                Context.Users.Attach(user);
                Context.Entry(user).Property(x => x.Email).IsModified = false;
                Context.Entry(user).Property(x => x.Password).IsModified = false;
                Context.Entry(user).Property(x => x.SignupDate).IsModified = false;
                Context.Entry(user).Property(x => x.Locked).IsModified = false;
                await Context.SaveChangesAsync();
                output.SeInformation("UpdateUser");
            }
            catch (Exception ex)
            {
                output.SetException(ex, "UpdateUser");
            }

            return output;
        }

        public async Task<ServiceResult<bool>> DeleteUser(string id)
        {
            var output = new ServiceResult<bool>();
            try
            {
                Users? user = await Context.Users.FindAsync(Convert.ToInt32(EncryptHelper.Decrypt(id)));

                if (user == null)
                {
                    output.SetDebug("DeleteUser", Resources.NoFoundMessage, $"UserId: {EncryptHelper.Decrypt(id)}");
                }
                else
                {                    
                    Context.Users.Remove(user);
                    await Context.SaveChangesAsync();
                    output.SeInformation("DeleteUser");
                }
            }
            catch (Exception ex)
            {
                output.SetException(ex, "DeleteUser");
            }

            return output;
        }

        public async Task<ServiceResult<bool>> ChangePassowrd(ChangePasswordDto password)
        {
            var output = new ServiceResult<bool>();
            try
            {
                Users? user = _mapper.Map<Users>(password);
                Context.Users.Attach(user);
                Context.Entry(user).Property(x => x.Password).IsModified = true;
                await Context.SaveChangesAsync();
                output.SeInformation("ChangePassowrd");
            }
            catch (Exception ex)
            {
                output.SetException(ex, "ChangePassowrd");
            }

            return output;
        }
    }

}
