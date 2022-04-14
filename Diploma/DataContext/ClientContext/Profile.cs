using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataContext
{
    public class Profile
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Secondname { get; set; }
        public int PositionID { get; set; }
        public Position Position { get; set; }
        public int RankID { get; set; }
        public Rank Rank { get; set; }
        public string PrivateNumber { get; set; }
        /// <summary>
        ///  Binding a user to a OS
        /// </summary>
        public string UserSID { get; set; }
        /// <summary>
        /// Is profile blocked or not calculating buy  wrong login atempts
        /// </summary>
        public bool Blocked { get; set; }
        public List<Case> Cases { get; set; }
    }
}