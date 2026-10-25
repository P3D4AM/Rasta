using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromPish_FactorDateRangeResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string ReadFromPish_FactorDateRangeResult;

	public ReadFromPish_FactorDateRangeResponseBody()
	{
	}

	public ReadFromPish_FactorDateRangeResponseBody(string ReadFromPish_FactorDateRangeResult)
	{
		this.ReadFromPish_FactorDateRangeResult = ReadFromPish_FactorDateRangeResult;
	}
}
