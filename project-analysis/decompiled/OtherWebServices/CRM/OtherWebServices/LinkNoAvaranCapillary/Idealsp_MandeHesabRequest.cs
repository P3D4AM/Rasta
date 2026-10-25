using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_MandeHesabRequest
{
	[MessageBodyMember(Name = "Idealsp_MandeHesab", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_MandeHesabRequestBody Body;

	public Idealsp_MandeHesabRequest()
	{
	}

	public Idealsp_MandeHesabRequest(Idealsp_MandeHesabRequestBody Body)
	{
		this.Body = Body;
	}
}
