using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CRMIdealApi.DataType;

public class ServiceResult<T>
{
	public T Data;

	[JsonConverter(typeof(StringEnumConverter))]
	public ServiceResultStatus Status;

	public string Message;

	public ServiceResult()
	{
		Status = ServiceResultStatus.Success;
	}

	public ServiceResult(ServiceResultStatus type)
	{
		Status = type;
	}
}
