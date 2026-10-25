using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class InsertIntoPish_FactorResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string InsertIntoPish_FactorResult;

	public InsertIntoPish_FactorResponseBody()
	{
	}

	public InsertIntoPish_FactorResponseBody(string InsertIntoPish_FactorResult)
	{
		this.InsertIntoPish_FactorResult = InsertIntoPish_FactorResult;
	}
}
