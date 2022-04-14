using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Diploma.DataContext
{
    public class Block
    {
        public int BlockId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public string Data { get; set; }
        /// <summary>
        /// Contains name of operation (create, update, delete(hide))
        /// </summary>
        public string CreatorId { get; set; }
        /// <summary>
        /// Contains information about server, which took the user request for add block to chain
        /// </summary>
        public string ServerAddress { get; set; }

        public string CreateHash()
        {
            string rawaData = $"{BlockId}{CreatedOn}{PreviousHash}{Data}";
            var message = Encoding.ASCII.GetBytes(rawaData);
            var hashString = new SHA256Managed();
            var hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (var x in hashValue)
                hex += string.Format("{0:x2}", x);
            return hex;
        }
    }
}