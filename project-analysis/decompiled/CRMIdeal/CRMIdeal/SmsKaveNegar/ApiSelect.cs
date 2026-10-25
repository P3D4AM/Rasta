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
public class ApiSelect
{
	private long messageidField;

	private string messageField;

	private int statusField;

	private string statustextField;

	private string senderField;

	private string receptorField;

	private long dateField;

	private int costField;

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

	public int status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
		}
	}

	public string statustext
	{
		get
		{
			return statustextField;
		}
		set
		{
			statustextField = value;
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

	public int cost
	{
		get
		{
			return costField;
		}
		set
		{
			costField = value;
		}
	}
}
