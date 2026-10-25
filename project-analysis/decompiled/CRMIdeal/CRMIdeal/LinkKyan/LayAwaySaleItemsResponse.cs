using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "LayAwaySaleItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class LayAwaySaleItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString LayAwaySaleItemsResult;

	public LayAwaySaleItemsResponse()
	{
	}

	public LayAwaySaleItemsResponse(ResponseDataOfString LayAwaySaleItemsResult)
	{
		this.LayAwaySaleItemsResult = LayAwaySaleItemsResult;
	}
}
