using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_UpdateAmount123Request
{
	[MessageBodyMember(Name = "Idealsp_UpdateAmount123", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_UpdateAmount123RequestBody Body;

	public Idealsp_UpdateAmount123Request()
	{
	}

	public Idealsp_UpdateAmount123Request(Idealsp_UpdateAmount123RequestBody Body)
	{
		this.Body = Body;
	}
}
