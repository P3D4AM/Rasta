using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPish_FactorRequest
{
	[MessageBodyMember(Name = "ReadFromPish_Factor", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPish_FactorRequestBody Body;

	public ReadFromPish_FactorRequest()
	{
	}

	public ReadFromPish_FactorRequest(ReadFromPish_FactorRequestBody Body)
	{
		this.Body = Body;
	}
}
