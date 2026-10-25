using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpSettleRequestResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string @return;

	public bpSettleRequestResponseBody()
	{
	}

	public bpSettleRequestResponseBody(string @return)
	{
		this.@return = @return;
	}
}
