using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRM.OtherWebServices.SmsCandoo;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[SoapType(Namespace = "urn:SMSAPIwsdl")]
public class MultipleSendResult
{
	private string idField;

	public string ID
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
		}
	}
}
