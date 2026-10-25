using System;
using System.Data.Entity.Validation;
using CRMIdealApi.ApiModels;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Classes.Helper;

public class PrintLog
{
	public static void InsertPrintLog(int objId, int printFormatTypeId, int mode, int userId, int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
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
				int num3 = cRMEntities.ApispInsertPrintLog(printFormatTypeId, objId, printDateTime, printUserId, printCmpId, seenDateTime, seenUserId, seenCmpId, downloadDateTime, downloadUserId, downloadCmpId, appType, defLangId);
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
			cRMEntities.Dispose();
		}
	}
}
