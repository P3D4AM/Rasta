using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using Mobile.Properties;

namespace Mobile.SmsAfzar;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "smsWebServiceSoap", Namespace = "http://tempuri.org/")]
public class smsWebService : SoapHttpClientProtocol
{
	private SendOrPostCallback sendSMSEnqueeOperationCompleted;

	private SendOrPostCallback sendSingleSMSOperationCompleted;

	private SendOrPostCallback getMessageStatusOperationCompleted;

	private SendOrPostCallback getMessageStatusesOperationCompleted;

	private SendOrPostCallback getReciveSMSWithNumberOnDateOperationCompleted;

	private SendOrPostCallback getAllReciveSMSWithNumberOperationCompleted;

	private SendOrPostCallback getAllReciveSMSOperationCompleted;

	private SendOrPostCallback getAllReciveSMSOnDateOperationCompleted;

	private SendOrPostCallback getReciveSMSOnReciveIDOperationCompleted;

	private SendOrPostCallback getLastReciveSMSOperationCompleted;

	private SendOrPostCallback getLastReciveSMSWithNumberOperationCompleted;

	private SendOrPostCallback setSendSMSOnDateTimeOperationCompleted;

	private SendOrPostCallback changeActiveOfSendSMSOnDateTimeOperationCompleted;

	private SendOrPostCallback getResultOfSendSMSOnDateTimeOperationCompleted;

	private SendOrPostCallback removeSendSMSOnDateTimeOperationCompleted;

	private SendOrPostCallback getCreditOperationCompleted;

	private SendOrPostCallback GetTotalUnreadSMSOperationCompleted;

	private SendOrPostCallback GetTotalUnreadSMSWithNumberOperationCompleted;

	private SendOrPostCallback GetUnreadSMSOperationCompleted;

	private SendOrPostCallback GetUnreadSMSWithNumberOperationCompleted;

	private SendOrPostCallback getAllReadReciveSMSOnDateOperationCompleted;

	private SendOrPostCallback GetUnreadSMSWithNoChangeOperationCompleted;

	private SendOrPostCallback getSendSMSOnDateOperationCompleted;

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

	public event sendSMSEnqueeCompletedEventHandler sendSMSEnqueeCompleted;

	public event sendSingleSMSCompletedEventHandler sendSingleSMSCompleted;

	public event getMessageStatusCompletedEventHandler getMessageStatusCompleted;

	public event getMessageStatusesCompletedEventHandler getMessageStatusesCompleted;

	public event getReciveSMSWithNumberOnDateCompletedEventHandler getReciveSMSWithNumberOnDateCompleted;

	public event getAllReciveSMSWithNumberCompletedEventHandler getAllReciveSMSWithNumberCompleted;

	public event getAllReciveSMSCompletedEventHandler getAllReciveSMSCompleted;

	public event getAllReciveSMSOnDateCompletedEventHandler getAllReciveSMSOnDateCompleted;

	public event getReciveSMSOnReciveIDCompletedEventHandler getReciveSMSOnReciveIDCompleted;

	public event getLastReciveSMSCompletedEventHandler getLastReciveSMSCompleted;

	public event getLastReciveSMSWithNumberCompletedEventHandler getLastReciveSMSWithNumberCompleted;

	public event setSendSMSOnDateTimeCompletedEventHandler setSendSMSOnDateTimeCompleted;

	public event changeActiveOfSendSMSOnDateTimeCompletedEventHandler changeActiveOfSendSMSOnDateTimeCompleted;

	public event getResultOfSendSMSOnDateTimeCompletedEventHandler getResultOfSendSMSOnDateTimeCompleted;

	public event removeSendSMSOnDateTimeCompletedEventHandler removeSendSMSOnDateTimeCompleted;

	public event getCreditCompletedEventHandler getCreditCompleted;

	public event GetTotalUnreadSMSCompletedEventHandler GetTotalUnreadSMSCompleted;

	public event GetTotalUnreadSMSWithNumberCompletedEventHandler GetTotalUnreadSMSWithNumberCompleted;

	public event GetUnreadSMSCompletedEventHandler GetUnreadSMSCompleted;

	public event GetUnreadSMSWithNumberCompletedEventHandler GetUnreadSMSWithNumberCompleted;

	public event getAllReadReciveSMSOnDateCompletedEventHandler getAllReadReciveSMSOnDateCompleted;

	public event GetUnreadSMSWithNoChangeCompletedEventHandler GetUnreadSMSWithNoChangeCompleted;

	public event getSendSMSOnDateCompletedEventHandler getSendSMSOnDateCompleted;

	public smsWebService()
	{
		Url = Settings.Default.Mobile_SmsAfzar_smsWebService;
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

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] sendSMSEnquee(string username, string password, string domain, string[] messageBodies, string[] recipientNumbers, string[] senderNumbers, int[] encodings, string[] udhs, int[] messageClasses, int[] priorities)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("sendSMSEnquee", new object[10] { username, password, domain, messageBodies, recipientNumbers, senderNumbers, encodings, udhs, messageClasses, priorities })[0];
	}

	public void sendSMSEnqueeAsync(string username, string password, string domain, string[] messageBodies, string[] recipientNumbers, string[] senderNumbers, int[] encodings, string[] udhs, int[] messageClasses, int[] priorities)
	{
		sendSMSEnqueeAsync(username, password, domain, messageBodies, recipientNumbers, senderNumbers, encodings, udhs, messageClasses, priorities, null);
	}

	public void sendSMSEnqueeAsync(string username, string password, string domain, string[] messageBodies, string[] recipientNumbers, string[] senderNumbers, int[] encodings, string[] udhs, int[] messageClasses, int[] priorities, object userState)
	{
		if (sendSMSEnqueeOperationCompleted == null)
		{
			sendSMSEnqueeOperationCompleted = OnsendSMSEnqueeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sendSMSEnquee", new object[10] { username, password, domain, messageBodies, recipientNumbers, senderNumbers, encodings, udhs, messageClasses, priorities }, sendSMSEnqueeOperationCompleted, userState);
	}

	private void OnsendSMSEnqueeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sendSMSEnqueeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sendSMSEnqueeCompleted(this, new sendSMSEnqueeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] sendSingleSMS(string username, string password, string domain, string messageBody, string recipientNumber, string senderNumber)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("sendSingleSMS", new object[6] { username, password, domain, messageBody, recipientNumber, senderNumber })[0];
	}

	public void sendSingleSMSAsync(string username, string password, string domain, string messageBody, string recipientNumber, string senderNumber)
	{
		sendSingleSMSAsync(username, password, domain, messageBody, recipientNumber, senderNumber, null);
	}

	public void sendSingleSMSAsync(string username, string password, string domain, string messageBody, string recipientNumber, string senderNumber, object userState)
	{
		if (sendSingleSMSOperationCompleted == null)
		{
			sendSingleSMSOperationCompleted = OnsendSingleSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sendSingleSMS", new object[6] { username, password, domain, messageBody, recipientNumber, senderNumber }, sendSingleSMSOperationCompleted, userState);
	}

	private void OnsendSingleSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sendSingleSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sendSingleSMSCompleted(this, new sendSingleSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int getMessageStatus(string username, string password, string domain, long messageId)
	{
		return (int)((SoapHttpClientProtocol)this).Invoke("getMessageStatus", new object[4] { username, password, domain, messageId })[0];
	}

	public void getMessageStatusAsync(string username, string password, string domain, long messageId)
	{
		getMessageStatusAsync(username, password, domain, messageId, null);
	}

	public void getMessageStatusAsync(string username, string password, string domain, long messageId, object userState)
	{
		if (getMessageStatusOperationCompleted == null)
		{
			getMessageStatusOperationCompleted = OngetMessageStatusOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getMessageStatus", new object[4] { username, password, domain, messageId }, getMessageStatusOperationCompleted, userState);
	}

	private void OngetMessageStatusOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getMessageStatusCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getMessageStatusCompleted(this, new getMessageStatusCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int[] getMessageStatuses(string username, string password, string domain, long[] messageId)
	{
		return (int[])((SoapHttpClientProtocol)this).Invoke("getMessageStatuses", new object[4] { username, password, domain, messageId })[0];
	}

	public void getMessageStatusesAsync(string username, string password, string domain, long[] messageId)
	{
		getMessageStatusesAsync(username, password, domain, messageId, null);
	}

	public void getMessageStatusesAsync(string username, string password, string domain, long[] messageId, object userState)
	{
		if (getMessageStatusesOperationCompleted == null)
		{
			getMessageStatusesOperationCompleted = OngetMessageStatusesOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getMessageStatuses", new object[4] { username, password, domain, messageId }, getMessageStatusesOperationCompleted, userState);
	}

	private void OngetMessageStatusesOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getMessageStatusesCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getMessageStatusesCompleted(this, new getMessageStatusesCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getReciveSMSWithNumberOnDate(string username, string password, string domain, string number, string startDate, string startTime, string endDate, string endTime)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getReciveSMSWithNumberOnDate", new object[8] { username, password, domain, number, startDate, startTime, endDate, endTime })[0];
	}

	public void getReciveSMSWithNumberOnDateAsync(string username, string password, string domain, string number, string startDate, string startTime, string endDate, string endTime)
	{
		getReciveSMSWithNumberOnDateAsync(username, password, domain, number, startDate, startTime, endDate, endTime, null);
	}

	public void getReciveSMSWithNumberOnDateAsync(string username, string password, string domain, string number, string startDate, string startTime, string endDate, string endTime, object userState)
	{
		if (getReciveSMSWithNumberOnDateOperationCompleted == null)
		{
			getReciveSMSWithNumberOnDateOperationCompleted = OngetReciveSMSWithNumberOnDateOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getReciveSMSWithNumberOnDate", new object[8] { username, password, domain, number, startDate, startTime, endDate, endTime }, getReciveSMSWithNumberOnDateOperationCompleted, userState);
	}

	private void OngetReciveSMSWithNumberOnDateOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getReciveSMSWithNumberOnDateCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getReciveSMSWithNumberOnDateCompleted(this, new getReciveSMSWithNumberOnDateCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getAllReciveSMSWithNumber(string username, string password, string domain, string number)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getAllReciveSMSWithNumber", new object[4] { username, password, domain, number })[0];
	}

	public void getAllReciveSMSWithNumberAsync(string username, string password, string domain, string number)
	{
		getAllReciveSMSWithNumberAsync(username, password, domain, number, null);
	}

	public void getAllReciveSMSWithNumberAsync(string username, string password, string domain, string number, object userState)
	{
		if (getAllReciveSMSWithNumberOperationCompleted == null)
		{
			getAllReciveSMSWithNumberOperationCompleted = OngetAllReciveSMSWithNumberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getAllReciveSMSWithNumber", new object[4] { username, password, domain, number }, getAllReciveSMSWithNumberOperationCompleted, userState);
	}

	private void OngetAllReciveSMSWithNumberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getAllReciveSMSWithNumberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getAllReciveSMSWithNumberCompleted(this, new getAllReciveSMSWithNumberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getAllReciveSMS(string username, string password, string domain)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getAllReciveSMS", new object[3] { username, password, domain })[0];
	}

	public void getAllReciveSMSAsync(string username, string password, string domain)
	{
		getAllReciveSMSAsync(username, password, domain, null);
	}

	public void getAllReciveSMSAsync(string username, string password, string domain, object userState)
	{
		if (getAllReciveSMSOperationCompleted == null)
		{
			getAllReciveSMSOperationCompleted = OngetAllReciveSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getAllReciveSMS", new object[3] { username, password, domain }, getAllReciveSMSOperationCompleted, userState);
	}

	private void OngetAllReciveSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getAllReciveSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getAllReciveSMSCompleted(this, new getAllReciveSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getAllReciveSMSOnDate(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getAllReciveSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime })[0];
	}

	public void getAllReciveSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		getAllReciveSMSOnDateAsync(username, password, domain, startDate, startTime, endDate, endTime, null);
	}

	public void getAllReciveSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime, object userState)
	{
		if (getAllReciveSMSOnDateOperationCompleted == null)
		{
			getAllReciveSMSOnDateOperationCompleted = OngetAllReciveSMSOnDateOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getAllReciveSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime }, getAllReciveSMSOnDateOperationCompleted, userState);
	}

	private void OngetAllReciveSMSOnDateOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getAllReciveSMSOnDateCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getAllReciveSMSOnDateCompleted(this, new getAllReciveSMSOnDateCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getReciveSMSOnReciveID(string username, string password, string domain, long reciveID)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getReciveSMSOnReciveID", new object[4] { username, password, domain, reciveID })[0];
	}

	public void getReciveSMSOnReciveIDAsync(string username, string password, string domain, long reciveID)
	{
		getReciveSMSOnReciveIDAsync(username, password, domain, reciveID, null);
	}

	public void getReciveSMSOnReciveIDAsync(string username, string password, string domain, long reciveID, object userState)
	{
		if (getReciveSMSOnReciveIDOperationCompleted == null)
		{
			getReciveSMSOnReciveIDOperationCompleted = OngetReciveSMSOnReciveIDOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getReciveSMSOnReciveID", new object[4] { username, password, domain, reciveID }, getReciveSMSOnReciveIDOperationCompleted, userState);
	}

	private void OngetReciveSMSOnReciveIDOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getReciveSMSOnReciveIDCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getReciveSMSOnReciveIDCompleted(this, new getReciveSMSOnReciveIDCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getLastReciveSMS(string username, string password, string domain, int numberOfRecive)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getLastReciveSMS", new object[4] { username, password, domain, numberOfRecive })[0];
	}

	public void getLastReciveSMSAsync(string username, string password, string domain, int numberOfRecive)
	{
		getLastReciveSMSAsync(username, password, domain, numberOfRecive, null);
	}

	public void getLastReciveSMSAsync(string username, string password, string domain, int numberOfRecive, object userState)
	{
		if (getLastReciveSMSOperationCompleted == null)
		{
			getLastReciveSMSOperationCompleted = OngetLastReciveSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getLastReciveSMS", new object[4] { username, password, domain, numberOfRecive }, getLastReciveSMSOperationCompleted, userState);
	}

	private void OngetLastReciveSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getLastReciveSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getLastReciveSMSCompleted(this, new getLastReciveSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getLastReciveSMSWithNumber(string username, string password, string domain, string number, int numberOfRecive)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getLastReciveSMSWithNumber", new object[5] { username, password, domain, number, numberOfRecive })[0];
	}

	public void getLastReciveSMSWithNumberAsync(string username, string password, string domain, string number, int numberOfRecive)
	{
		getLastReciveSMSWithNumberAsync(username, password, domain, number, numberOfRecive, null);
	}

	public void getLastReciveSMSWithNumberAsync(string username, string password, string domain, string number, int numberOfRecive, object userState)
	{
		if (getLastReciveSMSWithNumberOperationCompleted == null)
		{
			getLastReciveSMSWithNumberOperationCompleted = OngetLastReciveSMSWithNumberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getLastReciveSMSWithNumber", new object[5] { username, password, domain, number, numberOfRecive }, getLastReciveSMSWithNumberOperationCompleted, userState);
	}

	private void OngetLastReciveSMSWithNumberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getLastReciveSMSWithNumberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getLastReciveSMSWithNumberCompleted(this, new getLastReciveSMSWithNumberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long setSendSMSOnDateTime(string username, string password, string domain, string senderNumber, string messageBody, string[] recipientNumbers, string sendDate, string sendTime, bool active)
	{
		return (long)((SoapHttpClientProtocol)this).Invoke("setSendSMSOnDateTime", new object[9] { username, password, domain, senderNumber, messageBody, recipientNumbers, sendDate, sendTime, active })[0];
	}

	public void setSendSMSOnDateTimeAsync(string username, string password, string domain, string senderNumber, string messageBody, string[] recipientNumbers, string sendDate, string sendTime, bool active)
	{
		setSendSMSOnDateTimeAsync(username, password, domain, senderNumber, messageBody, recipientNumbers, sendDate, sendTime, active, null);
	}

	public void setSendSMSOnDateTimeAsync(string username, string password, string domain, string senderNumber, string messageBody, string[] recipientNumbers, string sendDate, string sendTime, bool active, object userState)
	{
		if (setSendSMSOnDateTimeOperationCompleted == null)
		{
			setSendSMSOnDateTimeOperationCompleted = OnsetSendSMSOnDateTimeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("setSendSMSOnDateTime", new object[9] { username, password, domain, senderNumber, messageBody, recipientNumbers, sendDate, sendTime, active }, setSendSMSOnDateTimeOperationCompleted, userState);
	}

	private void OnsetSendSMSOnDateTimeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.setSendSMSOnDateTimeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.setSendSMSOnDateTimeCompleted(this, new setSendSMSOnDateTimeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public bool changeActiveOfSendSMSOnDateTime(string username, string password, string domain, long sendID, bool active)
	{
		return (bool)((SoapHttpClientProtocol)this).Invoke("changeActiveOfSendSMSOnDateTime", new object[5] { username, password, domain, sendID, active })[0];
	}

	public void changeActiveOfSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID, bool active)
	{
		changeActiveOfSendSMSOnDateTimeAsync(username, password, domain, sendID, active, null);
	}

	public void changeActiveOfSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID, bool active, object userState)
	{
		if (changeActiveOfSendSMSOnDateTimeOperationCompleted == null)
		{
			changeActiveOfSendSMSOnDateTimeOperationCompleted = OnchangeActiveOfSendSMSOnDateTimeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("changeActiveOfSendSMSOnDateTime", new object[5] { username, password, domain, sendID, active }, changeActiveOfSendSMSOnDateTimeOperationCompleted, userState);
	}

	private void OnchangeActiveOfSendSMSOnDateTimeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.changeActiveOfSendSMSOnDateTimeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.changeActiveOfSendSMSOnDateTimeCompleted(this, new changeActiveOfSendSMSOnDateTimeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public string getResultOfSendSMSOnDateTime(string username, string password, string domain, long sendID)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("getResultOfSendSMSOnDateTime", new object[4] { username, password, domain, sendID })[0];
	}

	public void getResultOfSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID)
	{
		getResultOfSendSMSOnDateTimeAsync(username, password, domain, sendID, null);
	}

	public void getResultOfSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID, object userState)
	{
		if (getResultOfSendSMSOnDateTimeOperationCompleted == null)
		{
			getResultOfSendSMSOnDateTimeOperationCompleted = OngetResultOfSendSMSOnDateTimeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getResultOfSendSMSOnDateTime", new object[4] { username, password, domain, sendID }, getResultOfSendSMSOnDateTimeOperationCompleted, userState);
	}

	private void OngetResultOfSendSMSOnDateTimeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getResultOfSendSMSOnDateTimeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getResultOfSendSMSOnDateTimeCompleted(this, new getResultOfSendSMSOnDateTimeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public bool removeSendSMSOnDateTime(string username, string password, string domain, long sendID)
	{
		return (bool)((SoapHttpClientProtocol)this).Invoke("removeSendSMSOnDateTime", new object[4] { username, password, domain, sendID })[0];
	}

	public void removeSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID)
	{
		removeSendSMSOnDateTimeAsync(username, password, domain, sendID, null);
	}

	public void removeSendSMSOnDateTimeAsync(string username, string password, string domain, long sendID, object userState)
	{
		if (removeSendSMSOnDateTimeOperationCompleted == null)
		{
			removeSendSMSOnDateTimeOperationCompleted = OnremoveSendSMSOnDateTimeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("removeSendSMSOnDateTime", new object[4] { username, password, domain, sendID }, removeSendSMSOnDateTimeOperationCompleted, userState);
	}

	private void OnremoveSendSMSOnDateTimeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.removeSendSMSOnDateTimeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.removeSendSMSOnDateTimeCompleted(this, new removeSendSMSOnDateTimeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public decimal getCredit(string username, string password, string domain)
	{
		return (decimal)((SoapHttpClientProtocol)this).Invoke("getCredit", new object[3] { username, password, domain })[0];
	}

	public void getCreditAsync(string username, string password, string domain)
	{
		getCreditAsync(username, password, domain, null);
	}

	public void getCreditAsync(string username, string password, string domain, object userState)
	{
		if (getCreditOperationCompleted == null)
		{
			getCreditOperationCompleted = OngetCreditOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getCredit", new object[3] { username, password, domain }, getCreditOperationCompleted, userState);
	}

	private void OngetCreditOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getCreditCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getCreditCompleted(this, new getCreditCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int GetTotalUnreadSMS(string username, string password, string domain)
	{
		return (int)((SoapHttpClientProtocol)this).Invoke("GetTotalUnreadSMS", new object[3] { username, password, domain })[0];
	}

	public void GetTotalUnreadSMSAsync(string username, string password, string domain)
	{
		GetTotalUnreadSMSAsync(username, password, domain, null);
	}

	public void GetTotalUnreadSMSAsync(string username, string password, string domain, object userState)
	{
		if (GetTotalUnreadSMSOperationCompleted == null)
		{
			GetTotalUnreadSMSOperationCompleted = OnGetTotalUnreadSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetTotalUnreadSMS", new object[3] { username, password, domain }, GetTotalUnreadSMSOperationCompleted, userState);
	}

	private void OnGetTotalUnreadSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetTotalUnreadSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetTotalUnreadSMSCompleted(this, new GetTotalUnreadSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int GetTotalUnreadSMSWithNumber(string username, string password, string domain, string ReceiveNumber)
	{
		return (int)((SoapHttpClientProtocol)this).Invoke("GetTotalUnreadSMSWithNumber", new object[4] { username, password, domain, ReceiveNumber })[0];
	}

	public void GetTotalUnreadSMSWithNumberAsync(string username, string password, string domain, string ReceiveNumber)
	{
		GetTotalUnreadSMSWithNumberAsync(username, password, domain, ReceiveNumber, null);
	}

	public void GetTotalUnreadSMSWithNumberAsync(string username, string password, string domain, string ReceiveNumber, object userState)
	{
		if (GetTotalUnreadSMSWithNumberOperationCompleted == null)
		{
			GetTotalUnreadSMSWithNumberOperationCompleted = OnGetTotalUnreadSMSWithNumberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetTotalUnreadSMSWithNumber", new object[4] { username, password, domain, ReceiveNumber }, GetTotalUnreadSMSWithNumberOperationCompleted, userState);
	}

	private void OnGetTotalUnreadSMSWithNumberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetTotalUnreadSMSWithNumberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetTotalUnreadSMSWithNumberCompleted(this, new GetTotalUnreadSMSWithNumberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] GetUnreadSMS(string username, string password, string domain, int Count)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("GetUnreadSMS", new object[4] { username, password, domain, Count })[0];
	}

	public void GetUnreadSMSAsync(string username, string password, string domain, int Count)
	{
		GetUnreadSMSAsync(username, password, domain, Count, null);
	}

	public void GetUnreadSMSAsync(string username, string password, string domain, int Count, object userState)
	{
		if (GetUnreadSMSOperationCompleted == null)
		{
			GetUnreadSMSOperationCompleted = OnGetUnreadSMSOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetUnreadSMS", new object[4] { username, password, domain, Count }, GetUnreadSMSOperationCompleted, userState);
	}

	private void OnGetUnreadSMSOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetUnreadSMSCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetUnreadSMSCompleted(this, new GetUnreadSMSCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] GetUnreadSMSWithNumber(string username, string password, string domain, string ReceiveNumber, int Count)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("GetUnreadSMSWithNumber", new object[5] { username, password, domain, ReceiveNumber, Count })[0];
	}

	public void GetUnreadSMSWithNumberAsync(string username, string password, string domain, string ReceiveNumber, int Count)
	{
		GetUnreadSMSWithNumberAsync(username, password, domain, ReceiveNumber, Count, null);
	}

	public void GetUnreadSMSWithNumberAsync(string username, string password, string domain, string ReceiveNumber, int Count, object userState)
	{
		if (GetUnreadSMSWithNumberOperationCompleted == null)
		{
			GetUnreadSMSWithNumberOperationCompleted = OnGetUnreadSMSWithNumberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetUnreadSMSWithNumber", new object[5] { username, password, domain, ReceiveNumber, Count }, GetUnreadSMSWithNumberOperationCompleted, userState);
	}

	private void OnGetUnreadSMSWithNumberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetUnreadSMSWithNumberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetUnreadSMSWithNumberCompleted(this, new GetUnreadSMSWithNumberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] getAllReadReciveSMSOnDate(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("getAllReadReciveSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime })[0];
	}

	public void getAllReadReciveSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		getAllReadReciveSMSOnDateAsync(username, password, domain, startDate, startTime, endDate, endTime, null);
	}

	public void getAllReadReciveSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime, object userState)
	{
		if (getAllReadReciveSMSOnDateOperationCompleted == null)
		{
			getAllReadReciveSMSOnDateOperationCompleted = OngetAllReadReciveSMSOnDateOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getAllReadReciveSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime }, getAllReadReciveSMSOnDateOperationCompleted, userState);
	}

	private void OngetAllReadReciveSMSOnDateOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getAllReadReciveSMSOnDateCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getAllReadReciveSMSOnDateCompleted(this, new getAllReadReciveSMSOnDateCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public reciveInfo[] GetUnreadSMSWithNoChange(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		return (reciveInfo[])((SoapHttpClientProtocol)this).Invoke("GetUnreadSMSWithNoChange", new object[7] { username, password, domain, startDate, startTime, endDate, endTime })[0];
	}

	public void GetUnreadSMSWithNoChangeAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		GetUnreadSMSWithNoChangeAsync(username, password, domain, startDate, startTime, endDate, endTime, null);
	}

	public void GetUnreadSMSWithNoChangeAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime, object userState)
	{
		if (GetUnreadSMSWithNoChangeOperationCompleted == null)
		{
			GetUnreadSMSWithNoChangeOperationCompleted = OnGetUnreadSMSWithNoChangeOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetUnreadSMSWithNoChange", new object[7] { username, password, domain, startDate, startTime, endDate, endTime }, GetUnreadSMSWithNoChangeOperationCompleted, userState);
	}

	private void OnGetUnreadSMSWithNoChangeOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetUnreadSMSWithNoChangeCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetUnreadSMSWithNoChangeCompleted(this, new GetUnreadSMSWithNoChangeCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public SendInfo[] getSendSMSOnDate(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		return (SendInfo[])((SoapHttpClientProtocol)this).Invoke("getSendSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime })[0];
	}

	public void getSendSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime)
	{
		getSendSMSOnDateAsync(username, password, domain, startDate, startTime, endDate, endTime, null);
	}

	public void getSendSMSOnDateAsync(string username, string password, string domain, string startDate, string startTime, string endDate, string endTime, object userState)
	{
		if (getSendSMSOnDateOperationCompleted == null)
		{
			getSendSMSOnDateOperationCompleted = OngetSendSMSOnDateOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("getSendSMSOnDate", new object[7] { username, password, domain, startDate, startTime, endDate, endTime }, getSendSMSOnDateOperationCompleted, userState);
	}

	private void OngetSendSMSOnDateOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.getSendSMSOnDateCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.getSendSMSOnDateCompleted(this, new getSendSMSOnDateCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
