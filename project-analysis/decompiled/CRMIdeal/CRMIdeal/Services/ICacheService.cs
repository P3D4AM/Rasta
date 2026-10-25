using System.ServiceModel;

namespace CRMIdeal.Services;

[ServiceContract]
public interface ICacheService
{
	[OperationContract]
	bool UpdateSettings(string username, string password);

	[OperationContract]
	bool UpdateUser(string username, string password, int userId);

	[OperationContract]
	bool ClearAll(string username, string password);

	[OperationContract]
	bool ClearUser(string username, string password, int userId);

	[OperationContract]
	bool ClearSetting(string username, string password);
}
