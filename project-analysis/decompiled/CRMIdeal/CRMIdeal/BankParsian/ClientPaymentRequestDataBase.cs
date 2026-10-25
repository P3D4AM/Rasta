using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace CRMIdeal.BankParsian;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "ClientPaymentRequestDataBase", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
[KnownType(typeof(ClientSaleRequestData))]
[KnownType(typeof(ClientSaleDiscountRequestData))]
public class ClientPaymentRequestDataBase : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string LoginAccountField;

	private long AmountField;

	private long OrderIdField;

	[OptionalField]
	private string CallBackUrlField;

	[OptionalField]
	private string AdditionalDataField;

	[OptionalField]
	private string OriginatorField;

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

	[DataMember(EmitDefaultValue = false)]
	public string LoginAccount
	{
		get
		{
			return LoginAccountField;
		}
		set
		{
			if ((object)LoginAccountField != value)
			{
				LoginAccountField = value;
				RaisePropertyChanged("LoginAccount");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 1)]
	public long Amount
	{
		get
		{
			return AmountField;
		}
		set
		{
			if (!AmountField.Equals(value))
			{
				AmountField = value;
				RaisePropertyChanged("Amount");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 2)]
	public long OrderId
	{
		get
		{
			return OrderIdField;
		}
		set
		{
			if (!OrderIdField.Equals(value))
			{
				OrderIdField = value;
				RaisePropertyChanged("OrderId");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string CallBackUrl
	{
		get
		{
			return CallBackUrlField;
		}
		set
		{
			if ((object)CallBackUrlField != value)
			{
				CallBackUrlField = value;
				RaisePropertyChanged("CallBackUrl");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string AdditionalData
	{
		get
		{
			return AdditionalDataField;
		}
		set
		{
			if ((object)AdditionalDataField != value)
			{
				AdditionalDataField = value;
				RaisePropertyChanged("AdditionalData");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Originator
	{
		get
		{
			return OriginatorField;
		}
		set
		{
			if ((object)OriginatorField != value)
			{
				OriginatorField = value;
				RaisePropertyChanged("Originator");
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
