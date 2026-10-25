using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertPishFactorResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertPishFactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertPishFactorResponseBody Body;

	public Idealsp_InsertPishFactorResponse()
	{
	}

	public Idealsp_InsertPishFactorResponse(Idealsp_InsertPishFactorResponseBody Body)
	{
		this.Body = Body;
	}
}
