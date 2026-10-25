using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class InternalMessage
{
	public bool SendIntmsgSingle(int? msgMasterId, string msgSubject, string msgBody, int msgTypeId, int msgFromUserId, int? msgToUserId, string msgSendDate, string msgSendTime, int msgPriorityId, string msgAttachFile, int? msgAttachRecId, string msgAttachRecDesc, int? msgGroupId, out int retId, int LanguageID, int cId = 0)
	{
		retId = 0;
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int userId = UserLogin.CurrentUser.UserId;
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
			string appType = Configuration.AppType;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (cId != 0)
			{
				centerId = cId;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			int num = cRMSpEntities.CRMspInternalMessageSendSingle(msgMasterId, msgSubject, msgBody, msgTypeId, msgFromUserId, msgToUserId, msgSendDate, msgSendTime, now, msgPriorityId, msgAttachFile, msgAttachRecId, msgAttachRecDesc, msgGroupId, userId, value, value2, value3, registerDatePersian, appType, objectParameter, LanguageID, null, null, centerId);
			int num2 = (int)objectParameter.Value;
			if (num2 > 0)
			{
				retId = num2;
			}
			result = num > 0;
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public bool SendInternalMessage(int? msgMasterId, string msgSubject, string msgBody, int msgTypeId, int msgFromUserId, int? msgToUserId, string msgSendDate, string msgSendTime, int msgPriorityId, string msgAttachFile, int? msgAttachRecId, string msgAttachRecDesc, int? msgGroupId, int LanguageID, string msgSubject_Lang = "", string msgBody_Lang = "", int userId = -15)
	{
		int num = 0;
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			short value = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
			DateTime now = DateTime.Now;
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			int num2 = cRMSpEntities.CRMspInternalMessageSendSingle(msgMasterId, msgSubject, msgBody, msgTypeId, msgFromUserId, msgToUserId, msgSendDate, msgSendTime, now, msgPriorityId, msgAttachFile, msgAttachRecId, msgAttachRecDesc, msgGroupId, userId, value, value2, value3, registerDatePersian, appType, objectParameter, LanguageID, null, null, centerId);
			int num3 = (int)objectParameter.Value;
			if (num3 > 0)
			{
				num = num3;
				if (num > 0)
				{
					CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
					if (string.IsNullOrWhiteSpace(msgSubject_Lang) && string.IsNullOrWhiteSpace(msgBody_Lang))
					{
						foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != LanguageID))))
						{
							CrmInternalMessage_Lang entity = new CrmInternalMessage_Lang
							{
								LanguageID = item.LanguageID,
								InternalMessageID = num,
								msgBody = msgBody,
								msgSubject = msgSubject
							};
							cRMTabelEntities.CrmInternalMessage_Lang.Add(entity);
							cRMTabelEntities.SaveChanges();
						}
					}
					cRMTabelEntities.Dispose();
				}
			}
			result = num2 > 0;
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
