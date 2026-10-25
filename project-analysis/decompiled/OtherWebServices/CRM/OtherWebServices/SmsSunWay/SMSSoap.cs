using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.SmsSunWay;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SmsSunWay.SMSSoap")]
public interface SMSSoap
{
	[OperationContract(Action = "http://tempuri.org/SendArray", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] SendArray(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendArray", ReplyAction = "*")]
	Task<long[]> SendArrayAsync(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendArrayLikeToLike", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] SendArrayLikeToLike(string UserName, string Password, string[] RecipientNumber, string[] MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendArrayLikeToLike", ReplyAction = "*")]
	Task<long[]> SendArrayLikeToLikeAsync(string UserName, string Password, string[] RecipientNumber, string[] MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendItem", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long SendItem(string UserName, string Password, string RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendItem", ReplyAction = "*")]
	Task<long> SendItemAsync(string UserName, string Password, string RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/SendArraySchedule", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long SendArraySchedule(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, bool IsFlashMessage, int Year, int Month, int Day, int Hour, int Minute);

	[OperationContract(Action = "http://tempuri.org/SendArraySchedule", ReplyAction = "*")]
	Task<long> SendArrayScheduleAsync(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, bool IsFlashMessage, int Year, int Month, int Day, int Hour, int Minute);

	[OperationContract(Action = "http://tempuri.org/GetMessageID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] GetMessageID(string UserName, string Password, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/GetMessageID", ReplyAction = "*")]
	Task<long[]> GetMessageIDAsync(string UserName, string Password, long[] CheckingMessageID);

	[OperationContract(Action = "http://tempuri.org/GetMessageStatus", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] GetMessageStatus(string UserName, string Password, long[] MessageID);

	[OperationContract(Action = "http://tempuri.org/GetMessageStatus", ReplyAction = "*")]
	Task<long[]> GetMessageStatusAsync(string UserName, string Password, long[] MessageID);

	[OperationContract(Action = "http://tempuri.org/SendNumberGroup", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long SendNumberGroup(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber);

	[OperationContract(Action = "http://tempuri.org/SendNumberGroup", ReplyAction = "*")]
	Task<long> SendNumberGroupAsync(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber);

	[OperationContract(Action = "http://tempuri.org/SendNumberGroupSchedule", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long SendNumberGroupSchedule(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber, int Year, int Month, int Day, int Hour, int Minute);

	[OperationContract(Action = "http://tempuri.org/SendNumberGroupSchedule", ReplyAction = "*")]
	Task<long> SendNumberGroupScheduleAsync(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber, int Year, int Month, int Day, int Hour, int Minute);

	[OperationContract(Action = "http://tempuri.org/GetNumberGroupData", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	NumberGroupItem[] GetNumberGroupData(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/GetNumberGroupData", ReplyAction = "*")]
	Task<NumberGroupItem[]> GetNumberGroupDataAsync(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/InsertNumberInNumberGroup", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	long[] InsertNumberInNumberGroup(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName);

	[OperationContract(Action = "http://tempuri.org/InsertNumberInNumberGroup", ReplyAction = "*")]
	Task<long[]> InsertNumberInNumberGroupAsync(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessage", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	InboxItem[] GetInboxMessage(string UserName, string Password, int NumberOfMessage);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessage", ReplyAction = "*")]
	Task<InboxItem[]> GetInboxMessageAsync(string UserName, string Password, int NumberOfMessage);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessageWithNumber", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	InboxItem[] GetInboxMessageWithNumber(string UserName, string Password, int NumberOfMessage, string SpecialNumber);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessageWithNumber", ReplyAction = "*")]
	Task<InboxItem[]> GetInboxMessageWithNumberAsync(string UserName, string Password, int NumberOfMessage, string SpecialNumber);

	[OperationContract(Action = "http://tempuri.org/GetCredit", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	long GetCredit(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/GetCredit", ReplyAction = "*")]
	Task<long> GetCreditAsync(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/GetUserInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	ProfileInfo GetUserInfo(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/GetUserInfo", ReplyAction = "*")]
	Task<ProfileInfo> GetUserInfoAsync(string UserName, string Password);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessageWithInboxID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(ResultBase))]
	ResultInbox GetInboxMessageWithInboxID(string UserName, string Password, int NumberOfMessage, int InboxID, bool IsReaded);

	[OperationContract(Action = "http://tempuri.org/GetInboxMessageWithInboxID", ReplyAction = "*")]
	Task<ResultInbox> GetInboxMessageWithInboxIDAsync(string UserName, string Password, int NumberOfMessage, int InboxID, bool IsReaded);
}
