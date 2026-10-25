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
[DataContract(Name = "ClientPaymentResponseDataBase", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
[KnownType(typeof(ClientSaleResponseData))]
public class ClientPaymentResponseDataBase : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private long TokenField;

	[OptionalField]
	private string MessageField;

	private short StatusField;

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

	[DataMember(IsRequired = true)]
	public long Token
	{
		get
		{
			return TokenField;
		}
		set
		{
			if (!TokenField.Equals(value))
			{
				TokenField = value;
				RaisePropertyChanged("Token");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Message
	{
		get
		{
			return MessageField;
		}
		set
		{
			if ((object)MessageField != value)
			{
				MessageField = value;
				RaisePropertyChanged("Message");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 2)]
	public short Status
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
