using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerGroupResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerGroupResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfcustomerGroup GetCustomerGroupResult;

	public GetCustomerGroupResponse()
	{
	}

	public GetCustomerGroupResponse(ResponseDataOfcustomerGroup GetCustomerGroupResult)
	{
		this.GetCustomerGroupResult = GetCustomerGroupResult;
	}
}
