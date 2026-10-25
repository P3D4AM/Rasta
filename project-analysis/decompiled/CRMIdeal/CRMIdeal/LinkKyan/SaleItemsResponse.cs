using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SaleItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SaleItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString SaleItemsResult;

	public SaleItemsResponse()
	{
	}

	public SaleItemsResponse(ResponseDataOfString SaleItemsResult)
	{
		this.SaleItemsResult = SaleItemsResult;
	}
}
