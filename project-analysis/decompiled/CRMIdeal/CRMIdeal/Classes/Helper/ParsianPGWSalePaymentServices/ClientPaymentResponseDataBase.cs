using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.Classes.Helper.ParsianPGWSalePaymentServices;

[Serializable]
[XmlInclude(typeof(ClientSaleResponseData))]
[GeneratedCode("System.Xml", "4.7.2556.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
public class ClientPaymentResponseDataBase
{
	private long tokenField;

	private string messageField;

	private short statusField;

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

	public string Message
	{
		get
		{
			return messageField;
		}
		set
		{
			messageField = value;
		}
	}

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
}
