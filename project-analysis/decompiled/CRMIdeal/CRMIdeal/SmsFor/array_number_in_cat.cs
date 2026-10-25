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
public class array_number_in_cat
{
	private string idField;

	private string fullnameField;

	private string numberField;

	private string dateField;

	private string genderField;

	private string fullname_enField;

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

	public string fullname
	{
		get
		{
			return fullnameField;
		}
		set
		{
			fullnameField = value;
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

	public string gender
	{
		get
		{
			return genderField;
		}
		set
		{
			genderField = value;
		}
	}

	public string fullname_en
	{
		get
		{
			return fullname_enField;
		}
		set
		{
			fullname_enField = value;
		}
	}
}
