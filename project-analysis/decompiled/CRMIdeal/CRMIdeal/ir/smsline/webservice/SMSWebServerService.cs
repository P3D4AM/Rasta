using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using CRMIdeal.Properties;

namespace CRMIdeal.ir.smsline.webservice;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "SMS WebServer ServiceBinding", Namespace = "http://176.62.145.9/index.php/")]
public class SMSWebServerService : SoapHttpClientProtocol
{
	private SendOrPostCallback COUNT_GETSMSOperationCompleted;

	private SendOrPostCallback COUNT_SENDSMSOperationCompleted;

	private SendOrPostCallback CREDIT_LINESMSOperationCompleted;

	private SendOrPostCallback SendSMSOperationCompleted;

	private SendOrPostCallback StatusSMSOperationCompleted;

	private SendOrPostCallback Send_GROUP_SMSOperationCompleted;

	private SendOrPostCallback Send_peertopeerOperationCompleted;

	private SendOrPostCallback SMS_GETOperationCompleted;

	private SendOrPostCallback SendSMS_byPORTOperationCompleted;

	private SendOrPostCallback MessageInfoOperationCompleted;

	private bool useDefaultCredentialsSetExplicitly;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (IsLocalFileSystemWebService(((WebClientProtocol)this).Url) && !useDefaultCredentialsSetExplicitly && !IsLocalFileSystemWebService(value))
			{
				((WebClientProtocol)this).UseDefaultCredentials = false;
			}
			((WebClientProtocol)this).Url = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return ((WebClientProtocol)this).UseDefaultCredentials;
		}
		set
		{
			((WebClientProtocol)this).UseDefaultCredentials = value;
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	public event COUNT_GETSMSCompletedEventHandler COUNT_GETSMSCompleted;

	public event COUNT_SENDSMSCompletedEventHandler COUNT_SENDSMSCompleted;

	public event CREDIT_LINESMSCompletedEventHandler CREDIT_LINESMSCompleted;

	public event SendSMSCompletedEventHandler SendSMSCompleted;

	public event StatusSMSCompletedEventHandler StatusSMSCompleted;

	public event Send_GROUP_SMSCompletedEventHandler Send_GROUP_SMSCompleted;

	public event Send_peertopeerCompletedEventHandler Send_peertopeerCompleted;

	public event SMS_GETCompletedEventHandler SMS_GETCompleted;

	public event SendSMS_byPORTCompletedEventHandler SendSMS_byPORTCompleted;

	public event MessageInfoCompletedEventHandler MessageInfoCompleted;

	public SMSWebServerService()
	{
		Url = Settings.Default.CRMIdeal_ir_smsline_webservice_SMS_WebServer_Service;
		if (IsLocalFileSystemWebService(Url))
		{
			UseDefaultCredentials = true;
			useDefaultCredentialsSetExplicitly = false;
		}
		else
		{
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string COUNT_GETSMS(string username, string password, string method)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("COUNT_GETSMS", new object[3] { username, password, method })[0];
	}

	public void COUNT_GETSMSAsync(string username, string password, string method)
	{
		COUNT_GETSMSAsync(username, password, method, null);
	}

	public void COUNT_GETSMSAsync(string username, string password, string method, object userState)
	{
		if (COUNT_GETSMSOperationCompleted == null)
		{
			COUNT_GETSMSOperationCompleted = OnCOUNT_GETSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("COUNT_GETSMS", new object[3] { username, password, method }, COUNT_GETSMSOperationCompleted, userState);
	}

	private void OnCOUNT_GETSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.COUNT_GETSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.COUNT_GETSMSCompleted(this, new COUNT_GETSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string COUNT_SENDSMS(string username, string password)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("COUNT_SENDSMS", new object[2] { username, password })[0];
	}

	public void COUNT_SENDSMSAsync(string username, string password)
	{
		COUNT_SENDSMSAsync(username, password, null);
	}

	public void COUNT_SENDSMSAsync(string username, string password, object userState)
	{
		if (COUNT_SENDSMSOperationCompleted == null)
		{
			COUNT_SENDSMSOperationCompleted = OnCOUNT_SENDSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("COUNT_SENDSMS", new object[2] { username, password }, COUNT_SENDSMSOperationCompleted, userState);
	}

	private void OnCOUNT_SENDSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.COUNT_SENDSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.COUNT_SENDSMSCompleted(this, new COUNT_SENDSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string CREDIT_LINESMS(string username, string password, string sender)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("CREDIT_LINESMS", new object[3] { username, password, sender })[0];
	}

	public void CREDIT_LINESMSAsync(string username, string password, string sender)
	{
		CREDIT_LINESMSAsync(username, password, sender, null);
	}

	public void CREDIT_LINESMSAsync(string username, string password, string sender, object userState)
	{
		if (CREDIT_LINESMSOperationCompleted == null)
		{
			CREDIT_LINESMSOperationCompleted = OnCREDIT_LINESMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CREDIT_LINESMS", new object[3] { username, password, sender }, CREDIT_LINESMSOperationCompleted, userState);
	}

	private void OnCREDIT_LINESMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.CREDIT_LINESMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.CREDIT_LINESMSCompleted(this, new CREDIT_LINESMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string SendSMS(string username, string password, string reciver, string text, string sender)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("SendSMS", new object[5] { username, password, reciver, text, sender })[0];
	}

	public void SendSMSAsync(string username, string password, string reciver, string text, string sender)
	{
		SendSMSAsync(username, password, reciver, text, sender, null);
	}

	public void SendSMSAsync(string username, string password, string reciver, string text, string sender, object userState)
	{
		if (SendSMSOperationCompleted == null)
		{
			SendSMSOperationCompleted = OnSendSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendSMS", new object[5] { username, password, reciver, text, sender }, SendSMSOperationCompleted, userState);
	}

	private void OnSendSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendSMSCompleted(this, new SendSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string StatusSMS(string username, string password, string follow)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("StatusSMS", new object[3] { username, password, follow })[0];
	}

	public void StatusSMSAsync(string username, string password, string follow)
	{
		StatusSMSAsync(username, password, follow, null);
	}

	public void StatusSMSAsync(string username, string password, string follow, object userState)
	{
		if (StatusSMSOperationCompleted == null)
		{
			StatusSMSOperationCompleted = OnStatusSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("StatusSMS", new object[3] { username, password, follow }, StatusSMSOperationCompleted, userState);
	}

	private void OnStatusSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.StatusSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.StatusSMSCompleted(this, new StatusSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string Send_GROUP_SMS(string username, string password, string reciver, string text, string sender, string mes_msclass)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("Send_GROUP_SMS", new object[6] { username, password, reciver, text, sender, mes_msclass })[0];
	}

	public void Send_GROUP_SMSAsync(string username, string password, string reciver, string text, string sender, string mes_msclass)
	{
		Send_GROUP_SMSAsync(username, password, reciver, text, sender, mes_msclass, null);
	}

	public void Send_GROUP_SMSAsync(string username, string password, string reciver, string text, string sender, string mes_msclass, object userState)
	{
		if (Send_GROUP_SMSOperationCompleted == null)
		{
			Send_GROUP_SMSOperationCompleted = OnSend_GROUP_SMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Send_GROUP_SMS", new object[6] { username, password, reciver, text, sender, mes_msclass }, Send_GROUP_SMSOperationCompleted, userState);
	}

	private void OnSend_GROUP_SMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.Send_GROUP_SMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.Send_GROUP_SMSCompleted(this, new Send_GROUP_SMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string Send_peertopeer(string username, string password, string reciver_text, string sender)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("Send_peertopeer", new object[4] { username, password, reciver_text, sender })[0];
	}

	public void Send_peertopeerAsync(string username, string password, string reciver_text, string sender)
	{
		Send_peertopeerAsync(username, password, reciver_text, sender, null);
	}

	public void Send_peertopeerAsync(string username, string password, string reciver_text, string sender, object userState)
	{
		if (Send_peertopeerOperationCompleted == null)
		{
			Send_peertopeerOperationCompleted = OnSend_peertopeerOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Send_peertopeer", new object[4] { username, password, reciver_text, sender }, Send_peertopeerOperationCompleted, userState);
	}

	private void OnSend_peertopeerOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.Send_peertopeerCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.Send_peertopeerCompleted(this, new Send_peertopeerCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string SMS_GET(string username, string password, string method)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("SMS_GET", new object[3] { username, password, method })[0];
	}

	public void SMS_GETAsync(string username, string password, string method)
	{
		SMS_GETAsync(username, password, method, null);
	}

	public void SMS_GETAsync(string username, string password, string method, object userState)
	{
		if (SMS_GETOperationCompleted == null)
		{
			SMS_GETOperationCompleted = OnSMS_GETOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SMS_GET", new object[3] { username, password, method }, SMS_GETOperationCompleted, userState);
	}

	private void OnSMS_GETOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SMS_GETCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SMS_GETCompleted(this, new SMS_GETCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string SendSMS_byPORT(string username, string password, string reciver, string text, string sender, string udh)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("SendSMS_byPORT", new object[6] { username, password, reciver, text, sender, udh })[0];
	}

	public void SendSMS_byPORTAsync(string username, string password, string reciver, string text, string sender, string udh)
	{
		SendSMS_byPORTAsync(username, password, reciver, text, sender, udh, null);
	}

	public void SendSMS_byPORTAsync(string username, string password, string reciver, string text, string sender, string udh, object userState)
	{
		if (SendSMS_byPORTOperationCompleted == null)
		{
			SendSMS_byPORTOperationCompleted = OnSendSMS_byPORTOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendSMS_byPORT", new object[6] { username, password, reciver, text, sender, udh }, SendSMS_byPORTOperationCompleted, userState);
	}

	private void OnSendSMS_byPORTOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendSMS_byPORTCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendSMS_byPORTCompleted(this, new SendSMS_byPORTCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("http://176.62.145.9/index.php/", RequestNamespace = "http://176.62.145.9/index.php/", ResponseNamespace = "http://176.62.145.9/index.php/")]
	[return: SoapElement("return")]
	public string MessageInfo(string message)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("MessageInfo", new object[1] { message })[0];
	}

	public void MessageInfoAsync(string message)
	{
		MessageInfoAsync(message, null);
	}

	public void MessageInfoAsync(string message, object userState)
	{
		if (MessageInfoOperationCompleted == null)
		{
			MessageInfoOperationCompleted = OnMessageInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("MessageInfo", new object[1] { message }, MessageInfoOperationCompleted, userState);
	}

	private void OnMessageInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.MessageInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.MessageInfoCompleted(this, new MessageInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	public void CancelAsync(object userState)
	{
		((HttpWebClientProtocol)this).CancelAsync(userState);
	}

	private bool IsLocalFileSystemWebService(string url)
	{
		if (url == null || url == string.Empty)
		{
			return false;
		}
		Uri uri = new Uri(url);
		if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		return false;
	}
}
