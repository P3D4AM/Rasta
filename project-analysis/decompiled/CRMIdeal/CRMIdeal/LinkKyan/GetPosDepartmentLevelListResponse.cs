using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetPosDepartmentLevelListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetPosDepartmentLevelListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfPosDepartmentList GetPosDepartmentLevelListResult;

	public GetPosDepartmentLevelListResponse()
	{
	}

	public GetPosDepartmentLevelListResponse(ResponseDataOfPosDepartmentList GetPosDepartmentLevelListResult)
	{
		this.GetPosDepartmentLevelListResult = GetPosDepartmentLevelListResult;
	}
}
