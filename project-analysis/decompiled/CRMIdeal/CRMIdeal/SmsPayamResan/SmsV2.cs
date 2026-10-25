using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using CRMIdeal.Properties;

namespace CRMIdeal.SmsPayamResan;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "SmsV2Soap", Namespace = "http://www.sms-webservice.ir")]
public class SmsV2 : SoapHttpClientProtocol
{
	private SendOrPostCallback SendMessageOperationCompleted;

	private SendOrPostCallback SendMessageMultipleOperationCompleted;

	private SendOrPostCallback GetMessagesStatusOperationCompleted;

	private SendOrPostCallback GetCreditOperationCompleted;

	private SendOrPostCallback GeCreditOperationCompleted;

	private SendOrPostCallback GetAllMessagesOperationCompleted;

	private SendOrPostCallback Throw_errorOperationCompleted;

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

	public event SendMessageCompletedEventHandler SendMessageCompleted;

	public event SendMessageMultipleCompletedEventHandler SendMessageMultipleCompleted;

	public event GetMessagesStatusCompletedEventHandler GetMessagesStatusCompleted;

	public event GetCreditCompletedEventHandler GetCreditCompleted;

	public event GeCreditCompletedEventHandler GeCreditCompleted;

	public event GetAllMessagesCompletedEventHandler GetAllMessagesCompleted;

	public event Throw_errorCompletedEventHandler Throw_errorCompleted;

	public SmsV2()
	{
		Url = Settings.Default.CRMIdeal_SmsPayamResan_SmsV2;
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
	public long[] SendMessage(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("SendMessage", new object[7] { Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, Type, AllowedDelay })[0];
	}

	public void SendMessageAsync(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay)
	{
		SendMessageAsync(Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, Type, AllowedDelay, null);
	}

	public void SendMessageAsync(string Username, string PassWord, string MessageBodie, string[] RecipientNumbers, string SenderNumber, int Type, int AllowedDelay, object userState)
	{
		if (SendMessageOperationCompleted == null)
		{
			SendMessageOperationCompleted = OnSendMessageOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendMessage", new object[7] { Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, Type, AllowedDelay }, SendMessageOperationCompleted, userState);
	}

	private void OnSendMessageOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendMessageCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendMessageCompleted(this, new SendMessageCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] SendMessageMultiple(string Username, string PassWord, string[] MessageBodie, string[] RecipientNumbers, string[] SenderNumber, int[] AllowedDelay)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("SendMessageMultiple", new object[6] { Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, AllowedDelay })[0];
	}

	public void SendMessageMultipleAsync(string Username, string PassWord, string[] MessageBodie, string[] RecipientNumbers, string[] SenderNumber, int[] AllowedDelay)
	{
		SendMessageMultipleAsync(Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, AllowedDelay, null);
	}

	public void SendMessageMultipleAsync(string Username, string PassWord, string[] MessageBodie, string[] RecipientNumbers, string[] SenderNumber, int[] AllowedDelay, object userState)
	{
		if (SendMessageMultipleOperationCompleted == null)
		{
			SendMessageMultipleOperationCompleted = OnSendMessageMultipleOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendMessageMultiple", new object[6] { Username, PassWord, MessageBodie, RecipientNumbers, SenderNumber, AllowedDelay }, SendMessageMultipleOperationCompleted, userState);
	}

	private void OnSendMessageMultipleOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendMessageMultipleCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendMessageMultipleCompleted(this, new SendMessageMultipleCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] GetMessagesStatus(string Username, string PassWord, long[] messagesId)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("GetMessagesStatus", new object[3] { Username, PassWord, messagesId })[0];
	}

	public void GetMessagesStatusAsync(string Username, string PassWord, long[] messagesId)
	{
		GetMessagesStatusAsync(Username, PassWord, messagesId, null);
	}

	public void GetMessagesStatusAsync(string Username, string PassWord, long[] messagesId, object userState)
	{
		if (GetMessagesStatusOperationCompleted == null)
		{
			GetMessagesStatusOperationCompleted = OnGetMessagesStatusOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetMessagesStatus", new object[3] { Username, PassWord, messagesId }, GetMessagesStatusOperationCompleted, userState);
	}

	private void OnGetMessagesStatusOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetMessagesStatusCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetMessagesStatusCompleted(this, new GetMessagesStatusCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public double GetCredit(string Username, string PassWord)
	{
		return (double)((SoapHttpClientProtocol)this).Invoke("GetCredit", new object[2] { Username, PassWord })[0];
	}

	public void GetCreditAsync(string Username, string PassWord)
	{
		GetCreditAsync(Username, PassWord, null);
	}

	public void GetCreditAsync(string Username, string PassWord, object userState)
	{
		if (GetCreditOperationCompleted == null)
		{
			GetCreditOperationCompleted = OnGetCreditOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetCredit", new object[2] { Username, PassWord }, GetCreditOperationCompleted, userState);
	}

	private void OnGetCreditOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetCreditCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetCreditCompleted(this, new GetCreditCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public double GeCredit(string Username, string PassWord)
	{
		return (double)((SoapHttpClientProtocol)this).Invoke("GeCredit", new object[2] { Username, PassWord })[0];
	}

	public void GeCreditAsync(string Username, string PassWord)
	{
		GeCreditAsync(Username, PassWord, null);
	}

	public void GeCreditAsync(string Username, string PassWord, object userState)
	{
		if (GeCreditOperationCompleted == null)
		{
			GeCreditOperationCompleted = OnGeCreditOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GeCredit", new object[2] { Username, PassWord }, GeCreditOperationCompleted, userState);
	}

	private void OnGeCreditOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GeCreditCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GeCreditCompleted(this, new GeCreditCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArrayItem("ArrayOfString")]
	[return: XmlArrayItem(NestingLevel = 1)]
	public string[][] GetAllMessages(string Username, string PassWord, int numberOfMessages, string destNumber, ref int ErrNum)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("GetAllMessages", new object[5] { Username, PassWord, numberOfMessages, destNumber, ErrNum });
		ErrNum = (int)array[1];
		return (string[][])array[0];
	}

	public void GetAllMessagesAsync(string Username, string PassWord, int numberOfMessages, string destNumber, int ErrNum)
	{
		GetAllMessagesAsync(Username, PassWord, numberOfMessages, destNumber, ErrNum, null);
	}

	public void GetAllMessagesAsync(string Username, string PassWord, int numberOfMessages, string destNumber, int ErrNum, object userState)
	{
		if (GetAllMessagesOperationCompleted == null)
		{
			GetAllMessagesOperationCompleted = OnGetAllMessagesOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetAllMessages", new object[5] { Username, PassWord, numberOfMessages, destNumber, ErrNum }, GetAllMessagesOperationCompleted, userState);
	}

	private void OnGetAllMessagesOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetAllMessagesCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetAllMessagesCompleted(this, new GetAllMessagesCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public bool Throw_error()
	{
		return (bool)((SoapHttpClientProtocol)this).Invoke("Throw_error", new object[0])[0];
	}

	public void Throw_errorAsync()
	{
		Throw_errorAsync(null);
	}

	public void Throw_errorAsync(object userState)
	{
		if (Throw_errorOperationCompleted == null)
		{
			Throw_errorOperationCompleted = OnThrow_errorOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Throw_error", new object[0], Throw_errorOperationCompleted, userState);
	}

	private void OnThrow_errorOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.Throw_errorCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.Throw_errorCompleted(this, new Throw_errorCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
