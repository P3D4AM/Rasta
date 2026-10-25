using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromFactorRequest
{
	[MessageBodyMember(Name = "ReadFromFactor", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromFactorRequestBody Body;

	public ReadFromFactorRequest()
	{
	}

	public ReadFromFactorRequest(ReadFromFactorRequestBody Body)
	{
		this.Body = Body;
	}
}
