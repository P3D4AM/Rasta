using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.SmsMehrAfraz;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class ServiceSoapClient : ClientBase<ServiceSoap>, ServiceSoap
{
	public ServiceSoapClient()
	{
	}

	public ServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public string ApikeySendsmsphonebook(string cApikey, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid)
	{
		return base.Channel.ApikeySendsmsphonebook(cApikey, cBody, cGetid, nTypeSent, m_SchedulDate, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime, groupphonebook, isgroupid);
	}

	public Task<string> ApikeySendsmsphonebookAsync(string cApikey, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid)
	{
		return base.Channel.ApikeySendsmsphonebookAsync(cApikey, cBody, cGetid, nTypeSent, m_SchedulDate, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime, groupphonebook, isgroupid);
	}

	public string ApikeySENDVERIFICATIONCODE(string cApikey, string cMobileno, int nVerificationid, int nCodeVerification)
	{
		return base.Channel.ApikeySENDVERIFICATIONCODE(cApikey, cMobileno, nVerificationid, nCodeVerification);
	}

	public Task<string> ApikeySENDVERIFICATIONCODEAsync(string cApikey, string cMobileno, int nVerificationid, int nCodeVerification)
	{
		return base.Channel.ApikeySENDVERIFICATIONCODEAsync(cApikey, cMobileno, nVerificationid, nCodeVerification);
	}

	public string Apikeyaddinphonebook(string cApikey, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid)
	{
		return base.Channel.Apikeyaddinphonebook(cApikey, phonebookcode, cMobileno, Companyname, Fullname, sexid);
	}

	public Task<string> ApikeyaddinphonebookAsync(string cApikey, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid)
	{
		return base.Channel.ApikeyaddinphonebookAsync(cApikey, phonebookcode, cMobileno, Companyname, Fullname, sexid);
	}

	public string[] ApikeyGetReciveMessagein7array(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ApikeyGetReciveMessagein7array(cApikey, lReceiveAllmsg, cFromnumber, cFromDate, cToDate);
	}

	public Task<string[]> ApikeyGetReciveMessagein7arrayAsync(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ApikeyGetReciveMessagein7arrayAsync(cApikey, lReceiveAllmsg, cFromnumber, cFromDate, cToDate);
	}

	public string[] ApikeyGetNumber(string cApikey)
	{
		return base.Channel.ApikeyGetNumber(cApikey);
	}

	public Task<string[]> ApikeyGetNumberAsync(string cApikey)
	{
		return base.Channel.ApikeyGetNumberAsync(cApikey);
	}

	public string Apikeychargeuser(string cApikey, string cUsercharge, long nCharge, string cDesCharge)
	{
		return base.Channel.Apikeychargeuser(cApikey, cUsercharge, nCharge, cDesCharge);
	}

	public Task<string> ApikeychargeuserAsync(string cApikey, string cUsercharge, long nCharge, string cDesCharge)
	{
		return base.Channel.ApikeychargeuserAsync(cApikey, cUsercharge, nCharge, cDesCharge);
	}

	public string ApikeyActivateCentral(string cApikey, string cSerial, bool lActivationType)
	{
		return base.Channel.ApikeyActivateCentral(cApikey, cSerial, lActivationType);
	}

	public Task<string> ApikeyActivateCentralAsync(string cApikey, string cSerial, bool lActivationType)
	{
		return base.Channel.ApikeyActivateCentralAsync(cApikey, cSerial, lActivationType);
	}

	public string[] ApikeySantralConfig(string cApikey, string cCommand, int typeodata, string[] cValues, string[] cDatas)
	{
		return base.Channel.ApikeySantralConfig(cApikey, cCommand, typeodata, cValues, cDatas);
	}

	public Task<string[]> ApikeySantralConfigAsync(string cApikey, string cCommand, int typeodata, string[] cValues, string[] cDatas)
	{
		return base.Channel.ApikeySantralConfigAsync(cApikey, cCommand, typeodata, cValues, cDatas);
	}

	public string ApikeySendSms(string cApikey, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime)
	{
		return base.Channel.ApikeySendSms(cApikey, cBody, cSmsnumber, cGetid, nCMessage, nTypeSent, m_SchedulDate, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime);
	}

	public Task<string> ApikeySendSmsAsync(string cApikey, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime)
	{
		return base.Channel.ApikeySendSmsAsync(cApikey, cBody, cSmsnumber, cGetid, nCMessage, nTypeSent, m_SchedulDate, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime);
	}

	public long[] ApikeySendSms1To1(string cApikey, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin)
	{
		return base.Channel.ApikeySendSms1To1(cApikey, aBody, aMobileno, aGetid, aCMessage, aFromNumber, atypeUnicodemessage, am_SchedulDate, nTypeSent, nSpeedsms, nPeriodmin);
	}

	public Task<long[]> ApikeySendSms1To1Async(string cApikey, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin)
	{
		return base.Channel.ApikeySendSms1To1Async(cApikey, aBody, aMobileno, aGetid, aCMessage, aFromNumber, atypeUnicodemessage, am_SchedulDate, nTypeSent, nSpeedsms, nPeriodmin);
	}

	public string[] ApikeyGetDelivery(string cApikey, string[] aSid)
	{
		return base.Channel.ApikeyGetDelivery(cApikey, aSid);
	}

	public Task<string[]> ApikeyGetDeliveryAsync(string cApikey, string[] aSid)
	{
		return base.Channel.ApikeyGetDeliveryAsync(cApikey, aSid);
	}

	public string[] ApikeyGetuserInfo(string cApikey)
	{
		return base.Channel.ApikeyGetuserInfo(cApikey);
	}

	public Task<string[]> ApikeyGetuserInfoAsync(string cApikey)
	{
		return base.Channel.ApikeyGetuserInfoAsync(cApikey);
	}

	public string[] ApikeyGetDeliveryWithGetid(string cApikey, string cGetid, bool lReturnSid)
	{
		return base.Channel.ApikeyGetDeliveryWithGetid(cApikey, cGetid, lReturnSid);
	}

	public Task<string[]> ApikeyGetDeliveryWithGetidAsync(string cApikey, string cGetid, bool lReturnSid)
	{
		return base.Channel.ApikeyGetDeliveryWithGetidAsync(cApikey, cGetid, lReturnSid);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ApikeyReceivesmsLowLevelResponse ServiceSoap.ApikeyReceivesmsLowLevel(ApikeyReceivesmsLowLevelRequest request)
	{
		return base.Channel.ApikeyReceivesmsLowLevel(request);
	}

	public void ApikeyReceivesmsLowLevel(string cApikey, bool lReceiveAllmsg, string cFromnumber, ref string[] aBody, ref string[] aMobileno, ref long[] aMessageid, ref string[] aReceivedate, ref string[] afromnumber)
	{
		ApikeyReceivesmsLowLevelRequest apikeyReceivesmsLowLevelRequest = new ApikeyReceivesmsLowLevelRequest();
		apikeyReceivesmsLowLevelRequest.cApikey = cApikey;
		apikeyReceivesmsLowLevelRequest.lReceiveAllmsg = lReceiveAllmsg;
		apikeyReceivesmsLowLevelRequest.cFromnumber = cFromnumber;
		apikeyReceivesmsLowLevelRequest.aBody = aBody;
		apikeyReceivesmsLowLevelRequest.aMobileno = aMobileno;
		apikeyReceivesmsLowLevelRequest.aMessageid = aMessageid;
		apikeyReceivesmsLowLevelRequest.aReceivedate = aReceivedate;
		apikeyReceivesmsLowLevelRequest.afromnumber = afromnumber;
		ApikeyReceivesmsLowLevelResponse apikeyReceivesmsLowLevelResponse = ((ServiceSoap)this).ApikeyReceivesmsLowLevel(apikeyReceivesmsLowLevelRequest);
		aBody = apikeyReceivesmsLowLevelResponse.aBody;
		aMobileno = apikeyReceivesmsLowLevelResponse.aMobileno;
		aMessageid = apikeyReceivesmsLowLevelResponse.aMessageid;
		aReceivedate = apikeyReceivesmsLowLevelResponse.aReceivedate;
		afromnumber = apikeyReceivesmsLowLevelResponse.afromnumber;
	}

	public Task<ApikeyReceivesmsLowLevelResponse> ApikeyReceivesmsLowLevelAsync(ApikeyReceivesmsLowLevelRequest request)
	{
		return base.Channel.ApikeyReceivesmsLowLevelAsync(request);
	}

	public DataTable ApikeyReceiveSms(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ApikeyReceiveSms(cApikey, lReceiveAllmsg, cFromnumber, cFromDate, cToDate);
	}

	public Task<DataTable> ApikeyReceiveSmsAsync(string cApikey, bool lReceiveAllmsg, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ApikeyReceiveSmsAsync(cApikey, lReceiveAllmsg, cFromnumber, cFromDate, cToDate);
	}

	public string[] ApikeyDeleteReceivedMessages(string cApikey, long[] nMessageIds)
	{
		return base.Channel.ApikeyDeleteReceivedMessages(cApikey, nMessageIds);
	}

	public Task<string[]> ApikeyDeleteReceivedMessagesAsync(string cApikey, long[] nMessageIds)
	{
		return base.Channel.ApikeyDeleteReceivedMessagesAsync(cApikey, nMessageIds);
	}

	public string ApikeyChangeReceiveNo(string cApikey, bool lReceiveAllmsg, string cFromNumber)
	{
		return base.Channel.ApikeyChangeReceiveNo(cApikey, lReceiveAllmsg, cFromNumber);
	}

	public Task<string> ApikeyChangeReceiveNoAsync(string cApikey, bool lReceiveAllmsg, string cFromNumber)
	{
		return base.Channel.ApikeyChangeReceiveNoAsync(cApikey, lReceiveAllmsg, cFromNumber);
	}

	public int[] ApikeyGetMessageDelivery1to1(string cApikey, long[] longid)
	{
		return base.Channel.ApikeyGetMessageDelivery1to1(cApikey, longid);
	}

	public Task<int[]> ApikeyGetMessageDelivery1to1Async(string cApikey, long[] longid)
	{
		return base.Channel.ApikeyGetMessageDelivery1to1Async(cApikey, longid);
	}

	public long[] ApikeyGetMessageDelivery1to1V2(string cApikey, long[] longid)
	{
		return base.Channel.ApikeyGetMessageDelivery1to1V2(cApikey, longid);
	}

	public Task<long[]> ApikeyGetMessageDelivery1to1V2Async(string cApikey, long[] longid)
	{
		return base.Channel.ApikeyGetMessageDelivery1to1V2Async(cApikey, longid);
	}

	public long[] ApikeygetMessageIds1to1(string cApikey, long[] nCustomerid)
	{
		return base.Channel.ApikeygetMessageIds1to1(cApikey, nCustomerid);
	}

	public Task<long[]> ApikeygetMessageIds1to1Async(string cApikey, long[] nCustomerid)
	{
		return base.Channel.ApikeygetMessageIds1to1Async(cApikey, nCustomerid);
	}

	public string GenerateApiKey(string cDomainName, string cUsername, string cPassword, int nlentgh)
	{
		return base.Channel.GenerateApiKey(cDomainName, cUsername, cPassword, nlentgh);
	}

	public Task<string> GenerateApiKeyAsync(string cDomainName, string cUsername, string cPassword, int nlentgh)
	{
		return base.Channel.GenerateApiKeyAsync(cDomainName, cUsername, cPassword, nlentgh);
	}

	public string Sendsmsphonebook(string cUserName, string cPassword, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid)
	{
		return base.Channel.Sendsmsphonebook(cUserName, cPassword, cBody, cGetid, nTypeSent, m_SchedulDate, cDomainname, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime, groupphonebook, isgroupid);
	}

	public Task<string> SendsmsphonebookAsync(string cUserName, string cPassword, string cBody, string cGetid, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime, int groupphonebook, bool isgroupid)
	{
		return base.Channel.SendsmsphonebookAsync(cUserName, cPassword, cBody, cGetid, nTypeSent, m_SchedulDate, cDomainname, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime, groupphonebook, isgroupid);
	}

	public string SENDVERIFICATIONCODE(string cDomainName, string cUsername, string cPassword, string cMobileno, int nVerificationid, int nCodeVerification)
	{
		return base.Channel.SENDVERIFICATIONCODE(cDomainName, cUsername, cPassword, cMobileno, nVerificationid, nCodeVerification);
	}

	public Task<string> SENDVERIFICATIONCODEAsync(string cDomainName, string cUsername, string cPassword, string cMobileno, int nVerificationid, int nCodeVerification)
	{
		return base.Channel.SENDVERIFICATIONCODEAsync(cDomainName, cUsername, cPassword, cMobileno, nVerificationid, nCodeVerification);
	}

	public string addinphonebook(string cDomainName, string cUsername, string cPassword, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid)
	{
		return base.Channel.addinphonebook(cDomainName, cUsername, cPassword, phonebookcode, cMobileno, Companyname, Fullname, sexid);
	}

	public Task<string> addinphonebookAsync(string cDomainName, string cUsername, string cPassword, string phonebookcode, string cMobileno, string Companyname, string Fullname, string sexid)
	{
		return base.Channel.addinphonebookAsync(cDomainName, cUsername, cPassword, phonebookcode, cMobileno, Companyname, Fullname, sexid);
	}

	public string[] GetReciveMessagein7array(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.GetReciveMessagein7array(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromnumber, cFromDate, cToDate);
	}

	public Task<string[]> GetReciveMessagein7arrayAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.GetReciveMessagein7arrayAsync(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromnumber, cFromDate, cToDate);
	}

	public string[] GetNumber(string cDomainname, string cUsername, string cpassword)
	{
		return base.Channel.GetNumber(cDomainname, cUsername, cpassword);
	}

	public Task<string[]> GetNumberAsync(string cDomainname, string cUsername, string cpassword)
	{
		return base.Channel.GetNumberAsync(cDomainname, cUsername, cpassword);
	}

	public string ForgetPassword(string cDomainname, string cUsername, string cMobileno)
	{
		return base.Channel.ForgetPassword(cDomainname, cUsername, cMobileno);
	}

	public Task<string> ForgetPasswordAsync(string cDomainname, string cUsername, string cMobileno)
	{
		return base.Channel.ForgetPasswordAsync(cDomainname, cUsername, cMobileno);
	}

	public string chargeuser(string cDomainname, string cUsername, string cpassword, string cUsercharge, long nCharge, string cDesCharge)
	{
		return base.Channel.chargeuser(cDomainname, cUsername, cpassword, cUsercharge, nCharge, cDesCharge);
	}

	public Task<string> chargeuserAsync(string cDomainname, string cUsername, string cpassword, string cUsercharge, long nCharge, string cDesCharge)
	{
		return base.Channel.chargeuserAsync(cDomainname, cUsername, cpassword, cUsercharge, nCharge, cDesCharge);
	}

	public string ActivateCentral(string cUSername, string cPassword, string cDomainname, string cSerial, bool lActivationType)
	{
		return base.Channel.ActivateCentral(cUSername, cPassword, cDomainname, cSerial, lActivationType);
	}

	public Task<string> ActivateCentralAsync(string cUSername, string cPassword, string cDomainname, string cSerial, bool lActivationType)
	{
		return base.Channel.ActivateCentralAsync(cUSername, cPassword, cDomainname, cSerial, lActivationType);
	}

	public string SantralData(string cUSername, string cPassword, string cDomainname, string cData)
	{
		return base.Channel.SantralData(cUSername, cPassword, cDomainname, cData);
	}

	public Task<string> SantralDataAsync(string cUSername, string cPassword, string cDomainname, string cData)
	{
		return base.Channel.SantralDataAsync(cUSername, cPassword, cDomainname, cData);
	}

	public string[] SantralConfig(string cUSername, string cPassword, string cDomainname, string cCommand, int typeodata, string[] cValues, string[] cDatas)
	{
		return base.Channel.SantralConfig(cUSername, cPassword, cDomainname, cCommand, typeodata, cValues, cDatas);
	}

	public Task<string[]> SantralConfigAsync(string cUSername, string cPassword, string cDomainname, string cCommand, int typeodata, string[] cValues, string[] cDatas)
	{
		return base.Channel.SantralConfigAsync(cUSername, cPassword, cDomainname, cCommand, typeodata, cValues, cDatas);
	}

	public string SendSmsShort(string cUserName, string cPassword, string cBody, string cSmsnumber, string cDomainname)
	{
		return base.Channel.SendSmsShort(cUserName, cPassword, cBody, cSmsnumber, cDomainname);
	}

	public Task<string> SendSmsShortAsync(string cUserName, string cPassword, string cBody, string cSmsnumber, string cDomainname)
	{
		return base.Channel.SendSmsShortAsync(cUserName, cPassword, cBody, cSmsnumber, cDomainname);
	}

	public string SendSms(string cUserName, string cPassword, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime)
	{
		return base.Channel.SendSms(cUserName, cPassword, cBody, cSmsnumber, cGetid, nCMessage, nTypeSent, m_SchedulDate, cDomainname, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime);
	}

	public Task<string> SendSmsAsync(string cUserName, string cPassword, string cBody, string cSmsnumber, string cGetid, int nCMessage, int nTypeSent, string m_SchedulDate, string cDomainname, string cFromNumber, int nSpeedsms, int nPeriodmin, string cstarttime, string cEndTime)
	{
		return base.Channel.SendSmsAsync(cUserName, cPassword, cBody, cSmsnumber, cGetid, nCMessage, nTypeSent, m_SchedulDate, cDomainname, cFromNumber, nSpeedsms, nPeriodmin, cstarttime, cEndTime);
	}

	public long[] SendSms1To1(string cDomainname, string cUserName, string cPassword, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin)
	{
		return base.Channel.SendSms1To1(cDomainname, cUserName, cPassword, aBody, aMobileno, aGetid, aCMessage, aFromNumber, atypeUnicodemessage, am_SchedulDate, nTypeSent, nSpeedsms, nPeriodmin);
	}

	public Task<long[]> SendSms1To1Async(string cDomainname, string cUserName, string cPassword, string[] aBody, string[] aMobileno, long[] aGetid, int[] aCMessage, string[] aFromNumber, int[] atypeUnicodemessage, string[] am_SchedulDate, int nTypeSent, int nSpeedsms, int nPeriodmin)
	{
		return base.Channel.SendSms1To1Async(cDomainname, cUserName, cPassword, aBody, aMobileno, aGetid, aCMessage, aFromNumber, atypeUnicodemessage, am_SchedulDate, nTypeSent, nSpeedsms, nPeriodmin);
	}

	public string[] GetDelivery(string cUserName, string cPassword, string[] aSid)
	{
		return base.Channel.GetDelivery(cUserName, cPassword, aSid);
	}

	public Task<string[]> GetDeliveryAsync(string cUserName, string cPassword, string[] aSid)
	{
		return base.Channel.GetDeliveryAsync(cUserName, cPassword, aSid);
	}

	public string ChangePassword(string cUserName, string cPassword, string cNewPassword, string cDomainName)
	{
		return base.Channel.ChangePassword(cUserName, cPassword, cNewPassword, cDomainName);
	}

	public Task<string> ChangePasswordAsync(string cUserName, string cPassword, string cNewPassword, string cDomainName)
	{
		return base.Channel.ChangePasswordAsync(cUserName, cPassword, cNewPassword, cDomainName);
	}

	public string GetuserInfoold(string cUserName, string cPassword)
	{
		return base.Channel.GetuserInfoold(cUserName, cPassword);
	}

	public Task<string> GetuserInfooldAsync(string cUserName, string cPassword)
	{
		return base.Channel.GetuserInfooldAsync(cUserName, cPassword);
	}

	public string[] GetuserInfo(string cUserName, string cPassword, string cDomainName)
	{
		return base.Channel.GetuserInfo(cUserName, cPassword, cDomainName);
	}

	public Task<string[]> GetuserInfoAsync(string cUserName, string cPassword, string cDomainName)
	{
		return base.Channel.GetuserInfoAsync(cUserName, cPassword, cDomainName);
	}

	public string[] GetDeliveryWithGetid(string cUserName, string cPassword, string cGetid, bool lReturnSid, string cDomainname)
	{
		return base.Channel.GetDeliveryWithGetid(cUserName, cPassword, cGetid, lReturnSid, cDomainname);
	}

	public Task<string[]> GetDeliveryWithGetidAsync(string cUserName, string cPassword, string cGetid, bool lReturnSid, string cDomainname)
	{
		return base.Channel.GetDeliveryWithGetidAsync(cUserName, cPassword, cGetid, lReturnSid, cDomainname);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReceivesmsLowLevelResponse ServiceSoap.ReceivesmsLowLevel(ReceivesmsLowLevelRequest request)
	{
		return base.Channel.ReceivesmsLowLevel(request);
	}

	public void ReceivesmsLowLevel(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, ref string[] aBody, ref string[] aMobileno, ref long[] aMessageid, ref string[] aReceivedate, ref string[] afromnumber)
	{
		ReceivesmsLowLevelRequest receivesmsLowLevelRequest = new ReceivesmsLowLevelRequest();
		receivesmsLowLevelRequest.cUserName = cUserName;
		receivesmsLowLevelRequest.cPassword = cPassword;
		receivesmsLowLevelRequest.lReceiveAllmsg = lReceiveAllmsg;
		receivesmsLowLevelRequest.cDomainName = cDomainName;
		receivesmsLowLevelRequest.cFromnumber = cFromnumber;
		receivesmsLowLevelRequest.aBody = aBody;
		receivesmsLowLevelRequest.aMobileno = aMobileno;
		receivesmsLowLevelRequest.aMessageid = aMessageid;
		receivesmsLowLevelRequest.aReceivedate = aReceivedate;
		receivesmsLowLevelRequest.afromnumber = afromnumber;
		ReceivesmsLowLevelResponse receivesmsLowLevelResponse = ((ServiceSoap)this).ReceivesmsLowLevel(receivesmsLowLevelRequest);
		aBody = receivesmsLowLevelResponse.aBody;
		aMobileno = receivesmsLowLevelResponse.aMobileno;
		aMessageid = receivesmsLowLevelResponse.aMessageid;
		aReceivedate = receivesmsLowLevelResponse.aReceivedate;
		afromnumber = receivesmsLowLevelResponse.afromnumber;
	}

	public Task<ReceivesmsLowLevelResponse> ReceivesmsLowLevelAsync(ReceivesmsLowLevelRequest request)
	{
		return base.Channel.ReceivesmsLowLevelAsync(request);
	}

	public DataTable ReceiveSms(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ReceiveSms(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromnumber, cFromDate, cToDate);
	}

	public Task<DataTable> ReceiveSmsAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string cFromDate, string cToDate)
	{
		return base.Channel.ReceiveSmsAsync(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromnumber, cFromDate, cToDate);
	}

	public string[] DeleteReceivedMessages(string cUserName, string cPassword, string cDomainName, long[] nMessageIds)
	{
		return base.Channel.DeleteReceivedMessages(cUserName, cPassword, cDomainName, nMessageIds);
	}

	public Task<string[]> DeleteReceivedMessagesAsync(string cUserName, string cPassword, string cDomainName, long[] nMessageIds)
	{
		return base.Channel.DeleteReceivedMessagesAsync(cUserName, cPassword, cDomainName, nMessageIds);
	}

	public string ChangeReceiveNo(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromNumber)
	{
		return base.Channel.ChangeReceiveNo(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromNumber);
	}

	public Task<string> ChangeReceiveNoAsync(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromNumber)
	{
		return base.Channel.ChangeReceiveNoAsync(cUserName, cPassword, lReceiveAllmsg, cDomainName, cFromNumber);
	}

	public int[] GetMessageDelivery1to1(string cUserName, string cPassword, string cDomainname, long[] longid)
	{
		return base.Channel.GetMessageDelivery1to1(cUserName, cPassword, cDomainname, longid);
	}

	public Task<int[]> GetMessageDelivery1to1Async(string cUserName, string cPassword, string cDomainname, long[] longid)
	{
		return base.Channel.GetMessageDelivery1to1Async(cUserName, cPassword, cDomainname, longid);
	}

	public long[] GetMessageDelivery1to1V2(string cUserName, string cPassword, string cDomainname, long[] longid)
	{
		return base.Channel.GetMessageDelivery1to1V2(cUserName, cPassword, cDomainname, longid);
	}

	public Task<long[]> GetMessageDelivery1to1V2Async(string cUserName, string cPassword, string cDomainname, long[] longid)
	{
		return base.Channel.GetMessageDelivery1to1V2Async(cUserName, cPassword, cDomainname, longid);
	}

	public long[] getMessageIds1to1(string cUserName, string cPassword, string cDomainname, long[] nCustomerid)
	{
		return base.Channel.getMessageIds1to1(cUserName, cPassword, cDomainname, nCustomerid);
	}

	public Task<long[]> getMessageIds1to1Async(string cUserName, string cPassword, string cDomainname, long[] nCustomerid)
	{
		return base.Channel.getMessageIds1to1Async(cUserName, cPassword, cDomainname, nCustomerid);
	}

	public string ShowError(string cErrorCode, string cLanShow)
	{
		return base.Channel.ShowError(cErrorCode, cLanShow);
	}

	public Task<string> ShowErrorAsync(string cErrorCode, string cLanShow)
	{
		return base.Channel.ShowErrorAsync(cErrorCode, cLanShow);
	}

	public int GetMessageLength(string cBody)
	{
		return base.Channel.GetMessageLength(cBody);
	}

	public Task<int> GetMessageLengthAsync(string cBody)
	{
		return base.Channel.GetMessageLengthAsync(cBody);
	}

	public int GetUnicodeMessage(string cBody)
	{
		return base.Channel.GetUnicodeMessage(cBody);
	}

	public Task<int> GetUnicodeMessageAsync(string cBody)
	{
		return base.Channel.GetUnicodeMessageAsync(cBody);
	}

	public long[] mehrafrazDelivery(string cCommand, string cFormatSms, long[] asid, int[] nsmsstatus, string[] adate)
	{
		return base.Channel.mehrafrazDelivery(cCommand, cFormatSms, asid, nsmsstatus, adate);
	}

	public Task<long[]> mehrafrazDeliveryAsync(string cCommand, string cFormatSms, long[] asid, int[] nsmsstatus, string[] adate)
	{
		return base.Channel.mehrafrazDeliveryAsync(cCommand, cFormatSms, asid, nsmsstatus, adate);
	}

	public string CheckDeliverFromServer(int nAccountUsesid, int ntypeSms)
	{
		return base.Channel.CheckDeliverFromServer(nAccountUsesid, ntypeSms);
	}

	public Task<string> CheckDeliverFromServerAsync(int nAccountUsesid, int ntypeSms)
	{
		return base.Channel.CheckDeliverFromServerAsync(nAccountUsesid, ntypeSms);
	}
}
