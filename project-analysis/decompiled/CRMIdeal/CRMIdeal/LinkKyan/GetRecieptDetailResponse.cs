using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetRecieptDetailResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetRecieptDetailResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfRecieptsDetail GetRecieptDetailResult;

	public GetRecieptDetailResponse()
	{
	}

	public GetRecieptDetailResponse(ResponseDataOfRecieptsDetail GetRecieptDetailResult)
	{
		this.GetRecieptDetailResult = GetRecieptDetailResult;
	}
}
