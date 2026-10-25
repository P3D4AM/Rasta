using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Models;

public class AdvanceResultViewModel : AdvanceResultItemViewModel
{
	public AdvanceResultItemViewModel Center { get; set; } = new AdvanceResultItemViewModel();


	public List<AdvanceResultItemViewModel> Centers { get; set; } = new List<AdvanceResultItemViewModel>();


	public static int GetErrorsCnt(AdvanceResultViewModel vm)
	{
		return 0 + vm.Errors.Count + Enumerable.Sum<AdvanceResultItemViewModel>((IEnumerable<AdvanceResultItemViewModel>)vm.Centers, (Func<AdvanceResultItemViewModel, int>)((AdvanceResultItemViewModel x) => x.Errors.Count)) + vm.Center.Errors.Count;
	}

	public static int GetErrorsCnt(List<AdvanceResultViewModel> vm)
	{
		int num = 0;
		foreach (AdvanceResultViewModel item in vm)
		{
			num += GetErrorsCnt(item);
		}
		return num;
	}
}
