using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.SmsKaveNegar;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://api.kavenegar.com/")]
public class ApiReceive
{
	private long messageidField;

	private string messageField;

	private string senderField;

	private string receptorField;

	private long dateField;

	public long messageid
	{
		get
		{
			return messageidField;
		}
		set
		{
			messageidField = value;
		}
	}

	public string message
	{
		get
		{
			return messageField;
		}
		set
		{
			messageField = value;
		}
	}

	public string sender
	{
		get
		{
			return senderField;
		}
		set
		{
			senderField = value;
		}
	}

	public string receptor
	{
		get
		{
			return receptorField;
		}
		set
		{
			receptorField = value;
		}
	}

	public long date
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
}
