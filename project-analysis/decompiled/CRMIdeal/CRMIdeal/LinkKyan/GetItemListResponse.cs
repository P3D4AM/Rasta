using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm GetItemListResult;

	public GetItemListResponse()
	{
	}

	public GetItemListResponse(ResponseDataOfitm GetItemListResult)
	{
		this.GetItemListResult = GetItemListResult;
	}
}
