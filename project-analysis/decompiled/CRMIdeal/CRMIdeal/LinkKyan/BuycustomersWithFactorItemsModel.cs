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
public class BuycustomersWithFactorItemsModel : INotifyPropertyChanged
{
	private string customerIDField;

	private string customerMobileField;

	private string retailStoreCodeField;

	private string retailStoreIDField;

	private string workstationIDField;

	private string businessDateField;

	private string transactionSeqNoField;

	private string cashierIDField;

	private string barcodeField;

	private string itemIDField;

	private string salePriceField;

	private string saleQuantityField;

	private string customerPriceBuyField;

	private string itemDiscountPercentField;

	private string itemDiscountField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public string CustomerID
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
	public string CustomerMobile
	{
		get
		{
			return customerMobileField;
		}
		set
		{
			customerMobileField = value;
			RaisePropertyChanged("CustomerMobile");
		}
	}

	[XmlElement(Order = 2)]
	public string RetailStoreCode
	{
		get
		{
			return retailStoreCodeField;
		}
		set
		{
			retailStoreCodeField = value;
			RaisePropertyChanged("RetailStoreCode");
		}
	}

	[XmlElement(Order = 3)]
	public string RetailStoreID
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

	[XmlElement(Order = 4)]
	public string WorkstationID
	{
		get
		{
			return workstationIDField;
		}
		set
		{
			workstationIDField = value;
			RaisePropertyChanged("WorkstationID");
		}
	}

	[XmlElement(Order = 5)]
	public string BusinessDate
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

	[XmlElement(Order = 6)]
	public string TransactionSeqNo
	{
		get
		{
			return transactionSeqNoField;
		}
		set
		{
			transactionSeqNoField = value;
			RaisePropertyChanged("TransactionSeqNo");
		}
	}

	[XmlElement(Order = 7)]
	public string CashierID
	{
		get
		{
			return cashierIDField;
		}
		set
		{
			cashierIDField = value;
			RaisePropertyChanged("CashierID");
		}
	}

	[XmlElement(Order = 8)]
	public string barcode
	{
		get
		{
			return barcodeField;
		}
		set
		{
			barcodeField = value;
			RaisePropertyChanged("barcode");
		}
	}

	[XmlElement(Order = 9)]
	public string ItemID
	{
		get
		{
			return itemIDField;
		}
		set
		{
			itemIDField = value;
			RaisePropertyChanged("ItemID");
		}
	}

	[XmlElement(Order = 10)]
	public string SalePrice
	{
		get
		{
			return salePriceField;
		}
		set
		{
			salePriceField = value;
			RaisePropertyChanged("SalePrice");
		}
	}

	[XmlElement(Order = 11)]
	public string SaleQuantity
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

	[XmlElement(Order = 12)]
	public string CustomerPriceBuy
	{
		get
		{
			return customerPriceBuyField;
		}
		set
		{
			customerPriceBuyField = value;
			RaisePropertyChanged("CustomerPriceBuy");
		}
	}

	[XmlElement(Order = 13)]
	public string ItemDiscountPercent
	{
		get
		{
			return itemDiscountPercentField;
		}
		set
		{
			itemDiscountPercentField = value;
			RaisePropertyChanged("ItemDiscountPercent");
		}
	}

	[XmlElement(Order = 14)]
	public string ItemDiscount
	{
		get
		{
			return itemDiscountField;
		}
		set
		{
			itemDiscountField = value;
			RaisePropertyChanged("ItemDiscount");
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
