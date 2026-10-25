using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace CRMIdeal;

public class BypassCacheSelector : DefaultHttpControllerSelector
{
	private readonly HttpConfiguration _configuration;

	public BypassCacheSelector(HttpConfiguration configuration)
		: base(configuration)
	{
		_configuration = configuration;
	}

	public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
	{
		List<Type> list = Enumerable.ToList<Type>(Enumerable.Where<Type>((IEnumerable<Type>)Assembly.Load("RegisterCompany").GetTypes(), (Func<Type, bool>)((Type i) => typeof(IHttpController).IsAssignableFrom(i))));
		Type[] types = Assembly.Load("Mobile").GetTypes();
		list.AddRange(Enumerable.Where<Type>((IEnumerable<Type>)types, (Func<Type, bool>)((Type i) => typeof(IHttpController).IsAssignableFrom(i))));
		Type[] types2 = Assembly.Load("CRMIdealApi").GetTypes();
		list.AddRange(Enumerable.Where<Type>((IEnumerable<Type>)types2, (Func<Type, bool>)((Type i) => typeof(IHttpController).IsAssignableFrom(i))));
		Type[] types3 = Assembly.Load("CRMIdeal").GetTypes();
		list.AddRange(Enumerable.Where<Type>((IEnumerable<Type>)types3, (Func<Type, bool>)((Type i) => typeof(IHttpController).IsAssignableFrom(i))));
		string controllerName = base.GetControllerName(request);
		Type controllerType = Enumerable.FirstOrDefault<Type>((IEnumerable<Type>)list, (Func<Type, bool>)((Type i) => i.Name.ToLower() == controllerName.ToLower() + "controller"));
		return new HttpControllerDescriptor(_configuration, controllerName, controllerType);
	}
}
