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
using Mobile.Models.ViewModel.Common;
using Newtonsoft.Json;

namespace Mobile.Hubs;

[HubName("notificationHub1")]
public class MsgHub : Hub
{
	private static readonly object _lock = new object();

	private static readonly object _lockForBaseInfo = new object();

	private static readonly object _lockForUserTask = new object();

	private static readonly ConcurrentDictionary<string, UserCompanySignalR> Company = new ConcurrentDictionary<string, UserCompanySignalR>();

	public override Task OnConnected()
	{
		connect();
		return base.OnConnected();
	}

	private void connect()
	{
		string companyId = base.Context.QueryString["companyId"] ?? null;
		if (base.Context.Headers.GetValues("companyId") != null)
		{
			companyId = ((base.Context.Headers.GetValues("companyId") != null) ? Enumerable.FirstOrDefault<string>(base.Context.Headers.GetValues("companyId")) : null);
		}
		string userId = base.Context.QueryString["userId"] ?? null;
		if (base.Context.Headers.GetValues("userId") != null)
		{
			userId = ((base.Context.Headers.GetValues("userId") != null) ? Enumerable.FirstOrDefault<string>(base.Context.Headers.GetValues("userId")) : null);
		}
		string connectionId = base.Context.ConnectionId;
		UserCompanySignalR orAdd = Company.GetOrAdd(companyId, (Func<string, UserCompanySignalR>)((string _) => new UserCompanySignalR
		{
			UserId = userId,
			CompanyId = companyId,
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
		string text = base.Context.QueryString["companyId"] ?? null;
		if (base.Context.Headers.GetValues("companyId") != null)
		{
			text = ((base.Context.Headers.GetValues("companyId") != null) ? Enumerable.FirstOrDefault<string>(base.Context.Headers.GetValues("companyId")) : null);
		}
		string connectionId = base.Context.ConnectionId;
		UserCompanySignalR company = GetCompany(text);
		if (company != null)
		{
			lock (company.ConnectionIds)
			{
				company.ConnectionIds.RemoveWhere((Predicate<string>)((string cid) => cid.Equals(connectionId)));
				if (!Enumerable.Any<string>((IEnumerable<string>)company.ConnectionIds))
				{
					UserCompanySignalR userCompanySignalR = default(UserCompanySignalR);
					Company.TryRemove(text, ref userCompanySignalR);
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

	private UserCompanySignalR GetCompany(string companyId)
	{
		UserCompanySignalR result = default(UserCompanySignalR);
		Company.TryGetValue(companyId, ref result);
		return result;
	}

	public IEnumerable<string> GetConnectedUser()
	{
		return Enumerable.Select<KeyValuePair<string, UserCompanySignalR>, string>(Enumerable.Where<KeyValuePair<string, UserCompanySignalR>>((IEnumerable<KeyValuePair<string, UserCompanySignalR>>)Company, (Func<KeyValuePair<string, UserCompanySignalR>, bool>)delegate(KeyValuePair<string, UserCompanySignalR> x)
		{
			lock (x.Value.ConnectionIds)
			{
				return !Enumerable.Contains<string>((IEnumerable<string>)x.Value.ConnectionIds, base.Context.ConnectionId, (IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase);
			}
		}), (Func<KeyValuePair<string, UserCompanySignalR>, string>)((KeyValuePair<string, UserCompanySignalR> x) => x.Key));
	}

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
		List<CommonCmpMessageViewModel> list = new List<CommonCmpMessageViewModel>();
		lock (_lock)
		{
			if (Enumerable.Any<KeyValuePair<string, UserCompanySignalR>>((IEnumerable<KeyValuePair<string, UserCompanySignalR>>)Company))
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
					foreach (KeyValuePair<string, UserCompanySignalR> item in Company)
					{
						int result = 0;
						int.TryParse(item.Key, out result);
						if (result > 0)
						{
							MobspSelectMobSetting_Result mobspSelectMobSetting_Result = Enumerable.FirstOrDefault<MobspSelectMobSetting_Result>((IEnumerable<MobspSelectMobSetting_Result>)cRMEntities.MobspSelectMobSetting());
							int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.MobspIntMsgGetCmpVerifyMessageCnt(mobspSelectMobSetting_Result.DefUserId, result)));
							int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.MobspIntMsgGetCmpReferMessageCnt(mobspSelectMobSetting_Result.DefUserId, result)));
							string text = "0";
							int num3 = 0;
							if (num.HasValue)
							{
								int result2 = 0;
								int.TryParse(num.ToString(), out result2);
								num3 += result2;
							}
							else
							{
								num3 = num3;
							}
							if (num2.HasValue && num2.HasValue)
							{
								int result3 = 0;
								int.TryParse(num2.ToString(), out result3);
								num3 += result3;
							}
							else
							{
								num3 = num3;
							}
							text = num3.ToString();
							list.Add(new CommonCmpMessageViewModel
							{
								CompanyId = result.ToString(),
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
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MsgHub>();
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
				new MsgHub().SendNotifications();
			}
		}
	}
}
