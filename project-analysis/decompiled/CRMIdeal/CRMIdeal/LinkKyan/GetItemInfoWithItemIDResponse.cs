using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithItemIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithItemIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm GetItemInfoWithItemIDResult;

	public GetItemInfoWithItemIDResponse()
	{
	}

	public GetItemInfoWithItemIDResponse(ResponseDataOfitm GetItemInfoWithItemIDResult)
	{
		this.GetItemInfoWithItemIDResult = GetItemInfoWithItemIDResult;
	}
}
