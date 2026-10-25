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
public class Customer : INotifyPropertyChanged
{
	private int customerIDField;

	private string memberIDField;

	private string customerFirstNameField;

	private string customerLastNameField;

	private string emailField;

	private string noteField;

	private decimal? pointField;

	private decimal? creditField;

	private string phoneField;

	private string addressField;

	private int? groupIDField;

	private string groupNameField;

	private string birthDayDateField;

	private int genderField;

	private string socialSecurityNumberField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int customerID
	{
		get
		{
			return customerIDField;
		}
		set
		{
			customerIDField = value;
			RaisePropertyChanged("customerID");
		}
	}

	[XmlElement(Order = 1)]
	public string MemberID
	{
		get
		{
			return memberIDField;
		}
		set
		{
			memberIDField = value;
			RaisePropertyChanged("MemberID");
		}
	}

	[XmlElement(Order = 2)]
	public string customerFirstName
	{
		get
		{
			return customerFirstNameField;
		}
		set
		{
			customerFirstNameField = value;
			RaisePropertyChanged("customerFirstName");
		}
	}

	[XmlElement(Order = 3)]
	public string customerLastName
	{
		get
		{
			return customerLastNameField;
		}
		set
		{
			customerLastNameField = value;
			RaisePropertyChanged("customerLastName");
		}
	}

	[XmlElement(Order = 4)]
	public string Email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
			RaisePropertyChanged("Email");
		}
	}

	[XmlElement(Order = 5)]
	public string Note
	{
		get
		{
			return noteField;
		}
		set
		{
			noteField = value;
			RaisePropertyChanged("Note");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public decimal? Point
	{
		get
		{
			return pointField;
		}
		set
		{
			pointField = value;
			RaisePropertyChanged("Point");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public decimal? Credit
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

	[XmlElement(Order = 8)]
	public string Phone
	{
		get
		{
			return phoneField;
		}
		set
		{
			phoneField = value;
			RaisePropertyChanged("Phone");
		}
	}

	[XmlElement(Order = 9)]
	public string Address
	{
		get
		{
			return addressField;
		}
		set
		{
			addressField = value;
			RaisePropertyChanged("Address");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? GroupID
	{
		get
		{
			return groupIDField;
		}
		set
		{
			groupIDField = value;
			RaisePropertyChanged("GroupID");
		}
	}

	[XmlElement(Order = 11)]
	public string GroupName
	{
		get
		{
			return groupNameField;
		}
		set
		{
			groupNameField = value;
			RaisePropertyChanged("GroupName");
		}
	}

	[XmlElement(Order = 12)]
	public string BirthDayDate
	{
		get
		{
			return birthDayDateField;
		}
		set
		{
			birthDayDateField = value;
			RaisePropertyChanged("BirthDayDate");
		}
	}

	[XmlElement(Order = 13)]
	public int Gender
	{
		get
		{
			return genderField;
		}
		set
		{
			genderField = value;
			RaisePropertyChanged("Gender");
		}
	}

	[XmlElement(Order = 14)]
	public string SocialSecurityNumber
	{
		get
		{
			return socialSecurityNumberField;
		}
		set
		{
			socialSecurityNumberField = value;
			RaisePropertyChanged("SocialSecurityNumber");
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
