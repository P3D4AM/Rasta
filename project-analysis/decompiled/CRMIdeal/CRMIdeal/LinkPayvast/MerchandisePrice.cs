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
public class MerchandisePrice : INotifyPropertyChanged
{
	private int idField;

	private string codeField;

	private string nameField;

	private string technicalCodeField;

	private string barcodeField;

	private double price_1Field;

	private double price_2Field;

	private double price_3Field;

	private double price_4Field;

	private double price_5Field;

	private double price_6Field;

	private double price_7Field;

	private double price_8Field;

	private double price_9Field;

	private double price_10Field;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int Id
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("Id");
		}
	}

	[XmlElement(Order = 1)]
	public string Code
	{
		get
		{
			return codeField;
		}
		set
		{
			codeField = value;
			RaisePropertyChanged("Code");
		}
	}

	[XmlElement(Order = 2)]
	public string Name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
			RaisePropertyChanged("Name");
		}
	}

	[XmlElement(Order = 3)]
	public string TechnicalCode
	{
		get
		{
			return technicalCodeField;
		}
		set
		{
			technicalCodeField = value;
			RaisePropertyChanged("TechnicalCode");
		}
	}

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
	public double Price_1
	{
		get
		{
			return price_1Field;
		}
		set
		{
			price_1Field = value;
			RaisePropertyChanged("Price_1");
		}
	}

	[XmlElement(Order = 6)]
	public double Price_2
	{
		get
		{
			return price_2Field;
		}
		set
		{
			price_2Field = value;
			RaisePropertyChanged("Price_2");
		}
	}

	[XmlElement(Order = 7)]
	public double Price_3
	{
		get
		{
			return price_3Field;
		}
		set
		{
			price_3Field = value;
			RaisePropertyChanged("Price_3");
		}
	}

	[XmlElement(Order = 8)]
	public double Price_4
	{
		get
		{
			return price_4Field;
		}
		set
		{
			price_4Field = value;
			RaisePropertyChanged("Price_4");
		}
	}

	[XmlElement(Order = 9)]
	public double Price_5
	{
		get
		{
			return price_5Field;
		}
		set
		{
			price_5Field = value;
			RaisePropertyChanged("Price_5");
		}
	}

	[XmlElement(Order = 10)]
	public double Price_6
	{
		get
		{
			return price_6Field;
		}
		set
		{
			price_6Field = value;
			RaisePropertyChanged("Price_6");
		}
	}

	[XmlElement(Order = 11)]
	public double Price_7
	{
		get
		{
			return price_7Field;
		}
		set
		{
			price_7Field = value;
			RaisePropertyChanged("Price_7");
		}
	}

	[XmlElement(Order = 12)]
	public double Price_8
	{
		get
		{
			return price_8Field;
		}
		set
		{
			price_8Field = value;
			RaisePropertyChanged("Price_8");
		}
	}

	[XmlElement(Order = 13)]
	public double Price_9
	{
		get
		{
			return price_9Field;
		}
		set
		{
			price_9Field = value;
			RaisePropertyChanged("Price_9");
		}
	}

	[XmlElement(Order = 14)]
	public double Price_10
	{
		get
		{
			return price_10Field;
		}
		set
		{
			price_10Field = value;
			RaisePropertyChanged("Price_10");
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
