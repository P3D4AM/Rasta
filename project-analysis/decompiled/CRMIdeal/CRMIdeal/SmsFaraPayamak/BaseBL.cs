using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace CRMIdeal.SmsFaraPayamak;

[Serializable]
[XmlInclude(typeof(MessagesBL))]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class BaseBL : INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

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
