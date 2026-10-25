using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace CRM.General.Utilities;

public static class Tools
{
	public static List<string> GetListOfErrors(this ModelStateDictionary modelState)
	{
		List<KeyValuePair<string, ModelState>> list = Enumerable.ToList<KeyValuePair<string, ModelState>>((IEnumerable<KeyValuePair<string, ModelState>>)modelState);
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, ModelState> item in list)
		{
			list2.AddRange(Enumerable.Select<ModelError, string>((IEnumerable<ModelError>)item.Value.Errors, (Func<ModelError, string>)((ModelError error) => error.ErrorMessage)));
		}
		return list2;
	}
}
