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
public class ReceiveResult
{
	private string idField;

	private string fromField;

	private string toField;

	private string dateField;

	private string bodyField;

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

	public string From
	{
		get
		{
			return fromField;
		}
		set
		{
			fromField = value;
		}
	}

	public string To
	{
		get
		{
			return toField;
		}
		set
		{
			toField = value;
		}
	}

	public string Date
	{
		get
		{
			return dateField;
		}
		set
		{
			dateField = value;
		}
	}

	public string Body
	{
		get
		{
			return bodyField;
		}
		set
		{
			bodyField = value;
		}
	}
}
