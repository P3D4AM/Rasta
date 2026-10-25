using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.Classes.Helper.ParsianPGWSalePaymentServices;

[Serializable]
[XmlInclude(typeof(ClientSaleRequestData))]
[GeneratedCode("System.Xml", "4.7.2556.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
public class ClientPaymentRequestDataBase
{
	private string loginAccountField;

	private long amountField;

	private long orderIdField;

	private string callBackUrlField;

	private string additionalDataField;

	private string originatorField;

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

	public long Amount
	{
		get
		{
			return amountField;
		}
		set
		{
			amountField = value;
		}
	}

	public long OrderId
	{
		get
		{
			return orderIdField;
		}
		set
		{
			orderIdField = value;
		}
	}

	public string CallBackUrl
	{
		get
		{
			return callBackUrlField;
		}
		set
		{
			callBackUrlField = value;
		}
	}

	public string AdditionalData
	{
		get
		{
			return additionalDataField;
		}
		set
		{
			additionalDataField = value;
		}
	}

	public string Originator
	{
		get
		{
			return originatorField;
		}
		set
		{
			originatorField = value;
		}
	}
}
