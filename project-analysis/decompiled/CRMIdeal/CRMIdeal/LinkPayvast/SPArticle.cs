using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace CRMIdeal.LinkPayvast;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class SPArticle : INotifyPropertyChanged
{
	private int sPFactorIdField;

	private int merchandiseIdField;

	private string merchandiseKeyField;

	private decimal amountField;

	private int unitIdField;

	private decimal auxAmountField;

	private decimal unitPriceField;

	private decimal vTaxField;

	private decimal discountField;

	private int stockRoomIdField;

	private string descriptionField;

	private string aCCField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int SPFactorId
	{
		get
		{
			return sPFactorIdField;
		}
		set
		{
			sPFactorIdField = value;
			RaisePropertyChanged("SPFactorId");
		}
	}

	[XmlElement(Order = 1)]
	public int MerchandiseId
	{
		get
		{
			return merchandiseIdField;
		}
		set
		{
			merchandiseIdField = value;
			RaisePropertyChanged("MerchandiseId");
		}
	}

	[XmlElement(Order = 2)]
	public string MerchandiseKey
	{
		get
		{
			return merchandiseKeyField;
		}
		set
		{
			merchandiseKeyField = value;
			RaisePropertyChanged("MerchandiseKey");
		}
	}

	[XmlElement(Order = 3)]
	public decimal Amount
	{
		get
		{
			return amountField;
		}
		set
		{
			amountField = value;
			RaisePropertyChanged("Amount");
		}
	}

	[XmlElement(Order = 4)]
	public int UnitId
	{
		get
		{
			return unitIdField;
		}
		set
		{
			unitIdField = value;
			RaisePropertyChanged("UnitId");
		}
	}

	[XmlElement(Order = 5)]
	public decimal AuxAmount
	{
		get
		{
			return auxAmountField;
		}
		set
		{
			auxAmountField = value;
			RaisePropertyChanged("AuxAmount");
		}
	}

	[XmlElement(Order = 6)]
	public decimal UnitPrice
	{
		get
		{
			return unitPriceField;
		}
		set
		{
			unitPriceField = value;
			RaisePropertyChanged("UnitPrice");
		}
	}

	[XmlElement(Order = 7)]
	public decimal VTax
	{
		get
		{
			return vTaxField;
		}
		set
		{
			vTaxField = value;
			RaisePropertyChanged("VTax");
		}
	}

	[XmlElement(Order = 8)]
	public decimal Discount
	{
		get
		{
			return discountField;
		}
		set
		{
			discountField = value;
			RaisePropertyChanged("Discount");
		}
	}

	[XmlElement(Order = 9)]
	public int StockRoomId
	{
		get
		{
			return stockRoomIdField;
		}
		set
		{
			stockRoomIdField = value;
			RaisePropertyChanged("StockRoomId");
		}
	}

	[XmlElement(Order = 10)]
	public string Description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
			RaisePropertyChanged("Description");
		}
	}

	[XmlElement(Order = 11)]
	public string ACC
	{
		get
		{
			return aCCField;
		}
		set
		{
			aCCField = value;
			RaisePropertyChanged("ACC");
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
