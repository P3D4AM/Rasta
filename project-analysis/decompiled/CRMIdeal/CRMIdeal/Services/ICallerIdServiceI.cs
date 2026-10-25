using System.ServiceModel;

namespace CRMIdeal.Services;

[ServiceContract]
public interface ICallerIdServiceI
{
	[OperationContract]
	bool SendMessage(string UserName, string Password, string LineNumber, string EventType, int CallType, string[] VoipInfo, string Extention = "", int CmpSearchMode = 0, string CmpSearchVal = "");
}
