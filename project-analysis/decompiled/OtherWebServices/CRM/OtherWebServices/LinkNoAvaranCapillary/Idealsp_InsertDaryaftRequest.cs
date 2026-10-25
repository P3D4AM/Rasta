using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertDaryaftRequest
{
	[MessageBodyMember(Name = "Idealsp_InsertDaryaft", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertDaryaftRequestBody Body;

	public Idealsp_InsertDaryaftRequest()
	{
	}

	public Idealsp_InsertDaryaftRequest(Idealsp_InsertDaryaftRequestBody Body)
	{
		this.Body = Body;
	}
}
