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
public class customerGroup : INotifyPropertyChanged
{
	private int groupIDField;

	private int? levelIDField;

	private int? groupTypeIDField;

	private string groupNameField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int GroupID
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

	[XmlElement(IsNullable = true, Order = 1)]
	public int? LevelID
	{
		get
		{
			return levelIDField;
		}
		set
		{
			levelIDField = value;
			RaisePropertyChanged("LevelID");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? GroupTypeID
	{
		get
		{
			return groupTypeIDField;
		}
		set
		{
			groupTypeIDField = value;
			RaisePropertyChanged("GroupTypeID");
		}
	}

	[XmlElement(Order = 3)]
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
