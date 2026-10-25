using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.SmsFor;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[SoapType(Namespace = "urn:sms_webservice_wsdl")]
public class array_number
{
	private string numberField;

	private string orderField;

	private string kindField;

	public string number
	{
		get
		{
			return numberField;
		}
		set
		{
			numberField = value;
		}
	}

	public string order
	{
		get
		{
			return orderField;
		}
		set
		{
			orderField = value;
		}
	}

	public string kind
	{
		get
		{
			return kindField;
		}
		set
		{
			kindField = value;
		}
	}
}
