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
[DataContract(Name = "Product", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
public class Product : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private int PGroupIdField;

	private long AmountField;

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
	public int PGroupId
	{
		get
		{
			return PGroupIdField;
		}
		set
		{
			if (!PGroupIdField.Equals(value))
			{
				PGroupIdField = value;
				RaisePropertyChanged("PGroupId");
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
