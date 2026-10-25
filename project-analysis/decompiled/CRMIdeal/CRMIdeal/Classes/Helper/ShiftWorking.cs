using System.Collections.Generic;
using System.Web.Mvc;
using CRM.Resources;

namespace CRMIdeal.Classes.Helper;

public class ShiftWorking
{
	public static List<SelectListItem> GetCalendareTypes(int? selectedId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		selectedId = selectedId.GetValueOrDefault();
		list.Add(new SelectListItem
		{
			Value = "1",
			Text = Labels.lblJalaliCalendare,
			Selected = (selectedId.GetValueOrDefault() == 1)
		});
		list.Add(new SelectListItem
		{
			Value = "2",
			Text = Labels.lblQamariCalendare,
			Selected = (selectedId.GetValueOrDefault() == 2)
		});
		list.Add(new SelectListItem
		{
			Value = "3",
			Text = Labels.lblMiladiCalendare,
			Selected = (selectedId.GetValueOrDefault() == 3)
		});
		return list;
	}

	public static List<SelectListItem> GetShiftWorkingTimeTypeId(int? selectedId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		selectedId = selectedId.GetValueOrDefault();
		list.Add(new SelectListItem
		{
			Value = "1",
			Selected = (selectedId.GetValueOrDefault() == 1),
			Text = Labels.ShiftWorkingTimeTypeDayWork
		});
		list.Add(new SelectListItem
		{
			Value = "2",
			Selected = (selectedId.GetValueOrDefault() == 1),
			Text = Labels.ShiftWorkingTimeTypeOvertime
		});
		list.Add(new SelectListItem
		{
			Value = "3",
			Selected = (selectedId.GetValueOrDefault() == 1),
			Text = Labels.ShiftWorkingTimeTypeHolidayWork
		});
		list.Add(new SelectListItem
		{
			Value = "4",
			Selected = (selectedId.GetValueOrDefault() == 1),
			Text = Labels.ShiftWorkingTimeTypeLunchBreak
		});
		return list;
	}
}
