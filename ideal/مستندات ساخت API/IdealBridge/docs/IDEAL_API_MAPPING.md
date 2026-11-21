# نگاشت IdealBridge API ⇄ دیتابیس Ideal (crmideal)

> سند فاز ۱۲ — مرجع نگاشت فیلد-به-فیلد برای MedPad · مبنای ستون‌ها: `CRMTabel.ssdl` نسخهٔ 3.1.18.187

## ۰. خواندن این سند

- ستون «Ideal Column» همیشه **نام واقعی و صحیح** در دیتابیس ۱۸۷ است (همه با اسکریپت ممیزی فاز ۱۲ در برابر SSDL راستی‌آزمایی شده).
- هر جا کد فعلی IdealBridge نام دیگری نوشته، ستون «API Field / Notes» با برچسب **[BUG]** مشخص کرده است — فهرست کامل با شواهد در `IDEAL_SCHEMA_AUDIT.md` §۲. این سند نقشهٔ *هدف* است، نه وضعیت کد فعلی.
- ستون «Join» = نحوهٔ اتصال به جدول والد ([FK] = قید واقعی، [L] = منطقی با شاهد کد، طبق `IDEAL_DATABASE_MAP.md`).
- ستون «نسخهٔ ۱۶۹» یعنی ریسک نبودِ ستون در نصب 3.1.16.169.0303 (بر پایهٔ سبد نسخهٔ کاتالوگ): ✅ = از V1/V2 موجود، ⚠️ = افزودهٔ V6/V7/V8.

## ۱. دامنهٔ «مشتری» (Company)

Endpoint فعلی: `GET /api/v1/companies` · `GET /api/v1/companies/{id}` · `GET /api/v1/sync/companies` — منبع: `CompanyRepository` (حالت Table).

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Customer.Id | CrmCompany | CompanyID | PK (identity) | id | پایدار؛ مبنای `afterId` |
| Customer.Number | CrmCompany | cmpNumber | — | number | فیلتر `number` |
| Customer.Code | CrmCompany | cmpCode | — | code | فیلتر تطابق دقیق `code`؛ JSON چندکدی در نسخه‌های جدید |
| Customer.Name | CrmCompany | cmpName | — | name | فیلتر LIKE `name` |
| Customer.NameEn | CrmCompany | cmpNameEng | — | nameEn | |
| Customer.OfficialName | CrmCompany | cmpNameOfficial | — | (در DTO هست) | ⚠️ V6 — نبود در 169 → کاوش/حذف اختیاری |
| Customer.Title | CrmCompanyTitle | CompanyTitle | cmpTitleId → CompanyTitleID [L] | title / titleId | |
| Customer.Group | CrmCompanyGroups | GroupName | cmpGroupId → CompanyGroupID [L] | group / groupId | |
| Customer.SubGroup | CrmCompanySubGroups | SubGroupName | cmpSubGroupId → CompanySubGroupID [L] | subGroup | ParentId=CompanyGroupID |
| Customer.GroupII/III/IV | CrmCompanyGroupsII/III/IV | GroupIIName / GroupIIIName / GroupIVName | cmpGroupIdII/III/IV [L] | group2..4 | |
| Customer.Type | CrmCompanyType | CompanyTypeName | cmpTypeId → CompanyTypeID [L] | type | |
| Customer.Presentation | CrmCompanyPresentation | Presentation | cmpPresentationId [L] | presentation | |
| Customer.Phones | CrmCompany | cmpPreTel, cmpTel, cmpTelUpTo, cmpTelDesc, cmpPreTelII, cmpTelII, cmpTelUpToII, cmpTelIIDesc, cmpFax, cmpFaxDesc | — | phones… | |
| Customer.Mobile | CrmCompany | cmpMobile | — | mobile | |
| Customer.Email/Web | CrmCompany | cmpEmail, cmpWebSite | — | email, webSite | |
| Customer.Address | CrmCompany | cmpAddress, cmpAddressDesc, cmpZipCode, cmpPostBox | — | address… | |
| Customer.Geo | CrmCompany | cmpCoordinateLatitude, cmpCoordinateLongitude, cmpCoordinateZoomLevel, cmpCoordinateLastDate | — | latitude/longitude… | nvarchar — تبدیل عددی سمت MedPad |
| Customer.Country/Province/City | Country / Province / City | Country / Province / City | cmpCountryId → CountryID، cmpProvinceId → ProvinceID، cmpCityId → CityID [L] | country/province/city (+Id) | زنجیرهٔ City.ProvinceId → Province.CountryId |
| Customer.Registration | CrmCompany | cmpRegistrationNumber, cmpEconomicCode, cmpNationalCode, cmpBuyLimit, cmpAccountNumber | — | registration… | شناسه‌های ثبتی/اعتباری |
| Customer.SalesRep | Users | FName + N' ' + LName | cmpReferUserId → UserId [FK V4] | referUserId, referUser | «بازاریاب/معرف» — همان الگوی join فعلی |
| Customer.OwnerEditor | Users | FName/LName | UserId (آخرین ویراستر) → UserId [FK V4] | lastEditUserId/User | معنا: آخرین ویراستر (شاهد §۲ نقشه) |
| Customer.CreatedBy | Users | FName/LName | FirstRegisterUserId → UserId [FK V4] | firstRegister… | سازنده |
| Customer.MainContact | CrmCompanyPersons | prsFName/prsLName + CrmPersonTitle.PersonTitle | cmpMainPersonId → CompanyPersonID [L] | mainPersonId, mainPersonName | زیرکوئری TOP 1 فعلی |
| Customer.IsDraft | CrmCompany | cmpIsDraft | — | isDraft | ⚠️ V5 — برای 169 کم‌ریسک‌تر از V6 ولی بررسی شود |
| Customer.Kind | CrmCompany | cmpKind | — | kind | ⚠️ V5 |
| Customer.Status | CrmCompany | (بدون ستون IsDeleted/InActive) | — | — | «حذف» در Ideal ردیابی نمی‌شود — فقط Draft/نهایی |
| Customer.Timestamps | CrmCompany | RegisterDate, RegisterDatePersian, FirstRegisterDate, ImportDate, ImportDateTime | — | registeredAt… | RegisterDate = آخرین ویرایش (اثبات‌شده) |
| Customer.Password | CrmCompany | cmpPassword | — | — | **حذف عمدی از نگاشت (ApiCmpPassword قدیمی Ideal هم حذف شد)** |

## ۲. دامنهٔ «شخص مرتبط» (Contact/Person)

Endpoint فعلی: `GET /api/v1/persons` · `GET /api/v1/persons/{id}` · `GET /api/v1/sync/persons` — منبع: `PersonRepository`.

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Contact.Id | CrmCompanyPersons | CompanyPersonID | PK | id | |
| Contact.CompanyId | CrmCompanyPersons | prsCompanyId | → CrmCompany.CompanyID [L] | companyId | فیلتر `companyId` |
| Contact.CompanyName | CrmCompany | cmpName | [L] | companyName | |
| Contact.FirstName/LastName | CrmCompanyPersons | prsFName, prsLName | — | firstName, lastName | فیلتر LIKE `name` روی هر دو |
| Contact.Title | CrmPersonTitle | PersonTitle | prsTitleId → PersonTitleID [L] | title | |
| Contact.Job | **CrmPersonJobs** | **Jobs** | prsJobId → PersonJobID [L] | job | **[BUG کد فعلی: جدول `CrmPersonJob`، ستون‌های `JobID/Job` — هر سه نام در هیچ نسخه‌ای نبوده]** |
| Contact.Type | CrmPersonType | PersonType | prsTypeId → PersonTypeID [L] | type | |
| Contact.Group | **CrmPersonGroups** | **PersonGroup** | prsGroupId → PersonGroupID [L] | personGroup | **[BUG: `GroupName` — نام واقعی `PersonGroup`]** |
| Contact.Sex | **Sex** | **SexType** | prsSexId → SexID [L] | sex | **[BUG: `Sex` — نام واقعی `SexType`]** |
| Contact.Education | Education | Education | prsEducationId → EducationID [L] | education | |
| Contact.Department | **CrmPersonDepartments** | **PersonDepartment** | prsDepartmentId → PersonDepartmentId [L] | department | **[BUG: `DepartmentID/Department` — نام واقعی `PersonDepartmentId/PersonDepartment`]** |
| Contact.Phones | CrmCompanyPersons | prsPreTel, prsTel, prsTelUpTo, prsTelDesc, prsTelII, prsFax | — | phones… | |
| Contact.Mobile | CrmCompanyPersons | prsMobile | — | mobile | فیلتر LIKE `mobile` |
| Contact.Email/Web | CrmCompanyPersons | prsEmail, prsEmailII, prsWebSite | — | email… | |
| Contact.Address/Geo | CrmCompanyPersons + Country/Province/City | prsAddress, prsZipCode, prsPostBox; Country/Province/City | prsCountryId/ProvinceId/CityId [L] | address, country… | |
| Contact.NationalId | CrmCompanyPersons | prsNationalCode, prsIdentityNumber | — | nationalCode… | **PII — تصمیم حداقل‌سازی داده در سند امنیت §۴** |
| Contact.Personal | CrmCompanyPersons | prsFatherName, prsBirthDate, prsBirthPlace, prsIsMarried, prsMarriageDate, prsSkill, prsStudyField | — | … | |
| Contact.Flags | CrmCompanyPersons | prsWorkingOut, prsStopSendSms, ImportDate | — | workingOut (فیلتر), … | |
| Contact.Timestamps | CrmCompanyPersons | RegisterDate(+Persian), FirstRegisterDate | — | … | prsFirstRegisterUserId → Users [FK V4] |

## ۳. دامنهٔ «آدرس‌های مشتری»

Endpoint فعلی: `GET /api/v1/companies/{id}/addresses`.

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Address.Id | CrmCompanyAddresses | CompanyAddressId | PK | id | |
| Address.CompanyId | CrmCompanyAddresses | cmpaddCompanyId | → CrmCompany.CompanyID [L] | companyId | `WHERE A.cmpaddCompanyId = @companyId` |
| Address.Type | **CrmCompanyAddressType** | **CompanyAddressTypeName** | cmpaddTypeId → CompanyAddressTypeId [FK V7] | type | **[BUG: `CompanyAddressType` — نام واقعی `CompanyAddressTypeName`]؛ ⚠️ ستون cmpaddTypeId افزودهٔ V7 (RZ14010912)** |
| Address.City | City | City | cmpaddCityId → CityID [L] | city | |
| Address.Text | CrmCompanyAddresses | CompanyAddress, cmpaddDesc, cmpaddZipCode, cmpaddPostBox | — | … | |
| Address.Geo | CrmCompanyAddresses | cmpaddCoordinateLatitude/Longitude/ZoomLevel/LastDate | — | … | |

## ۴. دامنهٔ «کاربر/نمایندهٔ فروش» (User/SalesRep)

Endpoint فعلی: `GET /api/v1/users` · `GET /api/v1/users/{id}` — منبع: `UserRepository` (بدون join).

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| User.Id | Users | UserId | PK | id | |
| User.Name | Users | FName, LName | — | firstName/lastName/fullName | |
| User.UserName | Users | UserName | — | userName | شناسهٔ ورود — افشا فقط در صورت نیاز |
| User.PersonnelCode | Users | PersCode | — | personnelCode | |
| User.IsAdmin | Users | IsAdmin | — | isAdmin | nvarchar 'True'/'False' — خوانندهٔ bool-like امن |
| User.IsActive | Users | IsActive, UserIsActiveInWinApp, UserIsActiveInWebApp, UserIsActiveInMobApp | — | isActive… | |
| User.Mobile | Users | Mobile, MobileII, Tel | — | mobile… | |
| User.Position | UserPositions | PositionName | PositionId → PositionId [L] | positionId | درخت: UserPositions.ParentId |
| User.Group | UserGroups | GroupName | UserGroupId → UserGroupId [L] | userGroupId | ⚠️ ستون Users.UserGroupId افزودهٔ V6 |
| User.NationalCode | Users | NationalCode | — | nationalCode | **PII** |
| User.Validity | Users | StartDate, ExpireDate | — | startDate/expireDate | ⚠️ هر دو V6 |
| User.Password | Users | Password (nvarchar 50) | — | **—** | **هرگز در SELECT نیست (تضمین کد + تست)** |

انتساب کاربر↔مشتری در Ideal با جداول `CrmCompanyForbidden*` / `CrmCompanyJustAccess*` (سطح دسترسی دید کاربران CRM) مدیریت می‌شود — **نگاشت فعلی ندارد**؛ اگر MedPad به «مشتریانِ هر نماینده» نیاز داشت، مرجع منطقی همان `CrmCompany.cmpReferUserId` (بازاریاب مستقیم) است و پوشش کامل با آن جداول ممنوعیت/دسترسی، تصمیم آیندهٔ محصول است (خارج از فاز ۱۲).

## ۵. دامنهٔ «محصول»

Endpoint فعلی: `GET /api/v1/products` — منبع: `ProductRepository`.

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Product.Id | WSProducts | ProductID | PK | id | مبنای `afterId` |
| Product.Code | WSProducts | PrdCode | — | code | فیلتر دقیق |
| Product.Name | WSProducts | PrdName, PrdLatinName | — | name/latinName | فیلتر LIKE `name` |
| Product.Group | WSProductSecondGroup (گروه ۲) → WSProductFirstGroup | SGName؛ FGCode/FGName | PrdGroupID → PrdSecondGroupID [L]؛ SecondGroup.FirstGroupId → PrdFirstGroupID [L] | groupId | فیلتر `groupId`؛ **[BUG کد فعلی: join به `WSProductFirstGroup` با `ProductFirstGroupID`/`GroupName` — نام واقعی `PrdFirstGroupID`/`FGName` و جدول درست برای PrdGroupID خودِ `WSProductSecondGroup` است]** |
| Product.Type/Model | WSProducts | PrdType, PrdModel | — | type/model | |
| Product.Color | WSProductColor | Color | PrdColorId → ProductColorID [L] | color | (ColorEn هم هست) |
| Product.Unit | **WSProductUnits** | **Unit** | PrdUnitId → ProductUnitID [L] | unit | **[BUG: جدول `WSProductUnit`/ستون `UnitName` — واقعی: `WSProductUnits`/`Unit`]** |
| Product.Barcode | WSProducts | PrdFirstBarcode | — | barcode | |
| Product.Inactive | WSProducts | PrdInActive, PrdInactiveInSale, PrdInactiveInBuy | — | … | ⚠️ PrdInActive افزودهٔ V6 |
| Product.Thresholds | WSProducts | PrdMinQuantity, PrdMaxQuantity (V6)، PrdMinQty, PrdMaxQty (پایه) | — | minQty/maxQty | ⚠️ Quantity-ها V6 |
| Product.Weight | WSProducts | PrdWeight | — | weight | ⚠️ V8 (RZ14031114) |
| Product.Timestamps | WSProducts | RegisterDate, FirstRegisterDate | — | … | فیلترهای `registeredFrom/To` |

## ۶. دامنهٔ «قیمت» (هنوز Endpoint ندارد — نقشهٔ مسیر آینده)

⚠️ **قاعدهٔ طلایی: `WSProductPrice.Price` قیمتِ نهایی فروش نیست** — «آخرین ردیف قیمتِ محصول در گروه-قیمت بر اساس DocDate» است (تابع `WSfnReturnProductPrice`). قیمت مؤثر سفارش توسط `WSspAutoCalcOrderItemPrice` (با گروه قیمت، مشتری، واحد پول) محاسبه و در `WSOrderItems.ordIPrice` ثبت می‌شود.

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field (آینده) | Notes |
|---|---|---|---|---|---|
| PriceGroup.Id/Name | WSProductPriceGroup | ProductPriceGroupID, ProductPriceGroupName | PK | priceGroupId/Name | گروه پیش‌فرض = ۱ «لیست پیش فرض» |
| Price.List | WSProductPrice | PrdId, ProductPriceGroupId, Price, CurrencyPrice, CurrencyUnitId, DocDate, DocDateTime, DocNumber, WHId, FPId, Month1, CId | PrdId → WSProducts [L]؛ ProductPriceGroupId → WSProductPriceGroup **[FK V4]**؛ WHId → WsWareHouse **[FK V4]** | price, currency, date | رزولوشن: `TOP 1 ... WHERE PrdId=@p AND ProductPriceGroupId=@g ORDER BY DocDate DESC` (+tie-break PrdPriceID در ایندکس V8) |
| Price.Components | WSProductPrice | CooperationPrice, PricePercent, DiscountPrecent, Discount, OtherPrice, PrePaymentPrice, TaxIndex | — | … | اجزای قیمت برای سناریوهای خاص |
| Price.Currency | WSCurrencyUnits | CurrencyUnit, IsDecimal | CurrencyUnitId → CurrencyUnitID [L] | currencyName | |
| Price.CustomerSpecific | (SPها) | WSspCmpPrdSalePriceHistory, WSspReturnPricePartRateFromCmpGroupII | — | — | قیمت مشتری-خصیص/نرخ گروه II — فقط از طریق گزارش تاریخچه؛ ریسک پیاده‌سازی مستقیم بالا |
| Cost | WSProductCost / WSProductCostGroup | Cost, TransportCost, ... | ProductCostGroupId [FK V4] | — | بهای تمام‌شده — خارج از دامنهٔ MedPad |

## ۷. دامنهٔ «موجودی» (هنوز Endpoint ندارد — نقشهٔ مسیر آینده)

**موجودی انبار محاسبه‌ای است، نه ستونی روی محصول:** `Remain = SUM(In) - SUM(Out)` روی `WSDoc JOIN WSDocItems` که جهت هر سند از `WSDocOpr.OprType` (1=ورود، 2=خروج) می‌آید — به تفکیک `FPId + WHId + PrdId` (متن `WSspRpt_WareHouseStock`).

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field (آینده) | Notes |
|---|---|---|---|---|---|
| Warehouse.Id/Name | WsWareHouse | WareHouseID, WrhsName, WrhsCode, WrhsDeActive | PK | id/name/code | Endpoint فعلی `GET /warehouses` همین را می‌دهد |
| Stock.Warehouse | WSDoc | WHId (مبدأ) / WHIdI (مقصد) | → WareHouseID [FK V4 برای WHIdI] | — | سند انتقال دو انبار دارد |
| Stock.Direction | WSDocOpr | OprType (1=In / 2=Out) | WSDoc.OprId → DocOprID [L] | — | قلب فرمول موجودی |
| Stock.Doc | WSDoc | DocID, DocNumber, DocDate, DocDateTime, FPId, CompanyId | CompanyId → CrmCompany **[FK V4]** | — | |
| Stock.Item | WSDocItems | DocItemID, DocId, PrdId, WHId, Quantity | DocId → WSDoc [L]؛ PrdId → WSProducts [L] | qty | ایندکس V8: (PrdId, DocId, WHId, DocICId) |
| Stock.FinancialPeriod | WSFinancialPeriod | ID, Name, FDate, TDate | WSDoc.FPId → ID [L] | — | موجودی همیشه «تا پایان دورهٔ X» معنا دارد |
| Stock.MinMax | WSProducts | PrdMinQty/PrdMaxQty (پایه)، PrdMinQuantity/MaxQuantity (⚠️ V6) | — | — | آستانهٔ هشدار — نه موجودی جاری |
| Stock.Serial | WSDocItemSerials | SerialId… | — | — | ردیابی سریالی — فقط اگر MedPad سریال‌محور شود |

## ۸. دامنهٔ «پیش‌سفارش» (PreOrder)

Endpoint فعلی: `GET /api/v1/preorders` — منبع: `OrderRepository` (کوئری WSPreOrder).

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| PreOrder.Id | WSPreOrder | PreOrderID | PK | id | |
| PreOrder.Opr | WSOrderOpr/ WSPreOrderOpr | PreOrderOprID | → WSPreOrderOpr(PreOrderOprID) [L] | oprId (+oprName از WSOrderOpr در کد فعلی) | **[BUG محتمل: کد فعلی `OP.Name` را از `WSOrderOpr` می‌گیرد در حالی که ستون WSPreOrder.PreOrderOprID به WSPreOrderOpr اشاره می‌کند — راستی‌آزمایی runtime لازم]** |
| PreOrder.Number | WSPreOrder | pordNumber (bigint), pordNumberRevision, pordParentPreOrderId | — | number | بازنگری‌ها زنجیرهٔ Parent دارند |
| PreOrder.Date | WSPreOrder | pordDate (جلالی nvarchar(8)), pordDateTime | — | date/dateTime | فیلتر بازهٔ `fromDate/toDate` روی pordDateTime |
| PreOrder.Company | CrmCompany | cmpName | pordCompanyId → CompanyID [L] | companyId/companyName | فیلتر `companyId` |
| PreOrder.Contact/Project | CrmCompanyPersons / CrmProjects | — | pordCompanyPersonId / pordProjectId [L] | contactId/projectId | |
| PreOrder.Amounts | WSPreOrder | pordItemsAmount, pordInstallAmount, pordDiscount, pordSumAmount, pordTax, pordTotalAmount, pordItemCount | — | … | |
| PreOrder.Verified | WSPreOrder | pordIsVerified, pordVerifierId, pordVerifiedRegisterDate | — | isVerified (+فیلتر) | **وجود رکورد ≠ تأیید** |
| PreOrder.Status | WSPreOrderStatus | PreOrderStatus | pordStatusId → PreOrderStatusId [L] | statusId | فرهنگ وضعیت با FPId |
| PreOrder.StatusDate | WSPreOrder | pordChangeStatusDate | — | — | ⚠️ V8 — در DTO هست |
| PreOrder.SalesRep | Users | FName/LName | pordReferUserId → UserId **[FK V3]** | referUserId/Name | |
| PreOrder.Seller/Center | WSPreOrder | pordSellerId, pordSaleCenterId | — | — | هنوز در DTO نیست |
| PreOrder.Deadline | WSPreOrder | pordExpireDate, pordDeadlineDate | — | — | |

## ۹. دامنهٔ «سفارش» (Order)

Endpoint فعلی: `GET /api/v1/orders` — منبع: `OrderRepository` (کوئری WSOrder).

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Order.Id | WSOrder | OrderID | PK | id | |
| Order.Opr | WSOrderOpr | Name, OprType, DocOprId | OrderOprID → OrderOprID [L]؛ DocOprId → WSDocOpr **[FK V4]** | oprId, oprName | **OprType=1 → برگشت از فروش! فیلتر نکردن آن، فروش را متورم می‌کند** |
| Order.Number | WSOrder | ordNumber (bigint) | — | number | فیلتر دقیق |
| Order.FromPreOrder | **WSPreOrder** | PreOrderID | **WSOrder.PreOrderId → PreOrderID [L] — رابطهٔ ۱:N** (شاهد: `WSfnReturnOrderFromPreOrder`) | (هنوز در DTO نیست) | قید FK در کاتالوگ نیست؛ پیوند منطقی |
| Order.Date | WSOrder | ordDate (جلالی), ordDateTime | — | date/dateTime | فیلتر بازه |
| Order.Company | CrmCompany | cmpName | ordCompanyId [L] | companyId/companyName | |
| Order.Contact/Project | — | ordCompanyPersonId, ordProjectId | [L] | contactId/projectId | |
| Order.Amounts | WSOrder | ordItemsAmount, ordInstallAmount, ordDiscount, ordSumAmount, ordTax, ordTotalAmount, ordItemCount | — | … | |
| Order.Verified | WSOrder | ordIsVerified, ordVerifierId → Users **[FK V4]**, ordVerifiedRegisterDate | — | isVerified (+فیلتر) | **وجود رکورد ≠ فروش قطعی** — ترکیب با OprType و Status |
| Order.Status | WSOrderStatus | OrderStatus | ordStatusId [L] | statusId | |
| Order.SalesRep | Users | FName/LName | ordReferUserId → UserId **[FK V4]** | referUserId/Name | |
| Order.Seller | WSOrder | ordSellerId | — | — | در SchemaProbe هست، در DTO/کوئری نه |

## ۱۰. دامنه‌های «اقلام سفارش» و «پرداخت» (Endpoint ندارند — نقشهٔ مسیر)

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field (آینده) | Notes |
|---|---|---|---|---|---|
| OrderItem.Id | WSOrderItems | OrderItemID | PK | id | |
| OrderItem.OrderId | WSOrderItems | OrderId | → WSOrder.OrderID [L] | orderId | |
| OrderItem.Product | WSProducts | PrdCode/PrdName | ordIPrdId → ProductID [L] | productId | |
| OrderItem.Qty | WSOrderItems | ordIQuantity (+ordIQuantityDesc, ordIFCR) | — | quantity | |
| OrderItem.Price | WSOrderItems | ordIPrice, ordITotalPrice, ordIPriceSum | — | price/total | قیمت لحظهٔ ثبت؛ گروه قیمت: ordIPrdPriceGroupID → WSProductPriceGroup |
| OrderItem.Discount/Tax | WSOrderItems | ordIDiscount(I)/(I)Percent, ordITax, ordITaxIndex, ordICalculateTax | — | … | |
| OrderItem.Unit/Currency | WSProductUnits / WSCurrencyUnits | Unit / CurrencyUnit | ordIPrdUnitId **[FK V4]**، ordICurrencyUnitId **[FK V4]** | unit/currency | |
| OrderItem.Warehouse | WsWareHouse | WrhsName | ordIWHId [L] | warehouseId | |
| PreOrderItem.* | WSPreOrderItems | (الگوی ordI* با پیشوند pordI*) | PreOrderId [L]؛ pordIPrdUnitId/pordICurrencyUnitId **[FK V4]** | — | |
| Payment.Id | WSOrderPayments | OrderPaymentId | PK | id | |
| Payment.OrderId | WSOrderPayments | ordpayOrderId | → WSOrder [L] | orderId | |
| Payment.Type | WSOrderPaymentTypes | ordpayType, ordpayTypeIsChq, DeActive | ordpayTypeId → OrderPaymentTypeId [L] | typeId/typeName | |
| Payment.Amount | WSOrderPayments | ordpayAmount, ordpayDocNumber, ordpayDocDate, ordpayDocAmount | — | amount/docNo/date | |
| Payment.FromPreOrder | WSPreOrderPayments | PreOrderPaymentId | WSOrderPayments.PreOrderPaymentId → PreOrderPaymentId [L] | — | کپی پرداختِ پیش‌سفارش هنگام صدور |
| Payment.FP | WSFinancialPeriod | Name | FPId → ID **[FK V4]** | fp | هر دو جدول پرداخت |

## ۱۱. دامنهٔ «فعالیت مشتری» (CRM Activity)

Endpointهای فعلی: `GET /conversations` · `GET /projects` · `GET /reminders` — منابع: Conversation/Project/ReminderRepository.

| MedPad Domain | Ideal Table | Ideal Column | Relationship/Join | API Field | Notes |
|---|---|---|---|---|---|
| Activity.Id | CrmConversation | ConversationID | PK | id | |
| Activity.Company | CrmCompany | cmpName | cnvsCompanyId [L] | companyId/Name | فیلتر |
| Activity.Contact | CrmCompanyPersons | — | cnvsPersonId [L] | personId | |
| Activity.Project | CrmProjects | — | cnvsProjectId [L] | projectId | فیلتر |
| Activity.Topic | **CrmConversationTopics** | **Topic** | cnvsTopicId → ConversationTopicsID [L] | topic | **[BUG: `TopicID/TopicName` — واقعی: `ConversationTopicsID/Topic`]** |
| Activity.Status | **CrmConversationStatus** | **Status** | cnvsStatusId → ConversationStatusID [L] | status | **[BUG: `ConversationStatus` — واقعی: `Status`]** |
| Activity.DateTime | CrmConversation | cnvsDate/cnvsDay/cnvsTime/cnvsDateTime | — | … | فیلتر بازه روی cnvsDateTime |
| Activity.Owner | Users | FName/LName | cnvsUserId → UserId [L] | userId/Name | فیلتر |
| Activity.ReferTo | Users | FName/LName | cnvsReferUserId [L] | referUserId/Name | |
| Activity.Remind | CrmConversation | cnvsRemindDateTime, cnvsRemindOk | — | … | |
| Activity.Ticket | CrmConversation | cnvsIsTicket, cnvsIsTicketNew (⚠️ V7), cnvsTicketIsRead | — | isTicket… | ⚠️ cnvsIsTicketNew نبودنش در 169 → SqlException (کاوشش هم در Probe نیست — ممیزی §۴) |
| CallLog | CrmCallHistory | CallHistoryID, CallTypeId, CallDateTime, CallerIDDetectData | CompanyID → CrmCompany **[FK V4]**، CompanyPersonId → CrmCompanyPersons **[FK V4]** | — | Endpoint ندارد؛ تنها فعالیت با FK واقعی |
| Reminder.Id | CrmUserTasks | UserTaskId | PK | id | |
| Reminder.User | Users | FName/LName | UserId [L] | userId/Name | پارامتر الزامی `userId` |
| Reminder.Schedule | CrmUserTasks | UserTaskDate, UserTaskTime, UserTaskTimeEnd, UserTaskRemindDate/Time/DateTime | — | … | فیلتر بازه + includeDone روی UserTaskDidIt |
| Reminder.Priority | **CrmUserTaskPriorities** | **Priority** | UserTaskPriorityId [L] | priority | **[BUG: `PriorityName` — واقعی: `Priority`]** |
| Reminder.Group | **CrmUserTaskGroups** | **UserTaskGroup** | UserTaskGroupId [L] | group | **[BUG: `GroupName` — واقعی: `UserTaskGroup`]** |
| Project.Id | CrmProjects | ProjectID | PK | id | |
| Project.Company | CrmCompany | cmpName | prjCompanyId [L] | companyId/Name | |
| Project.Title | CrmProjects | prjTitle, prjSubject (⚠️ V6), prjDesc | — | title/subject | |
| Project.Numbering | CrmProjects | prjNumRef, prjNumR (⚠️ V6), prjPostFix | — | … | |
| Project.Schedule | CrmProjects | prjStartDate/StartTime/StartDateTime، prjIsFinished/FinishedStatusId/FinishedDate | — | … | فیلتر isFinished |
| Project.Grade | **CrmProjectGrade** | **ProjectGrade** | prjGradeId [L] | grade | **[BUG: `GradeName` — واقعی: `ProjectGrade`]** |
| Project.Group | **CrmProjectGroups** | **ProjectGroup** | prjGroupId → ProjectGroupID **[FK V4]** | group | **[BUG: `GroupName` — واقعی: `ProjectGroup`]** |
| Project.Priority | CrmProjectPriority | Priority | prjPriorityId [L] | priority | درست در کد فعلی |

## ۱۲. اطلاعات پایه (BaseInfo) — `GET /api/v1/baseinfo/{kind}`

نگاشت صحیح kind → (جدول، ستون شناسه، ستون نام) — **نسخهٔ اصلاح‌شده با نام‌های واقعی** (نسخهٔ فعلی کد شامل ۷ مورد غلط است — ممیزی §۲):

| kind | جدول | Id | Name | Parent |
|---|---|---|---|---|
| companytitle | CrmCompanyTitle | CompanyTitleID | CompanyTitle | — |
| companytype | CrmCompanyType | CompanyTypeID | CompanyTypeName | — |
| companygroup | CrmCompanyGroups | CompanyGroupID | GroupName | — |
| companysubgroup | CrmCompanySubGroups | CompanySubGroupID | SubGroupName | CompanyGroupID |
| companygroupii..iv | CrmCompanyGroupsII/III/IV | CompanyGroupIIID/IIIID/IVID | GroupIIName/IIIName/IVName | — |
| companypresentation | CrmCompanyPresentation | CompanyPresentationID | Presentation | — |
| companyaddresstype | CrmCompanyAddressType | CompanyAddressTypeId | **CompanyAddressTypeName** | — |
| persontitle / persontype | CrmPersonTitle / CrmPersonType | PersonTitleID / PersonTypeID | PersonTitle / PersonType | — |
| personjob | **CrmPersonJobs** | **PersonJobID** | **Jobs** | — |
| persondepartment | CrmPersonDepartments | **PersonDepartmentId** | **PersonDepartment** | — |
| persongroup | CrmPersonGroups | PersonGroupID | **PersonGroup** | — |
| education / sex | Education / Sex | EducationID / SexID | Education / **SexType** | — |
| city / province / country | City / Province / Country | CityID / ProvinceID / CountryID | City / Province / Country | ProvinceId / CountryId / — |
| projecttitle / projectgroup / projectgrade / projectpriority | CrmProjectTitles / CrmProjectGroups / CrmProjectGrade / CrmProjectPriority | ProjectTitleID / ProjectGroupID / ProjectGradeID / ProjectPriorityID | ProjectTitle / **ProjectGroup** / **ProjectGrade** / Priority | — |

## ۱۳. SPهای API خود Ideal (مرجع تطبیق — نه مسیر اجرا)

`SchemaProbe.ExpectedSpSignatures` فقط برای گزارش موجودی/امضاست؛ اجرای SP غیرفعال است. مرجع نگاشت فیلدهای خروجی SPهای `ApispSelect*` (نسخهٔ ۱۸۷) با حالت Table در سند ۰۱ آمده؛ تفاوت امضای ۱۶۹ در سند ۰۹.
