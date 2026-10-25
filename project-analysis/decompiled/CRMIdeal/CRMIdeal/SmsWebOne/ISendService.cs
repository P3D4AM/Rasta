using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.SmsWebOne;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SmsWebOne.ISendService")]
public interface ISendService
{
	[OperationContract(Action = "http://tempuri.org/ISendService/SendSMS", ReplyAction = "http://tempuri.org/ISendService/SendSMSResponse")]
	SendSMSResponse SendSMS(SendSMSRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/SendSMS", ReplyAction = "http://tempuri.org/ISendService/SendSMSResponse")]
	Task<SendSMSResponse> SendSMSAsync(SendSMSRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetCredit", ReplyAction = "http://tempuri.org/ISendService/GetCreditResponse")]
	decimal GetCredit(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetCredit", ReplyAction = "http://tempuri.org/ISendService/GetCreditResponse")]
	Task<decimal> GetCreditAsync(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDeilvery", ReplyAction = "http://tempuri.org/ISendService/GetDeilveryResponse")]
	long GetDeilvery(string userName, string password, long recId);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDeilvery", ReplyAction = "http://tempuri.org/ISendService/GetDeilveryResponse")]
	Task<long> GetDeilveryAsync(string userName, string password, long recId);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDelivery", ReplyAction = "http://tempuri.org/ISendService/GetDeliveryResponse")]
	long GetDelivery(string userName, string password, long recId);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDelivery", ReplyAction = "http://tempuri.org/ISendService/GetDeliveryResponse")]
	Task<long> GetDeliveryAsync(string userName, string password, long recId);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetMessages", ReplyAction = "http://tempuri.org/ISendService/GetMessagesResponse")]
	MessageInfo[] GetMessages(string userName, string password, int messageType, string[] fromNumbers, int index, int count);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetMessages", ReplyAction = "http://tempuri.org/ISendService/GetMessagesResponse")]
	Task<MessageInfo[]> GetMessagesAsync(string userName, string password, int messageType, string[] fromNumbers, int index, int count);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetMessagesByDateRange", ReplyAction = "http://tempuri.org/ISendService/GetMessagesByDateRangeResponse")]
	MessageInfo[] GetMessagesByDateRange(string userName, string password, int messageType, string[] fromNumbers, DateTime fromDate, DateTime toDate);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetMessagesByDateRange", ReplyAction = "http://tempuri.org/ISendService/GetMessagesByDateRangeResponse")]
	Task<MessageInfo[]> GetMessagesByDateRangeAsync(string userName, string password, int messageType, string[] fromNumbers, DateTime fromDate, DateTime toDate);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetInboxCount", ReplyAction = "http://tempuri.org/ISendService/GetInboxCountResponse")]
	int GetInboxCount(string userName, string password, bool isRead);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetInboxCount", ReplyAction = "http://tempuri.org/ISendService/GetInboxCountResponse")]
	Task<int> GetInboxCountAsync(string userName, string password, bool isRead);

	[OperationContract(Action = "http://tempuri.org/ISendService/SendBatchSms", ReplyAction = "http://tempuri.org/ISendService/SendBatchSmsResponse")]
	SendBatchSmsResponse SendBatchSms(SendBatchSmsRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/SendBatchSms", ReplyAction = "http://tempuri.org/ISendService/SendBatchSmsResponse")]
	Task<SendBatchSmsResponse> SendBatchSmsAsync(SendBatchSmsRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetBatchDelivery", ReplyAction = "http://tempuri.org/ISendService/GetBatchDeliveryResponse")]
	GetBatchDeliveryResponse GetBatchDelivery(GetBatchDeliveryRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetBatchDelivery", ReplyAction = "http://tempuri.org/ISendService/GetBatchDeliveryResponse")]
	Task<GetBatchDeliveryResponse> GetBatchDeliveryAsync(GetBatchDeliveryRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetSenderNumbers", ReplyAction = "http://tempuri.org/ISendService/GetSenderNumbersResponse")]
	string GetSenderNumbers(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetSenderNumbers", ReplyAction = "http://tempuri.org/ISendService/GetSenderNumbersResponse")]
	Task<string> GetSenderNumbersAsync(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/ISendService/SendSmsLikeToLike", ReplyAction = "http://tempuri.org/ISendService/SendSmsLikeToLikeResponse")]
	SendSmsLikeToLikeResponse SendSmsLikeToLike(SendSmsLikeToLikeRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/SendSmsLikeToLike", ReplyAction = "http://tempuri.org/ISendService/SendSmsLikeToLikeResponse")]
	Task<SendSmsLikeToLikeResponse> SendSmsLikeToLikeAsync(SendSmsLikeToLikeRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDeliveryLikeToLike", ReplyAction = "http://tempuri.org/ISendService/GetDeliveryLikeToLikeResponse")]
	GetDeliveryLikeToLikeResponse GetDeliveryLikeToLike(GetDeliveryLikeToLikeRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/GetDeliveryLikeToLike", ReplyAction = "http://tempuri.org/ISendService/GetDeliveryLikeToLikeResponse")]
	Task<GetDeliveryLikeToLikeResponse> GetDeliveryLikeToLikeAsync(GetDeliveryLikeToLikeRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/ExtractTelecomBlacklistNumbers", ReplyAction = "http://tempuri.org/ISendService/ExtractTelecomBlacklistNumbersResponse")]
	ExtractTelecomBlacklistNumbersResponse ExtractTelecomBlacklistNumbers(ExtractTelecomBlacklistNumbersRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/ExtractTelecomBlacklistNumbers", ReplyAction = "http://tempuri.org/ISendService/ExtractTelecomBlacklistNumbersResponse")]
	Task<ExtractTelecomBlacklistNumbersResponse> ExtractTelecomBlacklistNumbersAsync(ExtractTelecomBlacklistNumbersRequest request);

	[OperationContract(Action = "http://tempuri.org/ISendService/NumberIsInTelecomBlacklist", ReplyAction = "http://tempuri.org/ISendService/NumberIsInTelecomBlacklistResponse")]
	int NumberIsInTelecomBlacklist(string userName, string password, string number);

	[OperationContract(Action = "http://tempuri.org/ISendService/NumberIsInTelecomBlacklist", ReplyAction = "http://tempuri.org/ISendService/NumberIsInTelecomBlacklistResponse")]
	Task<int> NumberIsInTelecomBlacklistAsync(string userName, string password, string number);

	[OperationContract(Action = "http://tempuri.org/ISendService/CheckSmsContent", ReplyAction = "http://tempuri.org/ISendService/CheckSmsContentResponse")]
	int CheckSmsContent(string userName, string password, string message);

	[OperationContract(Action = "http://tempuri.org/ISendService/CheckSmsContent", ReplyAction = "http://tempuri.org/ISendService/CheckSmsContentResponse")]
	Task<int> CheckSmsContentAsync(string userName, string password, string message);

	[OperationContract(Action = "http://tempuri.org/ISendService/Dummy", ReplyAction = "http://tempuri.org/ISendService/DummyResponse")]
	int Dummy(int number);

	[OperationContract(Action = "http://tempuri.org/ISendService/Dummy", ReplyAction = "http://tempuri.org/ISendService/DummyResponse")]
	Task<int> DummyAsync(int number);
}
