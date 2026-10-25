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
public class array_cat_list
{
	private string idField;

	private string titleField;

	private string dateField;

	private int numberField;

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

	public string title
	{
		get
		{
			return titleField;
		}
		set
		{
			titleField = value;
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

	public int number
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
}
