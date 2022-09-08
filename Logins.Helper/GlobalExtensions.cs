using Logins.Model;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Logins.Helper
{
    public static class GlobalExtensions
    {
        public static void SeInformation<T>(this ServiceResult<T> model, string methodName)
        {
            model.HasError = false;
            model.Message = Properties.Resources.SuccessMessage;
            SetLog(methodName, (int)EnumLogType.Information, null, "Success");
        }

        public static void SetDebug<T>(this ServiceResult<T> model, string methodName, string message, string content)
        {
            model.HasError = true;
            model.Message = message;
            SetLog(methodName, (int)EnumLogType.Debug, null, content);
        }

        public static void SetException<T>(this ServiceResult<T> model, Exception ex, string methodName)
        {
            model.HasError = true;
            model.Message = Properties.Resources.ErrorMessage;

            var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
            SetLog(methodName, (int)EnumLogType.Error, (int)EnumErrorType.Service, errorMessage);
        }

        public static void SetLog(string methodName, int logTypeId, int? errorTypeId, string content)
        {
            string errorType = errorTypeId == (int)EnumErrorType.Database ? "Database" : "Service";

            if (logTypeId == (int)EnumLogType.Information)
                Log.Information($"method_name:{methodName} date_time: {DateTime.Now:yyyy-mm-dd}, content: {content}");
            else if (logTypeId == (int)EnumLogType.Debug)
                Log.Debug($"method_name:{methodName} date_time: {DateTime.Now:yyyy-mm-dd}, content: {content}");
            else if (logTypeId == (int)EnumLogType.Error)
                Log.Information($"method_name:{methodName}, error_type: {errorType}, date_time: {DateTime.Now:yyyy-mm-dd}, message: {content}");
        }

        public static string CreateJWTToken(int user_id, string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(BaseInfo.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: new List<Claim>
                {
                    new Claim("USERID", user_id.ToString()),
                    new Claim("EMAIL", email),
                },
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
