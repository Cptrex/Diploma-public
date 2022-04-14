using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Configuration
{
    /// <summary>
    /// Class for describe server settings which will be use for interaction with other servers
    /// </summary>
    class ServerConfiguration
    {
        public int Id { get; set; }
        /// <summary>
        /// Display servername
        /// </summary>
        public string Displayname { get; set; }
        /// <summary>
        /// System name for intercation (like DNS)
        /// </summary>
        public string Systemname { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        /// <summary>
        /// Mark server as active or not in server pool
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Server client list which can interact with current server
        /// </summary>
        public List<string> Clients { get; set; } = new List<string>();
    }
}