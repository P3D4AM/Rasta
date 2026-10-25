using System;
using System.Data.Objects;
using Elmah;
using GSD.Globalization;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class InternalMessage
{
	private readonly CRMEntities _db = new CRMEntities();

	public bool SendInternalmsgSingle(int userId, int? msgMasterId, string msgSubject, string msgBody, int msgTypeId, int msgFromUserId, int? msgToUserId, string msgSendDate, string msgSendTime, int msgPriorityId, string msgAttachFile, int? msgAttachRecId, string msgAttachRecDesc, int? msgGroupId, out int retId, int LanguageID, int? cId = null)
	{
		retId = 0;
		bool result = false;
		try
		{
			short value = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
			DateTime now = DateTime.Now;
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			if (!(msgMasterId > 0))
			{
				msgMasterId = null;
			}
			if (!(msgAttachRecId > 0))
			{
				msgAttachRecId = null;
			}
			if (!(msgGroupId > 0))
			{
				msgGroupId = null;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			int num = _db.MobspInternalMessageSendSingle(msgMasterId, msgSubject, msgBody, msgTypeId, msgFromUserId, msgToUserId, msgSendDate, msgSendTime, DateTime.Now, msgPriorityId, msgAttachFile, msgAttachRecId, msgAttachRecDesc, msgGroupId, userId, value, value2, value3, registerDatePersian, Configuration.AppType, objectParameter, LanguageID, null, null, cId);
			int num2 = (int)objectParameter.Value;
			if (num2 > 0)
			{
				retId = num2;
			}
			result = num > 0;
			PushNotif.NewIntMsgNotify(withthread: true, cId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			_db.Dispose();
		}
		return result;
	}
}
