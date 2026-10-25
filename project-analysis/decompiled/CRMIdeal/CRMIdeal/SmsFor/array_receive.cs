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
public class array_receive
{
	private string idField;

	private string sender_numberField;

	private string receiver_numberField;

	private string dateField;

	private string catidField;

	private string noteField;

	private int readField;

	public string id
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

	public string sender_number
	{
		get
		{
			return sender_numberField;
		}
		set
		{
			sender_numberField = value;
		}
	}

	public string receiver_number
	{
		get
		{
			return receiver_numberField;
		}
		set
		{
			receiver_numberField = value;
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

	public string catid
	{
		get
		{
			return catidField;
		}
		set
		{
			catidField = value;
		}
	}

	public string note
	{
		get
		{
			return noteField;
		}
		set
		{
			noteField = value;
		}
	}

	public int read
	{
		get
		{
			return readField;
		}
		set
		{
			readField = value;
		}
	}
}
