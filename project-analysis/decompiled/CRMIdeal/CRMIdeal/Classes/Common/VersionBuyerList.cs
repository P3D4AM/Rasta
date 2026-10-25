using System.Collections.Generic;
using CRM.Models;
using CRM.Resources;

namespace CRMIdeal.Classes.Common;

public static class VersionBuyerList
{
	public static List<CommonSystemPartViewModel> Get(string sysPartKey = "")
	{
		List<CommonSystemPartViewModel> list = new List<CommonSystemPartViewModel>();
		list.Add(new CommonSystemPartViewModel
		{
			Id = "10",
			Name = "Cmp",
			Caption = Labels.Company,
			Enabled = VersionBuyer.Customers
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "11",
			Name = "Prs",
			Caption = Labels.cmpPersonSectionTitle,
			Enabled = false
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "20",
			Name = "Pord",
			Caption = Labels.PreOrder,
			Enabled = false
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "40",
			Name = "Bord",
			Caption = Labels.buyOrderText,
			Enabled = false
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "30",
			Name = "Ord",
			Caption = Labels.Order,
			Enabled = false
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "70",
			Name = "Prd",
			Caption = Labels.Products,
			Enabled = false
		});
		list.Add(new CommonSystemPartViewModel
		{
			Id = "140",
			Name = "User",
			Caption = Labels.User,
			Enabled = false
		});
		if (!string.IsNullOrWhiteSpace(sysPartKey) && list.FindIndex((CommonSystemPartViewModel x) => x.Name == sysPartKey) != -1)
		{
			list[list.FindIndex((CommonSystemPartViewModel x) => x.Name == sysPartKey)].Selected = true;
		}
		return list;
	}

	public static List<CommonSystemPartViewModel> GetImportExcel(string sysPartKey = "")
	{
		List<CommonSystemPartViewModel> list = Get(sysPartKey);
		int num = -1;
		num = list.FindIndex((CommonSystemPartViewModel x) => x.Name == "User");
		if (num >= 0)
		{
			list[num].Enabled = VersionBuyer.UserImportExcel;
		}
		num = list.FindIndex((CommonSystemPartViewModel x) => x.Name == "Cmp");
		if (num >= 0)
		{
			list[num].Enabled = VersionBuyer.CmpImportExcel;
		}
		return list;
	}
}
