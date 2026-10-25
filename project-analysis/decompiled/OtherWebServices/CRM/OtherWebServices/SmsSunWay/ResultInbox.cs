using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRM.OtherWebServices.SmsSunWay;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class ResultInbox : ResultBase
{
	private InboxItem2[] messagesField;

	[XmlArray(Order = 0)]
	public InboxItem2[] Messages
	{
		get
		{
			return messagesField;
		}
		set
		{
			messagesField = value;
			RaisePropertyChanged("Messages");
		}
	}
}
