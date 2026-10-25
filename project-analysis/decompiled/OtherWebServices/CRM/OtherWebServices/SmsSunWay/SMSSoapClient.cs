using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.SmsSunWay;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class SMSSoapClient : ClientBase<SMSSoap>, SMSSoap
{
	public SMSSoapClient()
	{
	}

	public SMSSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public SMSSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SMSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SMSSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public long[] SendArray(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID)
	{
		return base.Channel.SendArray(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public Task<long[]> SendArrayAsync(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID)
	{
		return base.Channel.SendArrayAsync(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public long[] SendArrayLikeToLike(string UserName, string Password, string[] RecipientNumber, string[] MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID)
	{
		return base.Channel.SendArrayLikeToLike(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public Task<long[]> SendArrayLikeToLikeAsync(string UserName, string Password, string[] RecipientNumber, string[] MessageBody, string SpecialNumber, string IsFlashMessage, long[] CheckingMessageID)
	{
		return base.Channel.SendArrayLikeToLikeAsync(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public long SendItem(string UserName, string Password, string RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long CheckingMessageID)
	{
		return base.Channel.SendItem(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public Task<long> SendItemAsync(string UserName, string Password, string RecipientNumber, string MessageBody, string SpecialNumber, string IsFlashMessage, long CheckingMessageID)
	{
		return base.Channel.SendItemAsync(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, CheckingMessageID);
	}

	public long SendArraySchedule(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, bool IsFlashMessage, int Year, int Month, int Day, int Hour, int Minute)
	{
		return base.Channel.SendArraySchedule(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, Year, Month, Day, Hour, Minute);
	}

	public Task<long> SendArrayScheduleAsync(string UserName, string Password, string[] RecipientNumber, string MessageBody, string SpecialNumber, bool IsFlashMessage, int Year, int Month, int Day, int Hour, int Minute)
	{
		return base.Channel.SendArrayScheduleAsync(UserName, Password, RecipientNumber, MessageBody, SpecialNumber, IsFlashMessage, Year, Month, Day, Hour, Minute);
	}

	public long[] GetMessageID(string UserName, string Password, long[] CheckingMessageID)
	{
		return base.Channel.GetMessageID(UserName, Password, CheckingMessageID);
	}

	public Task<long[]> GetMessageIDAsync(string UserName, string Password, long[] CheckingMessageID)
	{
		return base.Channel.GetMessageIDAsync(UserName, Password, CheckingMessageID);
	}

	public long[] GetMessageStatus(string UserName, string Password, long[] MessageID)
	{
		return base.Channel.GetMessageStatus(UserName, Password, MessageID);
	}

	public Task<long[]> GetMessageStatusAsync(string UserName, string Password, long[] MessageID)
	{
		return base.Channel.GetMessageStatusAsync(UserName, Password, MessageID);
	}

	public long SendNumberGroup(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber)
	{
		return base.Channel.SendNumberGroup(UserName, Password, NumberGroupID, MessageBody, SpecialNumber, IsFlashMessage, DontSendToRepeatedNumber);
	}

	public Task<long> SendNumberGroupAsync(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber)
	{
		return base.Channel.SendNumberGroupAsync(UserName, Password, NumberGroupID, MessageBody, SpecialNumber, IsFlashMessage, DontSendToRepeatedNumber);
	}

	public long SendNumberGroupSchedule(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber, int Year, int Month, int Day, int Hour, int Minute)
	{
		return base.Channel.SendNumberGroupSchedule(UserName, Password, NumberGroupID, MessageBody, SpecialNumber, IsFlashMessage, DontSendToRepeatedNumber, Year, Month, Day, Hour, Minute);
	}

	public Task<long> SendNumberGroupScheduleAsync(string UserName, string Password, long[] NumberGroupID, string MessageBody, string SpecialNumber, bool IsFlashMessage, bool DontSendToRepeatedNumber, int Year, int Month, int Day, int Hour, int Minute)
	{
		return base.Channel.SendNumberGroupScheduleAsync(UserName, Password, NumberGroupID, MessageBody, SpecialNumber, IsFlashMessage, DontSendToRepeatedNumber, Year, Month, Day, Hour, Minute);
	}

	public NumberGroupItem[] GetNumberGroupData(string UserName, string Password)
	{
		return base.Channel.GetNumberGroupData(UserName, Password);
	}

	public Task<NumberGroupItem[]> GetNumberGroupDataAsync(string UserName, string Password)
	{
		return base.Channel.GetNumberGroupDataAsync(UserName, Password);
	}

	public long[] InsertNumberInNumberGroup(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName)
	{
		return base.Channel.InsertNumberInNumberGroup(UserName, Password, NumberGroupID, PersonNumber, PersonName);
	}

	public Task<long[]> InsertNumberInNumberGroupAsync(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName)
	{
		return base.Channel.InsertNumberInNumberGroupAsync(UserName, Password, NumberGroupID, PersonNumber, PersonName);
	}

	public InboxItem[] GetInboxMessage(string UserName, string Password, int NumberOfMessage)
	{
		return base.Channel.GetInboxMessage(UserName, Password, NumberOfMessage);
	}

	public Task<InboxItem[]> GetInboxMessageAsync(string UserName, string Password, int NumberOfMessage)
	{
		return base.Channel.GetInboxMessageAsync(UserName, Password, NumberOfMessage);
	}

	public InboxItem[] GetInboxMessageWithNumber(string UserName, string Password, int NumberOfMessage, string SpecialNumber)
	{
		return base.Channel.GetInboxMessageWithNumber(UserName, Password, NumberOfMessage, SpecialNumber);
	}

	public Task<InboxItem[]> GetInboxMessageWithNumberAsync(string UserName, string Password, int NumberOfMessage, string SpecialNumber)
	{
		return base.Channel.GetInboxMessageWithNumberAsync(UserName, Password, NumberOfMessage, SpecialNumber);
	}

	public long GetCredit(string UserName, string Password)
	{
		return base.Channel.GetCredit(UserName, Password);
	}

	public Task<long> GetCreditAsync(string UserName, string Password)
	{
		return base.Channel.GetCreditAsync(UserName, Password);
	}

	public ProfileInfo GetUserInfo(string UserName, string Password)
	{
		return base.Channel.GetUserInfo(UserName, Password);
	}

	public Task<ProfileInfo> GetUserInfoAsync(string UserName, string Password)
	{
		return base.Channel.GetUserInfoAsync(UserName, Password);
	}

	public ResultInbox GetInboxMessageWithInboxID(string UserName, string Password, int NumberOfMessage, int InboxID, bool IsReaded)
	{
		return base.Channel.GetInboxMessageWithInboxID(UserName, Password, NumberOfMessage, InboxID, IsReaded);
	}

	public Task<ResultInbox> GetInboxMessageWithInboxIDAsync(string UserName, string Password, int NumberOfMessage, int InboxID, bool IsReaded)
	{
		return base.Channel.GetInboxMessageWithInboxIDAsync(UserName, Password, NumberOfMessage, InboxID, IsReaded);
	}
}
