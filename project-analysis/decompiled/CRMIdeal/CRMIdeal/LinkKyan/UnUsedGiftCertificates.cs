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
public class UnUsedGiftCertificates : INotifyPropertyChanged
{
	private string giftCertificateSerialNumberField;

	private string giftCertificateBarcodeField;

	private DateTime? createDateTimeField;

	private DateTime? expireDateTimeField;

	private decimal amountField;

	private string bonTypeField;

	private string customerIDField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	[XmlElement(Order = 0)]
	public string GiftCertificateSerialNumber
	{
		get
		{
			return giftCertificateSerialNumberField;
		}
		set
		{
			giftCertificateSerialNumberField = value;
			RaisePropertyChanged("GiftCertificateSerialNumber");
		}
	}

	[XmlElement(Order = 1)]
	public string GiftCertificateBarcode
	{
		get
		{
			return giftCertificateBarcodeField;
		}
		set
		{
			giftCertificateBarcodeField = value;
			RaisePropertyChanged("GiftCertificateBarcode");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public DateTime? CreateDateTime
	{
		get
		{
			return createDateTimeField;
		}
		set
		{
			createDateTimeField = value;
			RaisePropertyChanged("CreateDateTime");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? ExpireDateTime
	{
		get
		{
			return expireDateTimeField;
		}
		set
		{
			expireDateTimeField = value;
			RaisePropertyChanged("ExpireDateTime");
		}
	}

	[XmlElement(Order = 4)]
	public decimal Amount
	{
		get
		{
			return amountField;
		}
		set
		{
			amountField = value;
			RaisePropertyChanged("Amount");
		}
	}

	[XmlElement(Order = 5)]
	public string BonType
	{
		get
		{
			return bonTypeField;
		}
		set
		{
			bonTypeField = value;
			RaisePropertyChanged("BonType");
		}
	}

	[XmlElement(Order = 6)]
	public string CustomerID
	{
		get
		{
			return customerIDField;
		}
		set
		{
			customerIDField = value;
			RaisePropertyChanged("CustomerID");
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
