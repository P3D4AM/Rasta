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
public class GiftCertificate : INotifyPropertyChanged
{
	private string giftCertificateSerialNumberField;

	private string giftCertificateBarcodeField;

	private string giftCertificateBarcodeTypField;

	private DateTime? paidDateTimeStampField;

	private int giftCertificateTypeCodeField;

	private DateTime? expirationDateField;

	private decimal faceValueAmountField;

	private string giftCertificateTypeField;

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

	[XmlElement(Order = 2)]
	public string GiftCertificateBarcodeTyp
	{
		get
		{
			return giftCertificateBarcodeTypField;
		}
		set
		{
			giftCertificateBarcodeTypField = value;
			RaisePropertyChanged("GiftCertificateBarcodeTyp");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? PaidDateTimeStamp
	{
		get
		{
			return paidDateTimeStampField;
		}
		set
		{
			paidDateTimeStampField = value;
			RaisePropertyChanged("PaidDateTimeStamp");
		}
	}

	[XmlElement(Order = 4)]
	public int GiftCertificateTypeCode
	{
		get
		{
			return giftCertificateTypeCodeField;
		}
		set
		{
			giftCertificateTypeCodeField = value;
			RaisePropertyChanged("GiftCertificateTypeCode");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public DateTime? ExpirationDate
	{
		get
		{
			return expirationDateField;
		}
		set
		{
			expirationDateField = value;
			RaisePropertyChanged("ExpirationDate");
		}
	}

	[XmlElement(Order = 6)]
	public decimal FaceValueAmount
	{
		get
		{
			return faceValueAmountField;
		}
		set
		{
			faceValueAmountField = value;
			RaisePropertyChanged("FaceValueAmount");
		}
	}

	[XmlElement(Order = 7)]
	public string GiftCertificateType
	{
		get
		{
			return giftCertificateTypeField;
		}
		set
		{
			giftCertificateTypeField = value;
			RaisePropertyChanged("GiftCertificateType");
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
