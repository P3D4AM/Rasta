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
public class CustomerTransaction : INotifyPropertyChanged
{
	private DateTime bussinessDayField;

	private string retailStoreNameField;

	private string itemBarcodeField;

	private string itemNameField;

	private decimal saleQuantityField;

	private decimal returnQuantityField;

	private decimal saleAmountField;

	private decimal returnAmountField;

	private decimal discountAmountField;

	private decimal returnDiscountAmountField;

	private decimal saleTaxAmountField;

	private decimal returnTaxAmountField;

	private decimal saleChargeAmountField;

	private decimal returnChangeAmountField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public DateTime BussinessDay
	{
		get
		{
			return bussinessDayField;
		}
		set
		{
			bussinessDayField = value;
			RaisePropertyChanged("BussinessDay");
		}
	}

	[XmlElement(Order = 1)]
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

	[XmlElement(Order = 2)]
	public string ItemBarcode
	{
		get
		{
			return itemBarcodeField;
		}
		set
		{
			itemBarcodeField = value;
			RaisePropertyChanged("ItemBarcode");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
	public decimal SaleQuantity
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

	[XmlElement(Order = 5)]
	public decimal ReturnQuantity
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

	[XmlElement(Order = 6)]
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

	[XmlElement(Order = 7)]
	public decimal ReturnAmount
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

	[XmlElement(Order = 8)]
	public decimal DiscountAmount
	{
		get
		{
			return discountAmountField;
		}
		set
		{
			discountAmountField = value;
			RaisePropertyChanged("DiscountAmount");
		}
	}

	[XmlElement(Order = 9)]
	public decimal ReturnDiscountAmount
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

	[XmlElement(Order = 10)]
	public decimal SaleTaxAmount
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

	[XmlElement(Order = 11)]
	public decimal ReturnTaxAmount
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

	[XmlElement(Order = 12)]
	public decimal SaleChargeAmount
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

	[XmlElement(Order = 13)]
	public decimal ReturnChangeAmount
	{
		get
		{
			return returnChangeAmountField;
		}
		set
		{
			returnChangeAmountField = value;
			RaisePropertyChanged("ReturnChangeAmount");
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
