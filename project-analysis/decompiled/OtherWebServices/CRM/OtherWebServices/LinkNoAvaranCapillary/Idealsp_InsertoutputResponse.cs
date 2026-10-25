using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertoutputResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertoutputResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertoutputResponseBody Body;

	public Idealsp_InsertoutputResponse()
	{
	}

	public Idealsp_InsertoutputResponse(Idealsp_InsertoutputResponseBody Body)
	{
		this.Body = Body;
	}
}
