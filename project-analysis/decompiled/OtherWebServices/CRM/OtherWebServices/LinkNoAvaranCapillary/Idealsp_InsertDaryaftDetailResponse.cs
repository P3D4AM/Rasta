using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertDaryaftDetailResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertDaryaftDetailResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertDaryaftDetailResponseBody Body;

	public Idealsp_InsertDaryaftDetailResponse()
	{
	}

	public Idealsp_InsertDaryaftDetailResponse(Idealsp_InsertDaryaftDetailResponseBody Body)
	{
		this.Body = Body;
	}
}
