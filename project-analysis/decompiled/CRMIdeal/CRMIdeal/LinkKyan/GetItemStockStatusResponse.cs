using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemStockStatusResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemStockStatusResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfLoanItemStock GetItemStockStatusResult;

	public GetItemStockStatusResponse()
	{
	}

	public GetItemStockStatusResponse(ResponseDataOfLoanItemStock GetItemStockStatusResult)
	{
		this.GetItemStockStatusResult = GetItemStockStatusResult;
	}
}
