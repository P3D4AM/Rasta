using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using CRM.Models;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace CRMIdeal.Hubs;

[HubName("chatHub")]
public class ChatHub : Hub
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnChangeEventHandler _003C0_003E__MessageDependency_OnChange;

		public static OnChangeEventHandler _003C1_003E__SmsDependency_OnChange;

		public static OnChangeEventHandler _003C2_003E__TicketDependency_OnChange;

		public static OnChangeEventHandler _003C3_003E__SmsTankDependency_OnChange;

		public static OnChangeEventHandler _003C4_003E__TelegramDependency_OnChange;

		public static OnChangeEventHandler _003C5_003E__EmailTankDependency_OnChange;

		public static OnChangeEventHandler _003C6_003E__EmailDependency_OnChange;
	}

	private static readonly object _lock = new object();

	private static readonly object _smslock = new object();

	private static readonly object _smstanklock = new object();

	private static readonly object _emaillock = new object();

	private static readonly object _emailtanklock = new object();

	private static readonly ConcurrentDictionary<string, UsersSignalR> Users = new ConcurrentDictionary<string, UsersSignalR>();

	private static readonly object _notificationLock = new object();

	private static readonly object _messagenotificationLock = new object();

	private static readonly object _smsnotificationLock = new object();

	private static readonly object _ticketnotificationLock = new object();

	private static readonly object _smsTanknotificationLock = new object();

	private static readonly object _telegramnotificationLock = new object();

	private static readonly object _emailTanknotificationLock = new object();

	private static readonly object _emailnotificationLock = new object();

	private static SqlDependency _messageDependency;

	private static SqlDependency _smsDependency;

	private static SqlDependency _ticketDependency;

	private static SqlDependency _smsTankDependency;

	private static SqlDependency _telegramDependency;

	private static SqlDependency _emailTankDependency;

	private static SqlDependency _emailDependency;

	private static bool _messageDependencyStarted = false;

	private static bool _smsDependencyStarted = false;

	private static bool _ticketDependencyStarted = false;

	private static bool _smsTankDependencyStarted = false;

	private static bool _telegramDependencyStarted = false;

	private static bool _emailTankDependencyStarted = false;

	private static bool _emailDependencyStarted = false;

	private static int _smsTankStarted;

	private static int _telegramStarted;

	private static int _emailTankStarted;

	private static int _emailStarted;

	private static readonly List<ChatUserInfoViewModel> UsersList = new List<ChatUserInfoViewModel>();

	private static readonly object _lockChat = new object();

	private static readonly List<UserOnlineViewModel> UserOnlineForIntMsgList = new List<UserOnlineViewModel>();

	private static readonly object _lockNotifWinForIntMsg = new object();

	private static string ConnectionString
	{
		get
		{
			using CRMSpEntities cRMSpEntities = new CRMSpEntities();
			return cRMSpEntities.Database.Connection.ConnectionString;
		}
	}

	public static void StartNotificationDependencies()
	{
		lock (_notificationLock)
		{
			try
			{
				StartMessageNotification();
				StartSmsNotification();
				StartTicketNotification();
				StartSmsTankNotification();
				StartTelegramNotification();
				StartEmailTankNotification();
				StartEmailNotification();
			}
			catch (Exception ex)
			{
				Logs.LogError(ex, "StartNotificationDependencies");
			}
		}
	}

	public void Send(string name, string message)
	{
		base.Clients.All.addNewMessageToPage(name, message);
	}

	public void showMessage(int userid)
	{
		lock (_lock)
		{
			base.Clients.All.broadcastMessage(DoJob());
		}
	}

	public string DoJob()
	{
		string text = "";
		int result = 0;
		IIdentity identity = base.Context.Request.GetHttpContext().User.Identity;
		if (identity != null)
		{
			int.TryParse(identity.Name, out result);
		}
		if (result > 0)
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
			try
			{
				int num = 0;
				num = User.GetUserLastCId(result, 1065, 1065);
				int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.CRMspIntMsgGetUnReadMessge(result, num));
				CRMspIntMsgGetUnReadVerify_Result cRMspIntMsgGetUnReadVerify_Result = Enumerable.FirstOrDefault<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)cRMSpEntities.CRMspIntMsgGetUnReadVerify(result, num));
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIEntities.CRMspGetUnReadSmsReceiveCnt()).GetValueOrDefault();
				if (num2.HasValue)
				{
					int? num3 = num2;
					text = num3 + "|";
				}
				else
				{
					text = "0|";
				}
				if (cRMspIntMsgGetUnReadVerify_Result != null && cRMspIntMsgGetUnReadVerify_Result.Cnt.HasValue)
				{
					text = text + cRMspIntMsgGetUnReadVerify_Result.Cnt + "|";
					text = text + cRMspIntMsgGetUnReadVerify_Result.msgdTypeId + "|";
					text = text + cRMspIntMsgGetUnReadVerify_Result.InternalMessageID + "|";
				}
				else
				{
					text += "0|0|0|";
				}
				text += valueOrDefault;
				text = text + "|" + result;
			}
			catch (Exception ex)
			{
				Logs.LogError(ex, "");
			}
			finally
			{
				cRMSpEntities.Dispose();
				cRMSpIIEntities.Dispose();
			}
		}
		return text;
	}

	public static void StartMessageNotification()
	{
		lock (_messagenotificationLock)
		{
			if (!_messageDependencyStarted)
			{
				_messageDependencyStarted = true;
				SubscribeMessageDependency();
			}
		}
	}

	private static void SubscribeMessageDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [InternalMessageDetailID] FROM [dbo].[CrmInternalMessageDetails] WHERE ISNULL([msgdIsRead],0) = 0", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C0_003E__MessageDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = MessageDependency_OnChange;
				_003C_003EO._003C0_003E__MessageDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_messageDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_messageDependencyStarted = false;
			Logs.LogError(ex, "SubscribeMessageDependency");
		}
	}

	private static void MessageDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_messagenotificationLock)
			{
				_messageDependency = null;
			}
			lock (_messagenotificationLock)
			{
				SubscribeMessageDependency();
			}
			SendNotificationsInternal();
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "MessageDependency_OnChange");
		}
	}

	[HubMethodName("sendNotifications")]
	public void SendNotifications()
	{
		SendNotificationsInternal();
	}

	private static void SendNotificationsInternal()
	{
		try
		{
			if (Users == null || !Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				return;
			}
			List<CommonMessageViewModel> list = new List<CommonMessageViewModel>();
			int result6;
			string text = string.Join(",", Enumerable.Distinct<int>(Enumerable.Where<int>(Enumerable.Select<string, int>((IEnumerable<string>)Users.Keys, (Func<string, int>)((string x) => int.TryParse(x, out result6) ? result6 : 0)), (Func<int, bool>)((int x) => x > 0))));
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			using (CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities())
			{
				List<CRMspIntMsgGetUnReadMessgeForUsers_Result> list2 = Enumerable.ToList<CRMspIntMsgGetUnReadMessgeForUsers_Result>((IEnumerable<CRMspIntMsgGetUnReadMessgeForUsers_Result>)cRMSpIIIEntities.CRMspIntMsgGetUnReadMessgeForUsers(text));
				if (list2 != null)
				{
					foreach (CRMspIntMsgGetUnReadMessgeForUsers_Result item in list2)
					{
						int result = 0;
						int.TryParse((!item.UserId.HasValue) ? "0" : item.UserId.ToString(), out result);
						if (result > 0)
						{
							int result2 = 0;
							_ = item.MessageCnt;
							int.TryParse(item.MessageCnt.ToString(), out result2);
							int result3 = 0;
							_ = item.VerifyCnt;
							int.TryParse(item.VerifyCnt.ToString(), out result3);
							int result4 = 0;
							int.TryParse((!item.MsgdTypeId.HasValue) ? "0" : item.MsgdTypeId.ToString(), out result4);
							int result5 = 0;
							int.TryParse((!item.InternalMessageID.HasValue) ? "0" : item.InternalMessageID.ToString(), out result5);
							string messageCount = result2 + "|" + result3 + "|" + result4 + "|" + result5 + "|0|" + result;
							list.Add(new CommonMessageViewModel
							{
								UserId = result.ToString(),
								MessageCount = messageCount
							});
						}
					}
				}
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveNotification(JsonConvert.SerializeObject(list));
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendNotificationsInternal");
		}
	}

	public static void StartSmsNotification()
	{
		lock (_smsnotificationLock)
		{
			if (!_smsDependencyStarted)
			{
				_smsDependencyStarted = true;
				SubscribeSmsDependency();
			}
		}
	}

	private static void SubscribeSmsDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [Id] FROM [dbo].[SmsReceive] WHERE ISNULL([IsRead],0) = 0", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C1_003E__SmsDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = SmsDependency_OnChange;
				_003C_003EO._003C1_003E__SmsDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_smsDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_smsDependencyStarted = false;
			Logs.LogError(ex, "SubscribeSmsDependency");
		}
	}

	private static void SmsDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_smsnotificationLock)
			{
				_smsDependency = null;
			}
			lock (_smsnotificationLock)
			{
				SubscribeSmsDependency();
			}
			SendNotificationsSms();
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SmsDependency_OnChange");
		}
	}

	[HubMethodName("sendSmsNotifications")]
	public void SendSmsNotifications()
	{
		SendNotificationsSms();
	}

	private static void SendNotificationsSms()
	{
		try
		{
			int num = 0;
			using (CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities())
			{
				num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIEntities.CRMspGetUnReadSmsReceiveCnt()).GetValueOrDefault();
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveSMSNotification(num);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendNotificationsSms");
		}
	}

	public static void StartTicketNotification()
	{
		lock (_ticketnotificationLock)
		{
			if (!_ticketDependencyStarted)
			{
				_ticketDependencyStarted = true;
				SubscribeTicketDependency();
			}
		}
	}

	private static void SubscribeTicketDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [ConversationID] FROM [dbo].[CrmConversation] WHERE ISNULL(cnvsIsTicket, 0) = 1 AND ISNULL(cnvsFOCmpCanSee, 0) = 1 AND FirstRegisterUserId < 0", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C2_003E__TicketDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = TicketDependency_OnChange;
				_003C_003EO._003C2_003E__TicketDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_ticketDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_ticketDependencyStarted = false;
			Logs.LogError(ex, "SubscribeTicketDependency");
		}
	}

	private static void TicketDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_ticketnotificationLock)
			{
				_ticketDependency = null;
			}
			lock (_ticketnotificationLock)
			{
				SubscribeTicketDependency();
			}
			SendNotificationsTicket();
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "TicketDependency_OnChange");
		}
	}

	[HubMethodName("sendTicketNotifications")]
	public void SendTicketNotifications()
	{
		SendNotificationsTicket();
	}

	private static void SendNotificationsTicket()
	{
		try
		{
			if (Users == null || !Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				return;
			}
			List<CommonWithIdStrViewModel> list = new List<CommonWithIdStrViewModel>();
			int result5;
			string text = string.Join(",", Enumerable.Distinct<int>(Enumerable.Where<int>(Enumerable.Select<string, int>((IEnumerable<string>)Users.Keys, (Func<string, int>)((string x) => int.TryParse(x, out result5) ? result5 : 0)), (Func<int, bool>)((int x) => x > 0))));
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			using (CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities())
			{
				List<CRMspGetUnReadTicketForUsers_Result> list2 = Enumerable.ToList<CRMspGetUnReadTicketForUsers_Result>((IEnumerable<CRMspGetUnReadTicketForUsers_Result>)cRMSpIIIEntities.CRMspGetUnReadTicketForUsers(text));
				if (list2 != null)
				{
					foreach (CRMspGetUnReadTicketForUsers_Result item in list2)
					{
						int result = 0;
						int.TryParse((!item.UserId.HasValue) ? "0" : item.UserId.ToString(), out result);
						if (result > 0)
						{
							int.TryParse(item.UserId.ToString(), out result);
							int result2 = 0;
							int.TryParse(item.InProgressCnt.ToString(), out result2);
							int result3 = 0;
							int.TryParse(item.NewCnt.ToString(), out result3);
							int result4 = 0;
							int.TryParse(item.AllCnt.ToString(), out result4);
							string text2 = "";
							text2 = result2 + "|";
							text2 = text2 + result3 + "|";
							text2 += result4;
							list.Add(new CommonWithIdStrViewModel
							{
								Id = result.ToString(),
								Extra = text2
							});
						}
					}
				}
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveTicketNotification(JsonConvert.SerializeObject(list));
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendNotificationsTicket");
		}
	}

	public static void StartSmsTankNotification()
	{
		lock (_smsTanknotificationLock)
		{
			if (!_smsTankDependencyStarted)
			{
				_smsTankDependencyStarted = true;
				SubscribeSmsTankDependency();
			}
		}
	}

	private static void SubscribeSmsTankDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [Id] FROM [dbo].[SmsSendDetail] WHERE ISNULL(StatusId,0) IN (-2000, -1) ", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C3_003E__SmsTankDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = SmsTankDependency_OnChange;
				_003C_003EO._003C3_003E__SmsTankDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_smsTankDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_smsTankDependencyStarted = false;
			Logs.LogError(ex, "SubscribeSmsTankDependency");
		}
	}

	private static void SmsTankDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_smsTanknotificationLock)
			{
				_smsTankDependency = null;
			}
			lock (_smsTanknotificationLock)
			{
				SubscribeSmsTankDependency();
			}
			SendNotificationsSmsTank();
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SmsTankDependency_OnChange");
		}
	}

	[HubMethodName("sendSmsTankNotifications")]
	public void SendSmsTankNotifications()
	{
		SendNotificationsSmsTank();
	}

	private static void SendNotificationsSmsTank()
	{
		int result = 0;
		try
		{
			using (CRMSpEntities cRMSpEntities = new CRMSpEntities())
			{
				int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.SmsspSelectSMSTankCount(DateTime.Now));
				if (num.HasValue)
				{
					int.TryParse(num.ToString(), out result);
				}
				else
				{
					result = 0;
				}
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveSMSTankNotification(result);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendNotificationsSmsTank");
		}
	}

	public static void StartTelegramNotification()
	{
		lock (_telegramnotificationLock)
		{
			if (!_telegramDependencyStarted)
			{
				_telegramDependencyStarted = true;
				SubscribeTelegramDependency();
			}
		}
	}

	private static void SubscribeTelegramDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [TelegBotChatMessageId] FROM [dbo].[CrmTelegBotChatMessage]", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C4_003E__TelegramDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = TelegramDependency_OnChange;
				_003C_003EO._003C4_003E__TelegramDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_telegramDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_telegramDependencyStarted = false;
			Logs.LogError(ex, "SubscribeTelegramDependency");
		}
	}

	private static void TelegramDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_telegramnotificationLock)
			{
				_telegramDependency = null;
			}
			lock (_telegramnotificationLock)
			{
				SubscribeTelegramDependency();
			}
			SendNotificationsTelegram();
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "TelegramDependency_OnChange");
		}
	}

	[HubMethodName("sendTelegramNotifications")]
	public void SendTelegramNotifications()
	{
		SendNotificationsTelegram();
	}

	private static void SendNotificationsTelegram()
	{
		int result = 0;
		try
		{
			using (CRMSpEntities cRMSpEntities = new CRMSpEntities())
			{
				int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.CRMspTelegBotGetUnReadChatMessage()).ToString(), out result);
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveTelegramNotification(result);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, " SendNotificationsTelegram");
		}
	}

	public static void SendTelegramSignal(string job = "", string p1 = "", string p2 = "")
	{
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
		hubContext.Clients.All.sendTelegramSignal(Info.Get().UserId, job, p1, p2);
	}

	public static void StartEmailTankNotification()
	{
		lock (_emailTanknotificationLock)
		{
			if (!_emailTankDependencyStarted)
			{
				_emailTankDependencyStarted = true;
				SubscribeEmailTankDependency();
			}
		}
	}

	private static void SubscribeEmailTankDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [EmailSendDetailId] FROM [dbo].[EmailSendDetail] WHERE ISNULL([StatusId],0) = 0 ", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C5_003E__EmailTankDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = EmailTankDependency_OnChange;
				_003C_003EO._003C5_003E__EmailTankDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_emailTankDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_emailTankDependencyStarted = false;
			Logs.LogError(ex, "SubscribeEmailTankDependency");
		}
	}

	private static void EmailTankDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_emailTanknotificationLock)
			{
				_emailTankDependency = null;
			}
			lock (_emailTanknotificationLock)
			{
				SubscribeEmailTankDependency();
			}
			if (Users == null || !Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				return;
			}
			foreach (KeyValuePair<string, UsersSignalR> user in Users)
			{
				int result = 0;
				int.TryParse(user.Key, out result);
				if (result > 0)
				{
					SendNotificationsEmailTank(result);
				}
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "EmailTankDependency_OnChange");
		}
	}

	[HubMethodName("sendEmailTankNotifications")]
	public void SendEmailTankNotifications(int usrId = 0)
	{
		int result = 0;
		try
		{
			if (base.Context != null && base.Context.Request != null)
			{
				IIdentity identity = base.Context.Request.GetHttpContext().User.Identity;
				if (identity != null)
				{
					int.TryParse(identity.Name, out result);
				}
			}
			if (result == 0 && Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				int.TryParse(Thread.CurrentPrincipal.Identity.Name, out result);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, " SendEmailTankNotifications");
		}
		SendNotificationsEmailTank(result);
	}

	private static void SendNotificationsEmailTank(int usrId = 0)
	{
		int num = 0;
		int result = 0;
		try
		{
			if (result == 0 && Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				int.TryParse(Thread.CurrentPrincipal.Identity.Name, out result);
			}
			if (result == 0)
			{
				result = usrId;
			}
			using (CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities())
			{
				if (result > 0)
				{
					num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIIEntities.EmailspSelectEmailTankCount(result, DateTime.Now)).GetValueOrDefault();
				}
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveEmailTankNotification(num, result);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendNotificationsEmailTank");
		}
	}

	public static void StartEmailNotification()
	{
		lock (_emailnotificationLock)
		{
			if (!_emailDependencyStarted)
			{
				_emailDependencyStarted = true;
				SubscribeEmailDependency();
			}
		}
	}

	private static void SubscribeEmailDependency()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(ConnectionString);
			SqlCommand val2 = new SqlCommand("SELECT [EmailReceiveId] FROM [dbo].[EmailReceive] WHERE ISNULL([IsRead],0) = 0", val)
			{
				Notification = null
			};
			SqlDependency val3 = new SqlDependency(val2);
			object obj = _003C_003EO._003C6_003E__EmailDependency_OnChange;
			if (obj == null)
			{
				OnChangeEventHandler val4 = EmailDependency_OnChange;
				_003C_003EO._003C6_003E__EmailDependency_OnChange = val4;
				obj = (object)val4;
			}
			val3.OnChange += (OnChangeEventHandler)obj;
			_emailDependency = val3;
			((DbConnection)val).Open();
			((DbCommand)val2).ExecuteScalar();
			((DbConnection)val).Close();
			((Component)val).Dispose();
			((Component)val2).Dispose();
		}
		catch (Exception ex)
		{
			_emailDependencyStarted = false;
			Logs.LogError(ex, "SubscribeEmailDependency");
		}
	}

	private static void EmailDependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		try
		{
			lock (_emailnotificationLock)
			{
				_emailDependency = null;
			}
			lock (_emailnotificationLock)
			{
				SubscribeEmailDependency();
			}
			if (Users == null || !Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				return;
			}
			foreach (KeyValuePair<string, UsersSignalR> user in Users)
			{
				int result = 0;
				int.TryParse(user.Key, out result);
				if (result > 0)
				{
					SendNotificationsEmail(result);
				}
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "EmailDependency_OnChange");
		}
	}

	[HubMethodName("sendEmailNotifications")]
	public void SendEmailNotifications(int usrId = 0)
	{
		int result = 0;
		try
		{
			if (base.Context != null && base.Context.Request != null)
			{
				IIdentity identity = base.Context.Request.GetHttpContext().User.Identity;
				if (identity != null)
				{
					int.TryParse(identity.Name, out result);
				}
			}
			if (result == 0 && Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				int.TryParse(Thread.CurrentPrincipal.Identity.Name, out result);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SendEmailNotifications");
		}
		SendNotificationsEmail(result);
	}

	private static void SendNotificationsEmail(int usrId = 0)
	{
		int num = 0;
		int result = 0;
		try
		{
			if (result == 0 && Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				int.TryParse(Thread.CurrentPrincipal.Identity.Name, out result);
			}
			if (result == 0)
			{
				result = usrId;
			}
			using (CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities())
			{
				if (result > 0)
				{
					num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIIEntities.EmailspGetUnReadEmailReceiveCount(result)).GetValueOrDefault();
				}
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.RecieveEmailNotification(num, result);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, " SendNotificationsEmail");
		}
	}

	[HubMethodName("sendMessageToUser")]
	public void SendMessageToUser(string fromUser, string message, string toUser, string fromUserName)
	{
		lock (_lockChat)
		{
			if (Enumerable.Any<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList) && Enumerable.FirstOrDefault<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList, (Func<ChatUserInfoViewModel, bool>)((ChatUserInfoViewModel m) => m.UserName == toUser)) != null)
			{
				IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
				string text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				text = Thread.CurrentThread.CurrentCulture.LCID switch
				{
					1065 => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", new PersianCulture()), 
					1025 => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA")), 
					_ => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US")), 
				};
				hubContext.Clients.All.getMessages(fromUser, message, toUser, text, fromUserName);
			}
		}
	}

	[HubMethodName("getUsersChatStatus")]
	public void GetUsersChatStatus()
	{
		lock (_lockChat)
		{
			string text = "";
			if (!Enumerable.Any<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList))
			{
				return;
			}
			foreach (ChatUserInfoViewModel users in UsersList)
			{
				text = text + users.UserName + "|";
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.getUsersChatStatus(text);
		}
	}

	[HubMethodName("getUserOnlineForIntMsgStatus")]
	public void GetUserOnlineForIntMsgStatus()
	{
		lock (_lockNotifWinForIntMsg)
		{
			string text = "";
			if (!Enumerable.Any<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList))
			{
				return;
			}
			foreach (UserOnlineViewModel userOnlineForIntMsg in UserOnlineForIntMsgList)
			{
				text = text + userOnlineForIntMsg.UserName + "|";
			}
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.getUserOnlineForIntMsgStatus(text);
		}
	}

	[HubMethodName("sendWinNotifyToUser")]
	public static void SendWinNotifyToUser(string fromUserId, string fromUserName, string toUserId, string message)
	{
		lock (_lockNotifWinForIntMsg)
		{
			if (!Enumerable.Any<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList) || string.IsNullOrWhiteSpace(toUserId))
			{
				return;
			}
			string[] array = toUserId.Split(new char[1] { ',' });
			if (array == null || !Enumerable.Any<string>((IEnumerable<string>)array))
			{
				return;
			}
			string[] array2 = array;
			foreach (string toUser in array2)
			{
				if (!string.IsNullOrWhiteSpace(toUser) && toUser != "0" && Enumerable.FirstOrDefault<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList, (Func<UserOnlineViewModel, bool>)((UserOnlineViewModel m) => m.UserName == toUser)) != null)
				{
					if (!string.IsNullOrWhiteSpace(message))
					{
						message = message.ToString();
					}
					IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
					hubContext.Clients.All.ReceiveWinNotifyToUser(fromUserId, fromUserName, toUser, message);
				}
			}
		}
	}

	public override Task OnConnected()
	{
		connect();
		return base.OnConnected();
	}

	private void connect()
	{
		string userName = base.Context.User.Identity.Name;
		string connectionId = base.Context.ConnectionId;
		UsersSignalR orAdd = Users.GetOrAdd(userName, (Func<string, UsersSignalR>)((string _) => new UsersSignalR
		{
			Id = userName,
			ConnectionIds = new HashSet<string>()
		}));
		lock (orAdd.ConnectionIds)
		{
			orAdd.ConnectionIds.Add(connectionId);
			if (Enumerable.Any<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList))
			{
				if (Enumerable.FirstOrDefault<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList, (Func<ChatUserInfoViewModel, bool>)((ChatUserInfoViewModel m) => m.UserName == userName)) == null)
				{
					UsersList.Add(new ChatUserInfoViewModel
					{
						ConnectionId = connectionId,
						UserName = userName,
						OnLine = true
					});
				}
			}
			else
			{
				UsersList.Add(new ChatUserInfoViewModel
				{
					ConnectionId = connectionId,
					UserName = userName,
					OnLine = true
				});
			}
			string text = "";
			if (Enumerable.Any<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList))
			{
				foreach (ChatUserInfoViewModel users in UsersList)
				{
					text = text + users.UserName + "|";
				}
			}
			if (Enumerable.Any<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList))
			{
				if (Enumerable.FirstOrDefault<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList, (Func<UserOnlineViewModel, bool>)((UserOnlineViewModel m) => m.UserName == userName)) == null)
				{
					UserOnlineForIntMsgList.Add(new UserOnlineViewModel
					{
						ConnectionId = connectionId,
						UserName = userName,
						OnLine = true
					});
				}
			}
			else
			{
				UserOnlineForIntMsgList.Add(new UserOnlineViewModel
				{
					ConnectionId = connectionId,
					UserName = userName,
					OnLine = true
				});
			}
			base.Clients.Caller.onConnected(connectionId, userName, text);
		}
	}

	public override Task OnDisconnected(bool stopCalled)
	{
		string name = base.Context.User.Identity.Name;
		string connectionId = base.Context.ConnectionId;
		UsersSignalR user = GetUser(name);
		if (user != null)
		{
			lock (user.ConnectionIds)
			{
				user.ConnectionIds.RemoveWhere((Predicate<string>)((string cid) => cid.Equals(connectionId)));
				if (!Enumerable.Any<string>((IEnumerable<string>)user.ConnectionIds))
				{
					UsersSignalR usersSignalR = default(UsersSignalR);
					Users.TryRemove(name, ref usersSignalR);
					ChatUserInfoViewModel chatUserInfoViewModel = Enumerable.FirstOrDefault<ChatUserInfoViewModel>((IEnumerable<ChatUserInfoViewModel>)UsersList, (Func<ChatUserInfoViewModel, bool>)((ChatUserInfoViewModel x) => x.ConnectionId == base.Context.ConnectionId));
					if (chatUserInfoViewModel != null)
					{
						UsersList.Remove(chatUserInfoViewModel);
						_ = base.Context.ConnectionId;
					}
					GetUsersChatStatus();
					UserOnlineViewModel userOnlineViewModel = Enumerable.FirstOrDefault<UserOnlineViewModel>((IEnumerable<UserOnlineViewModel>)UserOnlineForIntMsgList, (Func<UserOnlineViewModel, bool>)((UserOnlineViewModel x) => x.ConnectionId == base.Context.ConnectionId));
					if (userOnlineViewModel != null)
					{
						UserOnlineForIntMsgList.Remove(userOnlineViewModel);
						_ = base.Context.ConnectionId;
					}
					GetUserOnlineForIntMsgStatus();
				}
			}
		}
		return base.OnDisconnected(stopCalled);
	}

	public override Task OnReconnected()
	{
		connect();
		return base.OnReconnected();
	}

	private UsersSignalR GetUser(string userId)
	{
		UsersSignalR result = default(UsersSignalR);
		Users.TryGetValue(userId, ref result);
		return result;
	}

	public IEnumerable<string> GetConnectedUser()
	{
		return Enumerable.Select<KeyValuePair<string, UsersSignalR>, string>(Enumerable.Where<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users, (Func<KeyValuePair<string, UsersSignalR>, bool>)delegate(KeyValuePair<string, UsersSignalR> x)
		{
			lock (x.Value.ConnectionIds)
			{
				return !Enumerable.Contains<string>((IEnumerable<string>)x.Value.ConnectionIds, base.Context.ConnectionId, (IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase);
			}
		}), (Func<KeyValuePair<string, UsersSignalR>, string>)((KeyValuePair<string, UsersSignalR> x) => x.Key));
	}

	public static void SendData(string keyName = "", string data = "")
	{
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
		hubContext.Clients.All.sendData(keyName, data);
	}
}
