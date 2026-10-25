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
public class UsedCreditCustomer : INotifyPropertyChanged
{
	private int retailStoreIDField;

	private string receiptKyanField;

	private string retailStoreNameField;

	private int? customerIDField;

	private string memberNumberField;

	private DateTime? transactionDateTimeField;

	private string fullNameField;

	private decimal? spentAmountField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
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

	[XmlElement(Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
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

	[XmlElement(Order = 4)]
	public string MemberNumber
	{
		get
		{
			return memberNumberField;
		}
		set
		{
			memberNumberField = value;
			RaisePropertyChanged("MemberNumber");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public DateTime? TransactionDateTime
	{
		get
		{
			return transactionDateTimeField;
		}
		set
		{
			transactionDateTimeField = value;
			RaisePropertyChanged("TransactionDateTime");
		}
	}

	[XmlElement(Order = 6)]
	public string FullName
	{
		get
		{
			return fullNameField;
		}
		set
		{
			fullNameField = value;
			RaisePropertyChanged("FullName");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public decimal? SpentAmount
	{
		get
		{
			return spentAmountField;
		}
		set
		{
			spentAmountField = value;
			RaisePropertyChanged("SpentAmount");
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
