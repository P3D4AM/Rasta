using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundRequestV2Body
{
	[DataMember(Order = 0)]
	public long terminalId;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string userName;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string userPassword;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string destinationPan;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string mobileNo;

	[DataMember(Order = 5)]
	public long orderId;

	[DataMember(Order = 6)]
	public long saleOrderId;

	[DataMember(Order = 7)]
	public long saleReferenceId;

	[DataMember(Order = 8)]
	public long refundAmount;

	public bpRefundRequestV2Body()
	{
	}

	public bpRefundRequestV2Body(long terminalId, string userName, string userPassword, string destinationPan, string mobileNo, long orderId, long saleOrderId, long saleReferenceId, long refundAmount)
	{
		this.terminalId = terminalId;
		this.userName = userName;
		this.userPassword = userPassword;
		this.destinationPan = destinationPan;
		this.mobileNo = mobileNo;
		this.orderId = orderId;
		this.saleOrderId = saleOrderId;
		this.saleReferenceId = saleReferenceId;
		this.refundAmount = refundAmount;
	}
}
