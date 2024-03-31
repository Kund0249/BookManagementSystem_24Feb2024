using BMS.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DataLayer.ApplicationUser
{
    public class AppUser : IAppUser
    {
        private readonly DbContext context;
        public AppUser()
        {
            context = new DbContext();
        }
        public bool IsValid(string UserId, string Password, out User user)
        {
            try
            {
                user = context.AppUser.SingleOrDefault(x => x.UserName == UserId && x.Password == Password);
                if(user != null)
                {
                    return true;
                }
                
                return false;
            }
            catch (Exception)
            {
                user = null;
                return false;
            }
        }
    }
}
