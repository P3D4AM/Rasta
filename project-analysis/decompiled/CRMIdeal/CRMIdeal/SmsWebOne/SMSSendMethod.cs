using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace CRMIdeal.SmsWebOne;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SMSSendMethod", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Domain.Enums")]
public enum SMSSendMethod
{
	[EnumMember]
	None = -10,
	[EnumMember]
	Quick = 1,
	[EnumMember]
	Test = 2,
	[EnumMember]
	Regional = 3,
	[EnumMember]
	Group = 4,
	[EnumMember]
	WebService = 5,
	[EnumMember]
	Announcement = 6,
	[EnumMember]
	Secretary = 7,
	[EnumMember]
	IntelligentSend = 8,
	[EnumMember]
	CorrespondingSend = 9,
	[EnumMember]
	CodeReader = 10,
	[EnumMember]
	Poll = 11,
	[EnumMember]
	Transfer = 12,
	[EnumMember]
	Reply = 13,
	[EnumMember]
	PhoneBook = 14,
	[EnumMember]
	PostalCode = 15,
	[EnumMember]
	SmsEvent = 16,
	[EnumMember]
	IntelligentSecretary = 17,
	[EnumMember]
	AddToPhoneBook = 18,
	[EnumMember]
	InstantSms = 19,
	[EnumMember]
	ScheduleSms = 20,
	[EnumMember]
	UsanceSms = 21
}
