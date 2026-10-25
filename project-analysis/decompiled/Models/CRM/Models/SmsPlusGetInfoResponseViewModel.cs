using System;
using System.Collections.Generic;

namespace CRM.Models;

public class SmsPlusGetInfoResponseViewModel
{
	public SmsPlusErrorViewModel Error { get; set; }

	public decimal? Credit { get; set; }

	public decimal? BasicRate { get; set; }

	public DateTime? ExpireDate { get; set; }

	public List<SmsPlusGetInfoObjNumberResponseViewModel> Numbers { get; set; }
}
