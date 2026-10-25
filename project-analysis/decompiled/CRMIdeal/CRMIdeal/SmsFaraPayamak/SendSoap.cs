using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.SmsFaraPayamak;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SmsFaraPayamak.SendSoap")]
public interface SendSoap
{
	[OperationContract(Action = "http://tempuri.org/SendSimpleSMS", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] SendSimpleSMS(string username, string password, string[] to, string from, string text, bool isflash);

	[OperationContract(Action = "http://tempuri.org/SendSimpleSMS", ReplyAction = "*")]
	Task<string[]> SendSimpleSMSAsync(string username, string password, string[] to, string from, string text, bool isflash);

	[OperationContract(Action = "http://tempuri.org/SendSimpleSMS2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSimpleSMS2(string username, string password, string to, string from, string text, bool isflash);

	[OperationContract(Action = "http://tempuri.org/SendSimpleSMS2", ReplyAction = "*")]
	Task<string> SendSimpleSMS2Async(string username, string password, string to, string from, string text, bool isflash);

	[OperationContract(Action = "http://tempuri.org/SendSms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SendSmsResponse SendSms(SendSmsRequest request);

	[OperationContract(Action = "http://tempuri.org/SendSms", ReplyAction = "*")]
	Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request);

	[OperationContract(Action = "http://tempuri.org/SendWithDomain", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendWithDomain(string username, string password, string to, string from, string text, bool isflash, string domainName);

	[OperationContract(Action = "http://tempuri.org/SendWithDomain", ReplyAction = "*")]
	Task<string> SendWithDomainAsync(string username, string password, string to, string from, string text, bool isflash, string domainName);

	[OperationContract(Action = "http://tempuri.org/GetSmsPrice", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetSmsPrice(string username, string password, int irancellCount, int mtnCount, string from, string text);

	[OperationContract(Action = "http://tempuri.org/GetSmsPrice", ReplyAction = "*")]
	Task<double> GetSmsPriceAsync(string username, string password, int irancellCount, int mtnCount, string from, string text);

	[OperationContract(Action = "http://tempuri.org/GetCredit", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetCredit(string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetCredit", ReplyAction = "*")]
	Task<double> GetCreditAsync(string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetDelivery(long recId);

	[OperationContract(Action = "http://tempuri.org/GetDelivery", ReplyAction = "*")]
	Task<int> GetDeliveryAsync(long recId);

	[OperationContract(Action = "http://tempuri.org/GetDelivery2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetDelivery2(string recId);

	[OperationContract(Action = "http://tempuri.org/GetDelivery2", ReplyAction = "*")]
	Task<int> GetDelivery2Async(string recId);

	[OperationContract(Action = "http://tempuri.org/GetMultiDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetMultiDeliveryResponse GetMultiDelivery(GetMultiDeliveryRequest request);

	[OperationContract(Action = "http://tempuri.org/GetMultiDelivery", ReplyAction = "*")]
	Task<GetMultiDeliveryResponse> GetMultiDeliveryAsync(GetMultiDeliveryRequest request);

	[OperationContract(Action = "http://tempuri.org/GetMultiDelivery2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetMultiDelivery2(string recId);

	[OperationContract(Action = "http://tempuri.org/GetMultiDelivery2", ReplyAction = "*")]
	Task<string[]> GetMultiDelivery2Async(string recId);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int[] GetDeliveries(long[] recIds, string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries", ReplyAction = "*")]
	Task<int[]> GetDeliveriesAsync(long[] recIds, string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetDeliveries2(string recId);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries2", ReplyAction = "*")]
	Task<int> GetDeliveries2Async(string recId);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries3", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int[] GetDeliveries3(string[] recId, string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetDeliveries3", ReplyAction = "*")]
	Task<int[]> GetDeliveries3Async(string[] recId, string username, string password);

	[OperationContract(Action = "http://tempuri.org/GetInboxCount", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetInboxCount(string username, string password, bool isRead);

	[OperationContract(Action = "http://tempuri.org/GetInboxCount", ReplyAction = "*")]
	Task<int> GetInboxCountAsync(string username, string password, bool isRead);

	[OperationContract(Action = "http://tempuri.org/getMessages", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseBL))]
	MessagesBL[] getMessages(string username, string password, int location, string from, int index, int count);

	[OperationContract(Action = "http://tempuri.org/getMessages", ReplyAction = "*")]
	Task<MessagesBL[]> getMessagesAsync(string username, string password, int location, string from, int index, int count);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseBL))]
	string SendByBaseNumber(string username, string password, string[] text, string to, int bodyId);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber", ReplyAction = "*")]
	Task<string> SendByBaseNumberAsync(string username, string password, string[] text, string to, int bodyId);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseBL))]
	string SendByBaseNumber2(string username, string password, string text, string to, int bodyId);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber2", ReplyAction = "*")]
	Task<string> SendByBaseNumber2Async(string username, string password, string text, string to, int bodyId);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber3", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseBL))]
	string SendByBaseNumber3(string username, string password, string text, string to);

	[OperationContract(Action = "http://tempuri.org/SendByBaseNumber3", ReplyAction = "*")]
	Task<string> SendByBaseNumber3Async(string username, string password, string text, string to);
}
