using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Diploma.DataContext;
using System.Security.Cryptography;
using Diploma.Windows.Profile;
using System.Security.Principal;
using System.DirectoryServices;
using Diploma.Utils;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace Diploma.Windows.Auth
{
    public class AuthRepository
    {
        public int Auth(string login, string password)
        {
            using(DiplomaDataContext db = new DiplomaDataContext())
            {
                password = GetSha256(password);
                DataContext.Profile profile = db.Profiles.FirstOrDefault(p => p.Login == login && p.Password == password);
                
                if (profile == null) return Structure.AuthEventError.PROFILE_WRONG_AUTH;
                if (profile.Blocked) return Structure.AuthEventError.PROFILE_BLOCKED;
                var user = WindowsIdentity.GetCurrent().User.ToString();
                if (profile.UserSID != user) return Structure.AuthEventError.PROFILE_SID_ERROR;
            }
            return Structure.AuthEventError.PROFILE_SUCCESS;
        }
        private string GetSha256(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            var hashString = new SHA256Managed();
            var hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (var x in hashValue)
                hex += string.Format("{0:x2}", x);
            return hex;
        }
    }
}