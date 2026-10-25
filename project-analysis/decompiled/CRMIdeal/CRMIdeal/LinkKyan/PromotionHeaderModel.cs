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
public class PromotionHeaderModel : INotifyPropertyChanged
{
	private int promotionIDField;

	private string promotionNameField;

	private string joinableTypeField;

	private DateTime startDateField;

	private DateTime endDateField;

	private string promotionTypeField;

	private string promotionStateField;

	private int? retailstoreGroupIDField;

	private string thresholdTypeField;

	private decimal? thresholdValueField;

	private PromotionLineItemModel[] promotionLineItemField;

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
	public string PromotionName
	{
		get
		{
			return promotionNameField;
		}
		set
		{
			promotionNameField = value;
			RaisePropertyChanged("PromotionName");
		}
	}

	[XmlElement(Order = 2)]
	public string JoinableType
	{
		get
		{
			return joinableTypeField;
		}
		set
		{
			joinableTypeField = value;
			RaisePropertyChanged("JoinableType");
		}
	}

	[XmlElement(Order = 3)]
	public DateTime StartDate
	{
		get
		{
			return startDateField;
		}
		set
		{
			startDateField = value;
			RaisePropertyChanged("StartDate");
		}
	}

	[XmlElement(Order = 4)]
	public DateTime EndDate
	{
		get
		{
			return endDateField;
		}
		set
		{
			endDateField = value;
			RaisePropertyChanged("EndDate");
		}
	}

	[XmlElement(Order = 5)]
	public string PromotionType
	{
		get
		{
			return promotionTypeField;
		}
		set
		{
			promotionTypeField = value;
			RaisePropertyChanged("PromotionType");
		}
	}

	[XmlElement(Order = 6)]
	public string PromotionState
	{
		get
		{
			return promotionStateField;
		}
		set
		{
			promotionStateField = value;
			RaisePropertyChanged("PromotionState");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? RetailstoreGroupID
	{
		get
		{
			return retailstoreGroupIDField;
		}
		set
		{
			retailstoreGroupIDField = value;
			RaisePropertyChanged("RetailstoreGroupID");
		}
	}

	[XmlElement(Order = 8)]
	public string ThresholdType
	{
		get
		{
			return thresholdTypeField;
		}
		set
		{
			thresholdTypeField = value;
			RaisePropertyChanged("ThresholdType");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? ThresholdValue
	{
		get
		{
			return thresholdValueField;
		}
		set
		{
			thresholdValueField = value;
			RaisePropertyChanged("ThresholdValue");
		}
	}

	[XmlArray(Order = 10)]
	public PromotionLineItemModel[] PromotionLineItem
	{
		get
		{
			return promotionLineItemField;
		}
		set
		{
			promotionLineItemField = value;
			RaisePropertyChanged("PromotionLineItem");
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
