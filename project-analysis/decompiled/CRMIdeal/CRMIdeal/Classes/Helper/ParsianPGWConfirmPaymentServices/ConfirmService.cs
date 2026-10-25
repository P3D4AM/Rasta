using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace CRMIdeal.Classes.Helper.ParsianPGWConfirmPaymentServices;

[GeneratedCode("System.Web.Services", "4.6.1586.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "ConfirmServiceSoap", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
public class ConfirmService : SoapHttpClientProtocol
{
	private SendOrPostCallback ConfirmPaymentOperationCompleted;

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

	public event ConfirmPaymentCompletedEventHandler ConfirmPaymentCompleted;

	public ConfirmService()
	{
		Url = "https://pec.shaparak.ir/NewIPGServices/confirm/confirmservice.asmx";
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
	public ClientConfirmResponseData ConfirmPayment(ClientConfirmRequestData requestData)
	{
		return (ClientConfirmResponseData)((SoapHttpClientProtocol)this).Invoke("ConfirmPayment", new object[1] { requestData })[0];
	}

	public void ConfirmPaymentAsync(ClientConfirmRequestData requestData)
	{
		ConfirmPaymentAsync(requestData, null);
	}

	public void ConfirmPaymentAsync(ClientConfirmRequestData requestData, object userState)
	{
		if (ConfirmPaymentOperationCompleted == null)
		{
			ConfirmPaymentOperationCompleted = OnConfirmPaymentOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("ConfirmPayment", new object[1] { requestData }, ConfirmPaymentOperationCompleted, userState);
	}

	private void OnConfirmPaymentOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.ConfirmPaymentCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.ConfirmPaymentCompleted(this, new ConfirmPaymentCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
