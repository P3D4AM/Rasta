using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Mobile.SmsKaveNegar;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ReceiveByLoginInfoCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public ApiReceive[] Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (ApiReceive[])results[0];
		}
	}

	public int status
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (int)results[1];
		}
	}

	public string statusmessage
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (string)results[2];
		}
	}

	internal ReceiveByLoginInfoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
