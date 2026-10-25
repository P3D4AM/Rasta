using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Mobile.SmsWebOne;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SMSSendStatus", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Domain.Enums")]
public enum SMSSendStatus
{
	[EnumMember]
	None = -10,
	[EnumMember]
	Sent = 1,
	[EnumMember]
	Error = 2,
	[EnumMember]
	BlockList = 3
}
