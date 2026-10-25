using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class PaymentGatewayClient : ClientBase<IPaymentGateway>, IPaymentGateway
{
	public PaymentGatewayClient()
	{
	}

	public PaymentGatewayClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public PaymentGatewayClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public PaymentGatewayClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public PaymentGatewayClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundRequestResponse IPaymentGateway.bpRefundRequest(bpRefundRequest request)
	{
		return base.Channel.bpRefundRequest(request);
	}

	public string bpRefundRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		bpRefundRequest bpRefundRequest2 = new bpRefundRequest();
		bpRefundRequest2.Body = new bpRefundRequestBody();
		bpRefundRequest2.Body.terminalId = terminalId;
		bpRefundRequest2.Body.userName = userName;
		bpRefundRequest2.Body.userPassword = userPassword;
		bpRefundRequest2.Body.orderId = orderId;
		bpRefundRequest2.Body.saleOrderId = saleOrderId;
		bpRefundRequest2.Body.saleReferenceId = saleReferenceId;
		bpRefundRequest2.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpRefundRequest(bpRefundRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundRequestResponse> IPaymentGateway.bpRefundRequestAsync(bpRefundRequest request)
	{
		return base.Channel.bpRefundRequestAsync(request);
	}

	public Task<bpRefundRequestResponse> bpRefundRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		bpRefundRequest bpRefundRequest2 = new bpRefundRequest();
		bpRefundRequest2.Body = new bpRefundRequestBody();
		bpRefundRequest2.Body.terminalId = terminalId;
		bpRefundRequest2.Body.userName = userName;
		bpRefundRequest2.Body.userPassword = userPassword;
		bpRefundRequest2.Body.orderId = orderId;
		bpRefundRequest2.Body.saleOrderId = saleOrderId;
		bpRefundRequest2.Body.saleReferenceId = saleReferenceId;
		bpRefundRequest2.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpRefundRequestAsync(bpRefundRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpSaleReferenceIdRequestResponse IPaymentGateway.bpSaleReferenceIdRequest(bpSaleReferenceIdRequest request)
	{
		return base.Channel.bpSaleReferenceIdRequest(request);
	}

	public string bpSaleReferenceIdRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId)
	{
		bpSaleReferenceIdRequest bpSaleReferenceIdRequest2 = new bpSaleReferenceIdRequest();
		bpSaleReferenceIdRequest2.Body = new bpSaleReferenceIdRequestBody();
		bpSaleReferenceIdRequest2.Body.terminalId = terminalId;
		bpSaleReferenceIdRequest2.Body.userName = userName;
		bpSaleReferenceIdRequest2.Body.userPassword = userPassword;
		bpSaleReferenceIdRequest2.Body.orderId = orderId;
		bpSaleReferenceIdRequest2.Body.saleOrderId = saleOrderId;
		return ((IPaymentGateway)this).bpSaleReferenceIdRequest(bpSaleReferenceIdRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpSaleReferenceIdRequestResponse> IPaymentGateway.bpSaleReferenceIdRequestAsync(bpSaleReferenceIdRequest request)
	{
		return base.Channel.bpSaleReferenceIdRequestAsync(request);
	}

	public Task<bpSaleReferenceIdRequestResponse> bpSaleReferenceIdRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId)
	{
		bpSaleReferenceIdRequest bpSaleReferenceIdRequest2 = new bpSaleReferenceIdRequest();
		bpSaleReferenceIdRequest2.Body = new bpSaleReferenceIdRequestBody();
		bpSaleReferenceIdRequest2.Body.terminalId = terminalId;
		bpSaleReferenceIdRequest2.Body.userName = userName;
		bpSaleReferenceIdRequest2.Body.userPassword = userPassword;
		bpSaleReferenceIdRequest2.Body.orderId = orderId;
		bpSaleReferenceIdRequest2.Body.saleOrderId = saleOrderId;
		return ((IPaymentGateway)this).bpSaleReferenceIdRequestAsync(bpSaleReferenceIdRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundToPANRequestV2Response IPaymentGateway.bpRefundToPANRequestV2(bpRefundToPANRequestV2 request)
	{
		return base.Channel.bpRefundToPANRequestV2(request);
	}

	public string bpRefundToPANRequestV2(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, long orderId, string mobileNo)
	{
		bpRefundToPANRequestV2 bpRefundToPANRequestV3 = new bpRefundToPANRequestV2();
		bpRefundToPANRequestV3.Body = new bpRefundToPANRequestV2Body();
		bpRefundToPANRequestV3.Body.user = user;
		bpRefundToPANRequestV3.Body.password = password;
		bpRefundToPANRequestV3.Body.pan = pan;
		bpRefundToPANRequestV3.Body.amount = amount;
		bpRefundToPANRequestV3.Body.saleReferenceId = saleReferenceId;
		bpRefundToPANRequestV3.Body.terminalId = terminalId;
		bpRefundToPANRequestV3.Body.orderId = orderId;
		bpRefundToPANRequestV3.Body.mobileNo = mobileNo;
		return ((IPaymentGateway)this).bpRefundToPANRequestV2(bpRefundToPANRequestV3).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundToPANRequestV2Response> IPaymentGateway.bpRefundToPANRequestV2Async(bpRefundToPANRequestV2 request)
	{
		return base.Channel.bpRefundToPANRequestV2Async(request);
	}

	public Task<bpRefundToPANRequestV2Response> bpRefundToPANRequestV2Async(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, long orderId, string mobileNo)
	{
		bpRefundToPANRequestV2 bpRefundToPANRequestV3 = new bpRefundToPANRequestV2();
		bpRefundToPANRequestV3.Body = new bpRefundToPANRequestV2Body();
		bpRefundToPANRequestV3.Body.user = user;
		bpRefundToPANRequestV3.Body.password = password;
		bpRefundToPANRequestV3.Body.pan = pan;
		bpRefundToPANRequestV3.Body.amount = amount;
		bpRefundToPANRequestV3.Body.saleReferenceId = saleReferenceId;
		bpRefundToPANRequestV3.Body.terminalId = terminalId;
		bpRefundToPANRequestV3.Body.orderId = orderId;
		bpRefundToPANRequestV3.Body.mobileNo = mobileNo;
		return ((IPaymentGateway)this).bpRefundToPANRequestV2Async(bpRefundToPANRequestV3);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpDynamicPayRequestResponse IPaymentGateway.bpDynamicPayRequest(bpDynamicPayRequest request)
	{
		return base.Channel.bpDynamicPayRequest(request);
	}

	public string bpDynamicPayRequest(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId, long subServiceId, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpDynamicPayRequest bpDynamicPayRequest2 = new bpDynamicPayRequest();
		bpDynamicPayRequest2.Body = new bpDynamicPayRequestBody();
		bpDynamicPayRequest2.Body.terminalId = terminalId;
		bpDynamicPayRequest2.Body.userName = userName;
		bpDynamicPayRequest2.Body.userPassword = userPassword;
		bpDynamicPayRequest2.Body.orderId = orderId;
		bpDynamicPayRequest2.Body.amount = amount;
		bpDynamicPayRequest2.Body.localDate = localDate;
		bpDynamicPayRequest2.Body.localTime = localTime;
		bpDynamicPayRequest2.Body.additionalData = additionalData;
		bpDynamicPayRequest2.Body.callBackUrl = callBackUrl;
		bpDynamicPayRequest2.Body.payerId = payerId;
		bpDynamicPayRequest2.Body.subServiceId = subServiceId;
		bpDynamicPayRequest2.Body.mobileNo = mobileNo;
		bpDynamicPayRequest2.Body.encPan = encPan;
		bpDynamicPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpDynamicPayRequest2.Body.cartItem = cartItem;
		bpDynamicPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpDynamicPayRequest(bpDynamicPayRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpDynamicPayRequestResponse> IPaymentGateway.bpDynamicPayRequestAsync(bpDynamicPayRequest request)
	{
		return base.Channel.bpDynamicPayRequestAsync(request);
	}

	public Task<bpDynamicPayRequestResponse> bpDynamicPayRequestAsync(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId, long subServiceId, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpDynamicPayRequest bpDynamicPayRequest2 = new bpDynamicPayRequest();
		bpDynamicPayRequest2.Body = new bpDynamicPayRequestBody();
		bpDynamicPayRequest2.Body.terminalId = terminalId;
		bpDynamicPayRequest2.Body.userName = userName;
		bpDynamicPayRequest2.Body.userPassword = userPassword;
		bpDynamicPayRequest2.Body.orderId = orderId;
		bpDynamicPayRequest2.Body.amount = amount;
		bpDynamicPayRequest2.Body.localDate = localDate;
		bpDynamicPayRequest2.Body.localTime = localTime;
		bpDynamicPayRequest2.Body.additionalData = additionalData;
		bpDynamicPayRequest2.Body.callBackUrl = callBackUrl;
		bpDynamicPayRequest2.Body.payerId = payerId;
		bpDynamicPayRequest2.Body.subServiceId = subServiceId;
		bpDynamicPayRequest2.Body.mobileNo = mobileNo;
		bpDynamicPayRequest2.Body.encPan = encPan;
		bpDynamicPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpDynamicPayRequest2.Body.cartItem = cartItem;
		bpDynamicPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpDynamicPayRequestAsync(bpDynamicPayRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpInquiryRequestResponse IPaymentGateway.bpInquiryRequest(bpInquiryRequest request)
	{
		return base.Channel.bpInquiryRequest(request);
	}

	public string bpInquiryRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpInquiryRequest bpInquiryRequest2 = new bpInquiryRequest();
		bpInquiryRequest2.Body = new bpInquiryRequestBody();
		bpInquiryRequest2.Body.terminalId = terminalId;
		bpInquiryRequest2.Body.userName = userName;
		bpInquiryRequest2.Body.userPassword = userPassword;
		bpInquiryRequest2.Body.orderId = orderId;
		bpInquiryRequest2.Body.saleOrderId = saleOrderId;
		bpInquiryRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpInquiryRequest(bpInquiryRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpInquiryRequestResponse> IPaymentGateway.bpInquiryRequestAsync(bpInquiryRequest request)
	{
		return base.Channel.bpInquiryRequestAsync(request);
	}

	public Task<bpInquiryRequestResponse> bpInquiryRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpInquiryRequest bpInquiryRequest2 = new bpInquiryRequest();
		bpInquiryRequest2.Body = new bpInquiryRequestBody();
		bpInquiryRequest2.Body.terminalId = terminalId;
		bpInquiryRequest2.Body.userName = userName;
		bpInquiryRequest2.Body.userPassword = userPassword;
		bpInquiryRequest2.Body.orderId = orderId;
		bpInquiryRequest2.Body.saleOrderId = saleOrderId;
		bpInquiryRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpInquiryRequestAsync(bpInquiryRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpSettleRequestResponse IPaymentGateway.bpSettleRequest(bpSettleRequest request)
	{
		return base.Channel.bpSettleRequest(request);
	}

	public string bpSettleRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpSettleRequest bpSettleRequest2 = new bpSettleRequest();
		bpSettleRequest2.Body = new bpSettleRequestBody();
		bpSettleRequest2.Body.terminalId = terminalId;
		bpSettleRequest2.Body.userName = userName;
		bpSettleRequest2.Body.userPassword = userPassword;
		bpSettleRequest2.Body.orderId = orderId;
		bpSettleRequest2.Body.saleOrderId = saleOrderId;
		bpSettleRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpSettleRequest(bpSettleRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpSettleRequestResponse> IPaymentGateway.bpSettleRequestAsync(bpSettleRequest request)
	{
		return base.Channel.bpSettleRequestAsync(request);
	}

	public Task<bpSettleRequestResponse> bpSettleRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpSettleRequest bpSettleRequest2 = new bpSettleRequest();
		bpSettleRequest2.Body = new bpSettleRequestBody();
		bpSettleRequest2.Body.terminalId = terminalId;
		bpSettleRequest2.Body.userName = userName;
		bpSettleRequest2.Body.userPassword = userPassword;
		bpSettleRequest2.Body.orderId = orderId;
		bpSettleRequest2.Body.saleOrderId = saleOrderId;
		bpSettleRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpSettleRequestAsync(bpSettleRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpVerifySettleRequestResponse IPaymentGateway.bpVerifySettleRequest(bpVerifySettleRequest request)
	{
		return base.Channel.bpVerifySettleRequest(request);
	}

	public string bpVerifySettleRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpVerifySettleRequest bpVerifySettleRequest2 = new bpVerifySettleRequest();
		bpVerifySettleRequest2.Body = new bpVerifySettleRequestBody();
		bpVerifySettleRequest2.Body.terminalId = terminalId;
		bpVerifySettleRequest2.Body.userName = userName;
		bpVerifySettleRequest2.Body.userPassword = userPassword;
		bpVerifySettleRequest2.Body.orderId = orderId;
		bpVerifySettleRequest2.Body.saleOrderId = saleOrderId;
		bpVerifySettleRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpVerifySettleRequest(bpVerifySettleRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpVerifySettleRequestResponse> IPaymentGateway.bpVerifySettleRequestAsync(bpVerifySettleRequest request)
	{
		return base.Channel.bpVerifySettleRequestAsync(request);
	}

	public Task<bpVerifySettleRequestResponse> bpVerifySettleRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpVerifySettleRequest bpVerifySettleRequest2 = new bpVerifySettleRequest();
		bpVerifySettleRequest2.Body = new bpVerifySettleRequestBody();
		bpVerifySettleRequest2.Body.terminalId = terminalId;
		bpVerifySettleRequest2.Body.userName = userName;
		bpVerifySettleRequest2.Body.userPassword = userPassword;
		bpVerifySettleRequest2.Body.orderId = orderId;
		bpVerifySettleRequest2.Body.saleOrderId = saleOrderId;
		bpVerifySettleRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpVerifySettleRequestAsync(bpVerifySettleRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundRequestV2Response IPaymentGateway.bpRefundRequestV2(bpRefundRequestV2 request)
	{
		return base.Channel.bpRefundRequestV2(request);
	}

	public string bpRefundRequestV2(long terminalId, string userName, string userPassword, string destinationPan, string mobileNo, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		bpRefundRequestV2 bpRefundRequestV3 = new bpRefundRequestV2();
		bpRefundRequestV3.Body = new bpRefundRequestV2Body();
		bpRefundRequestV3.Body.terminalId = terminalId;
		bpRefundRequestV3.Body.userName = userName;
		bpRefundRequestV3.Body.userPassword = userPassword;
		bpRefundRequestV3.Body.destinationPan = destinationPan;
		bpRefundRequestV3.Body.mobileNo = mobileNo;
		bpRefundRequestV3.Body.orderId = orderId;
		bpRefundRequestV3.Body.saleOrderId = saleOrderId;
		bpRefundRequestV3.Body.saleReferenceId = saleReferenceId;
		bpRefundRequestV3.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpRefundRequestV2(bpRefundRequestV3).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundRequestV2Response> IPaymentGateway.bpRefundRequestV2Async(bpRefundRequestV2 request)
	{
		return base.Channel.bpRefundRequestV2Async(request);
	}

	public Task<bpRefundRequestV2Response> bpRefundRequestV2Async(long terminalId, string userName, string userPassword, string destinationPan, string mobileNo, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		bpRefundRequestV2 bpRefundRequestV3 = new bpRefundRequestV2();
		bpRefundRequestV3.Body = new bpRefundRequestV2Body();
		bpRefundRequestV3.Body.terminalId = terminalId;
		bpRefundRequestV3.Body.userName = userName;
		bpRefundRequestV3.Body.userPassword = userPassword;
		bpRefundRequestV3.Body.destinationPan = destinationPan;
		bpRefundRequestV3.Body.mobileNo = mobileNo;
		bpRefundRequestV3.Body.orderId = orderId;
		bpRefundRequestV3.Body.saleOrderId = saleOrderId;
		bpRefundRequestV3.Body.saleReferenceId = saleReferenceId;
		bpRefundRequestV3.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpRefundRequestV2Async(bpRefundRequestV3);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	sohResponse IPaymentGateway.soh(soh request)
	{
		return base.Channel.soh(request);
	}

	public bool soh()
	{
		soh request = new soh();
		return ((IPaymentGateway)this).soh(request).@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<sohResponse> IPaymentGateway.sohAsync(soh request)
	{
		return base.Channel.sohAsync(request);
	}

	public Task<sohResponse> sohAsync()
	{
		soh request = new soh();
		return ((IPaymentGateway)this).sohAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpChargePayRequestResponse IPaymentGateway.bpChargePayRequest(bpChargePayRequest request)
	{
		return base.Channel.bpChargePayRequest(request);
	}

	public string bpChargePayRequest(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId)
	{
		bpChargePayRequest bpChargePayRequest2 = new bpChargePayRequest();
		bpChargePayRequest2.Body = new bpChargePayRequestBody();
		bpChargePayRequest2.Body.terminalId = terminalId;
		bpChargePayRequest2.Body.userName = userName;
		bpChargePayRequest2.Body.userPassword = userPassword;
		bpChargePayRequest2.Body.orderId = orderId;
		bpChargePayRequest2.Body.amount = amount;
		bpChargePayRequest2.Body.localDate = localDate;
		bpChargePayRequest2.Body.localTime = localTime;
		bpChargePayRequest2.Body.additionalData = additionalData;
		bpChargePayRequest2.Body.callBackUrl = callBackUrl;
		bpChargePayRequest2.Body.payerId = payerId;
		return ((IPaymentGateway)this).bpChargePayRequest(bpChargePayRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpChargePayRequestResponse> IPaymentGateway.bpChargePayRequestAsync(bpChargePayRequest request)
	{
		return base.Channel.bpChargePayRequestAsync(request);
	}

	public Task<bpChargePayRequestResponse> bpChargePayRequestAsync(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId)
	{
		bpChargePayRequest bpChargePayRequest2 = new bpChargePayRequest();
		bpChargePayRequest2.Body = new bpChargePayRequestBody();
		bpChargePayRequest2.Body.terminalId = terminalId;
		bpChargePayRequest2.Body.userName = userName;
		bpChargePayRequest2.Body.userPassword = userPassword;
		bpChargePayRequest2.Body.orderId = orderId;
		bpChargePayRequest2.Body.amount = amount;
		bpChargePayRequest2.Body.localDate = localDate;
		bpChargePayRequest2.Body.localTime = localTime;
		bpChargePayRequest2.Body.additionalData = additionalData;
		bpChargePayRequest2.Body.callBackUrl = callBackUrl;
		bpChargePayRequest2.Body.payerId = payerId;
		return ((IPaymentGateway)this).bpChargePayRequestAsync(bpChargePayRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpCumulativeDynamicPayRequestResponse IPaymentGateway.bpCumulativeDynamicPayRequest(bpCumulativeDynamicPayRequest request)
	{
		return base.Channel.bpCumulativeDynamicPayRequest(request);
	}

	public string bpCumulativeDynamicPayRequest(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpCumulativeDynamicPayRequest bpCumulativeDynamicPayRequest2 = new bpCumulativeDynamicPayRequest();
		bpCumulativeDynamicPayRequest2.Body = new bpCumulativeDynamicPayRequestBody();
		bpCumulativeDynamicPayRequest2.Body.terminalId = terminalId;
		bpCumulativeDynamicPayRequest2.Body.userName = userName;
		bpCumulativeDynamicPayRequest2.Body.userPassword = userPassword;
		bpCumulativeDynamicPayRequest2.Body.orderId = orderId;
		bpCumulativeDynamicPayRequest2.Body.amount = amount;
		bpCumulativeDynamicPayRequest2.Body.localDate = localDate;
		bpCumulativeDynamicPayRequest2.Body.localTime = localTime;
		bpCumulativeDynamicPayRequest2.Body.additionalData = additionalData;
		bpCumulativeDynamicPayRequest2.Body.callBackUrl = callBackUrl;
		bpCumulativeDynamicPayRequest2.Body.mobileNo = mobileNo;
		bpCumulativeDynamicPayRequest2.Body.encPan = encPan;
		bpCumulativeDynamicPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpCumulativeDynamicPayRequest2.Body.cartItem = cartItem;
		bpCumulativeDynamicPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpCumulativeDynamicPayRequest(bpCumulativeDynamicPayRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpCumulativeDynamicPayRequestResponse> IPaymentGateway.bpCumulativeDynamicPayRequestAsync(bpCumulativeDynamicPayRequest request)
	{
		return base.Channel.bpCumulativeDynamicPayRequestAsync(request);
	}

	public Task<bpCumulativeDynamicPayRequestResponse> bpCumulativeDynamicPayRequestAsync(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpCumulativeDynamicPayRequest bpCumulativeDynamicPayRequest2 = new bpCumulativeDynamicPayRequest();
		bpCumulativeDynamicPayRequest2.Body = new bpCumulativeDynamicPayRequestBody();
		bpCumulativeDynamicPayRequest2.Body.terminalId = terminalId;
		bpCumulativeDynamicPayRequest2.Body.userName = userName;
		bpCumulativeDynamicPayRequest2.Body.userPassword = userPassword;
		bpCumulativeDynamicPayRequest2.Body.orderId = orderId;
		bpCumulativeDynamicPayRequest2.Body.amount = amount;
		bpCumulativeDynamicPayRequest2.Body.localDate = localDate;
		bpCumulativeDynamicPayRequest2.Body.localTime = localTime;
		bpCumulativeDynamicPayRequest2.Body.additionalData = additionalData;
		bpCumulativeDynamicPayRequest2.Body.callBackUrl = callBackUrl;
		bpCumulativeDynamicPayRequest2.Body.mobileNo = mobileNo;
		bpCumulativeDynamicPayRequest2.Body.encPan = encPan;
		bpCumulativeDynamicPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpCumulativeDynamicPayRequest2.Body.cartItem = cartItem;
		bpCumulativeDynamicPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpCumulativeDynamicPayRequestAsync(bpCumulativeDynamicPayRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpPayRequestResponse IPaymentGateway.bpPayRequest(bpPayRequest request)
	{
		return base.Channel.bpPayRequest(request);
	}

	public string bpPayRequest(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpPayRequest bpPayRequest2 = new bpPayRequest();
		bpPayRequest2.Body = new bpPayRequestBody();
		bpPayRequest2.Body.terminalId = terminalId;
		bpPayRequest2.Body.userName = userName;
		bpPayRequest2.Body.userPassword = userPassword;
		bpPayRequest2.Body.orderId = orderId;
		bpPayRequest2.Body.amount = amount;
		bpPayRequest2.Body.localDate = localDate;
		bpPayRequest2.Body.localTime = localTime;
		bpPayRequest2.Body.additionalData = additionalData;
		bpPayRequest2.Body.callBackUrl = callBackUrl;
		bpPayRequest2.Body.payerId = payerId;
		bpPayRequest2.Body.mobileNo = mobileNo;
		bpPayRequest2.Body.encPan = encPan;
		bpPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpPayRequest2.Body.cartItem = cartItem;
		bpPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpPayRequest(bpPayRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpPayRequestResponse> IPaymentGateway.bpPayRequestAsync(bpPayRequest request)
	{
		return base.Channel.bpPayRequestAsync(request);
	}

	public Task<bpPayRequestResponse> bpPayRequestAsync(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId, string mobileNo, string encPan, string panHiddenMode, string cartItem, string enc)
	{
		bpPayRequest bpPayRequest2 = new bpPayRequest();
		bpPayRequest2.Body = new bpPayRequestBody();
		bpPayRequest2.Body.terminalId = terminalId;
		bpPayRequest2.Body.userName = userName;
		bpPayRequest2.Body.userPassword = userPassword;
		bpPayRequest2.Body.orderId = orderId;
		bpPayRequest2.Body.amount = amount;
		bpPayRequest2.Body.localDate = localDate;
		bpPayRequest2.Body.localTime = localTime;
		bpPayRequest2.Body.additionalData = additionalData;
		bpPayRequest2.Body.callBackUrl = callBackUrl;
		bpPayRequest2.Body.payerId = payerId;
		bpPayRequest2.Body.mobileNo = mobileNo;
		bpPayRequest2.Body.encPan = encPan;
		bpPayRequest2.Body.panHiddenMode = panHiddenMode;
		bpPayRequest2.Body.cartItem = cartItem;
		bpPayRequest2.Body.enc = enc;
		return ((IPaymentGateway)this).bpPayRequestAsync(bpPayRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundInquiryRequestResponse IPaymentGateway.bpRefundInquiryRequest(bpRefundInquiryRequest request)
	{
		return base.Channel.bpRefundInquiryRequest(request);
	}

	public string bpRefundInquiryRequest(long terminalId, string userName, string userPassword, long orderId, long refundOrderId, long refundReferenceId)
	{
		bpRefundInquiryRequest bpRefundInquiryRequest2 = new bpRefundInquiryRequest();
		bpRefundInquiryRequest2.Body = new bpRefundInquiryRequestBody();
		bpRefundInquiryRequest2.Body.terminalId = terminalId;
		bpRefundInquiryRequest2.Body.userName = userName;
		bpRefundInquiryRequest2.Body.userPassword = userPassword;
		bpRefundInquiryRequest2.Body.orderId = orderId;
		bpRefundInquiryRequest2.Body.refundOrderId = refundOrderId;
		bpRefundInquiryRequest2.Body.refundReferenceId = refundReferenceId;
		return ((IPaymentGateway)this).bpRefundInquiryRequest(bpRefundInquiryRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundInquiryRequestResponse> IPaymentGateway.bpRefundInquiryRequestAsync(bpRefundInquiryRequest request)
	{
		return base.Channel.bpRefundInquiryRequestAsync(request);
	}

	public Task<bpRefundInquiryRequestResponse> bpRefundInquiryRequestAsync(long terminalId, string userName, string userPassword, long orderId, long refundOrderId, long refundReferenceId)
	{
		bpRefundInquiryRequest bpRefundInquiryRequest2 = new bpRefundInquiryRequest();
		bpRefundInquiryRequest2.Body = new bpRefundInquiryRequestBody();
		bpRefundInquiryRequest2.Body.terminalId = terminalId;
		bpRefundInquiryRequest2.Body.userName = userName;
		bpRefundInquiryRequest2.Body.userPassword = userPassword;
		bpRefundInquiryRequest2.Body.orderId = orderId;
		bpRefundInquiryRequest2.Body.refundOrderId = refundOrderId;
		bpRefundInquiryRequest2.Body.refundReferenceId = refundReferenceId;
		return ((IPaymentGateway)this).bpRefundInquiryRequestAsync(bpRefundInquiryRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpReversalRequestResponse IPaymentGateway.bpReversalRequest(bpReversalRequest request)
	{
		return base.Channel.bpReversalRequest(request);
	}

	public string bpReversalRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpReversalRequest bpReversalRequest2 = new bpReversalRequest();
		bpReversalRequest2.Body = new bpReversalRequestBody();
		bpReversalRequest2.Body.terminalId = terminalId;
		bpReversalRequest2.Body.userName = userName;
		bpReversalRequest2.Body.userPassword = userPassword;
		bpReversalRequest2.Body.orderId = orderId;
		bpReversalRequest2.Body.saleOrderId = saleOrderId;
		bpReversalRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpReversalRequest(bpReversalRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpReversalRequestResponse> IPaymentGateway.bpReversalRequestAsync(bpReversalRequest request)
	{
		return base.Channel.bpReversalRequestAsync(request);
	}

	public Task<bpReversalRequestResponse> bpReversalRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpReversalRequest bpReversalRequest2 = new bpReversalRequest();
		bpReversalRequest2.Body = new bpReversalRequestBody();
		bpReversalRequest2.Body.terminalId = terminalId;
		bpReversalRequest2.Body.userName = userName;
		bpReversalRequest2.Body.userPassword = userPassword;
		bpReversalRequest2.Body.orderId = orderId;
		bpReversalRequest2.Body.saleOrderId = saleOrderId;
		bpReversalRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpReversalRequestAsync(bpReversalRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpPosRefundRequestResponse IPaymentGateway.bpPosRefundRequest(bpPosRefundRequest request)
	{
		return base.Channel.bpPosRefundRequest(request);
	}

	public string bpPosRefundRequest(string user, string password, long saleReferenceId, long refundAmount)
	{
		bpPosRefundRequest bpPosRefundRequest2 = new bpPosRefundRequest();
		bpPosRefundRequest2.Body = new bpPosRefundRequestBody();
		bpPosRefundRequest2.Body.user = user;
		bpPosRefundRequest2.Body.password = password;
		bpPosRefundRequest2.Body.saleReferenceId = saleReferenceId;
		bpPosRefundRequest2.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpPosRefundRequest(bpPosRefundRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpPosRefundRequestResponse> IPaymentGateway.bpPosRefundRequestAsync(bpPosRefundRequest request)
	{
		return base.Channel.bpPosRefundRequestAsync(request);
	}

	public Task<bpPosRefundRequestResponse> bpPosRefundRequestAsync(string user, string password, long saleReferenceId, long refundAmount)
	{
		bpPosRefundRequest bpPosRefundRequest2 = new bpPosRefundRequest();
		bpPosRefundRequest2.Body = new bpPosRefundRequestBody();
		bpPosRefundRequest2.Body.user = user;
		bpPosRefundRequest2.Body.password = password;
		bpPosRefundRequest2.Body.saleReferenceId = saleReferenceId;
		bpPosRefundRequest2.Body.refundAmount = refundAmount;
		return ((IPaymentGateway)this).bpPosRefundRequestAsync(bpPosRefundRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundToPANRequestResponse IPaymentGateway.bpRefundToPANRequest(bpRefundToPANRequest request)
	{
		return base.Channel.bpRefundToPANRequest(request);
	}

	public string bpRefundToPANRequest(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, string mobileNo, long orderId)
	{
		bpRefundToPANRequest bpRefundToPANRequest2 = new bpRefundToPANRequest();
		bpRefundToPANRequest2.Body = new bpRefundToPANRequestBody();
		bpRefundToPANRequest2.Body.user = user;
		bpRefundToPANRequest2.Body.password = password;
		bpRefundToPANRequest2.Body.pan = pan;
		bpRefundToPANRequest2.Body.amount = amount;
		bpRefundToPANRequest2.Body.saleReferenceId = saleReferenceId;
		bpRefundToPANRequest2.Body.terminalId = terminalId;
		bpRefundToPANRequest2.Body.mobileNo = mobileNo;
		bpRefundToPANRequest2.Body.orderId = orderId;
		return ((IPaymentGateway)this).bpRefundToPANRequest(bpRefundToPANRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundToPANRequestResponse> IPaymentGateway.bpRefundToPANRequestAsync(bpRefundToPANRequest request)
	{
		return base.Channel.bpRefundToPANRequestAsync(request);
	}

	public Task<bpRefundToPANRequestResponse> bpRefundToPANRequestAsync(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, string mobileNo, long orderId)
	{
		bpRefundToPANRequest bpRefundToPANRequest2 = new bpRefundToPANRequest();
		bpRefundToPANRequest2.Body = new bpRefundToPANRequestBody();
		bpRefundToPANRequest2.Body.user = user;
		bpRefundToPANRequest2.Body.password = password;
		bpRefundToPANRequest2.Body.pan = pan;
		bpRefundToPANRequest2.Body.amount = amount;
		bpRefundToPANRequest2.Body.saleReferenceId = saleReferenceId;
		bpRefundToPANRequest2.Body.terminalId = terminalId;
		bpRefundToPANRequest2.Body.mobileNo = mobileNo;
		bpRefundToPANRequest2.Body.orderId = orderId;
		return ((IPaymentGateway)this).bpRefundToPANRequestAsync(bpRefundToPANRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpVerifyRequestResponse IPaymentGateway.bpVerifyRequest(bpVerifyRequest request)
	{
		return base.Channel.bpVerifyRequest(request);
	}

	public string bpVerifyRequest(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpVerifyRequest bpVerifyRequest2 = new bpVerifyRequest();
		bpVerifyRequest2.Body = new bpVerifyRequestBody();
		bpVerifyRequest2.Body.terminalId = terminalId;
		bpVerifyRequest2.Body.userName = userName;
		bpVerifyRequest2.Body.userPassword = userPassword;
		bpVerifyRequest2.Body.orderId = orderId;
		bpVerifyRequest2.Body.saleOrderId = saleOrderId;
		bpVerifyRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpVerifyRequest(bpVerifyRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpVerifyRequestResponse> IPaymentGateway.bpVerifyRequestAsync(bpVerifyRequest request)
	{
		return base.Channel.bpVerifyRequestAsync(request);
	}

	public Task<bpVerifyRequestResponse> bpVerifyRequestAsync(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId)
	{
		bpVerifyRequest bpVerifyRequest2 = new bpVerifyRequest();
		bpVerifyRequest2.Body = new bpVerifyRequestBody();
		bpVerifyRequest2.Body.terminalId = terminalId;
		bpVerifyRequest2.Body.userName = userName;
		bpVerifyRequest2.Body.userPassword = userPassword;
		bpVerifyRequest2.Body.orderId = orderId;
		bpVerifyRequest2.Body.saleOrderId = saleOrderId;
		bpVerifyRequest2.Body.saleReferenceId = saleReferenceId;
		return ((IPaymentGateway)this).bpVerifyRequestAsync(bpVerifyRequest2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bpRefundVerifyRequestResponse IPaymentGateway.bpRefundVerifyRequest(bpRefundVerifyRequest request)
	{
		return base.Channel.bpRefundVerifyRequest(request);
	}

	public string bpRefundVerifyRequest(long terminalId, string userName, string userPassword, long orderId, long refundOrderId, long refundReferenceId)
	{
		bpRefundVerifyRequest bpRefundVerifyRequest2 = new bpRefundVerifyRequest();
		bpRefundVerifyRequest2.Body = new bpRefundVerifyRequestBody();
		bpRefundVerifyRequest2.Body.terminalId = terminalId;
		bpRefundVerifyRequest2.Body.userName = userName;
		bpRefundVerifyRequest2.Body.userPassword = userPassword;
		bpRefundVerifyRequest2.Body.orderId = orderId;
		bpRefundVerifyRequest2.Body.refundOrderId = refundOrderId;
		bpRefundVerifyRequest2.Body.refundReferenceId = refundReferenceId;
		return ((IPaymentGateway)this).bpRefundVerifyRequest(bpRefundVerifyRequest2).Body.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bpRefundVerifyRequestResponse> IPaymentGateway.bpRefundVerifyRequestAsync(bpRefundVerifyRequest request)
	{
		return base.Channel.bpRefundVerifyRequestAsync(request);
	}

	public Task<bpRefundVerifyRequestResponse> bpRefundVerifyRequestAsync(long terminalId, string userName, string userPassword, long orderId, long refundOrderId, long refundReferenceId)
	{
		bpRefundVerifyRequest bpRefundVerifyRequest2 = new bpRefundVerifyRequest();
		bpRefundVerifyRequest2.Body = new bpRefundVerifyRequestBody();
		bpRefundVerifyRequest2.Body.terminalId = terminalId;
		bpRefundVerifyRequest2.Body.userName = userName;
		bpRefundVerifyRequest2.Body.userPassword = userPassword;
		bpRefundVerifyRequest2.Body.orderId = orderId;
		bpRefundVerifyRequest2.Body.refundOrderId = refundOrderId;
		bpRefundVerifyRequest2.Body.refundReferenceId = refundReferenceId;
		return ((IPaymentGateway)this).bpRefundVerifyRequestAsync(bpRefundVerifyRequest2);
	}
}
