using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace CRMIdeal;

public class CustomHttpControllerTypeResolver : DefaultHttpControllerTypeResolver
{
	public CustomHttpControllerTypeResolver()
		: base(IsHttpEndpoint)
	{
	}

	internal static bool IsHttpEndpoint(Type t)
	{
		if (t == null)
		{
			throw new ArgumentNullException("t");
		}
		if (t.IsClass && t.IsVisible && !t.IsAbstract)
		{
			return typeof(ApiController).IsAssignableFrom(t);
		}
		return false;
	}
}
