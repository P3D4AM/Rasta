using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ReturnItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ReturnItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString ReturnItemsResult;

	public ReturnItemsResponse()
	{
	}

	public ReturnItemsResponse(ResponseDataOfString ReturnItemsResult)
	{
		this.ReturnItemsResult = ReturnItemsResult;
	}
}
