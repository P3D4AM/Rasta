using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpRefundToPANRequestBody
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

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string mobileNo;

	[DataMember(Order = 7)]
	public long orderId;

	public bpRefundToPANRequestBody()
	{
	}

	public bpRefundToPANRequestBody(string user, string password, long pan, long amount, long saleReferenceId, long terminalId, string mobileNo, long orderId)
	{
		this.user = user;
		this.password = password;
		this.pan = pan;
		this.amount = amount;
		this.saleReferenceId = saleReferenceId;
		this.terminalId = terminalId;
		this.mobileNo = mobileNo;
		this.orderId = orderId;
	}
}
