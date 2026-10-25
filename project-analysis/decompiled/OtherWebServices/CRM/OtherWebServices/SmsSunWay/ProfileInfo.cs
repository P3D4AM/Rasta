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
public class ProfileInfo : INotifyPropertyChanged
{
	private int sMSCreditField;

	private int totalSendSMSField;

	private int totalReciveSMSField;

	private int totalIncomeSMSField;

	private string notificationsField;

	private string notificationsDiscField;

	private DateTime notificationsDateField;

	private string publicNotificationsField;

	private string publicNotificationsDiscField;

	private DateTime publicNotificationsDateField;

	private long statusField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public int SMSCredit
	{
		get
		{
			return sMSCreditField;
		}
		set
		{
			sMSCreditField = value;
			RaisePropertyChanged("SMSCredit");
		}
	}

	[XmlElement(Order = 1)]
	public int TotalSendSMS
	{
		get
		{
			return totalSendSMSField;
		}
		set
		{
			totalSendSMSField = value;
			RaisePropertyChanged("TotalSendSMS");
		}
	}

	[XmlElement(Order = 2)]
	public int TotalReciveSMS
	{
		get
		{
			return totalReciveSMSField;
		}
		set
		{
			totalReciveSMSField = value;
			RaisePropertyChanged("TotalReciveSMS");
		}
	}

	[XmlElement(Order = 3)]
	public int TotalIncomeSMS
	{
		get
		{
			return totalIncomeSMSField;
		}
		set
		{
			totalIncomeSMSField = value;
			RaisePropertyChanged("TotalIncomeSMS");
		}
	}

	[XmlElement(Order = 4)]
	public string Notifications
	{
		get
		{
			return notificationsField;
		}
		set
		{
			notificationsField = value;
			RaisePropertyChanged("Notifications");
		}
	}

	[XmlElement(Order = 5)]
	public string NotificationsDisc
	{
		get
		{
			return notificationsDiscField;
		}
		set
		{
			notificationsDiscField = value;
			RaisePropertyChanged("NotificationsDisc");
		}
	}

	[XmlElement(Order = 6)]
	public DateTime NotificationsDate
	{
		get
		{
			return notificationsDateField;
		}
		set
		{
			notificationsDateField = value;
			RaisePropertyChanged("NotificationsDate");
		}
	}

	[XmlElement(Order = 7)]
	public string PublicNotifications
	{
		get
		{
			return publicNotificationsField;
		}
		set
		{
			publicNotificationsField = value;
			RaisePropertyChanged("PublicNotifications");
		}
	}

	[XmlElement(Order = 8)]
	public string PublicNotificationsDisc
	{
		get
		{
			return publicNotificationsDiscField;
		}
		set
		{
			publicNotificationsDiscField = value;
			RaisePropertyChanged("PublicNotificationsDisc");
		}
	}

	[XmlElement(Order = 9)]
	public DateTime PublicNotificationsDate
	{
		get
		{
			return publicNotificationsDateField;
		}
		set
		{
			publicNotificationsDateField = value;
			RaisePropertyChanged("PublicNotificationsDate");
		}
	}

	[XmlElement(Order = 10)]
	public long Status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("Status");
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
