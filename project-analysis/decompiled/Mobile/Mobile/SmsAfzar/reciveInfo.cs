using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Mobile.SmsAfzar;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class reciveInfo
{
	private string senderNumberField;

	private string reciverNumberField;

	private string textField;

	private long reciveIDField;

	private string dateField;

	private string timeField;

	public string senderNumber
	{
		get
		{
			return senderNumberField;
		}
		set
		{
			senderNumberField = value;
		}
	}

	public string reciverNumber
	{
		get
		{
			return reciverNumberField;
		}
		set
		{
			reciverNumberField = value;
		}
	}

	public string text
	{
		get
		{
			return textField;
		}
		set
		{
			textField = value;
		}
	}

	public long reciveID
	{
		get
		{
			return reciveIDField;
		}
		set
		{
			reciveIDField = value;
		}
	}

	public string date
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

	public string time
	{
		get
		{
			return timeField;
		}
		set
		{
			timeField = value;
		}
	}
}
