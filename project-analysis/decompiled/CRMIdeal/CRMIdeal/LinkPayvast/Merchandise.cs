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
public class Merchandise : INotifyPropertyChanged
{
	private int idField;

	private string codeField;

	private string nameField;

	private string englishNameField;

	private string technicalCodeField;

	private string barcodeField;

	private string iranCodeField;

	private int unitIdField;

	private string unitField;

	private int fiscalPeriodField;

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
	public string EnglishName
	{
		get
		{
			return englishNameField;
		}
		set
		{
			englishNameField = value;
			RaisePropertyChanged("EnglishName");
		}
	}

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
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

	[XmlElement(Order = 6)]
	public string IranCode
	{
		get
		{
			return iranCodeField;
		}
		set
		{
			iranCodeField = value;
			RaisePropertyChanged("IranCode");
		}
	}

	[XmlElement(Order = 7)]
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

	[XmlElement(Order = 8)]
	public string Unit
	{
		get
		{
			return unitField;
		}
		set
		{
			unitField = value;
			RaisePropertyChanged("Unit");
		}
	}

	[XmlElement(Order = 9)]
	public int FiscalPeriod
	{
		get
		{
			return fiscalPeriodField;
		}
		set
		{
			fiscalPeriodField = value;
			RaisePropertyChanged("FiscalPeriod");
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
