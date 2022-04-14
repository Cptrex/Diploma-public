using System.ServiceModel;

namespace WCF_ServiceBlockchain
{
    public class ServiceUser
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public OperationContext operationContext { get; set; }
    }
}