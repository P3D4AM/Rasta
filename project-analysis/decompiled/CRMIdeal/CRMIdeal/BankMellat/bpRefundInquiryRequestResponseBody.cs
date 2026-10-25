using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundInquiryRequestResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string @return;

	public bpRefundInquiryRequestResponseBody()
	{
	}

	public bpRefundInquiryRequestResponseBody(string @return)
	{
		this.@return = @return;
	}
}
