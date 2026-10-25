using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace CRMIdeal.SmsAfzar;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class getSendSMSOnDateCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public SendInfo[] Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (SendInfo[])results[0];
		}
	}

	internal getSendSMSOnDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
