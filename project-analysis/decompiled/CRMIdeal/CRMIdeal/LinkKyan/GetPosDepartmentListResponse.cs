using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetPosDepartmentListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetPosDepartmentListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfPosDepartment GetPosDepartmentListResult;

	public GetPosDepartmentListResponse()
	{
	}

	public GetPosDepartmentListResponse(ResponseDataOfPosDepartment GetPosDepartmentListResult)
	{
		this.GetPosDepartmentListResult = GetPosDepartmentListResult;
	}
}
