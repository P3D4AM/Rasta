using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromFactorResponse
{
	[MessageBodyMember(Name = "ReadFromFactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromFactorResponseBody Body;

	public ReadFromFactorResponse()
	{
	}

	public ReadFromFactorResponse(ReadFromFactorResponseBody Body)
	{
		this.Body = Body;
	}
}
