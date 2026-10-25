using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace CRM.OtherWebServices.SmsSunWay;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class InboxItem2 : INotifyPropertyChanged
{
	private long inboxIDField;

	private string specialNumberField;

	private string senderNumberField;

	private string messageBodyField;

	private DateTime receiveDateField;

	private string uDHField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public long InboxID
	{
		get
		{
			return inboxIDField;
		}
		set
		{
			inboxIDField = value;
			RaisePropertyChanged("InboxID");
		}
	}

	[XmlElement(Order = 1)]
	public string SpecialNumber
	{
		get
		{
			return specialNumberField;
		}
		set
		{
			specialNumberField = value;
			RaisePropertyChanged("SpecialNumber");
		}
	}

	[XmlElement(Order = 2)]
	public string SenderNumber
	{
		get
		{
			return senderNumberField;
		}
		set
		{
			senderNumberField = value;
			RaisePropertyChanged("SenderNumber");
		}
	}

	[XmlElement(Order = 3)]
	public string MessageBody
	{
		get
		{
			return messageBodyField;
		}
		set
		{
			messageBodyField = value;
			RaisePropertyChanged("MessageBody");
		}
	}

	[XmlElement(Order = 4)]
	public DateTime ReceiveDate
	{
		get
		{
			return receiveDateField;
		}
		set
		{
			receiveDateField = value;
			RaisePropertyChanged("ReceiveDate");
		}
	}

	[XmlElement(Order = 5)]
	public string UDH
	{
		get
		{
			return uDHField;
		}
		set
		{
			uDHField = value;
			RaisePropertyChanged("UDH");
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
