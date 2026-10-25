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
public class RecieptsDetail : INotifyPropertyChanged
{
	private int lineNumberField;

	private int itemIdField;

	private string itemBarcodeField;

	private string itemNameField;

	private DateTime transactionDateField;

	private decimal saleQTYField;

	private decimal saleAmountField;

	private decimal taxAmountField;

	private decimal returnQTYField;

	private decimal returnAmountField;

	private decimal returnTaxField;

	private int? customerIdField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int LineNumber
	{
		get
		{
			return lineNumberField;
		}
		set
		{
			lineNumberField = value;
			RaisePropertyChanged("LineNumber");
		}
	}

	[XmlElement(Order = 1)]
	public int ItemId
	{
		get
		{
			return itemIdField;
		}
		set
		{
			itemIdField = value;
			RaisePropertyChanged("ItemId");
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
	public DateTime TransactionDate
	{
		get
		{
			return transactionDateField;
		}
		set
		{
			transactionDateField = value;
			RaisePropertyChanged("TransactionDate");
		}
	}

	[XmlElement(Order = 5)]
	public decimal SaleQTY
	{
		get
		{
			return saleQTYField;
		}
		set
		{
			saleQTYField = value;
			RaisePropertyChanged("SaleQTY");
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
	public decimal TaxAmount
	{
		get
		{
			return taxAmountField;
		}
		set
		{
			taxAmountField = value;
			RaisePropertyChanged("TaxAmount");
		}
	}

	[XmlElement(Order = 8)]
	public decimal ReturnQTY
	{
		get
		{
			return returnQTYField;
		}
		set
		{
			returnQTYField = value;
			RaisePropertyChanged("ReturnQTY");
		}
	}

	[XmlElement(Order = 9)]
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

	[XmlElement(Order = 10)]
	public decimal ReturnTax
	{
		get
		{
			return returnTaxField;
		}
		set
		{
			returnTaxField = value;
			RaisePropertyChanged("ReturnTax");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? CustomerId
	{
		get
		{
			return customerIdField;
		}
		set
		{
			customerIdField = value;
			RaisePropertyChanged("CustomerId");
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
