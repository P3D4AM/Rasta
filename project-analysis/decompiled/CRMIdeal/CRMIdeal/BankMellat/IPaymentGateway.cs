using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.BankMellat;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "http://interfaces.core.sw.bps.com/", ConfigurationName = "BankMellat.IPaymentGateway")]
public interface IPaymentGateway
{
	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundRequestResponse bpRefundRequest(bpRefundRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundRequestResponse> bpRefundRequestAsync(bpRefundRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpSaleReferenceIdRequestResponse bpSaleReferenceIdRequest(bpSaleReferenceIdRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpSaleReferenceIdRequestResponse> bpSaleReferenceIdRequestAsync(bpSaleReferenceIdRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundToPANRequestV2Response bpRefundToPANRequestV2(bpRefundToPANRequestV2 request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundToPANRequestV2Response> bpRefundToPANRequestV2Async(bpRefundToPANRequestV2 request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpDynamicPayRequestResponse bpDynamicPayRequest(bpDynamicPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpDynamicPayRequestResponse> bpDynamicPayRequestAsync(bpDynamicPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpInquiryRequestResponse bpInquiryRequest(bpInquiryRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpInquiryRequestResponse> bpInquiryRequestAsync(bpInquiryRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpSettleRequestResponse bpSettleRequest(bpSettleRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpSettleRequestResponse> bpSettleRequestAsync(bpSettleRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpVerifySettleRequestResponse bpVerifySettleRequest(bpVerifySettleRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpVerifySettleRequestResponse> bpVerifySettleRequestAsync(bpVerifySettleRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundRequestV2Response bpRefundRequestV2(bpRefundRequestV2 request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundRequestV2Response> bpRefundRequestV2Async(bpRefundRequestV2 request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[return: MessageParameter(Name = "return")]
	sohResponse soh(soh request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<sohResponse> sohAsync(soh request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpChargePayRequestResponse bpChargePayRequest(bpChargePayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpChargePayRequestResponse> bpChargePayRequestAsync(bpChargePayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpCumulativeDynamicPayRequestResponse bpCumulativeDynamicPayRequest(bpCumulativeDynamicPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpCumulativeDynamicPayRequestResponse> bpCumulativeDynamicPayRequestAsync(bpCumulativeDynamicPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpPayRequestResponse bpPayRequest(bpPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpPayRequestResponse> bpPayRequestAsync(bpPayRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundInquiryRequestResponse bpRefundInquiryRequest(bpRefundInquiryRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundInquiryRequestResponse> bpRefundInquiryRequestAsync(bpRefundInquiryRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpReversalRequestResponse bpReversalRequest(bpReversalRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpReversalRequestResponse> bpReversalRequestAsync(bpReversalRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpPosRefundRequestResponse bpPosRefundRequest(bpPosRefundRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpPosRefundRequestResponse> bpPosRefundRequestAsync(bpPosRefundRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundToPANRequestResponse bpRefundToPANRequest(bpRefundToPANRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundToPANRequestResponse> bpRefundToPANRequestAsync(bpRefundToPANRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpVerifyRequestResponse bpVerifyRequest(bpVerifyRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpVerifyRequestResponse> bpVerifyRequestAsync(bpVerifyRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	bpRefundVerifyRequestResponse bpRefundVerifyRequest(bpRefundVerifyRequest request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bpRefundVerifyRequestResponse> bpRefundVerifyRequestAsync(bpRefundVerifyRequest request);
}
