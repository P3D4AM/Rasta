using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPish_FactorDateRangeRequest
{
	[MessageBodyMember(Name = "ReadFromPish_FactorDateRange", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPish_FactorDateRangeRequestBody Body;

	public ReadFromPish_FactorDateRangeRequest()
	{
	}

	public ReadFromPish_FactorDateRangeRequest(ReadFromPish_FactorDateRangeRequestBody Body)
	{
		this.Body = Body;
	}
}
