using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertoutputRequest
{
	[MessageBodyMember(Name = "Idealsp_Insertoutput", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertoutputRequestBody Body;

	public Idealsp_InsertoutputRequest()
	{
	}

	public Idealsp_InsertoutputRequest(Idealsp_InsertoutputRequestBody Body)
	{
		this.Body = Body;
	}
}
