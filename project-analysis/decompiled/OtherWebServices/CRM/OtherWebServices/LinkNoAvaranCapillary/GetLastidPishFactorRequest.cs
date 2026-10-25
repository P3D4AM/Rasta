using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetLastidPishFactorRequest
{
	[MessageBodyMember(Name = "GetLastidPishFactor", Namespace = "http://tempuri.org/", Order = 0)]
	public GetLastidPishFactorRequestBody Body;

	public GetLastidPishFactorRequest()
	{
	}

	public GetLastidPishFactorRequest(GetLastidPishFactorRequestBody Body)
	{
		this.Body = Body;
	}
}
