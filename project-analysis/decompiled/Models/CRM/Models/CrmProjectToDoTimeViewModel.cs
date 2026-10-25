using System;

namespace CRM.Models;

public class CrmProjectToDoTimeViewModel
{
	public string prjToDoTimeStr { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public string prjToDoTimeStrTime { get; set; }

	public string prjToDoTimeRegisterStr { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public string prjToDoTimeRegisterTime { get; set; }

	public string prjToDoTimeDoneStr { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public string prjToDoTimeDoneTime { get; set; }

	public string prjToDoTimeRegisterHistory { get; set; }

	public string prjToDoTimeSecStr { get; set; }

	public long? prjToDoTimeSec { get; set; }
}
