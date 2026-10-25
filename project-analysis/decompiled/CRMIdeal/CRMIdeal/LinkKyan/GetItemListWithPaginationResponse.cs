using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithPaginationResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithPaginationResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitmWithRowNo GetItemListWithPaginationResult;

	public GetItemListWithPaginationResponse()
	{
	}

	public GetItemListWithPaginationResponse(ResponseDataOfitmWithRowNo GetItemListWithPaginationResult)
	{
		this.GetItemListWithPaginationResult = GetItemListWithPaginationResult;
	}
}
