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
public class RecieptsHeader : INotifyPropertyChanged
{
	private DateTime transactionDateField;

	private decimal? totalSaleAmountField;

	private decimal? totalTaxAmountField;

	private decimal? totalDiscountAmountField;

	private decimal? totalGrossAmountField;

	private decimal? totalPaymentAmountField;

	private decimal transactionSeqNoField;

	private int retailStoreIDField;

	private int workstaionIDField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
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

	[XmlElement(IsNullable = true, Order = 1)]
	public decimal? TotalSaleAmount
	{
		get
		{
			return totalSaleAmountField;
		}
		set
		{
			totalSaleAmountField = value;
			RaisePropertyChanged("TotalSaleAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public decimal? TotalTaxAmount
	{
		get
		{
			return totalTaxAmountField;
		}
		set
		{
			totalTaxAmountField = value;
			RaisePropertyChanged("TotalTaxAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? TotalDiscountAmount
	{
		get
		{
			return totalDiscountAmountField;
		}
		set
		{
			totalDiscountAmountField = value;
			RaisePropertyChanged("TotalDiscountAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? TotalGrossAmount
	{
		get
		{
			return totalGrossAmountField;
		}
		set
		{
			totalGrossAmountField = value;
			RaisePropertyChanged("TotalGrossAmount");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public decimal? TotalPaymentAmount
	{
		get
		{
			return totalPaymentAmountField;
		}
		set
		{
			totalPaymentAmountField = value;
			RaisePropertyChanged("TotalPaymentAmount");
		}
	}

	[XmlElement(Order = 6)]
	public decimal TransactionSeqNo
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

	[XmlElement(Order = 8)]
	public int WorkstaionID
	{
		get
		{
			return workstaionIDField;
		}
		set
		{
			workstaionIDField = value;
			RaisePropertyChanged("WorkstaionID");
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
