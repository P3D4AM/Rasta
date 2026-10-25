using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "KyanOnlineSaleService")]
public class ReceiptDsInfModel : INotifyPropertyChanged
{
	private int? customerIDField;

	private DateTime businessDateField;

	private int retailStoreIDField;

	private string retailStoreNameField;

	private string receiptNoField;

	private string receiptKyanField;

	private string barcodeField;

	private string itemNameField;

	private decimal? saleQuantityField;

	private decimal? returnQuantityField;

	private decimal saleAmountField;

	private decimal? returnAmountField;

	private decimal? retDiscountAmounturnAmountField;

	private decimal? returnDiscountAmountField;

	private decimal? saleTaxAmountField;

	private decimal? returnTaxAmountField;

	private decimal? saleChargeAmountField;

	private decimal? returnChargeAmountField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? CustomerID
	{
		get
		{
			return customerIDField;
		}
		set
		{
			customerIDField = value;
			RaisePropertyChanged("CustomerID");
		}
	}

	[XmlElement(Order = 1)]
	public DateTime BusinessDate
	{
		get
		{
			return businessDateField;
		}
		set
		{
			businessDateField = value;
			RaisePropertyChanged("BusinessDate");
		}
	}

	[XmlElement(Order = 2)]
	public int RetailStoreID
	{
		get
		{
			return retailStoreIDField;
		}
		set
		{
			retailStoreIDField = value;
			RaisePropertyChanged("RetailStoreID");
		}
	}

	[XmlElement(Order = 3)]
	public string RetailStoreName
	{
		get
		{
			return retailStoreNameField;
		}
		set
		{
			retailStoreNameField = value;
			RaisePropertyChanged("RetailStoreName");
		}
	}

	[XmlElement(Order = 4)]
	public string ReceiptNo
	{
		get
		{
			return receiptNoField;
		}
		set
		{
			receiptNoField = value;
			RaisePropertyChanged("ReceiptNo");
		}
	}

	[XmlElement(Order = 5)]
	public string ReceiptKyan
	{
		get
		{
			return receiptKyanField;
		}
		set
		{
			receiptKyanField = value;
			RaisePropertyChanged("ReceiptKyan");
		}
	}

	[XmlElement(Order = 6)]
	public string Barcode
	{
		get
		{
			return barcodeField;
		}
		set
		{
			barcodeField = value;
			RaisePropertyChanged("Barcode");
		}
	}

	[XmlElement(Order = 7)]
	public string ItemName
	{
		get
		{
			return itemNameField;
		}
		set
		{
			itemNameField = value;
			RaisePropertyChanged("ItemName");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public decimal? SaleQuantity
	{
		get
		{
			return saleQuantityField;
		}
		set
		{
			saleQuantityField = value;
			RaisePropertyChanged("SaleQuantity");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? ReturnQuantity
	{
		get
		{
			return returnQuantityField;
		}
		set
		{
			returnQuantityField = value;
			RaisePropertyChanged("ReturnQuantity");
		}
	}

	[XmlElement(Order = 10)]
	public decimal SaleAmount
	{
		get
		{
			return saleAmountField;
		}
		set
		{
			saleAmountField = value;
			RaisePropertyChanged("SaleAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public decimal? ReturnAmount
	{
		get
		{
			return returnAmountField;
		}
		set
		{
			returnAmountField = value;
			RaisePropertyChanged("ReturnAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public decimal? RetDiscountAmounturnAmount
	{
		get
		{
			return retDiscountAmounturnAmountField;
		}
		set
		{
			retDiscountAmounturnAmountField = value;
			RaisePropertyChanged("RetDiscountAmounturnAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public decimal? ReturnDiscountAmount
	{
		get
		{
			return returnDiscountAmountField;
		}
		set
		{
			returnDiscountAmountField = value;
			RaisePropertyChanged("ReturnDiscountAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public decimal? SaleTaxAmount
	{
		get
		{
			return saleTaxAmountField;
		}
		set
		{
			saleTaxAmountField = value;
			RaisePropertyChanged("SaleTaxAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public decimal? ReturnTaxAmount
	{
		get
		{
			return returnTaxAmountField;
		}
		set
		{
			returnTaxAmountField = value;
			RaisePropertyChanged("ReturnTaxAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public decimal? SaleChargeAmount
	{
		get
		{
			return saleChargeAmountField;
		}
		set
		{
			saleChargeAmountField = value;
			RaisePropertyChanged("SaleChargeAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public decimal? ReturnChargeAmount
	{
		get
		{
			return returnChargeAmountField;
		}
		set
		{
			returnChargeAmountField = value;
			RaisePropertyChanged("ReturnChargeAmount");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
	}

	protected void RaisePropertyChanged(string propertyName)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
		if (propertyChanged != null)
		{
			propertyChanged.Invoke((object)this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
