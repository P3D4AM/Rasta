using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetGeneralItemInfoPlusResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetGeneralItemInfoPlusResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfGeneralItemInfoPlusModel GetGeneralItemInfoPlusResult;

	public GetGeneralItemInfoPlusResponse()
	{
	}

	public GetGeneralItemInfoPlusResponse(ResponseDataOfGeneralItemInfoPlusModel GetGeneralItemInfoPlusResult)
	{
		this.GetGeneralItemInfoPlusResult = GetGeneralItemInfoPlusResult;
	}
}
