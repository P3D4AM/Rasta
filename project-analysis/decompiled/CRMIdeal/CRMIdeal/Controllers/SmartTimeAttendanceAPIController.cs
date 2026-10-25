using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CRMIdeal.Controllers;

public class SmartTimeAttendanceAPIController : ApiController
{
	public enum QRCodeServiceResultStatus
	{
		Success = 1,
		Fail,
		Error
	}

	public class QRCodeServiceResult<T>
	{
		public T Data;

		[JsonConverter(typeof(StringEnumConverter))]
		public QRCodeServiceResultStatus Status;

		public string Message;

		public QRCodeServiceResult()
		{
			Status = QRCodeServiceResultStatus.Success;
		}

		public QRCodeServiceResult(QRCodeServiceResultStatus type)
		{
			Status = type;
		}
	}

	[HttpPost]
	public QRCodeServiceResult<QRCodeResult> GetQRCode(string qrCode, double usLat = 0.0, double usLng = 0.0, int langId = 0, int mode = 0)
	{
		QRCodeResult qRCodeResult = new QRCodeResult();
		string text = "";
		QRCodeServiceResultStatus qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
		try
		{
			qRCodeResult.data = false;
			qRCodeResult.changeMode = false;
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int culture = ((langId > 0) ? langId : result);
			new BaseInfo().SetCulture(culture);
			string token = "";
			if (base.Request.Headers.Contains("token"))
			{
				token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			int num = CheckToken(token);
			if (num != 0)
			{
				if (!string.IsNullOrWhiteSpace(qrCode))
				{
					if (num == num)
					{
						LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(num);
						if (loginUserSmartTimeAttendanceViewModel != null)
						{
							DateTime smartTimeAttendanceFirstRegisterDate = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceFirstRegisterDate;
							DateTime now = DateTime.Now;
							if (smartTimeAttendanceFirstRegisterDate.AddSeconds(180.0) >= now)
							{
								if (string.IsNullOrWhiteSpace(loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceQRCode ?? ""))
								{
									string text2 = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "";
									if (!string.IsNullOrWhiteSpace(text2))
									{
										qrCode = CRMIdeal.Classes.Helper.User.DecodeQRBarcode(qrCode);
										text2 = text2.Split(new string[1] { "|**|" }, StringSplitOptions.None)[0];
										string sDomain = "";
										if (qrCode.Contains("|**|"))
										{
											sDomain = qrCode.Split(new string[1] { "|**|" }, StringSplitOptions.None)[1];
											qrCode = qrCode.Split(new string[1] { "|**|" }, StringSplitOptions.None)[0];
										}
										if (text2 == qrCode)
										{
											if (base.Request.Headers.TryGetValues("imeiCode", out var _) && base.Request.Headers.TryGetValues("appName", out var _) && !CRMIdeal.Classes.Helper.User.CheckUserImeiCode(num, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
											{
												return new QRCodeServiceResult<QRCodeResult>
												{
													Message = Messages.MobMsgUserImeiNotPreDefined,
													Data = qRCodeResult,
													Status = QRCodeServiceResultStatus.Fail
												};
											}
											bool flag = true;
											double result2 = 0.0;
											bool flag2 = false;
											bool flag3 = false;
											CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
											if (cRMspSelectCrmsysSetting_Result != null && mode == 0)
											{
												flag2 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQR.GetValueOrDefault();
												flag3 = cRMspSelectCrmsysSetting_Result.CheckLocForScanQRInMission.GetValueOrDefault();
												if (flag2 || flag3)
												{
													flag = false;
													result2 = cRMspSelectCrmsysSetting_Result.UserLoginAccessDistance.GetValueOrDefault();
													if (usLat == 0.0 && usLng == 0.0)
													{
														return new QRCodeServiceResult<QRCodeResult>
														{
															Message = Messages.msgErrorGettingCurrentLocation,
															Data = qRCodeResult,
															Status = QRCodeServiceResultStatus.Fail
														};
													}
													if (flag2)
													{
														double result3 = 0.0;
														double result4 = 0.0;
														CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = Info.Get(num);
														if (cRMspLoadUserLoginInfoViewModel != null)
														{
															List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
															if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations ?? "") != "")
															{
																list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocations);
															}
															else if (cRMspLoadUserLoginInfoViewModel.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (cRMspSelectCrmsysSetting_Result.CoLocations ?? "") != "")
															{
																list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(cRMspSelectCrmsysSetting_Result.CoLocations);
															}
															foreach (Dictionary<string, string> item in list)
															{
																double.TryParse(item["lat"], out result3);
																double.TryParse(item["lng"], out result4);
																double.TryParse(item["AccessDistance"], out result2);
																if (result3 != 0.0 && result4 != 0.0)
																{
																	if (Public.GetDistance(result4, result3, usLng, usLat) <= result2)
																	{
																		flag = true;
																	}
																}
																else
																{
																	text = Messages.MsgCoLocationNotDefined;
																	qRCodeResult.data = false;
																	qRCodeResult.changeMode = true;
																	qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
																}
															}
														}
													}
													if (!flag && flag3)
													{
														foreach (CRMspSelectSmartTimeAttendanceMission_Result item2 in Enumerable.ToList<CRMspSelectSmartTimeAttendanceMission_Result>((IEnumerable<CRMspSelectSmartTimeAttendanceMission_Result>)cRMSpIEntities.CRMspSelectSmartTimeAttendanceMission(num)))
														{
															double result5 = 0.0;
															double result6 = 0.0;
															double.TryParse(item2.PlaceCoordinateLatitude, out result5);
															double.TryParse(item2.PlaceCoordinateLongitude, out result6);
															if (result5 != 0.0 && result6 != 0.0 && Public.GetDistance(result6, result5, usLng, usLat) <= result2)
															{
																flag = true;
																break;
															}
														}
													}
												}
											}
											if (flag)
											{
												ParamViewModel paramViewModel = new ParamViewModel();
												paramViewModel.Lat = usLat;
												paramViewModel.Lng = usLng;
												paramViewModel.Mode = mode;
												paramViewModel.SDomain = sDomain;
												paramViewModel.KeyValue = qrCode;
												UserLoginSmartTimeAttendance.Update(num, qrCode, "", JsonConvert.SerializeObject(paramViewModel));
												text = Messages.msgSuccessAction;
												qRCodeResult.data = true;
												qRCodeResult.changeMode = false;
												qRCodeServiceResultStatus = QRCodeServiceResultStatus.Success;
											}
											else
											{
												text = ((flag2 && !flag3) ? string.Format(Messages.msgNotInCompanyAreaToScanQrCode, result2) : ((!(!flag2 && flag3)) ? string.Format(Messages.msgNotInCompanyOrMissionAreaToScanQrCode, result2) : string.Format(Messages.msgNotInMissionAreaToScanQrCode, result2)));
												qRCodeResult.data = false;
												qRCodeResult.changeMode = true;
												qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
											}
										}
										else
										{
											text = Messages.msgErrorNotMatchBarcodeWithMobBarCode;
											qRCodeResult.data = false;
											qRCodeResult.changeMode = false;
											qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
										}
									}
									else
									{
										text = Messages.msgErrorNotRegisterBarcodeQR;
										qRCodeResult.data = false;
										qRCodeResult.changeMode = false;
										qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
									}
								}
								else
								{
									text = Messages.msgErrorReRegisterBarcodeQR;
									qRCodeResult.data = false;
									qRCodeResult.changeMode = false;
									qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
								}
							}
							else
							{
								text = Messages.msgErrorBarCodeQrHasExpired;
								qRCodeResult.data = false;
								qRCodeResult.changeMode = false;
								qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
							}
						}
						else
						{
							text = Messages.msgErrorNotMatchCrmUserAndUserEnterQrCode;
							qRCodeResult.data = false;
							qRCodeResult.changeMode = false;
							qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
						}
					}
					else
					{
						text = Messages.msgErrorNotMatchCrmUserAndUserEnterQrCode;
						qRCodeResult.data = false;
						qRCodeResult.changeMode = false;
						qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
					}
				}
				else
				{
					text = Messages.msgErrorNotSendQRCode;
					qRCodeResult.data = false;
					qRCodeResult.changeMode = false;
					qRCodeServiceResultStatus = QRCodeServiceResultStatus.Fail;
				}
			}
			else
			{
				text = Messages.msgErrorAccessingToken;
				qRCodeResult.data = false;
				qRCodeResult.changeMode = false;
				qRCodeServiceResultStatus = QRCodeServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.msgErrorRunFunction;
			qRCodeResult.data = false;
			qRCodeResult.changeMode = false;
			qRCodeServiceResultStatus = QRCodeServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new QRCodeServiceResult<QRCodeResult>
		{
			Message = text,
			Data = qRCodeResult,
			Status = qRCodeServiceResultStatus
		};
	}

	public int CheckToken(string token)
	{
		int result = 0;
		if (string.IsNullOrWhiteSpace(token))
		{
			return 0;
		}
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[3], out var _);
			int.TryParse(array[1], out var result3);
			result = result3;
			return result;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
	}
}
