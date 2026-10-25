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

public class FoPrintLog
{
	public static void InsertPrintLog(int cmpId, int objId, int printFormatTypeId, int mode)
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
			int value2 = -10;
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
				printUserId = value2;
				printCmpId = cmpId;
				break;
			case 2:
				seenDateTime = value;
				seenUserId = value2;
				seenCmpId = cmpId;
				break;
			case 3:
				downloadDateTime = value;
				downloadUserId = value2;
				downloadCmpId = cmpId;
				break;
			}
			if (objId != 0 && printFormatTypeId != 0 && mode != 0 && cmpId != 0)
			{
				cRMSpEntities.FOMobspInsertPrintLog(printFormatTypeId, objId, printDateTime, printUserId, printCmpId, seenDateTime, seenUserId, seenCmpId, downloadDateTime, downloadUserId, downloadCmpId, appType, result);
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

	public static List<FOMobspSelectPrintLogWithPaging_Result> SelectPrintLog(int cmpId, int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		List<FOMobspSelectPrintLogWithPaging_Result> list = new List<FOMobspSelectPrintLogWithPaging_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<FOMobspSelectPrintLogWithPaging_Result>((IEnumerable<FOMobspSelectPrintLogWithPaging_Result>)cRMSpEntities.FOMobspSelectPrintLogWithPaging(cmpId, objectId: objId, printFormatTypeId: printFormatTypeId, topValue: topValue, lastRowNumber: lastRowNumber, languageID: lCID, defaultLanguageID: result));
			if (list == null)
			{
				list = new List<FOMobspSelectPrintLogWithPaging_Result>();
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

	public static FoPrintLogListViewModel GetListPrintLog(int cmpId, int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		FoPrintLogListViewModel foPrintLogListViewModel = new FoPrintLogListViewModel();
		foPrintLogListViewModel.ListPrintLog = new List<FoPrintLogViewModel>();
		foPrintLogListViewModel.LastRowNumber = 0L;
		foPrintLogListViewModel.LastPrintLogId = 0;
		foPrintLogListViewModel.LoadMore = false;
		CRMEntities cRMEntities = new CRMEntities();
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
			List<FOMobspSelectPrintLogWithPaging_Result> list = SelectPrintLog(cmpId, objId, printFormatTypeId, topValue, lastRowNumber);
			if (list != null && Enumerable.Any<FOMobspSelectPrintLogWithPaging_Result>((IEnumerable<FOMobspSelectPrintLogWithPaging_Result>)list))
			{
				foreach (FOMobspSelectPrintLogWithPaging_Result item in list)
				{
					FoPrintLogViewModel foPrintLogViewModel = new FoPrintLogViewModel();
					foPrintLogViewModel.AppType = item.AppType;
					foPrintLogViewModel.PrintLogId = item.PrintLogId;
					foPrintLogViewModel.ObjectId = item.ObjectId;
					foPrintLogViewModel.PrintFormatTypeId = item.PrintFormatTypeId;
					foPrintLogViewModel.PrintFormatType = item.PrintFormatType;
					foPrintLogViewModel.PrintLogType = item.PrintLogType;
					if (!string.IsNullOrWhiteSpace(foPrintLogViewModel.PrintLogType))
					{
						if (foPrintLogViewModel.PrintLogType == "Print")
						{
							foPrintLogViewModel.PrintLogTypeTitle = printLogPrintText;
							foPrintLogViewModel.LogDateTime = item.PrintDateTime;
							foPrintLogViewModel.LogUserId = item.PrintUserId;
							foPrintLogViewModel.LogUser = item.PrintUser;
							foPrintLogViewModel.LogCmpId = item.PrintCmpId;
							foPrintLogViewModel.LogCmp = item.PrintCmp;
						}
						else if (foPrintLogViewModel.PrintLogType == "Seen")
						{
							foPrintLogViewModel.PrintLogTypeTitle = printLogSeenText;
							foPrintLogViewModel.LogDateTime = item.SeenDateTime;
							foPrintLogViewModel.LogUserId = item.SeenUserId;
							foPrintLogViewModel.LogUser = item.SeenUser;
							foPrintLogViewModel.LogCmpId = item.SeenCmpId;
							foPrintLogViewModel.LogCmp = item.SeenCmp;
						}
						else if (foPrintLogViewModel.PrintLogType == "Download")
						{
							foPrintLogViewModel.PrintLogTypeTitle = printLogDownloadText;
							foPrintLogViewModel.LogDateTime = item.DownloadDateTime;
							foPrintLogViewModel.LogUserId = item.DownloadUserId;
							foPrintLogViewModel.LogUser = item.DownloadUser;
							foPrintLogViewModel.LogCmpId = item.DownloadCmpId;
							foPrintLogViewModel.LogCmp = item.DownloadCmp;
						}
					}
					foPrintLogViewModel.LogDate = (foPrintLogViewModel.LogDateTime.HasValue ? foPrintLogViewModel.LogDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					foPrintLogViewModel.RowNumber = item.RowNumber;
					foPrintLogListViewModel.ListPrintLog.Add(foPrintLogViewModel);
				}
				if (foPrintLogListViewModel.ListPrintLog == null)
				{
					foPrintLogListViewModel.ListPrintLog = new List<FoPrintLogViewModel>();
				}
				FOMobspSelectPrintLogWithPaging_Result fOMobspSelectPrintLogWithPaging_Result = Enumerable.LastOrDefault<FOMobspSelectPrintLogWithPaging_Result>((IEnumerable<FOMobspSelectPrintLogWithPaging_Result>)list);
				if (fOMobspSelectPrintLogWithPaging_Result != null)
				{
					foPrintLogListViewModel.LastRowNumber = fOMobspSelectPrintLogWithPaging_Result.RowNumber;
					foPrintLogListViewModel.LastPrintLogId = fOMobspSelectPrintLogWithPaging_Result.LastPrintLogId;
					if (fOMobspSelectPrintLogWithPaging_Result.LastPrintLogId.GetValueOrDefault() != fOMobspSelectPrintLogWithPaging_Result.PrintLogId)
					{
						foPrintLogListViewModel.LoadMore = true;
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
			cRMEntities.Dispose();
		}
		return foPrintLogListViewModel;
	}

	public static string SetLastPrintLogInfo(string lastPrintLogType, DateTime? lastPrintLogDateTime)
	{
		string text = "";
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
			if (!string.IsNullOrWhiteSpace(lastPrintLogType) && lastPrintLogDateTime.HasValue)
			{
				switch (lastPrintLogType)
				{
				case "Print":
					text = printLogPrintText;
					break;
				case "Seen":
					text = printLogSeenText;
					break;
				case "Download":
					text = printLogDownloadText;
					break;
				}
				text += (lastPrintLogDateTime.HasValue ? (" <smap>(" + lastPrintLogDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") + ")</smap>") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}
}
