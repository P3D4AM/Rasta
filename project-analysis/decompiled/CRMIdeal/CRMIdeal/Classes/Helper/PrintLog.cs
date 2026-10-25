using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class PrintLog
{
	public static void InsertPrintLog(int objId, int printFormatTypeId, int mode, int? seenCmpId = null)
	{
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
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
			int value2 = -3;
			if (UserLogin.CurrentUser != null)
			{
				value2 = UserLogin.CurrentUser.UserId;
			}
			DateTime? printDateTime = null;
			int? printUserId = null;
			int? printCmpId = null;
			DateTime? seenDateTime = null;
			int? seenUserId = null;
			DateTime? downloadDateTime = null;
			int? downloadUserId = null;
			int? downloadCmpId = null;
			switch (mode)
			{
			case 1:
				printDateTime = value;
				printUserId = value2;
				break;
			case 2:
				seenDateTime = value;
				seenUserId = value2;
				break;
			case 3:
				downloadDateTime = value;
				downloadUserId = value2;
				break;
			}
			if (objId != 0 && printFormatTypeId != 0 && mode != 0 && mode != 2)
			{
				cRMSpIEntities.CRMspInsertPrintLog(printFormatTypeId, objId, printDateTime, printUserId, printCmpId, seenDateTime, seenUserId, seenCmpId, downloadDateTime, downloadUserId, downloadCmpId, appType, result);
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
			cRMSpIEntities.Dispose();
		}
	}

	public static List<CRMspSelectPrintLogWithPaging_Result> SelectPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		List<CRMspSelectPrintLogWithPaging_Result> list = new List<CRMspSelectPrintLogWithPaging_Result>();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectPrintLogWithPaging_Result>((IEnumerable<CRMspSelectPrintLogWithPaging_Result>)cRMSpIEntities.CRMspSelectPrintLogWithPaging(objectId: objId, printFormatTypeId: printFormatTypeId, topValue: topValue, lastRowNumber: lastRowNumber, languageID: lCID, defaultLanguageID: result));
			if (list == null)
			{
				list = new List<CRMspSelectPrintLogWithPaging_Result>();
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
			cRMSpIEntities.Dispose();
		}
		return list;
	}

	public static List<PrintLogViewModel> SelectListPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		List<PrintLogViewModel> list = new List<PrintLogViewModel>();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
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
			List<CRMspSelectPrintLogWithPaging_Result> list2 = SelectPrintLog(objId, printFormatTypeId, topValue, lastRowNumber);
			if (list2 != null && Enumerable.Any<CRMspSelectPrintLogWithPaging_Result>((IEnumerable<CRMspSelectPrintLogWithPaging_Result>)list2))
			{
				foreach (CRMspSelectPrintLogWithPaging_Result item in list2)
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
			cRMSpIEntities.Dispose();
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
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
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
			List<CRMspSelectPrintLogWithPaging_Result> list = SelectPrintLog(objId, printFormatTypeId, topValue, lastRowNumber);
			if (list != null && Enumerable.Any<CRMspSelectPrintLogWithPaging_Result>((IEnumerable<CRMspSelectPrintLogWithPaging_Result>)list))
			{
				foreach (CRMspSelectPrintLogWithPaging_Result item in list)
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
				CRMspSelectPrintLogWithPaging_Result cRMspSelectPrintLogWithPaging_Result = Enumerable.LastOrDefault<CRMspSelectPrintLogWithPaging_Result>((IEnumerable<CRMspSelectPrintLogWithPaging_Result>)list);
				if (cRMspSelectPrintLogWithPaging_Result != null)
				{
					printLogListViewModel.LastRowNumber = cRMspSelectPrintLogWithPaging_Result.RowNumber;
					printLogListViewModel.LastPrintLogId = cRMspSelectPrintLogWithPaging_Result.LastPrintLogId;
					if (cRMspSelectPrintLogWithPaging_Result.LastPrintLogId.GetValueOrDefault() != cRMspSelectPrintLogWithPaging_Result.PrintLogId)
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
			cRMSpIEntities.Dispose();
		}
		return printLogListViewModel;
	}
}
