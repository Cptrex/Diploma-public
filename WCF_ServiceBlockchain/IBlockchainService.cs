using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_ServiceBlockchain
{
    [ServiceContract]
    public interface IBlockchainService
    {
        [OperationContract]
        int Connect(string login);
        [OperationContract]
        void Disconnect(int id);
        [OperationContract]
        void ValidateBlock();
        [OperationContract]
        void AddBlockToChain();
    }
}