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
public class SPFactor : INotifyPropertyChanged
{
	private int idField;

	private int factorNumberField;

	private DateTime dateField;

	private int customerIdField;

	private string descriptionField;

	private string customString1Field;

	private SPArticle[] articlesField;

	private string accountField;

	private string floatingAccount1Field;

	private string floatingAccount2Field;

	private string floatingAccount3Field;

	private int factorTypeField;

	private int scField;

	private int brokerIdField;

	private decimal totalField;

	private decimal discountField;

	private string referenceNoField;

	private DateTime payRcvDateField;

	private int payRcvTypeField;

	private int creatorUserIdField;

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
	public int FactorNumber
	{
		get
		{
			return factorNumberField;
		}
		set
		{
			factorNumberField = value;
			RaisePropertyChanged("FactorNumber");
		}
	}

	[XmlElement(Order = 2)]
	public DateTime Date
	{
		get
		{
			return dateField;
		}
		set
		{
			dateField = value;
			RaisePropertyChanged("Date");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
	public string CustomString1
	{
		get
		{
			return customString1Field;
		}
		set
		{
			customString1Field = value;
			RaisePropertyChanged("CustomString1");
		}
	}

	[XmlArray(Order = 6)]
	public SPArticle[] Articles
	{
		get
		{
			return articlesField;
		}
		set
		{
			articlesField = value;
			RaisePropertyChanged("Articles");
		}
	}

	[XmlElement(Order = 7)]
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

	[XmlElement(Order = 8)]
	public string FloatingAccount1
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

	[XmlElement(Order = 9)]
	public string FloatingAccount2
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

	[XmlElement(Order = 10)]
	public string FloatingAccount3
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

	[XmlElement(Order = 11)]
	public int FactorType
	{
		get
		{
			return factorTypeField;
		}
		set
		{
			factorTypeField = value;
			RaisePropertyChanged("FactorType");
		}
	}

	[XmlElement(Order = 12)]
	public int SC
	{
		get
		{
			return scField;
		}
		set
		{
			scField = value;
			RaisePropertyChanged("SC");
		}
	}

	[XmlElement(Order = 13)]
	public int BrokerId
	{
		get
		{
			return brokerIdField;
		}
		set
		{
			brokerIdField = value;
			RaisePropertyChanged("BrokerId");
		}
	}

	[XmlElement(Order = 14)]
	public decimal Total
	{
		get
		{
			return totalField;
		}
		set
		{
			totalField = value;
			RaisePropertyChanged("Total");
		}
	}

	[XmlElement(Order = 15)]
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

	[XmlElement(Order = 16)]
	public string ReferenceNo
	{
		get
		{
			return referenceNoField;
		}
		set
		{
			referenceNoField = value;
			RaisePropertyChanged("ReferenceNo");
		}
	}

	[XmlElement(Order = 17)]
	public DateTime PayRcvDate
	{
		get
		{
			return payRcvDateField;
		}
		set
		{
			payRcvDateField = value;
			RaisePropertyChanged("PayRcvDate");
		}
	}

	[XmlElement(Order = 18)]
	public int PayRcvType
	{
		get
		{
			return payRcvTypeField;
		}
		set
		{
			payRcvTypeField = value;
			RaisePropertyChanged("PayRcvType");
		}
	}

	[XmlElement(Order = 19)]
	public int CreatorUserId
	{
		get
		{
			return creatorUserIdField;
		}
		set
		{
			creatorUserIdField = value;
			RaisePropertyChanged("CreatorUserId");
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
