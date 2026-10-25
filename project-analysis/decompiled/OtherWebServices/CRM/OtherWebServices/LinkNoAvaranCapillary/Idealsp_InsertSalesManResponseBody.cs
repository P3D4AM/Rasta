using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertSalesManResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertSalesManResult;

	public Idealsp_InsertSalesManResponseBody()
	{
	}

	public Idealsp_InsertSalesManResponseBody(string Idealsp_InsertSalesManResult)
	{
		this.Idealsp_InsertSalesManResult = Idealsp_InsertSalesManResult;
	}
}
