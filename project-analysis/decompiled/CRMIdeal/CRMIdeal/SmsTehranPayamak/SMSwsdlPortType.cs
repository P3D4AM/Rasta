using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.SmsTehranPayamak;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "urn:SMSwsdl", ConfigurationName = "SmsTehranPayamak.SMSwsdlPortType")]
public interface SMSwsdlPortType
{
	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[return: MessageParameter(Name = "return")]
	string sendSMS(string domain, string username, string password, string from, string to, string text, int isflash);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	Task<string> sendSMSAsync(string domain, string username, string password, string from, string to, string text, int isflash);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[return: MessageParameter(Name = "return")]
	string sendMultiSMS(string domain, string username, string password, string from, string to, string texts, int isflash);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	Task<string> sendMultiSMSAsync(string domain, string username, string password, string from, string to, string texts, int isflash);

	[OperationContract(Action = "urn:SMSwsdl#GetCredit", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[return: MessageParameter(Name = "return")]
	string getCredit(string domain, string username, string password);

	[OperationContract(Action = "urn:SMSwsdl#GetCredit", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	Task<string> getCreditAsync(string domain, string username, string password);

	[OperationContract(Action = "urn:SMSwsdl#getDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	[return: MessageParameter(Name = "result")]
	delivery[] getDelivery(string domain, string username, string password, int id);

	[OperationContract(Action = "urn:SMSwsdl#getDelivery", ReplyAction = "*")]
	[return: MessageParameter(Name = "result")]
	Task<delivery[]> getDeliveryAsync(string domain, string username, string password, int id);

	[OperationContract(Action = "urn:SMSwsdl#getDeliveryMulti", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	[return: MessageParameter(Name = "result")]
	delivery[] getDeliveryMulti(string domain, string username, string password, int id);

	[OperationContract(Action = "urn:SMSwsdl#getDeliveryMulti", ReplyAction = "*")]
	[return: MessageParameter(Name = "result")]
	Task<delivery[]> getDeliveryMultiAsync(string domain, string username, string password, int id);

	[OperationContract(Action = "urn:SMSwsdl#checkReceive", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	checkReceiveResponse checkReceive(checkReceiveRequest request);

	[OperationContract(Action = "urn:SMSwsdl#checkReceive", ReplyAction = "*")]
	Task<checkReceiveResponse> checkReceiveAsync(checkReceiveRequest request);

	[OperationContract(Action = "http://tehran-payamak.ir/APPs/SMS/WebService.php/getMessages", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	[return: MessageParameter(Name = "result")]
	message[] getMessages(string domain, string username, string password, string smsType, string start, string count, string from);

	[OperationContract(Action = "http://tehran-payamak.ir/APPs/SMS/WebService.php/getMessages", ReplyAction = "*")]
	[return: MessageParameter(Name = "result")]
	Task<message[]> getMessagesAsync(string domain, string username, string password, string smsType, string start, string count, string from);

	[OperationContract(Action = "urn:SMSwsdl#getMessagesCount", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	[return: MessageParameter(Name = "return")]
	string getMessagesCount(string domain, string username, string password, string smsType, string from, string box);

	[OperationContract(Action = "urn:SMSwsdl#getMessagesCount", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	Task<string> getMessagesCountAsync(string domain, string username, string password, string smsType, string from, string box);

	[OperationContract(Action = "urn:SMSwsdl#removeMessage", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	[return: MessageParameter(Name = "return")]
	string removeMessage(string domain, string username, string password, string ids, string smsType);

	[OperationContract(Action = "urn:SMSwsdl#removeMessage", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	Task<string> removeMessageAsync(string domain, string username, string password, string ids, string smsType);

	[OperationContract(Action = "http://tehran-payamak.ir/APPs/SMS/WebService.php/getPayAccounts", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	getPayAccountsResponse getPayAccounts(getPayAccountsRequest request);

	[OperationContract(Action = "http://tehran-payamak.ir/APPs/SMS/WebService.php/getPayAccounts", ReplyAction = "*")]
	Task<getPayAccountsResponse> getPayAccountsAsync(getPayAccountsRequest request);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	payRequestResponse payRequest(payRequestRequest request);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	Task<payRequestResponse> payRequestAsync(payRequestRequest request);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	[XmlSerializerFormat(/*Could not decode attribute arguments.*/)]
	[ServiceKnownType(typeof(account))]
	[ServiceKnownType(typeof(message))]
	[ServiceKnownType(typeof(delivery))]
	getCreditPriceResponse getCreditPrice(getCreditPriceRequest request);

	[OperationContract(Action = "urn:SMSwsdl#SMS", ReplyAction = "*")]
	Task<getCreditPriceResponse> getCreditPriceAsync(getCreditPriceRequest request);
}
