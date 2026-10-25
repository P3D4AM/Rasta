using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertPishFactorRequest
{
	[MessageBodyMember(Name = "Idealsp_InsertPishFactor", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertPishFactorRequestBody Body;

	public Idealsp_InsertPishFactorRequest()
	{
	}

	public Idealsp_InsertPishFactorRequest(Idealsp_InsertPishFactorRequestBody Body)
	{
		this.Body = Body;
	}
}
