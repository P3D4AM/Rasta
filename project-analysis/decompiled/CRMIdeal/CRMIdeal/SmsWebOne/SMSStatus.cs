using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace CRMIdeal.SmsWebOne;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SMSStatus", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Domain.Enums")]
public enum SMSStatus
{
	[EnumMember]
	None = -10,
	[EnumMember]
	Pending = 1,
	[EnumMember]
	Illegal = 2,
	[EnumMember]
	Sending = 3,
	[EnumMember]
	NotApproved = 4,
	[EnumMember]
	Sent = 5,
	[EnumMember]
	Canceled = 6,
	[EnumMember]
	Error = 7,
	[EnumMember]
	NoCredit = 8,
	[EnumMember]
	NotSent = 9,
	[EnumMember]
	WaitForSend = 10
}
