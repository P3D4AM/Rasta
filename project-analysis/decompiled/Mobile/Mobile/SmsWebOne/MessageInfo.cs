using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace Mobile.SmsWebOne;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "MessageInfo", Namespace = "http://schemas.datacontract.org/2004/07/SMSPanel.Domain.Models")]
public class MessageInfo : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private DateTime ActionDateTimeField;

	[OptionalField]
	private string ContentField;

	[OptionalField]
	private decimal CostField;

	[OptionalField]
	private int CountField;

	[OptionalField]
	private string DescField;

	[OptionalField]
	private bool FlashField;

	[OptionalField]
	private bool IsReadField;

	[OptionalField]
	private SMSLang LangField;

	[OptionalField]
	private int MessageIdField;

	[OptionalField]
	private SMSDirectionType MessageTypeField;

	[OptionalField]
	private bool MoneyIsRefundedField;

	[OptionalField]
	private int NotSentField;

	[OptionalField]
	private int PagesField;

	[OptionalField]
	private string ReceiverField;

	[OptionalField]
	private SMSSendMethod SendMethodField;

	[OptionalField]
	private SMSSendStatus SendStatusField;

	[OptionalField]
	private string SenderField;

	[OptionalField]
	private int SentField;

	[OptionalField]
	private SMSStatus StatusField;

	[OptionalField]
	private decimal TariffField;

	[OptionalField]
	private string TitleField;

	[OptionalField]
	private int UserIdField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember]
	public DateTime ActionDateTime
	{
		get
		{
			return ActionDateTimeField;
		}
		set
		{
			if (!ActionDateTimeField.Equals(value))
			{
				ActionDateTimeField = value;
				RaisePropertyChanged("ActionDateTime");
			}
		}
	}

	[DataMember]
	public string Content
	{
		get
		{
			return ContentField;
		}
		set
		{
			if ((object)ContentField != value)
			{
				ContentField = value;
				RaisePropertyChanged("Content");
			}
		}
	}

	[DataMember]
	public decimal Cost
	{
		get
		{
			return CostField;
		}
		set
		{
			if (!CostField.Equals(value))
			{
				CostField = value;
				RaisePropertyChanged("Cost");
			}
		}
	}

	[DataMember]
	public int Count
	{
		get
		{
			return CountField;
		}
		set
		{
			if (!CountField.Equals(value))
			{
				CountField = value;
				RaisePropertyChanged("Count");
			}
		}
	}

	[DataMember]
	public string Desc
	{
		get
		{
			return DescField;
		}
		set
		{
			if ((object)DescField != value)
			{
				DescField = value;
				RaisePropertyChanged("Desc");
			}
		}
	}

	[DataMember]
	public bool Flash
	{
		get
		{
			return FlashField;
		}
		set
		{
			if (!FlashField.Equals(value))
			{
				FlashField = value;
				RaisePropertyChanged("Flash");
			}
		}
	}

	[DataMember]
	public bool IsRead
	{
		get
		{
			return IsReadField;
		}
		set
		{
			if (!IsReadField.Equals(value))
			{
				IsReadField = value;
				RaisePropertyChanged("IsRead");
			}
		}
	}

	[DataMember]
	public SMSLang Lang
	{
		get
		{
			return LangField;
		}
		set
		{
			if (!LangField.Equals(value))
			{
				LangField = value;
				RaisePropertyChanged("Lang");
			}
		}
	}

	[DataMember]
	public int MessageId
	{
		get
		{
			return MessageIdField;
		}
		set
		{
			if (!MessageIdField.Equals(value))
			{
				MessageIdField = value;
				RaisePropertyChanged("MessageId");
			}
		}
	}

	[DataMember]
	public SMSDirectionType MessageType
	{
		get
		{
			return MessageTypeField;
		}
		set
		{
			if (!MessageTypeField.Equals(value))
			{
				MessageTypeField = value;
				RaisePropertyChanged("MessageType");
			}
		}
	}

	[DataMember]
	public bool MoneyIsRefunded
	{
		get
		{
			return MoneyIsRefundedField;
		}
		set
		{
			if (!MoneyIsRefundedField.Equals(value))
			{
				MoneyIsRefundedField = value;
				RaisePropertyChanged("MoneyIsRefunded");
			}
		}
	}

	[DataMember]
	public int NotSent
	{
		get
		{
			return NotSentField;
		}
		set
		{
			if (!NotSentField.Equals(value))
			{
				NotSentField = value;
				RaisePropertyChanged("NotSent");
			}
		}
	}

	[DataMember]
	public int Pages
	{
		get
		{
			return PagesField;
		}
		set
		{
			if (!PagesField.Equals(value))
			{
				PagesField = value;
				RaisePropertyChanged("Pages");
			}
		}
	}

	[DataMember]
	public string Receiver
	{
		get
		{
			return ReceiverField;
		}
		set
		{
			if ((object)ReceiverField != value)
			{
				ReceiverField = value;
				RaisePropertyChanged("Receiver");
			}
		}
	}

	[DataMember]
	public SMSSendMethod SendMethod
	{
		get
		{
			return SendMethodField;
		}
		set
		{
			if (!SendMethodField.Equals(value))
			{
				SendMethodField = value;
				RaisePropertyChanged("SendMethod");
			}
		}
	}

	[DataMember]
	public SMSSendStatus SendStatus
	{
		get
		{
			return SendStatusField;
		}
		set
		{
			if (!SendStatusField.Equals(value))
			{
				SendStatusField = value;
				RaisePropertyChanged("SendStatus");
			}
		}
	}

	[DataMember]
	public string Sender
	{
		get
		{
			return SenderField;
		}
		set
		{
			if ((object)SenderField != value)
			{
				SenderField = value;
				RaisePropertyChanged("Sender");
			}
		}
	}

	[DataMember]
	public int Sent
	{
		get
		{
			return SentField;
		}
		set
		{
			if (!SentField.Equals(value))
			{
				SentField = value;
				RaisePropertyChanged("Sent");
			}
		}
	}

	[DataMember]
	public SMSStatus Status
	{
		get
		{
			return StatusField;
		}
		set
		{
			if (!StatusField.Equals(value))
			{
				StatusField = value;
				RaisePropertyChanged("Status");
			}
		}
	}

	[DataMember]
	public decimal Tariff
	{
		get
		{
			return TariffField;
		}
		set
		{
			if (!TariffField.Equals(value))
			{
				TariffField = value;
				RaisePropertyChanged("Tariff");
			}
		}
	}

	[DataMember]
	public string Title
	{
		get
		{
			return TitleField;
		}
		set
		{
			if ((object)TitleField != value)
			{
				TitleField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	[DataMember]
	public int UserId
	{
		get
		{
			return UserIdField;
		}
		set
		{
			if (!UserIdField.Equals(value))
			{
				UserIdField = value;
				RaisePropertyChanged("UserId");
			}
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
