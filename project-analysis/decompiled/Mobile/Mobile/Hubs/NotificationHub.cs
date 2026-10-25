using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Hubs;

[HubName("notificationHub")]
public class NotificationHub : Hub
{
	private static readonly object _lock = new object();

	private static readonly object _lockForBaseInfo = new object();

	private static readonly object _lockForUserTask = new object();

	private static readonly ConcurrentDictionary<string, UsersSignalR> Users = new ConcurrentDictionary<string, UsersSignalR>();

	[HubMethodName("sendNotifications")]
	public void SendNotifications()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		List<CommonMessageViewModel> list = new List<CommonMessageViewModel>();
		lock (_lock)
		{
			if (Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					((CodeAccessPermission)new SqlClientPermission(PermissionState.Unrestricted)).Demand();
					SqlConnection val = new SqlConnection(cRMEntities.Database.Connection.ConnectionString);
					try
					{
						((DbConnection)val).Open();
						SqlCommand val2 = new SqlCommand("SELECT [LastChangeTime] FROM [dbo].[CrmsysManageInternalMessageChanges]", val);
						try
						{
							val2.Notification = null;
							new SqlDependency(val2).OnChange += new OnChangeEventHandler(dependency_OnChange);
							if ((int)((DbConnection)val).State == 0)
							{
								((DbConnection)val).Open();
							}
							((DbCommand)val2).ExecuteScalar();
							((DbConnection)val).Close();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
					foreach (KeyValuePair<string, UsersSignalR> user in Users)
					{
						int result = 0;
						int.TryParse(user.Key, out result);
						if (result > 0)
						{
							int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.CRMspIntMsgGetUnReadMessge(result, null)));
							CRMspIntMsgGetUnReadVerify_Result cRMspIntMsgGetUnReadVerify_Result = Enumerable.FirstOrDefault<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)Enumerable.ToList<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)cRMEntities.CRMspIntMsgGetUnReadVerify(result, null)));
							string text = "0";
							int num2 = 0;
							if (num.HasValue)
							{
								int result2 = 0;
								int.TryParse(num.ToString(), out result2);
								num2 += result2;
							}
							else
							{
								num2 = num2;
							}
							if (cRMspIntMsgGetUnReadVerify_Result != null && cRMspIntMsgGetUnReadVerify_Result.Cnt.HasValue)
							{
								int result3 = 0;
								int.TryParse(cRMspIntMsgGetUnReadVerify_Result.Cnt.ToString(), out result3);
								num2 += result3;
							}
							else
							{
								num2 = num2;
							}
							text = num2.ToString();
							list.Add(new CommonMessageViewModel
							{
								UserId = result.ToString(),
								MessageCount = text
							});
						}
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
		}
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
		hubContext.Clients.All.RecieveNotification(JsonConvert.SerializeObject(list));
	}

	private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		lock (_lock)
		{
			if ((int)e.Type == 0 && ((int)e.Info == 1 || (int)e.Info == 2 || (int)e.Info == 3))
			{
				new NotificationHub().SendNotifications();
			}
		}
	}

	[HubMethodName("isAlarmUpdated")]
	public void IsAlarmUpdated()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		List<ReminderNotificationViewModel> list = new List<ReminderNotificationViewModel>();
		lock (_lockForUserTask)
		{
			if (Enumerable.Any<KeyValuePair<string, UsersSignalR>>((IEnumerable<KeyValuePair<string, UsersSignalR>>)Users))
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					((CodeAccessPermission)new SqlClientPermission(PermissionState.Unrestricted)).Demand();
					SqlConnection val = new SqlConnection(cRMEntities.Database.Connection.ConnectionString);
					try
					{
						((DbConnection)val).Open();
						SqlCommand val2 = new SqlCommand("SELECT [LastChangeTime] FROM [dbo].[CrmsysManageAlarmChanges]", val);
						try
						{
							val2.Notification = null;
							new SqlDependency(val2).OnChange += new OnChangeEventHandler(IsAlarmUpdated_Dependency_OnChange);
							if ((int)((DbConnection)val).State == 0)
							{
								((DbConnection)val).Open();
							}
							((DbCommand)val2).ExecuteScalar();
							((DbConnection)val).Close();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
					foreach (KeyValuePair<string, UsersSignalR> user in Users)
					{
						int result = 0;
						int.TryParse(user.Key, out result);
						if (result > 0)
						{
							list.Add(new ReminderNotificationViewModel
							{
								UserId = result,
								IsUpdate = true
							});
						}
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
		}
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
		hubContext.Clients.All.RecieveIsAlarmUpdated(JsonConvert.SerializeObject(list));
	}

	private void IsAlarmUpdated_Dependency_OnChange(object sender, SqlNotificationEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		lock (_lockForUserTask)
		{
			if ((int)e.Type == 0 && ((int)e.Info == 1 || (int)e.Info == 2 || (int)e.Info == 3))
			{
				new NotificationHub().IsAlarmUpdated();
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
		string userName = base.Context.QueryString["username"] ?? null;
		if (base.Context.Headers.GetValues("username") != null)
		{
			userName = ((base.Context.Headers.GetValues("username") != null) ? Enumerable.FirstOrDefault<string>(base.Context.Headers.GetValues("username")) : null);
		}
		string connectionId = base.Context.ConnectionId;
		UsersSignalR orAdd = Users.GetOrAdd(userName, (Func<string, UsersSignalR>)((string _) => new UsersSignalR
		{
			Id = userName,
			ConnectionIds = new HashSet<string>()
		}));
		lock (orAdd.ConnectionIds)
		{
			if (Enumerable.FirstOrDefault<string>((IEnumerable<string>)orAdd.ConnectionIds, (Func<string, bool>)((string id) => id == connectionId)) == null)
			{
				orAdd.ConnectionIds.Add(connectionId);
			}
		}
	}

	public override Task OnDisconnected(bool stopCalled)
	{
		string text = base.Context.QueryString["username"] ?? null;
		if (base.Context.Headers.GetValues("username") != null)
		{
			text = ((base.Context.Headers.GetValues("username") != null) ? Enumerable.FirstOrDefault<string>(base.Context.Headers.GetValues("username")) : null);
		}
		string connectionId = base.Context.ConnectionId;
		UsersSignalR user = GetUser(text);
		if (user != null)
		{
			lock (user.ConnectionIds)
			{
				user.ConnectionIds.RemoveWhere((Predicate<string>)((string cid) => cid.Equals(connectionId)));
				if (!Enumerable.Any<string>((IEnumerable<string>)user.ConnectionIds))
				{
					UsersSignalR usersSignalR = default(UsersSignalR);
					Users.TryRemove(text, ref usersSignalR);
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
}
