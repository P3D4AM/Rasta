using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTaxChargeAmountResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTaxChargeAmountResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfConfigEntity GetTaxChargeAmountResult;

	public GetTaxChargeAmountResponse()
	{
	}

	public GetTaxChargeAmountResponse(ResponseDataOfConfigEntity GetTaxChargeAmountResult)
	{
		this.GetTaxChargeAmountResult = GetTaxChargeAmountResult;
	}
}
