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
public class Check : INotifyPropertyChanged
{
	private int idField;

	private string numberField;

	private int typeField;

	private int subTypeField;

	private int statusIdField;

	private string statusField;

	private double amountField;

	private int customerIdField;

	private string accountField;

	private DateTime dueDateField;

	private string draweeBankNameField;

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
	public string Number
	{
		get
		{
			return numberField;
		}
		set
		{
			numberField = value;
			RaisePropertyChanged("Number");
		}
	}

	[XmlElement(Order = 2)]
	public int Type
	{
		get
		{
			return typeField;
		}
		set
		{
			typeField = value;
			RaisePropertyChanged("Type");
		}
	}

	[XmlElement(Order = 3)]
	public int SubType
	{
		get
		{
			return subTypeField;
		}
		set
		{
			subTypeField = value;
			RaisePropertyChanged("SubType");
		}
	}

	[XmlElement(Order = 4)]
	public int StatusId
	{
		get
		{
			return statusIdField;
		}
		set
		{
			statusIdField = value;
			RaisePropertyChanged("StatusId");
		}
	}

	[XmlElement(Order = 5)]
	public string Status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("Status");
		}
	}

	[XmlElement(Order = 6)]
	public double Amount
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

	[XmlElement(Order = 7)]
	public int CustomerId
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

	[XmlElement(Order = 8)]
	public string Account
	{
		get
		{
			return accountField;
		}
		set
		{
			accountField = value;
			RaisePropertyChanged("Account");
		}
	}

	[XmlElement(Order = 9)]
	public DateTime DueDate
	{
		get
		{
			return dueDateField;
		}
		set
		{
			dueDateField = value;
			RaisePropertyChanged("DueDate");
		}
	}

	[XmlElement(Order = 10)]
	public string DraweeBankName
	{
		get
		{
			return draweeBankNameField;
		}
		set
		{
			draweeBankNameField = value;
			RaisePropertyChanged("DraweeBankName");
		}
	}

	[XmlElement(Order = 11)]
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
