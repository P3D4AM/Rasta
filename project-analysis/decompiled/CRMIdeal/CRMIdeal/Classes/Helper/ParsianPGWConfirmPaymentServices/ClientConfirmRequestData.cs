using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.Classes.Helper.ParsianPGWConfirmPaymentServices;

[Serializable]
[GeneratedCode("System.Xml", "4.6.1586.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
public class ClientConfirmRequestData
{
	private string loginAccountField;

	private long tokenField;

	public string LoginAccount
	{
		get
		{
			return loginAccountField;
		}
		set
		{
			loginAccountField = value;
		}
	}

	public long Token
	{
		get
		{
			return tokenField;
		}
		set
		{
			tokenField = value;
		}
	}
}
