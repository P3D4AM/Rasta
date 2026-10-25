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
public class return_array_user_info
{
	private string idField;

	private string fullnameField;

	private string emailField;

	private string mobileField;

	private string cashField;

	private string dateField;

	private string date_expireField;

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

	public string email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
		}
	}

	public string mobile
	{
		get
		{
			return mobileField;
		}
		set
		{
			mobileField = value;
		}
	}

	public string cash
	{
		get
		{
			return cashField;
		}
		set
		{
			cashField = value;
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

	public string date_expire
	{
		get
		{
			return date_expireField;
		}
		set
		{
			date_expireField = value;
		}
	}
}
