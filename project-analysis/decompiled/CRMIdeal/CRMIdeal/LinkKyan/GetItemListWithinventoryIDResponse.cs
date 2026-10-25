using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithinventoryIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithinventoryIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm GetItemListWithinventoryIDResult;

	public GetItemListWithinventoryIDResponse()
	{
	}

	public GetItemListWithinventoryIDResponse(ResponseDataOfitm GetItemListWithinventoryIDResult)
	{
		this.GetItemListWithinventoryIDResult = GetItemListWithinventoryIDResult;
	}
}
