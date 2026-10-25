using System.ServiceModel;

namespace CRMIdeal.Services;

[ServiceContract]
public interface IAutomaticEventsService
{
	[OperationContract]
	bool CallAutomaticEvents(string username, string password);
}
