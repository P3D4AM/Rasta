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
public class CustomerAddress : INotifyPropertyChanged
{
	private string addressTypeField;

	private string addressTypeIdField;

	private string firstNameField;

	private string lastNameField;

	private string addressIDField;

	private string cityField;

	private string stateField;

	private string phoneField;

	private string mobileField;

	private string postalcodeField;

	private string addressField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public string AddressType
	{
		get
		{
			return addressTypeField;
		}
		set
		{
			addressTypeField = value;
			RaisePropertyChanged("AddressType");
		}
	}

	[XmlElement(Order = 1)]
	public string AddressTypeId
	{
		get
		{
			return addressTypeIdField;
		}
		set
		{
			addressTypeIdField = value;
			RaisePropertyChanged("AddressTypeId");
		}
	}

	[XmlElement(Order = 2)]
	public string FirstName
	{
		get
		{
			return firstNameField;
		}
		set
		{
			firstNameField = value;
			RaisePropertyChanged("FirstName");
		}
	}

	[XmlElement(Order = 3)]
	public string LastName
	{
		get
		{
			return lastNameField;
		}
		set
		{
			lastNameField = value;
			RaisePropertyChanged("LastName");
		}
	}

	[XmlElement(Order = 4)]
	public string AddressID
	{
		get
		{
			return addressIDField;
		}
		set
		{
			addressIDField = value;
			RaisePropertyChanged("AddressID");
		}
	}

	[XmlElement(Order = 5)]
	public string City
	{
		get
		{
			return cityField;
		}
		set
		{
			cityField = value;
			RaisePropertyChanged("City");
		}
	}

	[XmlElement(Order = 6)]
	public string State
	{
		get
		{
			return stateField;
		}
		set
		{
			stateField = value;
			RaisePropertyChanged("State");
		}
	}

	[XmlElement(Order = 7)]
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

	[XmlElement(Order = 8)]
	public string Mobile
	{
		get
		{
			return mobileField;
		}
		set
		{
			mobileField = value;
			RaisePropertyChanged("Mobile");
		}
	}

	[XmlElement(Order = 9)]
	public string Postalcode
	{
		get
		{
			return postalcodeField;
		}
		set
		{
			postalcodeField = value;
			RaisePropertyChanged("Postalcode");
		}
	}

	[XmlElement(Order = 10)]
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
