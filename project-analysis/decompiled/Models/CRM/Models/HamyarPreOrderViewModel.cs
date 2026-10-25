using System.Collections.Generic;

namespace CRM.Models;

public class HamyarPreOrderViewModel
{
	public long centerCode { get; set; }

	public string tarikhSefaresh { get; set; }

	public string tarikhEtebarSefaresh { get; set; }

	public string tarikhTahvilSefaresh { get; set; }

	public string onvanSefareh { get; set; }

	public string codeMeliMoshtari { get; set; }

	public string tozihat { get; set; }

	public string sefareshIdCrm { get; set; }

	public string shomarehSefareshCrm { get; set; }

	public List<HamyarPreOrderItemViewModel> sefareshItems { get; set; }
}
