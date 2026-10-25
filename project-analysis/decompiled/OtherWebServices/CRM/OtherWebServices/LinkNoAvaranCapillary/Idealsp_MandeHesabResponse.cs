using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_MandeHesabResponse
{
	[MessageBodyMember(Name = "Idealsp_MandeHesabResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_MandeHesabResponseBody Body;

	public Idealsp_MandeHesabResponse()
	{
	}

	public Idealsp_MandeHesabResponse(Idealsp_MandeHesabResponseBody Body)
	{
		this.Body = Body;
	}
}
