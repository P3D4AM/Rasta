using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromPish_FactorDateRangeResponse
{
	[MessageBodyMember(Name = "ReadFromPish_FactorDateRangeResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromPish_FactorDateRangeResponseBody Body;

	public ReadFromPish_FactorDateRangeResponse()
	{
	}

	public ReadFromPish_FactorDateRangeResponse(ReadFromPish_FactorDateRangeResponseBody Body)
	{
		this.Body = Body;
	}
}
