using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Mobile.SmsFor;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[SoapType(Namespace = "urn:sms_webservice_wsdl")]
public class array_tree
{
	private int idField;

	private string nameField;

	public int id
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

	public string name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}
}
