using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerInfoWithMemberID", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerInfoWithMemberIDRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string MemberID;

	public GetCustomerInfoWithMemberIDRequest()
	{
	}

	public GetCustomerInfoWithMemberIDRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string MemberID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.MemberID = MemberID;
	}
}
