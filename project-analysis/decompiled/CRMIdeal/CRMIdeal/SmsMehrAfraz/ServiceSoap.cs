using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.SmsMehrAfraz;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SmsMehrAfraz.ServiceSoap")]
public interface ServiceSoap
{
	[OperationContract(Action = "http://tempuri.org/ApikeySendsmsphonebook", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ApikeySendsmsphonebook(string cApikey, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid);

	[OperationContract(Action = "http://tempuri.org/ApikeySendsmsphonebook", ReplyAction = "*")]
	Task<string> ApikeySendsmsphonebookAsync(string cApikey, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid);

	[OperationContract(Action = "http://tempuri.org/ApikeySENDVERIFICATIONCODE", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ApikeySENDVERIFICATIONCODE(string cApikey, string cMobileno, int nVerificationid, int nCodeVerification);

	[OperationContract(Action = "http://tempuri.org/ApikeySENDVERIFICATIONCODE", ReplyAction = "*")]
	Task<string> ApikeySENDVERIFICATIONCODEAsync(string cApikey, string cMobileno, int nVerificationid, int nCodeVerification);

	[OperationContract(Action = "http://tempuri.org/Apikeyaddinphonebook", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string Apikeyaddinphonebook(string cApikey, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid);

	[OperationContract(Action = "http://tempuri.org/Apikeyaddinphonebook", ReplyAction = "*")]
	Task<string> ApikeyaddinphonebookAsync(string cApikey, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetReciveMessagein7array", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyGetReciveMessagein7array(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetReciveMessagein7array", ReplyAction = "*")]
	Task<string[]> ApikeyGetReciveMessagein7arrayAsync(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetNumber", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyGetNumber(string cApikey);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetNumber", ReplyAction = "*")]
	Task<string[]> ApikeyGetNumberAsync(string cApikey);

	[OperationContract(Action = "http://tempuri.org/Apikeychargeuser", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string Apikeychargeuser(string cApikey, string cUsercharge, long nCharge, string cDesCharge);

	[OperationContract(Action = "http://tempuri.org/Apikeychargeuser", ReplyAction = "*")]
	Task<string> ApikeychargeuserAsync(string cApikey, string cUsercharge, long nCharge, string cDesCharge);

	[OperationContract(Action = "http://tempuri.org/ApikeyActivateCentral", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ApikeyActivateCentral(string cApikey, string cSerial, bool lActivationType);

	[OperationContract(Action = "http://tempuri.org/ApikeyActivateCentral", ReplyAction = "*")]
	Task<string> ApikeyActivateCentralAsync(string cApikey, string cSerial, bool lActivationType);

	[OperationContract(Action = "http://tempuri.org/ApikeySantralConfig", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeySantralConfig(string cApikey, string cCommand, int typeodata, string[] cValues, string[] cDatas);

	[OperationContract(Action = "http://tempuri.org/ApikeySantralConfig", ReplyAction = "*")]
	Task<string[]> ApikeySantralConfigAsync(string cApikey, string cCommand, int typeodata, string[] cValues, string[] cDatas);

	[OperationContract(Action = "http://tempuri.org/ApikeySendSms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ApikeySendSms(string cApikey, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime);

	[OperationContract(Action = "http://tempuri.org/ApikeySendSms", ReplyAction = "*")]
	Task<string> ApikeySendSmsAsync(string cApikey, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime);

	[OperationContract(Action = "http://tempuri.org/ApikeySendSms1To1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] ApikeySendSms1To1(string cApikey, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin);

	[OperationContract(Action = "http://tempuri.org/ApikeySendSms1To1", ReplyAction = "*")]
	Task<long[]> ApikeySendSms1To1Async(string cApikey, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetDelivery", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyGetDelivery(string cApikey, string[] aSid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetDelivery", ReplyAction = "*")]
	Task<string[]> ApikeyGetDeliveryAsync(string cApikey, string[] aSid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetuserInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyGetuserInfo(string cApikey);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetuserInfo", ReplyAction = "*")]
	Task<string[]> ApikeyGetuserInfoAsync(string cApikey);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetDeliveryWithGetid", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyGetDeliveryWithGetid(string cApikey, string cGetid, bool lReturnSid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetDeliveryWithGetid", ReplyAction = "*")]
	Task<string[]> ApikeyGetDeliveryWithGetidAsync(string cApikey, string cGetid, bool lReturnSid);

	[OperationContract(Action = "http://tempuri.org/ApikeyReceivesmsLowLevel", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ApikeyReceivesmsLowLevelResponse ApikeyReceivesmsLowLevel(ApikeyReceivesmsLowLevelRequest request);

	[OperationContract(Action = "http://tempuri.org/ApikeyReceivesmsLowLevel", ReplyAction = "*")]
	Task<ApikeyReceivesmsLowLevelResponse> ApikeyReceivesmsLowLevelAsync(ApikeyReceivesmsLowLevelRequest request);

	[OperationContract(Action = "http://tempuri.org/ApikeyReceiveSms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	DataTable ApikeyReceiveSms(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/ApikeyReceiveSms", ReplyAction = "*")]
	Task<DataTable> ApikeyReceiveSmsAsync(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate);

	[OperationContract(Action = "http://tempuri.org/ApikeyDeleteReceivedMessages", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] ApikeyDeleteReceivedMessages(string cApikey, long[] nMessageIds);

	[OperationContract(Action = "http://tempuri.org/ApikeyDeleteReceivedMessages", ReplyAction = "*")]
	Task<string[]> ApikeyDeleteReceivedMessagesAsync(string cApikey, long[] nMessageIds);

	[OperationContract(Action = "http://tempuri.org/ApikeyChangeReceiveNo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string ApikeyChangeReceiveNo(string cApikey, bool lReceiveAllmsg, string cFromNumber);

	[OperationContract(Action = "http://tempuri.org/ApikeyChangeReceiveNo", ReplyAction = "*")]
	Task<string> ApikeyChangeReceiveNoAsync(string cApikey, bool lReceiveAllmsg, string cFromNumber);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetMessageDelivery1to1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int[] ApikeyGetMessageDelivery1to1(string cApikey, long[] longid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetMessageDelivery1to1", ReplyAction = "*")]
	Task<int[]> ApikeyGetMessageDelivery1to1Async(string cApikey, long[] longid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetMessageDelivery1to1V2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] ApikeyGetMessageDelivery1to1V2(string cApikey, long[] longid);

	[OperationContract(Action = "http://tempuri.org/ApikeyGetMessageDelivery1to1V2", ReplyAction = "*")]
	Task<long[]> ApikeyGetMessageDelivery1to1V2Async(string cApikey, long[] longid);

	[OperationContract(Action = "http://tempuri.org/ApikeygetMessageIds1to1", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] ApikeygetMessageIds1to1(string cApikey, long[] nCustomerid);

	[OperationContract(Action = "http://tempuri.org/ApikeygetMessageIds1to1", ReplyAction = "*")]
	Task<long[]> ApikeygetMessageIds1to1Async(string cApikey, long[] nCustomerid);

	[OperationContract(Action = "http://tempuri.org/GenerateApiKey", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string GenerateApiKey(string cDomainName, string cUsername, string cPassword, int nlentgh);

	[OperationContract(Action = "http://tempuri.org/GenerateApiKey", ReplyAction = "*")]
	Task<string> GenerateApiKeyAsync(string cDomainName, string cUsername, string cPassword, int nlentgh);

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

	[OperationContract(Action = "http://tempuri.org/GetuserInfoold", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string GetuserInfoold(string cUserName, string cPassword);

	[OperationContract(Action = "http://tempuri.org/GetuserInfoold", ReplyAction = "*")]
	Task<string> GetuserInfooldAsync(string cUserName, string cPassword);

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

	[OperationContract(Action = "http://tempuri.org/GetMessageDelivery1to1V2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	long[] GetMessageDelivery1to1V2(string cUserName, string cPassword, string cDomainname, long[] longid);

	[OperationContract(Action = "http://tempuri.org/GetMessageDelivery1to1V2", ReplyAction = "*")]
	Task<long[]> GetMessageDelivery1to1V2Async(string cUserName, string cPassword, string cDomainname, long[] longid);

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

	[OperationContract(Action = "http://tempuri.org/CheckDeliverFromServer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string CheckDeliverFromServer(int nAccountUsesid, int ntypeSms);

	[OperationContract(Action = "http://tempuri.org/CheckDeliverFromServer", ReplyAction = "*")]
	Task<string> CheckDeliverFromServerAsync(int nAccountUsesid, int ntypeSms);
}
