using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromPish_FactorResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string ReadFromPish_FactorResult;

	public ReadFromPish_FactorResponseBody()
	{
	}

	public ReadFromPish_FactorResponseBody(string ReadFromPish_FactorResult)
	{
		this.ReadFromPish_FactorResult = ReadFromPish_FactorResult;
	}
}
