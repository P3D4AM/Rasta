using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpPosRefundRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string user;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string password;

	[DataMember(Order = 2)]
	public long saleReferenceId;

	[DataMember(Order = 3)]
	public long refundAmount;

	public bpPosRefundRequestBody()
	{
	}

	public bpPosRefundRequestBody(string user, string password, long saleReferenceId, long refundAmount)
	{
		this.user = user;
		this.password = password;
		this.saleReferenceId = saleReferenceId;
		this.refundAmount = refundAmount;
	}
}
