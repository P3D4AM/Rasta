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
public class ApiProvincies
{
	private int provinceidField;

	private string nameField;

	private long permanentcellcountField;

	private long temporarycellcountField;

	public int provinceid
	{
		get
		{
			return provinceidField;
		}
		set
		{
			provinceidField = value;
		}
	}

	public string name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}

	public long permanentcellcount
	{
		get
		{
			return permanentcellcountField;
		}
		set
		{
			permanentcellcountField = value;
		}
	}

	public long temporarycellcount
	{
		get
		{
			return temporarycellcountField;
		}
		set
		{
			temporarycellcountField = value;
		}
	}
}
