using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.BankParsian;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService", ConfigurationName = "BankParsian.SaleServiceSoap")]
public interface SaleServiceSoap
{
	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentRequest", ReplyAction = "*")]
	SalePaymentRequestResponse SalePaymentRequest(SalePaymentRequestRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentRequest", ReplyAction = "*")]
	Task<SalePaymentRequestResponse> SalePaymentRequestAsync(SalePaymentRequestRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentWithId", ReplyAction = "*")]
	SalePaymentWithIdResponse SalePaymentWithId(SalePaymentWithIdRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentWithId", ReplyAction = "*")]
	Task<SalePaymentWithIdResponse> SalePaymentWithIdAsync(SalePaymentWithIdRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/UDSalePaymentRequest", ReplyAction = "*")]
	UDSalePaymentRequestResponse UDSalePaymentRequest(UDSalePaymentRequestRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/UDSalePaymentRequest", ReplyAction = "*")]
	Task<UDSalePaymentRequestResponse> UDSalePaymentRequestAsync(UDSalePaymentRequestRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentWithDiscount", ReplyAction = "*")]
	SalePaymentWithDiscountResponse SalePaymentWithDiscount(SalePaymentWithDiscountRequest request);

	[OperationContract(Action = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService/SalePaymentWithDiscount", ReplyAction = "*")]
	Task<SalePaymentWithDiscountResponse> SalePaymentWithDiscountAsync(SalePaymentWithDiscountRequest request);
}
