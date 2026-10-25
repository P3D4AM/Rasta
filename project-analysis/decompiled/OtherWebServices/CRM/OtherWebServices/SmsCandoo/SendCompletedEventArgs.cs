using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace CRM.OtherWebServices.SmsCandoo;

[GeneratedCode("System.Web.Services", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SendCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public SendResult[] Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (SendResult[])results[0];
		}
	}

	internal SendCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
