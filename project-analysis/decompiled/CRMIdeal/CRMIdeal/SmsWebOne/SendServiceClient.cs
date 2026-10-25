using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class SendServiceClient : ClientBase<ISendService>, ISendService
{
	public SendServiceClient()
	{
	}

	public SendServiceClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public SendServiceClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SendServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public SendServiceClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SendSMSResponse ISendService.SendSMS(SendSMSRequest request)
	{
		return base.Channel.SendSMS(request);
	}

	public int SendSMS(string userName, string password, string fromNumber, string[] toNumbers, string messageContent, bool isFlash, ref long[] recId, ref byte[] status)
	{
		SendSMSRequest sendSMSRequest = new SendSMSRequest();
		sendSMSRequest.userName = userName;
		sendSMSRequest.password = password;
		sendSMSRequest.fromNumber = fromNumber;
		sendSMSRequest.toNumbers = toNumbers;
		sendSMSRequest.messageContent = messageContent;
		sendSMSRequest.isFlash = isFlash;
		sendSMSRequest.recId = recId;
		sendSMSRequest.status = status;
		SendSMSResponse sendSMSResponse = ((ISendService)this).SendSMS(sendSMSRequest);
		recId = sendSMSResponse.recId;
		status = sendSMSResponse.status;
		return sendSMSResponse.SendSMSResult;
	}

	public Task<SendSMSResponse> SendSMSAsync(SendSMSRequest request)
	{
		return base.Channel.SendSMSAsync(request);
	}

	public decimal GetCredit(string userName, string password)
	{
		return base.Channel.GetCredit(userName, password);
	}

	public Task<decimal> GetCreditAsync(string userName, string password)
	{
		return base.Channel.GetCreditAsync(userName, password);
	}

	public long GetDeilvery(string userName, string password, long recId)
	{
		return base.Channel.GetDeilvery(userName, password, recId);
	}

	public Task<long> GetDeilveryAsync(string userName, string password, long recId)
	{
		return base.Channel.GetDeilveryAsync(userName, password, recId);
	}

	public long GetDelivery(string userName, string password, long recId)
	{
		return base.Channel.GetDelivery(userName, password, recId);
	}

	public Task<long> GetDeliveryAsync(string userName, string password, long recId)
	{
		return base.Channel.GetDeliveryAsync(userName, password, recId);
	}

	public MessageInfo[] GetMessages(string userName, string password, int messageType, string[] fromNumbers, int index, int count)
	{
		return base.Channel.GetMessages(userName, password, messageType, fromNumbers, index, count);
	}

	public Task<MessageInfo[]> GetMessagesAsync(string userName, string password, int messageType, string[] fromNumbers, int index, int count)
	{
		return base.Channel.GetMessagesAsync(userName, password, messageType, fromNumbers, index, count);
	}

	public MessageInfo[] GetMessagesByDateRange(string userName, string password, int messageType, string[] fromNumbers, DateTime fromDate, DateTime toDate)
	{
		return base.Channel.GetMessagesByDateRange(userName, password, messageType, fromNumbers, fromDate, toDate);
	}

	public Task<MessageInfo[]> GetMessagesByDateRangeAsync(string userName, string password, int messageType, string[] fromNumbers, DateTime fromDate, DateTime toDate)
	{
		return base.Channel.GetMessagesByDateRangeAsync(userName, password, messageType, fromNumbers, fromDate, toDate);
	}

	public int GetInboxCount(string userName, string password, bool isRead)
	{
		return base.Channel.GetInboxCount(userName, password, isRead);
	}

	public Task<int> GetInboxCountAsync(string userName, string password, bool isRead)
	{
		return base.Channel.GetInboxCountAsync(userName, password, isRead);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SendBatchSmsResponse ISendService.SendBatchSms(SendBatchSmsRequest request)
	{
		return base.Channel.SendBatchSms(request);
	}

	public int SendBatchSms(string userName, string password, string fromNumber, string[] toNumbers, string messageContent, bool isFlash, out int batchSmsId)
	{
		SendBatchSmsRequest sendBatchSmsRequest = new SendBatchSmsRequest();
		sendBatchSmsRequest.userName = userName;
		sendBatchSmsRequest.password = password;
		sendBatchSmsRequest.fromNumber = fromNumber;
		sendBatchSmsRequest.toNumbers = toNumbers;
		sendBatchSmsRequest.messageContent = messageContent;
		sendBatchSmsRequest.isFlash = isFlash;
		SendBatchSmsResponse sendBatchSmsResponse = ((ISendService)this).SendBatchSms(sendBatchSmsRequest);
		batchSmsId = sendBatchSmsResponse.batchSmsId;
		return sendBatchSmsResponse.SendBatchSmsResult;
	}

	public Task<SendBatchSmsResponse> SendBatchSmsAsync(SendBatchSmsRequest request)
	{
		return base.Channel.SendBatchSmsAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetBatchDeliveryResponse ISendService.GetBatchDelivery(GetBatchDeliveryRequest request)
	{
		return base.Channel.GetBatchDelivery(request);
	}

	public int GetBatchDelivery(string userName, string password, int batchSmsId, int index, int count, out string[] numbers, out int[] deliveryStatus)
	{
		GetBatchDeliveryRequest getBatchDeliveryRequest = new GetBatchDeliveryRequest();
		getBatchDeliveryRequest.userName = userName;
		getBatchDeliveryRequest.password = password;
		getBatchDeliveryRequest.batchSmsId = batchSmsId;
		getBatchDeliveryRequest.index = index;
		getBatchDeliveryRequest.count = count;
		GetBatchDeliveryResponse batchDelivery = ((ISendService)this).GetBatchDelivery(getBatchDeliveryRequest);
		numbers = batchDelivery.numbers;
		deliveryStatus = batchDelivery.deliveryStatus;
		return batchDelivery.GetBatchDeliveryResult;
	}

	public Task<GetBatchDeliveryResponse> GetBatchDeliveryAsync(GetBatchDeliveryRequest request)
	{
		return base.Channel.GetBatchDeliveryAsync(request);
	}

	public string GetSenderNumbers(string userName, string password)
	{
		return base.Channel.GetSenderNumbers(userName, password);
	}

	public Task<string> GetSenderNumbersAsync(string userName, string password)
	{
		return base.Channel.GetSenderNumbersAsync(userName, password);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SendSmsLikeToLikeResponse ISendService.SendSmsLikeToLike(SendSmsLikeToLikeRequest request)
	{
		return base.Channel.SendSmsLikeToLike(request);
	}

	public int SendSmsLikeToLike(string userName, string password, string fromNumber, string[] toNumbers, string[] messageContents, bool isFlash, out int smsId)
	{
		SendSmsLikeToLikeRequest sendSmsLikeToLikeRequest = new SendSmsLikeToLikeRequest();
		sendSmsLikeToLikeRequest.userName = userName;
		sendSmsLikeToLikeRequest.password = password;
		sendSmsLikeToLikeRequest.fromNumber = fromNumber;
		sendSmsLikeToLikeRequest.toNumbers = toNumbers;
		sendSmsLikeToLikeRequest.messageContents = messageContents;
		sendSmsLikeToLikeRequest.isFlash = isFlash;
		SendSmsLikeToLikeResponse sendSmsLikeToLikeResponse = ((ISendService)this).SendSmsLikeToLike(sendSmsLikeToLikeRequest);
		smsId = sendSmsLikeToLikeResponse.smsId;
		return sendSmsLikeToLikeResponse.SendSmsLikeToLikeResult;
	}

	public Task<SendSmsLikeToLikeResponse> SendSmsLikeToLikeAsync(SendSmsLikeToLikeRequest request)
	{
		return base.Channel.SendSmsLikeToLikeAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetDeliveryLikeToLikeResponse ISendService.GetDeliveryLikeToLike(GetDeliveryLikeToLikeRequest request)
	{
		return base.Channel.GetDeliveryLikeToLike(request);
	}

	public int GetDeliveryLikeToLike(string userName, string password, int smsId, out string[] numbers, out int[] deliveryStatus)
	{
		GetDeliveryLikeToLikeRequest getDeliveryLikeToLikeRequest = new GetDeliveryLikeToLikeRequest();
		getDeliveryLikeToLikeRequest.userName = userName;
		getDeliveryLikeToLikeRequest.password = password;
		getDeliveryLikeToLikeRequest.smsId = smsId;
		GetDeliveryLikeToLikeResponse deliveryLikeToLike = ((ISendService)this).GetDeliveryLikeToLike(getDeliveryLikeToLikeRequest);
		numbers = deliveryLikeToLike.numbers;
		deliveryStatus = deliveryLikeToLike.deliveryStatus;
		return deliveryLikeToLike.GetDeliveryLikeToLikeResult;
	}

	public Task<GetDeliveryLikeToLikeResponse> GetDeliveryLikeToLikeAsync(GetDeliveryLikeToLikeRequest request)
	{
		return base.Channel.GetDeliveryLikeToLikeAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ExtractTelecomBlacklistNumbersResponse ISendService.ExtractTelecomBlacklistNumbers(ExtractTelecomBlacklistNumbersRequest request)
	{
		return base.Channel.ExtractTelecomBlacklistNumbers(request);
	}

	public int ExtractTelecomBlacklistNumbers(string userName, string password, string numbers, out string[] blacklistNumbers)
	{
		ExtractTelecomBlacklistNumbersRequest extractTelecomBlacklistNumbersRequest = new ExtractTelecomBlacklistNumbersRequest();
		extractTelecomBlacklistNumbersRequest.userName = userName;
		extractTelecomBlacklistNumbersRequest.password = password;
		extractTelecomBlacklistNumbersRequest.numbers = numbers;
		ExtractTelecomBlacklistNumbersResponse extractTelecomBlacklistNumbersResponse = ((ISendService)this).ExtractTelecomBlacklistNumbers(extractTelecomBlacklistNumbersRequest);
		blacklistNumbers = extractTelecomBlacklistNumbersResponse.blacklistNumbers;
		return extractTelecomBlacklistNumbersResponse.ExtractTelecomBlacklistNumbersResult;
	}

	public Task<ExtractTelecomBlacklistNumbersResponse> ExtractTelecomBlacklistNumbersAsync(ExtractTelecomBlacklistNumbersRequest request)
	{
		return base.Channel.ExtractTelecomBlacklistNumbersAsync(request);
	}

	public int NumberIsInTelecomBlacklist(string userName, string password, string number)
	{
		return base.Channel.NumberIsInTelecomBlacklist(userName, password, number);
	}

	public Task<int> NumberIsInTelecomBlacklistAsync(string userName, string password, string number)
	{
		return base.Channel.NumberIsInTelecomBlacklistAsync(userName, password, number);
	}

	public int CheckSmsContent(string userName, string password, string message)
	{
		return base.Channel.CheckSmsContent(userName, password, message);
	}

	public Task<int> CheckSmsContentAsync(string userName, string password, string message)
	{
		return base.Channel.CheckSmsContentAsync(userName, password, message);
	}

	public int Dummy(int number)
	{
		return base.Channel.Dummy(number);
	}

	public Task<int> DummyAsync(int number)
	{
		return base.Channel.DummyAsync(number);
	}
}
