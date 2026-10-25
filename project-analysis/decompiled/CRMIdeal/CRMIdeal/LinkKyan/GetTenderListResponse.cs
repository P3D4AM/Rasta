using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTenderListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTenderListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfTenderModel GetTenderListResult;

	public GetTenderListResponse()
	{
	}

	public GetTenderListResponse(ResponseDataOfTenderModel GetTenderListResult)
	{
		this.GetTenderListResult = GetTenderListResult;
	}
}
