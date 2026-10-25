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
public class PosDepartmentList : INotifyPropertyChanged
{
	private int? level1IDField;

	private int? level2IDField;

	private int? level3IDField;

	private int? level4IDField;

	private string level1NameField;

	private string level2NameField;

	private string level3NameField;

	private string level4NameField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? Level1ID
	{
		get
		{
			return level1IDField;
		}
		set
		{
			level1IDField = value;
			RaisePropertyChanged("Level1ID");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? Level2ID
	{
		get
		{
			return level2IDField;
		}
		set
		{
			level2IDField = value;
			RaisePropertyChanged("Level2ID");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Level3ID
	{
		get
		{
			return level3IDField;
		}
		set
		{
			level3IDField = value;
			RaisePropertyChanged("Level3ID");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? Level4ID
	{
		get
		{
			return level4IDField;
		}
		set
		{
			level4IDField = value;
			RaisePropertyChanged("Level4ID");
		}
	}

	[XmlElement(Order = 4)]
	public string Level1Name
	{
		get
		{
			return level1NameField;
		}
		set
		{
			level1NameField = value;
			RaisePropertyChanged("Level1Name");
		}
	}

	[XmlElement(Order = 5)]
	public string Level2Name
	{
		get
		{
			return level2NameField;
		}
		set
		{
			level2NameField = value;
			RaisePropertyChanged("Level2Name");
		}
	}

	[XmlElement(Order = 6)]
	public string Level3Name
	{
		get
		{
			return level3NameField;
		}
		set
		{
			level3NameField = value;
			RaisePropertyChanged("Level3Name");
		}
	}

	[XmlElement(Order = 7)]
	public string Level4Name
	{
		get
		{
			return level4NameField;
		}
		set
		{
			level4NameField = value;
			RaisePropertyChanged("Level4Name");
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
