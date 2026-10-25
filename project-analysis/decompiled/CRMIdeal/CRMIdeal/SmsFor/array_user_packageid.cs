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
public class array_user_packageid
{
	private int idField;

	private string titleField;

	private string serviceField;

	private int priceField;

	private int expireField;

	private int free_cashField;

	public int id
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

	public string service
	{
		get
		{
			return serviceField;
		}
		set
		{
			serviceField = value;
		}
	}

	public int price
	{
		get
		{
			return priceField;
		}
		set
		{
			priceField = value;
		}
	}

	public int expire
	{
		get
		{
			return expireField;
		}
		set
		{
			expireField = value;
		}
	}

	public int free_cash
	{
		get
		{
			return free_cashField;
		}
		set
		{
			free_cashField = value;
		}
	}
}
