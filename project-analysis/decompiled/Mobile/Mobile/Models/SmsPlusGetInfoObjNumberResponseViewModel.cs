using System;

namespace Mobile.Models;

public class SmsPlusGetInfoObjNumberResponseViewModel
{
	public string Number { get; set; }

	public bool? Lock { get; set; }

	public bool? Send { get; set; }

	public bool? Receive { get; set; }

	public bool? FilterCheck { get; set; }

	public bool? BackListCheck { get; set; }

	public DateTime? CreateDateTime { get; set; }
}
