using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Resources;
using Elmah;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class FoDyForm
{
	public static bool IsChecked(int mValId, ref string msg)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			FOMobspDySelectFormFieldMasterValueWithId_Result fOMobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<FOMobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<FOMobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.FOMobspDySelectFormFieldMasterValueWithId(mValId));
			if (fOMobspDySelectFormFieldMasterValueWithId_Result != null && fOMobspDySelectFormFieldMasterValueWithId_Result.IsChecked.HasValue && fOMobspDySelectFormFieldMasterValueWithId_Result.IsChecked.GetValueOrDefault())
			{
				DateTime.TryParse(fOMobspDySelectFormFieldMasterValueWithId_Result.CheckedDate.ToString(), out var result2);
				msg = string.Format(Messages.FOMobMsgFormIsChecked, fOMobspDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId, result2.ToString("yyyy/MM/dd"));
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetFromName(int formId, int defLangId, int currLangId, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			FOMobspDySelectForms_Result fOMobspDySelectForms_Result = Enumerable.FirstOrDefault<FOMobspDySelectForms_Result>((IEnumerable<FOMobspDySelectForms_Result>)cRMEntities.FOMobspDySelectForms(formId, 0, currLangId, defLangId, cId));
			if (fOMobspDySelectForms_Result != null)
			{
				result = ((!string.IsNullOrEmpty(fOMobspDySelectForms_Result.FormName)) ? fOMobspDySelectForms_Result.FormName : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result;
	}
}
