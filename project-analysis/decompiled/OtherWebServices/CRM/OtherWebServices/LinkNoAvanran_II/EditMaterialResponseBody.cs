using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class EditMaterialResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string EditMaterialResult;

	public EditMaterialResponseBody()
	{
	}

	public EditMaterialResponseBody(string EditMaterialResult)
	{
		this.EditMaterialResult = EditMaterialResult;
	}
}
