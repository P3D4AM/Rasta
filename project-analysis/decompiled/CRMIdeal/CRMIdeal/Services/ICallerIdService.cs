using System.ServiceModel;

namespace CRMIdeal.Services;

[ServiceContract]
public interface ICallerIdService
{
	[OperationContract]
	bool SendMessage(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo = null, string users = "", string fileName = "", string duration = "", string[] voipInfo = null, string exten = "", int devType = 1);
}
