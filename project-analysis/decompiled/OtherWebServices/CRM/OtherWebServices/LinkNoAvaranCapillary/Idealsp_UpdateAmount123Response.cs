using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_UpdateAmount123Response
{
	[MessageBodyMember(Name = "Idealsp_UpdateAmount123Response", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_UpdateAmount123ResponseBody Body;

	public Idealsp_UpdateAmount123Response()
	{
	}

	public Idealsp_UpdateAmount123Response(Idealsp_UpdateAmount123ResponseBody Body)
	{
		this.Body = Body;
	}
}
