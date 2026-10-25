using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class PrintLog
{
	public static void InsertPrintLog(int objId, int printFormatTypeId, int mode)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			int userId = UserLogin.CurrentUser.UserId;
			DateTime? printDateTime = null;
			int? printUserId = null;
			int? printCmpId = null;
			DateTime? seenDateTime = null;
			int? seenUserId = null;
			int? seenCmpId = null;
			DateTime? downloadDateTime = null;
			int? downloadUserId = null;
			int? downloadCmpId = null;
			switch (mode)
			{
			case 1:
				printDateTime = value;
				printUserId = userId;
				break;
			case 2:
				seenDateTime = value;
				seenUserId = userId;
				break;
			case 3:
				downloadDateTime = value;
				downloadUserId = userId;
				break;
			}
			if (objId != 0 && printFormatTypeId != 0 && mode != 0 && mode != 2)
			{
				cRMSpEntities.MobspInsertPrintLog(printFormatTypeId, objId, printDateTime, printUserId, printCmpId, seenDateTime, seenUserId, seenCmpId, downloadDateTime, downloadUserId, downloadCmpId, appType, result);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
	}

	public static List<MobspSelectPrintLogWithPaging_Result> SelectPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		List<MobspSelectPrintLogWithPaging_Result> list = new List<MobspSelectPrintLogWithPaging_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<MobspSelectPrintLogWithPaging_Result>((IEnumerable<MobspSelectPrintLogWithPaging_Result>)cRMSpEntities.MobspSelectPrintLogWithPaging(objectId: objId, printFormatTypeId: printFormatTypeId, topValue: topValue, lastRowNumber: lastRowNumber, languageID: lCID, defaultLanguageID: result));
			if (list == null)
			{
				list = new List<MobspSelectPrintLogWithPaging_Result>();
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return list;
	}

	public static List<PrintLogViewModel> SelectListPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		List<PrintLogViewModel> list = new List<PrintLogViewModel>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string printLogPrintText = Labels.PrintLogPrintText;
			string printLogSeenText = Labels.PrintLogSeenText;
			string printLogDownloadText = Labels.PrintLogDownloadText;
			List<MobspSelectPrintLogWithPaging_Result> list2 = SelectPrintLog(objId, printFormatTypeId, topValue, lastRowNumber);
			if (list2 != null && Enumerable.Any<MobspSelectPrintLogWithPaging_Result>((IEnumerable<MobspSelectPrintLogWithPaging_Result>)list2))
			{
				foreach (MobspSelectPrintLogWithPaging_Result item in list2)
				{
					PrintLogViewModel printLogViewModel = new PrintLogViewModel();
					printLogViewModel.AppType = item.AppType;
					printLogViewModel.AppType = Configuration.GetAppType(printLogViewModel.AppType);
					printLogViewModel.PrintLogId = item.PrintLogId;
					printLogViewModel.ObjectId = item.ObjectId;
					printLogViewModel.PrintFormatTypeId = item.PrintFormatTypeId;
					printLogViewModel.PrintFormatType = item.PrintFormatType;
					printLogViewModel.PrintLogType = item.PrintLogType;
					if (!string.IsNullOrWhiteSpace(printLogViewModel.PrintLogType))
					{
						if (printLogViewModel.PrintLogType == "Print")
						{
							printLogViewModel.PrintLogTypeTitle = printLogPrintText;
							printLogViewModel.LogDateTime = item.PrintDateTime;
							printLogViewModel.LogUserId = item.PrintUserId;
							printLogViewModel.LogUser = item.PrintUser;
							printLogViewModel.LogCmpId = item.PrintCmpId;
							printLogViewModel.LogCmp = item.PrintCmp;
						}
						else if (printLogViewModel.PrintLogType == "Seen")
						{
							printLogViewModel.PrintLogTypeTitle = printLogSeenText;
							printLogViewModel.LogDateTime = item.SeenDateTime;
							printLogViewModel.LogUserId = item.SeenUserId;
							printLogViewModel.LogUser = item.SeenUser;
							printLogViewModel.LogCmpId = item.SeenCmpId;
							printLogViewModel.LogCmp = item.SeenCmp;
						}
						else if (printLogViewModel.PrintLogType == "Download")
						{
							printLogViewModel.PrintLogTypeTitle = printLogDownloadText;
							printLogViewModel.LogDateTime = item.DownloadDateTime;
							printLogViewModel.LogUserId = item.DownloadUserId;
							printLogViewModel.LogUser = item.DownloadUser;
							printLogViewModel.LogCmpId = item.DownloadCmpId;
							printLogViewModel.LogCmp = item.DownloadCmp;
						}
					}
					printLogViewModel.LogDate = (printLogViewModel.LogDateTime.HasValue ? printLogViewModel.LogDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					list.Add(printLogViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return list;
	}

	public static PrintLogListViewModel GetListPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		PrintLogListViewModel printLogListViewModel = new PrintLogListViewModel();
		printLogListViewModel.ListPrintLog = new List<PrintLogViewModel>();
		printLogListViewModel.LastRowNumber = 0L;
		printLogListViewModel.LastPrintLogId = 0;
		printLogListViewModel.LoadMore = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string printLogPrintText = Labels.PrintLogPrintText;
			string printLogSeenText = Labels.PrintLogSeenText;
			string printLogDownloadText = Labels.PrintLogDownloadText;
			List<MobspSelectPrintLogWithPaging_Result> list = SelectPrintLog(objId, printFormatTypeId, topValue, lastRowNumber);
			if (list != null && Enumerable.Any<MobspSelectPrintLogWithPaging_Result>((IEnumerable<MobspSelectPrintLogWithPaging_Result>)list))
			{
				foreach (MobspSelectPrintLogWithPaging_Result item in list)
				{
					PrintLogViewModel printLogViewModel = new PrintLogViewModel();
					printLogViewModel.AppType = item.AppType;
					printLogViewModel.AppType = Configuration.GetAppType(printLogViewModel.AppType);
					printLogViewModel.PrintLogId = item.PrintLogId;
					printLogViewModel.ObjectId = item.ObjectId;
					printLogViewModel.PrintFormatTypeId = item.PrintFormatTypeId;
					printLogViewModel.PrintFormatType = item.PrintFormatType;
					printLogViewModel.PrintLogType = item.PrintLogType;
					if (!string.IsNullOrWhiteSpace(printLogViewModel.PrintLogType))
					{
						if (printLogViewModel.PrintLogType == "Print")
						{
							printLogViewModel.PrintLogTypeTitle = printLogPrintText;
							printLogViewModel.LogDateTime = item.PrintDateTime;
							printLogViewModel.LogUserId = item.PrintUserId;
							printLogViewModel.LogUser = item.PrintUser;
							printLogViewModel.LogCmpId = item.PrintCmpId;
							printLogViewModel.LogCmp = item.PrintCmp;
						}
						else if (printLogViewModel.PrintLogType == "Seen")
						{
							printLogViewModel.PrintLogTypeTitle = printLogSeenText;
							printLogViewModel.LogDateTime = item.SeenDateTime;
							printLogViewModel.LogUserId = item.SeenUserId;
							printLogViewModel.LogUser = item.SeenUser;
							printLogViewModel.LogCmpId = item.SeenCmpId;
							printLogViewModel.LogCmp = item.SeenCmp;
						}
						else if (printLogViewModel.PrintLogType == "Download")
						{
							printLogViewModel.PrintLogTypeTitle = printLogDownloadText;
							printLogViewModel.LogDateTime = item.DownloadDateTime;
							printLogViewModel.LogUserId = item.DownloadUserId;
							printLogViewModel.LogUser = item.DownloadUser;
							printLogViewModel.LogCmpId = item.DownloadCmpId;
							printLogViewModel.LogCmp = item.DownloadCmp;
						}
					}
					printLogViewModel.LogDate = (printLogViewModel.LogDateTime.HasValue ? printLogViewModel.LogDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					printLogViewModel.RowNumber = item.RowNumber;
					printLogListViewModel.ListPrintLog.Add(printLogViewModel);
				}
				if (printLogListViewModel.ListPrintLog == null)
				{
					printLogListViewModel.ListPrintLog = new List<PrintLogViewModel>();
				}
				MobspSelectPrintLogWithPaging_Result mobspSelectPrintLogWithPaging_Result = Enumerable.LastOrDefault<MobspSelectPrintLogWithPaging_Result>((IEnumerable<MobspSelectPrintLogWithPaging_Result>)list);
				if (mobspSelectPrintLogWithPaging_Result != null)
				{
					printLogListViewModel.LastRowNumber = mobspSelectPrintLogWithPaging_Result.RowNumber;
					printLogListViewModel.LastPrintLogId = mobspSelectPrintLogWithPaging_Result.LastPrintLogId;
					if (mobspSelectPrintLogWithPaging_Result.LastPrintLogId.GetValueOrDefault() != mobspSelectPrintLogWithPaging_Result.PrintLogId)
					{
						printLogListViewModel.LoadMore = true;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return printLogListViewModel;
	}
}
