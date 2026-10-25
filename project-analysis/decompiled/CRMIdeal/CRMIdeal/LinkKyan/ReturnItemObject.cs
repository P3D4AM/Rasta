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
public class ReturnItemObject : INotifyPropertyChanged
{
	private int itemIDField;

	private decimal? quantityField;

	private decimal? extendedAmountField;

	private decimal actualUnitPriceField;

	private decimal? chargeAmountField;

	private decimal? taxAmountField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int ItemID
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

	[XmlElement(IsNullable = true, Order = 1)]
	public decimal? Quantity
	{
		get
		{
			return quantityField;
		}
		set
		{
			quantityField = value;
			RaisePropertyChanged("Quantity");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public decimal? ExtendedAmount
	{
		get
		{
			return extendedAmountField;
		}
		set
		{
			extendedAmountField = value;
			RaisePropertyChanged("ExtendedAmount");
		}
	}

	[XmlElement(Order = 3)]
	public decimal ActualUnitPrice
	{
		get
		{
			return actualUnitPriceField;
		}
		set
		{
			actualUnitPriceField = value;
			RaisePropertyChanged("ActualUnitPrice");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? ChargeAmount
	{
		get
		{
			return chargeAmountField;
		}
		set
		{
			chargeAmountField = value;
			RaisePropertyChanged("ChargeAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public decimal? TaxAmount
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
