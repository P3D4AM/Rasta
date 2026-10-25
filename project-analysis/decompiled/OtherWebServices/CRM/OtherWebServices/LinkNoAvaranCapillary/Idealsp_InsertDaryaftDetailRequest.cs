using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertDaryaftDetailRequest
{
	[MessageBodyMember(Name = "Idealsp_InsertDaryaftDetail", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertDaryaftDetailRequestBody Body;

	public Idealsp_InsertDaryaftDetailRequest()
	{
	}

	public Idealsp_InsertDaryaftDetailRequest(Idealsp_InsertDaryaftDetailRequestBody Body)
	{
		this.Body = Body;
	}
}
