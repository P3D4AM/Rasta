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
public class StockRoom : INotifyPropertyChanged
{
	private int idField;

	private int codeField;

	private string nameField;

	private string accountIdField;

	private int floatingAccount1Field;

	private int floatingAccount2Field;

	private int floatingAccount3Field;

	private int floatingAccount4Field;

	private int floatingAccount5Field;

	private string managerNameField;

	private string descriptionField;

	private int fiscalPeriodIdField;

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
	public int Code
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
	public string AccountId
	{
		get
		{
			return accountIdField;
		}
		set
		{
			accountIdField = value;
			RaisePropertyChanged("AccountId");
		}
	}

	[XmlElement(Order = 4)]
	public int FloatingAccount1
	{
		get
		{
			return floatingAccount1Field;
		}
		set
		{
			floatingAccount1Field = value;
			RaisePropertyChanged("FloatingAccount1");
		}
	}

	[XmlElement(Order = 5)]
	public int FloatingAccount2
	{
		get
		{
			return floatingAccount2Field;
		}
		set
		{
			floatingAccount2Field = value;
			RaisePropertyChanged("FloatingAccount2");
		}
	}

	[XmlElement(Order = 6)]
	public int FloatingAccount3
	{
		get
		{
			return floatingAccount3Field;
		}
		set
		{
			floatingAccount3Field = value;
			RaisePropertyChanged("FloatingAccount3");
		}
	}

	[XmlElement(Order = 7)]
	public int FloatingAccount4
	{
		get
		{
			return floatingAccount4Field;
		}
		set
		{
			floatingAccount4Field = value;
			RaisePropertyChanged("FloatingAccount4");
		}
	}

	[XmlElement(Order = 8)]
	public int FloatingAccount5
	{
		get
		{
			return floatingAccount5Field;
		}
		set
		{
			floatingAccount5Field = value;
			RaisePropertyChanged("FloatingAccount5");
		}
	}

	[XmlElement(Order = 9)]
	public string ManagerName
	{
		get
		{
			return managerNameField;
		}
		set
		{
			managerNameField = value;
			RaisePropertyChanged("ManagerName");
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
	public int FiscalPeriodId
	{
		get
		{
			return fiscalPeriodIdField;
		}
		set
		{
			fiscalPeriodIdField = value;
			RaisePropertyChanged("FiscalPeriodId");
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
