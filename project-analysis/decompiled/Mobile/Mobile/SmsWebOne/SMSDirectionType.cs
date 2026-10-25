using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Mobile.SmsWebOne;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SMSDirectionType", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Domain.Enums")]
public enum SMSDirectionType
{
	[EnumMember]
	None = -10,
	[EnumMember]
	In = 1,
	[EnumMember]
	Out = 2,
	[EnumMember]
	Schedule = 3,
	[EnumMember]
	Usance = 4
}
