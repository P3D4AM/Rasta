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
public class Customer : INotifyPropertyChanged
{
	private int idField;

	private string nameField;

	private string forenameField;

	private string surnameField;

	private string titleField;

	private string nationalCodeField;

	private string fatherName_CEOField;

	private int mainTypeCodeField;

	private string mainTypeField;

	private string cellPhoneField;

	private string phoneField;

	private string faxField;

	private string economyCodeField;

	private string addressField;

	private string postalCodeField;

	private string eMailField;

	private string accountIdField;

	private int groupField;

	private bool foreignNationalField;

	private string countryCodeField;

	private string countryNameField;

	private string provinceCodeField;

	private string provinceNameField;

	private string cityCodeField;

	private string cityNameField;

	private string floatingAccount1Field;

	private string floatingAccount2Field;

	private string floatingAccount3Field;

	private int salePriceTypeField;

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

	[XmlElement(Order = 2)]
	public string Forename
	{
		get
		{
			return forenameField;
		}
		set
		{
			forenameField = value;
			RaisePropertyChanged("Forename");
		}
	}

	[XmlElement(Order = 3)]
	public string Surname
	{
		get
		{
			return surnameField;
		}
		set
		{
			surnameField = value;
			RaisePropertyChanged("Surname");
		}
	}

	[XmlElement(Order = 4)]
	public string Title
	{
		get
		{
			return titleField;
		}
		set
		{
			titleField = value;
			RaisePropertyChanged("Title");
		}
	}

	[XmlElement(Order = 5)]
	public string NationalCode
	{
		get
		{
			return nationalCodeField;
		}
		set
		{
			nationalCodeField = value;
			RaisePropertyChanged("NationalCode");
		}
	}

	[XmlElement(Order = 6)]
	public string FatherName_CEO
	{
		get
		{
			return fatherName_CEOField;
		}
		set
		{
			fatherName_CEOField = value;
			RaisePropertyChanged("FatherName_CEO");
		}
	}

	[XmlElement(Order = 7)]
	public int MainTypeCode
	{
		get
		{
			return mainTypeCodeField;
		}
		set
		{
			mainTypeCodeField = value;
			RaisePropertyChanged("MainTypeCode");
		}
	}

	[XmlElement(Order = 8)]
	public string MainType
	{
		get
		{
			return mainTypeField;
		}
		set
		{
			mainTypeField = value;
			RaisePropertyChanged("MainType");
		}
	}

	[XmlElement(Order = 9)]
	public string CellPhone
	{
		get
		{
			return cellPhoneField;
		}
		set
		{
			cellPhoneField = value;
			RaisePropertyChanged("CellPhone");
		}
	}

	[XmlElement(Order = 10)]
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

	[XmlElement(Order = 11)]
	public string Fax
	{
		get
		{
			return faxField;
		}
		set
		{
			faxField = value;
			RaisePropertyChanged("Fax");
		}
	}

	[XmlElement(Order = 12)]
	public string EconomyCode
	{
		get
		{
			return economyCodeField;
		}
		set
		{
			economyCodeField = value;
			RaisePropertyChanged("EconomyCode");
		}
	}

	[XmlElement(Order = 13)]
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

	[XmlElement(Order = 14)]
	public string PostalCode
	{
		get
		{
			return postalCodeField;
		}
		set
		{
			postalCodeField = value;
			RaisePropertyChanged("PostalCode");
		}
	}

	[XmlElement(Order = 15)]
	public string EMail
	{
		get
		{
			return eMailField;
		}
		set
		{
			eMailField = value;
			RaisePropertyChanged("EMail");
		}
	}

	[XmlElement(Order = 16)]
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

	[XmlElement(Order = 17)]
	public int Group
	{
		get
		{
			return groupField;
		}
		set
		{
			groupField = value;
			RaisePropertyChanged("Group");
		}
	}

	[XmlElement(Order = 18)]
	public bool ForeignNational
	{
		get
		{
			return foreignNationalField;
		}
		set
		{
			foreignNationalField = value;
			RaisePropertyChanged("ForeignNational");
		}
	}

	[XmlElement(Order = 19)]
	public string CountryCode
	{
		get
		{
			return countryCodeField;
		}
		set
		{
			countryCodeField = value;
			RaisePropertyChanged("CountryCode");
		}
	}

	[XmlElement(Order = 20)]
	public string CountryName
	{
		get
		{
			return countryNameField;
		}
		set
		{
			countryNameField = value;
			RaisePropertyChanged("CountryName");
		}
	}

	[XmlElement(Order = 21)]
	public string ProvinceCode
	{
		get
		{
			return provinceCodeField;
		}
		set
		{
			provinceCodeField = value;
			RaisePropertyChanged("ProvinceCode");
		}
	}

	[XmlElement(Order = 22)]
	public string ProvinceName
	{
		get
		{
			return provinceNameField;
		}
		set
		{
			provinceNameField = value;
			RaisePropertyChanged("ProvinceName");
		}
	}

	[XmlElement(Order = 23)]
	public string CityCode
	{
		get
		{
			return cityCodeField;
		}
		set
		{
			cityCodeField = value;
			RaisePropertyChanged("CityCode");
		}
	}

	[XmlElement(Order = 24)]
	public string CityName
	{
		get
		{
			return cityNameField;
		}
		set
		{
			cityNameField = value;
			RaisePropertyChanged("CityName");
		}
	}

	[XmlElement(Order = 25)]
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

	[XmlElement(Order = 26)]
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

	[XmlElement(Order = 27)]
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

	[XmlElement(Order = 28)]
	public int SalePriceType
	{
		get
		{
			return salePriceTypeField;
		}
		set
		{
			salePriceTypeField = value;
			RaisePropertyChanged("SalePriceType");
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
