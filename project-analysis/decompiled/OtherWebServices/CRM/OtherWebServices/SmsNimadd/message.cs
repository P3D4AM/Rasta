using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace CRM.OtherWebServices.SmsNimadd;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[SoapType(Namespace = "urn:SMSwsdl")]
public class message : INotifyPropertyChanged
{
	private string boxField;

	private string textField;

	private int sms_idField;

	private string send_dateField;

	private string creditField;

	private string line_noField;

	private string mobile_noField;

	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	public string box
	{
		get
		{
			return boxField;
		}
		set
		{
			boxField = value;
			RaisePropertyChanged("box");
		}
	}

	public string text
	{
		get
		{
			return textField;
		}
		set
		{
			textField = value;
			RaisePropertyChanged("text");
		}
	}

	public int sms_id
	{
		get
		{
			return sms_idField;
		}
		set
		{
			sms_idField = value;
			RaisePropertyChanged("sms_id");
		}
	}

	public string send_date
	{
		get
		{
			return send_dateField;
		}
		set
		{
			send_dateField = value;
			RaisePropertyChanged("send_date");
		}
	}

	public string credit
	{
		get
		{
			return creditField;
		}
		set
		{
			creditField = value;
			RaisePropertyChanged("credit");
		}
	}

	public string line_no
	{
		get
		{
			return line_noField;
		}
		set
		{
			line_noField = value;
			RaisePropertyChanged("line_no");
		}
	}

	public string mobile_no
	{
		get
		{
			return mobile_noField;
		}
		set
		{
			mobile_noField = value;
			RaisePropertyChanged("mobile_no");
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
