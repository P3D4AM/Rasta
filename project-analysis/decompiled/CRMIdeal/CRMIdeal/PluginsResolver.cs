using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace CRMIdeal;

public class PluginsResolver : DefaultAssembliesResolver
{
	public override ICollection<Assembly> GetAssemblies()
	{
		ICollection<Assembly> assemblies = base.GetAssemblies();
		List<Assembly> result = new List<Assembly>(assemblies);
		Assembly item = Assembly.Load("RegisterCompany");
		assemblies.Add(item);
		item = Assembly.Load("Mobile");
		assemblies.Add(item);
		item = Assembly.Load("CRMIdealApi");
		assemblies.Add(item);
		return result;
	}
}
