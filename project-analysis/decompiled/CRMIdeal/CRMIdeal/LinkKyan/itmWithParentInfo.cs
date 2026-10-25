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
public class itmWithParentInfo : INotifyPropertyChanged
{
	private int itmIDField;

	private string zQ_DS_BRCDField;

	private string itmNameField;

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

	private int? parentIdField;

	private string parentNameField;

	private string proprtyName1Field;

	private string proprtyName2Field;

	private string proprtyName3Field;

	private string itemStatField;

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
	public string ZQ_DS_BRCD
	{
		get
		{
			return zQ_DS_BRCDField;
		}
		set
		{
			zQ_DS_BRCDField = value;
			RaisePropertyChanged("ZQ_DS_BRCD");
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

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
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

	[XmlElement(Order = 6)]
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

	[XmlElement(Order = 7)]
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

	[XmlElement(Order = 8)]
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

	[XmlElement(Order = 9)]
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

	[XmlElement(Order = 10)]
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

	[XmlElement(IsNullable = true, Order = 11)]
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

	[XmlElement(IsNullable = true, Order = 12)]
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

	[XmlElement(Order = 13)]
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

	[XmlElement(Order = 14)]
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

	[XmlElement(IsNullable = true, Order = 15)]
	public int? ParentId
	{
		get
		{
			return parentIdField;
		}
		set
		{
			parentIdField = value;
			RaisePropertyChanged("ParentId");
		}
	}

	[XmlElement(Order = 16)]
	public string ParentName
	{
		get
		{
			return parentNameField;
		}
		set
		{
			parentNameField = value;
			RaisePropertyChanged("ParentName");
		}
	}

	[XmlElement(Order = 17)]
	public string ProprtyName1
	{
		get
		{
			return proprtyName1Field;
		}
		set
		{
			proprtyName1Field = value;
			RaisePropertyChanged("ProprtyName1");
		}
	}

	[XmlElement(Order = 18)]
	public string ProprtyName2
	{
		get
		{
			return proprtyName2Field;
		}
		set
		{
			proprtyName2Field = value;
			RaisePropertyChanged("ProprtyName2");
		}
	}

	[XmlElement(Order = 19)]
	public string ProprtyName3
	{
		get
		{
			return proprtyName3Field;
		}
		set
		{
			proprtyName3Field = value;
			RaisePropertyChanged("ProprtyName3");
		}
	}

	[XmlElement(Order = 20)]
	public string ItemStat
	{
		get
		{
			return itemStatField;
		}
		set
		{
			itemStatField = value;
			RaisePropertyChanged("ItemStat");
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
