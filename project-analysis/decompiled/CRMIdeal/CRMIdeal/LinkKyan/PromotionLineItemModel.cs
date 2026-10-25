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
public class PromotionLineItemModel : INotifyPropertyChanged
{
	private int promotionIDField;

	private string memberTypeField;

	private string decreaseTypeField;

	private decimal? decreaseAmountField;

	private int itemIDField;

	private int itemDepartmentIDField;

	private int propertyIDField;

	private int propertyValueIDField;

	private string propertyNameField;

	private string barCodeField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int PromotionID
	{
		get
		{
			return promotionIDField;
		}
		set
		{
			promotionIDField = value;
			RaisePropertyChanged("PromotionID");
		}
	}

	[XmlElement(Order = 1)]
	public string MemberType
	{
		get
		{
			return memberTypeField;
		}
		set
		{
			memberTypeField = value;
			RaisePropertyChanged("MemberType");
		}
	}

	[XmlElement(Order = 2)]
	public string DecreaseType
	{
		get
		{
			return decreaseTypeField;
		}
		set
		{
			decreaseTypeField = value;
			RaisePropertyChanged("DecreaseType");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? DecreaseAmount
	{
		get
		{
			return decreaseAmountField;
		}
		set
		{
			decreaseAmountField = value;
			RaisePropertyChanged("DecreaseAmount");
		}
	}

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
	public int ItemDepartmentID
	{
		get
		{
			return itemDepartmentIDField;
		}
		set
		{
			itemDepartmentIDField = value;
			RaisePropertyChanged("ItemDepartmentID");
		}
	}

	[XmlElement(Order = 6)]
	public int PropertyID
	{
		get
		{
			return propertyIDField;
		}
		set
		{
			propertyIDField = value;
			RaisePropertyChanged("PropertyID");
		}
	}

	[XmlElement(Order = 7)]
	public int PropertyValueID
	{
		get
		{
			return propertyValueIDField;
		}
		set
		{
			propertyValueIDField = value;
			RaisePropertyChanged("PropertyValueID");
		}
	}

	[XmlElement(Order = 8)]
	public string PropertyName
	{
		get
		{
			return propertyNameField;
		}
		set
		{
			propertyNameField = value;
			RaisePropertyChanged("PropertyName");
		}
	}

	[XmlElement(Order = 9)]
	public string BarCode
	{
		get
		{
			return barCodeField;
		}
		set
		{
			barCodeField = value;
			RaisePropertyChanged("BarCode");
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
