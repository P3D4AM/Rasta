using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;

namespace CRMIdeal.Areas.Emails.Controllers;

public class ProcessController : Controller
{
	public static class EmailProgressStore
	{
		public static ConcurrentDictionary<string, EmailProgressModel> ActiveProcesses = new ConcurrentDictionary<string, EmailProgressModel>();
	}

	public class EmailBackgroundService
	{
		private static readonly object _lock = new object();

		public string StartEmailProcess(string userId, string type, int totalEmails, int currLangId, int curruserId, List<EmailspSelectActiveEmailUsersInfoByUserId_Result> emailAccounts)
		{
			string userKey = userId + "_" + type;
			EmailProgressModel emailProgressModel = Enumerable.FirstOrDefault<EmailProgressModel>((IEnumerable<EmailProgressModel>)EmailProgressStore.ActiveProcesses.Values, (Func<EmailProgressModel, bool>)((EmailProgressModel p) => p.UserKey == userKey && (p.Status == "Running" || p.Status == "Starting")));
			if (emailProgressModel != null)
			{
				return emailProgressModel.ProcessId;
			}
			string processId = type + "_" + userId;
			CancellationTokenSource cancellationToken2 = new CancellationTokenSource();
			int num = totalEmails;
			if (emailAccounts != null && Enumerable.Any<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)emailAccounts))
			{
				num += emailAccounts.Count;
			}
			EmailProgressModel progress = new EmailProgressModel
			{
				ProcessId = processId,
				UserKey = userKey,
				UserId = userId,
				Type = type,
				Total = num,
				Current = 0,
				Status = "Starting",
				StartTime = DateTime.Now,
				LastUpdate = DateTime.Now,
				CancellationToken = cancellationToken2
			};
			EmailProgressStore.ActiveProcesses.TryAdd(userKey, progress);
			HostingEnvironment.QueueBackgroundWorkItem((Func<CancellationToken, Task>)delegate
			{
				ProcessEmails(userId, type, processId, totalEmails, progress.CancellationToken.Token, currLangId, curruserId, emailAccounts);
				return Task.CompletedTask;
			});
			Task.Delay(100).ContinueWith(delegate
			{
				EmailProgressModel emailProgressModel2 = default(EmailProgressModel);
				if (EmailProgressStore.ActiveProcesses.TryGetValue(userKey, ref emailProgressModel2))
				{
					emailProgressModel2.Status = "Running";
				}
			});
			return processId;
		}

		private async Task ProcessEmails(string userId, string type, string processId, int total, CancellationToken token, int currLangId, int curruserId, List<EmailspSelectActiveEmailUsersInfoByUserId_Result> emailAccounts)
		{
			string userKey = userId + "_" + type;
			int sumTotal = total;
			int currStep = 0;
			if (emailAccounts != null && Enumerable.Any<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)emailAccounts))
			{
				sumTotal += emailAccounts.Count;
			}
			CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();
			try
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				EmailspSelectEmailSetting_Result _EmailSetting = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)cRMSpEntities.EmailspSelectEmailSetting("", ""));
				int delay = 0;
				if (_EmailSetting != null)
				{
					int.TryParse(_EmailSetting.EmailBulkingDelayTime.ToString(), out delay);
					if (delay < 3)
					{
						delay = 3;
					}
					delay *= 1000;
				}
				for (int i = 1; i <= total; i++)
				{
					currStep = i;
					if (token.IsCancellationRequested)
					{
						UpdateProgress(userKey, i - 1, sumTotal, "Stopped", currLangId);
						return;
					}
					try
					{
						Task.Run(delegate
						{
							if (_EmailSetting != null)
							{
								int.TryParse(_EmailSetting.EmailBulkingDelayTime.ToString(), out delay);
								if (delay < 3)
								{
									delay = 3;
								}
								delay *= 1000;
								bool result = false;
								bool.TryParse(_EmailSetting.EmailBulkingIsActive.ToString(), out result);
								if (result)
								{
									DateTime now = DateTime.Now;
									string text = ((!string.IsNullOrWhiteSpace(_EmailSetting.EmailBulkingDailyStarTime)) ? _EmailSetting.EmailBulkingDailyStarTime : "00:00:00");
									string text2 = ((!string.IsNullOrWhiteSpace(_EmailSetting.EmailBulkingDailyEndTime)) ? _EmailSetting.EmailBulkingDailyEndTime : "23:59:59");
									DateTime startTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text);
									DateTime endTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text2);
									SendTankController sendTankController = new SendTankController();
									if (sendTankController.IsBetween(now, startTime, endTime))
									{
										CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
										EmailspSelectEmailReadySendByUserId_Result emailspSelectEmailReadySendByUserId_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReadySendByUserId_Result>((IEnumerable<EmailspSelectEmailReadySendByUserId_Result>)cRMSpIIIEntities.EmailspSelectEmailReadySendByUserId(sendDateTime: DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59"), userId: curruserId));
										if (emailspSelectEmailReadySendByUserId_Result != null)
										{
											EmailspSelectEmailReadySend_Result emailInfo = new EmailspSelectEmailReadySend_Result
											{
												UserId = emailspSelectEmailReadySendByUserId_Result.UserId,
												Header_Id = emailspSelectEmailReadySendByUserId_Result.Header_Id,
												Header_Subject = emailspSelectEmailReadySendByUserId_Result.Header_Subject,
												Header_Body = emailspSelectEmailReadySendByUserId_Result.Header_Body,
												Header_PriorityId = emailspSelectEmailReadySendByUserId_Result.Header_PriorityId,
												Setting_Id = emailspSelectEmailReadySendByUserId_Result.Setting_Id,
												UsersInfo_Id = emailspSelectEmailReadySendByUserId_Result.UsersInfo_Id,
												UsersInfo_euUserId = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euUserId,
												UsersInfo_euNikeName = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euNikeName,
												UsersInfo_euNikeEmail = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euNikeEmail,
												UsersInfo_euPOP3Server = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euPOP3Server,
												UsersInfo_euSMTPServer = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euSMTPServer,
												UsersInfo_euUserName = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euUserName,
												UsersInfo_euPassword = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euPassword,
												UsersInfo_euIsActive = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euIsActive,
												Detail_Id = emailspSelectEmailReadySendByUserId_Result.Detail_Id,
												Detail_EmailAddress = emailspSelectEmailReadySendByUserId_Result.Detail_EmailAddress,
												Detail_EmailCmpId = emailspSelectEmailReadySendByUserId_Result.Detail_EmailCmpId,
												Detail_EmailCmpPrsId = emailspSelectEmailReadySendByUserId_Result.Detail_EmailCmpPrsId,
												Detail_EmailCmpPrjId = emailspSelectEmailReadySendByUserId_Result.Detail_EmailCmpPrjId,
												Detail_EmailCmpName = emailspSelectEmailReadySendByUserId_Result.Detail_EmailCmpName,
												Detail_EmailCmpPrsName = emailspSelectEmailReadySendByUserId_Result.Detail_EmailCmpPrsName,
												Detail_EmailPrsJob = emailspSelectEmailReadySendByUserId_Result.Detail_EmailPrsJob,
												Detail_StatusId = emailspSelectEmailReadySendByUserId_Result.Detail_StatusId,
												Detail_AppType = emailspSelectEmailReadySendByUserId_Result.Detail_AppType,
												Detail_TryCount = emailspSelectEmailReadySendByUserId_Result.Detail_TryCount,
												UsersInfo_euSMTPUseDefCredentials = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euSMTPUseDefCredentials,
												UsersInfo_euSMTPUseSsl = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euSMTPUseSsl,
												UsersInfo_euSMTPPort = emailspSelectEmailReadySendByUserId_Result.UsersInfo_euSMTPPort
											};
											CultureInfo cultureInfo = new CultureInfo(currLangId);
											Thread.CurrentThread.CurrentUICulture = cultureInfo;
											Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
											Thread.CurrentThread.CurrentCulture = cultureInfo;
											sendTankController.SendSingleEmailSync(emailInfo);
										}
										cRMSpIIIEntities.Dispose();
									}
								}
							}
						}).Wait(token);
						UpdateProgress(userKey, i, sumTotal, "Running", currLangId);
						Thread.Sleep(delay);
					}
					catch (OperationCanceledException)
					{
						UpdateProgress(userKey, i - 1, sumTotal, "Stopped", currLangId);
						return;
					}
					catch (Exception ex2)
					{
						UpdateProgress(userKey, i, sumTotal, "Error: " + ex2.Message, currLangId);
						return;
					}
				}
				cRMSpEntities.Dispose();
				int counter = total;
				if (emailAccounts != null && Enumerable.Any<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)emailAccounts))
				{
					for (int accountIndex = 0; accountIndex < emailAccounts.Count; accountIndex++)
					{
						counter++;
						if (token.IsCancellationRequested)
						{
							UpdateProgress(userKey, counter - 1, sumTotal, "Stopped", currLangId);
							return;
						}
						try
						{
							EmailspSelectActiveEmailUsersInfoByUserId_Result account = emailAccounts[accountIndex];
							_ = account?.euUserName;
							await Task.Delay(500, token);
							if (await GetEmailCountFromServer(account, token, currLangId) > 0)
							{
								await DownloadSingleEmailFromServer(account, 0, token, currLangId);
							}
							UpdateProgress(userKey, counter, sumTotal, "Running", currLangId);
							Thread.Sleep(50);
						}
						catch (OperationCanceledException)
						{
							UpdateProgress(userKey, counter - 1, sumTotal, "Stopped", currLangId);
							return;
						}
						catch (Exception ex4)
						{
							UpdateProgress(userKey, counter, sumTotal, "Error: " + ex4.Message, currLangId);
							return;
						}
						currStep++;
					}
					_dbIII.CRMspUpdateUserLastCheckEmailDate(curruserId, DateTime.Now);
				}
				if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.EmailspSelectEmailTankCount(curruserId, DateTime.Now)).GetValueOrDefault() == 0 && currStep == sumTotal)
				{
					UpdateProgress(userKey, sumTotal, sumTotal, "Completed", currLangId);
					return;
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				_dbIII?.Dispose();
			}
			await Task.Delay(60000).ContinueWith(delegate
			{
				EmailProgressModel emailProgressModel = default(EmailProgressModel);
				if (EmailProgressStore.ActiveProcesses.TryGetValue(userKey, ref emailProgressModel))
				{
					emailProgressModel.Status = "Running";
				}
			});
		}

		private void UpdateProgress(string userKey, int current, int total, string status, int currLangId)
		{
			EmailProgressModel emailProgressModel = default(EmailProgressModel);
			if (EmailProgressStore.ActiveProcesses.TryGetValue(userKey, ref emailProgressModel))
			{
				emailProgressModel.Current = current;
				emailProgressModel.Status = status;
				emailProgressModel.Total = total;
				emailProgressModel.LastUpdate = DateTime.Now;
			}
		}

		public void StopProcess(string userId, string type, int currLangId)
		{
			string text = userId + "_" + type;
			EmailProgressModel emailProgressModel = default(EmailProgressModel);
			if (EmailProgressStore.ActiveProcesses.TryGetValue(text, ref emailProgressModel))
			{
				emailProgressModel.CancellationToken?.Cancel();
				emailProgressModel.Status = "Stopping";
			}
		}

		public EmailProgressModel GetProgress(string userId, string type, int currLangId)
		{
			string text = userId + "_" + type;
			EmailProgressModel emailProgressModel = default(EmailProgressModel);
			EmailProgressStore.ActiveProcesses.TryGetValue(text, ref emailProgressModel);
			if (emailProgressModel != null && emailProgressModel.Percentage == 100)
			{
				emailProgressModel.Status = "Completed";
			}
			return emailProgressModel;
		}

		public List<EmailProgressModel> GetAllActiveProcesses(string userId, int currLangId)
		{
			return Enumerable.ToList<EmailProgressModel>(Enumerable.Where<EmailProgressModel>((IEnumerable<EmailProgressModel>)EmailProgressStore.ActiveProcesses.Values, (Func<EmailProgressModel, bool>)((EmailProgressModel p) => p.UserId == userId)));
		}

		private async Task<long> GetEmailCountFromServer(EmailspSelectActiveEmailUsersInfoByUserId_Result account, CancellationToken token, int currLangId)
		{
			long result = 0L;
			if (account != null)
			{
				ReceiveEmailController receiveEmailController = new ReceiveEmailController();
				int emailUsersInfoId = account.EmailUsersInfoId;
				CultureInfo cultureInfo = new CultureInfo(currLangId);
				Thread.CurrentThread.CurrentUICulture = cultureInfo;
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
				Thread.CurrentThread.CurrentCulture = cultureInfo;
				DateTime now = DateTime.Now;
				string toDate = now.ToString("yyyyMMdd");
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				int euUserId = account.euUserId;
				string fromDate = "";
				CRMspSelectUsersById_Result cRMspSelectUsersById_Result = Enumerable.FirstOrDefault<CRMspSelectUsersById_Result>((IEnumerable<CRMspSelectUsersById_Result>)cRMSpEntities.CRMspSelectUsersById(euUserId, currLangId, currLangId, 0));
				if (cRMspSelectUsersById_Result != null)
				{
					DateTime valueOrDefault = cRMspSelectUsersById_Result.LastCheckEmailDate.GetValueOrDefault(now);
					if (cRMspSelectUsersById_Result.LastCheckEmailDate.HasValue)
					{
						fromDate = valueOrDefault.ToString("yyyyMMdd");
					}
				}
				result = receiveEmailController.GetReceiveEmailCount(emailUsersInfoId, fromDate, toDate);
				cRMSpEntities.Dispose();
			}
			return result;
		}

		private async Task DownloadSingleEmailFromServer(EmailspSelectActiveEmailUsersInfoByUserId_Result account, int index, CancellationToken token, int currLangId)
		{
			if (account != null)
			{
				CultureInfo cultureInfo = new CultureInfo(currLangId);
				Thread.CurrentThread.CurrentUICulture = cultureInfo;
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
				Thread.CurrentThread.CurrentCulture = cultureInfo;
				new ReceiveEmailController().ReceiveSingleEmailSync(account.EmailUsersInfoId, account.euUserId, currLangId);
			}
		}
	}

	public class EmailProgressModel
	{
		public string ProcessId { get; set; }

		public string UserKey { get; set; }

		public string UserId { get; set; }

		public string Type { get; set; }

		public int Current { get; set; }

		public int Total { get; set; }

		public int Percentage
		{
			get
			{
				if (Total <= 0)
				{
					return 0;
				}
				return Current * 100 / Total;
			}
		}

		public string Status { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime LastUpdate { get; set; }

		public CancellationTokenSource CancellationToken { get; set; }

		public Task RunningTask { get; set; }
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly EmailBackgroundService _service = new EmailBackgroundService();

	[HttpPost]
	public JsonResult Start(string type, int total)
	{
		try
		{
			int result = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string currentUserId = GetCurrentUserId();
			int num = 0;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				num = currentUser.UserId;
			}
			if (string.IsNullOrEmpty(type))
			{
				return Json(new
				{
					success = false,
					message = "Type is required"
				});
			}
			List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(num));
			if (list == null)
			{
				list = new List<EmailspSelectActiveEmailUsersInfoByUserId_Result>();
			}
			string processId = _service.StartEmailProcess(currentUserId, type, total, lCID, num, list);
			return Json(new
			{
				success = true,
				processId = processId
			});
		}
		catch (Exception ex)
		{
			return Json(new
			{
				success = false,
				message = ex.Message
			});
		}
	}

	[HttpPost]
	public JsonResult Stop(string type)
	{
		try
		{
			int result = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string currentUserId = GetCurrentUserId();
			_service.StopProcess(currentUserId, type, lCID);
			return Json(new
			{
				success = true
			});
		}
		catch (Exception ex)
		{
			return Json(new
			{
				success = false,
				message = ex.Message
			});
		}
	}

	[HttpGet]
	public JsonResult GetProgress(string type)
	{
		try
		{
			int result = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string currentUserId = GetCurrentUserId();
			EmailProgressModel progress = _service.GetProgress(currentUserId, type, lCID);
			if (progress == null)
			{
				return Json(new
				{
					success = false,
					message = Messages.ResourceManager.GetString("msgErrorProcessNotFound", new CultureInfo(lCID))
				}, JsonRequestBehavior.AllowGet);
			}
			return Json(new
			{
				success = true,
				processId = progress.ProcessId,
				type = progress.Type,
				current = progress.Current,
				total = progress.Total,
				percentage = progress.Percentage,
				status = progress.Status
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			return Json(new
			{
				success = false,
				message = ex.Message
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpGet]
	public JsonResult GetAllActive()
	{
		try
		{
			int result = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string currentUserId = GetCurrentUserId();
			List<EmailProgressModel> allActiveProcesses = _service.GetAllActiveProcesses(currentUserId, lCID);
			return Json(new
			{
				success = true,
				processes = allActiveProcesses
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			return Json(new
			{
				success = false,
				message = ex.Message
			}, JsonRequestBehavior.AllowGet);
		}
	}

	private string GetCurrentUserId()
	{
		string text = "";
		if (UserLogin.CurrentUser != null && UserLogin.CurrentUser.UserId > 0)
		{
			text = UserLogin.CurrentUser.UserId.ToString();
		}
		if (string.IsNullOrWhiteSpace(text) && Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
		{
			text = Thread.CurrentPrincipal.Identity.Name ?? "";
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "anon_" + Guid.NewGuid();
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
