using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using Mobile.Properties;

namespace Mobile.SmsKaveNegar;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "v1Soap", Namespace = "http://api.kavenegar.com/")]
public class v1 : SoapHttpClientProtocol
{
	private SendOrPostCallback SendAdvanceOperationCompleted;

	private SendOrPostCallback SendSimpleByApikeyOperationCompleted;

	private SendOrPostCallback SendSimpleByLoginInfoOperationCompleted;

	private SendOrPostCallback SendArrayByLoginInfoOperationCompleted;

	private SendOrPostCallback SendArrayByApikeyOperationCompleted;

	private SendOrPostCallback GetStatusByApikeyOperationCompleted;

	private SendOrPostCallback GetStatusByLoginInfoOperationCompleted;

	private SendOrPostCallback SelectByApikeyOperationCompleted;

	private SendOrPostCallback SelectByLoginInfoOperationCompleted;

	private SendOrPostCallback SelectoutboxByApikeyOperationCompleted;

	private SendOrPostCallback SelectoutboxByLoginInfoOperationCompleted;

	private SendOrPostCallback SelectlatestByApikeyOperationCompleted;

	private SendOrPostCallback SelectlatestByLoginInfoOperationCompleted;

	private SendOrPostCallback CancelByApikeyOperationCompleted;

	private SendOrPostCallback CancelByLoginInfoOperationCompleted;

	private SendOrPostCallback ReceiveByApikeyOperationCompleted;

	private SendOrPostCallback ReceiveByLoginInfoOperationCompleted;

	private SendOrPostCallback RemainCreditByApiKeyOperationCompleted;

	private SendOrPostCallback RemainCreditByLoginInfoOperationCompleted;

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

	public event SendAdvanceCompletedEventHandler SendAdvanceCompleted;

	public event SendSimpleByApikeyCompletedEventHandler SendSimpleByApikeyCompleted;

	public event SendSimpleByLoginInfoCompletedEventHandler SendSimpleByLoginInfoCompleted;

	public event SendArrayByLoginInfoCompletedEventHandler SendArrayByLoginInfoCompleted;

	public event SendArrayByApikeyCompletedEventHandler SendArrayByApikeyCompleted;

	public event GetStatusByApikeyCompletedEventHandler GetStatusByApikeyCompleted;

	public event GetStatusByLoginInfoCompletedEventHandler GetStatusByLoginInfoCompleted;

	public event SelectByApikeyCompletedEventHandler SelectByApikeyCompleted;

	public event SelectByLoginInfoCompletedEventHandler SelectByLoginInfoCompleted;

	public event SelectoutboxByApikeyCompletedEventHandler SelectoutboxByApikeyCompleted;

	public event SelectoutboxByLoginInfoCompletedEventHandler SelectoutboxByLoginInfoCompleted;

	public event SelectlatestByApikeyCompletedEventHandler SelectlatestByApikeyCompleted;

	public event SelectlatestByLoginInfoCompletedEventHandler SelectlatestByLoginInfoCompleted;

	public event CancelByApikeyCompletedEventHandler CancelByApikeyCompleted;

	public event CancelByLoginInfoCompletedEventHandler CancelByLoginInfoCompleted;

	public event ReceiveByApikeyCompletedEventHandler ReceiveByApikeyCompleted;

	public event ReceiveByLoginInfoCompletedEventHandler ReceiveByLoginInfoCompleted;

	public event RemainCreditByApiKeyCompletedEventHandler RemainCreditByApiKeyCompleted;

	public event RemainCreditByLoginInfoCompletedEventHandler RemainCreditByLoginInfoCompleted;

	public v1()
	{
		Url = Settings.Default.Mobile_SmsKaveNegar_v1;
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
	public long SendAdvance(string apikey, string sender, string message, int encoding, string receptor, long unixdate, int messagemode, string fallbackurl, string clientmessageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SendAdvance", new object[11]
		{
			apikey, sender, message, encoding, receptor, unixdate, messagemode, fallbackurl, clientmessageid, status,
			statusmessage
		});
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long)array[0];
	}

	public void SendAdvanceAsync(string apikey, string sender, string message, int encoding, string receptor, long unixdate, int messagemode, string fallbackurl, string clientmessageid, int status, string statusmessage)
	{
		SendAdvanceAsync(apikey, sender, message, encoding, receptor, unixdate, messagemode, fallbackurl, clientmessageid, status, statusmessage, null);
	}

	public void SendAdvanceAsync(string apikey, string sender, string message, int encoding, string receptor, long unixdate, int messagemode, string fallbackurl, string clientmessageid, int status, string statusmessage, object userState)
	{
		if (SendAdvanceOperationCompleted == null)
		{
			SendAdvanceOperationCompleted = OnSendAdvanceOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendAdvance", new object[11]
		{
			apikey, sender, message, encoding, receptor, unixdate, messagemode, fallbackurl, clientmessageid, status,
			statusmessage
		}, SendAdvanceOperationCompleted, userState);
	}

	private void OnSendAdvanceOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendAdvanceCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendAdvanceCompleted(this, new SendAdvanceCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] SendSimpleByApikey(string apikey, string sender, string message, string[] receptor, long unixdate, int msgmode, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SendSimpleByApikey", new object[8] { apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long[])array[0];
	}

	public void SendSimpleByApikeyAsync(string apikey, string sender, string message, string[] receptor, long unixdate, int msgmode, int status, string statusmessage)
	{
		SendSimpleByApikeyAsync(apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage, null);
	}

	public void SendSimpleByApikeyAsync(string apikey, string sender, string message, string[] receptor, long unixdate, int msgmode, int status, string statusmessage, object userState)
	{
		if (SendSimpleByApikeyOperationCompleted == null)
		{
			SendSimpleByApikeyOperationCompleted = OnSendSimpleByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendSimpleByApikey", new object[8] { apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage }, SendSimpleByApikeyOperationCompleted, userState);
	}

	private void OnSendSimpleByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendSimpleByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendSimpleByApikeyCompleted(this, new SendSimpleByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] SendSimpleByLoginInfo(string userName, string password, string sender, string message, string[] receptor, long unixdate, int msgmode, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SendSimpleByLoginInfo", new object[9] { userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long[])array[0];
	}

	public void SendSimpleByLoginInfoAsync(string userName, string password, string sender, string message, string[] receptor, long unixdate, int msgmode, int status, string statusmessage)
	{
		SendSimpleByLoginInfoAsync(userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage, null);
	}

	public void SendSimpleByLoginInfoAsync(string userName, string password, string sender, string message, string[] receptor, long unixdate, int msgmode, int status, string statusmessage, object userState)
	{
		if (SendSimpleByLoginInfoOperationCompleted == null)
		{
			SendSimpleByLoginInfoOperationCompleted = OnSendSimpleByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendSimpleByLoginInfo", new object[9] { userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage }, SendSimpleByLoginInfoOperationCompleted, userState);
	}

	private void OnSendSimpleByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendSimpleByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendSimpleByLoginInfoCompleted(this, new SendSimpleByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] SendArrayByLoginInfo(string userName, string password, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SendArrayByLoginInfo", new object[9] { userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long[])array[0];
	}

	public void SendArrayByLoginInfoAsync(string userName, string password, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, int status, string statusmessage)
	{
		SendArrayByLoginInfoAsync(userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage, null);
	}

	public void SendArrayByLoginInfoAsync(string userName, string password, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, int status, string statusmessage, object userState)
	{
		if (SendArrayByLoginInfoOperationCompleted == null)
		{
			SendArrayByLoginInfoOperationCompleted = OnSendArrayByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendArrayByLoginInfo", new object[9] { userName, password, sender, message, receptor, unixdate, msgmode, status, statusmessage }, SendArrayByLoginInfoOperationCompleted, userState);
	}

	private void OnSendArrayByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendArrayByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendArrayByLoginInfoCompleted(this, new SendArrayByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long[] SendArrayByApikey(string apikey, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SendArrayByApikey", new object[8] { apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long[])array[0];
	}

	public void SendArrayByApikeyAsync(string apikey, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, int status, string statusmessage)
	{
		SendArrayByApikeyAsync(apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage, null);
	}

	public void SendArrayByApikeyAsync(string apikey, string[] sender, string[] message, string[] receptor, long unixdate, int[] msgmode, int status, string statusmessage, object userState)
	{
		if (SendArrayByApikeyOperationCompleted == null)
		{
			SendArrayByApikeyOperationCompleted = OnSendArrayByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SendArrayByApikey", new object[8] { apikey, sender, message, receptor, unixdate, msgmode, status, statusmessage }, SendArrayByApikeyOperationCompleted, userState);
	}

	private void OnSendArrayByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SendArrayByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SendArrayByApikeyCompleted(this, new SendArrayByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int[] GetStatusByApikey(string apikey, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("GetStatusByApikey", new object[4] { apikey, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (int[])array[0];
	}

	public void GetStatusByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage)
	{
		GetStatusByApikeyAsync(apikey, messageid, status, statusmessage, null);
	}

	public void GetStatusByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage, object userState)
	{
		if (GetStatusByApikeyOperationCompleted == null)
		{
			GetStatusByApikeyOperationCompleted = OnGetStatusByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetStatusByApikey", new object[4] { apikey, messageid, status, statusmessage }, GetStatusByApikeyOperationCompleted, userState);
	}

	private void OnGetStatusByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetStatusByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetStatusByApikeyCompleted(this, new GetStatusByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int[] GetStatusByLoginInfo(string userName, string password, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("GetStatusByLoginInfo", new object[5] { userName, password, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (int[])array[0];
	}

	public void GetStatusByLoginInfoAsync(string userName, string password, long[] messageid, int status, string statusmessage)
	{
		GetStatusByLoginInfoAsync(userName, password, messageid, status, statusmessage, null);
	}

	public void GetStatusByLoginInfoAsync(string userName, string password, long[] messageid, int status, string statusmessage, object userState)
	{
		if (GetStatusByLoginInfoOperationCompleted == null)
		{
			GetStatusByLoginInfoOperationCompleted = OnGetStatusByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetStatusByLoginInfo", new object[5] { userName, password, messageid, status, statusmessage }, GetStatusByLoginInfoOperationCompleted, userState);
	}

	private void OnGetStatusByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.GetStatusByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.GetStatusByLoginInfoCompleted(this, new GetStatusByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectByApikey(string apikey, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectByApikey", new object[4] { apikey, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage)
	{
		SelectByApikeyAsync(apikey, messageid, status, statusmessage, null);
	}

	public void SelectByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage, object userState)
	{
		if (SelectByApikeyOperationCompleted == null)
		{
			SelectByApikeyOperationCompleted = OnSelectByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectByApikey", new object[4] { apikey, messageid, status, statusmessage }, SelectByApikeyOperationCompleted, userState);
	}

	private void OnSelectByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectByApikeyCompleted(this, new SelectByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectByLoginInfo(string username, string password, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectByLoginInfo", new object[5] { username, password, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectByLoginInfoAsync(string username, string password, long[] messageid, int status, string statusmessage)
	{
		SelectByLoginInfoAsync(username, password, messageid, status, statusmessage, null);
	}

	public void SelectByLoginInfoAsync(string username, string password, long[] messageid, int status, string statusmessage, object userState)
	{
		if (SelectByLoginInfoOperationCompleted == null)
		{
			SelectByLoginInfoOperationCompleted = OnSelectByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectByLoginInfo", new object[5] { username, password, messageid, status, statusmessage }, SelectByLoginInfoOperationCompleted, userState);
	}

	private void OnSelectByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectByLoginInfoCompleted(this, new SelectByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectoutboxByApikey(string apikey, long startUnixdate, long endUnixdate, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectoutboxByApikey", new object[5] { apikey, startUnixdate, endUnixdate, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectoutboxByApikeyAsync(string apikey, long startUnixdate, long endUnixdate, int status, string statusmessage)
	{
		SelectoutboxByApikeyAsync(apikey, startUnixdate, endUnixdate, status, statusmessage, null);
	}

	public void SelectoutboxByApikeyAsync(string apikey, long startUnixdate, long endUnixdate, int status, string statusmessage, object userState)
	{
		if (SelectoutboxByApikeyOperationCompleted == null)
		{
			SelectoutboxByApikeyOperationCompleted = OnSelectoutboxByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectoutboxByApikey", new object[5] { apikey, startUnixdate, endUnixdate, status, statusmessage }, SelectoutboxByApikeyOperationCompleted, userState);
	}

	private void OnSelectoutboxByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectoutboxByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectoutboxByApikeyCompleted(this, new SelectoutboxByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectoutboxByLoginInfo(string username, string password, long startUnixdate, long endUnixdate, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectoutboxByLoginInfo", new object[6] { username, password, startUnixdate, endUnixdate, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectoutboxByLoginInfoAsync(string username, string password, long startUnixdate, long endUnixdate, int status, string statusmessage)
	{
		SelectoutboxByLoginInfoAsync(username, password, startUnixdate, endUnixdate, status, statusmessage, null);
	}

	public void SelectoutboxByLoginInfoAsync(string username, string password, long startUnixdate, long endUnixdate, int status, string statusmessage, object userState)
	{
		if (SelectoutboxByLoginInfoOperationCompleted == null)
		{
			SelectoutboxByLoginInfoOperationCompleted = OnSelectoutboxByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectoutboxByLoginInfo", new object[6] { username, password, startUnixdate, endUnixdate, status, statusmessage }, SelectoutboxByLoginInfoOperationCompleted, userState);
	}

	private void OnSelectoutboxByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectoutboxByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectoutboxByLoginInfoCompleted(this, new SelectoutboxByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectlatestByApikey(string apikey, int pagesize, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectlatestByApikey", new object[4] { apikey, pagesize, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectlatestByApikeyAsync(string apikey, int pagesize, int status, string statusmessage)
	{
		SelectlatestByApikeyAsync(apikey, pagesize, status, statusmessage, null);
	}

	public void SelectlatestByApikeyAsync(string apikey, int pagesize, int status, string statusmessage, object userState)
	{
		if (SelectlatestByApikeyOperationCompleted == null)
		{
			SelectlatestByApikeyOperationCompleted = OnSelectlatestByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectlatestByApikey", new object[4] { apikey, pagesize, status, statusmessage }, SelectlatestByApikeyOperationCompleted, userState);
	}

	private void OnSelectlatestByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectlatestByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectlatestByApikeyCompleted(this, new SelectlatestByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiSelect[] SelectlatestByLoginInfo(string username, string password, int pagesize, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("SelectlatestByLoginInfo", new object[5] { username, password, pagesize, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiSelect[])array[0];
	}

	public void SelectlatestByLoginInfoAsync(string username, string password, int pagesize, int status, string statusmessage)
	{
		SelectlatestByLoginInfoAsync(username, password, pagesize, status, statusmessage, null);
	}

	public void SelectlatestByLoginInfoAsync(string username, string password, int pagesize, int status, string statusmessage, object userState)
	{
		if (SelectlatestByLoginInfoOperationCompleted == null)
		{
			SelectlatestByLoginInfoOperationCompleted = OnSelectlatestByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SelectlatestByLoginInfo", new object[5] { username, password, pagesize, status, statusmessage }, SelectlatestByLoginInfoOperationCompleted, userState);
	}

	private void OnSelectlatestByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SelectlatestByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SelectlatestByLoginInfoCompleted(this, new SelectlatestByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int[] CancelByApikey(string apikey, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("CancelByApikey", new object[4] { apikey, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (int[])array[0];
	}

	public void CancelByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage)
	{
		CancelByApikeyAsync(apikey, messageid, status, statusmessage, null);
	}

	public void CancelByApikeyAsync(string apikey, long[] messageid, int status, string statusmessage, object userState)
	{
		if (CancelByApikeyOperationCompleted == null)
		{
			CancelByApikeyOperationCompleted = OnCancelByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CancelByApikey", new object[4] { apikey, messageid, status, statusmessage }, CancelByApikeyOperationCompleted, userState);
	}

	private void OnCancelByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.CancelByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.CancelByApikeyCompleted(this, new CancelByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public int[] CancelByLoginInfo(string userName, string password, long[] messageid, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("CancelByLoginInfo", new object[5] { userName, password, messageid, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (int[])array[0];
	}

	public void CancelByLoginInfoAsync(string userName, string password, long[] messageid, int status, string statusmessage)
	{
		CancelByLoginInfoAsync(userName, password, messageid, status, statusmessage, null);
	}

	public void CancelByLoginInfoAsync(string userName, string password, long[] messageid, int status, string statusmessage, object userState)
	{
		if (CancelByLoginInfoOperationCompleted == null)
		{
			CancelByLoginInfoOperationCompleted = OnCancelByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CancelByLoginInfo", new object[5] { userName, password, messageid, status, statusmessage }, CancelByLoginInfoOperationCompleted, userState);
	}

	private void OnCancelByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.CancelByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.CancelByLoginInfoCompleted(this, new CancelByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiReceive[] ReceiveByApikey(string apikey, string lineNumber, short isread, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("ReceiveByApikey", new object[5] { apikey, lineNumber, isread, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiReceive[])array[0];
	}

	public void ReceiveByApikeyAsync(string apikey, string lineNumber, short isread, int status, string statusmessage)
	{
		ReceiveByApikeyAsync(apikey, lineNumber, isread, status, statusmessage, null);
	}

	public void ReceiveByApikeyAsync(string apikey, string lineNumber, short isread, int status, string statusmessage, object userState)
	{
		if (ReceiveByApikeyOperationCompleted == null)
		{
			ReceiveByApikeyOperationCompleted = OnReceiveByApikeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("ReceiveByApikey", new object[5] { apikey, lineNumber, isread, status, statusmessage }, ReceiveByApikeyOperationCompleted, userState);
	}

	private void OnReceiveByApikeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.ReceiveByApikeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.ReceiveByApikeyCompleted(this, new ReceiveByApikeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ApiReceive[] ReceiveByLoginInfo(string userName, string password, string lineNumber, short isread, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("ReceiveByLoginInfo", new object[6] { userName, password, lineNumber, isread, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (ApiReceive[])array[0];
	}

	public void ReceiveByLoginInfoAsync(string userName, string password, string lineNumber, short isread, int status, string statusmessage)
	{
		ReceiveByLoginInfoAsync(userName, password, lineNumber, isread, status, statusmessage, null);
	}

	public void ReceiveByLoginInfoAsync(string userName, string password, string lineNumber, short isread, int status, string statusmessage, object userState)
	{
		if (ReceiveByLoginInfoOperationCompleted == null)
		{
			ReceiveByLoginInfoOperationCompleted = OnReceiveByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("ReceiveByLoginInfo", new object[6] { userName, password, lineNumber, isread, status, statusmessage }, ReceiveByLoginInfoOperationCompleted, userState);
	}

	private void OnReceiveByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.ReceiveByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.ReceiveByLoginInfoCompleted(this, new ReceiveByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long RemainCreditByApiKey(string apikey, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("RemainCreditByApiKey", new object[3] { apikey, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long)array[0];
	}

	public void RemainCreditByApiKeyAsync(string apikey, int status, string statusmessage)
	{
		RemainCreditByApiKeyAsync(apikey, status, statusmessage, null);
	}

	public void RemainCreditByApiKeyAsync(string apikey, int status, string statusmessage, object userState)
	{
		if (RemainCreditByApiKeyOperationCompleted == null)
		{
			RemainCreditByApiKeyOperationCompleted = OnRemainCreditByApiKeyOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("RemainCreditByApiKey", new object[3] { apikey, status, statusmessage }, RemainCreditByApiKeyOperationCompleted, userState);
	}

	private void OnRemainCreditByApiKeyOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.RemainCreditByApiKeyCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.RemainCreditByApiKeyCompleted(this, new RemainCreditByApiKeyCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public long RemainCreditByLoginInfo(string userName, string password, ref int status, ref string statusmessage)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke("RemainCreditByLoginInfo", new object[4] { userName, password, status, statusmessage });
		status = (int)array[1];
		statusmessage = (string)array[2];
		return (long)array[0];
	}

	public void RemainCreditByLoginInfoAsync(string userName, string password, int status, string statusmessage)
	{
		RemainCreditByLoginInfoAsync(userName, password, status, statusmessage, null);
	}

	public void RemainCreditByLoginInfoAsync(string userName, string password, int status, string statusmessage, object userState)
	{
		if (RemainCreditByLoginInfoOperationCompleted == null)
		{
			RemainCreditByLoginInfoOperationCompleted = OnRemainCreditByLoginInfoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("RemainCreditByLoginInfo", new object[4] { userName, password, status, statusmessage }, RemainCreditByLoginInfoOperationCompleted, userState);
	}

	private void OnRemainCreditByLoginInfoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.RemainCreditByLoginInfoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.RemainCreditByLoginInfoCompleted(this, new RemainCreditByLoginInfoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
