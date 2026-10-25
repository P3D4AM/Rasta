using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPishFactorRequest
{
	[MessageBodyMember(Name = "ReadFromPishFactor", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPishFactorRequestBody Body;

	public ReadFromPishFactorRequest()
	{
	}

	public ReadFromPishFactorRequest(ReadFromPishFactorRequestBody Body)
	{
		this.Body = Body;
	}
}
