using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace CRMIdeal.Classes.Helper.ParsianPGWSalePaymentServices;

[GeneratedCode("System.Web.Services", "4.7.2556.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SalePaymentRequestCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public ClientSaleResponseData Result
	{
		get
		{
			((AsyncCompletedEventArgs)this).RaiseExceptionIfNecessary();
			return (ClientSaleResponseData)results[0];
		}
	}

	internal SalePaymentRequestCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
