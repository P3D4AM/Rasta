using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.CallerIdService;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CallerIdServiceClient : ClientBase<ICallerIdService>, ICallerIdService
{
	public CallerIdServiceClient()
	{
	}

	public CallerIdServiceClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public CallerIdServiceClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CallerIdServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CallerIdServiceClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public bool SendMessage(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo, string users, string fileName, string duration, string[] voipInfo)
	{
		return base.Channel.SendMessage(username, password, facedMode, data, lineNumber, telNumber, callTypeId, telInfo, users, fileName, duration, voipInfo);
	}

	public Task<bool> SendMessageAsync(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo, string users, string fileName, string duration, string[] voipInfo)
	{
		return base.Channel.SendMessageAsync(username, password, facedMode, data, lineNumber, telNumber, callTypeId, telInfo, users, fileName, duration, voipInfo);
	}
}
