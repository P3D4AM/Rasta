using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSFinancialPeriodViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FinancialPeriodListName")]
	public string Name { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FinancialPeriodListFDate")]
	public string FDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FinancialPeriodListTDate")]
	public string TDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FinancialPeriodListYear1")]
	public short? Year1 { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
