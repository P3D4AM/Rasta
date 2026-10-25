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
public class CustomerCredit : INotifyPropertyChanged
{
	private double creditField;

	private double accountBalanceField;

	private double notesReceivableField;

	private double bouncedChecksBalanceField;

	private double creditBalanceField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public double Credit
	{
		get
		{
			return creditField;
		}
		set
		{
			creditField = value;
			RaisePropertyChanged("Credit");
		}
	}

	[XmlElement(Order = 1)]
	public double AccountBalance
	{
		get
		{
			return accountBalanceField;
		}
		set
		{
			accountBalanceField = value;
			RaisePropertyChanged("AccountBalance");
		}
	}

	[XmlElement(Order = 2)]
	public double NotesReceivable
	{
		get
		{
			return notesReceivableField;
		}
		set
		{
			notesReceivableField = value;
			RaisePropertyChanged("NotesReceivable");
		}
	}

	[XmlElement(Order = 3)]
	public double BouncedChecksBalance
	{
		get
		{
			return bouncedChecksBalanceField;
		}
		set
		{
			bouncedChecksBalanceField = value;
			RaisePropertyChanged("BouncedChecksBalance");
		}
	}

	[XmlElement(Order = 4)]
	public double CreditBalance
	{
		get
		{
			return creditBalanceField;
		}
		set
		{
			creditBalanceField = value;
			RaisePropertyChanged("CreditBalance");
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
