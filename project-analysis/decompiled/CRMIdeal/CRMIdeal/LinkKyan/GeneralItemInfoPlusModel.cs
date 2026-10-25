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
public class GeneralItemInfoPlusModel : INotifyPropertyChanged
{
	private int itemIDField;

	private string itemNameField;

	private string barcodeField;

	private decimal? priceField;

	private decimal? tempPriceField;

	private decimal? customerPriceField;

	private string itemTypeField;

	private string itemStatusField;

	private bool? taxAbleField;

	private decimal? quantityField;

	private DateTime? itemCreateDateField;

	private string itemDescriptionField;

	private int? posDepartmentIDField;

	private string posDepartmentNameField;

	private int? parentIdField;

	private string parentNameField;

	private string proprtyValue1Field;

	private string proprtyName1Field;

	private string proprtyValue2Field;

	private string proprtyName2Field;

	private string proprtyValue3Field;

	private string proprtyName3Field;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int ItemID
	{
		get
		{
			return itemIDField;
		}
		set
		{
			itemIDField = value;
			RaisePropertyChanged("ItemID");
		}
	}

	[XmlElement(Order = 1)]
	public string ItemName
	{
		get
		{
			return itemNameField;
		}
		set
		{
			itemNameField = value;
			RaisePropertyChanged("ItemName");
		}
	}

	[XmlElement(Order = 2)]
	public string Barcode
	{
		get
		{
			return barcodeField;
		}
		set
		{
			barcodeField = value;
			RaisePropertyChanged("Barcode");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? Price
	{
		get
		{
			return priceField;
		}
		set
		{
			priceField = value;
			RaisePropertyChanged("Price");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? TempPrice
	{
		get
		{
			return tempPriceField;
		}
		set
		{
			tempPriceField = value;
			RaisePropertyChanged("TempPrice");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public decimal? CustomerPrice
	{
		get
		{
			return customerPriceField;
		}
		set
		{
			customerPriceField = value;
			RaisePropertyChanged("CustomerPrice");
		}
	}

	[XmlElement(Order = 6)]
	public string ItemType
	{
		get
		{
			return itemTypeField;
		}
		set
		{
			itemTypeField = value;
			RaisePropertyChanged("ItemType");
		}
	}

	[XmlElement(Order = 7)]
	public string ItemStatus
	{
		get
		{
			return itemStatusField;
		}
		set
		{
			itemStatusField = value;
			RaisePropertyChanged("ItemStatus");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public bool? TaxAble
	{
		get
		{
			return taxAbleField;
		}
		set
		{
			taxAbleField = value;
			RaisePropertyChanged("TaxAble");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? Quantity
	{
		get
		{
			return quantityField;
		}
		set
		{
			quantityField = value;
			RaisePropertyChanged("Quantity");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public DateTime? itemCreateDate
	{
		get
		{
			return itemCreateDateField;
		}
		set
		{
			itemCreateDateField = value;
			RaisePropertyChanged("itemCreateDate");
		}
	}

	[XmlElement(Order = 11)]
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

	[XmlElement(IsNullable = true, Order = 12)]
	public int? PosDepartmentID
	{
		get
		{
			return posDepartmentIDField;
		}
		set
		{
			posDepartmentIDField = value;
			RaisePropertyChanged("PosDepartmentID");
		}
	}

	[XmlElement(Order = 13)]
	public string PosDepartmentName
	{
		get
		{
			return posDepartmentNameField;
		}
		set
		{
			posDepartmentNameField = value;
			RaisePropertyChanged("PosDepartmentName");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
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

	[XmlElement(Order = 15)]
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

	[XmlElement(Order = 16)]
	public string ProprtyValue1
	{
		get
		{
			return proprtyValue1Field;
		}
		set
		{
			proprtyValue1Field = value;
			RaisePropertyChanged("ProprtyValue1");
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
	public string ProprtyValue2
	{
		get
		{
			return proprtyValue2Field;
		}
		set
		{
			proprtyValue2Field = value;
			RaisePropertyChanged("ProprtyValue2");
		}
	}

	[XmlElement(Order = 19)]
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

	[XmlElement(Order = 20)]
	public string ProprtyValue3
	{
		get
		{
			return proprtyValue3Field;
		}
		set
		{
			proprtyValue3Field = value;
			RaisePropertyChanged("ProprtyValue3");
		}
	}

	[XmlElement(Order = 21)]
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
