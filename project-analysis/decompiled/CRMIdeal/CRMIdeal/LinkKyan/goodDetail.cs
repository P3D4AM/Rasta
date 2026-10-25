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
public class goodDetail : INotifyPropertyChanged
{
	private int rowNumField;

	private int inventoryIDField;

	private int itmIDField;

	private string itmBrcdField;

	private string itmNameField;

	private string itemTypesField;

	private decimal itmPriceField;

	private decimal itmTempPriceField;

	private string tempPriceExpireDateField;

	private decimal? discountField;

	private decimal itmQuantityField;

	private bool taxableField;

	private decimal? userPriceField;

	private int? pOSDepartmentIDField;

	private string pOSDepartmentNameField;

	private string itemDescriptionField;

	private string itmStatusField;

	private decimal? jetPriceField;

	private decimal? jetQuatityTotalField;

	private decimal? jetQuatityRemainField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int RowNum
	{
		get
		{
			return rowNumField;
		}
		set
		{
			rowNumField = value;
			RaisePropertyChanged("RowNum");
		}
	}

	[XmlElement(Order = 1)]
	public int InventoryID
	{
		get
		{
			return inventoryIDField;
		}
		set
		{
			inventoryIDField = value;
			RaisePropertyChanged("InventoryID");
		}
	}

	[XmlElement(Order = 2)]
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

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
	public string ItemTypes
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

	[XmlElement(Order = 6)]
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

	[XmlElement(Order = 7)]
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

	[XmlElement(Order = 8)]
	public string TempPriceExpireDate
	{
		get
		{
			return tempPriceExpireDateField;
		}
		set
		{
			tempPriceExpireDateField = value;
			RaisePropertyChanged("TempPriceExpireDate");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? discount
	{
		get
		{
			return discountField;
		}
		set
		{
			discountField = value;
			RaisePropertyChanged("discount");
		}
	}

	[XmlElement(Order = 10)]
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

	[XmlElement(Order = 16)]
	public string itmStatus
	{
		get
		{
			return itmStatusField;
		}
		set
		{
			itmStatusField = value;
			RaisePropertyChanged("itmStatus");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public decimal? JetPrice
	{
		get
		{
			return jetPriceField;
		}
		set
		{
			jetPriceField = value;
			RaisePropertyChanged("JetPrice");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public decimal? JetQuatityTotal
	{
		get
		{
			return jetQuatityTotalField;
		}
		set
		{
			jetQuatityTotalField = value;
			RaisePropertyChanged("JetQuatityTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public decimal? JetQuatityRemain
	{
		get
		{
			return jetQuatityRemainField;
		}
		set
		{
			jetQuatityRemainField = value;
			RaisePropertyChanged("JetQuatityRemain");
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
