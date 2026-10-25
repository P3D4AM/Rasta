using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Mobile.SmsFor;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class sms_sentCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public array_sent[] Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (array_sent[])results[0];
		}
	}

	internal sms_sentCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
