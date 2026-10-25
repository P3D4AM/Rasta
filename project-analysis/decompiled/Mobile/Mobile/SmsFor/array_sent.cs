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
public class array_sent
{
	private string idField;

	private string sender_numberField;

	private string numberField;

	private string dateField;

	private string noteField;

	private int deliver_stateField;

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

	public int deliver_state
	{
		get
		{
			return deliver_stateField;
		}
		set
		{
			deliver_stateField = value;
		}
	}
}
