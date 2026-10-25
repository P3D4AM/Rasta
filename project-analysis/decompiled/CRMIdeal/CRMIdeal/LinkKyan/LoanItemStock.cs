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
public class LoanItemStock : INotifyPropertyChanged
{
	private int itemIDField;

	private string itemBarcodeField;

	private decimal quantitiyField;

	private int loanIDField;

	private int retailStoreIDField;

	private string loanNameField;

	private string retailStoreNameField;

	private string[] serialField;

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

	[XmlElement(Order = 1)]
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

	[XmlElement(Order = 2)]
	public decimal Quantitiy
	{
		get
		{
			return quantitiyField;
		}
		set
		{
			quantitiyField = value;
			RaisePropertyChanged("Quantitiy");
		}
	}

	[XmlElement(Order = 3)]
	public int LoanID
	{
		get
		{
			return loanIDField;
		}
		set
		{
			loanIDField = value;
			RaisePropertyChanged("LoanID");
		}
	}

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
	public string LoanName
	{
		get
		{
			return loanNameField;
		}
		set
		{
			loanNameField = value;
			RaisePropertyChanged("LoanName");
		}
	}

	[XmlElement(Order = 6)]
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

	[XmlArray(Order = 7)]
	public string[] Serial
	{
		get
		{
			return serialField;
		}
		set
		{
			serialField = value;
			RaisePropertyChanged("Serial");
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
