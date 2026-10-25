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
public class AccountTransaction : INotifyPropertyChanged
{
	private string accountIdField;

	private string accountNameField;

	private int transactionNumberField;

	private DateTime transactionDateField;

	private string articleDescrioptionField;

	private double debitField;

	private double creditField;

	private int codeOrgField;

	private string nameOrgField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
	public string AccountName
	{
		get
		{
			return accountNameField;
		}
		set
		{
			accountNameField = value;
			RaisePropertyChanged("AccountName");
		}
	}

	[XmlElement(Order = 2)]
	public int TransactionNumber
	{
		get
		{
			return transactionNumberField;
		}
		set
		{
			transactionNumberField = value;
			RaisePropertyChanged("TransactionNumber");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
	public string ArticleDescrioption
	{
		get
		{
			return articleDescrioptionField;
		}
		set
		{
			articleDescrioptionField = value;
			RaisePropertyChanged("ArticleDescrioption");
		}
	}

	[XmlElement(Order = 5)]
	public double Debit
	{
		get
		{
			return debitField;
		}
		set
		{
			debitField = value;
			RaisePropertyChanged("Debit");
		}
	}

	[XmlElement(Order = 6)]
	public double Credit
	{
		get
		{
			return creditField;
		}
		set
		{
			creditField = value;
			RaisePropertyChanged("Credit");
		}
	}

	[XmlElement(Order = 7)]
	public int CodeOrg
	{
		get
		{
			return codeOrgField;
		}
		set
		{
			codeOrgField = value;
			RaisePropertyChanged("CodeOrg");
		}
	}

	[XmlElement(Order = 8)]
	public string NameOrg
	{
		get
		{
			return nameOrgField;
		}
		set
		{
			nameOrgField = value;
			RaisePropertyChanged("NameOrg");
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
