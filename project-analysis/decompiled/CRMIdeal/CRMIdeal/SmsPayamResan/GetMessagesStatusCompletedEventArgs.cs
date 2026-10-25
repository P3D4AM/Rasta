using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace CRMIdeal.SmsPayamResan;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetMessagesStatusCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public long[] Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (long[])results[0];
		}
	}

	internal GetMessagesStatusCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
