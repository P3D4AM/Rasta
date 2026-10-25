using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithinventoryIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithinventoryIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm3 GetItemInfoWithinventoryIDResult;

	public GetItemInfoWithinventoryIDResponse()
	{
	}

	public GetItemInfoWithinventoryIDResponse(ResponseDataOfitm3 GetItemInfoWithinventoryIDResult)
	{
		this.GetItemInfoWithinventoryIDResult = GetItemInfoWithinventoryIDResult;
	}
}
