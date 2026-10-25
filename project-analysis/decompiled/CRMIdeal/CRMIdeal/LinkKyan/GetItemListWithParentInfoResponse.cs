using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithParentInfoResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithParentInfoResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitmWithParentInfo GetItemListWithParentInfoResult;

	public GetItemListWithParentInfoResponse()
	{
	}

	public GetItemListWithParentInfoResponse(ResponseDataOfitmWithParentInfo GetItemListWithParentInfoResult)
	{
		this.GetItemListWithParentInfoResult = GetItemListWithParentInfoResult;
	}
}
