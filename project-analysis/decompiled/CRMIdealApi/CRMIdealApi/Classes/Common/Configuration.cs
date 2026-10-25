using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using Elmah;

namespace CRMIdealApi.Classes.Common;

public static class Configuration
{
	private static string _cacheUniqueName = "";

	private static string _cacheDefaultName = "";

	private static string _cacheDefaultTimeInMinutes = "";

	private static string _maxCountOfOnlineUser = "";

	private static string _maxCountOfOnlineUserInMob = "";

	private static string _maxCountOfOnlineUserDeActive = "";

	private static string _maxCountOfOnlineUserInHrm = "";

	private static string _maxCountWarehouse = "";

	private static string _maxCountCic = "";

	private static string _maxCountCrmShop = "";

	private static string _maxAccDbCount = "";

	private static string _maxViopCount = "";

	private static string _maxViopTrunkCount = "";

	private static string _maxFoCount = "";

	private static string _maxCenterCount = "";

	public static string CacheUniqueName
	{
		get
		{
			if (_cacheUniqueName != "")
			{
				return _cacheUniqueName;
			}
			try
			{
				_cacheUniqueName = ApplicationSettings.GetValue("CacheUniqueName");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return _cacheUniqueName;
		}
		set
		{
			_cacheUniqueName = value;
		}
	}

	public static string CacheDefaultName
	{
		get
		{
			if (_cacheDefaultName != "")
			{
				return _cacheDefaultName;
			}
			try
			{
				_cacheDefaultName = ApplicationSettings.GetValue("CacheDefaultName");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return _cacheDefaultName;
		}
		set
		{
			_cacheDefaultName = value;
		}
	}

	public static int CacheDefaultTimeInMinutes
	{
		get
		{
			int result = 0;
			if (_cacheDefaultTimeInMinutes != "")
			{
				int.TryParse(_cacheDefaultTimeInMinutes, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
					ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("CacheDefaultTimeInMinutes")));
					if (apispSelectCrmWebSetting_Result != null)
					{
						_cacheDefaultTimeInMinutes = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
						int.TryParse(_cacheDefaultTimeInMinutes, out result);
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
			}
			return result;
		}
		set
		{
			int num = value;
			_cacheDefaultTimeInMinutes = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUser
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUser != "")
			{
				int.TryParse(_maxCountOfOnlineUser, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
									if (array2 != null && array2.Length == 2)
									{
										text3 = array2[0];
										text3 = CodeDecode.RegDeCodding(text3);
									}
								}
								text3 = text3.Remove(text3.Length - 5);
								text3 = text3.Substring(6);
								_maxCountOfOnlineUser = text3;
								int.TryParse(_maxCountOfOnlineUser, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUser = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserInMob
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserInMob != "")
			{
				int.TryParse(_maxCountOfOnlineUserInMob, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("UsrDeAct") < 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
											text3 = CodeDecode.RegDeCodding(text3);
										}
									}
									else if (text3.IndexOf("UsrDeAct") >= 0)
									{
										string[] array3 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array3 != null && array3.Length == 2)
										{
											text3 = array3[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrDeAct") >= 0)
										{
											string[] array4 = text3.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
											if (array4 != null && array4.Length == 2)
											{
												text3 = array4[0];
												text3 = CodeDecode.RegDeCodding(text3);
											}
										}
									}
								}
								text3 = text3.Remove(text3.Length - 5);
								text3 = text3.Substring(6);
								_maxCountOfOnlineUserInMob = text3;
								int.TryParse(_maxCountOfOnlineUserInMob, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserInMob = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserDeActive
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserDeActive != "")
			{
				int.TryParse(_maxCountOfOnlineUserDeActive, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("UsrDeAct") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("UsrDeAct") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrDeAct") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
											}
										}
										if (!string.IsNullOrWhiteSpace(text3))
										{
											if (text3.IndexOf("UsrHrm") >= 0)
											{
												string[] array4 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
												if (array4 != null && array4.Length == 2)
												{
													text3 = array4[0];
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
											else
											{
												text3 = CodeDecode.RegDeCodding(text3);
											}
										}
										else
										{
											text3 = CodeDecode.RegDeCodding(text3);
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCountOfOnlineUserDeActive = text3;
								int.TryParse(_maxCountOfOnlineUserDeActive, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserDeActive = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserInHrm
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserInHrm != "")
			{
				int.TryParse(_maxCountOfOnlineUserInHrm, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("UsrHrm") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("UsrHrm") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("WhCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCountOfOnlineUserInHrm = text3;
								int.TryParse(_maxCountOfOnlineUserInHrm, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserInHrm = num.ToString();
		}
	}

	public static int MaxCountWarehouse
	{
		get
		{
			int result = 0;
			if (_maxCountWarehouse != "")
			{
				int.TryParse(_maxCountWarehouse, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("WhCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("WhCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("WhCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("CicCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCountWarehouse = text3;
								int.TryParse(_maxCountWarehouse, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountWarehouse = num.ToString();
		}
	}

	public static int MaxCountCic
	{
		get
		{
			int result = 0;
			if (_maxCountCic != "")
			{
				int.TryParse(_maxCountCic, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("CicCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("CicCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("CicCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("CRMShopCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCountCic = text3;
								int.TryParse(_maxCountCic, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountCic = num.ToString();
		}
	}

	public static int MaxCountCrmShop
	{
		get
		{
			int result = 0;
			if (_maxCountCrmShop != "")
			{
				int.TryParse(_maxCountCrmShop, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("CRMShopCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("CRMShopCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("CRMShopCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("AccDbCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCountCrmShop = text3;
								int.TryParse(_maxCountCrmShop, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountCrmShop = num.ToString();
		}
	}

	public static int MaxAccDbCount
	{
		get
		{
			int result = 0;
			if (_maxAccDbCount != "")
			{
				int.TryParse(_maxAccDbCount, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("AccDbCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("AccDbCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("AccDbCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("VoipCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "VoipCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxAccDbCount = text3;
								int.TryParse(_maxAccDbCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxAccDbCount = num.ToString();
		}
	}

	public static int MaxViopCount
	{
		get
		{
			int result = 0;
			if (_maxViopCount != "")
			{
				int.TryParse(_maxViopCount, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("VoipCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("VoipCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("VoipCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "VoipCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("VoipTunkCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "VoipTunkCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxViopCount = text3;
								int.TryParse(_maxViopCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxViopCount = num.ToString();
		}
	}

	public static int MaxViopTrunkCount
	{
		get
		{
			int result = 0;
			if (_maxViopTrunkCount != "")
			{
				int.TryParse(_maxViopTrunkCount, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("VoipTunkCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("VoipTunkCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("VoipTunkCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "VoipTunkCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("FoCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "FoCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxViopTrunkCount = text3;
								int.TryParse(_maxViopTrunkCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxViopTrunkCount = num.ToString();
		}
	}

	public static int MaxFOCount
	{
		get
		{
			int result = 0;
			if (_maxFoCount != "")
			{
				int.TryParse(_maxFoCount, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("FoCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("FoCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("FoCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "FoCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												if (!string.IsNullOrWhiteSpace(text3))
												{
													if (text3.IndexOf("CCnt") >= 0)
													{
														string[] array4 = text3.Split(new string[1] { "CCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text3 = array4[0];
															text3 = CodeDecode.RegDeCodding(text3);
														}
													}
													else
													{
														text3 = CodeDecode.RegDeCodding(text3);
													}
												}
												else
												{
													text3 = CodeDecode.RegDeCodding(text3);
												}
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxFoCount = text3;
								int.TryParse(_maxFoCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxFoCount = num.ToString();
		}
	}

	public static int MaxCenterCount
	{
		get
		{
			int result = 0;
			if (_maxCenterCount != "")
			{
				int.TryParse(_maxCenterCount, out result);
			}
			else
			{
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
					if (apispSelectCrmsysSetting_Result != null)
					{
						string lockSerial = apispSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string text = CodeDecode.RegDeCodding(value);
							string[] array = text.Split(new char[1] { '|' });
							string text2 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
							if (text2 == lockSerial)
							{
								string text3 = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3.IndexOf("CCnt") < 0)
									{
										text3 = "0";
									}
									else if (text3.IndexOf("CCnt") >= 0)
									{
										string[] array2 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text3 = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("CCnt") >= 0)
										{
											string[] array3 = text3.Split(new string[1] { "CCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text3 = array3[1];
												text3 = CodeDecode.RegDeCodding(text3);
											}
										}
									}
								}
								if (text3 != "0")
								{
									text3 = text3.Remove(text3.Length - 5);
									text3 = text3.Substring(6);
								}
								_maxCenterCount = text3;
								int.TryParse(_maxCenterCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
				finally
				{
					cRMEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCenterCount = num.ToString();
		}
	}
}
