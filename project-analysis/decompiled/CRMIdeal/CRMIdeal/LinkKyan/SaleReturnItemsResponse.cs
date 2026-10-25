using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SaleReturnItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SaleReturnItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString SaleReturnItemsResult;

	public SaleReturnItemsResponse()
	{
	}

	public SaleReturnItemsResponse(ResponseDataOfString SaleReturnItemsResult)
	{
		this.SaleReturnItemsResult = SaleReturnItemsResult;
	}
}
