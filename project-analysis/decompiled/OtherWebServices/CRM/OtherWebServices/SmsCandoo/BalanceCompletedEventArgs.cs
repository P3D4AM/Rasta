using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace CRM.OtherWebServices.SmsCandoo;

[GeneratedCode("System.Web.Services", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class BalanceCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public string Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (string)results[0];
		}
	}

	internal BalanceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
