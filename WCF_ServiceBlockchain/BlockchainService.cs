using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_ServiceBlockchain
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class BlockchainService : IBlockchainService
    {
        List<ServiceUser> ActiveUsers = new List<ServiceUser>();
        int nextID = 1;
        public void AddBlockToChain()
        {
        }

        public int Connect(string login)
        {
            ServiceUser user = new ServiceUser()
            {
                ID = nextID,
                Login = login,
                operationContext = OperationContext.Current
            };
            nextID++;
            ActiveUsers.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            ServiceUser user = ActiveUsers.FirstOrDefault(u => u.ID == id);
            if (user != null) ActiveUsers.Remove(user);
        }

        public void ValidateBlock()
        {
        }
    }
}
