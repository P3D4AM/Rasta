using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPishFactorResponse
{
	[MessageBodyMember(Name = "ReadFromPishFactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPishFactorResponseBody Body;

	public ReadFromPishFactorResponse()
	{
	}

	public ReadFromPishFactorResponse(ReadFromPishFactorResponseBody Body)
	{
		this.Body = Body;
	}
}
