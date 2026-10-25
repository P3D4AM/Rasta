using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpSaleReferenceIdRequestBody
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

	public bpSaleReferenceIdRequestBody()
	{
	}

	public bpSaleReferenceIdRequestBody(long terminalId, string userName, string userPassword, long orderId, long saleOrderId)
	{
		this.terminalId = terminalId;
		this.userName = userName;
		this.userPassword = userPassword;
		this.orderId = orderId;
		this.saleOrderId = saleOrderId;
	}
}
