using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.BankParsian;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class SaleServiceSoapClient : ClientBase<SaleServiceSoap>, SaleServiceSoap
{
	public SaleServiceSoapClient()
	{
	}

	public SaleServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public SaleServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SaleServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SaleServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SalePaymentRequestResponse SaleServiceSoap.SalePaymentRequest(SalePaymentRequestRequest request)
	{
		return base.Channel.SalePaymentRequest(request);
	}

	public ClientSaleResponseData SalePaymentRequest(ClientSaleRequestData requestData)
	{
		SalePaymentRequestRequest salePaymentRequestRequest = new SalePaymentRequestRequest();
		salePaymentRequestRequest.Body = new SalePaymentRequestRequestBody();
		salePaymentRequestRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentRequest(salePaymentRequestRequest).Body.SalePaymentRequestResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SalePaymentRequestResponse> SaleServiceSoap.SalePaymentRequestAsync(SalePaymentRequestRequest request)
	{
		return base.Channel.SalePaymentRequestAsync(request);
	}

	public Task<SalePaymentRequestResponse> SalePaymentRequestAsync(ClientSaleRequestData requestData)
	{
		SalePaymentRequestRequest salePaymentRequestRequest = new SalePaymentRequestRequest();
		salePaymentRequestRequest.Body = new SalePaymentRequestRequestBody();
		salePaymentRequestRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentRequestAsync(salePaymentRequestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SalePaymentWithIdResponse SaleServiceSoap.SalePaymentWithId(SalePaymentWithIdRequest request)
	{
		return base.Channel.SalePaymentWithId(request);
	}

	public ClientSaleResponseData SalePaymentWithId(ClientSaleRequestData requestData)
	{
		SalePaymentWithIdRequest salePaymentWithIdRequest = new SalePaymentWithIdRequest();
		salePaymentWithIdRequest.Body = new SalePaymentWithIdRequestBody();
		salePaymentWithIdRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentWithId(salePaymentWithIdRequest).Body.SalePaymentWithIdResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SalePaymentWithIdResponse> SaleServiceSoap.SalePaymentWithIdAsync(SalePaymentWithIdRequest request)
	{
		return base.Channel.SalePaymentWithIdAsync(request);
	}

	public Task<SalePaymentWithIdResponse> SalePaymentWithIdAsync(ClientSaleRequestData requestData)
	{
		SalePaymentWithIdRequest salePaymentWithIdRequest = new SalePaymentWithIdRequest();
		salePaymentWithIdRequest.Body = new SalePaymentWithIdRequestBody();
		salePaymentWithIdRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentWithIdAsync(salePaymentWithIdRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	UDSalePaymentRequestResponse SaleServiceSoap.UDSalePaymentRequest(UDSalePaymentRequestRequest request)
	{
		return base.Channel.UDSalePaymentRequest(request);
	}

	public ClientPaymentResponseDataBase UDSalePaymentRequest(ClientSaleRequestData requestData)
	{
		UDSalePaymentRequestRequest uDSalePaymentRequestRequest = new UDSalePaymentRequestRequest();
		uDSalePaymentRequestRequest.Body = new UDSalePaymentRequestRequestBody();
		uDSalePaymentRequestRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).UDSalePaymentRequest(uDSalePaymentRequestRequest).Body.UDSalePaymentRequestResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<UDSalePaymentRequestResponse> SaleServiceSoap.UDSalePaymentRequestAsync(UDSalePaymentRequestRequest request)
	{
		return base.Channel.UDSalePaymentRequestAsync(request);
	}

	public Task<UDSalePaymentRequestResponse> UDSalePaymentRequestAsync(ClientSaleRequestData requestData)
	{
		UDSalePaymentRequestRequest uDSalePaymentRequestRequest = new UDSalePaymentRequestRequest();
		uDSalePaymentRequestRequest.Body = new UDSalePaymentRequestRequestBody();
		uDSalePaymentRequestRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).UDSalePaymentRequestAsync(uDSalePaymentRequestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SalePaymentWithDiscountResponse SaleServiceSoap.SalePaymentWithDiscount(SalePaymentWithDiscountRequest request)
	{
		return base.Channel.SalePaymentWithDiscount(request);
	}

	public ClientSaleResponseData SalePaymentWithDiscount(ClientSaleDiscountRequestData requestData)
	{
		SalePaymentWithDiscountRequest salePaymentWithDiscountRequest = new SalePaymentWithDiscountRequest();
		salePaymentWithDiscountRequest.Body = new SalePaymentWithDiscountRequestBody();
		salePaymentWithDiscountRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentWithDiscount(salePaymentWithDiscountRequest).Body.SalePaymentWithDiscountResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SalePaymentWithDiscountResponse> SaleServiceSoap.SalePaymentWithDiscountAsync(SalePaymentWithDiscountRequest request)
	{
		return base.Channel.SalePaymentWithDiscountAsync(request);
	}

	public Task<SalePaymentWithDiscountResponse> SalePaymentWithDiscountAsync(ClientSaleDiscountRequestData requestData)
	{
		SalePaymentWithDiscountRequest salePaymentWithDiscountRequest = new SalePaymentWithDiscountRequest();
		salePaymentWithDiscountRequest.Body = new SalePaymentWithDiscountRequestBody();
		salePaymentWithDiscountRequest.Body.requestData = requestData;
		return ((SaleServiceSoap)this).SalePaymentWithDiscountAsync(salePaymentWithDiscountRequest);
	}
}
