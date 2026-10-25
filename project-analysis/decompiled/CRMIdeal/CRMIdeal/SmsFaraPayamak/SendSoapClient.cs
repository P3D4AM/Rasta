using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class SendSoapClient : ClientBase<SendSoap>, SendSoap
{
	public SendSoapClient()
	{
	}

	public SendSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public SendSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SendSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SendSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public string[] SendSimpleSMS(string username, string password, string[] to, string from, string text, bool isflash)
	{
		return base.Channel.SendSimpleSMS(username, password, to, from, text, isflash);
	}

	public Task<string[]> SendSimpleSMSAsync(string username, string password, string[] to, string from, string text, bool isflash)
	{
		return base.Channel.SendSimpleSMSAsync(username, password, to, from, text, isflash);
	}

	public string SendSimpleSMS2(string username, string password, string to, string from, string text, bool isflash)
	{
		return base.Channel.SendSimpleSMS2(username, password, to, from, text, isflash);
	}

	public Task<string> SendSimpleSMS2Async(string username, string password, string to, string from, string text, bool isflash)
	{
		return base.Channel.SendSimpleSMS2Async(username, password, to, from, text, isflash);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SendSmsResponse SendSoap.SendSms(SendSmsRequest request)
	{
		return base.Channel.SendSms(request);
	}

	public int SendSms(string username, string password, string[] to, string from, string text, bool isflash, string udh, ref long[] recId, ref byte[] status)
	{
		SendSmsRequest sendSmsRequest = new SendSmsRequest();
		sendSmsRequest.username = username;
		sendSmsRequest.password = password;
		sendSmsRequest.to = to;
		sendSmsRequest.from = from;
		sendSmsRequest.text = text;
		sendSmsRequest.isflash = isflash;
		sendSmsRequest.udh = udh;
		sendSmsRequest.recId = recId;
		sendSmsRequest.status = status;
		SendSmsResponse sendSmsResponse = ((SendSoap)this).SendSms(sendSmsRequest);
		recId = sendSmsResponse.recId;
		status = sendSmsResponse.status;
		return sendSmsResponse.SendSmsResult;
	}

	public Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request)
	{
		return base.Channel.SendSmsAsync(request);
	}

	public string SendWithDomain(string username, string password, string to, string from, string text, bool isflash, string domainName)
	{
		return base.Channel.SendWithDomain(username, password, to, from, text, isflash, domainName);
	}

	public Task<string> SendWithDomainAsync(string username, string password, string to, string from, string text, bool isflash, string domainName)
	{
		return base.Channel.SendWithDomainAsync(username, password, to, from, text, isflash, domainName);
	}

	public double GetSmsPrice(string username, string password, int irancellCount, int mtnCount, string from, string text)
	{
		return base.Channel.GetSmsPrice(username, password, irancellCount, mtnCount, from, text);
	}

	public Task<double> GetSmsPriceAsync(string username, string password, int irancellCount, int mtnCount, string from, string text)
	{
		return base.Channel.GetSmsPriceAsync(username, password, irancellCount, mtnCount, from, text);
	}

	public double GetCredit(string username, string password)
	{
		return base.Channel.GetCredit(username, password);
	}

	public Task<double> GetCreditAsync(string username, string password)
	{
		return base.Channel.GetCreditAsync(username, password);
	}

	public int GetDelivery(long recId)
	{
		return base.Channel.GetDelivery(recId);
	}

	public Task<int> GetDeliveryAsync(long recId)
	{
		return base.Channel.GetDeliveryAsync(recId);
	}

	public int GetDelivery2(string recId)
	{
		return base.Channel.GetDelivery2(recId);
	}

	public Task<int> GetDelivery2Async(string recId)
	{
		return base.Channel.GetDelivery2Async(recId);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetMultiDeliveryResponse SendSoap.GetMultiDelivery(GetMultiDeliveryRequest request)
	{
		return base.Channel.GetMultiDelivery(request);
	}

	public byte[] GetMultiDelivery(string recId)
	{
		GetMultiDeliveryRequest getMultiDeliveryRequest = new GetMultiDeliveryRequest();
		getMultiDeliveryRequest.recId = recId;
		return ((SendSoap)this).GetMultiDelivery(getMultiDeliveryRequest).GetMultiDeliveryResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetMultiDeliveryResponse> SendSoap.GetMultiDeliveryAsync(GetMultiDeliveryRequest request)
	{
		return base.Channel.GetMultiDeliveryAsync(request);
	}

	public Task<GetMultiDeliveryResponse> GetMultiDeliveryAsync(string recId)
	{
		GetMultiDeliveryRequest getMultiDeliveryRequest = new GetMultiDeliveryRequest();
		getMultiDeliveryRequest.recId = recId;
		return ((SendSoap)this).GetMultiDeliveryAsync(getMultiDeliveryRequest);
	}

	public string[] GetMultiDelivery2(string recId)
	{
		return base.Channel.GetMultiDelivery2(recId);
	}

	public Task<string[]> GetMultiDelivery2Async(string recId)
	{
		return base.Channel.GetMultiDelivery2Async(recId);
	}

	public int[] GetDeliveries(long[] recIds, string username, string password)
	{
		return base.Channel.GetDeliveries(recIds, username, password);
	}

	public Task<int[]> GetDeliveriesAsync(long[] recIds, string username, string password)
	{
		return base.Channel.GetDeliveriesAsync(recIds, username, password);
	}

	public int GetDeliveries2(string recId)
	{
		return base.Channel.GetDeliveries2(recId);
	}

	public Task<int> GetDeliveries2Async(string recId)
	{
		return base.Channel.GetDeliveries2Async(recId);
	}

	public int[] GetDeliveries3(string[] recId, string username, string password)
	{
		return base.Channel.GetDeliveries3(recId, username, password);
	}

	public Task<int[]> GetDeliveries3Async(string[] recId, string username, string password)
	{
		return base.Channel.GetDeliveries3Async(recId, username, password);
	}

	public int GetInboxCount(string username, string password, bool isRead)
	{
		return base.Channel.GetInboxCount(username, password, isRead);
	}

	public Task<int> GetInboxCountAsync(string username, string password, bool isRead)
	{
		return base.Channel.GetInboxCountAsync(username, password, isRead);
	}

	public MessagesBL[] getMessages(string username, string password, int location, string from, int index, int count)
	{
		return base.Channel.getMessages(username, password, location, from, index, count);
	}

	public Task<MessagesBL[]> getMessagesAsync(string username, string password, int location, string from, int index, int count)
	{
		return base.Channel.getMessagesAsync(username, password, location, from, index, count);
	}

	public string SendByBaseNumber(string username, string password, string[] text, string to, int bodyId)
	{
		return base.Channel.SendByBaseNumber(username, password, text, to, bodyId);
	}

	public Task<string> SendByBaseNumberAsync(string username, string password, string[] text, string to, int bodyId)
	{
		return base.Channel.SendByBaseNumberAsync(username, password, text, to, bodyId);
	}

	public string SendByBaseNumber2(string username, string password, string text, string to, int bodyId)
	{
		return base.Channel.SendByBaseNumber2(username, password, text, to, bodyId);
	}

	public Task<string> SendByBaseNumber2Async(string username, string password, string text, string to, int bodyId)
	{
		return base.Channel.SendByBaseNumber2Async(username, password, text, to, bodyId);
	}

	public string SendByBaseNumber3(string username, string password, string text, string to)
	{
		return base.Channel.SendByBaseNumber3(username, password, text, to);
	}

	public Task<string> SendByBaseNumber3Async(string username, string password, string text, string to)
	{
		return base.Channel.SendByBaseNumber3Async(username, password, text, to);
	}
}
