using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class InsertIntoPish_FactorResponse
{
	[MessageBodyMember(Name = "InsertIntoPish_FactorResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public InsertIntoPish_FactorResponseBody Body;

	public InsertIntoPish_FactorResponse()
	{
	}

	public InsertIntoPish_FactorResponse(InsertIntoPish_FactorResponseBody Body)
	{
		this.Body = Body;
	}
}
