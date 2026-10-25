using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertDaryaftResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertDaryaftResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertDaryaftResponseBody Body;

	public Idealsp_InsertDaryaftResponse()
	{
	}

	public Idealsp_InsertDaryaftResponse(Idealsp_InsertDaryaftResponseBody Body)
	{
		this.Body = Body;
	}
}
