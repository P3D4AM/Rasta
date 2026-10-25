using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.CallerIdService;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "CallerIdService.ICallerIdService")]
public interface ICallerIdService
{
	[OperationContract(Action = "http://tempuri.org/ICallerIdService/SendMessage", ReplyAction = "http://tempuri.org/ICallerIdService/SendMessageResponse")]
	bool SendMessage(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo, string users, string fileName, string duration, string[] voipInfo);

	[OperationContract(Action = "http://tempuri.org/ICallerIdService/SendMessage", ReplyAction = "http://tempuri.org/ICallerIdService/SendMessageResponse")]
	Task<bool> SendMessageAsync(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo, string users, string fileName, string duration, string[] voipInfo);
}
