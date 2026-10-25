using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Mobile.SmsMehrAfraz;

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
}
