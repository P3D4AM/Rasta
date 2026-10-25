using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace CRMIdeal.Classes.Helper.ParsianPGWSalePaymentServices;

[GeneratedCode("System.Web.Services", "4.7.2556.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "SaleServiceSoap", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
[XmlInclude(typeof(ClientPaymentRequestDataBase))]
public class SaleService : SoapHttpClientProtocol
{
	private SendOrPostCallback SalePaymentRequestOperationCompleted;

	private SendOrPostCallback UDSalePaymentRequestOperationCompleted;

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

	public event SalePaymentRequestCompletedEventHandler SalePaymentRequestCompleted;

	public event UDSalePaymentRequestCompletedEventHandler UDSalePaymentRequestCompleted;

	public SaleService()
	{
		Url = "https://pec.shaparak.ir/NewIPGServices/Sale/SaleService.asmx";
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
	public ClientSaleResponseData SalePaymentRequest(ClientSaleRequestData requestData)
	{
		return (ClientSaleResponseData)((SoapHttpClientProtocol)this).Invoke("SalePaymentRequest", new object[1] { requestData })[0];
	}

	public void SalePaymentRequestAsync(ClientSaleRequestData requestData)
	{
		SalePaymentRequestAsync(requestData, null);
	}

	public void SalePaymentRequestAsync(ClientSaleRequestData requestData, object userState)
	{
		if (SalePaymentRequestOperationCompleted == null)
		{
			SalePaymentRequestOperationCompleted = OnSalePaymentRequestOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("SalePaymentRequest", new object[1] { requestData }, SalePaymentRequestOperationCompleted, userState);
	}

	private void OnSalePaymentRequestOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.SalePaymentRequestCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.SalePaymentRequestCompleted(this, new SalePaymentRequestCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public ClientPaymentResponseDataBase UDSalePaymentRequest(ClientSaleRequestData requestData)
	{
		return (ClientPaymentResponseDataBase)((SoapHttpClientProtocol)this).Invoke("UDSalePaymentRequest", new object[1] { requestData })[0];
	}

	public void UDSalePaymentRequestAsync(ClientSaleRequestData requestData)
	{
		UDSalePaymentRequestAsync(requestData, null);
	}

	public void UDSalePaymentRequestAsync(ClientSaleRequestData requestData, object userState)
	{
		if (UDSalePaymentRequestOperationCompleted == null)
		{
			UDSalePaymentRequestOperationCompleted = OnUDSalePaymentRequestOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("UDSalePaymentRequest", new object[1] { requestData }, UDSalePaymentRequestOperationCompleted, userState);
	}

	private void OnUDSalePaymentRequestOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.UDSalePaymentRequestCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.UDSalePaymentRequestCompleted(this, new UDSalePaymentRequestCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
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
