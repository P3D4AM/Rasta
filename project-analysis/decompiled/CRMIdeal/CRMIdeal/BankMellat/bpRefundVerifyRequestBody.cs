using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundVerifyRequestBody
{
	[DataMember(Order = 0)]
	public long terminalId;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string userName;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string userPassword;

	[DataMember(Order = 3)]
	public long orderId;

	[DataMember(Order = 4)]
	public long refundOrderId;

	[DataMember(Order = 5)]
	public long refundReferenceId;

	public bpRefundVerifyRequestBody()
	{
	}

	public bpRefundVerifyRequestBody(long terminalId, string userName, string userPassword, long orderId, long refundOrderId, long refundReferenceId)
	{
		this.terminalId = terminalId;
		this.userName = userName;
		this.userPassword = userPassword;
		this.orderId = orderId;
		this.refundOrderId = refundOrderId;
		this.refundReferenceId = refundReferenceId;
	}
}
