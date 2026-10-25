using System;

namespace CRM.Models;

public class DyFormChartPrintFormFieldItemsDateFieldType
{
	public int? FormId { get; set; }

	public int? FormFieldId { get; set; }

	public string Text { get; set; }

	public string Value { get; set; }

	public DateTime? ValueDate { get; set; }

	public int ValueYear { get; set; }

	public int ValueMonth { get; set; }

	public int ValueDay { get; set; }

	public int? OrderView { get; set; }

	public int? CNT { get; set; }
}
