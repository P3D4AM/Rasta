using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomersBaseInfo", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomersBaseInfoRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public FiledName filedName;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string[] value;

	public GetCustomersBaseInfoRequest()
	{
	}

	public GetCustomersBaseInfoRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, FiledName filedName, string[] value)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.filedName = filedName;
		this.value = value;
	}
}
