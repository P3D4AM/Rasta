using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPish_FactorResponse
{
	[MessageBodyMember(Name = "ReadFromPish_FactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPish_FactorResponseBody Body;

	public ReadFromPish_FactorResponse()
	{
	}

	public ReadFromPish_FactorResponse(ReadFromPish_FactorResponseBody Body)
	{
		this.Body = Body;
	}
}
