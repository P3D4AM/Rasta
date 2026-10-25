using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_LastResidnoResponse
{
	[MessageBodyMember(Name = "Idealsp_LastResidnoResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_LastResidnoResponseBody Body;

	public Idealsp_LastResidnoResponse()
	{
	}

	public Idealsp_LastResidnoResponse(Idealsp_LastResidnoResponseBody Body)
	{
		this.Body = Body;
	}
}
