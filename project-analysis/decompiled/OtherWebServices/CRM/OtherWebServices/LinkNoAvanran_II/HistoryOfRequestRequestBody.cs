using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class HistoryOfRequestRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Doc_No;

	public HistoryOfRequestRequestBody()
	{
	}

	public HistoryOfRequestRequestBody(string Store, string Doc_No)
	{
		this.Store = Store;
		this.Doc_No = Doc_No;
	}
}
