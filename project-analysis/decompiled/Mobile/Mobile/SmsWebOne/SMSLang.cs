using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Mobile.SmsWebOne;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SMSLang", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Common.Enums")]
public enum SMSLang
{
	[EnumMember]
	None = -10,
	[EnumMember]
	FA = 1,
	[EnumMember]
	EN = 2
}
