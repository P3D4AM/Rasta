using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithGroupIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithGroupIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm GetItemInfoWithGroupIDResult;

	public GetItemInfoWithGroupIDResponse()
	{
	}

	public GetItemInfoWithGroupIDResponse(ResponseDataOfitm GetItemInfoWithGroupIDResult)
	{
		this.GetItemInfoWithGroupIDResult = GetItemInfoWithGroupIDResult;
	}
}
