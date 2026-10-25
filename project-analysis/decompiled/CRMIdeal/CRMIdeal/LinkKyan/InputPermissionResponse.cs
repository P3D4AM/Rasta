using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "InputPermissionResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class InputPermissionResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public Result InputPermissionResult;

	public InputPermissionResponse()
	{
	}

	public InputPermissionResponse(Result InputPermissionResult)
	{
		this.InputPermissionResult = InputPermissionResult;
	}
}
