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
public class itm : INotifyPropertyChanged
{
	private int itmIDField;

	private string itmBrcdField;

	private string itmNameField;

	private string[] serialsField;

	private ItemType itemTypesField;

	private decimal itmPriceField;

	private decimal itmTempPriceField;

	private decimal itmRsGrpPriceField;

	private decimal itmRsGrpTempPriceField;

	private decimal itmQuantityField;

	private string itmCreateDateField;

	private bool taxableField;

	private decimal? userPriceField;

	private int? pOSDepartmentIDField;

	private string pOSDepartmentNameField;

	private string itemDescriptionField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int itmID
	{
		get
		{
			return itmIDField;
		}
		set
		{
			itmIDField = value;
			RaisePropertyChanged("itmID");
		}
	}

	[XmlElement(Order = 1)]
	public string itmBrcd
	{
		get
		{
			return itmBrcdField;
		}
		set
		{
			itmBrcdField = value;
			RaisePropertyChanged("itmBrcd");
		}
	}

	[XmlElement(Order = 2)]
	public string itmName
	{
		get
		{
			return itmNameField;
		}
		set
		{
			itmNameField = value;
			RaisePropertyChanged("itmName");
		}
	}

	[XmlArray(Order = 3)]
	public string[] serials
	{
		get
		{
			return serialsField;
		}
		set
		{
			serialsField = value;
			RaisePropertyChanged("serials");
		}
	}

	[XmlElement(Order = 4)]
	public ItemType ItemTypes
	{
		get
		{
			return itemTypesField;
		}
		set
		{
			itemTypesField = value;
			RaisePropertyChanged("ItemTypes");
		}
	}

	[XmlElement(Order = 5)]
	public decimal itmPrice
	{
		get
		{
			return itmPriceField;
		}
		set
		{
			itmPriceField = value;
			RaisePropertyChanged("itmPrice");
		}
	}

	[XmlElement(Order = 6)]
	public decimal itmTempPrice
	{
		get
		{
			return itmTempPriceField;
		}
		set
		{
			itmTempPriceField = value;
			RaisePropertyChanged("itmTempPrice");
		}
	}

	[XmlElement(Order = 7)]
	public decimal itmRsGrpPrice
	{
		get
		{
			return itmRsGrpPriceField;
		}
		set
		{
			itmRsGrpPriceField = value;
			RaisePropertyChanged("itmRsGrpPrice");
		}
	}

	[XmlElement(Order = 8)]
	public decimal itmRsGrpTempPrice
	{
		get
		{
			return itmRsGrpTempPriceField;
		}
		set
		{
			itmRsGrpTempPriceField = value;
			RaisePropertyChanged("itmRsGrpTempPrice");
		}
	}

	[XmlElement(Order = 9)]
	public decimal itmQuantity
	{
		get
		{
			return itmQuantityField;
		}
		set
		{
			itmQuantityField = value;
			RaisePropertyChanged("itmQuantity");
		}
	}

	[XmlElement(Order = 10)]
	public string itmCreateDate
	{
		get
		{
			return itmCreateDateField;
		}
		set
		{
			itmCreateDateField = value;
			RaisePropertyChanged("itmCreateDate");
		}
	}

	[XmlElement(Order = 11)]
	public bool Taxable
	{
		get
		{
			return taxableField;
		}
		set
		{
			taxableField = value;
			RaisePropertyChanged("Taxable");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public decimal? UserPrice
	{
		get
		{
			return userPriceField;
		}
		set
		{
			userPriceField = value;
			RaisePropertyChanged("UserPrice");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public int? POSDepartmentID
	{
		get
		{
			return pOSDepartmentIDField;
		}
		set
		{
			pOSDepartmentIDField = value;
			RaisePropertyChanged("POSDepartmentID");
		}
	}

	[XmlElement(Order = 14)]
	public string POSDepartmentName
	{
		get
		{
			return pOSDepartmentNameField;
		}
		set
		{
			pOSDepartmentNameField = value;
			RaisePropertyChanged("POSDepartmentName");
		}
	}

	[XmlElement(Order = 15)]
	public string ItemDescription
	{
		get
		{
			return itemDescriptionField;
		}
		set
		{
			itemDescriptionField = value;
			RaisePropertyChanged("ItemDescription");
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
