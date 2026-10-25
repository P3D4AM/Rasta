using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "checkReceiveResponse", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class checkReceiveResponse
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string result;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public string status;

	public checkReceiveResponse()
	{
	}

	public checkReceiveResponse(string result, string status)
	{
		this.result = result;
		this.status = status;
	}
}
