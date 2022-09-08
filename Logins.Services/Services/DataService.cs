using Logins.Data;

namespace Logins.ApiService.Services
{
    public class DataService
    {
        public DataContext Context { get; set; }
        public DataService(DataContext DataContext)
        {
            Context = DataContext;
        }
    }
}
