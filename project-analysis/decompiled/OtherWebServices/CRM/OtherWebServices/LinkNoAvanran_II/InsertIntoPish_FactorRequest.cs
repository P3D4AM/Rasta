using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class InsertIntoPish_FactorRequest
{
	[MessageBodyMember(Name = "InsertIntoPish_Factor", Namespace = "http://tempuri.org/", Order = 0)]
	public InsertIntoPish_FactorRequestBody Body;

	public InsertIntoPish_FactorRequest()
	{
	}

	public InsertIntoPish_FactorRequest(InsertIntoPish_FactorRequestBody Body)
	{
		this.Body = Body;
	}
}
