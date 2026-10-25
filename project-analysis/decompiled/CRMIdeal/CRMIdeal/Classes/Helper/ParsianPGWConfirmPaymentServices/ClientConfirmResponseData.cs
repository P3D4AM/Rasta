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
public class ClientConfirmResponseData
{
	private short statusField;

	private string cardNumberMaskedField;

	private long rRNField;

	private long tokenField;

	public short Status
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

	public string CardNumberMasked
	{
		get
		{
			return cardNumberMaskedField;
		}
		set
		{
			cardNumberMaskedField = value;
		}
	}

	public long RRN
	{
		get
		{
			return rRNField;
		}
		set
		{
			rRNField = value;
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
