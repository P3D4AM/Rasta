using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankParsian;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class SalePaymentWithIdRequest
{
	[MessageBodyMember(Name = "SalePaymentWithId", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService", Order = 0)]
	public SalePaymentWithIdRequestBody Body;

	public SalePaymentWithIdRequest()
	{
	}

	public SalePaymentWithIdRequest(SalePaymentWithIdRequestBody Body)
	{
		this.Body = Body;
	}
}
