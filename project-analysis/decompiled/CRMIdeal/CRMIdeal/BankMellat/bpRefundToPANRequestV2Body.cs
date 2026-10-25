using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundToPANRequestV2Body
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string user;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string password;

	[DataMember(Order = 2)]
	public long pan;

	[DataMember(Order = 3)]
	public long amount;

	[DataMember(Order = 4)]
	public long saleReferenceId;

	[DataMember(Order = 5)]
	public long terminalId;

	[DataMember(Order = 6)]
	public long orderId;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string mobileNo;

	public bpRefundToPANRequestV2Body()
	{
	}

	public bpRefundToPANRequestV2Body(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, long orderId, string mobileNo)
	{
		this.user = user;
		this.password = password;
		this.pan = pan;
		this.amount = amount;
		this.saleReferenceId = saleReferenceId;
		this.terminalId = terminalId;
		this.orderId = orderId;
		this.mobileNo = mobileNo;
	}
}
