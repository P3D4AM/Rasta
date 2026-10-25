using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_LastResidnoRequest
{
	[MessageBodyMember(Name = "Idealsp_LastResidno", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_LastResidnoRequestBody Body;

	public Idealsp_LastResidnoRequest()
	{
	}

	public Idealsp_LastResidnoRequest(Idealsp_LastResidnoRequestBody Body)
	{
		this.Body = Body;
	}
}
