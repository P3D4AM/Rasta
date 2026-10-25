using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Mobile.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class SMSwsdlPortTypeClient : ClientBase<SMSwsdlPortType>, SMSwsdlPortType
{
	public SMSwsdlPortTypeClient()
	{
	}

	public SMSwsdlPortTypeClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public SMSwsdlPortTypeClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SMSwsdlPortTypeClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SMSwsdlPortTypeClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public string sendSMS(string domain, string username, string password, string from, string to, string text, int isflash)
	{
		return base.Channel.sendSMS(domain, username, password, from, to, text, isflash);
	}

	public Task<string> sendSMSAsync(string domain, string username, string password, string from, string to, string text, int isflash)
	{
		return base.Channel.sendSMSAsync(domain, username, password, from, to, text, isflash);
	}

	public string sendMultiSMS(string domain, string username, string password, string from, string to, string texts, int isflash)
	{
		return base.Channel.sendMultiSMS(domain, username, password, from, to, texts, isflash);
	}

	public Task<string> sendMultiSMSAsync(string domain, string username, string password, string from, string to, string texts, int isflash)
	{
		return base.Channel.sendMultiSMSAsync(domain, username, password, from, to, texts, isflash);
	}

	public string getCredit(string domain, string username, string password)
	{
		return base.Channel.getCredit(domain, username, password);
	}

	public Task<string> getCreditAsync(string domain, string username, string password)
	{
		return base.Channel.getCreditAsync(domain, username, password);
	}

	public delivery[] getDelivery(string domain, string username, string password, int id)
	{
		return base.Channel.getDelivery(domain, username, password, id);
	}

	public Task<delivery[]> getDeliveryAsync(string domain, string username, string password, int id)
	{
		return base.Channel.getDeliveryAsync(domain, username, password, id);
	}

	public delivery[] getDeliveryMulti(string domain, string username, string password, int id)
	{
		return base.Channel.getDeliveryMulti(domain, username, password, id);
	}

	public Task<delivery[]> getDeliveryMultiAsync(string domain, string username, string password, int id)
	{
		return base.Channel.getDeliveryMultiAsync(domain, username, password, id);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	checkReceiveResponse SMSwsdlPortType.checkReceive(checkReceiveRequest request)
	{
		return base.Channel.checkReceive(request);
	}

	public string checkReceive(string mobile_no, string text, string line_number, string domain, string username, string password, out string status)
	{
		checkReceiveRequest checkReceiveRequest2 = new checkReceiveRequest();
		checkReceiveRequest2.mobile_no = mobile_no;
		checkReceiveRequest2.text = text;
		checkReceiveRequest2.line_number = line_number;
		checkReceiveRequest2.domain = domain;
		checkReceiveRequest2.username = username;
		checkReceiveRequest2.password = password;
		checkReceiveResponse checkReceiveResponse2 = ((SMSwsdlPortType)this).checkReceive(checkReceiveRequest2);
		status = checkReceiveResponse2.status;
		return checkReceiveResponse2.result;
	}

	public Task<checkReceiveResponse> checkReceiveAsync(checkReceiveRequest request)
	{
		return base.Channel.checkReceiveAsync(request);
	}

	public message[] getMessages(string domain, string username, string password, string smsType, string start, string count, string from)
	{
		return base.Channel.getMessages(domain, username, password, smsType, start, count, from);
	}

	public Task<message[]> getMessagesAsync(string domain, string username, string password, string smsType, string start, string count, string from)
	{
		return base.Channel.getMessagesAsync(domain, username, password, smsType, start, count, from);
	}

	public string getMessagesCount(string domain, string username, string password, string smsType, string from, string box)
	{
		return base.Channel.getMessagesCount(domain, username, password, smsType, from, box);
	}

	public Task<string> getMessagesCountAsync(string domain, string username, string password, string smsType, string from, string box)
	{
		return base.Channel.getMessagesCountAsync(domain, username, password, smsType, from, box);
	}

	public string removeMessage(string domain, string username, string password, string ids, string smsType)
	{
		return base.Channel.removeMessage(domain, username, password, ids, smsType);
	}

	public Task<string> removeMessageAsync(string domain, string username, string password, string ids, string smsType)
	{
		return base.Channel.removeMessageAsync(domain, username, password, ids, smsType);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getPayAccountsResponse SMSwsdlPortType.getPayAccounts(getPayAccountsRequest request)
	{
		return base.Channel.getPayAccounts(request);
	}

	public string getPayAccounts(string domain, string username, string password, out account[] accounts)
	{
		getPayAccountsRequest getPayAccountsRequest2 = new getPayAccountsRequest();
		getPayAccountsRequest2.domain = domain;
		getPayAccountsRequest2.username = username;
		getPayAccountsRequest2.password = password;
		getPayAccountsResponse payAccounts = ((SMSwsdlPortType)this).getPayAccounts(getPayAccountsRequest2);
		accounts = payAccounts.accounts;
		return payAccounts.result;
	}

	public Task<getPayAccountsResponse> getPayAccountsAsync(getPayAccountsRequest request)
	{
		return base.Channel.getPayAccountsAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	payRequestResponse SMSwsdlPortType.payRequest(payRequestRequest request)
	{
		return base.Channel.payRequest(request);
	}

	public string payRequest(string domain, string username, string password, string account, string amount, string r_url, out int pay_id, out string url)
	{
		payRequestRequest payRequestRequest2 = new payRequestRequest();
		payRequestRequest2.domain = domain;
		payRequestRequest2.username = username;
		payRequestRequest2.password = password;
		payRequestRequest2.account = account;
		payRequestRequest2.amount = amount;
		payRequestRequest2.r_url = r_url;
		payRequestResponse payRequestResponse2 = ((SMSwsdlPortType)this).payRequest(payRequestRequest2);
		pay_id = payRequestResponse2.pay_id;
		url = payRequestResponse2.url;
		return payRequestResponse2.result;
	}

	public Task<payRequestResponse> payRequestAsync(payRequestRequest request)
	{
		return base.Channel.payRequestAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getCreditPriceResponse SMSwsdlPortType.getCreditPrice(getCreditPriceRequest request)
	{
		return base.Channel.getCreditPrice(request);
	}

	public string getCreditPrice(string domain, string username, string password, string amount, out int price)
	{
		getCreditPriceRequest getCreditPriceRequest2 = new getCreditPriceRequest();
		getCreditPriceRequest2.domain = domain;
		getCreditPriceRequest2.username = username;
		getCreditPriceRequest2.password = password;
		getCreditPriceRequest2.amount = amount;
		getCreditPriceResponse creditPrice = ((SMSwsdlPortType)this).getCreditPrice(getCreditPriceRequest2);
		price = creditPrice.price;
		return creditPrice.result;
	}

	public Task<getCreditPriceResponse> getCreditPriceAsync(getCreditPriceRequest request)
	{
		return base.Channel.getCreditPriceAsync(request);
	}
}
