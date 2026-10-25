using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundRequestBody
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
	public long saleOrderId;

	[DataMember(Order = 5)]
	public long saleReferenceId;

	[DataMember(Order = 6)]
	public long refundAmount;

	public bpRefundRequestBody()
	{
	}

	public bpRefundRequestBody(long terminalId, string userName, string userPassword, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		this.terminalId = terminalId;
		this.userName = userName;
		this.userPassword = userPassword;
		this.orderId = orderId;
		this.saleOrderId = saleOrderId;
		this.saleReferenceId = saleReferenceId;
		this.refundAmount = refundAmount;
	}
}
