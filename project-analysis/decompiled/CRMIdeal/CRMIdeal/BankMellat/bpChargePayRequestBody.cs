using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "")]
public class bpChargePayRequestBody
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
	public long amount;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string localDate;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string localTime;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string additionalData;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string callBackUrl;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string payerId;

	public bpChargePayRequestBody()
	{
	}

	public bpChargePayRequestBody(long terminalId, string userName, string userPassword, long orderId, long amount, string localDate, string localTime, string additionalData, string callBackUrl, string payerId)
	{
		this.terminalId = terminalId;
		this.userName = userName;
		this.userPassword = userPassword;
		this.orderId = orderId;
		this.amount = amount;
		this.localDate = localDate;
		this.localTime = localTime;
		this.additionalData = additionalData;
		this.callBackUrl = callBackUrl;
		this.payerId = payerId;
	}
}
