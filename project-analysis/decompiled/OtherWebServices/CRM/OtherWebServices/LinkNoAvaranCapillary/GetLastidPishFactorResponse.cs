using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetLastidPishFactorResponse
{
	[MessageBodyMember(Name = "GetLastidPishFactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetLastidPishFactorResponseBody Body;

	public GetLastidPishFactorResponse()
	{
	}

	public GetLastidPishFactorResponse(GetLastidPishFactorResponseBody Body)
	{
		this.Body = Body;
	}
}
