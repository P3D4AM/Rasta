using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;

namespace CRMIdeal.Classes.Helper;

public class Leave
{
	public List<CRMspSelectLeaveStepGroups_Result> SelectLeaveStepGroups()
	{
		List<CRMspSelectLeaveStepGroups_Result> result = new List<CRMspSelectLeaveStepGroups_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			List<CRMspSelectLeaveStepGroups_Result> list = Enumerable.ToList<CRMspSelectLeaveStepGroups_Result>((IEnumerable<CRMspSelectLeaveStepGroups_Result>)cRMSpIIEntities.CRMspSelectLeaveStepGroups(Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (list != null)
			{
				foreach (CRMspSelectLeaveStepGroups_Result item in list)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public CRMspSelectLeaveStepGroupWithId_Result SelectLeaveStepGroupWithId(int id = 0)
	{
		CRMspSelectLeaveStepGroupWithId_Result result = new CRMspSelectLeaveStepGroupWithId_Result();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (id != 0)
			{
				CRMspSelectLeaveStepGroupWithId_Result cRMspSelectLeaveStepGroupWithId_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveStepGroupWithId_Result>((IEnumerable<CRMspSelectLeaveStepGroupWithId_Result>)cRMSpIIEntities.CRMspSelectLeaveStepGroupWithId(id, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
				if (cRMspSelectLeaveStepGroupWithId_Result != null)
				{
					cRMspSelectLeaveStepGroupWithId_Result.RegisterDatePersian = cRMspSelectLeaveStepGroupWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					cRMspSelectLeaveStepGroupWithId_Result.FirstRegisterDatePersian = cRMspSelectLeaveStepGroupWithId_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					result = cRMspSelectLeaveStepGroupWithId_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public List<CRMspSelectLeaveSteps_Result> SelectLeaveSteps(int groupId = 0)
	{
		List<CRMspSelectLeaveSteps_Result> result = new List<CRMspSelectLeaveSteps_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (groupId != 0)
			{
				List<CRMspSelectLeaveSteps_Result> list = Enumerable.ToList<CRMspSelectLeaveSteps_Result>((IEnumerable<CRMspSelectLeaveSteps_Result>)cRMSpIIEntities.CRMspSelectLeaveSteps(groupId, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
				if (list != null)
				{
					foreach (CRMspSelectLeaveSteps_Result item in list)
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					}
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public List<CRMspSelectLeaveSteps_Result> SelectLeaveStepsActive(int groupId = 0)
	{
		return Enumerable.ToList<CRMspSelectLeaveSteps_Result>(Enumerable.Where<CRMspSelectLeaveSteps_Result>((IEnumerable<CRMspSelectLeaveSteps_Result>)SelectLeaveSteps(groupId), (Func<CRMspSelectLeaveSteps_Result, bool>)((CRMspSelectLeaveSteps_Result x) => !x.lsInActive.GetValueOrDefault())));
	}

	public CRMspSelectLeaveStepWithId_Result SelectLeaveStepWithId(int id = 0)
	{
		CRMspSelectLeaveStepWithId_Result result = new CRMspSelectLeaveStepWithId_Result();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			CRMspSelectLeaveStepWithId_Result cRMspSelectLeaveStepWithId_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveStepWithId_Result>((IEnumerable<CRMspSelectLeaveStepWithId_Result>)cRMSpIIEntities.CRMspSelectLeaveStepWithId(id, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (cRMspSelectLeaveStepWithId_Result != null)
			{
				cRMspSelectLeaveStepWithId_Result.RegisterDatePersian = cRMspSelectLeaveStepWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeaveStepWithId_Result.FirstRegisterDatePersian = cRMspSelectLeaveStepWithId_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				result = cRMspSelectLeaveStepWithId_Result;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public List<CRMspSelectLeaveStepsWithTimeAttendance_Result> SelectLeaveStepsWithTimeAttendance(int leaveId = 0, int leaveStepGroupId = 0, DateTime? date = null, string datePer = "")
	{
		List<CRMspSelectLeaveStepsWithTimeAttendance_Result> result = new List<CRMspSelectLeaveStepsWithTimeAttendance_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (!string.IsNullOrWhiteSpace(datePer))
			{
				date = DateTimeClass.GetDateFromPersian(datePer);
			}
			List<CRMspSelectLeaveStepsWithTimeAttendance_Result> list = Enumerable.ToList<CRMspSelectLeaveStepsWithTimeAttendance_Result>((IEnumerable<CRMspSelectLeaveStepsWithTimeAttendance_Result>)cRMSpIIEntities.CRMspSelectLeaveStepsWithTimeAttendance(leaveId, leaveStepGroupId, date, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}
}
