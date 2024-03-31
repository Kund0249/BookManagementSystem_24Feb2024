using BMS.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DataLayer.ApplicationUser
{
   public interface IAppUser
    {
        public bool IsValid(string UserId, string Password, out User user);
    }
}
