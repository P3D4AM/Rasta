using System;
using System.Collections.Generic;
using System.Linq;
using Elmah;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Language
{
	public static List<FOMobspSelectLanguages_Result> GetLanguageList()
	{
		CRMEntities cRMEntities = new CRMEntities();
		List<FOMobspSelectLanguages_Result> result = new List<FOMobspSelectLanguages_Result>();
		try
		{
			List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}
}
