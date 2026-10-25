using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Mobile.SmsMehrAfraz;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SmsMehrAfraz.ServiceSoap")]
public interface ServiceSoap
{
	[OperationContract(Action = "http://tempuri.org/Sendsmsphonebook", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string Sendsmsphonebook(string cUserName, string cPassword, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid);

	[OperationContract(Action = "http://tempuri.org/Sendsmsphonebook", ReplyAction = "*")]
	Task<string> SendsmsphonebookAsync(string cUserName, string cPassword, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid);

	[OperationContract(Action = "http://tempuri.org/SENDVERIFICATIONCODE", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SENDVERIFICATIONCODE(string cDomainName, string cUsername, string cPassword, string cMobileno, int nVerificationid, int nCodeVerification);

	[OperationContract(Action = "http://tempuri.org/SENDVERIFICATIONCODE", ReplyAction = "*")]
	Task<string> SENDVERIFICATIONCODEAsync(string cDomainName, string cUsername, string cPassword, string cMobileno, int nVerificationid, int nCodeVerification);

	[OperationContract(Action = "http://tempuri.org/addinphonebook", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string addinphonebook(string cDomainName, string cUsername, string cPassword, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid);

	[OperationContract(Action = "http://tempuri.org/addinphonebook", ReplyAction = "*")]
	Task<string> addinphonebookAsync(string cDomainName, string cUsername, string cPassword, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid);

	[OperationContract(Action = "http://tempuri.org/GetReciveMessagein7array", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetReciveMessagein7array(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/GetReciveMessagein7array", ReplyAction = "*")]
	Task<string[]> GetReciveMessagein7arrayAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/GetNumber", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetNumber(string cDomainname, string cUsername, string cpassword);

	[OperationContract(Action = "http://tempuri.org/GetNumber", ReplyAction = "*")]
	Task<string[]> GetNumberAsync(string cDomainname, string cUsername, string cpassword);

	[OperationContract(Action = "http://tempuri.org/ForgetPassword", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ForgetPassword(string cDomainname, string cUsername, string cMobileno);

	[OperationContract(Action = "http://tempuri.org/ForgetPassword", ReplyAction = "*")]
	Task<string> ForgetPasswordAsync(string cDomainname, string cUsername, string cMobileno);

	[OperationContract(Action = "http://tempuri.org/chargeuser", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string chargeuser(string cDomainname, string cUsername, string cpassword, string cUsercharge, long nCharge, string cDesCharge);

	[OperationContract(Action = "http://tempuri.org/chargeuser", ReplyAction = "*")]
	Task<string> chargeuserAsync(string cDomainname, string cUsername, string cpassword, string cUsercharge, long nCharge, string cDesCharge);

	[OperationContract(Action = "http://tempuri.org/ActivateCentral", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ActivateCentral(string cUSername, string cPassword, string cDomainname, string cSerial, bool lActivationType);

	[OperationContract(Action = "http://tempuri.org/ActivateCentral", ReplyAction = "*")]
	Task<string> ActivateCentralAsync(string cUSername, string cPassword, string cDomainname, string cSerial, bool lActivationType);

	[OperationContract(Action = "http://tempuri.org/SantralData", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SantralData(string cUSername, string cPassword, string cDomainname, string cData);

	[OperationContract(Action = "http://tempuri.org/SantralData", ReplyAction = "*")]
	Task<string> SantralDataAsync(string cUSername, string cPassword, string cDomainname, string cData);

	[OperationContract(Action = "http://tempuri.org/SantralConfig", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] SantralConfig(string cUSername, string cPassword, string cDomainname, string cCommand, int typeodata, string[] cValues, string[] cDatas);

	[OperationContract(Action = "http://tempuri.org/SantralConfig", ReplyAction = "*")]
	Task<string[]> SantralConfigAsync(string cUSername, string cPassword, string cDomainname, string cCommand, int typeodata, string[] cValues, string[] cDatas);

	[OperationContract(Action = "http://tempuri.org/SendSmsShort", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSmsShort(string cUserName, string cPassword, string cBody, string cSmsnumber, string cDomainname);

	[OperationContract(Action = "http://tempuri.org/SendSmsShort", ReplyAction = "*")]
	Task<string> SendSmsShortAsync(string cUserName, string cPassword, string cBody, string cSmsnumber, string cDomainname);

	[OperationContract(Action = "http://tempuri.org/SendSms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSms(string cUserName, string cPassword, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime);

	[OperationContract(Action = "http://tempuri.org/SendSms", ReplyAction = "*")]
	Task<string> SendSmsAsync(string cUserName, string cPassword, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime);

	[OperationContract(Action = "http://tempuri.org/SendSms1To1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] SendSms1To1(string cDomainname, string cUserName, string cPassword, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin);

	[OperationContract(Action = "http://tempuri.org/SendSms1To1", ReplyAction = "*")]
	Task<long[]> SendSms1To1Async(string cDomainname, string cUserName, string cPassword, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin);

	[OperationContract(Action = "http://tempuri.org/GetDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetDelivery(string cUserName, string cPassword, string[] aSid);

	[OperationContract(Action = "http://tempuri.org/GetDelivery", ReplyAction = "*")]
	Task<string[]> GetDeliveryAsync(string cUserName, string cPassword, string[] aSid);

	[OperationContract(Action = "http://tempuri.org/ChangePassword", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ChangePassword(string cUserName, string cPassword, string cNewPassword, string cDomainName);

	[OperationContract(Action = "http://tempuri.org/ChangePassword", ReplyAction = "*")]
	Task<string> ChangePasswordAsync(string cUserName, string cPassword, string cNewPassword, string cDomainName);

	[OperationContract(Action = "http://tempuri.org/GetuserInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetuserInfo(string cUserName, string cPassword, string cDomainName);

	[OperationContract(Action = "http://tempuri.org/GetuserInfo", ReplyAction = "*")]
	Task<string[]> GetuserInfoAsync(string cUserName, string cPassword, string cDomainName);

	[OperationContract(Action = "http://tempuri.org/GetDeliveryWithGetid", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] GetDeliveryWithGetid(string cUserName, string cPassword, string cGetid, bool lReturnSid, string cDomainname);

	[OperationContract(Action = "http://tempuri.org/GetDeliveryWithGetid", ReplyAction = "*")]
	Task<string[]> GetDeliveryWithGetidAsync(string cUserName, string cPassword, string cGetid, bool lReturnSid, string cDomainname);

	[OperationContract(Action = "http://tempuri.org/ReceivesmsLowLevel", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ReceivesmsLowLevelResponse ReceivesmsLowLevel(ReceivesmsLowLevelRequest request);

	[OperationContract(Action = "http://tempuri.org/ReceivesmsLowLevel", ReplyAction = "*")]
	Task<ReceivesmsLowLevelResponse> ReceivesmsLowLevelAsync(ReceivesmsLowLevelRequest request);

	[OperationContract(Action = "http://tempuri.org/ReceiveSms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	DataTable ReceiveSms(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/ReceiveSms", ReplyAction = "*")]
	Task<DataTable> ReceiveSmsAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/DeleteReceivedMessages", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] DeleteReceivedMessages(string cUserName, string cPassword, string cDomainName, long[] nMessageIds);

	[OperationContract(Action = "http://tempuri.org/DeleteReceivedMessages", ReplyAction = "*")]
	Task<string[]> DeleteReceivedMessagesAsync(string cUserName, string cPassword, string cDomainName, long[] nMessageIds);

	[OperationContract(Action = "http://tempuri.org/ChangeReceiveNo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ChangeReceiveNo(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromNumber);

	[OperationContract(Action = "http://tempuri.org/ChangeReceiveNo", ReplyAction = "*")]
	Task<string> ChangeReceiveNoAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromNumber);

	[OperationContract(Action = "http://tempuri.org/GetMessageDelivery1to1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int[] GetMessageDelivery1to1(string cUserName, string cPassword, string cDomainname, long[] longid);

	[OperationContract(Action = "http://tempuri.org/GetMessageDelivery1to1", ReplyAction = "*")]
	Task<int[]> GetMessageDelivery1to1Async(string cUserName, string cPassword, string cDomainname, long[] longid);

	[OperationContract(Action = "http://tempuri.org/getMessageIds1to1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] getMessageIds1to1(string cUserName, string cPassword, string cDomainname, long[] nCustomerid);

	[OperationContract(Action = "http://tempuri.org/getMessageIds1to1", ReplyAction = "*")]
	Task<long[]> getMessageIds1to1Async(string cUserName, string cPassword, string cDomainname, long[] nCustomerid);

	[OperationContract(Action = "http://tempuri.org/ShowError", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ShowError(string cErrorCode, string cLanShow);

	[OperationContract(Action = "http://tempuri.org/ShowError", ReplyAction = "*")]
	Task<string> ShowErrorAsync(string cErrorCode, string cLanShow);

	[OperationContract(Action = "http://tempuri.org/GetMessageLength", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetMessageLength(string cBody);

	[OperationContract(Action = "http://tempuri.org/GetMessageLength", ReplyAction = "*")]
	Task<int> GetMessageLengthAsync(string cBody);

	[OperationContract(Action = "http://tempuri.org/GetUnicodeMessage", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetUnicodeMessage(string cBody);

	[OperationContract(Action = "http://tempuri.org/GetUnicodeMessage", ReplyAction = "*")]
	Task<int> GetUnicodeMessageAsync(string cBody);

	[OperationContract(Action = "http://tempuri.org/mehrafrazDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] mehrafrazDelivery(string cCommand, string cFormatSms, long[] asid, int[] nsmsstatus, string[] adate);

	[OperationContract(Action = "http://tempuri.org/mehrafrazDelivery", ReplyAction = "*")]
	Task<long[]> mehrafrazDeliveryAsync(string cCommand, string cFormatSms, long[] asid, int[] nsmsstatus, string[] adate);
}
