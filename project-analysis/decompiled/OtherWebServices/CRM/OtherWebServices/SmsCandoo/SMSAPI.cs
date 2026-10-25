using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using CRM.OtherWebServices.Properties;

namespace CRM.OtherWebServices.SmsCandoo;

[GeneratedCode("System.Web.Services", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "SMS APIBinding", Namespace = "urn:SMSAPIwsdl")]
[SoapInclude(typeof(DeliveryResult))]
[SoapInclude(typeof(ReceiveResult))]
[SoapInclude(typeof(SendResult))]
[SoapInclude(typeof(MultipleSendResult))]
public class SMSAPI : SoapHttpClientProtocol
{
	private SendOrPostCallback SendMultipleOperationCompleted;

	private SendOrPostCallback SendOperationCompleted;

	private SendOrPostCallback ViewReceiveOperationCompleted;

	private SendOrPostCallback DeliveryReportOperationCompleted;

	private SendOrPostCallback getStatusesOperationCompleted;

	private SendOrPostCallback AcknowledgeOperationCompleted;

	private SendOrPostCallback getStatuses_OriginalIDOperationCompleted;

	private SendOrPostCallback BalanceOperationCompleted;

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

	public event SendMultipleCompletedEventHandler SendMultipleCompleted;

	public event SendCompletedEventHandler SendCompleted;

	public event ViewReceiveCompletedEventHandler ViewReceiveCompleted;

	public event DeliveryReportCompletedEventHandler DeliveryReportCompleted;

	public event getStatusesCompletedEventHandler getStatusesCompleted;

	public event AcknowledgeCompletedEventHandler AcknowledgeCompleted;

	public event getStatuses_OriginalIDCompletedEventHandler getStatuses_OriginalIDCompleted;

	public event BalanceCompletedEventHandler BalanceCompleted;

	public SMSAPI()
	{
		Url = Settings.Default.OtherWebServices_SmsCandoo_SMS_API;
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

	[SoapRpcMethod("urn:SMSAPIwsdl#Send", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public MultipleSendResult[] SendMultiple(string username, string password, string[] srcNumbers, string[] bodys, string[] destNos, string[] flashs, long[] checkingMessageIds)
	{
		return (MultipleSendResult[])((SoapHttpClientProtocol)this).Invoke("SendMultiple", new object[7] { username, password, srcNumbers, bodys, destNos, flashs, checkingMessageIds })[0];
	}

	public void SendMultipleAsync(string username, string password, string[] srcNumbers, string[] bodys, string[] destNos, string[] flashs, long[] checkingMessageIds)
	{
		SendMultipleAsync(username, password, srcNumbers, bodys, destNos, flashs, checkingMessageIds, null);
	}

	public void SendMultipleAsync(string username, string password, string[] srcNumbers, string[] bodys, string[] destNos, string[] flashs, long[] checkingMessageIds, object userState)
	{
		if (SendMultipleOperationCompleted == null)
		{
			SendMultipleOperationCompleted = OnSendMultipleOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendMultiple", new object[7] { username, password, srcNumbers, bodys, destNos, flashs, checkingMessageIds }, SendMultipleOperationCompleted, userState);
	}

	private void OnSendMultipleOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendMultipleCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendMultipleCompleted(this, new SendMultipleCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#Send", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public SendResult[] Send(string username, string password, string srcNumber, string body, string[] destNo, string flash)
	{
		return (SendResult[])((SoapHttpClientProtocol)this).Invoke("Send", new object[6] { username, password, srcNumber, body, destNo, flash })[0];
	}

	public void SendAsync(string username, string password, string srcNumber, string body, string[] destNo, string flash)
	{
		SendAsync(username, password, srcNumber, body, destNo, flash, null);
	}

	public void SendAsync(string username, string password, string srcNumber, string body, string[] destNo, string flash, object userState)
	{
		if (SendOperationCompleted == null)
		{
			SendOperationCompleted = OnSendOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Send", new object[6] { username, password, srcNumber, body, destNo, flash }, SendOperationCompleted, userState);
	}

	private void OnSendOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendCompleted(this, new SendCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#ViewReceive", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public ReceiveResult[] ViewReceive(string username, string password, string number, string id)
	{
		return (ReceiveResult[])((SoapHttpClientProtocol)this).Invoke("ViewReceive", new object[4] { username, password, number, id })[0];
	}

	public void ViewReceiveAsync(string username, string password, string number, string id)
	{
		ViewReceiveAsync(username, password, number, id, null);
	}

	public void ViewReceiveAsync(string username, string password, string number, string id, object userState)
	{
		if (ViewReceiveOperationCompleted == null)
		{
			ViewReceiveOperationCompleted = OnViewReceiveOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("ViewReceive", new object[4] { username, password, number, id }, ViewReceiveOperationCompleted, userState);
	}

	private void OnViewReceiveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.ViewReceiveCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.ViewReceiveCompleted(this, new ViewReceiveCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#DeliveryReport", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public DeliveryResult[] DeliveryReport(string username, string password, string srcNumber, string id, string fromid)
	{
		return (DeliveryResult[])((SoapHttpClientProtocol)this).Invoke("DeliveryReport", new object[5] { username, password, srcNumber, id, fromid })[0];
	}

	public void DeliveryReportAsync(string username, string password, string srcNumber, string id, string fromid)
	{
		DeliveryReportAsync(username, password, srcNumber, id, fromid, null);
	}

	public void DeliveryReportAsync(string username, string password, string srcNumber, string id, string fromid, object userState)
	{
		if (DeliveryReportOperationCompleted == null)
		{
			DeliveryReportOperationCompleted = OnDeliveryReportOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("DeliveryReport", new object[5] { username, password, srcNumber, id, fromid }, DeliveryReportOperationCompleted, userState);
	}

	private void OnDeliveryReportOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.DeliveryReportCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.DeliveryReportCompleted(this, new DeliveryReportCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#getStatuses", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public string[] getStatuses(string username, string password, long[] checkingIds)
	{
		return (string[])((SoapHttpClientProtocol)this).Invoke("getStatuses", new object[3] { username, password, checkingIds })[0];
	}

	public void getStatusesAsync(string username, string password, long[] checkingIds)
	{
		getStatusesAsync(username, password, checkingIds, null);
	}

	public void getStatusesAsync(string username, string password, long[] checkingIds, object userState)
	{
		if (getStatusesOperationCompleted == null)
		{
			getStatusesOperationCompleted = OngetStatusesOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getStatuses", new object[3] { username, password, checkingIds }, getStatusesOperationCompleted, userState);
	}

	private void OngetStatusesOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getStatusesCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getStatusesCompleted(this, new getStatusesCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#Acknowledge", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public string[] Acknowledge(string username, string password, long[] checkingIds)
	{
		return (string[])((SoapHttpClientProtocol)this).Invoke("Acknowledge", new object[3] { username, password, checkingIds })[0];
	}

	public void AcknowledgeAsync(string username, string password, long[] checkingIds)
	{
		AcknowledgeAsync(username, password, checkingIds, null);
	}

	public void AcknowledgeAsync(string username, string password, long[] checkingIds, object userState)
	{
		if (AcknowledgeOperationCompleted == null)
		{
			AcknowledgeOperationCompleted = OnAcknowledgeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Acknowledge", new object[3] { username, password, checkingIds }, AcknowledgeOperationCompleted, userState);
	}

	private void OnAcknowledgeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.AcknowledgeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.AcknowledgeCompleted(this, new AcknowledgeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#getStatuses", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public string[] getStatuses_OriginalID(string username, string password, long[] checkingIds)
	{
		return (string[])((SoapHttpClientProtocol)this).Invoke("getStatuses_OriginalID", new object[3] { username, password, checkingIds })[0];
	}

	public void getStatuses_OriginalIDAsync(string username, string password, long[] checkingIds)
	{
		getStatuses_OriginalIDAsync(username, password, checkingIds, null);
	}

	public void getStatuses_OriginalIDAsync(string username, string password, long[] checkingIds, object userState)
	{
		if (getStatuses_OriginalIDOperationCompleted == null)
		{
			getStatuses_OriginalIDOperationCompleted = OngetStatuses_OriginalIDOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getStatuses_OriginalID", new object[3] { username, password, checkingIds }, getStatuses_OriginalIDOperationCompleted, userState);
	}

	private void OngetStatuses_OriginalIDOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getStatuses_OriginalIDCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getStatuses_OriginalIDCompleted(this, new getStatuses_OriginalIDCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("urn:SMSAPIwsdl#return account balance", RequestNamespace = "urn:SMSAPIwsdl", ResponseNamespace = "urn:SMSAPIwsdl")]
	[return: SoapElement("return")]
	public string Balance(string username, string password)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("Balance", new object[2] { username, password })[0];
	}

	public void BalanceAsync(string username, string password)
	{
		BalanceAsync(username, password, null);
	}

	public void BalanceAsync(string username, string password, object userState)
	{
		if (BalanceOperationCompleted == null)
		{
			BalanceOperationCompleted = OnBalanceOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Balance", new object[2] { username, password }, BalanceOperationCompleted, userState);
	}

	private void OnBalanceOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.BalanceCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.BalanceCompleted(this, new BalanceCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
