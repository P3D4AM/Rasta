using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class PaymentGatewayImplementationServicePortTypeClient : ClientBase<PaymentGatewayImplementationServicePortType>, PaymentGatewayImplementationServicePortType
{
	public PaymentGatewayImplementationServicePortTypeClient()
	{
	}

	public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public PaymentGatewayImplementationServicePortTypeClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	PaymentRequestResponse PaymentGatewayImplementationServicePortType.PaymentRequest(PaymentRequestRequest request)
	{
		return base.Channel.PaymentRequest(request);
	}

	public int PaymentRequest(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority)
	{
		PaymentRequestRequest paymentRequestRequest = new PaymentRequestRequest();
		paymentRequestRequest.Body = new PaymentRequestRequestBody();
		paymentRequestRequest.Body.MerchantID = MerchantID;
		paymentRequestRequest.Body.Amount = Amount;
		paymentRequestRequest.Body.Description = Description;
		paymentRequestRequest.Body.Email = Email;
		paymentRequestRequest.Body.Mobile = Mobile;
		paymentRequestRequest.Body.CallbackURL = CallbackURL;
		PaymentRequestResponse paymentRequestResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentRequest(paymentRequestRequest);
		Authority = paymentRequestResponse.Body.Authority;
		return paymentRequestResponse.Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<PaymentRequestResponse> PaymentGatewayImplementationServicePortType.PaymentRequestAsync(PaymentRequestRequest request)
	{
		return base.Channel.PaymentRequestAsync(request);
	}

	public Task<PaymentRequestResponse> PaymentRequestAsync(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL)
	{
		PaymentRequestRequest paymentRequestRequest = new PaymentRequestRequest();
		paymentRequestRequest.Body = new PaymentRequestRequestBody();
		paymentRequestRequest.Body.MerchantID = MerchantID;
		paymentRequestRequest.Body.Amount = Amount;
		paymentRequestRequest.Body.Description = Description;
		paymentRequestRequest.Body.Email = Email;
		paymentRequestRequest.Body.Mobile = Mobile;
		paymentRequestRequest.Body.CallbackURL = CallbackURL;
		return ((PaymentGatewayImplementationServicePortType)this).PaymentRequestAsync(paymentRequestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	PaymentRequestWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentRequestWithExtra(PaymentRequestWithExtraRequest request)
	{
		return base.Channel.PaymentRequestWithExtra(request);
	}

	public int PaymentRequestWithExtra(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL, out string Authority)
	{
		PaymentRequestWithExtraRequest paymentRequestWithExtraRequest = new PaymentRequestWithExtraRequest();
		paymentRequestWithExtraRequest.Body = new PaymentRequestWithExtraRequestBody();
		paymentRequestWithExtraRequest.Body.MerchantID = MerchantID;
		paymentRequestWithExtraRequest.Body.Amount = Amount;
		paymentRequestWithExtraRequest.Body.Description = Description;
		paymentRequestWithExtraRequest.Body.AdditionalData = AdditionalData;
		paymentRequestWithExtraRequest.Body.Email = Email;
		paymentRequestWithExtraRequest.Body.Mobile = Mobile;
		paymentRequestWithExtraRequest.Body.CallbackURL = CallbackURL;
		PaymentRequestWithExtraResponse paymentRequestWithExtraResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentRequestWithExtra(paymentRequestWithExtraRequest);
		Authority = paymentRequestWithExtraResponse.Body.Authority;
		return paymentRequestWithExtraResponse.Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<PaymentRequestWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentRequestWithExtraAsync(PaymentRequestWithExtraRequest request)
	{
		return base.Channel.PaymentRequestWithExtraAsync(request);
	}

	public Task<PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL)
	{
		PaymentRequestWithExtraRequest paymentRequestWithExtraRequest = new PaymentRequestWithExtraRequest();
		paymentRequestWithExtraRequest.Body = new PaymentRequestWithExtraRequestBody();
		paymentRequestWithExtraRequest.Body.MerchantID = MerchantID;
		paymentRequestWithExtraRequest.Body.Amount = Amount;
		paymentRequestWithExtraRequest.Body.Description = Description;
		paymentRequestWithExtraRequest.Body.AdditionalData = AdditionalData;
		paymentRequestWithExtraRequest.Body.Email = Email;
		paymentRequestWithExtraRequest.Body.Mobile = Mobile;
		paymentRequestWithExtraRequest.Body.CallbackURL = CallbackURL;
		return ((PaymentGatewayImplementationServicePortType)this).PaymentRequestWithExtraAsync(paymentRequestWithExtraRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	PaymentVerificationResponse PaymentGatewayImplementationServicePortType.PaymentVerification(PaymentVerificationRequest request)
	{
		return base.Channel.PaymentVerification(request);
	}

	public int PaymentVerification(string MerchantID, string Authority, int Amount, out long RefID)
	{
		PaymentVerificationRequest paymentVerificationRequest = new PaymentVerificationRequest();
		paymentVerificationRequest.Body = new PaymentVerificationRequestBody();
		paymentVerificationRequest.Body.MerchantID = MerchantID;
		paymentVerificationRequest.Body.Authority = Authority;
		paymentVerificationRequest.Body.Amount = Amount;
		PaymentVerificationResponse paymentVerificationResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentVerification(paymentVerificationRequest);
		RefID = paymentVerificationResponse.Body.RefID;
		return paymentVerificationResponse.Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<PaymentVerificationResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationAsync(PaymentVerificationRequest request)
	{
		return base.Channel.PaymentVerificationAsync(request);
	}

	public Task<PaymentVerificationResponse> PaymentVerificationAsync(string MerchantID, string Authority, int Amount)
	{
		PaymentVerificationRequest paymentVerificationRequest = new PaymentVerificationRequest();
		paymentVerificationRequest.Body = new PaymentVerificationRequestBody();
		paymentVerificationRequest.Body.MerchantID = MerchantID;
		paymentVerificationRequest.Body.Authority = Authority;
		paymentVerificationRequest.Body.Amount = Amount;
		return ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationAsync(paymentVerificationRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	PaymentVerificationWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtra(PaymentVerificationWithExtraRequest request)
	{
		return base.Channel.PaymentVerificationWithExtra(request);
	}

	public int PaymentVerificationWithExtra(string MerchantID, string Authority, int Amount, out long RefID, out string ExtraDetail)
	{
		PaymentVerificationWithExtraRequest paymentVerificationWithExtraRequest = new PaymentVerificationWithExtraRequest();
		paymentVerificationWithExtraRequest.Body = new PaymentVerificationWithExtraRequestBody();
		paymentVerificationWithExtraRequest.Body.MerchantID = MerchantID;
		paymentVerificationWithExtraRequest.Body.Authority = Authority;
		paymentVerificationWithExtraRequest.Body.Amount = Amount;
		PaymentVerificationWithExtraResponse paymentVerificationWithExtraResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationWithExtra(paymentVerificationWithExtraRequest);
		RefID = paymentVerificationWithExtraResponse.Body.RefID;
		ExtraDetail = paymentVerificationWithExtraResponse.Body.ExtraDetail;
		return paymentVerificationWithExtraResponse.Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<PaymentVerificationWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtraAsync(PaymentVerificationWithExtraRequest request)
	{
		return base.Channel.PaymentVerificationWithExtraAsync(request);
	}

	public Task<PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(string MerchantID, string Authority, int Amount)
	{
		PaymentVerificationWithExtraRequest paymentVerificationWithExtraRequest = new PaymentVerificationWithExtraRequest();
		paymentVerificationWithExtraRequest.Body = new PaymentVerificationWithExtraRequestBody();
		paymentVerificationWithExtraRequest.Body.MerchantID = MerchantID;
		paymentVerificationWithExtraRequest.Body.Authority = Authority;
		paymentVerificationWithExtraRequest.Body.Amount = Amount;
		return ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationWithExtraAsync(paymentVerificationWithExtraRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetUnverifiedTransactionsResponse PaymentGatewayImplementationServicePortType.GetUnverifiedTransactions(GetUnverifiedTransactionsRequest request)
	{
		return base.Channel.GetUnverifiedTransactions(request);
	}

	public int GetUnverifiedTransactions(string MerchantID, out string Authorities)
	{
		GetUnverifiedTransactionsRequest getUnverifiedTransactionsRequest = new GetUnverifiedTransactionsRequest();
		getUnverifiedTransactionsRequest.Body = new GetUnverifiedTransactionsRequestBody();
		getUnverifiedTransactionsRequest.Body.MerchantID = MerchantID;
		GetUnverifiedTransactionsResponse unverifiedTransactions = ((PaymentGatewayImplementationServicePortType)this).GetUnverifiedTransactions(getUnverifiedTransactionsRequest);
		Authorities = unverifiedTransactions.Body.Authorities;
		return unverifiedTransactions.Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetUnverifiedTransactionsResponse> PaymentGatewayImplementationServicePortType.GetUnverifiedTransactionsAsync(GetUnverifiedTransactionsRequest request)
	{
		return base.Channel.GetUnverifiedTransactionsAsync(request);
	}

	public Task<GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(string MerchantID)
	{
		GetUnverifiedTransactionsRequest getUnverifiedTransactionsRequest = new GetUnverifiedTransactionsRequest();
		getUnverifiedTransactionsRequest.Body = new GetUnverifiedTransactionsRequestBody();
		getUnverifiedTransactionsRequest.Body.MerchantID = MerchantID;
		return ((PaymentGatewayImplementationServicePortType)this).GetUnverifiedTransactionsAsync(getUnverifiedTransactionsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	RefreshAuthorityResponse PaymentGatewayImplementationServicePortType.RefreshAuthority(RefreshAuthorityRequest request)
	{
		return base.Channel.RefreshAuthority(request);
	}

	public int RefreshAuthority(string MerchantID, string Authority, int ExpireIn)
	{
		RefreshAuthorityRequest refreshAuthorityRequest = new RefreshAuthorityRequest();
		refreshAuthorityRequest.Body = new RefreshAuthorityRequestBody();
		refreshAuthorityRequest.Body.MerchantID = MerchantID;
		refreshAuthorityRequest.Body.Authority = Authority;
		refreshAuthorityRequest.Body.ExpireIn = ExpireIn;
		return ((PaymentGatewayImplementationServicePortType)this).RefreshAuthority(refreshAuthorityRequest).Body.Status;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<RefreshAuthorityResponse> PaymentGatewayImplementationServicePortType.RefreshAuthorityAsync(RefreshAuthorityRequest request)
	{
		return base.Channel.RefreshAuthorityAsync(request);
	}

	public Task<RefreshAuthorityResponse> RefreshAuthorityAsync(string MerchantID, string Authority, int ExpireIn)
	{
		RefreshAuthorityRequest refreshAuthorityRequest = new RefreshAuthorityRequest();
		refreshAuthorityRequest.Body = new RefreshAuthorityRequestBody();
		refreshAuthorityRequest.Body.MerchantID = MerchantID;
		refreshAuthorityRequest.Body.Authority = Authority;
		refreshAuthorityRequest.Body.ExpireIn = ExpireIn;
		return ((PaymentGatewayImplementationServicePortType)this).RefreshAuthorityAsync(refreshAuthorityRequest);
	}
}
