USE [misigo]
GO
/****** Object:  StoredProcedure [dbo].[MSGMusteriUrunList]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSGMusteriUrunList]
GO
/****** Object:  StoredProcedure [dbo].[MSG_UrunListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_UrunListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TrendyolResimIndirListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TrendyolResimIndirListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxUrunListesi]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxUrun]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxUrun]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxStokEkle]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxStokEkle]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxStokCikar]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxStokCikar]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxSiparisList]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxSiparisList]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxResim]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxResim]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxMusteri_PR]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxMusteri_PR]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxMusteri]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxMusteri]
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxKategori]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_TicimaxKategori]
GO
/****** Object:  StoredProcedure [dbo].[MSG_SiparisList]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_SiparisList]
GO
/****** Object:  StoredProcedure [dbo].[MSG_SiparisBarkod]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_SiparisBarkod]
GO
/****** Object:  StoredProcedure [dbo].[MSG_RenkListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_RenkListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_OzellikTipiListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_OzellikTipiListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_OzellikListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_OzellikListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSZTTicimaxUrunQR]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MSZTTicimaxUrunQR]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSZTNebimUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MSZTNebimUrunListesi]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSRAFSAYIMOffline]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MSRAFSAYIMOffline]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoUrunListesi]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoSayimEkle]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoSayimEkle]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoSayimCikar]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoSayimCikar]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimListEkle2]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoResimListEkle2]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimListEkle]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoResimListEkle]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimIndirListeGuncelle]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoResimIndirListeGuncelle]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimIndirListe]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoResimIndirListe]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoKategoriList]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoKategoriList]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoFiyatDuzenle]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoFiyatDuzenle]
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoFirmaBilgileri_DB]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_MisigoFirmaBilgileri_DB]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount_Update]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount_Update]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount_delete]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount_delete]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemLotlistCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceItemLotlistCount]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_Update]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceItemlistCount_Update]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_delete]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceItemlistCount_delete]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_Complated]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceItemlistCount_Complated]
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_InvoiceItemlistCount]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetUrunListesi]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturnSeriNOUpdate]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetReturnSeriNOUpdate]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturnSeriNO]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetReturnSeriNO]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturn]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetReturn]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderGorsel]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderGorsel]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RShipmentID]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RShipmentID]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RShipment]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RShipment]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_ReturnItem]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_ReturnItem]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REToplu]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REToplu]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineReturn]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineReturn]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineCount]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnline]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnline]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RE]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RE]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_Item]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_Item]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_DB]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_DB]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_BPCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_BPCount]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIrsaliyeGorselHeader]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetIrsaliyeGorselHeader]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIrsaliyeGorsel]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetIrsaliyeGorsel]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetInvoiceGorsel]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetInvoiceGorsel]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIadeGorsel]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetIadeGorsel]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetFaturaGider]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetFaturaGider]
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetAlisSiparis]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_GetAlisSiparis]
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriRenk]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_DilCeviriRenk]
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriOzellikTipi]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_DilCeviriOzellikTipi]
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriOzellik]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_DilCeviriOzellik]
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviri]    Script Date: 21.02.2024 02:58:05 ******/
DROP PROCEDURE [dbo].[MSG_DilCeviri]
GO
ALTER TABLE [dbo].[ZTMSGYetki] DROP CONSTRAINT [DF_ZTMSGYetki_ID]
GO
ALTER TABLE [dbo].[ZTMSGUserLogin] DROP CONSTRAINT [DF_ZTMSGUserLogin_ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunResimList] DROP CONSTRAINT [DF_ZTMSGUrunResimList_ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunListMisigo2] DROP CONSTRAINT [DF_ZTMSGUrunListMisigo2_ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunListMisigo] DROP CONSTRAINT [DF_ZTMSGUrunListMisigo_ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunlerQR] DROP CONSTRAINT [DF_ZTMSGUrunlerQR_ID]
GO
ALTER TABLE [dbo].[ZTMSGTrendyolSiparisYD] DROP CONSTRAINT [DF_ZTMSGTrendyolSiparisYD_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicXmlUrl] DROP CONSTRAINT [DF_ZTMSGTicXmlUrl_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunVariant] DROP CONSTRAINT [DF_ZTMSGTicUrunVariant_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunKartiAcma] DROP CONSTRAINT [DF_ZTMSGTicUrunKartiAcma_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunAcmaParametreleri] DROP CONSTRAINT [DF_ZTMSGTicUrunAcmaParametreleri_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisListDetay] DROP CONSTRAINT [DF_ZTMSGTicSiparisListDetay_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisList] DROP CONSTRAINT [DF_ZTMSGTicSiparisList_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisList] DROP CONSTRAINT [DF_ZTMSGTicSiparisList_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisKontrol] DROP CONSTRAINT [DF_ZTMSGTicSiparisKontrol_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisKontrol] DROP CONSTRAINT [DF_ZTMSGTicSiparisKontrol_ID]
GO
ALTER TABLE [dbo].[ZTMSGTicKargo] DROP CONSTRAINT [DF_ZTMSGTicKargo_ID]
GO
ALTER TABLE [dbo].[ZTMSGStore] DROP CONSTRAINT [DF_ZTMSGStore_ID]
GO
ALTER TABLE [dbo].[ZTMSGSettings] DROP CONSTRAINT [DF_ZTMSGSettings_ID]
GO
ALTER TABLE [dbo].[ZTMSGRAFSTOK] DROP CONSTRAINT [DF_ZTMSGRAFSTOK_ID]
GO
ALTER TABLE [dbo].[ZTMSGRafSayimOffline] DROP CONSTRAINT [DF_ZTMSRAFSAYIMOFFLINE_ID]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] DROP CONSTRAINT [DF_ZTMSGRAFHAREKETLER_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] DROP CONSTRAINT [DF_ZTMSGRAFHAREKETLER_ItemDate]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] DROP CONSTRAINT [DF_ZTMSGRAFHAREKETLER_ID]
GO
ALTER TABLE [dbo].[ZTMSGRAF] DROP CONSTRAINT [DF_ZTMSGRAF_ID]
GO
ALTER TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri] DROP CONSTRAINT [DF_ZTMSGMisigoUrunAcmaParametreleri_ID]
GO
ALTER TABLE [dbo].[ZTMSGMisigoOzellikEslestir] DROP CONSTRAINT [DF_ZTMSGMisigoOzellikEslestir_ID]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakipKontrol] DROP CONSTRAINT [DF_ZTMSGKargoTakipKontrol_Tarih]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakipKontrol] DROP CONSTRAINT [DF_ZTMSGKargoTakipKontrol_ID]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakip] DROP CONSTRAINT [DF_ZTMSGKargoTakip_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakip] DROP CONSTRAINT [DF_ZTMSGKargoTakip_ID]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceReturnItemList] DROP CONSTRAINT [DF_ZTMSGInvoiceReturnItemList_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceReturnItemList] DROP CONSTRAINT [DF_ZTMSGInvoiceReturnItemList_ID]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceItemList] DROP CONSTRAINT [DF_ZTMSGInvoiceItemList_CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceItemList] DROP CONSTRAINT [DF_ZTMSGInvoiceItemList_ID]
GO
ALTER TABLE [dbo].[ZTMSFirmaBarkod] DROP CONSTRAINT [DF_ZTMSFirmaBarkod_ID]
GO
/****** Object:  Table [dbo].[ZTMSGYetki]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGYetki]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGYetki]
GO
/****** Object:  Table [dbo].[ZTMSGUserLogin]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUserLogin]
GO
/****** Object:  Table [dbo].[ZTMSGUrunResimList]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUrunResimList]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUrunResimList]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo3]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUrunListMisigo3]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUrunListMisigo3]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo2]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUrunListMisigo2]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUrunListMisigo2]
GO
/****** Object:  Table [dbo].[ZTMSGUrunlerQR]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUrunlerQR]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUrunlerQR]
GO
/****** Object:  Table [dbo].[ZTMSGTrendyolSiparisYD]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTrendyolSiparisYD]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTrendyolSiparisYD]
GO
/****** Object:  Table [dbo].[ZTMSGTrendyolSiparis]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTrendyolSiparis]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTrendyolSiparis]
GO
/****** Object:  Table [dbo].[ZTMSGTicXmlUrl2]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicXmlUrl2]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicXmlUrl2]
GO
/****** Object:  Table [dbo].[ZTMSGTicXmlUrl]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicXmlUrl]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicXmlUrl]
GO
/****** Object:  Table [dbo].[ZTMSGTicUyeAdres]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUyeAdres]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUyeAdres]
GO
/****** Object:  Table [dbo].[ZTMSGTicUye]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUye]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUye]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunVariant]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUrunVariant]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUrunVariant]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunler]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUrunler]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUrunler]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunKartiAcma]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUrunKartiAcma]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUrunKartiAcma]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunAcmaParametreleri]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicUrunAcmaParametreleri]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicUrunAcmaParametreleri]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisListDetay]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicSiparisListDetay]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicSiparisListDetay]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisList]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicSiparisList]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicSiparisList]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicSiparisKontrol]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicSiparisKontrol]
GO
/****** Object:  Table [dbo].[ZTMSGTicSecenekler]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicSecenekler]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicSecenekler]
GO
/****** Object:  Table [dbo].[ZTMSGTicResimlerYedek]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicResimlerYedek]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicResimlerYedek]
GO
/****** Object:  Table [dbo].[ZTMSGTicResimler]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicResimler]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicResimler]
GO
/****** Object:  Table [dbo].[ZTMSGTicOzellikler]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicOzellikler]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicOzellikler]
GO
/****** Object:  Table [dbo].[ZTMSGTicOtomatik]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicOtomatik]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicOtomatik]
GO
/****** Object:  Table [dbo].[ZTMSGTicOdemeKodlari]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicOdemeKodlari]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicOdemeKodlari]
GO
/****** Object:  Table [dbo].[ZTMSGTicLog]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicLog]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicLog]
GO
/****** Object:  Table [dbo].[ZTMSGTicKategoriler]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicKategoriler]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicKategoriler]
GO
/****** Object:  Table [dbo].[ZTMSGTicKargo]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGTicKargo]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGTicKargo]
GO
/****** Object:  Table [dbo].[ZTMSGStore]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGStore]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGStore]
GO
/****** Object:  Table [dbo].[ZTMSGSettings]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGSettings]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGSettings]
GO
/****** Object:  Table [dbo].[ZTMSGRAFSTOK]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGRAFSTOK]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGRAFSTOK]
GO
/****** Object:  Table [dbo].[ZTMSGRafSayimOffline]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGRafSayimOffline]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGRafSayimOffline]
GO
/****** Object:  Table [dbo].[ZTMSGRAFHAREKETLER]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGRAFHAREKETLER]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGRAFHAREKETLER]
GO
/****** Object:  Table [dbo].[ZTMSGRAF]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGRAF]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGRAF]
GO
/****** Object:  Table [dbo].[ZTMSGNebimSiparisAktarma]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGNebimSiparisAktarma]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGNebimSiparisAktarma]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoUrunAcmaParametreleri2]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGMisigoUrunAcmaParametreleri2]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri2]
GO
/****** Object:  Table [dbo].[ZTMSGMarka]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGMarka]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGMarka]
GO
/****** Object:  Table [dbo].[ZTMSGKategoriListMisigo]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGKategoriListMisigo]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGKategoriListMisigo]
GO
/****** Object:  Table [dbo].[ZTMSGInvoiceReturnItemList]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGInvoiceReturnItemList]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGInvoiceReturnItemList]
GO
/****** Object:  Table [dbo].[ZTMSGInvoiceItemList]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGInvoiceItemList]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGInvoiceItemList]
GO
/****** Object:  Table [dbo].[ZTMSGFirmaList]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGFirmaList]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGFirmaList]
GO
/****** Object:  Table [dbo].[ZTMSFirmaBarkod]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSFirmaBarkod]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSFirmaBarkod]
GO
/****** Object:  View [dbo].[MSGAllUrunLer]    Script Date: 21.02.2024 02:58:05 ******/
DROP VIEW [dbo].[MSGAllUrunLer]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_StokSiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_StokSiparisKontrol]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolSite]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_SiparisKontrolSite]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolPazaryeri]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_SiparisKontrolPazaryeri]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolOdeme]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_SiparisKontrolOdeme]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolCount]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_SiparisKontrolCount]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_SiparisKontrol]
GO
/****** Object:  Table [dbo].[ZTMSGKargoTakipKontrol]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGKargoTakipKontrol]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGKargoTakipKontrol]
GO
/****** Object:  Table [dbo].[ZTMSGKargoTakip]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGKargoTakip]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGKargoTakip]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_MisigoKategoriListFN]    Script Date: 21.02.2024 02:58:05 ******/
DROP FUNCTION [dbo].[MSG_MisigoKategoriListFN]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoUrunAcmaParametreleri]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGMisigoUrunAcmaParametreleri]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoOzellikEslestir]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGMisigoOzellikEslestir]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGMisigoOzellikEslestir]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo]    Script Date: 21.02.2024 02:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZTMSGUrunListMisigo]') AND type in (N'U'))
DROP TABLE [dbo].[ZTMSGUrunListMisigo]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUrunListMisigo](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemCode] [nvarchar](500) NULL,
	[Itemdescription] [nvarchar](500) NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Color] [nvarchar](200) NULL,
	[ItemDim1Code] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NOT NULL,
	[Envanter] [int] NULL,
	[MisigoWebSatis] [money] NULL,
	[MisigoWebIndirimliSatis] [money] NULL,
	[MisigoPazaryeriSatis] [money] NULL,
	[MisigoPazaryeriIndirimliSatis] [money] NULL,
	[ProductHierarchyLevel01] [nvarchar](100) NULL,
	[ProductHierarchyLevel02] [nvarchar](100) NULL,
	[ProductHierarchyLevel03] [nvarchar](100) NULL,
	[ProductHierarchyLevel04] [nvarchar](100) NULL,
	[ProductAtt01Type] [nvarchar](200) NULL,
	[ProductAtt01Desc] [nvarchar](200) NULL,
	[ProductAtt02Type] [nvarchar](200) NULL,
	[ProductAtt02Desc] [nvarchar](200) NULL,
	[ProductAtt03Type] [nvarchar](200) NULL,
	[ProductAtt03Desc] [nvarchar](200) NULL,
	[ProductAtt04Type] [nvarchar](200) NULL,
	[ProductAtt04Desc] [nvarchar](200) NULL,
	[ProductAtt05Type] [nvarchar](200) NULL,
	[ProductAtt05Desc] [nvarchar](200) NULL,
	[ProductAtt06Type] [nvarchar](200) NULL,
	[ProductAtt06Desc] [nvarchar](200) NULL,
	[ProductAtt07Type] [nvarchar](200) NULL,
	[ProductAtt07Desc] [nvarchar](200) NULL,
	[ProductAtt08Type] [nvarchar](200) NULL,
	[ProductAtt08Desc] [nvarchar](200) NULL,
	[ProductAtt09Type] [nvarchar](200) NULL,
	[ProductAtt09Desc] [nvarchar](200) NULL,
	[ProductAtt10Type] [nvarchar](200) NULL,
	[ProductAtt10Desc] [nvarchar](200) NULL,
	[ProductAtt11Type] [nvarchar](200) NULL,
	[ProductAtt11Desc] [nvarchar](200) NULL,
	[ProductAtt12Type] [nvarchar](200) NULL,
	[ProductAtt12Desc] [nvarchar](200) NULL,
	[ProductAtt13Type] [nvarchar](200) NULL,
	[ProductAtt13Desc] [nvarchar](200) NULL,
	[ProductAtt14Type] [nvarchar](200) NULL,
	[ProductAtt14Desc] [nvarchar](200) NULL,
	[ProductAtt15Type] [nvarchar](200) NULL,
	[ProductAtt15Desc] [nvarchar](200) NULL,
	[ProductAtt16Type] [nvarchar](200) NULL,
	[ProductAtt16Desc] [nvarchar](200) NULL,
	[ProductAtt17Type] [nvarchar](200) NULL,
	[ProductAtt17Desc] [nvarchar](200) NULL,
	[ProductAtt18Type] [nvarchar](200) NULL,
	[ProductAtt18Desc] [nvarchar](200) NULL,
	[ProductAtt19Type] [nvarchar](200) NULL,
	[ProductAtt19Desc] [nvarchar](200) NULL,
	[ProductAtt20Type] [nvarchar](200) NULL,
	[ProductAtt20Desc] [nvarchar](200) NULL,
 CONSTRAINT [PK_ZTMSGUrunListMisigo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoOzellikEslestir]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGMisigoOzellikEslestir](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Marka] [nvarchar](50) NULL,
	[FirmaAttributeTypeCode] [nvarchar](50) NULL,
	[NebimAttributeTypeCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGMisigoOzellikEslestir] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoUrunAcmaParametreleri]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DataBaseNebim] [nvarchar](50) NULL,
	[SirketKodu] [nvarchar](50) NULL,
	[IpAdres] [nvarchar](50) NULL,
	[FirmaKisaKod] [nvarchar](50) NULL,
	[Resim1] [nvarchar](500) NULL,
	[Resim2] [nvarchar](500) NULL,
	[Resim3] [nvarchar](500) NULL,
	[Resim4] [nvarchar](500) NULL,
	[Resim5] [nvarchar](500) NULL,
	[Cinsiyet] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGMisigoUrunAcmaParametreleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_MisigoKategoriListFN]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_MisigoKategoriListFN() where Attributecode != '' and ProductAttributeValue != '' and AttributeCode  != 'Marka' and AttributeCode != 'Tedarikçi'
CREATE FUNCTION [dbo].[MSG_MisigoKategoriListFN] () 
    RETURNS TABLE 
    AS RETURN
    (
        SELECT 
            p.DataBaseNebim,
            c.AttributeType as ProductAttributeType,
            c.AttributeDesc as ProductAttributeValue,
            AttributeCode = ISNULL(ZTMSGMisigoOzellikEslestir.NebimAttributeTypeCode, SPACE(0))
        FROM 
            (
                SELECT 
            DataBaseNebim,
            ProductAtt01Type,
			ProductAtt01Desc,
            ProductAtt02Type,
			ProductAtt02Desc,
            ProductAtt03Type,
			ProductAtt03Desc,
            ProductAtt04Type,
			ProductAtt04Desc,
            ProductAtt05Type,
			ProductAtt05Desc,
            ProductAtt06Type,
			ProductAtt06Desc,
            ProductAtt07Type,
			ProductAtt07Desc,
            ProductAtt08Type,
			ProductAtt08Desc,
            ProductAtt09Type,
			ProductAtt09Desc,
            ProductAtt10Type,
			ProductAtt10Desc,
            ProductAtt11Type,
			ProductAtt11Desc,
            ProductAtt12Type,
			ProductAtt12Desc,
            ProductAtt13Type,
			ProductAtt13Desc,
            ProductAtt14Type,
			ProductAtt14Desc,
            ProductAtt15Type,
			ProductAtt15Desc,
            ProductAtt16Type,
			ProductAtt16Desc,
            ProductAtt17Type,
			ProductAtt17Desc,
            ProductAtt18Type,
			ProductAtt18Desc,
            ProductAtt19Type,
			ProductAtt19Desc,
            ProductAtt20Type,
			ProductAtt20Desc
        FROM 
            ZTMSGUrunListMisigo
        LEFT OUTER JOIN ZTMSGMisigoUrunAcmaParametreleri 
            ON ZTMSGMisigoUrunAcmaParametreleri.SirketKodu = SUBSTRING(Itemcode, 0, 4)
            ) AS p
           CROSS APPLY
            (VALUES
                (ProductAtt01Type, ProductAtt01Desc),
                (ProductAtt02Type, ProductAtt02Desc),
				(ProductAtt03Type, ProductAtt03Desc),
				(ProductAtt04Type, ProductAtt04Desc),
				(ProductAtt05Type, ProductAtt05Desc),
				(ProductAtt06Type, ProductAtt06Desc),
				(ProductAtt07Type, ProductAtt07Desc),
				(ProductAtt08Type, ProductAtt08Desc),
				(ProductAtt09Type, ProductAtt09Desc),
				(ProductAtt10Type, ProductAtt10Desc),
				(ProductAtt11Type, ProductAtt11Desc),
                (ProductAtt12Type, ProductAtt12Desc),
				(ProductAtt13Type, ProductAtt13Desc),
				(ProductAtt14Type, ProductAtt14Desc),
				(ProductAtt15Type, ProductAtt15Desc),
				(ProductAtt16Type, ProductAtt16Desc),
				(ProductAtt17Type, ProductAtt17Desc),
				(ProductAtt18Type, ProductAtt18Desc),
				(ProductAtt19Type, ProductAtt19Desc),
				(ProductAtt20Type, ProductAtt20Desc)

            ) AS c(AttributeType, AttributeDesc)
        LEFT OUTER JOIN ZTMSGMisigoOzellikEslestir 
            ON ZTMSGMisigoOzellikEslestir.Marka = p.DataBaseNebim
            AND ZTMSGMisigoOzellikEslestir.FirmaAttributeTypeCode = c.AttributeType
        GROUP BY p.DataBaseNebim, c.AttributeType, c.AttributeDesc, ZTMSGMisigoOzellikEslestir.NebimAttributeTypeCode
    )
GO
/****** Object:  Table [dbo].[ZTMSGKargoTakip]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGKargoTakip](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[KargoNo] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGKargoTakip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGKargoTakipKontrol]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGKargoTakipKontrol](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[KargoNo] [nvarchar](500) NULL,
	[PazaryeriBarkod] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGKargoTakipKontrol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_SiparisKontrol()
		CREATE FUNCTION [dbo].[MSG_SiparisKontrol] () 
		RETURNS TABLE 
		
		AS RETURN
		(
		SELECT * FROM (
select OrderDate
,[Site Sipariş No]=DocumentNumber
,Pazaryeri= SalesURL
,Site = Case When DocumentNumber like 'ASR-%' THEN
'ASSUR PLUS'
Else 
Case When DocumentNumber like 'B2B-%' THEN
'B2BASSUR'
Else
Case When DocumentNumber like 'DEW-%' THEN
'DEWPRO'
Else
'' END END END
,DURUMU= Case When b.KargoNo is not null or d.KargoNo is not null THEN 
'KARGOLANDI'
Else Case WHEN a.KargoNo is not null or c.KargoNo is not null
THEN 
'PAKETLENDİ'
Else 
'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI'
end end  
,[Sipariş No]=Description
,[Kargo Barkod]=InternalDescription
,[Müşteri Adı]=CurrAccDescription
,[Ürün Kodu]=AllOrders.Itemcode
,[Ürün Adı]=ItemDescription
,Miktar=SUM(Qty1)
,Tutar=SUM(Loc_NetAmount)
from AllOrders
Left Outer Join cdItemDesc on cdItemDesc.ItemCode = AllOrders.ItemCode
and cdItemDesc.LangCode = 'TR'
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join tpOrdersViaInternetInfo on tpOrdersViaInternetInfo.OrderHeaderID = AllOrders.OrderHeaderID
Left Outer Join (select KargoNo from ZTMSGKargoTakip
Group by KargoNo) as a on a.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo from ZTMSGKargoTakip
Group by KargoNo) as c on c.KargoNo = AllOrders.Description
Left Outer Join (select KargoNo from ZTMSGKargoTakipKontrol
Group by KargoNo) as b on b.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo from ZTMSGKargoTakipKontrol
Group by KargoNo) as d on d.KargoNo = AllOrders.Description
where AllOrders.CreatedDate >= GETDATE()-10
GROUP BY  OrderNumber,OrderDate,DocumentNumber, SalesURL
,Description,AllOrders.ITemcode,InternalDescription,AllOrders.CurrAccCode,CurrAccDescription
,b.KargoNo,a.KargoNo,d.KargoNo,c.KargoNo,cdItemDesc.ItemDescription
) AS A 
WHERE A.Site != ''
and [Sipariş No] not in (select Description from trInvoiceHeader where IsReturn = 1)


		)


		
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_SiparisKontrolCount()
		CREATE FUNCTION [dbo].[MSG_SiparisKontrolCount] () 
		RETURNS TABLE 
		
		AS RETURN
		(
		select
		CreatedDate=ISNULL((CreatedDate),SPACE(0)),
OrderDate
,DURUMU
,[Ürün Kodu]
,Miktar=SUM(Miktar)
,Tutar=SUM(Tutar)

from (
SELECT 

*

FROM (
select 
CreatedDate=Case When  a.KargoNo is not null THEN 
a.CreatedDate

Else 
c.CreatedDate
end 
,OrderDate


,DURUMU= Case When b.KargoNo is not null or d.KargoNo is not null THEN 
'KARGOLANDI'
Else Case WHEN a.KargoNo is not null or c.KargoNo is not null
THEN 
'PAKETLENDİ'
Else 
'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI'
end end  
,[Sipariş No]=Description
,[Ürün Kodu]=prItemAttribute.AttributeCode
,[Ürün Adı]=ItemDescription
,Miktar=SUM(Qty1)
,Tutar=SUM(Loc_NetAmount)
from AllOrders
Left Outer Join prItemAttribute on prItemAttribute.ItemCode = AllOrders.ItemCode
and prItemAttribute.AttributeTypeCode = 2
Left Outer Join cdItemDesc on cdItemDesc.ItemCode = AllOrders.ItemCode
and cdItemDesc.LangCode = 'TR'
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join (select KargoNo,CreatedDate=Convert(Date,CreatedDate,102) from ZTMSGKargoTakip
Group by KargoNo,CreatedDate) as a on a.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo,CreatedDate=Convert(Date,CreatedDate,102) from ZTMSGKargoTakip
Group by KargoNo,CreatedDate) as c on c.KargoNo = AllOrders.Description
Left Outer Join (select KargoNo,CreatedDate=Convert(Date,CreatedDate,102) from ZTMSGKargoTakipKontrol
Group by KargoNo,CreatedDate) as b on b.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo,CreatedDate=Convert(Date,CreatedDate,102) from ZTMSGKargoTakipKontrol
Group by KargoNo,CreatedDate) as d on d.KargoNo = AllOrders.Description
where AllOrders.CreatedDate >= GETDATE()-10
GROUP BY  OrderDate
,prItemAttribute.AttributeCode
,b.KargoNo,a.KargoNo,d.KargoNo,c.KargoNo,cdItemDesc.ItemDescription,AllOrders.Description,a.CreatedDate,c.CreatedDate
) AS A 
WHERE  [Sipariş No] not in (select Description from trInvoiceHeader where IsReturn = 1)
and a.[Ürün Kodu] not in ('001')
) as a
--where a.[Ürün Kodu] = 'ASR026'
Group by OrderDate
,DURUMU
,[Ürün Kodu]
,a.CreatedDate
		)


		
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolOdeme]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_SiparisKontrol()
		CREATE FUNCTION [dbo].[MSG_SiparisKontrolOdeme] ()
		RETURNS TABLE 
		
		AS RETURN
		(
	
		SELECT OrderDate,OdemeTipi=CreditCardTypeDescription,Site,DURUMU,Miktar=SUM(Miktar),Tutar=SUM(Tutar) FROM (
select OrderDate,cdCreditCardTypeDesc.CreditCardTypeDescription,Site = Case When AllOrders.DocumentNumber like 'ASR-%' THEN
'ASSUR PLUS'
Else 
Case When AllOrders.DocumentNumber like 'B2B-%' THEN
'B2BASSUR'
Else
Case When AllOrders.DocumentNumber like 'DEW-%' THEN
'DEWPRO'
Else
'' END END END
,DURUMU= Case When b.KargoNo is not null  THEN 
'KARGOLANDI'
Else Case WHEN a.KargoNo is not null 
THEN 
'PAKETLENDİ'
Else 
'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI'
end end  
,Miktar=SUM(Qty1),Tutar=SUM(Loc_NetAmount) from AllOrders
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join tpOrdersViaInternetInfo on tpOrdersViaInternetInfo.OrderHeaderID = AllOrders.OrderHeaderID
Left Outer Join trCreditCardPaymentHeader on trCreditCardPaymentHeader.RefNumber = AllOrders.OrderNumber
Left Outer Join trCreditCardPaymentLine on trCreditCardPaymentLine.CreditCardPaymentHeaderID = trCreditCardPaymentHeader.CreditCardPaymentHeaderID
Left Outer Join cdCreditCardTypeDesc on cdCreditCardTypeDesc.CreditCardTypeCode = trCreditCardPaymentLine.CreditCardTypeCode
and cdCreditCardTypeDesc.LangCode = 'TR'
Left Outer Join (select KargoNo from ZTMSGKargoTakip
Group by KargoNo) as a on a.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo from ZTMSGKargoTakipKontrol
Group by KargoNo) as b on b.KargoNo = AllOrders.InternalDescription
where AllOrders.CreatedDate >= GETDATE()-10
GROUP BY  OrderDate,AllOrders.DocumentNumber, SalesURL,cdCreditCardTypeDesc.CreditCardTypeDescription
,b.KargoNo,a.KargoNo
) AS A 
WHERE A.Site != ''
Group by OrderDate,CreditCardTypeDescription,Site,DURUMU


		)
	



GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolPazaryeri]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_SiparisKontrol()
		CREATE FUNCTION [dbo].[MSG_SiparisKontrolPazaryeri] ()
		RETURNS TABLE 
		
		AS RETURN
		(
	
		SELECT OrderDate,Pazaryeri,Miktar=SUM(Miktar),Tutar=SUM(Tutar) FROM (
select OrderDate,Pazaryeri= SalesURL
,Miktar=SUM(Qty1),Tutar=SUM(Loc_NetAmount) from AllOrders
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join tpOrdersViaInternetInfo on tpOrdersViaInternetInfo.OrderHeaderID = AllOrders.OrderHeaderID
Left Outer Join (select KargoNo from ZTMSGKargoTakip
Group by KargoNo) as a on a.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo from ZTMSGKargoTakipKontrol
Group by KargoNo) as b on b.KargoNo = AllOrders.InternalDescription
where AllOrders.CreatedDate >= GETDATE()-10
GROUP BY OrderDate,SalesURL
,b.KargoNo,a.KargoNo
) AS A 
WHERE A.Pazaryeri != ''
Group by OrderDate,Pazaryeri


		)
	
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_SiparisKontrolSite]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_SiparisKontrol()
		CREATE FUNCTION [dbo].[MSG_SiparisKontrolSite] ()
		RETURNS TABLE 
		
		AS RETURN
		(
		SELECT OrderDate,Site,Miktar=SUM(Miktar),Tutar=SUM(Tutar) FROM (
select OrderDate,Site = Case When DocumentNumber like 'ASR-%' THEN
'ASSUR PLUS'
Else 
Case When DocumentNumber like 'B2B-%' THEN
'B2BASSUR'
Else
Case When DocumentNumber like 'DEW-%' THEN
'DEWPRO'
Else
'' END END END
 
,Miktar=SUM(Qty1),Tutar=SUM(Loc_NetAmount) from AllOrders
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join tpOrdersViaInternetInfo on tpOrdersViaInternetInfo.OrderHeaderID = AllOrders.OrderHeaderID
Left Outer Join (select KargoNo from ZTMSGKargoTakip
Group by KargoNo) as a on a.KargoNo = AllOrders.InternalDescription
Left Outer Join (select KargoNo from ZTMSGKargoTakipKontrol
Group by KargoNo) as b on b.KargoNo = AllOrders.InternalDescription
where AllOrders.CreatedDate >= GETDATE()-10
GROUP BY OrderDate,DocumentNumber
,b.KargoNo,a.KargoNo
) AS A 
WHERE A.Site != ''
Group by OrderDate,Site


		)
	
GO
/****** Object:  UserDefinedFunction [dbo].[MSG_StokSiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from MSG_StokSiparisKontrol('ASR818',GETDATE()-1)
		CREATE FUNCTION [dbo].[MSG_StokSiparisKontrol] (
		@AttributeCode nvarchar(50),
		@Tarih datetime
		) 
		RETURNS TABLE 
		
		AS RETURN
		(select AttributeCode,SiparisMiktari= ISNULL((SUM(Miktar)),0)
		,Kargolanan =ISNULL((Miktar2),0) from (
select AllORders.CreatedDate,prItemAttribute.AttributeCode,Miktar=Case When stOrder.OrderlineID is null Then 0 else SUM(AllOrders.Qty1-CancelQty1) end   from AllOrders
Left Outer Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
Left Outer Join prItemAttribute on prItemAttribute.AttributeTypeCode = 2 
and prItemAttribute.ItemCode = AllOrders.ItemCode
where prItemAttribute.AttributeCode is not null
Group by prItemAttribute.AttributeCode,AllOrders.CreatedDate,stOrder.OrderlineID ) as a
Left Outer Join (select StokKodu,Miktar2=SUM(Miktar2) from (
select StokKodu = prItemAttribute.AttributeCode 
	,Miktar2= SUM(AllOrders.Qty1-AllOrders.CancelQty1)
	from ZTMSgKargoTakip
	Inner Join AllOrders on AllOrders.InternalDescription = ZTMSgKargoTakip.KargoNo
	
	Left Outer Join prItemAttribute on prItemAttribute.AttributeTypeCode = 2 
and prItemAttribute.ItemCode = AllOrders.ItemCode

where AllOrders.CreatedDate >=@Tarih
and prItemAttribute.AttributeCode = @AttributeCode
Group by prItemAttribute.AttributeCode
UNION ALL


select StokKodu = prItemAttribute.AttributeCode 
	,Miktar2= SUM(AllOrders.Qty1-AllOrders.CancelQty1)
	from ZTMSgKargoTakip
	Inner Join AllOrders on AllOrders.Description = ZTMSgKargoTakip.KargoNo
	
	Left Outer Join prItemAttribute on prItemAttribute.AttributeTypeCode = 2 
and prItemAttribute.ItemCode = AllOrders.ItemCode

where AllOrders.CreatedDate >=@Tarih
and prItemAttribute.AttributeCode = @AttributeCode
Group by prItemAttribute.AttributeCode) as a
Group by StokKodu
) as b 
on b.StokKodu = a.AttributeCode
where CreatedDate >=@Tarih
and a.AttributeCode = @AttributeCode
Group by AttributeCode,B.Miktar2


		)


GO
/****** Object:  View [dbo].[MSGAllUrunLer]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[MSGAllUrunLer]

AS

select Colorcode,ColorDescription,Itemdim1code='',ProductHierarchyID='',ProductHierarchyLevel01='',ProductHierarchyLevel02='',ProductHierarchyLevel03='',ProductHierarchyLevel04='',ProductHierarchyLevel05='' from cdColorDesc where Langcode = 'TR'
UNION ALL
select Colorcode='',ColorDescription='',Itemdim1code,ProductHierarchyID='',ProductHierarchyLevel01='',ProductHierarchyLevel02='',ProductHierarchyLevel03='',ProductHierarchyLevel04='',ProductHierarchyLevel05='' from cdItemDim1
UNION ALL
select Colorcode='',ColorDescription='',Itemdim1code='',ProductHierarchyID,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,ProductHierarchyLevel05 from ProductHierarchy('TR')

GO
/****** Object:  Table [dbo].[ZTMSFirmaBarkod]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSFirmaBarkod](
	[Barcode] [nvarchar](50) NULL,
	[FirmaBarcode] [nvarchar](50) NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSFirmaBarkod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGFirmaList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGFirmaList](
	[ID] [uniqueidentifier] NOT NULL,
	[Firma] [nvarchar](50) NULL,
	[Url] [nvarchar](500) NULL,
 CONSTRAINT [PK_ZTMSGFirmaList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGInvoiceItemList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGInvoiceItemList](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[OrderNumber] [nvarchar](50) NULL,
	[CurrAccCode] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NULL,
	[Qty1] [int] NULL,
	[IsComplate] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ZTMSGInvoiceItemList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGInvoiceReturnItemList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGInvoiceReturnItemList](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[OrderNumber] [nvarchar](50) NULL,
	[CurrAccCode] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NULL,
	[Qty1] [int] NULL,
	[IsComplate] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReturnReasonCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGInvoiceReturnItemList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGKategoriListMisigo]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGKategoriListMisigo](
	[ProductHierarchyID] [int] NOT NULL,
	[ProductHierarchyLevel01] [nvarchar](100) NULL,
	[ProductHierarchyLevel02] [nvarchar](100) NULL,
	[ProductHierarchyLevel03] [nvarchar](100) NULL,
	[ProductHierarchyLevel04] [nvarchar](100) NULL,
	[Marka] [nvarchar](100) NULL,
	[ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGMarka]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGMarka](
	[AttributeCode] [nvarchar](50) NULL,
	[Description] [varchar](1) NOT NULL,
	[ProducthierarchyFilter] [varchar](1) NOT NULL,
	[Isblocked] [int] NOT NULL,
	[DataBaseNebim] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGMisigoUrunAcmaParametreleri2]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri2](
	[ID] [uniqueidentifier] NOT NULL,
	[DataBaseNebim] [nvarchar](50) NULL,
	[SirketKodu] [nvarchar](50) NULL,
	[IpAdres] [nvarchar](50) NULL,
	[FirmaKisaKod] [nvarchar](50) NULL,
	[Resim1] [nvarchar](500) NULL,
	[Resim2] [nvarchar](500) NULL,
	[Resim3] [nvarchar](500) NULL,
	[Resim4] [nvarchar](500) NULL,
	[Resim5] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGNebimSiparisAktarma]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGNebimSiparisAktarma](
	[Kodu] [nvarchar](50) NULL,
	[Adı] [nvarchar](50) NULL,
	[Soyadı] [nvarchar](50) NULL,
	[Unvanı] [nvarchar](50) NULL,
	[Ofis] [nvarchar](50) NULL,
	[TcKimlik] [nvarchar](50) NULL,
	[VergiKimlikNo] [nvarchar](50) NULL,
	[VergiDairesi] [nvarchar](50) NULL,
	[Telefon] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Adres] [nvarchar](1000) NULL,
	[İl] [nvarchar](50) NULL,
	[İlçe] [nvarchar](50) NULL,
	[ParaBirimi] [nvarchar](50) NULL,
	[Kargo] [nvarchar](50) NULL,
	[KargoKodu] [nvarchar](50) NULL,
	[OrderDate] [date] NULL,
	[Ordernumber] [nvarchar](50) NULL,
	[Aciklama] [nvarchar](50) NULL,
	[DahiliAciklama] [nvarchar](50) NULL,
	[Barkod] [nvarchar](50) NULL,
	[UrunKodu] [nvarchar](50) NULL,
	[Renk] [nvarchar](50) NULL,
	[Beden] [nvarchar](50) NULL,
	[Miktar] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Tutar] [decimal](18, 2) NULL,
	[Aktarildimi] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGRAF]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGRAF](
	[Warehouse] [nvarchar](50) NULL,
	[ShelfNo] [nvarchar](50) NULL,
	[RowNumber] [nvarchar](50) NULL,
	[Konum] [nvarchar](50) NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSGRAF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGRAFHAREKETLER]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGRAFHAREKETLER](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ShelfNo] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[BatchCode] [nvarchar](50) NULL,
	[ItemDate] [datetime] NOT NULL,
	[OrderNumber] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[WareHouseCode] [nvarchar](50) NULL,
	[ToWareHouseCode] [nvarchar](50) NULL,
	[CurrAccCode] [nvarchar](50) NULL,
	[Itemcode] [nvarchar](50) NULL,
	[IsReturn] [bit] NULL,
	[SalesPersonCode] [nvarchar](50) NULL,
	[TaxTypeCode] [nvarchar](50) NULL,
	[LineId] [nvarchar](500) NULL,
	[InvoiceNumber] [nvarchar](50) NULL,
	[LineDescription] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGRAFHAREKETLER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGRafSayimOffline]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGRafSayimOffline](
	[ShelfNo] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[SayimID] [uniqueidentifier] NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSRAFSAYIMOFFLINE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGRAFSTOK]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGRAFSTOK](
	[Depo] [nvarchar](50) NOT NULL,
	[RafNo] [nvarchar](50) NOT NULL,
	[Itemcode] [nvarchar](50) NOT NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Itemdim1Code] [nvarchar](50) NULL,
	[Parti] [nvarchar](50) NULL,
	[Envanter] [int] NULL,
	[Marka] [nvarchar](100) NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSGRAFSTOK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGSettings]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGSettings](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Entegrator] [nvarchar](100) NULL,
	[SiteAdi] [nvarchar](50) NULL,
	[WsYetki] [nvarchar](500) NULL,
	[DEUser] [nvarchar](50) NULL,
	[DESifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGSettings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGStore]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGStore](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[StoreCode] [nvarchar](50) NULL,
	[Store] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGStore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicKargo]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicKargo](
	[SiparisNo] [nvarchar](50) NULL,
	[KargoDurum] [nvarchar](50) NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSGTicKargo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicKategoriler]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicKategoriler](
	[KategoriID] [int] NOT NULL,
	[ParentID] [int] NULL,
	[Tanim] [nvarchar](255) NULL,
	[Marka] [nvarchar](50) NULL,
	[NebimKategoriID] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ZTMSGTicKategoriler_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicLog]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Gorev] [nvarchar](150) NULL,
	[Mesaj] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ZTMSGTicLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicOdemeKodlari]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicOdemeKodlari](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OdemeTipi] [int] NULL,
	[OdemeTipiTanim] [nvarchar](100) NULL,
	[BankaId] [int] NULL,
	[BankaTanim] [nvarchar](100) NULL,
	[SiparisKaynagi] [nvarchar](100) NULL,
	[NebimOdemeTipi] [int] NULL,
	[NebimOdemeTipiTanim] [nvarchar](100) NULL,
	[NebimOdemeKodu] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [nvarchar](150) NULL,
 CONSTRAINT [PK_ZTMSGTicOdemeKodlari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicOtomatik]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicOtomatik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GorevAdi] [nvarchar](150) NULL,
	[YenilemeSuresi] [int] NULL,
	[Durumu] [nvarchar](50) NULL,
	[BaslangicZamani] [datetime] NULL,
	[BitisZamani] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_ZTMSGTicOtomatik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicOzellikler]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicOzellikler](
	[OzellikID] [int] IDENTITY(1,1) NOT NULL,
	[Tanim] [nvarchar](255) NULL,
	[Deger] [nvarchar](255) NULL,
	[VaryasyonID] [int] NULL,
	[Marka] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicResimler]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicResimler](
	[UrunKartiID] [int] NOT NULL,
	[VaryasyonID] [int] NOT NULL,
	[ResimAdresi] [nvarchar](1024) NULL,
	[IndirmeDurumu] [nvarchar](255) NULL,
	[Marka] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicResimlerYedek]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicResimlerYedek](
	[ID] [int] NOT NULL,
	[barcode] [nvarchar](255) NULL,
	[url] [nvarchar](1024) NULL,
	[IndirmeDurumu] [nvarchar](255) NULL,
	[Marka] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicSecenekler]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicSecenekler](
	[VaryasyonID] [int] NOT NULL,
	[StokKodu] [nvarchar](255) NULL,
	[Barkod] [nvarchar](255) NULL,
	[StokAdedi] [int] NULL,
	[AlisFiyati] [decimal](18, 2) NULL,
	[SatisFiyati] [decimal](18, 2) NULL,
	[IndirimliFiyat] [decimal](18, 2) NULL,
	[KDVDahil] [bit] NULL,
	[KdvOrani] [int] NULL,
	[ParaBirimi] [nvarchar](255) NULL,
	[Desi] [int] NULL,
	[UrunKartiID] [int] NULL,
	[Marka] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisKontrol]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicSiparisKontrol](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[FaturaNo] [nvarchar](50) NULL,
	[Request] [nvarchar](max) NULL,
	[Cevap] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ZTMSGTicSiparisKontrol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicSiparisList](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[AdiSoyadi] [nvarchar](150) NULL,
	[SiparisID] [int] NULL,
	[MarketPlaceKampanyaKodu] [nvarchar](50) NULL,
	[SiparisNo] [nvarchar](50) NULL,
	[SiparisTarihi] [date] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ZTMSGTicSiparisList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicSiparisListDetay]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicSiparisListDetay](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SiparisID] [int] NULL,
	[SiparisDetayID] [int] NULL,
	[Barkod] [nvarchar](50) NULL,
	[Adet] [int] NULL,
	[MagazaKodu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGTicSiparisListDetay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunAcmaParametreleri]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUrunAcmaParametreleri](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DataBaseNebim] [nvarchar](50) NULL,
	[SirketKodu] [nvarchar](50) NULL,
	[ResimYolu] [nvarchar](500) NULL,
	[IpAdres] [nvarchar](50) NULL,
	[FirmaKisaKod] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGTicUrunAcmaParametreleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunKartiAcma]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUrunKartiAcma](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[AnaUrunKodu] [nvarchar](50) NULL,
	[NebimUrunKodu] [nvarchar](50) NULL,
	[NebimUrunAdi] [nvarchar](200) NULL,
	[Variant] [int] NULL,
	[UrunHiyerarsi] [int] NULL,
	[MaddeVergiGrubu] [nvarchar](50) NULL,
	[MaddeHesapGrubu] [nvarchar](50) NULL,
	[MagazadaSatisaAcik] [bit] NULL,
	[MagazadaKullanimaAcik] [bit] NULL,
	[InternetteSatisaAcik] [bit] NULL,
 CONSTRAINT [PK_ZtTicUrunKartiAcma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunler]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUrunler](
	[UrunKartiID] [int] NOT NULL,
	[UrunAdi] [nvarchar](255) NULL,
	[OnYazi] [nvarchar](max) NULL,
	[Aciklama] [nvarchar](max) NULL,
	[MarkaID] [int] NULL,
	[KategoriID] [int] NULL,
	[SatisBirimi] [nvarchar](255) NULL,
	[UrunUrl] [nvarchar](1024) NULL,
	[OzelAlan1] [nvarchar](500) NULL,
	[OzelAlan2] [nvarchar](500) NULL,
	[OzelAlan3] [nvarchar](500) NULL,
	[OzelAlan4] [nvarchar](500) NULL,
	[OzelAlan5] [nvarchar](500) NULL,
	[Marka] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUrunVariant]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUrunVariant](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Itemcode] [nvarchar](50) NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Colordescription] [nvarchar](50) NULL,
	[Itemdim1code] [nvarchar](50) NULL,
	[Barcode] [nvarchar](50) NULL,
	[SirketKodu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGTicUrunVariant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUye]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUye](
	[IDField] [int] NOT NULL,
	[CepTelefonuField] [nvarchar](50) NULL,
	[CinsiyetIDField] [int] NULL,
	[DogumTarihiField] [datetime] NULL,
	[DuzenlemeTarihiField] [datetime] NULL,
	[IlField] [nvarchar](100) NULL,
	[IlIDField] [int] NULL,
	[IlceField] [nvarchar](100) NULL,
	[IlceIDField] [int] NULL,
	[IsimField] [nvarchar](100) NULL,
	[KrediLimitiField] [float] NULL,
	[MailField] [nvarchar](255) NULL,
	[MailIzinField] [bit] NULL,
	[MeslekField] [nvarchar](150) NULL,
	[MusteriKoduField] [nvarchar](100) NULL,
	[OgrenimDurumuField] [nvarchar](150) NULL,
	[ParaPuanField] [int] NULL,
	[SifreField] [nvarchar](255) NULL,
	[SmsIzinField] [bit] NULL,
	[SonGirisTarihiField] [datetime] NULL,
	[SoyisimField] [nvarchar](100) NULL,
	[TelefonField] [nvarchar](50) NULL,
	[UyeTuruField] [nvarchar](100) NULL,
	[UyeTuruIDField] [int] NULL,
	[UyelikTarihiField] [datetime] NULL,
	[UyelikTipiField] [nvarchar](100) NULL,
	[UyelikTipiIDField] [int] NULL,
 CONSTRAINT [PK_ZTMSGTicUye] PRIMARY KEY CLUSTERED 
(
	[IDField] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicUyeAdres]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicUyeAdres](
	[IDField] [int] NOT NULL,
	[AdresField] [nvarchar](max) NULL,
	[AdresTarifiField] [nvarchar](max) NULL,
	[AktifField] [bit] NULL,
	[AliciAdiField] [nvarchar](255) NULL,
	[AliciTelefonField] [nvarchar](50) NULL,
	[FirmaAdiField] [nvarchar](255) NULL,
	[IlceField] [nvarchar](100) NULL,
	[IsKurumsalField] [bit] NULL,
	[PostaKoduField] [nvarchar](10) NULL,
	[SehirField] [nvarchar](100) NULL,
	[TanimField] [nvarchar](255) NULL,
	[UlkeField] [nvarchar](100) NULL,
	[UyeIdField] [int] NULL,
	[VergiDairesiField] [nvarchar](255) NULL,
	[VergiNoField] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDField] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicXmlUrl]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicXmlUrl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [nvarchar](50) NULL,
	[Tur] [nvarchar](50) NULL,
	[XML] [nvarchar](500) NULL,
	[KisaKod] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ZTMSGTicXmlUrl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTicXmlUrl2]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTicXmlUrl2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [nvarchar](50) NULL,
	[Tur] [nvarchar](50) NULL,
	[XML] [nvarchar](500) NULL,
	[KisaKod] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTrendyolSiparis]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTrendyolSiparis](
	[Barkod] [varchar](255) NULL,
	[PaketNo] [varchar](255) NULL,
	[KargoFirmasi] [varchar](255) NULL,
	[SiparisTarihi] [datetime] NULL,
	[TerminSuresininBittigiTarih] [datetime] NULL,
	[KargoyaTeslimTarihi] [datetime] NULL,
	[KargoKodu] [varchar](255) NULL,
	[SiparisNumarasi] [varchar](255) NULL,
	[Alici] [varchar](255) NULL,
	[TeslimatAdresi] [text] NULL,
	[UrunAdi] [text] NULL,
	[FaturaAdresi] [text] NULL,
	[AliciFaturaAdresi] [varchar](255) NULL,
	[SiparisStatusu] [varchar](255) NULL,
	[EPosta] [varchar](255) NULL,
	[KomisyonOrani] [float] NULL,
	[Marka] [varchar](255) NULL,
	[StokKodu] [varchar](255) NULL,
	[Adet] [int] NULL,
	[BirimFiyati] [float] NULL,
	[SatisTutari] [float] NULL,
	[IndirimTutari] [float] NULL,
	[TrendyolIndirimTutari] [float] NULL,
	[FaturalanacakTutar] [float] NULL,
	[ButikNumarasi] [int] NULL,
	[TeslimTarihi] [datetime] NULL,
	[KargodanAlinanDesi] [float] NULL,
	[HesapladigimDesi] [float] NULL,
	[FaturalananKargoTutari] [float] NULL,
	[AlternatifTeslimatStatusu] [varchar](255) NULL,
	[KurumsalFaturaliSiparis] [varchar](255) NULL,
	[VergiKimlikNumarasi] [varchar](255) NULL,
	[VergiDairesi] [varchar](255) NULL,
	[SirketIsmi] [varchar](255) NULL,
	[ArkadaslarinlaAlSiparisi] [varchar](255) NULL,
	[Fatura] [varchar](255) NULL,
	[MusteriSiparisAdedi] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGTrendyolSiparisYD]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGTrendyolSiparisYD](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TakipNo] [nvarchar](50) NULL,
	[ToptanSatisFiyati] [float] NULL,
	[Barkod] [nvarchar](50) NULL,
	[UrunAdi] [nvarchar](500) NULL,
	[Adet] [int] NULL,
	[MusteriKodu] [nvarchar](50) NULL,
	[CurrencyCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGTrendyolSiparisYD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGUrunlerQR]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUrunlerQR](
	[Barkod] [nvarchar](50) NULL,
	[Url] [nvarchar](500) NULL,
	[Aktarim] [bit] NULL,
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ZTMSGUrunlerQR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo2]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUrunListMisigo2](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemCode] [nvarchar](500) NULL,
	[Itemdescription] [nvarchar](500) NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Color] [nvarchar](200) NULL,
	[ItemDim1Code] [nvarchar](50) NULL,
	[Barcode] [nvarchar](20) NULL,
	[Envanter] [int] NULL,
	[MisigoWebSatis] [money] NULL,
	[MisigoWebIndirimliSatis] [money] NULL,
	[MisigoPazaryeriSatis] [money] NULL,
	[MisigoPazaryeriIndirimliSatis] [money] NULL,
	[ProductHierarchyLevel01] [nvarchar](100) NULL,
	[ProductHierarchyLevel02] [nvarchar](100) NULL,
	[ProductHierarchyLevel03] [nvarchar](100) NULL,
	[ProductHierarchyLevel04] [nvarchar](100) NULL,
	[ProductAtt01Type] [nvarchar](200) NULL,
	[ProductAtt01Desc] [nvarchar](200) NULL,
	[ProductAtt02Type] [nvarchar](200) NULL,
	[ProductAtt02Desc] [nvarchar](200) NULL,
	[ProductAtt03Type] [nvarchar](200) NULL,
	[ProductAtt03Desc] [nvarchar](200) NULL,
	[ProductAtt04Type] [nvarchar](200) NULL,
	[ProductAtt04Desc] [nvarchar](200) NULL,
	[ProductAtt05Type] [nvarchar](200) NULL,
	[ProductAtt05Desc] [nvarchar](200) NULL,
	[ProductAtt06Type] [nvarchar](200) NULL,
	[ProductAtt06Desc] [nvarchar](200) NULL,
	[ProductAtt07Type] [nvarchar](200) NULL,
	[ProductAtt07Desc] [nvarchar](200) NULL,
	[ProductAtt08Type] [nvarchar](200) NULL,
	[ProductAtt08Desc] [nvarchar](200) NULL,
	[ProductAtt09Type] [nvarchar](200) NULL,
	[ProductAtt09Desc] [nvarchar](200) NULL,
	[ProductAtt10Type] [nvarchar](200) NULL,
	[ProductAtt10Desc] [nvarchar](200) NULL,
	[ProductAtt11Type] [nvarchar](200) NULL,
	[ProductAtt11Desc] [nvarchar](200) NULL,
	[ProductAtt12Type] [nvarchar](200) NULL,
	[ProductAtt12Desc] [nvarchar](200) NULL,
	[ProductAtt13Type] [nvarchar](200) NULL,
	[ProductAtt13Desc] [nvarchar](200) NULL,
	[ProductAtt14Type] [nvarchar](200) NULL,
	[ProductAtt14Desc] [nvarchar](200) NULL,
	[ProductAtt15Type] [nvarchar](200) NULL,
	[ProductAtt15Desc] [nvarchar](200) NULL,
	[ProductAtt16Type] [nvarchar](200) NULL,
	[ProductAtt16Desc] [nvarchar](200) NULL,
	[ProductAtt17Type] [nvarchar](200) NULL,
	[ProductAtt17Desc] [nvarchar](200) NULL,
	[ProductAtt18Type] [nvarchar](200) NULL,
	[ProductAtt18Desc] [nvarchar](200) NULL,
	[ProductAtt19Type] [nvarchar](200) NULL,
	[ProductAtt19Desc] [nvarchar](200) NULL,
	[ProductAtt20Type] [nvarchar](200) NULL,
	[ProductAtt20Desc] [nvarchar](200) NULL,
 CONSTRAINT [PK_ZTMSGUrunListMisigo2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGUrunListMisigo3]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUrunListMisigo3](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemCode] [nvarchar](500) NULL,
	[Itemdescription] [nvarchar](500) NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Color] [nvarchar](200) NULL,
	[ItemDim1Code] [nvarchar](50) NULL,
	[Barcode] [nvarchar](20) NULL,
	[Envanter] [int] NULL,
	[MisigoWebSatis] [money] NULL,
	[MisigoWebIndirimliSatis] [money] NULL,
	[MisigoPazaryeriSatis] [money] NULL,
	[MisigoPazaryeriIndirimliSatis] [money] NULL,
	[ProductHierarchyLevel01] [nvarchar](100) NULL,
	[ProductHierarchyLevel02] [nvarchar](100) NULL,
	[ProductHierarchyLevel03] [nvarchar](100) NULL,
	[ProductHierarchyLevel04] [nvarchar](100) NULL,
	[ProductAtt01Type] [nvarchar](200) NULL,
	[ProductAtt01Desc] [nvarchar](200) NULL,
	[ProductAtt02Type] [nvarchar](200) NULL,
	[ProductAtt02Desc] [nvarchar](200) NULL,
	[ProductAtt03Type] [nvarchar](200) NULL,
	[ProductAtt03Desc] [nvarchar](200) NULL,
	[ProductAtt04Type] [nvarchar](200) NULL,
	[ProductAtt04Desc] [nvarchar](200) NULL,
	[ProductAtt05Type] [nvarchar](200) NULL,
	[ProductAtt05Desc] [nvarchar](200) NULL,
	[ProductAtt06Type] [nvarchar](200) NULL,
	[ProductAtt06Desc] [nvarchar](200) NULL,
	[ProductAtt07Type] [nvarchar](200) NULL,
	[ProductAtt07Desc] [nvarchar](200) NULL,
	[ProductAtt08Type] [nvarchar](200) NULL,
	[ProductAtt08Desc] [nvarchar](200) NULL,
	[ProductAtt09Type] [nvarchar](200) NULL,
	[ProductAtt09Desc] [nvarchar](200) NULL,
	[ProductAtt10Type] [nvarchar](200) NULL,
	[ProductAtt10Desc] [nvarchar](200) NULL,
	[ProductAtt11Type] [nvarchar](200) NULL,
	[ProductAtt11Desc] [nvarchar](200) NULL,
	[ProductAtt12Type] [nvarchar](200) NULL,
	[ProductAtt12Desc] [nvarchar](200) NULL,
	[ProductAtt13Type] [nvarchar](200) NULL,
	[ProductAtt13Desc] [nvarchar](200) NULL,
	[ProductAtt14Type] [nvarchar](200) NULL,
	[ProductAtt14Desc] [nvarchar](200) NULL,
	[ProductAtt15Type] [nvarchar](200) NULL,
	[ProductAtt15Desc] [nvarchar](200) NULL,
	[ProductAtt16Type] [nvarchar](200) NULL,
	[ProductAtt16Desc] [nvarchar](200) NULL,
	[ProductAtt17Type] [nvarchar](200) NULL,
	[ProductAtt17Desc] [nvarchar](200) NULL,
	[ProductAtt18Type] [nvarchar](200) NULL,
	[ProductAtt18Desc] [nvarchar](200) NULL,
	[ProductAtt19Type] [nvarchar](200) NULL,
	[ProductAtt19Desc] [nvarchar](200) NULL,
	[ProductAtt20Type] [nvarchar](200) NULL,
	[ProductAtt20Desc] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGUrunResimList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUrunResimList](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Resim] [nvarchar](500) NULL,
	[Aktarma] [bit] NULL,
	[Barcode] [nvarchar](100) NULL,
	[Marka] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGUrunResimList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGUserLogin]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGUserLogin](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
	[StoreCode] [nvarchar](50) NULL,
	[Yetki] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGUserLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZTMSGYetki]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTMSGYetki](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[YetkiKodu] [int] NULL,
	[Yetki] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZTMSGYetki] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ZTMSFirmaBarkod] ADD  CONSTRAINT [DF_ZTMSFirmaBarkod_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceItemList] ADD  CONSTRAINT [DF_ZTMSGInvoiceItemList_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceItemList] ADD  CONSTRAINT [DF_ZTMSGInvoiceItemList_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceReturnItemList] ADD  CONSTRAINT [DF_ZTMSGInvoiceReturnItemList_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGInvoiceReturnItemList] ADD  CONSTRAINT [DF_ZTMSGInvoiceReturnItemList_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakip] ADD  CONSTRAINT [DF_ZTMSGKargoTakip_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakip] ADD  CONSTRAINT [DF_ZTMSGKargoTakip_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakipKontrol] ADD  CONSTRAINT [DF_ZTMSGKargoTakipKontrol_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGKargoTakipKontrol] ADD  CONSTRAINT [DF_ZTMSGKargoTakipKontrol_Tarih]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGMisigoOzellikEslestir] ADD  CONSTRAINT [DF_ZTMSGMisigoOzellikEslestir_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGMisigoUrunAcmaParametreleri] ADD  CONSTRAINT [DF_ZTMSGMisigoUrunAcmaParametreleri_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGRAF] ADD  CONSTRAINT [DF_ZTMSGRAF_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] ADD  CONSTRAINT [DF_ZTMSGRAFHAREKETLER_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] ADD  CONSTRAINT [DF_ZTMSGRAFHAREKETLER_ItemDate]  DEFAULT (getdate()) FOR [ItemDate]
GO
ALTER TABLE [dbo].[ZTMSGRAFHAREKETLER] ADD  CONSTRAINT [DF_ZTMSGRAFHAREKETLER_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGRafSayimOffline] ADD  CONSTRAINT [DF_ZTMSRAFSAYIMOFFLINE_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGRAFSTOK] ADD  CONSTRAINT [DF_ZTMSGRAFSTOK_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGSettings] ADD  CONSTRAINT [DF_ZTMSGSettings_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGStore] ADD  CONSTRAINT [DF_ZTMSGStore_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicKargo] ADD  CONSTRAINT [DF_ZTMSGTicKargo_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisKontrol] ADD  CONSTRAINT [DF_ZTMSGTicSiparisKontrol_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisKontrol] ADD  CONSTRAINT [DF_ZTMSGTicSiparisKontrol_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisList] ADD  CONSTRAINT [DF_ZTMSGTicSiparisList_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisList] ADD  CONSTRAINT [DF_ZTMSGTicSiparisList_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTicSiparisListDetay] ADD  CONSTRAINT [DF_ZTMSGTicSiparisListDetay_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunAcmaParametreleri] ADD  CONSTRAINT [DF_ZTMSGTicUrunAcmaParametreleri_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunKartiAcma] ADD  CONSTRAINT [DF_ZTMSGTicUrunKartiAcma_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicUrunVariant] ADD  CONSTRAINT [DF_ZTMSGTicUrunVariant_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGTicXmlUrl] ADD  CONSTRAINT [DF_ZTMSGTicXmlUrl_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ZTMSGTrendyolSiparisYD] ADD  CONSTRAINT [DF_ZTMSGTrendyolSiparisYD_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunlerQR] ADD  CONSTRAINT [DF_ZTMSGUrunlerQR_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunListMisigo] ADD  CONSTRAINT [DF_ZTMSGUrunListMisigo_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunListMisigo2] ADD  CONSTRAINT [DF_ZTMSGUrunListMisigo2_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGUrunResimList] ADD  CONSTRAINT [DF_ZTMSGUrunResimList_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGUserLogin] ADD  CONSTRAINT [DF_ZTMSGUserLogin_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ZTMSGYetki] ADD  CONSTRAINT [DF_ZTMSGYetki_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviri]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec POST_MSDilCeviri '001-N22-1399','EN','Lace-up Shorts'
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_DilCeviri]
	(@Itemcode nvarchar(50)
	,@Langcode nvarchar(50)
	,@Itemdescription nvarchar(500)
	)
AS



Insert Into cdItemDesc(ItemTypeCode,ItemCode,LangCode,ItemDescription)
select  1,@Itemcode,@Langcode,@Itemdescription
where @Itemcode not in (select Itemcode from cdItemDesc where LangCode =@Langcode)
GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriOzellik]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec POST_MSDilCeviri '001-N22-1399','EN','Lace-up Shorts'
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_DilCeviriOzellik]
	(@AttributeTypeCode nvarchar(50),
	@AttributeCode nvarchar(50)
	
	,@Langcode nvarchar(50)
	,@Itemdescription nvarchar(500)
	)
AS



Insert Into cdItemAttributeDesc(ItemTypeCode,AttributeTypeCode,AttributeCode,LangCode,AttributeDescription)
select  1,@AttributeTypeCode,@AttributeCode,@Langcode,@Itemdescription
where @AttributeCode not in (select AttributeCode from cdItemAttributeDesc where AttributeTypeCode=@AttributeTypeCode and AttributeCode=@AttributeCode and LangCode =@Langcode)


GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriOzellikTipi]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec POST_MSDilCeviri '001-N22-1399','EN','Lace-up Shorts'
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_DilCeviriOzellikTipi]
	(@AttributeTypeCode nvarchar(50)
	
	,@Langcode nvarchar(50)
	,@AttributeTypeDescription nvarchar(500)
	)
AS


delete cdItemAttributeTypeDesc where CreatedUserName = 'sa' and LangCode != 'TR' and ItemTypeCode = 1

Insert Into cdItemAttributeTypeDesc(ItemTypeCode,AttributeTypeCode,LangCode,AttributeTypeDescription)
select  1,@AttributeTypeCode,@Langcode,@AttributeTypeDescription
where @AttributeTypeCode not in (select AttributeTypeCode  from cdItemAttributeTypeDesc where AttributeTypeCode=@AttributeTypeCode and  LangCode =@Langcode)


GO
/****** Object:  StoredProcedure [dbo].[MSG_DilCeviriRenk]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec POST_MSDilCeviri '001-N22-1399','EN','Lace-up Shorts'
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_DilCeviriRenk]
	(@Itemcode nvarchar(50)
	,@Langcode nvarchar(50)
	,@Itemdescription nvarchar(500)
	)
AS



Insert Into cdColorDesc(ColorCode,LangCode,ColorDescription)
select  @Itemcode,@Langcode,@Itemdescription
where @Itemcode not in (select Colorcode from cdColorDesc where LangCode =@Langcode)
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetAlisSiparis]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetFaturaGider 'M01'
create PROCEDURE [dbo].[MSG_GetAlisSiparis]
  (@StoreCode nvarchar(50))
AS
select OrderID=UPPER(AllOrders.OrderHeaderID)
,[Müşteri Adı] =CurrAccDescription
,SiparisNo =OrderNumber
,Açıklama =Description
,[Detaylı Açıklama]=InternalDescription
,Durumu = 'Faturalaştırılmadı'

from AllOrders
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
Left Outer Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
where ProcessCode = 'BP'
and AllOrders.CreatedDate >=GETDATE()-30
Group by AllOrders.OrderHeaderID,CurrAccDescription,OrderNumber,Description,InternalDescription,AllOrders.CreatedDate
Order By AllOrders.CreatedDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetFaturaGider]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetFaturaGider 'M01'
CREATE PROCEDURE [dbo].[MSG_GetFaturaGider]
  (@StoreCode nvarchar(50))
AS
select InvoiceID=UPPER(AllInvoices.InvoiceHeaderID)
,[Müşteri Adı] =CurrAccDescription
,FaturaNo =InvoiceNumber
,Açıklama =Description
,[Detaylı Açıklama]=InternalDescription
,Durumu = 'Gider Pusulası Kesilmedi'

from AllInvoices
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllInvoices.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
and IsReturn = 0
where ProcessCode = 'R'
and AllInvoices.StoreCode = @StoreCode
and AllInvoices.CreatedDate >=GETDATE()-30
Group by AllInvoices.InvoiceHeaderID,CurrAccDescription,InvoiceNumber,Description,InternalDescription,AllInvoices.CreatedDate
Order By AllInvoices.CreatedDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIadeGorsel]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from trInvoiceHeader where IsReturn = 1
----exec MSG_GetIrsaliyeGorselHeader '70322472-96BC-4195-985D-B11B00469A81'
create PROCEDURE [dbo].[MSG_GetIadeGorsel]
  (@HeaderID nvarchar(50))
AS
exec sp_executesql N'
 SELECT InvoiceNumber			= trInvoiceHeader.InvoiceNumber			
	 , InvoiceDate				= trInvoiceHeader.InvoiceDate
	 , InvoiceTime				= trInvoiceHeader.InvoiceTime
	 , IsReturn					= trInvoiceHeader.IsReturn
	 , Series					= trInvoiceHeader.Series
	 , SeriesNumber				= trInvoiceHeader.SeriesNumber
	 , CurrAccCode				= trInvoiceHeader.CurrAccCode
	 , FirstLastName			= CASE WHEN trInvoiceHeader.CurrAccTypeCode IN (4,8) THEN  ISNULL(CASE InvoicePostalAddress.FirstLastName WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.FirstLastName  END   , cdCurrAcc.FirstLastName)
									   WHEN trInvoiceHeader.CurrAccTypeCode = 3 THEN ISNULL(CASE InvoicePostalAddress.CompanyName WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CompanyName  END   , ISNULL((SELECT CurrAccDescription FROM cdCurrAccDesc WITH(NOLOCK) WHERE cdCurrAccDesc.CurrAccTypeCode = cdCurrAcc.CurrAccTypeCode AND cdCurrAccDesc.CurrAccCode = cdCurrAcc.CurrAccCode AND cdCurrAccDesc.LangCode =''TR''),SPACE(0))) END
	 , FullName					= cdCurrAcc.FullName
	 , Patronym					= cdCurrAcc.Patronym
	 , PassportNum			= ISNULL(prCurrAccPersonalInfo.PassportNum, SPACE(0))
	 , TaxOffice			= ISNULL((SELECT TaxOfficeDescription FROM cdTaxOfficeDesc WITH(NOLOCK) WHERE cdTaxOfficeDesc.TaxOfficeCode = cdCurrAcc.TaxOfficeCode AND cdTaxOfficeDesc.LangCode =''TR'')	, SPACE(0)) 
	 , TaxNumber			= cdCurrAcc.TaxNumber
	 , IdentityNum			= cdCurrAcc.IdentityNum

	 , BillingAddress_CompanyName	= COALESCE(tpInvoicePostalAddress.CompanyName,InvoicePostalAddress.CompanyName	, SPACE(0)) 
	 , BillingAddress_Address		= COALESCE(tpInvoicePostalAddress.Address,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.Address END				, CurrAccPostalAddress.Address	, SPACE(0)) 
	 , BillingAddress_District		= COALESCE((SELECT DistrictDescription FROM cdDistrictDesc WITH(NOLOCK) WHERE LangCode =''TR'' and cdDistrictDesc.DistrictCode = ISNULL(tpInvoicePostalAddress.DistrictCode, SPACE(0))),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.DistrictDescription END	, CurrAccPostalAddress.DistrictDescription	, SPACE(0)) 
	 , BillingAddress_City			= COALESCE((SELECT CityDescription FROM cdCityDesc WITH(NOLOCK) WHERE LangCode =''TR'' and cdCityDesc.CityCode = tpInvoicePostalAddress.CityCode),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CityDescription END		, CurrAccPostalAddress.CityDescription		, SPACE(0)) 
	 , BillingAddress_Country		= COALESCE((SELECT CountryDescription  FROM cdCountryDesc WITH(NOLOCK)	WHERE cdCountryDesc.CountryCode		= ISNULL(tpInvoicePostalAddress.CountryCode, SPACE(0)) AND cdCountryDesc.LangCode =''TR''),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CountryDescription END	, CurrAccPostalAddress.CountryDescription	, SPACE(0)) 
	 , BillingAddress_ZipCode		= COALESCE(tpInvoicePostalAddress.ZipCode,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.ZipCode END				, CurrAccPostalAddress.ZipCode	, SPACE(0)) 
	 , BillingAddress_TaxOffice		= COALESCE((SELECT TaxOfficeDescription FROM cdTaxOfficeDesc WITH(NOLOCK) WHERE cdTaxOfficeDesc.TaxOfficeCode = ISNULL(tpInvoicePostalAddress.TaxOfficeCode, SPACE(0)) AND cdTaxOfficeDesc.LangCode =''TR''),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.TaxOfficeDescription END	, CurrAccPostalAddress.TaxOfficeDescription , SPACE(0)) 
	 , BillingAddress_TaxNumber		= COALESCE(tpInvoicePostalAddress.TaxNumber,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.TaxNumber END			, CurrAccPostalAddress.TaxNumber , SPACE(0)) 
	 , BillingAddress_IdentityNum	= COALESCE(tpInvoicePostalAddress.IdentityNum,cdCurrAcc.IdentityNum, SPACE(0)) 
	 

	 , ContactTypeCode			= ISNULL(prCurrAccContact.ContactTypeCode , SPACE(0))
	 , ContactFirstLastName		= ISNULL(prCurrAccContact.FirstLastName , SPACE(0))
	 
	 , OfficeCode				= trInvoiceHeader.OfficeCode
	 , OfficeDescription		= ISNULL((SELECT OfficeDescription FROM cdOfficeDesc WITH(NOLOCK) WHERE cdOfficeDesc.OfficeCode = trInvoiceHeader.OfficeCode AND cdOfficeDesc.LangCode =''TR'') , SPACE(0))
	 , StoreCode				= trInvoiceHeader.StoreCode
	 , StoreDescription			= ISNULL((SELECT CurrAccDescription FROM cdCurrAccDesc WITH(NOLOCK) WHERE cdCurrAccDesc.CurrAccTypeCode = 5 AND cdCurrAccDesc.CurrAccCode = trInvoiceHeader.StoreCode AND cdCurrAccDesc.LangCode =''TR'') , SPACE(0))
	 , StoreAddress_Address		= ISNULL(StoreAddress.Address	, SPACE(0)) 
	 , StoreAddress_District	= ISNULL(StoreAddress.DistrictDescription	, SPACE(0)) 
	 , StoreAddress_City		= ISNULL(StoreAddress.CityDescription		, SPACE(0)) 
	 , StoreAddress_Country		= ISNULL(StoreAddress.CountryDescription	, SPACE(0)) 
	 , StoreAddress_ZipCode		= ISNULL(StoreAddress.ZipCode				, SPACE(0)) 
	 , StoreAddress_TaxOffice	= ISNULL(StoreAddress.TaxOfficeDescription	, SPACE(0)) 
	 , StoreAddress_TaxNumber	= ISNULL(StoreAddress.TaxNumber	, SPACE(0)) 
	 , WarehouseCode			= trInvoiceHeader.WarehouseCode
	 , WarehouseDescription		= ISNULL((SELECT WarehouseDescription FROM cdWarehouseDesc WITH(NOLOCK) WHERE cdWarehouseDesc.WarehouseCode = trInvoiceHeader.WarehouseCode AND cdWarehouseDesc.LangCode =''TR'') , SPACE(0))
	 , LastUpdatedUserName		= trInvoiceHeader.LastUpdatedUserName
	 , LastUpdatedDate			= trInvoiceHeader.LastUpdatedDate
	 , CashierFirstLastName		= ISNULL((SELECT FirstName + SPACE(1) + LastName FROM NebimV3Master..cdUser WHERE cdUser.UserGroupCode = SUBSTRING(trInvoiceHeader.LastUpdatedUserName,1,5) AND cdUser.UserName = SUBSTRING(trInvoiceHeader.LastUpdatedUserName,6,15)), SPACE(0))
	 , SalesInvoiceNumber		= ISNULL(SalesInvoice.SalesInvoiceNumber , SPACE(0))
	 , SalesInvoiceDate			= ISNULL(SalesInvoice.SalesInvoiceDate , SPACE(0))
	 , Invoice.*

 FROM 
 (
 SELECT 
	   SortOrder				= trInvoiceLine.SortOrder
	 , ItemCode					= trInvoiceLine.ItemCode
	 , ItemDescription			= ISNULL(cdItemDesc.ItemDescription,SPACE(0))
	 , ColorCode				= trInvoiceLine.ColorCode
	 , ColorDescription			= ISNULL(cdColorDesc.ColorDescription , SPACE(0))
	 , ItemDim1Code				= trInvoiceLine.ItemDim1Code
	 , ItemDim2Code				= trInvoiceLine.ItemDim2Code
	 , ItemDim3Code				= trInvoiceLine.ItemDim3Code
	 , SerialNumber				= COALESCE(ShipmentSerialNumbers.SerialNumber , InvoiceSerialNumbers.SerialNumber, SPACE(0))
	 
	 , UnitOfMeasureCode1	= cdItem.UnitOfMeasureCode1
	 , UnitOfMeasureCode2	= cdItem.UnitOfMeasureCode2
	 , UnitConvertRate		= cdItem.UnitConvertRate		

	 , VatCode				= trInvoiceLine.VatCode
	 , VatRate				= trInvoiceLine.VatRate
	 , PCTCode				= trInvoiceLine.PCTCode
	 , PCTRate				= trInvoiceLine.PCTRate

	 , Qty1						= ABS(trInvoiceLine.Qty1)
	 , Qty2						= ABS(trInvoiceLine.Qty2)
	 , Price					= trInvoiceLine.Price
	 , Doc_Price				= ISNULL(trInvoiceLineCurrencyDoc.Price , 0)
	 , Doc_PriceVI				= ISNULL(trInvoiceLineCurrencyDoc.PriceVI , 0)
	 , Loc_Price				= ISNULL(trInvoiceLineCurrencyLoc.Price , 0)
	 , Loc_PriceVI				= ISNULL(trInvoiceLineCurrencyLoc.PriceVI , 0)


     , LineDescription          = trInvoiceLine.LineDescription
	 , Description				= trInvoiceHeader.Description
	 , SupportRequestNumber		= ISNULL(trSupportRequestHeader.SupportRequestNumber , SPACE(0))

	 , Doc_CurrencyCode			= trInvoiceLine.DocCurrencyCode
	 , Doc_AmountVI				= ABS(ISNULL(trInvoiceLineCurrencyDoc.AmountVI , 0))

	 , Doc_Amount				= ABS(ISNULL(trInvoiceLineCurrencyDoc.Amount , 0))
	 , Doc_LDiscount1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.LDiscount1 , 0))
	 , Doc_LDiscount2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.LDiscount2 , 0))			
	 , Doc_LDiscountTotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.LDiscount1 + trInvoiceLineCurrencyDoc.LDiscount2 + trInvoiceLineCurrencyDoc.LDiscount3 + trInvoiceLineCurrencyDoc.LDiscount4 + trInvoiceLineCurrencyDoc.LDiscount5) , 0))
	 , Doc_TDiscount1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscount1 , 0))		
	 , Doc_TDiscount2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscount2 , 0))					
	 , Doc_TDiscountTotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.TDiscount1 + trInvoiceLineCurrencyDoc.TDiscount2 + trInvoiceLineCurrencyDoc.TDiscount3 + trInvoiceLineCurrencyDoc.TDiscount4 + trInvoiceLineCurrencyDoc.TDiscount5) , 0))

	 , Doc_LDiscountVI1			= ABS(trInvoiceLineCurrencyDoc.LDiscountVI1)
	 , Doc_LDiscountVI2			= ABS(trInvoiceLineCurrencyDoc.LDiscountVI2)			
	 , Doc_LDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.LDiscountVI1 + trInvoiceLineCurrencyDoc.LDiscountVI2 + trInvoiceLineCurrencyDoc.LDiscountVI3 + trInvoiceLineCurrencyDoc.LDiscountVI4 + trInvoiceLineCurrencyDoc.LDiscountVI5) , 0))
	 , Doc_TDiscountVI1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscountVI1 , 0))		
	 , Doc_TDiscountVI2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscountVI2 , 0))			
	 , Doc_TDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.TDiscountVI1 + trInvoiceLineCurrencyDoc.TDiscountVI2 + trInvoiceLineCurrencyDoc.TDiscountVI3 + trInvoiceLineCurrencyDoc.TDiscountVI4 + trInvoiceLineCurrencyDoc.TDiscountVI5) , 0))
	 , Doc_TaxBase				= ABS(trInvoiceLineCurrencyDoc.TaxBase)
	 , Doc_Vat					= ABS(trInvoiceLineCurrencyDoc.Vat)
	 , Doc_NetAmount			= ABS(trInvoiceLineCurrencyDoc.NetAmount)

	 , Loc_CurrencyCode			= trInvoiceHeader.LocalCurrencyCode
	 , Loc_ExchangeRate			= trInvoiceLineCurrencyLoc.ExchangeRate			
	 , Loc_AmountVI				= ABS(trInvoiceLineCurrencyLoc.AmountVI)
	 , Loc_LDiscountVI1			= ABS(trInvoiceLineCurrencyLoc.LDiscountVI1)
	 , Loc_LDiscountVI2			= ABS(trInvoiceLineCurrencyLoc.LDiscountVI2)			
	 , Loc_LDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyLoc.LDiscountVI1 + trInvoiceLineCurrencyLoc.LDiscountVI2 + trInvoiceLineCurrencyLoc.LDiscountVI3 + trInvoiceLineCurrencyLoc.LDiscountVI4 + trInvoiceLineCurrencyLoc.LDiscountVI5) , 0))
	 , Loc_TDiscountVI1			= ABS(trInvoiceLineCurrencyLoc.TDiscountVI1)		
	 , Loc_TDiscountVI2			= ABS(trInvoiceLineCurrencyLoc.TDiscountVI2)			
	 , Loc_TDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyLoc.TDiscountVI1 + trInvoiceLineCurrencyLoc.TDiscountVI2 + trInvoiceLineCurrencyLoc.TDiscountVI3 + trInvoiceLineCurrencyLoc.TDiscountVI4 + trInvoiceLineCurrencyLoc.TDiscountVI5) , 0))
	 , Loc_TaxBase				= ABS(trInvoiceLineCurrencyLoc.TaxBase)
	 , Loc_Vat					= ABS(trInvoiceLineCurrencyLoc.Vat)
	 , Loc_NetAmount			= ABS(trInvoiceLineCurrencyLoc.NetAmount)

	 , TaxRefund				= ABS(trInvoiceHeader.TaxRefund )
	 , TaxTypeCode				= trInvoiceHeader.TaxTypeCode

	 , PaymentTypeCode = 0
	 , PaymentTypeDescription = SPACE(0)
	 , PaymentProviderCode			= SPACE(0)
	 , PaymentProviderDescription	= SPACE(0)
	 , CreditCardTypeCode = SPACE(0)
	 , CreditCardTypeDescription = SPACE(0)
	 , AcquirerBankCode			= SPACE(0)
	 , AcquirerBankDescription	= SPACE(0)
	 , IssuerBankCode			= SPACE(0)
	 , IssuerBankDescription	= SPACE(0)
	 , CreditCardNum = SPACE(0)
	 , OrderNumber = SPACE(0)
	 , CreditCardInstallmentCount = 0
	 , PaymentCurrencyCode = SPACE(0)
	 , Doc_Payment = 0
	 , PaymentExchangeRate = 0
	 , Loc_Payment = 0
	 , GiftCardRemainingAmount = 0
	 , FirstValidDate				= SPACE(0)
	 , LastValidDate				= SPACE(0)

	 , InstallmentDueDate		= ''19000101''
	 , InstallmentDoc_Amount	= 0
	 , trInvoiceLine.SalespersonCode	 
	 , SalespersonFirstLastName = (SELECT FirstLastName FROM cdSalesperson WITH(NOLOCK) WHERE cdSalesperson.SalespersonCode	= trInvoiceLine.SalespersonCode	 )
	 , Type						= 1
	 , HeaderID					= trInvoiceLine.InvoiceHeaderID
	 , LineID					= trInvoiceLine.InvoiceLineID
	 , ApplicationCode			= trInvoiceHeader.ApplicationCode
	 , ApplicationID			= trInvoiceHeader.ApplicationID
	 
	 , cdItem.ProductHierarchyID 
	 , ProductHierarchyLevel01
     , ProductHierarchyLevel02
     , ProductHierarchyLevel03
     , ProductHierarchyLevel04
     , ProductHierarchyLevel05
     , ProductHierarchyLevel06
     , ProductHierarchyLevel07
     , ProductHierarchyLevel08
     , ProductHierarchyLevel09
     , ProductHierarchyLevel10

	 , ProductHierarchyLevelCode01
	 , ProductHierarchyLevelCode02
	 , ProductHierarchyLevelCode03
	 , ProductHierarchyLevelCode04
	 , ProductHierarchyLevelCode05
	 , ProductHierarchyLevelCode06
	 , ProductHierarchyLevelCode07
	 , ProductHierarchyLevelCode09
	 , ProductHierarchyLevelCode10
	 , trInvoiceLine.UsedBarcode
FROM trInvoiceLine  WITH(NOLOCK)
	 INNER JOIN trInvoiceHeader WITH (NOLOCK) 
		ON trInvoiceHeader.InvoiceHeaderID = trInvoiceLine.InvoiceHeaderID
	 LEFT OUTER JOIN trInvoiceLineCurrency AS trInvoiceLineCurrencyDoc WITH (NOLOCK) 
		ON trInvoiceLineCurrencyDoc.InvoiceLineID = trInvoiceLine.InvoiceLineID 
		AND trInvoiceLineCurrencyDoc.CurrencyCode =  trInvoiceLine.DocCurrencyCode   
	 LEFT OUTER JOIN trInvoiceLineCurrency AS trInvoiceLineCurrencyLoc WITH (NOLOCK) 
		ON trInvoiceLineCurrencyLoc.InvoiceLineID = trInvoiceLine.InvoiceLineID 
		AND trInvoiceLineCurrencyLoc.CurrencyCode = trInvoiceHeader.LocalCurrencyCode 
	  LEFT OUTER JOIN cdItemDesc				WITH(NOLOCK)	
		ON cdItemDesc.ItemTypeCode = trInvoiceLine.ItemTypeCode AND cdItemDesc.ItemCode = trInvoiceLine.ItemCode AND cdItemDesc.LangCode =''TR''
	 LEFT OUTER JOIN trSupportRequestHeader WITH(NOLOCK) 
		ON trSupportRequestHeader.SupportRequestHeaderID = trInvoiceLine.SupportRequestHeaderID
	 LEFT OUTER JOIN cdColorDesc	WITH(NOLOCK)
		ON cdColorDesc.ColorCode = trInvoiceLine.ColorCode
		AND cdColorDesc.LangCode =''TR''
	 INNER JOIN cdItem WITH(NOLOCK)
		ON cdItem.ItemTypeCode	= trInvoiceLine.ItemTypeCode
		AND cdItem.ItemCode		= trInvoiceLine.ItemCode
	 INNER JOIN ProductHierarchy(''TR'') 
		ON ProductHierarchy.ProductHierarchyID			= cdItem.ProductHierarchyID	

	LEFT OUTER JOIN stItemSerialNumber ShipmentSerialNumbers WITH(NOLOCK)	ON trInvoiceLine.ShipmentLineID = ShipmentSerialNumbers.ShipmentLineID 

	LEFT OUTER JOIN stItemSerialNumber InvoiceSerialNumbers WITH(NOLOCK)	ON trInvoiceLine.InvoiceLineID = InvoiceSerialNumbers.InvoiceLineID 
UNION All
 SELECT 
	   SortOrder				= 0
	 , ItemCode					= SPACE(0)
	 , ItemDescription			= SPACE(0)
	 , ColorCode				= SPACE(0)
	 , ColorDescription			= SPACE(0)
	 , ItemDim1Code				= SPACE(0)
	 , ItemDim2Code				= SPACE(0)
	 , ItemDim3Code				= SPACE(0)
	 , SerialNumber				= SPACE(0)

	 , UnitOfMeasureCode1	= SPACE(0)
	 , UnitOfMeasureCode2	= SPACE(0)
	 , UnitConvertRate		= SPACE(0)

	 , VatCode				= SPACE(0)
	 , VatRate				= SPACE(0)
	 , PCTCode				= SPACE(0)
	 , PCTRate				= SPACE(0)

	 , Qty1						= 0
	 , Qty2						= 0
	 , Price					= 0
	 , Doc_Price				= 0
	 , Doc_PriceVI				= 0
	 , Loc_Price				= 0
	 , Loc_PriceVI				= 0

	 , LineDescription          = SPACE(0)
	 , Description		        = SPACE(0)
	 , SupportRequestNumber		= SPACE(0)
	 , Doc_CurrencyCode			= SPACE(0)
	 , Doc_AmountVI				= 0

	 , Doc_Amount				= 0
	 , Doc_LDiscount1			= 0
	 , Doc_LDiscount2			= 0	
	 , Doc_LDiscountTotal		= 0
	 , Doc_TDiscount1			= 0	
	 , Doc_TDiscount2			= 0			
	 , Doc_TDiscountTotal		= 0

	 , Doc_LDiscountVI1			= 0
	 , Doc_LDiscountVI2			= 0	
	 , Doc_LDiscountVITotal		= 0
	 , Doc_TDiscountVI1			= 0	
	 , Doc_TDiscountVI2			= 0			
	 , Doc_TDiscountVITotal		= 0
	 , Doc_TaxBase				= 0
	 , Doc_Vat					= 0
	 , Doc_NetAmount			= 0
	 , Loc_CurrencyCode			= SPACE(0)
	 , Loc_ExchangeRate			= 0
	 , Loc_AmountVI				= 0
	 , Loc_LDiscountVI1			= 0
	 , Loc_LDiscountVI2			= 0	
	 , Loc_LDiscountVITotal		= 0
	 , Loc_TDiscountVI1			= 0	
	 , Loc_TDiscountVI2			= 0			
	 , Loc_TDiscountVITotal		= 0
	 , Loc_TaxBase				= 0
	 , Loc_Vat					= 0
	 , Loc_NetAmount			= 0
	 , TaxRefund				= 0
	 , TaxTypeCode				= 0

	 , PaymentTypeCode				= trPaymentLine.PaymentTypeCode 
									* CASE WHEN ( (trPaymentLine.CashLineID IS NOT NULL AND trCashHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.CreditCardPaymentLineID IS NOT NULL AND trCreditCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.GiftCardPaymentLineID IS NOT NULL AND trGiftCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.OtherPaymentLineID IS NOT NULL AND trOtherPaymentHeader.ApplicationCode = N''Order'')) THEN -1 ELSE 1 END
	 , PaymentTypeDescription		= CASE WHEN ( (trPaymentLine.CashLineID IS NOT NULL AND trCashHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.CreditCardPaymentLineID IS NOT NULL AND trCreditCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.GiftCardPaymentLineID IS NOT NULL AND trGiftCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.OtherPaymentLineID IS NOT NULL AND trOtherPaymentHeader.ApplicationCode = N''Order'')) THEN 
													(CASE WHEN trPaymentLine.PaymentTypeCode <> 6 AND ISNULL(trPaymentLineCurrencyLoc.Payment, 0) < 0 THEN dbo.fn_GetFieldName(N''ReturnRetailDeposit'',''TR'')  ELSE  dbo.fn_GetFieldName(N''RetailDeposit'',''TR'') END) + '' - '' ELSE SPACE(0) END
									+  ISNULL(bsPaymentTypeDesc.PaymentTypeDescription , SPACE(0))									
	 , PaymentProviderCode			= ISNULL(trOtherPaymentHeader.PaymentProviderCode, SPACE(0))
	 , PaymentProviderDescription	= ISNULL((SELECT PaymentProviderDescription FROM cdPaymentProviderDesc WITH(NOLOCK) WHERE cdPaymentProviderDesc.LangCode =''TR'' AND cdPaymentProviderDesc.PaymentProviderCode = trOtherPaymentHeader.PaymentProviderCode), SPACE(0))
	 
	 , CreditCardTypeCode			= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(trCreditCardPaymentLine.CreditCardTypeCode, SPACE(0))
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(cdGiftCard.ItemCode, SPACE(0))
											ELSE SPACE(0) 
									  END
	 , CreditCardTypeDescription	= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(cdCreditCardTypeDesc.CreditCardTypeDescription, SPACE(0))
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(cdItemDesc.ItemDescription, SPACE(0))
											ELSE SPACE(0) 
									  END
	 , AcquirerBankCode				= ISNULL(trCreditCardPaymentLine.AcquirerBankCode, SPACE(0))
	 , AcquirerBankDescription		= ISNULL((SELECT BankDescription FROM cdBankDesc WITH(NOLOCK) WHERE cdBankDesc.BankCode = trCreditCardPaymentLine.AcquirerBankCode AND cdBankDesc.LangCode =''TR''), SPACE(0))
	 , IssuerBankCode				= ISNULL(trCreditCardPaymentLine.IssuerBankCode, SPACE(0))
	 , IssuerBankDescription		= ISNULL((SELECT BankDescription FROM cdBankDesc WITH(NOLOCK) WHERE cdBankDesc.BankCode = trCreditCardPaymentLine.IssuerBankCode AND cdBankDesc.LangCode =''TR''), SPACE(0))
	 
	 , CreditCardNum				= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(trCreditCardPaymentLine.CreditCardNum, SPACE(0))		
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(trGiftCardPaymentLine.SerialNumber, SPACE(0))
											ELSE SPACE(0)
									  END		
	 , OrderNumber					= CASE WHEN COALESCE(trCashHeader.ApplicationCode,trCreditCardPaymentHeader.ApplicationCode,trGiftCardPaymentHeader.ApplicationCode, SPACE(0)) = N''Order'' THEN	  COALESCE(trCashHeader.RefNumber,trCreditCardPaymentHeader.RefNumber,trGiftCardPaymentHeader.RefNumber, SPACE(0))	  ELSE SPACE(0) END
	 , CreditCardInstallmentCount	= ISNULL(trCreditCardPaymentLine.CreditCardInstallmentCount, 0)
	 , PaymentCurrencyCode			= trPaymentLine.DocCurrencyCode
	 , Doc_Payment					= CASE WHEN trPaymentLine.PaymentTypeCode IN(''4'',''5'') AND trInvoiceHeader.IsReturn =1 THEN ISNULL(trPaymentLineCurrencyDoc.Payment, 0) *( -1 )ELSE  ISNULL(trPaymentLineCurrencyDoc.Payment, 0) END  
	 , PaymentExchangeRate			= ISNULL(trPaymentLineCurrencyLoc.ExchangeRate , 0)
	 , Loc_Payment					= CASE WHEN trPaymentLine.PaymentTypeCode IN(''4'',''5'') AND trInvoiceHeader.IsReturn =1 THEN ISNULL(trPaymentLineCurrencyLoc.Payment, 0) *( -1 )ELSE  ISNULL(trPaymentLineCurrencyLoc.Payment, 0) END 
	 , GiftCardRemainingAmount		= ISNULL(cdGiftCard.Amount,0) - ISNULL(cdGiftCard.UsedAmount,0) 
	 , FirstValidDate				= ISNULL(cdGiftCard.FirstValidDate,SPACE(0))
	 , LastValidDate				= ISNULL(cdGiftCard.LastValidDate,SPACE(0))
	 , InstallmentDueDate		= ''19000101''
	 , InstallmentDoc_Amount	= 0
	 , SalespersonCode			= SPACE(0)
	 , SalespersonFirstLastName = SPACE(0)
	 , Type						= 2
	 , HeaderID					= trDebitHeader.ApplicationID
	 , LineID					= ''00000000-0000-0000-0000-000000000000''
	 , ApplicationCode			= trDebitHeader.ApplicationCode
	 , ApplicationID			= trDebitHeader.ApplicationID

	 , ProductHierarchyID	   = SPACE(0)
	 , ProductHierarchyLevel01 = SPACE(0)
     , ProductHierarchyLevel02 = SPACE(0)
     , ProductHierarchyLevel03 = SPACE(0)
     , ProductHierarchyLevel04 = SPACE(0)
     , ProductHierarchyLevel05 = SPACE(0)
     , ProductHierarchyLevel06 = SPACE(0)
     , ProductHierarchyLevel07 = SPACE(0)
     , ProductHierarchyLevel08 = SPACE(0)
     , ProductHierarchyLevel09 = SPACE(0)
     , ProductHierarchyLevel10 = SPACE(0)

	 , ProductHierarchyLevelCode01 = SPACE(0)
	 , ProductHierarchyLevelCode02 = SPACE(0)
	 , ProductHierarchyLevelCode03 = SPACE(0)
	 , ProductHierarchyLevelCode04 = SPACE(0)
	 , ProductHierarchyLevelCode05 = SPACE(0)
	 , ProductHierarchyLevelCode06 = SPACE(0)
	 , ProductHierarchyLevelCode07 = SPACE(0)
	 , ProductHierarchyLevelCode09 = SPACE(0)
	 , ProductHierarchyLevelCode10 = SPACE(0)
	 , UsedBarcode  = SPACE(0)
	FROM trPaymentLine WITH(NOLOCK)
		INNER JOIN trDebitLine WITH(NOLOCK) 
			ON trDebitLine.DebitLineID = trPaymentLine.DebitLineID
		INNER JOIN trDebitHeader WITH(NOLOCK)
			ON trDebitHeader.DebitHeaderID = trDebitLine.DebitHeaderID
			AND trDebitHeader.ApplicationCode = N''Invoi''
		INNER JOIN trPaymentHeader WITH (NOLOCK)   
			ON trPaymentHeader.PaymentHeaderID = trPaymentLine.PaymentHeaderID
		LEFT OUTER JOIN trPaymentLineCurrency AS trPaymentLineCurrencyDoc WITH (NOLOCK) 
			ON trPaymentLineCurrencyDoc.PaymentLineID = trPaymentLine.PaymentLineID 
			AND trPaymentLineCurrencyDoc.CurrencyCode = trPaymentLine.DocCurrencyCode 
		LEFT OUTER JOIN trPaymentLineCurrency AS trPaymentLineCurrencyLoc WITH (NOLOCK) 
			ON trPaymentLineCurrencyLoc.PaymentLineID = trPaymentLine.PaymentLineID 
			AND trPaymentLineCurrencyLoc.CurrencyCode = trPAymentHeader.LocalCurrencyCode 
		LEFT OUTER JOIN trCashLine WITH(NOLOCK)
			ON trCashLine.CashLineID = trPaymentLine.CashLineID
		LEFT OUTER JOIN trCashHeader WITH(NOLOCK)
			ON trCashHeader.CashHeaderID = trCashLine.CashHeaderID
		LEFT OUTER JOIN trCreditCardPaymentLine WITH(NOLOCK)
			ON trCreditCardPaymentLine.CreditCardPaymentLineID = trPaymentLine.CreditCardPaymentLineID
		LEFT OUTER JOIN trCreditCardPaymentHeader WITH(NOLOCK)
			ON trCreditCardPaymentHeader.CreditCardPaymentHeaderID = trCreditCardPaymentLine.CreditCardPaymentHeaderID
		LEFT OUTER JOIN trGiftCardPAymentLine WITH(NOLOCK)
			ON trGiftCardPaymentLine.GiftCardPaymentLineID = trPaymentLine.GiftCardPaymentLineID
		LEFT OUTER JOIN trGiftCardPaymentHeader WITH(NOLOCK)
			ON trGiftCardPaymentHeader.GiftCardPaymentHeaderID = trGiftCardPAymentLine.GiftCardPaymentHeaderID
		LEFT OUTER JOIN trOtherPaymentLine WITH(NOLOCK)
			ON trOtherPaymentLine.OtherPaymentLineID = trPaymentLine.OtherPaymentLineID
		LEFT OUTER JOIN trOtherPaymentHeader WITH(NOLOCK)
			ON trOtherPaymentHeader.OtherPAymentHeaderID = trOtherPaymentLine.OtherPaymentHeaderID
	     LEFT OUTER JOIN bsPaymentTypeDesc			WITH(NOLOCK) ON bsPaymentTypeDesc.PaymentTypeCode = trPaymentLine.PaymentTypeCode AND bsPaymentTypeDesc.LangCode =''TR''
	     LEFT OUTER JOIN cdCreditCardTypeDesc		WITH(NOLOCK) ON cdCreditCardTypeDesc.CreditCardTypeCode = ISNULL(trCreditCardPaymentLine.CreditCardTypeCode,SPACE(0)) AND cdCreditCardTypeDesc.LangCode =''TR''
		 LEFT OUTER JOIN cdGiftCard					WITH(NOLOCK) ON cdGiftCard.SerialNumber = trGiftCardPAymentLine.SerialNumber
		 LEFT OUTER JOIN cdItemDesc					WITH(NOLOCK) ON cdItemDesc.ItemTypeCode = cdGiftCard.ItemTypeCode AND cdItemDesc.ItemCode = cdGiftCard.ItemCode AND cdItemDesc.LangCode =''TR''
		 INNER JOIN trInvoiceHeader					WITH(NOLOCK) ON trDebitHeader.ApplicationID = trInvoiceHeader.InvoiceHeaderID
UNION ALL
 SELECT 
	   SortOrder				= 0
	 , ItemCode					= SPACE(0)
	 , ItemDescription			= SPACE(0)
	 , ColorCode				= SPACE(0)
	 , ColorDescription			= SPACE(0)
	 , ItemDim1Code				= SPACE(0)
	 , ItemDim2Code				= SPACE(0)
	 , ItemDim3Code				= SPACE(0)
	 , SerialNumber				= SPACE(0)

	 , UnitOfMeasureCode1	= SPACE(0)
	 , UnitOfMeasureCode2	= SPACE(0)
	 , UnitConvertRate		= SPACE(0)

	 , VatCode				= SPACE(0)
	 , VatRate				= SPACE(0)
	 , PCTCode				= SPACE(0)
	 , PCTRate				= SPACE(0)

	 , Qty1						= 0
	 , Qty2						= 0
	 , Price					= 0
	 , Doc_Price				= 0
	 , Doc_PriceVI				= 0
	 , Loc_Price				= 0
	 , Loc_PriceVI				= 0

	 , LineDescription          = SPACE(0)
	 , Description		        = SPACE(0)
	 , SupportRequestNumber		= SPACE(0)
	 , Doc_CurrencyCode			= SPACE(0)
	 , Doc_AmountVI				= 0
	 
	 , Doc_Amount				= 0
	 , Doc_LDiscount1			= 0
	 , Doc_LDiscount2			= 0	
	 , Doc_LDiscountTotal		= 0
	 , Doc_TDiscount1			= 0	
	 , Doc_TDiscount2			= 0			
	 , Doc_TDiscountTotal		= 0

	 , Doc_LDiscountVI1			= 0
	 , Doc_LDiscountVI2			= 0	
	 , Doc_LDiscountVITotal		= 0
	 , Doc_TDiscountVI1			= 0	
	 , Doc_TDiscountVI2			= 0			
	 , Doc_TDiscountVITotal		= 0
	 , Doc_TaxBase				= 0
	 , Doc_Vat					= 0
	 , Doc_NetAmount			= 0
	 
	 , Loc_CurrencyCode			= SPACE(0)
	 , Loc_ExchangeRate			= 0
	 , Loc_AmountVI				= 0
	 , Loc_LDiscountVI1			= 0
	 , Loc_LDiscountVI2			= 0	
	 , Loc_LDiscountVITotal		= 0
	 , Loc_TDiscountVI1			= 0	
	 , Loc_TDiscountVI2			= 0			
	 , Loc_TDiscountVITotal		= 0
	 , Loc_TaxBase				= 0
	 , Loc_Vat					= 0
	 , Loc_NetAmount			= 0

	 , TaxRefund				= 0
	 , TaxTypeCode				= 0

	 , PaymentTypeCode = 0
	 , PaymentTypeDescription = SPACE(0)
	 , PaymentProviderCode			= SPACE(0)
	 , PaymentProviderDescription	= SPACE(0)
	 , CreditCardTypeCode = SPACE(0)
	 , CreditCardTypeDescription = SPACE(0)
	 , AcquirerBankCode			= SPACE(0)
	 , AcquirerBankDescription	= SPACE(0)
	 , IssuerBankCode			= SPACE(0)
	 , IssuerBankDescription	= SPACE(0)
	 , CreditCardNum = SPACE(0)
	 , OrderNumber = SPACE(0)
	 , CreditCardInstallmentCount = 0
	 , PaymentCurrencyCode			= SPACE(0)
	 , Doc_Payment					= 0
	 , PaymentExchangeRate			= 0
	 , Loc_Payment					= 0
	 
	 , GiftCardRemainingAmount = 0
	 , FirstValidDate				= SPACE(0)
	 , LastValidDate				= SPACE(0)

	 , InstallmentDueDate		= trDebitLine.DueDate
	 , InstallmentDoc_Amount	= (ISNULL(trDebitLineCurrencyDoc.Debit, 0) + ISNULL(trDebitLineCurrencyDoc.Credit, 0)) - ISNULL(AllPayments.Doc_Payment,0)
	 , SalespersonCode			= SPACE(0)	 
	 , SalespersonFirstLastName = SPACE(0)
	 , Type						= 3	 
	 , HeaderID					= trDebitHeader.ApplicationID
	 , LineID					= ''00000000-0000-0000-0000-000000000000''
	 , ApplicationCode			= trDebitHeader.ApplicationCode
	 , ApplicationID			= trDebitHeader.ApplicationID
	 
	 , ProductHierarchyID	   = SPACE(0)
	 , ProductHierarchyLevel01 = SPACE(0)
     , ProductHierarchyLevel02 = SPACE(0)
     , ProductHierarchyLevel03 = SPACE(0)
     , ProductHierarchyLevel04 = SPACE(0)
     , ProductHierarchyLevel05 = SPACE(0)
     , ProductHierarchyLevel06 = SPACE(0)
     , ProductHierarchyLevel07 = SPACE(0)
     , ProductHierarchyLevel08 = SPACE(0)
     , ProductHierarchyLevel09 = SPACE(0)
     , ProductHierarchyLevel10 = SPACE(0)

	 , ProductHierarchyLevelCode01 = SPACE(0)
	 , ProductHierarchyLevelCode02 = SPACE(0)
	 , ProductHierarchyLevelCode03 = SPACE(0)
	 , ProductHierarchyLevelCode04 = SPACE(0)
	 , ProductHierarchyLevelCode05 = SPACE(0)
	 , ProductHierarchyLevelCode06 = SPACE(0)
	 , ProductHierarchyLevelCode07 = SPACE(0)
	 , ProductHierarchyLevelCode09 = SPACE(0)
	 , ProductHierarchyLevelCode10 = SPACE(0)
	 , UsedBarcode  = SPACE(0)
FROM trDebitLine  WITH(NOLOCK)
	INNER JOIN trDebitHeader WITH (NOLOCK) 
		ON trDebitHeader.DebitHeaderID = trDebitLine.DebitHeaderID
	LEFT OUTER JOIN trDebitLineCurrency AS trDebitLineCurrencyDoc WITH (NOLOCK) 
		ON trDebitLineCurrencyDoc.DebitLineID = trDebitLine.DebitLineID 
		AND trDebitLineCurrencyDoc.CurrencyCode = trDebitLine.DocCurrencyCode   
	LEFT OUTER JOIN 
	(
		SELECT DebitLineID, DocCurrencyCode, Doc_Payment = ABS(SUM(Payment))
		FROM trPaymentLine WITH(NOLOCK)
			INNER JOIN trPaymentLineCurrency WITH(NOLOCK)
				ON trPaymentLineCurrency.PaymentLineID = trPaymentLine.PaymentLineID
				AND trPaymentLineCurrency.CurrencyCode = trPaymentLine.DocCurrencyCode
		WHERE trPaymentLine.DebitLineID IS NOT NULL
		GROUP BY DebitLineID, DocCurrencyCode 		
	)
	AS AllPayments
		ON AllPayments.DebitLineID = trDebitLine.DebitLineID
	LEFT OUTER JOIN DebitATAttributesFilter
		ON DebitATAttributesFilter.DebitHeaderID = trDebitHeader.DebitHeaderID
WHERE (ISNULL(trDebitLineCurrencyDoc.Debit, 0) + ISNULL(trDebitLineCurrencyDoc.Credit, 0)) - ISNULL(AllPayments.Doc_Payment,0) > 0 AND trDebitHeader.ApplicationCode = N''Invoi''
) AS Invoice
    INNER JOIN trInvoiceHeader WITH(NOLOCK)
		ON trInvoiceHeader.InvoiceHEaderID			= Invoice.HeaderID
	LEFT OUTER JOIN prCurrAccPersonalInfo WITH(NOLOCK)
		ON prCurrAccPersonalInfo.CurrAccTypeCode	= trInvoiceHeader.CurrAccTypeCode
		AND prCurrAccPersonalInfo.CurrAccCode		= trInvoiceHeader.CurrAccCode
		AND ISNULL(prCurrAccPersonalInfo.ContactID	, ''00000000-0000-0000-0000-000000000000'')		= ISNULL(trInvoiceHeader.ContactID, ''00000000-0000-0000-0000-000000000000'')
     LEFT OUTER JOIN prCurrAccContact		WITH(NOLOCK)	
		ON prCurrAccContact.ContactID	= trInvoiceHeader.ContactID
     LEFT OUTER JOIN CurrAccPostalAddress   (''TR'')	
		ON CurrAccPostalAddress.PostalAddressID = trInvoiceHeader.BillingPostalAddressID
	 LEFT OUTER JOIN InvoicePostalAddress   (''TR'')	
		ON InvoicePostalAddress.InvoiceHeaderID = trInvoiceHeader.InvoiceHeaderID
	 LEFT OUTER JOIN prCurrAccDefault StoreDefaultAddress WITH(NOLOCK) 
		ON StoreDefaultAddress.CurrAccTypeCode = 5
		AND StoreDefaultAddress.CurrAccCode = trInvoiceHeader.StoreCode
	 LEFT OUTER JOIN CurrAccPostalAddress(''TR'') StoreAddress 
		ON StoreAddress.PostalAddressID = StoreDefaultAddress.PostalAddressID
    
	 INNER JOIN cdCurrAcc WITH(NOLOCK) 
		ON	trInvoiceHeader.CurrAccTypeCode = cdCurrAcc.CurrAccTypeCode
		AND trInvoiceHeader.CurrAccCode		= cdCurrAcc.CurrAccCode
	 LEFT OUTER JOIN (SELECT InvoiceHEaderID , SalesInvoiceDate = InvoiceDate, SalesInvoiceNumber = InvoiceNumber FROM trInvoiceHeader  WITH(NOLOCK) WHERE IsReturn = 0 AND ProcessCode IN (''R'' , ''RI'')) AS SalesInvoice
		ON SalesInvoice.InvoiceHeaderID = trInvoiceHeader.ApplicationID
		AND trInvoiceHeader.ApplicationCode = ''Invoi''
		AND trInvoiceHeader.IsReturn		= 1
		LEFT OUTER JOIN tpInvoicePostalAddress WITH(NOLOCK) 
		      ON tpInvoicePostalAddress.InvoiceHeaderID = trInvoiceHeader.InvoiceHeaderID 
 WHERE HeaderID = @p0', N'@p0 uniqueidentifier', @p0=@HeaderID
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetInvoiceGorsel]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetInvoiceGorsel 'M01'
CREATE PROCEDURE [dbo].[MSG_GetInvoiceGorsel]
  (@StoreCode nvarchar(50))
AS
select InvoiceID=UPPER(AllInvoices.InvoiceHeaderID)
,[Müşteri Adı] =CurrAccDescription
,Fatura =InvoiceNumber
,Açıklama =Description
,[Detaylı Açıklama]=InternalDescription
,Durumu = case When EInvoiceStatusCode = 12 then 'E-Arşiv' else 'E-Fatura' end
,InvoiceUrl =ISNULL((tpInvoiceEArchieveXML.InvoiceUrl),SPACE(0))
from AllInvoices
Left Outer Join  tpInvoiceEArchieveXML on tpInvoiceEArchieveXML.InvoiceHeaderID = AllInvoices.InvoiceHeaderID
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllInvoices.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
where ProcessCode = 'R'
and IsReturn = 0
and EInvoiceStatusCode in ('3','12')
and AllInvoices.StoreCode = @StoreCode
and AllInvoices.CreatedDate >=GETDATE()-30
Order By AllInvoices.CreatedDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIrsaliyeGorsel]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetInvoiceGorsel 'M01'
create PROCEDURE [dbo].[MSG_GetIrsaliyeGorsel]
  (@StoreCode nvarchar(50))
AS
select OrderID=UPPER(AllORders.OrderHeaderID)
,[Müşteri Adı] =CurrAccDescription
,SiparisNo =OrderNumber
,Açıklama =Description
,[Detaylı Açıklama]=InternalDescription
,Durumu = 'Faturalandırılmadı'

from AllORders
Inner Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllORders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
where ProcessCode = 'R'
and CancelQty1 = 0
and AllORders.StoreCode = @StoreCode
and AllORders.CreatedDate >=GETDATE()-30
Order By AllORders.CreatedDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetIrsaliyeGorselHeader]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetInvoiceGorsel 'M01'
create PROCEDURE [dbo].[MSG_GetIrsaliyeGorselHeader]
  (@HeaderID nvarchar(50))
AS
exec sp_executesql N'
 SELECT InvoiceNumber			= trInvoiceHeader.InvoiceNumber			
	 , InvoiceDate				= trInvoiceHeader.InvoiceDate
	 , InvoiceTime				= trInvoiceHeader.InvoiceTime
	 , IsReturn					= trInvoiceHeader.IsReturn
	 , Series					= trInvoiceHeader.Series
	 , SeriesNumber				= trInvoiceHeader.SeriesNumber
	 , CurrAccCode				= trInvoiceHeader.CurrAccCode
	 , FirstLastName			= CASE WHEN trInvoiceHeader.CurrAccTypeCode IN (4,8) THEN  ISNULL(CASE InvoicePostalAddress.FirstLastName WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.FirstLastName  END   , cdCurrAcc.FirstLastName)
									   WHEN trInvoiceHeader.CurrAccTypeCode = 3 THEN ISNULL(CASE InvoicePostalAddress.CompanyName WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CompanyName  END   , ISNULL((SELECT CurrAccDescription FROM cdCurrAccDesc WITH(NOLOCK) WHERE cdCurrAccDesc.CurrAccTypeCode = cdCurrAcc.CurrAccTypeCode AND cdCurrAccDesc.CurrAccCode = cdCurrAcc.CurrAccCode AND cdCurrAccDesc.LangCode =''TR''),SPACE(0))) END
	 , FullName					= cdCurrAcc.FullName
	 , Patronym					= cdCurrAcc.Patronym
	 , PassportNum			= ISNULL(prCurrAccPersonalInfo.PassportNum, SPACE(0))
	 , TaxOffice			= ISNULL((SELECT TaxOfficeDescription FROM cdTaxOfficeDesc WITH(NOLOCK) WHERE cdTaxOfficeDesc.TaxOfficeCode = cdCurrAcc.TaxOfficeCode AND cdTaxOfficeDesc.LangCode =''TR'')	, SPACE(0)) 
	 , TaxNumber			= cdCurrAcc.TaxNumber
	 , IdentityNum			= cdCurrAcc.IdentityNum

	 , BillingAddress_CompanyName	= COALESCE(tpInvoicePostalAddress.CompanyName,InvoicePostalAddress.CompanyName	, SPACE(0)) 
	 , BillingAddress_Address		= COALESCE(tpInvoicePostalAddress.Address,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.Address END				, CurrAccPostalAddress.Address	, SPACE(0)) 
	 , BillingAddress_District		= COALESCE((SELECT DistrictDescription FROM cdDistrictDesc WITH(NOLOCK) WHERE LangCode =''TR'' and cdDistrictDesc.DistrictCode = ISNULL(tpInvoicePostalAddress.DistrictCode, SPACE(0))),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.DistrictDescription END	, CurrAccPostalAddress.DistrictDescription	, SPACE(0)) 
	 , BillingAddress_City			= COALESCE((SELECT CityDescription FROM cdCityDesc WITH(NOLOCK) WHERE LangCode =''TR'' and cdCityDesc.CityCode = tpInvoicePostalAddress.CityCode),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CityDescription END		, CurrAccPostalAddress.CityDescription		, SPACE(0)) 
	 , BillingAddress_Country		= COALESCE((SELECT CountryDescription  FROM cdCountryDesc WITH(NOLOCK)	WHERE cdCountryDesc.CountryCode		= ISNULL(tpInvoicePostalAddress.CountryCode, SPACE(0)) AND cdCountryDesc.LangCode =''TR''),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.CountryDescription END	, CurrAccPostalAddress.CountryDescription	, SPACE(0)) 
	 , BillingAddress_ZipCode		= COALESCE(tpInvoicePostalAddress.ZipCode,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.ZipCode END				, CurrAccPostalAddress.ZipCode	, SPACE(0)) 
	 , BillingAddress_TaxOffice		= COALESCE((SELECT TaxOfficeDescription FROM cdTaxOfficeDesc WITH(NOLOCK) WHERE cdTaxOfficeDesc.TaxOfficeCode = ISNULL(tpInvoicePostalAddress.TaxOfficeCode, SPACE(0)) AND cdTaxOfficeDesc.LangCode =''TR''),CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.TaxOfficeDescription END	, CurrAccPostalAddress.TaxOfficeDescription , SPACE(0)) 
	 , BillingAddress_TaxNumber		= COALESCE(tpInvoicePostalAddress.TaxNumber,CASE InvoicePostalAddress.Address WHEN SPACE(0) THEN NULL ELSE InvoicePostalAddress.TaxNumber END			, CurrAccPostalAddress.TaxNumber , SPACE(0)) 
	 , BillingAddress_IdentityNum	= COALESCE(tpInvoicePostalAddress.IdentityNum,cdCurrAcc.IdentityNum, SPACE(0)) 
	 

	 , ContactTypeCode			= ISNULL(prCurrAccContact.ContactTypeCode , SPACE(0))
	 , ContactFirstLastName		= ISNULL(prCurrAccContact.FirstLastName , SPACE(0))
	 
	 , OfficeCode				= trInvoiceHeader.OfficeCode
	 , OfficeDescription		= ISNULL((SELECT OfficeDescription FROM cdOfficeDesc WITH(NOLOCK) WHERE cdOfficeDesc.OfficeCode = trInvoiceHeader.OfficeCode AND cdOfficeDesc.LangCode =''TR'') , SPACE(0))
	 , StoreCode				= trInvoiceHeader.StoreCode
	 , StoreDescription			= ISNULL((SELECT CurrAccDescription FROM cdCurrAccDesc WITH(NOLOCK) WHERE cdCurrAccDesc.CurrAccTypeCode = 5 AND cdCurrAccDesc.CurrAccCode = trInvoiceHeader.StoreCode AND cdCurrAccDesc.LangCode =''TR'') , SPACE(0))
	 , StoreAddress_Address		= ISNULL(StoreAddress.Address	, SPACE(0)) 
	 , StoreAddress_District	= ISNULL(StoreAddress.DistrictDescription	, SPACE(0)) 
	 , StoreAddress_City		= ISNULL(StoreAddress.CityDescription		, SPACE(0)) 
	 , StoreAddress_Country		= ISNULL(StoreAddress.CountryDescription	, SPACE(0)) 
	 , StoreAddress_ZipCode		= ISNULL(StoreAddress.ZipCode				, SPACE(0)) 
	 , StoreAddress_TaxOffice	= ISNULL(StoreAddress.TaxOfficeDescription	, SPACE(0)) 
	 , StoreAddress_TaxNumber	= ISNULL(StoreAddress.TaxNumber	, SPACE(0)) 
	 , WarehouseCode			= trInvoiceHeader.WarehouseCode
	 , WarehouseDescription		= ISNULL((SELECT WarehouseDescription FROM cdWarehouseDesc WITH(NOLOCK) WHERE cdWarehouseDesc.WarehouseCode = trInvoiceHeader.WarehouseCode AND cdWarehouseDesc.LangCode =''TR'') , SPACE(0))
	 , LastUpdatedUserName		= trInvoiceHeader.LastUpdatedUserName
	 , LastUpdatedDate			= trInvoiceHeader.LastUpdatedDate
	 , CashierFirstLastName		= ISNULL((SELECT FirstName + SPACE(1) + LastName FROM NebimV3Master..cdUser WHERE cdUser.UserGroupCode = SUBSTRING(trInvoiceHeader.LastUpdatedUserName,1,5) AND cdUser.UserName = SUBSTRING(trInvoiceHeader.LastUpdatedUserName,6,15)), SPACE(0))
	 , SalesInvoiceNumber		= ISNULL(SalesInvoice.SalesInvoiceNumber , SPACE(0))
	 , SalesInvoiceDate			= ISNULL(SalesInvoice.SalesInvoiceDate , SPACE(0))
	 , Invoice.*

 FROM 
 (
 SELECT 
	   SortOrder				= trInvoiceLine.SortOrder
	 , ItemCode					= trInvoiceLine.ItemCode
	 , ItemDescription			= ISNULL(cdItemDesc.ItemDescription,SPACE(0))
	 , ColorCode				= trInvoiceLine.ColorCode
	 , ColorDescription			= ISNULL(cdColorDesc.ColorDescription , SPACE(0))
	 , ItemDim1Code				= trInvoiceLine.ItemDim1Code
	 , ItemDim2Code				= trInvoiceLine.ItemDim2Code
	 , ItemDim3Code				= trInvoiceLine.ItemDim3Code
	 , SerialNumber				= COALESCE(ShipmentSerialNumbers.SerialNumber , InvoiceSerialNumbers.SerialNumber, SPACE(0))
	 
	 , UnitOfMeasureCode1	= cdItem.UnitOfMeasureCode1
	 , UnitOfMeasureCode2	= cdItem.UnitOfMeasureCode2
	 , UnitConvertRate		= cdItem.UnitConvertRate		

	 , VatCode				= trInvoiceLine.VatCode
	 , VatRate				= trInvoiceLine.VatRate
	 , PCTCode				= trInvoiceLine.PCTCode
	 , PCTRate				= trInvoiceLine.PCTRate

	 , Qty1						= ABS(trInvoiceLine.Qty1)
	 , Qty2						= ABS(trInvoiceLine.Qty2)
	 , Price					= trInvoiceLine.Price
	 , Doc_Price				= ISNULL(trInvoiceLineCurrencyDoc.Price , 0)
	 , Doc_PriceVI				= ISNULL(trInvoiceLineCurrencyDoc.PriceVI , 0)
	 , Loc_Price				= ISNULL(trInvoiceLineCurrencyLoc.Price , 0)
	 , Loc_PriceVI				= ISNULL(trInvoiceLineCurrencyLoc.PriceVI , 0)


     , LineDescription          = trInvoiceLine.LineDescription
	 , Description				= trInvoiceHeader.Description
	 , SupportRequestNumber		= ISNULL(trSupportRequestHeader.SupportRequestNumber , SPACE(0))

	 , Doc_CurrencyCode			= trInvoiceLine.DocCurrencyCode
	 , Doc_AmountVI				= ABS(ISNULL(trInvoiceLineCurrencyDoc.AmountVI , 0))

	 , Doc_Amount				= ABS(ISNULL(trInvoiceLineCurrencyDoc.Amount , 0))
	 , Doc_LDiscount1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.LDiscount1 , 0))
	 , Doc_LDiscount2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.LDiscount2 , 0))			
	 , Doc_LDiscountTotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.LDiscount1 + trInvoiceLineCurrencyDoc.LDiscount2 + trInvoiceLineCurrencyDoc.LDiscount3 + trInvoiceLineCurrencyDoc.LDiscount4 + trInvoiceLineCurrencyDoc.LDiscount5) , 0))
	 , Doc_TDiscount1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscount1 , 0))		
	 , Doc_TDiscount2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscount2 , 0))					
	 , Doc_TDiscountTotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.TDiscount1 + trInvoiceLineCurrencyDoc.TDiscount2 + trInvoiceLineCurrencyDoc.TDiscount3 + trInvoiceLineCurrencyDoc.TDiscount4 + trInvoiceLineCurrencyDoc.TDiscount5) , 0))

	 , Doc_LDiscountVI1			= ABS(trInvoiceLineCurrencyDoc.LDiscountVI1)
	 , Doc_LDiscountVI2			= ABS(trInvoiceLineCurrencyDoc.LDiscountVI2)			
	 , Doc_LDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.LDiscountVI1 + trInvoiceLineCurrencyDoc.LDiscountVI2 + trInvoiceLineCurrencyDoc.LDiscountVI3 + trInvoiceLineCurrencyDoc.LDiscountVI4 + trInvoiceLineCurrencyDoc.LDiscountVI5) , 0))
	 , Doc_TDiscountVI1			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscountVI1 , 0))		
	 , Doc_TDiscountVI2			= ABS(ISNULL(trInvoiceLineCurrencyDoc.TDiscountVI2 , 0))			
	 , Doc_TDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyDoc.TDiscountVI1 + trInvoiceLineCurrencyDoc.TDiscountVI2 + trInvoiceLineCurrencyDoc.TDiscountVI3 + trInvoiceLineCurrencyDoc.TDiscountVI4 + trInvoiceLineCurrencyDoc.TDiscountVI5) , 0))
	 , Doc_TaxBase				= ABS(trInvoiceLineCurrencyDoc.TaxBase)
	 , Doc_Vat					= ABS(trInvoiceLineCurrencyDoc.Vat)
	 , Doc_NetAmount			= ABS(trInvoiceLineCurrencyDoc.NetAmount)

	 , Loc_CurrencyCode			= trInvoiceHeader.LocalCurrencyCode
	 , Loc_ExchangeRate			= trInvoiceLineCurrencyLoc.ExchangeRate			
	 , Loc_AmountVI				= ABS(trInvoiceLineCurrencyLoc.AmountVI)
	 , Loc_LDiscountVI1			= ABS(trInvoiceLineCurrencyLoc.LDiscountVI1)
	 , Loc_LDiscountVI2			= ABS(trInvoiceLineCurrencyLoc.LDiscountVI2)			
	 , Loc_LDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyLoc.LDiscountVI1 + trInvoiceLineCurrencyLoc.LDiscountVI2 + trInvoiceLineCurrencyLoc.LDiscountVI3 + trInvoiceLineCurrencyLoc.LDiscountVI4 + trInvoiceLineCurrencyLoc.LDiscountVI5) , 0))
	 , Loc_TDiscountVI1			= ABS(trInvoiceLineCurrencyLoc.TDiscountVI1)		
	 , Loc_TDiscountVI2			= ABS(trInvoiceLineCurrencyLoc.TDiscountVI2)			
	 , Loc_TDiscountVITotal		= ABS(ISNULL((trInvoiceLineCurrencyLoc.TDiscountVI1 + trInvoiceLineCurrencyLoc.TDiscountVI2 + trInvoiceLineCurrencyLoc.TDiscountVI3 + trInvoiceLineCurrencyLoc.TDiscountVI4 + trInvoiceLineCurrencyLoc.TDiscountVI5) , 0))
	 , Loc_TaxBase				= ABS(trInvoiceLineCurrencyLoc.TaxBase)
	 , Loc_Vat					= ABS(trInvoiceLineCurrencyLoc.Vat)
	 , Loc_NetAmount			= ABS(trInvoiceLineCurrencyLoc.NetAmount)

	 , TaxRefund				= ABS(trInvoiceHeader.TaxRefund )
	 , TaxTypeCode				= trInvoiceHeader.TaxTypeCode

	 , PaymentTypeCode = 0
	 , PaymentTypeDescription = SPACE(0)
	 , PaymentProviderCode			= SPACE(0)
	 , PaymentProviderDescription	= SPACE(0)
	 , CreditCardTypeCode = SPACE(0)
	 , CreditCardTypeDescription = SPACE(0)
	 , AcquirerBankCode			= SPACE(0)
	 , AcquirerBankDescription	= SPACE(0)
	 , IssuerBankCode			= SPACE(0)
	 , IssuerBankDescription	= SPACE(0)
	 , CreditCardNum = SPACE(0)
	 , OrderNumber = SPACE(0)
	 , CreditCardInstallmentCount = 0
	 , PaymentCurrencyCode = SPACE(0)
	 , Doc_Payment = 0
	 , PaymentExchangeRate = 0
	 , Loc_Payment = 0
	 , GiftCardRemainingAmount = 0
	 , FirstValidDate				= SPACE(0)
	 , LastValidDate				= SPACE(0)

	 , InstallmentDueDate		= ''19000101''
	 , InstallmentDoc_Amount	= 0
	 , trInvoiceLine.SalespersonCode	 
	 , SalespersonFirstLastName = (SELECT FirstLastName FROM cdSalesperson WITH(NOLOCK) WHERE cdSalesperson.SalespersonCode	= trInvoiceLine.SalespersonCode	 )
	 , Type						= 1
	 , HeaderID					= trInvoiceLine.InvoiceHeaderID
	 , LineID					= trInvoiceLine.InvoiceLineID
	 , ApplicationCode			= trInvoiceHeader.ApplicationCode
	 , ApplicationID			= trInvoiceHeader.ApplicationID
	 
	 , cdItem.ProductHierarchyID 
	 , ProductHierarchyLevel01
     , ProductHierarchyLevel02
     , ProductHierarchyLevel03
     , ProductHierarchyLevel04
     , ProductHierarchyLevel05
     , ProductHierarchyLevel06
     , ProductHierarchyLevel07
     , ProductHierarchyLevel08
     , ProductHierarchyLevel09
     , ProductHierarchyLevel10

	 , ProductHierarchyLevelCode01
	 , ProductHierarchyLevelCode02
	 , ProductHierarchyLevelCode03
	 , ProductHierarchyLevelCode04
	 , ProductHierarchyLevelCode05
	 , ProductHierarchyLevelCode06
	 , ProductHierarchyLevelCode07
	 , ProductHierarchyLevelCode09
	 , ProductHierarchyLevelCode10
	 , trInvoiceLine.UsedBarcode
FROM trInvoiceLine  WITH(NOLOCK)
	 INNER JOIN trInvoiceHeader WITH (NOLOCK) 
		ON trInvoiceHeader.InvoiceHeaderID = trInvoiceLine.InvoiceHeaderID
	 LEFT OUTER JOIN trInvoiceLineCurrency AS trInvoiceLineCurrencyDoc WITH (NOLOCK) 
		ON trInvoiceLineCurrencyDoc.InvoiceLineID = trInvoiceLine.InvoiceLineID 
		AND trInvoiceLineCurrencyDoc.CurrencyCode =  trInvoiceLine.DocCurrencyCode   
	 LEFT OUTER JOIN trInvoiceLineCurrency AS trInvoiceLineCurrencyLoc WITH (NOLOCK) 
		ON trInvoiceLineCurrencyLoc.InvoiceLineID = trInvoiceLine.InvoiceLineID 
		AND trInvoiceLineCurrencyLoc.CurrencyCode = trInvoiceHeader.LocalCurrencyCode 
	  LEFT OUTER JOIN cdItemDesc				WITH(NOLOCK)	
		ON cdItemDesc.ItemTypeCode = trInvoiceLine.ItemTypeCode AND cdItemDesc.ItemCode = trInvoiceLine.ItemCode AND cdItemDesc.LangCode =''TR''
	 LEFT OUTER JOIN trSupportRequestHeader WITH(NOLOCK) 
		ON trSupportRequestHeader.SupportRequestHeaderID = trInvoiceLine.SupportRequestHeaderID
	 LEFT OUTER JOIN cdColorDesc	WITH(NOLOCK)
		ON cdColorDesc.ColorCode = trInvoiceLine.ColorCode
		AND cdColorDesc.LangCode =''TR''
	 INNER JOIN cdItem WITH(NOLOCK)
		ON cdItem.ItemTypeCode	= trInvoiceLine.ItemTypeCode
		AND cdItem.ItemCode		= trInvoiceLine.ItemCode
	 INNER JOIN ProductHierarchy(''TR'') 
		ON ProductHierarchy.ProductHierarchyID			= cdItem.ProductHierarchyID	

	LEFT OUTER JOIN stItemSerialNumber ShipmentSerialNumbers WITH(NOLOCK)	ON trInvoiceLine.ShipmentLineID = ShipmentSerialNumbers.ShipmentLineID 

	LEFT OUTER JOIN stItemSerialNumber InvoiceSerialNumbers WITH(NOLOCK)	ON trInvoiceLine.InvoiceLineID = InvoiceSerialNumbers.InvoiceLineID 
UNION All
 SELECT 
	   SortOrder				= 0
	 , ItemCode					= SPACE(0)
	 , ItemDescription			= SPACE(0)
	 , ColorCode				= SPACE(0)
	 , ColorDescription			= SPACE(0)
	 , ItemDim1Code				= SPACE(0)
	 , ItemDim2Code				= SPACE(0)
	 , ItemDim3Code				= SPACE(0)
	 , SerialNumber				= SPACE(0)

	 , UnitOfMeasureCode1	= SPACE(0)
	 , UnitOfMeasureCode2	= SPACE(0)
	 , UnitConvertRate		= SPACE(0)

	 , VatCode				= SPACE(0)
	 , VatRate				= SPACE(0)
	 , PCTCode				= SPACE(0)
	 , PCTRate				= SPACE(0)

	 , Qty1						= 0
	 , Qty2						= 0
	 , Price					= 0
	 , Doc_Price				= 0
	 , Doc_PriceVI				= 0
	 , Loc_Price				= 0
	 , Loc_PriceVI				= 0

	 , LineDescription          = SPACE(0)
	 , Description		        = SPACE(0)
	 , SupportRequestNumber		= SPACE(0)
	 , Doc_CurrencyCode			= SPACE(0)
	 , Doc_AmountVI				= 0

	 , Doc_Amount				= 0
	 , Doc_LDiscount1			= 0
	 , Doc_LDiscount2			= 0	
	 , Doc_LDiscountTotal		= 0
	 , Doc_TDiscount1			= 0	
	 , Doc_TDiscount2			= 0			
	 , Doc_TDiscountTotal		= 0

	 , Doc_LDiscountVI1			= 0
	 , Doc_LDiscountVI2			= 0	
	 , Doc_LDiscountVITotal		= 0
	 , Doc_TDiscountVI1			= 0	
	 , Doc_TDiscountVI2			= 0			
	 , Doc_TDiscountVITotal		= 0
	 , Doc_TaxBase				= 0
	 , Doc_Vat					= 0
	 , Doc_NetAmount			= 0
	 , Loc_CurrencyCode			= SPACE(0)
	 , Loc_ExchangeRate			= 0
	 , Loc_AmountVI				= 0
	 , Loc_LDiscountVI1			= 0
	 , Loc_LDiscountVI2			= 0	
	 , Loc_LDiscountVITotal		= 0
	 , Loc_TDiscountVI1			= 0	
	 , Loc_TDiscountVI2			= 0			
	 , Loc_TDiscountVITotal		= 0
	 , Loc_TaxBase				= 0
	 , Loc_Vat					= 0
	 , Loc_NetAmount			= 0
	 , TaxRefund				= 0
	 , TaxTypeCode				= 0

	 , PaymentTypeCode				= trPaymentLine.PaymentTypeCode 
									* CASE WHEN ( (trPaymentLine.CashLineID IS NOT NULL AND trCashHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.CreditCardPaymentLineID IS NOT NULL AND trCreditCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.GiftCardPaymentLineID IS NOT NULL AND trGiftCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.OtherPaymentLineID IS NOT NULL AND trOtherPaymentHeader.ApplicationCode = N''Order'')) THEN -1 ELSE 1 END
	 , PaymentTypeDescription		= CASE WHEN ( (trPaymentLine.CashLineID IS NOT NULL AND trCashHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.CreditCardPaymentLineID IS NOT NULL AND trCreditCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.GiftCardPaymentLineID IS NOT NULL AND trGiftCardPaymentHeader.ApplicationCode = N''Order'')
												OR (trPaymentLine.OtherPaymentLineID IS NOT NULL AND trOtherPaymentHeader.ApplicationCode = N''Order'')) THEN 
													(CASE WHEN trPaymentLine.PaymentTypeCode <> 6 AND ISNULL(trPaymentLineCurrencyLoc.Payment, 0) < 0 THEN dbo.fn_GetFieldName(N''ReturnRetailDeposit'',''TR'')  ELSE  dbo.fn_GetFieldName(N''RetailDeposit'',''TR'') END) + '' - '' ELSE SPACE(0) END
									+  ISNULL(bsPaymentTypeDesc.PaymentTypeDescription , SPACE(0))									
	 , PaymentProviderCode			= ISNULL(trOtherPaymentHeader.PaymentProviderCode, SPACE(0))
	 , PaymentProviderDescription	= ISNULL((SELECT PaymentProviderDescription FROM cdPaymentProviderDesc WITH(NOLOCK) WHERE cdPaymentProviderDesc.LangCode =''TR'' AND cdPaymentProviderDesc.PaymentProviderCode = trOtherPaymentHeader.PaymentProviderCode), SPACE(0))
	 
	 , CreditCardTypeCode			= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(trCreditCardPaymentLine.CreditCardTypeCode, SPACE(0))
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(cdGiftCard.ItemCode, SPACE(0))
											ELSE SPACE(0) 
									  END
	 , CreditCardTypeDescription	= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(cdCreditCardTypeDesc.CreditCardTypeDescription, SPACE(0))
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(cdItemDesc.ItemDescription, SPACE(0))
											ELSE SPACE(0) 
									  END
	 , AcquirerBankCode				= ISNULL(trCreditCardPaymentLine.AcquirerBankCode, SPACE(0))
	 , AcquirerBankDescription		= ISNULL((SELECT BankDescription FROM cdBankDesc WITH(NOLOCK) WHERE cdBankDesc.BankCode = trCreditCardPaymentLine.AcquirerBankCode AND cdBankDesc.LangCode =''TR''), SPACE(0))
	 , IssuerBankCode				= ISNULL(trCreditCardPaymentLine.IssuerBankCode, SPACE(0))
	 , IssuerBankDescription		= ISNULL((SELECT BankDescription FROM cdBankDesc WITH(NOLOCK) WHERE cdBankDesc.BankCode = trCreditCardPaymentLine.IssuerBankCode AND cdBankDesc.LangCode =''TR''), SPACE(0))
	 
	 , CreditCardNum				= CASE	WHEN trPaymentLine.PaymentTypeCode = 2 THEN ISNULL(trCreditCardPaymentLine.CreditCardNum, SPACE(0))		
											WHEN trPaymentLine.PaymentTypeCode IN (3,7) THEN ISNULL(trGiftCardPaymentLine.SerialNumber, SPACE(0))
											ELSE SPACE(0)
									  END		
	 , OrderNumber					= CASE WHEN COALESCE(trCashHeader.ApplicationCode,trCreditCardPaymentHeader.ApplicationCode,trGiftCardPaymentHeader.ApplicationCode, SPACE(0)) = N''Order'' THEN	  COALESCE(trCashHeader.RefNumber,trCreditCardPaymentHeader.RefNumber,trGiftCardPaymentHeader.RefNumber, SPACE(0))	  ELSE SPACE(0) END
	 , CreditCardInstallmentCount	= ISNULL(trCreditCardPaymentLine.CreditCardInstallmentCount, 0)
	 , PaymentCurrencyCode			= trPaymentLine.DocCurrencyCode
	 , Doc_Payment					= CASE WHEN trPaymentLine.PaymentTypeCode IN(''4'',''5'') AND trInvoiceHeader.IsReturn =1 THEN ISNULL(trPaymentLineCurrencyDoc.Payment, 0) *( -1 )ELSE  ISNULL(trPaymentLineCurrencyDoc.Payment, 0) END  
	 , PaymentExchangeRate			= ISNULL(trPaymentLineCurrencyLoc.ExchangeRate , 0)
	 , Loc_Payment					= CASE WHEN trPaymentLine.PaymentTypeCode IN(''4'',''5'') AND trInvoiceHeader.IsReturn =1 THEN ISNULL(trPaymentLineCurrencyLoc.Payment, 0) *( -1 )ELSE  ISNULL(trPaymentLineCurrencyLoc.Payment, 0) END 
	 , GiftCardRemainingAmount		= ISNULL(cdGiftCard.Amount,0) - ISNULL(cdGiftCard.UsedAmount,0) 
	 , FirstValidDate				= ISNULL(cdGiftCard.FirstValidDate,SPACE(0))
	 , LastValidDate				= ISNULL(cdGiftCard.LastValidDate,SPACE(0))
	 , InstallmentDueDate		= ''19000101''
	 , InstallmentDoc_Amount	= 0
	 , SalespersonCode			= SPACE(0)
	 , SalespersonFirstLastName = SPACE(0)
	 , Type						= 2
	 , HeaderID					= trDebitHeader.ApplicationID
	 , LineID					= ''00000000-0000-0000-0000-000000000000''
	 , ApplicationCode			= trDebitHeader.ApplicationCode
	 , ApplicationID			= trDebitHeader.ApplicationID

	 , ProductHierarchyID	   = SPACE(0)
	 , ProductHierarchyLevel01 = SPACE(0)
     , ProductHierarchyLevel02 = SPACE(0)
     , ProductHierarchyLevel03 = SPACE(0)
     , ProductHierarchyLevel04 = SPACE(0)
     , ProductHierarchyLevel05 = SPACE(0)
     , ProductHierarchyLevel06 = SPACE(0)
     , ProductHierarchyLevel07 = SPACE(0)
     , ProductHierarchyLevel08 = SPACE(0)
     , ProductHierarchyLevel09 = SPACE(0)
     , ProductHierarchyLevel10 = SPACE(0)

	 , ProductHierarchyLevelCode01 = SPACE(0)
	 , ProductHierarchyLevelCode02 = SPACE(0)
	 , ProductHierarchyLevelCode03 = SPACE(0)
	 , ProductHierarchyLevelCode04 = SPACE(0)
	 , ProductHierarchyLevelCode05 = SPACE(0)
	 , ProductHierarchyLevelCode06 = SPACE(0)
	 , ProductHierarchyLevelCode07 = SPACE(0)
	 , ProductHierarchyLevelCode09 = SPACE(0)
	 , ProductHierarchyLevelCode10 = SPACE(0)
	 , UsedBarcode  = SPACE(0)
	FROM trPaymentLine WITH(NOLOCK)
		INNER JOIN trDebitLine WITH(NOLOCK) 
			ON trDebitLine.DebitLineID = trPaymentLine.DebitLineID
		INNER JOIN trDebitHeader WITH(NOLOCK)
			ON trDebitHeader.DebitHeaderID = trDebitLine.DebitHeaderID
			AND trDebitHeader.ApplicationCode = N''Invoi''
		INNER JOIN trPaymentHeader WITH (NOLOCK)   
			ON trPaymentHeader.PaymentHeaderID = trPaymentLine.PaymentHeaderID
		LEFT OUTER JOIN trPaymentLineCurrency AS trPaymentLineCurrencyDoc WITH (NOLOCK) 
			ON trPaymentLineCurrencyDoc.PaymentLineID = trPaymentLine.PaymentLineID 
			AND trPaymentLineCurrencyDoc.CurrencyCode = trPaymentLine.DocCurrencyCode 
		LEFT OUTER JOIN trPaymentLineCurrency AS trPaymentLineCurrencyLoc WITH (NOLOCK) 
			ON trPaymentLineCurrencyLoc.PaymentLineID = trPaymentLine.PaymentLineID 
			AND trPaymentLineCurrencyLoc.CurrencyCode = trPAymentHeader.LocalCurrencyCode 
		LEFT OUTER JOIN trCashLine WITH(NOLOCK)
			ON trCashLine.CashLineID = trPaymentLine.CashLineID
		LEFT OUTER JOIN trCashHeader WITH(NOLOCK)
			ON trCashHeader.CashHeaderID = trCashLine.CashHeaderID
		LEFT OUTER JOIN trCreditCardPaymentLine WITH(NOLOCK)
			ON trCreditCardPaymentLine.CreditCardPaymentLineID = trPaymentLine.CreditCardPaymentLineID
		LEFT OUTER JOIN trCreditCardPaymentHeader WITH(NOLOCK)
			ON trCreditCardPaymentHeader.CreditCardPaymentHeaderID = trCreditCardPaymentLine.CreditCardPaymentHeaderID
		LEFT OUTER JOIN trGiftCardPAymentLine WITH(NOLOCK)
			ON trGiftCardPaymentLine.GiftCardPaymentLineID = trPaymentLine.GiftCardPaymentLineID
		LEFT OUTER JOIN trGiftCardPaymentHeader WITH(NOLOCK)
			ON trGiftCardPaymentHeader.GiftCardPaymentHeaderID = trGiftCardPAymentLine.GiftCardPaymentHeaderID
		LEFT OUTER JOIN trOtherPaymentLine WITH(NOLOCK)
			ON trOtherPaymentLine.OtherPaymentLineID = trPaymentLine.OtherPaymentLineID
		LEFT OUTER JOIN trOtherPaymentHeader WITH(NOLOCK)
			ON trOtherPaymentHeader.OtherPAymentHeaderID = trOtherPaymentLine.OtherPaymentHeaderID
	     LEFT OUTER JOIN bsPaymentTypeDesc			WITH(NOLOCK) ON bsPaymentTypeDesc.PaymentTypeCode = trPaymentLine.PaymentTypeCode AND bsPaymentTypeDesc.LangCode =''TR''
	     LEFT OUTER JOIN cdCreditCardTypeDesc		WITH(NOLOCK) ON cdCreditCardTypeDesc.CreditCardTypeCode = ISNULL(trCreditCardPaymentLine.CreditCardTypeCode,SPACE(0)) AND cdCreditCardTypeDesc.LangCode =''TR''
		 LEFT OUTER JOIN cdGiftCard					WITH(NOLOCK) ON cdGiftCard.SerialNumber = trGiftCardPAymentLine.SerialNumber
		 LEFT OUTER JOIN cdItemDesc					WITH(NOLOCK) ON cdItemDesc.ItemTypeCode = cdGiftCard.ItemTypeCode AND cdItemDesc.ItemCode = cdGiftCard.ItemCode AND cdItemDesc.LangCode =''TR''
		 INNER JOIN trInvoiceHeader					WITH(NOLOCK) ON trDebitHeader.ApplicationID = trInvoiceHeader.InvoiceHeaderID
UNION ALL
 SELECT 
	   SortOrder				= 0
	 , ItemCode					= SPACE(0)
	 , ItemDescription			= SPACE(0)
	 , ColorCode				= SPACE(0)
	 , ColorDescription			= SPACE(0)
	 , ItemDim1Code				= SPACE(0)
	 , ItemDim2Code				= SPACE(0)
	 , ItemDim3Code				= SPACE(0)
	 , SerialNumber				= SPACE(0)

	 , UnitOfMeasureCode1	= SPACE(0)
	 , UnitOfMeasureCode2	= SPACE(0)
	 , UnitConvertRate		= SPACE(0)

	 , VatCode				= SPACE(0)
	 , VatRate				= SPACE(0)
	 , PCTCode				= SPACE(0)
	 , PCTRate				= SPACE(0)

	 , Qty1						= 0
	 , Qty2						= 0
	 , Price					= 0
	 , Doc_Price				= 0
	 , Doc_PriceVI				= 0
	 , Loc_Price				= 0
	 , Loc_PriceVI				= 0

	 , LineDescription          = SPACE(0)
	 , Description		        = SPACE(0)
	 , SupportRequestNumber		= SPACE(0)
	 , Doc_CurrencyCode			= SPACE(0)
	 , Doc_AmountVI				= 0
	 
	 , Doc_Amount				= 0
	 , Doc_LDiscount1			= 0
	 , Doc_LDiscount2			= 0	
	 , Doc_LDiscountTotal		= 0
	 , Doc_TDiscount1			= 0	
	 , Doc_TDiscount2			= 0			
	 , Doc_TDiscountTotal		= 0

	 , Doc_LDiscountVI1			= 0
	 , Doc_LDiscountVI2			= 0	
	 , Doc_LDiscountVITotal		= 0
	 , Doc_TDiscountVI1			= 0	
	 , Doc_TDiscountVI2			= 0			
	 , Doc_TDiscountVITotal		= 0
	 , Doc_TaxBase				= 0
	 , Doc_Vat					= 0
	 , Doc_NetAmount			= 0
	 
	 , Loc_CurrencyCode			= SPACE(0)
	 , Loc_ExchangeRate			= 0
	 , Loc_AmountVI				= 0
	 , Loc_LDiscountVI1			= 0
	 , Loc_LDiscountVI2			= 0	
	 , Loc_LDiscountVITotal		= 0
	 , Loc_TDiscountVI1			= 0	
	 , Loc_TDiscountVI2			= 0			
	 , Loc_TDiscountVITotal		= 0
	 , Loc_TaxBase				= 0
	 , Loc_Vat					= 0
	 , Loc_NetAmount			= 0

	 , TaxRefund				= 0
	 , TaxTypeCode				= 0

	 , PaymentTypeCode = 0
	 , PaymentTypeDescription = SPACE(0)
	 , PaymentProviderCode			= SPACE(0)
	 , PaymentProviderDescription	= SPACE(0)
	 , CreditCardTypeCode = SPACE(0)
	 , CreditCardTypeDescription = SPACE(0)
	 , AcquirerBankCode			= SPACE(0)
	 , AcquirerBankDescription	= SPACE(0)
	 , IssuerBankCode			= SPACE(0)
	 , IssuerBankDescription	= SPACE(0)
	 , CreditCardNum = SPACE(0)
	 , OrderNumber = SPACE(0)
	 , CreditCardInstallmentCount = 0
	 , PaymentCurrencyCode			= SPACE(0)
	 , Doc_Payment					= 0
	 , PaymentExchangeRate			= 0
	 , Loc_Payment					= 0
	 
	 , GiftCardRemainingAmount = 0
	 , FirstValidDate				= SPACE(0)
	 , LastValidDate				= SPACE(0)

	 , InstallmentDueDate		= trDebitLine.DueDate
	 , InstallmentDoc_Amount	= (ISNULL(trDebitLineCurrencyDoc.Debit, 0) + ISNULL(trDebitLineCurrencyDoc.Credit, 0)) - ISNULL(AllPayments.Doc_Payment,0)
	 , SalespersonCode			= SPACE(0)	 
	 , SalespersonFirstLastName = SPACE(0)
	 , Type						= 3	 
	 , HeaderID					= trDebitHeader.ApplicationID
	 , LineID					= ''00000000-0000-0000-0000-000000000000''
	 , ApplicationCode			= trDebitHeader.ApplicationCode
	 , ApplicationID			= trDebitHeader.ApplicationID
	 
	 , ProductHierarchyID	   = SPACE(0)
	 , ProductHierarchyLevel01 = SPACE(0)
     , ProductHierarchyLevel02 = SPACE(0)
     , ProductHierarchyLevel03 = SPACE(0)
     , ProductHierarchyLevel04 = SPACE(0)
     , ProductHierarchyLevel05 = SPACE(0)
     , ProductHierarchyLevel06 = SPACE(0)
     , ProductHierarchyLevel07 = SPACE(0)
     , ProductHierarchyLevel08 = SPACE(0)
     , ProductHierarchyLevel09 = SPACE(0)
     , ProductHierarchyLevel10 = SPACE(0)

	 , ProductHierarchyLevelCode01 = SPACE(0)
	 , ProductHierarchyLevelCode02 = SPACE(0)
	 , ProductHierarchyLevelCode03 = SPACE(0)
	 , ProductHierarchyLevelCode04 = SPACE(0)
	 , ProductHierarchyLevelCode05 = SPACE(0)
	 , ProductHierarchyLevelCode06 = SPACE(0)
	 , ProductHierarchyLevelCode07 = SPACE(0)
	 , ProductHierarchyLevelCode09 = SPACE(0)
	 , ProductHierarchyLevelCode10 = SPACE(0)
	 , UsedBarcode  = SPACE(0)
FROM trDebitLine  WITH(NOLOCK)
	INNER JOIN trDebitHeader WITH (NOLOCK) 
		ON trDebitHeader.DebitHeaderID = trDebitLine.DebitHeaderID
	LEFT OUTER JOIN trDebitLineCurrency AS trDebitLineCurrencyDoc WITH (NOLOCK) 
		ON trDebitLineCurrencyDoc.DebitLineID = trDebitLine.DebitLineID 
		AND trDebitLineCurrencyDoc.CurrencyCode = trDebitLine.DocCurrencyCode   
	LEFT OUTER JOIN 
	(
		SELECT DebitLineID, DocCurrencyCode, Doc_Payment = ABS(SUM(Payment))
		FROM trPaymentLine WITH(NOLOCK)
			INNER JOIN trPaymentLineCurrency WITH(NOLOCK)
				ON trPaymentLineCurrency.PaymentLineID = trPaymentLine.PaymentLineID
				AND trPaymentLineCurrency.CurrencyCode = trPaymentLine.DocCurrencyCode
		WHERE trPaymentLine.DebitLineID IS NOT NULL
		GROUP BY DebitLineID, DocCurrencyCode 		
	)
	AS AllPayments
		ON AllPayments.DebitLineID = trDebitLine.DebitLineID
	LEFT OUTER JOIN DebitATAttributesFilter
		ON DebitATAttributesFilter.DebitHeaderID = trDebitHeader.DebitHeaderID
WHERE (ISNULL(trDebitLineCurrencyDoc.Debit, 0) + ISNULL(trDebitLineCurrencyDoc.Credit, 0)) - ISNULL(AllPayments.Doc_Payment,0) > 0 AND trDebitHeader.ApplicationCode = N''Invoi''
) AS Invoice
    INNER JOIN trInvoiceHeader WITH(NOLOCK)
		ON trInvoiceHeader.InvoiceHEaderID			= Invoice.HeaderID
	LEFT OUTER JOIN prCurrAccPersonalInfo WITH(NOLOCK)
		ON prCurrAccPersonalInfo.CurrAccTypeCode	= trInvoiceHeader.CurrAccTypeCode
		AND prCurrAccPersonalInfo.CurrAccCode		= trInvoiceHeader.CurrAccCode
		AND ISNULL(prCurrAccPersonalInfo.ContactID	, ''00000000-0000-0000-0000-000000000000'')		= ISNULL(trInvoiceHeader.ContactID, ''00000000-0000-0000-0000-000000000000'')
     LEFT OUTER JOIN prCurrAccContact		WITH(NOLOCK)	
		ON prCurrAccContact.ContactID	= trInvoiceHeader.ContactID
     LEFT OUTER JOIN CurrAccPostalAddress   (''TR'')	
		ON CurrAccPostalAddress.PostalAddressID = trInvoiceHeader.BillingPostalAddressID
	 LEFT OUTER JOIN InvoicePostalAddress   (''TR'')	
		ON InvoicePostalAddress.InvoiceHeaderID = trInvoiceHeader.InvoiceHeaderID
	 LEFT OUTER JOIN prCurrAccDefault StoreDefaultAddress WITH(NOLOCK) 
		ON StoreDefaultAddress.CurrAccTypeCode = 5
		AND StoreDefaultAddress.CurrAccCode = trInvoiceHeader.StoreCode
	 LEFT OUTER JOIN CurrAccPostalAddress(''TR'') StoreAddress 
		ON StoreAddress.PostalAddressID = StoreDefaultAddress.PostalAddressID
    
	 INNER JOIN cdCurrAcc WITH(NOLOCK) 
		ON	trInvoiceHeader.CurrAccTypeCode = cdCurrAcc.CurrAccTypeCode
		AND trInvoiceHeader.CurrAccCode		= cdCurrAcc.CurrAccCode
	 LEFT OUTER JOIN (SELECT InvoiceHEaderID , SalesInvoiceDate = InvoiceDate, SalesInvoiceNumber = InvoiceNumber FROM trInvoiceHeader  WITH(NOLOCK) WHERE IsReturn = 0 AND ProcessCode IN (''R'' , ''RI'')) AS SalesInvoice
		ON SalesInvoice.InvoiceHeaderID = trInvoiceHeader.ApplicationID
		AND trInvoiceHeader.ApplicationCode = ''Invoi''
		AND trInvoiceHeader.IsReturn		= 1
		LEFT OUTER JOIN tpInvoicePostalAddress WITH(NOLOCK) 
		      ON tpInvoicePostalAddress.InvoiceHeaderID = trInvoiceHeader.InvoiceHeaderID 
 WHERE HeaderID = @p0', N'@p0 uniqueidentifier', @p0=@HeaderID
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_BPCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select EInvoiceNumber from trInvoiceheader  where ProcessCode = 'BP'
--select * from trInvoiceheader  where ProcessCode = 'BP'
--exec MSG_GetOrderForInvoiceToplu_BPCount '1-BP-2-2','AEAN13'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_BPCount]
  (@Ordernumber nvarchar(50)
  ,@BarcodeType nvarchar(50)
  )
AS

    SELECT  
	ModelType=19
	,VendorCode = DATA.CurrAccCode
	,EInvoiceNumber='BBB2024000000001'
	,InvoiceNumber = ''
	   ,CompanyCode
	 ,OfficeCode 
    ,StoreCode =Case When StoreCode = '' Then '' else StoreCode end 
    ,WareHouseCode=Case When WareHouseCode = '' Then 'M01' else WareHouseCode end 
	   ,DeliveryCompanyCode
	     ,BillingPostalAddressID
    ,ShippingPostalAddressID
	
 ,POSTerminalID = 1
   ,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'

	 ,TaxExemptionCode
	    ,Description 
		  , InternalDescription
		    ,Lines

	,IsOrderBase='true'
	


 	


  

   
   
	
    FROM
    (
        SELECT 
		oh.OrderheaderID,
        CurrAccCode=oh.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

   ,TaxExemptionCode
       ,ShipmentMethodCode=2
		
        ,Lines				=	(
		select * from (
										
										           select 
                              OrderlineID = li.OrderLineID,
									
                              
                                                            VatRate ,

										--li.VatRate,
                                     CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 	                ZTMSGInvoiceItemList.Qty1*   CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as AmountVI,
                                        ZTMSGInvoiceItemList.Qty1 AS Qty1
                                        from AllOrders li  WITH(NOLOCK)
										Left Outer Join prItembarcode on prItemBarcode.ItemCode = li.ItemCode
										and prItemBarcode.ColorCode = li.ColorCode
										and prItemBarcode.ItemDim1Code = li.ItemDim1Code

										and prItemBarcode.BarcodeTypeCode = @BarcodeType
										Inner Join ZTMSGInvoiceItemList on ZTMSGInvoiceItemList.Ordernumber = li.OrderNumber

										and ZTMSGInvoiceItemList.Barcode = prItemBarcode.Barcode
								

                                        where oh.OrderheaderID = li.OrderheaderID
										and ZTMSGInvoiceItemList.IsComplate = 1

									

										) as a
										FOR json PATH
									

                                    )
	
        ,InternalDescription
									--select * from ZTMSGTrendyolSiparis
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)

        ,Description
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode
        ,WareHouseCode
	
        FROM trORderheader oh WITH(NOLOCK)
		
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = oh.CurrAccCode
        and prCurrAccDefault.CurrAccTypeCode = 1
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = oh.CurrAccCode 
		where oh.OrderHeaderId in (select trORderheader.ORderHeaderId from trORderheader 
		Inner Join trORderline on trORderline.OrderheaderID = trORderheader.OrderHeaderID
		Inner Join stOrder on stOrder.ORderlineId = trORderline.OrderlineID) 
		and oh.OrderNumber = @Ordernumber
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault

      --select * from ZTMSGTrendyolSiparis
	  --select * from trORderheader 

	   
     )
	 
	 AS DATA

	 Group by  Data.OrderheaderID,DATA.TaxExemptionCode,InternalDescription, OrderDate, Lines, CurrAccCode, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_DB]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_DB]
  
AS
   select DataBaseNebim,IpAdres,Firma=FirmaKisaKod from ZTMSGTicUrunAcmaParametreleri
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_Item]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'

--exec MSG_GetOrderForInvoiceToplu_Item '','AEAN13'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_Item]
(@Invoicenumber nvarchar(50) , @BarcodeTypeCode nvarchar(50))
  
AS
  select OrderNumber=AllOrders.OrderNumber,cdCurrAccDesc.CurrAccCode,cdCurrAccDesc.CurrAccDescription,prItemBarcode.Barcode,AllOrders.ItemCode
  ,ColorCode=ISNULL((cdColorDesc.ColorCode),SPACE(0)),ColorDescription=ISNULL((ColorDescription),SPACE(0)),AllOrders.ItemDim1Code,AllOrders.Qty1
  ,CountQty = ISNULL((a.Qty1),0)
  from AllOrders
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = AllOrders.ColorCode
and cdColorDesc.LangCode = 'TR'
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode ='TR'
Left Outer Join prItembarcode on prItembarcode.Itemcode = AllOrders.Itemcode
and prItembarcode.Colorcode = AllOrders.ColorCode
and prItemBarcode.ItemDim1Code = AllOrders.ItemDim1Code
and prItemBarcode.BarcodeTypeCode  = @BarcodeTypeCode
Left Outer Join (select Ordernumber,Barcode,Qty1=SUM(Qty1) from ZTMSGInvoiceItemList
Group by Ordernumber,Barcode) as a on a.Ordernumber = AllOrders.OrderNumber
and a.Barcode = prItembarcode.Barcode

where 
(AllOrders.Ordernumber = @Invoicenumber or Description = @Invoicenumber or InternalDescription = @Invoicenumber)
and AllOrders.ItemCode not like 'T9%'
and @Invoicenumber != ''
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RE]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RE]
  
AS
    SELECT
	ModelType=6
	,CustomerCode = DATA.CurrAccCode
	   ,CompanyCode
	 ,OfficeCode
    ,StoreCode
    ,StoreWareHouseCode=WareHouseCode
	   ,DeliveryCompanyCode
 ,POSTerminalID = 1
   ,ShipmentMethodCode
   	,OrderDate
	 ,EMailAddress
	  ,BillingPostalAddressID
    ,ShippingPostalAddressID
	
	 ,IsSalesViaInternet='true'
   ,DocumentNumber=PaketNo
   ,Description 
   , InternalDescription	

	
    ,Lines
	,OrdersViaInternetInfo = (select SalesURL='www.trendyol.com'
	,PaymentTypeCode= 1
	,PaymentTypeDescription= 'KREDIKARTI/BANKAKARTI'
	,PaymentAgent=''
	,PaymentDate=Orderdate
	,SendDate=Orderdate for json path)
    ,Payments
   ,IsCompleted='true'
   
   
 
   
 
   

  
	


	
    FROM
    (
        SELECT 
        CurrAccCode=prCurrAccCommunication.CurrAccCode
		,OrderDate = oh.SiparisTarihi -- Eşleşen verinin OrderDate'i

   
       ,ShipmentMethodCode=2
		
        ,Lines				=	(

										
										           select 
                                  UsedBarcode=li.Barkod ,
									
                              
                                                            VatRate =  20,

										--li.VatRate,
                                     CAST(li.BirimFiyati AS DECIMAL(16,2)) as PriceVI,
									 	                  FaturalanacakTutar as AmountVI,
                                        li.Adet AS Qty1
                                        from ZTMSGTrendyolSiparis li  WITH(NOLOCK)
										
                                        where oh.SiparisNumarasi = li.SiparisNumarasi FOR json PATH
									

                                    )
	
        ,InternalDescription	=	oh.KargoKodu
        ,Payments				=	(   select  PaymentType=2, Code='', CreditCardTypeCode='TRD', InstallmentCount=1, CurrencyCode='TRY', Amount=SUM(FaturalanacakTutar) from ZTMSGTrendyolSiparis where ZTMSGTrendyolSiparis.SiparisNumarasi = oh.SiparisNumarasi
		Group by SiparisNumarasi
                                         for JSON PATH
                                    )
									--select * from ZTMSGTrendyolSiparis
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)
        ,EMailAddress = oh.EPosta
        ,Description=oh.PaketNo + '_'+oh.SiparisNumarasi
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode='SRT'
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode='M01'
        ,WareHouseCode='M02'
		,oh.PaketNo

        FROM ZTMSGTrendyolSiparis oh WITH(NOLOCK)
		Inner Join prCurrAccCommunication on prCurrAccCommunication.CommAddress = oh.EPosta
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = prCurrAccCommunication.CurrAccCode
        and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = prCurrAccCommunication.CurrAccCode 
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault

      --select * from ZTMSGTrendyolSiparis
	  --select * from trORderheader 

	   
     )
	 
	 AS DATA
	 Group by InternalDescription, OrderDate, Lines, Payments, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode,PaketNo
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnline]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_REOnline '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnline]
  (@Firma nvarchar(50))
AS
update prCurrAccPostalAddress set CountryCode = 'AZ',StateCode = 'AZ.AZ99' , CityCode = 'AZ.AZ9915' , DistrictCode='AZ.AZ99151' from prCurrAccPostalAddress where PostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where StateCode = 'TR.GDA' and CityCode = 'TR.21' and DistrictCode = 'TR.02100' )
update trOrderHeader set  TaxExemptionCode=301 from trOrderHeader where BillingPostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where CountryCode = 'AZ')


update prCurrAccPostalAddress set CountryCode = 'AZ',StateCode = 'AZ.01' , CityCode = 'AZ001' , DistrictCode='AZ001_003' from prCurrAccPostalAddress where PostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where StateCode = 'TR.GDA' and CityCode = 'TR.21' and DistrictCode = 'TR.02100' )
update trOrderHeader set  TaxExemptionCode=301 from trOrderHeader where BillingPostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where CountryCode = 'AZ')

update cdCurrAcc set IdentityNum = TaxNumber ,IsIndividualAcc = 1 from cdCurrAcc where Len(TaxNumber) >10
update cdCurrAcc set TaxNumber = '' from cdCurrAcc where Len(TaxNumber) >10


update cdCurrAcc set TaxNumber = IdentityNum,IsIndividualAcc = 0 from cdCurrAcc where Len(IdentityNum) =10
update cdCurrAcc set IdentityNum = '' from cdCurrAcc where Len(IdentityNum) =10

update cdCurrAcc set FirstName= a.FirstName , LastName = a.Lastname , IdentityNum = a.IdentityNum from cdCurrAcc 
Inner Join (
select cdCurrAcc.CurrAccCode,tpOrderPostalAddress.FirstName,tpOrderPostalAddress.LastName,tpOrderPostalAddress.IdentityNum from tpOrderPostalAddress
Inner Join trOrderHeader on trOrderHeader.OrderHeaderID = tpOrderPostalAddress.OrderHeaderID
Inner Join cdCurrAcc on cdCurrAcc.CurrAccCode = trOrderHeader.CurrAccCode
where tpOrderPostalAddress.TaxNumber = '2222222222'
) as a on a.CurrAccCode = cdCurrAcc.CurrAccCode

update tpOrderPostalAddress set IdentityNum = '22222222222',CompanyName = '' where TaxNumber = '2222222222'

update cdCurrAcc set FirstName = a.Firtname ,LastName = a.LastName from cdCurrAcc 
Inner Join (
select CurrAccCode,Firtname =SUBSTRING(CurrAccDescription,0,CHARINDEX (' ',CurrAccDescription,0)),LastName = Replace(CurrAccDescription,(SUBSTRING(CurrAccDescription,0,CHARINDEX (' ',CurrAccDescription,0))),'') from cdCurrAccDesc where CurrAccCode in (
select CurrAccCode from cdCurrAcc where IdentityNum !='' and FirstName = '')) as a on a.CurrAccCode = cdCurrAcc.CurrAccCode



update cdCurrAcc set IdentityNum = '22222222222' where IdentityNum = '2222222222'


    SELECT  
	ModelType=8
	,CustomerCode = DATA.CurrAccCode
	   ,CompanyCode
	 ,OfficeCode
    ,StoreCode
    ,WareHouseCode
	   ,DeliveryCompanyCode
	     ,BillingPostalAddressID
    ,ShippingPostalAddressID
	
 ,POSTerminalID = 1
   ,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'
	 ,IsSalesViaInternet='true'
	 ,TaxExemptionCode
	    ,Description = Case When TaxExemptionCode=301 then 'Mikro İhracat faturalarınızı e-arşiv olarak ve 301 kodu ile %0 KDVli istisna faturası olarak düzenlenmiştir.' else Description end 
		  , InternalDescription
		    ,Lines
	,SalesViaInternetInfo = (select SalesURL
	,PaymentTypeCode
	,PaymentTypeDescription
	,PaymentAgent
	,PaymentDate =GETDATE()
	,SendDate=GETDATE()	
	from tpOrdersViaInternetInfo
	where tpOrdersViaInternetInfo.ORderheaderID =  Data.OrderheaderID
	for json path)
	,SendInvoiceByEMail='true'
	 ,EMailAddress
	,IsOrderBase='true'
	


 	


  

   
   
	
    FROM
    (
        SELECT 
		oh.OrderheaderID,
        CurrAccCode=prCurrAccCommunication.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

   ,TaxExemptionCode
       ,ShipmentMethodCode=2
		
        ,Lines				=	(

										
										           select 
                                  OrderlineID=li.OrderlineID ,
									
                              
                                                            VatRate ,

										--li.VatRate,
                                     CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 	                  li.Doc_AmountVI as AmountVI,
                                        li.Qty1 AS Qty1
                                        from AllOrders li  WITH(NOLOCK)
										Inner Join stORder on StOrder.ORderlineID = li.OrderlineID
                                        where oh.OrderheaderID = li.OrderheaderID FOR json PATH
									

                                    )
	
        ,InternalDescription
									--select * from ZTMSGTrendyolSiparis
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)
        ,EMailAddress =prCurrAccCommunication.CommAddress
        ,Description
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode
        ,WareHouseCode
	
        FROM trORderheader oh WITH(NOLOCK)
		Inner Join prCurrAccCommunication on prCurrAccCommunication.CommunicationTypeCode = 3  and
		prCurrAccCommunication.CurrAccCode = oh.CurrAccCode
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = prCurrAccCommunication.CurrAccCode
        and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = prCurrAccCommunication.CurrAccCode 
		where oh.OrderHeaderId in (select trORderheader.ORderHeaderId from trORderheader 
		Inner Join trORderline on trORderline.OrderheaderID = trORderheader.OrderHeaderID
		Inner Join stOrder on stOrder.ORderlineId = trORderline.OrderlineID) 
		and oh.Documentnumber not like @Firma
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault

      --select * from ZTMSGTrendyolSiparis
	  --select * from trORderheader 

	   
     )
	 
	 AS DATA

	 Group by  Data.OrderheaderID,DATA.TaxExemptionCode,InternalDescription, OrderDate, Lines, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from trInvoiceHeader where CurrAccCode = '1-4-170065'
--exec MSG_GetOrderForInvoiceToplu_REOnlineCount '1-R-2-11840','AEAN13'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineCount]
  (@Ordernumber nvarchar(50)
  ,@BarcodeType nvarchar(50)
  )
AS
update prCurrAccPostalAddress set CountryCode = 'AZ',StateCode = 'AZ.AZ99' , CityCode = 'AZ.AZ9915' , DistrictCode='AZ.AZ99151' from prCurrAccPostalAddress where PostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where StateCode = 'TR.GDA' and CityCode = 'TR.21' and DistrictCode = 'TR.02100' )
update trOrderHeader set  TaxExemptionCode=301 from trOrderHeader where BillingPostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where CountryCode = 'AZ')


update prCurrAccPostalAddress set CountryCode = 'AZ',StateCode = 'AZ.01' , CityCode = 'AZ001' , DistrictCode='AZ001_003' from prCurrAccPostalAddress where PostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where StateCode = 'TR.GDA' and CityCode = 'TR.21' and DistrictCode = 'TR.02100' )
update trOrderHeader set  TaxExemptionCode=301 from trOrderHeader where BillingPostalAddressID in (
select PostalAddressID from prCurrAccPostalAddress where CountryCode = 'AZ')

update cdCurrAcc set IdentityNum = TaxNumber ,IsIndividualAcc = 1 from cdCurrAcc where Len(TaxNumber) >10
update cdCurrAcc set TaxNumber = '' from cdCurrAcc where Len(TaxNumber) >10


update cdCurrAcc set TaxNumber = IdentityNum,IsIndividualAcc = 0 from cdCurrAcc where Len(IdentityNum) =10
update cdCurrAcc set IdentityNum = '' from cdCurrAcc where Len(IdentityNum) =10

update cdCurrAcc set FirstName= a.FirstName , LastName = a.Lastname , IdentityNum = a.IdentityNum from cdCurrAcc 
Inner Join (
select cdCurrAcc.CurrAccCode,tpOrderPostalAddress.FirstName,tpOrderPostalAddress.LastName,tpOrderPostalAddress.IdentityNum from tpOrderPostalAddress
Inner Join trOrderHeader on trOrderHeader.OrderHeaderID = tpOrderPostalAddress.OrderHeaderID
Inner Join cdCurrAcc on cdCurrAcc.CurrAccCode = trOrderHeader.CurrAccCode
where tpOrderPostalAddress.TaxNumber = '2222222222'
) as a on a.CurrAccCode = cdCurrAcc.CurrAccCode

update tpOrderPostalAddress set IdentityNum = '22222222222',CompanyName = '' where TaxNumber = '2222222222'

update cdCurrAcc set FirstName = a.Firtname ,LastName = a.LastName from cdCurrAcc 
Inner Join (
select CurrAccCode,Firtname =SUBSTRING(CurrAccDescription,0,CHARINDEX (' ',CurrAccDescription,0)),LastName = Replace(CurrAccDescription,(SUBSTRING(CurrAccDescription,0,CHARINDEX (' ',CurrAccDescription,0))),'') from cdCurrAccDesc where CurrAccCode in (
select CurrAccCode from cdCurrAcc where IdentityNum !='' and FirstName = '')) as a on a.CurrAccCode = cdCurrAcc.CurrAccCode



update cdCurrAcc set IdentityNum = '22222222222' where IdentityNum = '2222222222'


    SELECT  
	ModelType=8
	,CustomerCode = DATA.CurrAccCode
	   ,CompanyCode
	 ,OfficeCode
    ,StoreCode
    ,WareHouseCode
	   ,DeliveryCompanyCode
	     ,BillingPostalAddressID
    ,ShippingPostalAddressID
	
 ,POSTerminalID = 1
   ,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'
	 ,IsSalesViaInternet='true'
	 ,TaxExemptionCode
	    ,Description = Case When TaxExemptionCode=301 then 'Mikro İhracat faturalarınızı e-arşiv olarak ve 301 kodu ile %0 KDVli istisna faturası olarak düzenlenmiştir.' else Description end 
		  , InternalDescription
		    ,Lines
	,SalesViaInternetInfo = (select SalesURL
	,PaymentTypeCode
	,PaymentTypeDescription
	,PaymentAgent
	,PaymentDate =GETDATE()
	,SendDate=GETDATE()	
	from tpOrdersViaInternetInfo
	where tpOrdersViaInternetInfo.ORderheaderID =  Data.OrderheaderID
	for json path)
	,SendInvoiceByEMail='true'
	 ,EMailAddress
	,IsOrderBase='true'
	


 	


  

   
   
	
    FROM
    (
        SELECT 
		oh.OrderheaderID,
        CurrAccCode=prCurrAccCommunication.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

   ,TaxExemptionCode
       ,ShipmentMethodCode=2
		
        ,Lines				=	(
		select * from (
										
										           select 
                              OrderlineID = li.OrderLineID,
									
                              
                                                            VatRate ,

										--li.VatRate,
                                     CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 	                ZTMSGInvoiceItemList.Qty1*   CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as AmountVI,
                                        ZTMSGInvoiceItemList.Qty1 AS Qty1
                                        from AllOrders li  WITH(NOLOCK)
										Left Outer Join prItembarcode on prItemBarcode.ItemCode = li.ItemCode
										and prItemBarcode.ColorCode = li.ColorCode
										and prItemBarcode.ItemDim1Code = li.ItemDim1Code

										and prItemBarcode.BarcodeTypeCode = @BarcodeType
										Inner Join ZTMSGInvoiceItemList on ZTMSGInvoiceItemList.Ordernumber = li.OrderNumber

										and ZTMSGInvoiceItemList.Barcode = prItemBarcode.Barcode
								

                                        where oh.OrderheaderID = li.OrderheaderID
										and ZTMSGInvoiceItemList.IsComplate = 1

										UNION ALL

										        select 
                             OrderlineID = li.OrderLineID,
									
                              
                                                            VatRate ,

										--li.VatRate,
                                     CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 	                li.Qty1*   CAST(li.Doc_PriceVI AS DECIMAL(16,2)) as AmountVI,
                                        li.Qty1 AS Qty1
                                        from AllOrders li  WITH(NOLOCK)
										Left Outer Join prItembarcode on prItemBarcode.ItemCode = li.ItemCode
										and prItemBarcode.ColorCode = li.ColorCode
										and prItemBarcode.ItemDim1Code = li.ItemDim1Code

										and prItemBarcode.BarcodeTypeCode = @BarcodeType
										

                                        where oh.OrderheaderID = li.OrderheaderID
										and li.ItemCode like 'T9%'

										) as a
										FOR json PATH
									

                                    )
	
        ,InternalDescription
									--select * from ZTMSGTrendyolSiparis
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)
        ,EMailAddress =prCurrAccCommunication.CommAddress
        ,Description
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode
        ,WareHouseCode
	
        FROM trORderheader oh WITH(NOLOCK)
		Inner Join prCurrAccCommunication on prCurrAccCommunication.CommunicationTypeCode = 3  and
		prCurrAccCommunication.CurrAccCode = oh.CurrAccCode
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = prCurrAccCommunication.CurrAccCode
        and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = prCurrAccCommunication.CurrAccCode 
		where oh.OrderHeaderId in (select trORderheader.ORderHeaderId from trORderheader 
		Inner Join trORderline on trORderline.OrderheaderID = trORderheader.OrderHeaderID
		Inner Join stOrder on stOrder.ORderlineId = trORderline.OrderlineID) 
		and oh.OrderNumber = @Ordernumber
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault

      --select * from ZTMSGTrendyolSiparis
	  --select * from trORderheader 

	   
     )
	 
	 AS DATA

	 Group by  Data.OrderheaderID,DATA.TaxExemptionCode,InternalDescription, OrderDate, Lines, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineReturn]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select SeriesNumber from trInvoiceHeader where IsReturn = 1
--exec MSG_GetOrderForInvoiceToplu_REOnlineReturn '1-R-7-8714'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REOnlineReturn]
  (@Invoicenumber nvarchar(50))
AS


    SELECT  
	ModelType=8
	,CustomerCode = DATA.CurrAccCode
	,CompanyCode
	,OfficeCode
    ,StoreCode
    ,WareHouseCode
	,DeliveryCompanyCode
	,BillingPostalAddressID
    ,ShippingPostalAddressID
	,Isreturn = 'true'
	,POSTerminalID = POSTerminalID
    ,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'
	
	,TaxExemptionCode
	,Description = Case When TaxExemptionCode=301 then 'Mikro İhracat faturalarınızı e-arşiv olarak ve 301 kodu ile %0 KDVli istisna faturası olarak düzenlenmiştir.' else Description end 
	, InternalDescription
	
	,Lines


 	


  

   
   
	
    FROM
    (
        SELECT 
		oh.InvoiceHeaderID,
        CurrAccCode=oh.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

   ,TaxExemptionCode
       ,ShipmentMethodCode=2
		
		,POSTerminalID
	
        ,InternalDescription
									--select * from ZTMSGTrendyolSiparis
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)

        ,Description
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode
        ,WareHouseCode
	,Lines				=	(

										
										           select 
                             
								lineID=AllInvoices.OrderLineID,
                                   UsedBarcode=Li.Barcode,
                                                            VatRate ,

										--li.VatRate,
                                     CAST(AllInvoices.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 	            CAST(AllInvoices.Doc_PriceVI AS DECIMAL(16,2)) * li.Qty1  as AmountVI,
                                        li.Qty1 AS Qty1
										,ReturnReasonCode=li.ReturnReasonCode
                                        from ZTMSGInvoiceReturnItemList li  WITH(NOLOCK)
									Inner Join AllInvoices on AllInvoices.InvoiceLineID = Li.ID
                                        where oh.InvoiceNumber = li.Ordernumber FOR json PATH
									

                                    )
        FROM trInvoiceHeader oh WITH(NOLOCK)
		
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = oh.CurrAccCode
        and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = oh.CurrAccCode 
		where oh.InvoiceNumber =  @Invoicenumber
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault

      --select * from ZTMSGTrendyolSiparis
	  --select * from trORderheader 

	   
     )
	 
	 AS DATA

	 Group by  Data.InvoiceHeaderId,DATA.TaxExemptionCode,POSTerminalID,Lines,InternalDescription, OrderDate, CurrAccCode, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_REToplu]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_REToplu]
  
AS
    SELECT
	ModelType=5
	,CustomerCode = DATA.CurrAccCode
	,CompanyCode
	,OfficeCode
    ,StoreCode
    ,WareHouseCode=WareHouseCode
	,DeliveryCompanyCode
    ,POSTerminalID = 1
    ,ShipmentMethodCode
   	,OrderDate
	,EMailAddress
	,BillingPostalAddressID
    ,ShippingPostalAddressID
	,CurrencyCode = 'TRY'
	,DocCurrencyCode 
	,IsSalesViaInternet='true'
    ,DocumentNumber=Description
    ,Description 
    , InternalDescription	

	
    ,Lines
	,OrdersViaInternetInfo = (select SalesURL='www.trendyol.com'
	,PaymentTypeCode= 1
	,PaymentTypeDescription= 'KREDIKARTI/BANKAKARTI'
	,PaymentAgent=''
	,PaymentDate=Orderdate
	,SendDate=Orderdate for json path)
    ,Payments
   ,IsCompleted='true'
   
   
 
   
 
   

  
	


	
    FROM
    (
        SELECT 
        CurrAccCode=MusteriKodu
		,OrderDate = GETDATE() -- Eşleşen verinin OrderDate'i

   
       ,ShipmentMethodCode=2
		,DocCurrencyCode = oh.CurrencyCode
        ,Lines				=	(

										
										           select 
                                  UsedBarcode=li.Barkod ,
									
                              
                                                            VatRate =  10,
DoccurrencyCode = li.CurrencyCode,
										--li.VatRate,
                                     CAST(li.ToptansatisFiyati AS DECIMAL(16,2)) as PriceVI,
									 	                  CAST(li.ToptansatisFiyati AS DECIMAL(16,2))*SUM(li.Adet) as AmountVI,
                                        SUM(li.Adet) AS Qty1
                                        from ZTMSGTrendyolSiparisYD li  WITH(NOLOCK)
										Group by  li.barkod,li.ToptansatisFiyati,li.CurrencyCode
										FOR json PATH
									

                                    )
	
        ,InternalDescription	=	oh.TakipNo
        ,Payments				=	(   select  PaymentType=2, Code='', CreditCardTypeCode='TRD', InstallmentCount=1, CurrencyCode='TRY', Amount=SUM(ToptansatisFiyati*Adet) from ZTMSGTrendyolSiparisYD where ZTMSGTrendyolSiparisYD.TakipNo = oh.TakipNo
		Group by TakipNo
                                         for JSON PATH
                                    )
									--select * from ZTMSGTrendyolSiparisYD
        ,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
        ,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
	   -- ,PostalAddress = (select Address= Address,AddressId = ADDressID,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID = oh.OrderHeaderID  for JSON PATH)
        ,EMailAddress = ''
        ,Description=oh.TakipNo
        ,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
        ,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
        ,DeliveryCompanyCode='SRT'
        ,CompanyCode=cdCurracc.CompanyCode
        ,IsSalesViaInternet=1
        ,OfficeCode =cdCurracc.OfficeCode
        ,StoreCode='M01'
        ,WareHouseCode='M02'
		--select * from trOrderHeader where ORderdate = '2023-11-08'
        FROM ZTMSGTrendyolSiparisYD oh WITH(NOLOCK)
        Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = oh.MusteriKodu
        and prCurrAccDefault.CurrAccTypeCode = 3
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = oh.MusteriKodu 
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
      --select * from prCurrAccDefault where Curracccode = '1-3-1'

      --select * from ZTMSGTrendyolSiparisYD
	  --select * from allOrders  where ORderdate = '2023-11-08'

	   
     )
	 
	 AS DATA
	 Group by InternalDescription,DATA.DocCurrencyCode, OrderDate, Lines, Payments, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
	 Order By OrderDate Desc
	 --select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_ReturnItem]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetOrderForInvoiceToplu_ReturnItem '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_ReturnItem]
(@Invoicenumber nvarchar(50))
  
AS
  select InvoiceLineID,InvoiceNumber,cdCurrAccDesc.CurrAccCode,cdCurrAccDesc.CurrAccDescription,Barcode,AllInvoices.ItemCode,cdColorDesc.ColorCode,ColorDescription,AllInvoices.ItemDim1Code,Qty1 from AllInvoices
  Left Outer Join prItemBarcode on prItemBarcode.ItemCode = AllInvoices.ItemCode
  and prItemBarcode.ColorCode = AllInvoices.ColorCode
  and prItemBarcode.ItemDim1Code = AllInvoices.ItemDim1Code
  and prItemBarcode.BarcodeTypeCode = 'AEAN13'
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = AllInvoices.ColorCode
and cdColorDesc.LangCode = 'TR'
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllInvoices.CurrAccCode
and cdCurrAccDesc.LangCode ='TR'
where 
(InvoiceNumber = @Invoicenumber or Description = @Invoicenumber or InternalDescription = @Invoicenumber)
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RShipment]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--usp_GetOrderForInvoiceToplu_RShipment 'TR'
CREATE PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RShipment]
	(@Firma nvarchar(50))
AS

	SELECT top 10
	ModelType=8
	,CustomerCode = DATA.CurrAccCode
		,CompanyCode
		,OfficeCode
	,StoreCode
	,WareHouseCode
		,DeliveryCompanyCode
			,BillingPostalAddressID
	,ShippingPostalAddressID
	
	,POSTerminalID = 1
	,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'
		,IsSalesViaInternet='true'
		,TaxExemptionCode
		,Description = Case When TaxExemptionCode=301 then 'Mikro İhracat faturalarınızı e-arşiv olarak ve 301 kodu ile %0 KDVli istisna faturası olarak düzenlenmiştir.' else Description end 
			, InternalDescription
			,Lines
	,SalesViaInternetInfo = (select SalesURL
	,PaymentTypeCode
	,PaymentTypeDescription
	,PaymentAgent
	,PaymentDate =GETDATE()
	,SendDate=GETDATE()	
	from tpOrdersViaInternetInfo
	where tpOrdersViaInternetInfo.ORderheaderID =  (Select Top 1 OrderHeaderID from AllShipmentLines
	Inner Join AllOrders on AllOrders.OrderLineID = AllShipmentLines.OrderLineID
	where AllShipmentLines.ShipmentHeaderID = DATA.ShipmentHeaderID)
	for json path)
	 ,PostalAddress 
	 ,Payments
	,IsShipmentBase='true'
	
		,SendInvoiceByEMail='true'
		,EMailAddress

	FROM
	(
		SELECT 
		oh.ShipmentHeaderID,
		CurrAccCode=prCurrAccCommunication.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

	,TaxExemptionCode=0
		,ShipmentMethodCode=2
		
		,Lines				=	(

										
													select 
									ShipmentLineID=li.ShipmentLineID ,
									li.ItemCode
									,li.ColorCode,li.ItemDim1Code
                              
															,VatRate ,

										--li.VatRate,
										CAST(allOrders.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 						allOrders.Doc_AmountVI as AmountVI,
										li.Qty1 AS Qty1
										from AllShipmentLines li  WITH(NOLOCK)
										Inner Join allOrders WITH(NOLOCK) on AllOrders.OrderLineID = li.OrderLineID
										Inner Join stShipment on stShipment.ShipmentLineID = li.ShipmentLineID
									where li.ShipmentHeaderID = oh.ShipmentHeaderID 
									and stShipment.Qty1 != 0
									FOR json PATH
									

									)
	
		,InternalDescription
									--select * from ZTMSGTrendyolSiparis
		,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
		,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
		 ,PostalAddress = (select top 1 AddressTypeCode = ADDressID,Address= Address,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID
		 in (select OrderHeaderID from AllShipmentLines
Inner Join AllOrders on AllOrders.OrderLineID = AllShipmentLines.OrderLineID
where AllShipmentLines.ShipmentHeaderID = oh.ShipmentHeaderID)
		 for JSON PATH)
		 ,Payments				=	(  	select 
							PaymentType=2, Code='', CreditCardTypeCode, InstallmentCount=1, CurrencyCode='TRY', Amount=allOrders.Doc_AmountVI

									 					
										from AllShipmentLines li  WITH(NOLOCK)
										Inner Join allOrders WITH(NOLOCK) on AllOrders.OrderLineID = li.OrderLineID
										Inner Join stShipment on stShipment.ShipmentLineID = li.ShipmentLineID
										Inner Join RetailPayments on RetailPayments.DocumentNumber = AllOrders.OrderNumber
									where li.ShipmentHeaderID = oh.ShipmentHeaderID 
									and stShipment.Qty1 != 0
                                         for JSON PATH
                                    )
									
		
		
		,EMailAddress =prCurrAccCommunication.CommAddress
		,Description
		,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
		,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
		,DeliveryCompanyCode
		,CompanyCode=cdCurracc.CompanyCode
		,IsSalesViaInternet=1
		,OfficeCode =cdCurracc.OfficeCode
		,StoreCode
		,WareHouseCode
	
		FROM trShipmentHeader oh WITH(NOLOCK)

		Inner Join prCurrAccCommunication on prCurrAccCommunication.CommunicationTypeCode = 3  and
		prCurrAccCommunication.CurrAccCode = oh.CurrAccCode
		Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = prCurrAccCommunication.CurrAccCode
		and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = prCurrAccCommunication.CurrAccCode 
		where oh.ShipmentHeaderID in (select  trShipmentHeader.ShipmentHeaderID from trShipmentHeader 
		Inner Join trShipmentLine on trShipmentLine.ShipmentHeaderID = trShipmentHeader.ShipmentHeaderID
		Inner Join stShipment on stShipment.ShipmentLineID = trShipmentLine.ShipmentLineID) 
		and oh.StoreCode = @Firma
		--and oh.Documentnumber not like @Firma
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
		--select * from prCurrAccDefault

		--select * from ZTMSGTrendyolSiparis
		--select * from trORderheader 

	   
		)
	 
		AS DATA
	where data.Lines is not null and DeliveryCompanyCode != ''
		Group by  DATA.ShipmentHeaderID,DATA.TaxExemptionCode,InternalDescription, OrderDate, Lines, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
		 ,PostalAddress 
	 ,Payments
	 Order By OrderDate Desc
		--select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderForInvoiceToplu_RShipmentID]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--usp_GetOrderForInvoiceToplu_RShipment 'TR'
Create PROCEDURE [dbo].[MSG_GetOrderForInvoiceToplu_RShipmentID]
	(@Firma nvarchar(50))
AS

	SELECT top 10
	ModelType=8
	,CustomerCode = DATA.CurrAccCode
		,CompanyCode
		,OfficeCode
	,StoreCode
	,WareHouseCode
		,DeliveryCompanyCode
			,BillingPostalAddressID
	,ShippingPostalAddressID
	
	,POSTerminalID = 1
	,ShipmentMethodCode
   	,InvoiceDate= GETDATE()
	,IsCompleted='true'
		,IsSalesViaInternet='true'
		,TaxExemptionCode
		,Description = Case When TaxExemptionCode=301 then 'Mikro İhracat faturalarınızı e-arşiv olarak ve 301 kodu ile %0 KDVli istisna faturası olarak düzenlenmiştir.' else Description end 
			, InternalDescription
			,Lines
	,SalesViaInternetInfo = (select SalesURL
	,PaymentTypeCode
	,PaymentTypeDescription
	,PaymentAgent
	,PaymentDate =GETDATE()
	,SendDate=GETDATE()	
	from tpOrdersViaInternetInfo
	where tpOrdersViaInternetInfo.ORderheaderID =  (Select Top 1 OrderHeaderID from AllShipmentLines
	Inner Join AllOrders on AllOrders.OrderLineID = AllShipmentLines.OrderLineID
	where AllShipmentLines.ShipmentHeaderID = DATA.ShipmentHeaderID)
	for json path)
	 ,PostalAddress 
	 ,Payments
	,IsShipmentBase='true'
	
		,SendInvoiceByEMail='true'
		,EMailAddress

	FROM
	(
		SELECT 
		oh.ShipmentHeaderID,
		CurrAccCode=prCurrAccCommunication.CurrAccCode
		,OrderDate =getDATE() -- Eşleşen verinin OrderDate'i

	,TaxExemptionCode=0
		,ShipmentMethodCode=2
		
		,Lines				=	(

										
													select 
									ShipmentLineID=li.ShipmentLineID ,
									li.ItemCode
									,li.ColorCode,li.ItemDim1Code
                              
															,VatRate ,

										--li.VatRate,
										CAST(allOrders.Doc_PriceVI AS DECIMAL(16,2)) as PriceVI,
									 						allOrders.Doc_AmountVI as AmountVI,
										li.Qty1 AS Qty1
										from AllShipmentLines li  WITH(NOLOCK)
										Inner Join allOrders WITH(NOLOCK) on AllOrders.OrderLineID = li.OrderLineID
										Inner Join stShipment on stShipment.ShipmentLineID = li.ShipmentLineID
									where li.ShipmentHeaderID = oh.ShipmentHeaderID 
									and stShipment.Qty1 != 0
									FOR json PATH
									

									)
	
		,InternalDescription
									--select * from ZTMSGTrendyolSiparis
		,BillingAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode AND LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'),  ' / ', (SELECT Top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID = prCurrAccDefault.BillingAddressID for JSON PATH)
		,ShipmentAddress = (select AddressId, Address, CONCAT((SELECT top 1 DistrictDescription FROM cdDistrictDesc WHERE a.DistrictCode = DistrictCode and LangCode = 'TR'), ' / ', (SELECT top 1 CityDescription FROM cdCityDesc WHERE a.CityCode = CityCode and LangCode = 'TR'), ' / ', (SELECT top 1 CountryDescription FROM cdCountryDesc WHERE a.CountryCode = CountryCode and LangCode = 'TR')) as Place from prCurrAccPostalAddress a WITH(NOLOCK) where a.PostalAddressID =  prCurrAccDefault.ShippingAddressID  for JSON PATH)
		 ,PostalAddress = (select top 1 AddressTypeCode = ADDressID,Address= Address,CityCode = CityCode,CountryCode= CountryCode,StateCode= StateCode,DistrictCode= DistrictCode,CompanyName=CompanyName,FirstName=FirstName,LastName=LastName,IdentityNum=IdentityNum,TaxNumber=TaxNumber,TaxOfficeCode=TaxOfficeCode,ZipCode=ZipCode from tpOrderPostalAddress WITH(NOLOCK) where tpOrderPostalAddress.OrderHeaderID
		 in (select OrderHeaderID from AllShipmentLines
Inner Join AllOrders on AllOrders.OrderLineID = AllShipmentLines.OrderLineID
where AllShipmentLines.ShipmentHeaderID = oh.ShipmentHeaderID)
		 for JSON PATH)
		 ,Payments				=	(  	select 
							PaymentType=2, Code='', CreditCardTypeCode, InstallmentCount=1, CurrencyCode='TRY', Amount=allOrders.Doc_AmountVI

									 					
										from AllShipmentLines li  WITH(NOLOCK)
										Inner Join allOrders WITH(NOLOCK) on AllOrders.OrderLineID = li.OrderLineID
										Inner Join stShipment on stShipment.ShipmentLineID = li.ShipmentLineID
										Inner Join RetailPayments on RetailPayments.DocumentNumber = AllOrders.OrderNumber
									where li.ShipmentHeaderID = oh.ShipmentHeaderID 
									and stShipment.Qty1 != 0
                                         for JSON PATH
                                    )
									
		
		
		,EMailAddress =prCurrAccCommunication.CommAddress
		,Description
		,BillingPostalAddressID=prCurrAccDefault.BillingAddressID
		,ShippingPostalAddressID=prCurrAccDefault.ShippingAddressID
		,DeliveryCompanyCode
		,CompanyCode=cdCurracc.CompanyCode
		,IsSalesViaInternet=1
		,OfficeCode =cdCurracc.OfficeCode
		,StoreCode
		,WareHouseCode
	
		FROM trShipmentHeader oh WITH(NOLOCK)

		Inner Join prCurrAccCommunication on prCurrAccCommunication.CommunicationTypeCode = 3  and
		prCurrAccCommunication.CurrAccCode = oh.CurrAccCode
		Left Outer Join prCurrAccDefault WITH(NOLOCK) on prCurrAccDefault.CurrAccCode = prCurrAccCommunication.CurrAccCode
		and prCurrAccDefault.CurrAccTypeCode = 4
		Inner Join cdCurracc on cdCurrAcc.CurrAccCode = prCurrAccCommunication.CurrAccCode 
		where oh.ShipmentHeaderID in (select  trShipmentHeader.ShipmentHeaderID from trShipmentHeader 
		Inner Join trShipmentLine on trShipmentLine.ShipmentHeaderID = trShipmentHeader.ShipmentHeaderID
		Inner Join stShipment on stShipment.ShipmentLineID = trShipmentLine.ShipmentLineID) 
		and oh.ShippingNumber in (select ShippingNumber from AllShipmentLines
Inner Join AllOrders on AllOrders.OrderLineID = AllShipmentLines.OrderLineID
where (AllOrders.DocumentNumber = @Firma or AllOrders.OrderNumber =@Firma or AllOrders.Description =@Firma or AllOrders.InternalDescription =@Firma))
		--and oh.Documentnumber not like @Firma
		--where oh.Fatura = 'Evet'
		--and oh.KargoKodu not in (Select InternalDescription from trInvoiceHeader)
		--select * from prCurrAccDefault

		--select * from ZTMSGTrendyolSiparis
		--select * from trORderheader 

	   
		)
	 
		AS DATA
	where data.Lines is not null and DeliveryCompanyCode != ''
		Group by  DATA.ShipmentHeaderID,DATA.TaxExemptionCode,InternalDescription, OrderDate, Lines, CurrAccCode, EMailAddress, Description, BillingAddress, ShipmentAddress, BillingPostalAddressID, ShippingPostalAddressID, DeliveryCompanyCode, CompanyCode, IsSalesViaInternet, OfficeCode, StoreCode, WareHouseCode, ShipmentMethodCode
		 ,PostalAddress 
	 ,Payments
	 Order By OrderDate Desc
		--select * from trOrderHeader
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetOrderGorsel]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetInvoiceGorsel 'M01'
CREATE PROCEDURE [dbo].[MSG_GetOrderGorsel]
  (@StoreCode nvarchar(50))
AS
select OrderID=UPPER(AllORders.OrderHeaderID)
,[Müşteri Adı] =CurrAccDescription
,SiparisNo =OrderNumber
,Açıklama =Description
,[Detaylı Açıklama]=InternalDescription
,Durumu = 'Faturalandırılmadı'

from AllORders
Inner Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllORders.CurrAccCode
and cdCurrAccDesc.LangCode = 'TR'
where ProcessCode = 'R'
and CancelQty1 = 0
and AllORders.StoreCode = @StoreCode
and AllORders.CreatedDate >=GETDATE()-30
Order By AllORders.CreatedDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturn]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
create PROCEDURE [dbo].[MSG_GetReturn]
(@Invoicenumber nvarchar(50))
  
AS
  SELECT OrderCancelReasonCode, OrderCancelReasonDescription FROM OrderCancelReason('TR')  WHERE OrderCancelReasonCode <> SPACE(0) and IsBlocked = 0
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturnSeriNO]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_GetReturnSeriNO]
(@StoreCode nvarchar(50))
  
AS
 select LastNumber,Series,OfficeCode,Storecode,Warehousecode,ProcessFlowCode,FormType from srSerialNumber
where IsDefault = 1 
and StoreCode = @StoreCode
and FormType = 1
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetReturnSeriNOUpdate]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec MSG_GetReturnSeriNO 'M01'
Create PROCEDURE [dbo].[MSG_GetReturnSeriNOUpdate]
(@StoreCode nvarchar(50))
  
AS
update srSerialNumber set LastNumber =LastNumber+1 from srSerialNumber
where 
IsDefault = 1 
and StoreCode = @StoreCode
and FormType = 1
and ProcessFlowCode = 7
and FormType = 1
GO
/****** Object:  StoredProcedure [dbo].[MSG_GetUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec usp_GetUrun '3452969287294 (4)'
CREATE PROCEDURE [dbo].[MSG_GetUrunListesi] 

AS
select top 50  * from (
select  Photo='\\192.168.2.38\Nebim Resim\'+prItemVariant.ItemCode+'\ColorPhotos\'+prItemVariant.ItemCode+'_'+prItemVariant.ColorCode+'.jpg'
,Brand=''
,UPC=''
,EAN=''
,[Manufacturer Code]=''
,UrunKodu=prItemVariant.ItemCode
,ColorCode=prItemVariant.ColorCode
,Size=prItemVariant.ItemDim1Code
,Quantity=SUM(In_qty1-Out_qty1)
,[Wholesale Price]=''
,[Retail Price]= ''
,Color=''
,Gender=''
,[Product Type]=''
,Composition=''
,Origin=''
,[Care Instructions]=''
from prItemVariant
Left Outer Join trStock on trStock.ItemCode = prItemVariant.ItemCode
and trStock.ColorCode = prItemVariant.ColorCode
and trStock.ItemDim1Code = prItemVariant.ItemDim1Code

where prItemVariant.ItemCode like 'MS%'
Group by prItemVariant.ItemCode
,prItemVariant.ColorCode
,prItemVariant.ItemDim1Code

) as a 

where a.Quantity >1
Order by a.UrunKodu
,a.ColorCode
,a.Size
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'

--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
CREATE PROCEDURE [dbo].[MSG_InvoiceItemlistCount]
(@Invoicenumber nvarchar(50) , @CurrAccCode nvarchar(50)
,@Barcode nvarchar(50)
,@Qty1 nvarchar(50)

)
  
AS
  
  Insert Into ZTMSGInvoiceItemList(OrderNumber,CurrAccCode,Barcode,Qty1,IsComplate) select @Invoicenumber,@CurrAccCode,@Barcode,@Qty1,0
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_Complated]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec MSG_GetOrderForInvoiceToplu_REOnlineCount '1-R-2-11835','AEAN13'
--delete  ZTMSGInvoiceItemList where Ordernumber ='1-R-2-11842'
--select * from ZTMSGTicSiparisKontrol where OrderDate = '2024-02-07'
--select * from trInvoiceheader where Invoicedate = '2024-02-08'
--select * from AllOrders where ORderdate = '2024-02-08'
--select * from AllInvoices where OrderLineID in (
--select * from AllOrders where OrderNumber = '1-R-2-11842')
--delete ZTMSGInvoiceItemList
---MSG_InvoiceItemlistCount
---MSG_InvoiceItemlistCount_Update
--exec MSG_GetOrderForInvoiceToplu_REOnlineCount '1-R-2-11842','AEAN13'
CREATE PROCEDURE [dbo].[MSG_InvoiceItemlistCount_Complated]
(@Invoicenumber nvarchar(50) , @BarcodeTypeCode nvarchar(50)

)
  
AS



select SiparisDurumu=
Case When SUM(CancelQty1) >0 Then 3 else 
Case When SUM(Qty1)-SUM(CountQty) = 0 Then 1 else  0 end  end

from (
  select OrderNumber=AllOrders.OrderNumber,cdCurrAccDesc.CurrAccCode,cdCurrAccDesc.CurrAccDescription,prItemBarcode.Barcode,AllOrders.ItemCode
  ,ColorCode=ISNULL((cdColorDesc.ColorCode),SPACE(0)),ColorDescription=ISNULL((ColorDescription),SPACE(0)),AllOrders.ItemDim1Code,AllOrders.Qty1
  ,CountQty = ISNULL((a.Qty1),0)
    ,AllOrders.CancelQty1
  from AllOrders
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = AllOrders.ColorCode
and cdColorDesc.LangCode = 'TR'
Left Outer Join cdCurrAccDesc on cdCurrAccDesc.CurrAccCode = AllOrders.CurrAccCode
and cdCurrAccDesc.LangCode ='TR'
Left Outer Join prItembarcode on prItembarcode.Itemcode = AllOrders.Itemcode
and prItembarcode.Colorcode = AllOrders.ColorCode
and prItemBarcode.ItemDim1Code = AllOrders.ItemDim1Code
and prItemBarcode.BarcodeTypeCode  = @BarcodeTypeCode
Left Outer Join (select Ordernumber,Barcode,Qty1=SUM(Qty1) from ZTMSGInvoiceItemList
Group by Ordernumber,Barcode) as a on a.Ordernumber = AllOrders.OrderNumber
and a.Barcode = prItembarcode.Barcode

where 
(AllOrders.Ordernumber = @Invoicenumber or Description = @Invoicenumber or InternalDescription = @Invoicenumber)
and AllOrders.ItemCode not like 'T9%'
) as a
Group by OrderNumber
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_delete]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'
---MSG_InvoiceItemlistCount
---MSG_InvoiceItemlistCount_Update
--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
Create PROCEDURE [dbo].[MSG_InvoiceItemlistCount_delete]
(@Invoicenumber nvarchar(50) 

)
  
AS
  delete  ZTMSGInvoiceItemList  where OrderNumber = @Invoicenumber
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemlistCount_Update]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'
---MSG_InvoiceItemlistCount
--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
Create PROCEDURE [dbo].[MSG_InvoiceItemlistCount_Update]
(@Invoicenumber nvarchar(50) 
)
  
AS
  Update ZTMSGInvoiceItemList set IsComplate = 1 from ZTMSGInvoiceItemList where OrderNumber = @Invoicenumber
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceItemLotlistCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'

--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
create PROCEDURE [dbo].[MSG_InvoiceItemLotlistCount]
(@Invoicenumber nvarchar(50) , @CurrAccCode nvarchar(50)
,@LotBarcode nvarchar(50)
,@Qty1 int
,@BarcodeTypeCode nvarchar(50)
)
  
AS
  
  Insert Into ZTMSGInvoiceItemList(OrderNumber,CurrAccCode,Barcode,Qty1,IsComplate) 

  
select 
@Invoicenumber,@CurrAccCode,Barcode,Qty=prLotQty.Qty*@Qty1,0
from prProductLotBarcode
Left Outer Join prLotQty on prLotQty.LotCode = prProductLotBarcode.LotCode
Left Outer Join prItemBarcode on prItemBarcode.ItemCode = prProductLotBarcode.ItemCode
and prItemBarcode.ColorCode = prProductLotBarcode.ColorCode
and prItemBarcode.ItemDim1Code = prLotQty.ItemDim1Code
and prItemBarcode.ItemDim2Code = prLotQty.ItemDim2Code
and prItemBarcode.BarcodeTypeCode = @BarcodeTypeCode
where LotBarcode = @LotBarcode
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select ReturnReasonCode from AllInvoices where Processcode = 'R' and Isreturn = 1
--select * from ZTMSGInvoiceReturnItemList where OrderDate = '2024-02-07'
--select * from AllInvoices where InvoicelineID = 'C052B437-49C0-420E-AD6A-B116007E2550'
--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
CREATE PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount]
(
@InvoiceLineID nvarchar(50),
@Invoicenumber nvarchar(50) , @CurrAccCode nvarchar(50)
,@Barcode nvarchar(50)
,@Qty1 nvarchar(50)
,@ReturnReasonCode nvarchar(50)
)
  
AS
  --delete ZTMSGInvoiceReturnItemList
  Insert Into ZTMSGInvoiceReturnItemList(ID,OrderNumber,CurrAccCode,Barcode,Qty1,IsComplate,ReturnReasonCode) select @InvoiceLineID,@Invoicenumber,@CurrAccCode,@Barcode,@Qty1,0,@ReturnReasonCode
  where @InvoiceLineID not in (select ID from ZTMSGInvoiceReturnItemList)
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount_delete]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from ZTMSGInvoiceReturnItemList where OrderDate = '2024-02-07'
---MSG_InvoiceItemlistCount
---MSG_InvoiceItemlistCount_Update
--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
create PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount_delete]
(@Invoicenumber nvarchar(50) 

)
  
AS
  delete  ZTMSGInvoiceReturnItemList  where OrderNumber = @Invoicenumber
GO
/****** Object:  StoredProcedure [dbo].[MSG_InvoiceReturnItemlistCount_Update]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from AllOrders where OrderDate = '2024-02-07'
---MSG_InvoiceItemlistCount
--exec MSG_GetOrderForInvoiceToplu_Item '343SR3859H','AEAN13'
creATE PROCEDURE [dbo].[MSG_InvoiceReturnItemlistCount_Update]
(@Invoicenumber nvarchar(50) 
)
  
AS
  Update ZTMSGInvoiceReturnItemList set IsComplate = 1 from ZTMSGInvoiceReturnItemList where OrderNumber = @Invoicenumber
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoFirmaBilgileri_DB]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec MSG_MisigoFirmaBilgileri_DB
CREATE PROCEDURE [dbo].[MSG_MisigoFirmaBilgileri_DB]
  
AS
   select DataBaseNebim,IpAdres,Firma=FirmaKisaKod from ZTMSGMisigoUrunAcmaParametreleri
   --where FirmaKisaKod = 'MAR'
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoFiyatDuzenle]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select DataBaseNebim from ZTMSGMisigoUrunAcmaParametreleri
--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_MisigoFiyatDuzenle]
  
AS

delete prItemBasePrice from prItemBasePrice
Inner Join ZTMSGUrunListMisigo on ZTMSGUrunListMisigo.Itemcode = prItemBasePrice.Itemcode
where BasePriceCode = 3
and prItembaseprice.Price != ZTMSGUrunListMisigo.MisigoWebSatis

Insert Into  prItemBasePrice(ItemTypeCode,ItemCode,CountryCode,SeasonCode,BasePriceCode,PriceDate,CurrencyCode,Price)
select ItemTypeCode=1,ZTMSGUrunListMisigo.ItemCode,CountryCode='TR',SeasonCode='',BasePriceCode=3,PriceDate=GETDATE(),CurrencyCode='TRY',Price=MisigoWebSatis from ZTMSGUrunListMisigo
Inner Join cdItem on cdItem.ItemCode = ZTMSGUrunListMisigo.Itemcode
where ZTMSGUrunListMisigo.Itemcode not in (select Itemcode from prItemBasePrice where BasePriceCode = 3)
Group by ZTMSGUrunListMisigo.ItemCode,MisigoWebSatis


delete prItemBasePrice from prItemBasePrice
Inner Join ZTMSGUrunListMisigo on ZTMSGUrunListMisigo.Itemcode = prItemBasePrice.Itemcode
where BasePriceCode = 4
and prItembaseprice.Price != ZTMSGUrunListMisigo.MisigoWebIndirimliSatis

Insert Into  prItemBasePrice(ItemTypeCode,ItemCode,CountryCode,SeasonCode,BasePriceCode,PriceDate,CurrencyCode,Price)
select ItemTypeCode=1,ZTMSGUrunListMisigo.ItemCode,CountryCode='TR',SeasonCode='',BasePriceCode=4,PriceDate=GETDATE(),CurrencyCode='TRY',Price=MisigoWebIndirimliSatis from ZTMSGUrunListMisigo
Inner Join cdItem on cdItem.ItemCode = ZTMSGUrunListMisigo.Itemcode
where ZTMSGUrunListMisigo.Itemcode not in (select Itemcode from prItemBasePrice where BasePriceCode = 4)
Group by ZTMSGUrunListMisigo.ItemCode,MisigoWebIndirimliSatis


delete prItemBasePrice from prItemBasePrice
Inner Join ZTMSGUrunListMisigo on ZTMSGUrunListMisigo.Itemcode = prItemBasePrice.Itemcode
where BasePriceCode = 6
and ZTMSGUrunListMisigo.Itemcode not like 'MS%'
and prItembaseprice.Price != ZTMSGUrunListMisigo.MisigoPazaryeriIndirimliSatis

Insert Into  prItemBasePrice(ItemTypeCode,ItemCode,CountryCode,SeasonCode,BasePriceCode,PriceDate,CurrencyCode,Price)
select ItemTypeCode=1,ZTMSGUrunListMisigo.ItemCode,CountryCode='TR',SeasonCode='',BasePriceCode=6,PriceDate=GETDATE(),CurrencyCode='TRY',Price=MisigoPazaryeriIndirimliSatis from ZTMSGUrunListMisigo
Inner Join cdItem on cdItem.ItemCode = ZTMSGUrunListMisigo.Itemcode
where ZTMSGUrunListMisigo.Itemcode not in (select Itemcode from prItemBasePrice where BasePriceCode = 6)
and ZTMSGUrunListMisigo.Itemcode not like 'MS%'
Group by ZTMSGUrunListMisigo.ItemCode,MisigoPazaryeriIndirimliSatis


GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoKategoriList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select DataBaseNebim from ZTMSGMisigoUrunAcmaParametreleri
--exec MSG_MisigoKategoriList 'LEVİDOR'
CREATE PROCEDURE [dbo].[MSG_MisigoKategoriList]
  (@Marka nvarchar(50))
AS
SELECT 
    p.DataBaseNebim,
    p.ProductAttributeType,
    p.ProductAttributeValue
	,AttributeCode = ISNULL((ZTMSGMisigoOzellikEslestir.NebimAttributeTypeCode),SPACE(0))
FROM 
    (
        SELECT 
            DataBaseNebim,
            ProductAtt01Type,
            ProductAtt02Type,
            ProductAtt03Type,
            ProductAtt04Type,
            ProductAtt05Type,
            ProductAtt06Type,
            ProductAtt07Type,
            ProductAtt08Type,
            ProductAtt09Type,
            ProductAtt10Type,
            ProductAtt11Type,
            ProductAtt12Type,
            ProductAtt13Type,
            ProductAtt14Type,
            ProductAtt15Type,
            ProductAtt16Type,
            ProductAtt17Type,
            ProductAtt18Type,
            ProductAtt19Type,
            ProductAtt20Type
        FROM 
            ZTMSGUrunListMisigo
        LEFT OUTER JOIN ZTMSGMisigoUrunAcmaParametreleri 
            ON ZTMSGMisigoUrunAcmaParametreleri.SirketKodu = SUBSTRING(Itemcode, 0, 4)
        WHERE 
            ZTMSGMisigoUrunAcmaParametreleri.DataBaseNebim = @Marka
    ) AS SourceTable
UNPIVOT
    (
        ProductAttributeValue FOR ProductAttributeType IN 
        (
            ProductAtt01Type,
            ProductAtt02Type,
            ProductAtt03Type,
            ProductAtt04Type,
            ProductAtt05Type,
            ProductAtt06Type,
            ProductAtt07Type,
            ProductAtt08Type,
            ProductAtt09Type,
            ProductAtt10Type,
            ProductAtt11Type,
            ProductAtt12Type,
            ProductAtt13Type,
            ProductAtt14Type,
            ProductAtt15Type,
            ProductAtt16Type,
            ProductAtt17Type,
            ProductAtt18Type,
            ProductAtt19Type,
            ProductAtt20Type
        )
    ) AS p
	Left Outer Join ZTMSGMisigoOzellikEslestir on ZTMSGMisigoOzellikEslestir.Marka  = p.DataBaseNebim
	and ZTMSGMisigoOzellikEslestir.FirmaAttributeTypeCode = p.ProductAttributeValue
	Group by p.DataBaseNebim,p.ProductAttributeType,p.ProductAttributeValue,ZTMSGMisigoOzellikEslestir.NebimAttributeTypeCode
	Order by p.DataBaseNebim,p.ProductAttributeType,p.ProductAttributeValue


	--select * from ZTMSGMisigoOzellikEslestir
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimIndirListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MSG_MisigoResimIndirListe] 


AS

--select * from ZTMSGTicUrunler 
--select * from ZTMSGUrunResimList

select  ID,barcode=Barcode,Url=Resim,Marka='Misigo' from ZTMSGUrunResimList
where aktarma = 'false'
ORder by Marka,barcode

GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimIndirListeGuncelle]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[MSG_MisigoResimIndirListeGuncelle] (
@Url nvarchar(100)
)


AS

--select * from ZTMSGTicUrunler 
--select * from ZTMSGUrunResimList

update ZTMSGUrunResimList set  Aktarma = 'true' from ZTMSGUrunResimList 
where Resim = @Url
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimListEkle]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select DataBaseNebim from ZTMSGMisigoUrunAcmaParametreleri
--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
CREATE PROCEDURE [dbo].[MSG_MisigoResimListEkle]
  
AS

Insert Into ZTMSGUrunResimList (Itemcode,Resim,Aktarma,Barcode,Marka)
select ItemCode,Resim,Aktarma,Barcode=Itemcode + '_' +ColorCode+'_' + Convert(nvarchar(50), ROW_NUMBER() OVER (PARTITION BY Itemcode, ColorCode ORDER BY Itemcode, ColorCode)),Marka from (
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim1,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim1,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim2,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim2,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim3,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim3,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim4,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim4,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim5,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim5,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
) as a 
where a.ItemCode not in (select ItemCode from ZTMSGUrunResimList)
and a.Marka != 'Misigo'
Group by ItemCode,ColorCode,Resim,Aktarma,Barcode,Marka



Insert Into ZTMSGKategoriListMisigo(ProductHierarchyID ,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,ID)
select ProductHierarchyID =0,ZTMSGUrunListMisigo.ProductHierarchyLevel01,ZTMSGUrunListMisigo.ProductHierarchyLevel02,ZTMSGUrunListMisigo.ProductHierarchyLevel03
,ZTMSGUrunListMisigo.ProductHierarchyLevel04 
,ID=ROW_NUMBER() OVER ( ORDER BY ZTMSGUrunListMisigo.ProductHierarchyLevel01,ZTMSGUrunListMisigo.ProductHierarchyLevel02,ZTMSGUrunListMisigo.ProductHierarchyLevel03,ZTMSGUrunListMisigo.ProductHierarchyLevel04)
from ZTMSGUrunListMisigo
Left Outer Join ZTMSGKategoriListMisigo on ZTMSGKategoriListMisigo.ProductHierarchyLevel01 = ZTMSGUrunListMisigo.ProductHierarchyLevel01
and ZTMSGKategoriListMisigo.ProductHierarchyLevel02 = ZTMSGUrunListMisigo.ProductHierarchyLevel02
and ZTMSGKategoriListMisigo.ProductHierarchyLevel03 = ZTMSGUrunListMisigo.ProductHierarchyLevel03
and ZTMSGKategoriListMisigo.ProductHierarchyLevel04 = ZTMSGUrunListMisigo.ProductHierarchyLevel04
where ZTMSGUrunListMisigo.ProductHierarchyLevel01 != ''
and ZTMSGKategoriListMisigo.ProductHierarchyLevel01 is null
Group by ZTMSGUrunListMisigo.ProductHierarchyLevel01,ZTMSGUrunListMisigo.ProductHierarchyLevel02,ZTMSGUrunListMisigo.ProductHierarchyLevel03,ZTMSGUrunListMisigo.ProductHierarchyLevel04 

Order by ZTMSGUrunListMisigo.ProductHierarchyLevel01,ZTMSGUrunListMisigo.ProductHierarchyLevel02,ZTMSGUrunListMisigo.ProductHierarchyLevel03,ZTMSGUrunListMisigo.ProductHierarchyLevel04



--delete ZTMSGUrunResimList
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoResimListEkle2]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select DataBaseNebim from ZTMSGMisigoUrunAcmaParametreleri
--exec usp_GetOrderForInvoiceToplu_ws '1-WS-2-11748'
Create PROCEDURE [dbo].[MSG_MisigoResimListEkle2]
  
AS

Insert Into ZTMSGUrunResimList (Itemcode,Resim,Aktarma,Barcode,Marka)
select ItemCode,Resim,Aktarma,Barcode=Barcode + '-' +Convert(nvarchar(50),ROW_NUMBER() OVER (ORDER BY Itemcode)),Marka from (
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim1,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim1,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim2,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim2,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim3,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim3,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim4,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim4,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
UNION ALL
select Itemcode,ColorCode,Resim=Replace(REPLACE(Resim5,'{ProductCode}',REPLACE(Itemcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),'{ColorCode}',REPLACE(Colorcode,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,'')),Aktarma='false',Barcode=MAX(Barcode),Marka = DataBaseNebim from ZTMSGUrunListMisigo
Left Outer Join ZTMSGMisigoUrunAcmaParametreleri on ZTMSGUrunListMisigo.ItemCode like ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod +'%'
Group by Itemcode,ColorCode,Resim5,ZTMSGMisigoUrunAcmaParametreleri.FirmaKisaKod,DataBaseNebim
) as a 
where a.ItemCode not in (select ItemCode from ZTMSGUrunResimList)
Group by ItemCode,ColorCode,Resim,Aktarma,Barcode,Marka
Order by ItemCode,Resim
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoSayimCikar]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from trInvoiceHeader where EInvoiceStatusCode = 3

--exec usp_GetOrderForInvoiceToplu_SayimCikar 'B3F2EAF9-B492-45C4-8EAC-DEC14D1617E1'
CREATE  PROCEDURE [dbo].[MSG_MisigoSayimCikar]

AS



    SELECT  
 ModelType = 142,
  OperationDate = GETDATE(),
OfficeCode= 'M'
,StoreCode='M01'
,WarehouseCode='M02'
,CompanyCode=1
,InnerProcessType=3
,Lines =ISNULL((
select top 100 * from (

select  ItemtypeCode = 1 ,Itemcode,Colorcode,Itemdim1code,Qty1 from (
select ZTMSGUrunListMisigo.Itemcode,ZTMSGUrunListMisigo.Colorcode,ZTMSGUrunListMisigo.Itemdim1code,Qty1=(Envanter-Case When MisigoStok<0 Then MisigoStok*-1 else MisigoStok end)*-1 from ZTMSGUrunListMisigo
Inner Join (Select Itemcode ,Colorcode,Itemdim1code ,MisigoStok = SUM(In_qty1-Out_qty1) from trStock
where Warehousecode in ( 'M01','M02')
Group by Itemcode ,Colorcode,Itemdim1code ) as a 
on a.ItemCode = ZTMSGUrunListMisigo.Itemcode
and a.ColorCode = ZTMSGUrunListMisigo.Colorcode
and a.ItemDim1Code = ZTMSGUrunListMisigo.Itemdim1code 
where ZTMSGUrunListMisigo.Itemcode not like 'MS%') as a where a.Qty1 >0



                         ) as a        
                                      FOR json PATH
									

                                    ),SPace(0))
	
	
	-- where Data.OrderNumber = @TCMXOrderNo
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoSayimEkle]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from trInvoiceHeader where EInvoiceStatusCode = 3

--exec usp_GetOrderForInvoiceToplu_SayimCikar 'C6AB3A26-E266-442F-9F4F-E880819A5FCF'
--exec usp_GetOrderForInvoiceToplu_SayimEkle 'C1874E35-AEE8-4B86-9053-2175A2268147'
CREATE  PROCEDURE [dbo].[MSG_MisigoSayimEkle]
 
AS
    SELECT 
 ModelType = 142,
  OperationDate = GETDATE(),
OfficeCode= 'M'
,StoreCode='M01'
,WarehouseCode='M02'
,CompanyCode=1
,InnerProcessType=2
,Lines =ISNULL((select top 100 ItemtypeCode = 1 ,Itemcode,Colorcode,Itemdim1code,Qty1 from (
select ZTMSGUrunListMisigo.Itemcode,ZTMSGUrunListMisigo.Colorcode,ZTMSGUrunListMisigo.Itemdim1code,Qty1=(Case When MisigoStok<0 Then MisigoStok*-1 else MisigoStok end-Envanter)*-1 from ZTMSGUrunListMisigo
Inner Join (Select Itemcode ,Colorcode,Itemdim1code ,MisigoStok = SUM(In_qty1-Out_qty1) from trStock
where Warehousecode in ( 'M01','M02')
Group by Itemcode ,Colorcode,Itemdim1code ) as a 
on a.ItemCode = ZTMSGUrunListMisigo.Itemcode
and a.ColorCode = ZTMSGUrunListMisigo.Colorcode
and a.ItemDim1Code = ZTMSGUrunListMisigo.Itemdim1code 
where ZTMSGUrunListMisigo.Itemcode not like 'MS%') as a where a.Qty1 >0

                                      FOR json PATH
									

                                    ),SPace(0))
	
GO
/****** Object:  StoredProcedure [dbo].[MSG_MisigoUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--054-855
--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_MisigoUrunListesi] 

AS

select ZTMSGUrunListMisigo.colorcode, Deger=Color into ztdeger from ZTMSGUrunListMisigo
Left Outer Join cdColor on cdColor.Colorcode = ZTMSGUrunListMisigo.Colorcode 
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = ZTMSGUrunListMisigo.Colorcode
and cdColordesc.Colordescription = ZTMSGUrunListMisigo.Color
and cdColorDesc.LangCode = 'TR'
where  cdColorDesc.ColorDescription is null
--and ZTMSGUrunListMisigo.Colorcode = 'MON79'
Group by Color,ZTMSGUrunListMisigo.colorcode
Insert Into cdColor(ColorCode,ColorHex,ColorCatalogCode1,ColorCatalogCode2,ColorCatalogCode3,IsBlocked)
select colorcode,ColorHex='',ColorCatalogCode1='',ColorCatalogCode2='',ColorCatalogCode3='',IsBlocked=0 from ztdeger
Insert Into cdColorDesc(ColorCode,LangCode,ColorDescription)
select colorcode,'TR',Deger from ztdeger
Drop Table ztdeger

UPDATE z
SET z.Itemdescription = REPLACE(z.Itemdescription, c.Colordescription, '')
FROM ZTMSGUrunListMisigo z
INNER JOIN cdColordesc c ON z.ColorCode = c.ColorCode

Insert Into cdItemDim1(ItemDim1Code,SortOrder,IsBlocked)
select ZTMSGUrunListMisigo.ItemDim1Code,0,0 from ZTMSGUrunListMisigo
Left Outer Join cdItemDim1 on cdItemDim1.ItemDim1Code = ZTMSGUrunListMisigo.ItemDim1Code
where cdItemDim1.ItemDim1Code is null
Group by  ZTMSGUrunListMisigo.ItemDim1Code



select  ModelType=4, ItemTypeCode=1, b.ItemCode
, ItemDescription=MAX(Itemdescription), ItemDimTypeCode=2
, ItemTaxGrCode='%10',
--ProductHierarchyID=ISNULL(ZTMSGTicKategoriler.NebimKategoriID,0)
ProductHierarchyID=0
,UsePOS='True'
,UseStore='True'
,UseInternet = 'True'
,UnitOfMeasureCode1= 'AD',
UseBatch='False'
,UseInternet='True'
,UseManufacturing='False'
,UsePOS='True'
,UseRoll='False'
,UseSerialNumber='False'
,

Variant=(

Select top 30 ColorCode=ZTMSGUrunListMisigo.ColorCode, ItemDim1Code =ISNULL((ZTMSGUrunListMisigo.Itemdim1code),SPACE(0))  
from ZTMSGUrunListMisigo
Left Outer Join prItemvariant on prItemvariant.Itemcode = ZTMSGUrunListMisigo.Itemcode
and prITemvariant.Colorcode = ZTMSGUrunListMisigo.Colorcode
and prITemvariant.Itemdim1code = ZTMSGUrunListMisigo.Itemdim1code
where ZTMSGUrunListMisigo.Itemcode = b.Itemcode 
and prItemvariant.Itemcode is null
for json path)

--,ProductLots= (select DeleteWithProductLotBarcode = 'False',IsDefault='True' , LotCode = OzelAlan2 from ZTMSGTicUrunler as a where a.UrunKartiID = b.UrunKartiID   for Json path)
,BasePrices=(
select * from (
select BasePriceCode = 8 ,CountryCode='TR',CurrencyCode='TRY',Price=MisigoWebSatis,PriceDate=convert(varchar, getdate(), 105) from ZTMSGUrunListMisigo as Satis where satis.Itemcode = b.Itemcode
Group by MisigoWebSatis
UNION ALL
select BasePriceCode = 7 ,CountryCode='TR',CurrencyCode='TRY',Price=MisigoWebIndirimliSatis,PriceDate=convert(varchar, getdate(), 105)  from ZTMSGUrunListMisigo as Satis where satis.Itemcode = b.Itemcode
Group by MisigoWebIndirimliSatis
UNION ALL
select BasePriceCode = 6 ,CountryCode='TR',CurrencyCode='TRY',Price=MisigoPazaryeriIndirimliSatis,PriceDate=convert(varchar, getdate(), 105)  from ZTMSGUrunListMisigo as Satis where satis.Itemcode = b.Itemcode
Group by MisigoPazaryeriIndirimliSatis) as a
for json path)
,Barcodes =(select top 30  Barcode =ZTMSGUrunListMisigo.Barcode,BarcodeTypeCode='def',Colorcode=ZTMSGUrunListMisigo.Colorcode,ItemDim1Code =ZTMSGUrunListMisigo.Itemdim1code,Qty=1,UnitOfMeasureCode='AD' from ZTMSGUrunListMisigo
where   ZTMSGUrunListMisigo.Itemcode = b.Itemcode
for json path)

--,Descriptions= (Select DataLanguageCode ='TR',Description=UrunAdi from ZTMSGTicUrunler as Urun where Urun.UrunKartiID = b.UrunKartiID for json path)
--,ItemNotes = (select LangCode='TR',Notes=Aciklama,PlainText=Aciklama from ZTMSGTicUrunler as Acik where Acik.UrunKartiID = b.UrunKartiID for json path)

from ZTMSGUrunListMisigo as b
Left Outer Join cdColorDesc on cdColorDesc.ColorDescription = b.Color
and cdColorDesc.LangCode = 'TR'
Left Outer Join prItemBarcode on prItemBarcode.Barcode = b.Barcode
Left Outer Join prItemvariant on prItemvariant.Itemcode = b.Itemcode
and prItemvariant.Colorcode = b.Colorcode
and prItemvariant.Itemdim1code = b.Itemdim1code

--Left Outer Join ZTMSGTicKategoriler on ZTMSGTicKategoriler.KategoriID = b.KategoriID
where   prItemBarcode.Barcode is null
and b.Barcode != ''
and prItemvariant.Itemcode is null
Group by b.ItemCode







Insert Into prItemBarcode( Barcode,BarcodeTypeCode,ItemTypeCode,ItemCode,ColorCode,ItemDim1Code,ItemDim2Code,ItemDim3Code,UnitOfMeasureCode,Qty)
Select Barcode,BarcodeTypeCode='AEAN13',cdItem.ItemTypeCode,a.ItemCode,ColorCode=MAX(a.ColorCode),a.ItemDim1Code,ItemDim2Code='',ItemDim3Code='',UnitOfMeasureCode='AD',Qty=1 from (
select ZTMSGUrunListMisigo.ItemCode,ZTMSGUrunListMisigo.ColorCode,ZTMSGUrunListMisigo.ItemDim1Code,Barcode = Replace(SUBSTRING(ZTMSGUrunListMisigo.Barcode,4,99),'B','') from ZTMSGUrunListMisigo
Left Outer Join prItemBarcode on prItemBarcode.Barcode =ZTMSGUrunListMisigo.Barcode
Left Outer Join prItemBarcode as a on a.ItemCode = ZTMSGUrunListMisigo.ItemCode
and a.ColorCode = ZTMSGUrunListMisigo.ColorCode
and a.ItemDim1Code =ZTMSGUrunListMisigo.ItemDim1Code
where prItemBarcode.Barcode is null
and a.Barcode is null ) as a
Inner Join cdItem on cdItem.ItemCode = a.ItemCode
Inner Join prItemVariant on prItemVariant.ItemCode = a.ItemCode
and prItemVariant.ColorCode = a.ColorCode
and prItemVariant.ItemDim1Code = a.ItemDim1Code
where a.Barcode != ''
and a.Barcode != 'T9998'
--and a.Barcode = '1907925179097'
Group by a.ItemCode,a.ItemDim1Code,a.Barcode,cdItem.ItemTypeCode






Insert Into prItemBarcode( Barcode,BarcodeTypeCode,ItemTypeCode,ItemCode,ColorCode,ItemDim1Code,ItemDim2Code,ItemDim3Code,UnitOfMeasureCode,Qty)
Select a.Barcode,BarcodeTypeCode='def',cdItem.ItemTypeCode,a.ItemCode,ColorCode=MAX(a.ColorCode),a.ItemDim1Code,ItemDim2Code='',ItemDim3Code='',UnitOfMeasureCode='AD',Qty=1 from (
select ZTMSGUrunListMisigo.ItemCode,ZTMSGUrunListMisigo.ColorCode,ZTMSGUrunListMisigo.ItemDim1Code,Barcode = ZTMSGUrunListMisigo.Barcode from ZTMSGUrunListMisigo
Left Outer Join prItemBarcode on prItemBarcode.Barcode =ZTMSGUrunListMisigo.Barcode
Left Outer Join prItemBarcode as a on a.ItemCode = ZTMSGUrunListMisigo.ItemCode
and a.ColorCode = ZTMSGUrunListMisigo.ColorCode
and a.ItemDim1Code =ZTMSGUrunListMisigo.ItemDim1Code
and a.BarcodeTypeCode = 'Def'
where prItemBarcode.Barcode is null
and a.Barcode is null ) as a
Inner Join cdItem on cdItem.ItemCode = a.ItemCode
Inner Join prItemVariant on prItemVariant.ItemCode = a.ItemCode
and prItemVariant.ColorCode = a.ColorCode
and prItemVariant.ItemDim1Code = a.ItemDim1Code
Left Outer Join prItemBarcode on prItemBarcode.Barcode = a.Barcode
where a.Barcode != ''
and a.Barcode != 'T9998'
--and a.Barcode = '1907925179097'
and prItemBarcode.Barcode is null
and a.Barcode != 'OLC'
Group by a.ItemCode,a.ItemDim1Code,a.Barcode,cdItem.ItemTypeCode
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSRAFSAYIMOffline]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec Get_MSRAFSAYIMOffline '1234567891234','D-G-01-02',0
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_MSRAFSAYIMOffline]
	
	(@barcode nvarchar(50),
	 @ShelfNo nvarchar(50)
	 ,@OrderNumberCheck int
	 ,@ID uniqueidentifier
	)
AS






SELECT @OrderNumberCheck=COUNT(*) from ZTMSRAF where ShelfNo = REPLACE(@barcode,'*','-')



IF @OrderNumberCheck = 1 
BEGIN
	Select Status='RAF', Description = REPLACE(@barcode,'*','-')
select 	@OrderNumberCheck = 0
end

ELSE
SELECT @OrderNumberCheck=COUNT(*) from prItemBarcode where Barcode = @barcode
IF @OrderNumberCheck = 1 
Begin 
Insert Into ZTMSGRafSayimOffline(ShelfNo,Barcode,Quantity,SayimID) Select ShelfNo=@ShelfNo,Barcode=@barcode,Quantity=1,@ID
select Status='Barcode',Description=@barcode
End 

--SELECT * FROM  ZTMSGRafSayimOffline

--delete ZTMSGRafSayimOffline
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSZTNebimUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from ZTMSGTicUrunKartiAcma
--USP_MSZTNebimUrunListesi 'Kadir'
CREATE PROCEDURE [dbo].[MSG_MSZTNebimUrunListesi] 
(@AnaUrunKodu nvarchar(500))
AS



select  ModelType=4, ItemTypeCode=1, ItemCode=b.NebimUrunKodu
, ItemDescription=NebimUrunAdi, ItemDimTypeCode=b.Variant
, ItemTaxGrCode=b.MaddeVergiGrubu,
ProductHierarchyID=ISNULL(b.UrunHiyerarsi,0)
,UsePOS='True'
,UseStore='True'
,UseInternet = 'True'
,UnitOfMeasureCode1= 'AD',
UseBatch='False'
,UseInternet='True'
,UseManufacturing='False'
,UsePOS='True'
,UseRoll='False'
,UseSerialNumber='False'
,

Variant=ISNULL((

Select ColorCode=ZTMSGTicUrunVariant.ColorCode, ItemDim1Code =ISNULL((ZTMSGTicUrunVariant.Itemdim1code),SPACE(0))  
from ZTMSGTicUrunVariant
where  ZTMSGTicUrunVariant.Itemcode = b.NebimUrunKodu
for json path),SPACE(0))

--,ProductLots= (select DeleteWithProductLotBarcode = 'False',IsDefault='True' , LotCode = OzelAlan2 from ZTMSGTicUrunler as a where a.UrunKartiID = b.UrunKartiID   for Json path)
,BasePrices=ISNULL((
select * from (
select BasePriceCode = BasepriceCode,CountryCode='TR',CurrencyCode='TRY',Price=Price,PriceDate=convert(varchar, getdate(), 105) from ZtTicUrunFiyat as Satis where satis.Itemcode = b.NebimUrunKodu
Group by BasepriceCode,Price) as a
for json path),SPACE(0))
,Barcodes =ISNULL((select Barcode =REPLACE((Barcode),' ',''),BarcodeTypeCode='AEAN13',Colorcode,ItemDim1Code ,Qty=1,UnitOfMeasureCode='AD' from ZTMSGTicUrunVariant

where   ZTMSGTicUrunVariant.Itemcode = b.NebimUrunKodu
for json path),SPACE(0))

,Descriptions= ISNULL((Select DataLanguageCode ='TR',Description=NebimUrunAdi from ZTMSGTicUrunKartiAcma as Urun where Urun.NebimUrunKodu = b.NebimUrunKodu for json path),SPACE(0))
,ItemNotes = ISNULL((select LangCode='TR',Notes='',PlainText=''  for json path),SPACE(0))
from ZTMSGTicUrunKartiAcma as b

where b.AnaUrunKodu = @AnaUrunKodu

--select * from ZTMSGTicUrunKartiAcma
GO
/****** Object:  StoredProcedure [dbo].[MSG_MSZTTicimaxUrunQR]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_MSZTTicimaxUrunQR] 

AS

select  Barkod=MAX(ZTMSGTicSecenekler.Barkod),UrunUrl from ZTMSGTicUrunler
Left Outer Join ZTMSGTicSecenekler on ZTMSGTicSecenekler.UrunKartiID = ZTMSGTicUrunler.UrunKartiID
Left Outer Join ZTMSGUrunlerQR on ZTMSGUrunlerQR.Barkod = ZTMSGTicSecenekler.Barkod
where ZTMSGUrunlerQR.Barkod is null
and ZTMSGTicUrunler.UrunUrl is not null
Group by UrunUrl
--select * from ZTMSGTicUrunler
--select * from ZTMSGTicSecenekler
GO
/****** Object:  StoredProcedure [dbo].[MSG_OzellikListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec Get_MSRAFSAYIMOffline '1234567891234','D-G-01-02',0
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_OzellikListe]

AS

select * from (

select cdItemAttributeDesc.AttributeTypeCode, cdItemAttributeDesc.AttributeCode,cdItemAttributeDesc.AttributeDescription from cdItemAttributeDesc
Left Outer Join cdItemAttributeDesc as EN on EN.AttributeCode = cdItemAttributeDesc.AttributeCode
and EN.LangCode in ('EN')
where cdItemAttributeDesc.LangCode = 'TR'
and EN.AttributeCode is null

UNION ALL 

select cdItemAttributeDesc.AttributeTypeCode, cdItemAttributeDesc.AttributeCode,cdItemAttributeDesc.AttributeDescription from cdItemAttributeDesc
Left Outer Join cdItemAttributeDesc as EN on EN.AttributeCode = cdItemAttributeDesc.AttributeCode
and EN.LangCode in ('RU' )
where cdItemAttributeDesc.LangCode = 'TR'
and EN.AttributeCode is null

UNION ALL 

select cdItemAttributeDesc.AttributeTypeCode, cdItemAttributeDesc.AttributeCode,cdItemAttributeDesc.AttributeDescription from cdItemAttributeDesc
Left Outer Join cdItemAttributeDesc as EN on EN.AttributeCode = cdItemAttributeDesc.AttributeCode
and EN.LangCode in ('AR' )
where cdItemAttributeDesc.LangCode = 'TR'
and EN.AttributeCode is null

UNION ALL 

select cdItemAttributeDesc.AttributeTypeCode, cdItemAttributeDesc.AttributeCode,cdItemAttributeDesc.AttributeDescription from cdItemAttributeDesc
Left Outer Join cdItemAttributeDesc as EN on EN.AttributeCode = cdItemAttributeDesc.AttributeCode
and EN.LangCode in ( 'FR')
where cdItemAttributeDesc.LangCode = 'TR'
and EN.AttributeCode is null

UNION ALL 

select cdItemAttributeDesc.AttributeTypeCode, cdItemAttributeDesc.AttributeCode,cdItemAttributeDesc.AttributeDescription from cdItemAttributeDesc
Left Outer Join cdItemAttributeDesc as EN on EN.AttributeCode = cdItemAttributeDesc.AttributeCode
and EN.LangCode in ( 'DE' )
where cdItemAttributeDesc.LangCode = 'TR'
and EN.AttributeCode is null

) as a
where a.AttributeDescription not in ('','.',',')
Group by a.AttributeTypeCode,AttributeCode,AttributeDescription
GO
/****** Object:  StoredProcedure [dbo].[MSG_OzellikTipiListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec Get_MSRAFSAYIMOffline '1234567891234','D-G-01-02',0
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_OzellikTipiListe]

AS

select * from (

select cdItemAttributeTypeDesc.AttributeTypeCode,cdItemAttributeTypeDesc.AttributeTypeDescription from cdItemAttributeTypeDesc
Left Outer Join cdItemAttributeTypeDesc as EN on 
EN.ItemTypeCode = cdItemAttributeTypeDesc.ItemTypeCode and
EN.AttributeTypeCode = cdItemAttributeTypeDesc.AttributeTypeCode
and EN.LangCode in ('EN')
where cdItemAttributeTypeDesc.LangCode = 'TR'
and cdItemAttributeTypeDesc.ItemTypeCode = 1
and EN.AttributeTypeCode is null



UNION ALL 

select cdItemAttributeTypeDesc.AttributeTypeCode,cdItemAttributeTypeDesc.AttributeTypeDescription from cdItemAttributeTypeDesc
Left Outer Join cdItemAttributeTypeDesc as EN on 
EN.ItemTypeCode = cdItemAttributeTypeDesc.ItemTypeCode and
EN.AttributeTypeCode = cdItemAttributeTypeDesc.AttributeTypeCode
and EN.LangCode in ('RU')
where cdItemAttributeTypeDesc.LangCode = 'TR'
and cdItemAttributeTypeDesc.ItemTypeCode = 1
and EN.AttributeTypeCode is null


UNION ALL 

select cdItemAttributeTypeDesc.AttributeTypeCode,cdItemAttributeTypeDesc.AttributeTypeDescription from cdItemAttributeTypeDesc
Left Outer Join cdItemAttributeTypeDesc as EN on 
EN.ItemTypeCode = cdItemAttributeTypeDesc.ItemTypeCode and
EN.AttributeTypeCode = cdItemAttributeTypeDesc.AttributeTypeCode
and EN.LangCode in ('AR')
where cdItemAttributeTypeDesc.LangCode = 'TR'
and cdItemAttributeTypeDesc.ItemTypeCode = 1
and EN.AttributeTypeCode is null


UNION ALL 

select cdItemAttributeTypeDesc.AttributeTypeCode,cdItemAttributeTypeDesc.AttributeTypeDescription from cdItemAttributeTypeDesc
Left Outer Join cdItemAttributeTypeDesc as EN on 
EN.ItemTypeCode = cdItemAttributeTypeDesc.ItemTypeCode and
EN.AttributeTypeCode = cdItemAttributeTypeDesc.AttributeTypeCode
and EN.LangCode in ('FR')
where cdItemAttributeTypeDesc.LangCode = 'TR'
and cdItemAttributeTypeDesc.ItemTypeCode = 1
and EN.AttributeTypeCode is null


UNION ALL 

select cdItemAttributeTypeDesc.AttributeTypeCode,cdItemAttributeTypeDesc.AttributeTypeDescription from cdItemAttributeTypeDesc
Left Outer Join cdItemAttributeTypeDesc as EN on 
EN.ItemTypeCode = cdItemAttributeTypeDesc.ItemTypeCode and
EN.AttributeTypeCode = cdItemAttributeTypeDesc.AttributeTypeCode
and EN.LangCode in ('DE')
where cdItemAttributeTypeDesc.LangCode = 'TR'
and cdItemAttributeTypeDesc.ItemTypeCode = 1
and EN.AttributeTypeCode is null

) as a
where a.AttributeTypeDescription not in ('','.',',')
Group by a.AttributeTypeCode,AttributeTypeDescription
GO
/****** Object:  StoredProcedure [dbo].[MSG_RenkListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec Get_MSRAFSAYIMOffline '1234567891234','D-G-01-02',0
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_RenkListe]

AS

select * from (

select cdColordesc.Colorcode,cdColordesc.ColorDescription from cdColordesc
Left Outer Join cdColordesc as EN on EN.Colorcode = cdColordesc.Colorcode
and EN.LangCode in ('EN')
where cdColordesc.LangCode = 'TR'
and EN.Colorcode is null

UNION ALL 

select cdColordesc.Colorcode,cdColordesc.ColorDescription from cdColordesc
Left Outer Join cdColordesc as EN on EN.Colorcode = cdColordesc.Colorcode
and EN.LangCode in ('RU' )
where cdColordesc.LangCode = 'TR'
and EN.Colorcode is null

UNION ALL 

select cdColordesc.Colorcode,cdColordesc.ColorDescription from cdColordesc
Left Outer Join cdColordesc as EN on EN.Colorcode = cdColordesc.Colorcode
and EN.LangCode in ('AR' )
where cdColordesc.LangCode = 'TR'
and EN.Colorcode is null

UNION ALL 

select cdColordesc.Colorcode,cdColordesc.ColorDescription from cdColordesc
Left Outer Join cdColordesc as EN on EN.Colorcode = cdColordesc.Colorcode
and EN.LangCode in ( 'FR')
where cdColordesc.LangCode = 'TR'
and EN.Colorcode is null

UNION ALL 

select cdColordesc.Colorcode,cdColordesc.ColorDescription from cdColordesc
Left Outer Join cdColordesc as EN on EN.Colorcode = cdColordesc.Colorcode
and EN.LangCode in ( 'DE' )
where cdColordesc.LangCode = 'TR'
and EN.Colorcode is null

) as a
where a.ColorDescription not in ('','.',',')
Group by Colorcode,ColorDescription
GO
/****** Object:  StoredProcedure [dbo].[MSG_SiparisBarkod]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from prItemBarcode


--exec Get_MSSiparisBarkod 'AEAN13','1-R-2-429'
	Create PROCEDURE [dbo].[MSG_SiparisBarkod]
	(@BarcodeTypeCode nvarchar(50)
	,@OrderNumber nvarchar(50))
	
AS
select
ProductCode=AllOrders.Itemcode
,ItemDescription
,AllOrders.ColorCode
,ColorDescription
,AllOrders.ItemDim1Code
,Price = AllOrders.Loc_PriceVI
,Price2 = AllOrders.Loc_PriceVI
,PriceDate ='2023-06-19'
,UsedBarcode=prItemBarcode.Barcode
,UrunKodu=ItemDescription
from AllOrders
Left Outer Join cdItemDesc on cdItemDesc.ItemCode = AllOrders.ItemCode
and cdItemDesc.LangCode = 'TR'
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = AllOrders.ColorCode
and cdColorDesc.LangCode = 'TR'
Left Outer Join prItemBarcode on prItemBarcode.ItemCode = AllOrders.ItemCode
and prItemBarcode.ColorCode = allOrders.ColorCode
and prItemBarcode.ItemDim1Code = AllOrders.ItemDim1Code
and prItemBarcode.BarcodeTypeCode = @BarcodeTypeCode
Inner Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
where AllOrders.OrderNumber = @OrderNumber
Order by OrderDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_SiparisList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




	Create PROCEDURE [dbo].[MSG_SiparisList]
	
AS
select OrderDate,OrderNumber from AllOrders
Inner Join stOrder on stOrder.OrderLineID = AllOrders.OrderLineID
Order by OrderDate desc
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxKategori]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxKategori] 

AS

select Marka,Url=XML from ZTMSGTicXmlUrl where Tur = 'Kategori'


--select * from ZTMSGTicXmlUrl
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxMusteri]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- exec [usp_GetOrderForInvoice] 'TS300628977785'
-- exec [usp_GetOrderForInvoice] '1-R-2-1716'
CREATE PROCEDURE [dbo].[MSG_TicimaxMusteri]

AS
  select 
  ModelType=2,
  CurrAccCode =''
,CurrAccDescription =FirmAAdiField
,FirstName=cAse when Len(VergiNoField) = 10 Then '' Else SUBSTRING(firmaAdiField,0,CHARINDEX (' ',firmaAdiField,0)) end 
,LastName=cAse when Len(VergiNoField) = 10 Then '' Else Replace (firmaAdiField,SUBSTRING(firmaAdiField,0,CHARINDEX (' ',firmaAdiField,0)),'') end 
,IsIndividualAcc=cAse when Len(VergiNoField) = 10 Then 'false' Else 'true' end 
,IdentityNum=cAse when Len(VergiNoField) = 11 Then VergiNoField Else
cAse when VergiNoField = '' Then '11111111111' else '' end end 
,TaxNumber=cAse when Len(VergiNoField) = 10 Then VergiNoField Else '' end 
,TaxOfficeCode=''
,CurrencyCode=Case When  UlkeField = 'Türkiye' Then 'TRY' else 'USD' end 
,OfficeCode='M'
--,WholeSalePriceGroupCode=Case When  UlkeField = 'Türkiye' Then 'PSF' else 'RCM_STD' end 
--,RetailSalePriceGroupCode=Case When  UlkeField = 'Türkiye' Then '' else 'RCM_STD' end 
,WholeSalePriceGroupCode=''
,RetailSalePriceGroupCode=''
,CustomerTypeCode=Case When  UlkeField = 'Türkiye' Then 0 else 3 end 
,PostalAddresses=(select top 1 
AddressTypeCode = 1
,CountryCode = (select top 1 CountryCode from TicimaxAdreslist(ZTMSGTicUyeAdres.UlkeField,ZTMSGTicUyeAdres.SehirField,ZTMSGTicUyeAdres.IlceField))
,StateCode = (select top 1 StateCode from TicimaxAdreslist(ZTMSGTicUyeAdres.UlkeField,ZTMSGTicUyeAdres.SehirField,ZTMSGTicUyeAdres.IlceField))
,CityCode = (select top 1 CityCode from TicimaxAdreslist(ZTMSGTicUyeAdres.UlkeField,ZTMSGTicUyeAdres.SehirField,ZTMSGTicUyeAdres.IlceField))
,DistrictCode = (select top 1 DistrictCode from TicimaxAdreslist(ZTMSGTicUyeAdres.UlkeField,ZTMSGTicUyeAdres.SehirField,ZTMSGTicUyeAdres.IlceField))
,Address = ZTMSGTicUyeAdres.AdresField 

FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField  For json Path)
,Attributes=(
Select * from (
select top 1 AttributeTypeCode = 1,AttributeCode = 'YI' FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField and a.UlkeField = 'Türkiye'
UNION all 
select top 1 AttributeTypeCode = 2,AttributeCode = 'P' FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField 
UNION all 
select top 1 AttributeTypeCode = 3,AttributeCode = 'O' FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField 
UNION all 
select top 1 AttributeTypeCode = 1,AttributeCode = 'YD' FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField and a.UlkeField != 'Türkiye') As b
For json Path
) 
,Communications=(select top 1 CommunicationTypeCode = 7,CommAddress = Alicitelefonfield FROM ZTMSGTicUyeAdres as a where a.IDField =ZTMSGTicUyeAdres.IDField  For json Path)
from   ZTMSGTicUyeAdres 
where ZTMSGTicUyeAdres.Alicitelefonfield not in (select Commaddress from prCurrAcccommunication)
Order by UyeIdfield
 




GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxMusteri_PR]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- exec [usp_GetOrderForInvoice] 'TS300628977785'
-- exec [usp_GetOrderForInvoice] '1-R-2-1716'
CREATE PROCEDURE [dbo].[MSG_TicimaxMusteri_PR]

AS
 
 select 
  ModelType=3,
  CurrAccCode =''
,CurrAccDescription =SirketIsmi
,FirstName=cAse when Len(VergiKimlikNumarasi) = 10 Then '' Else SUBSTRING(AliciFaturaAdresi,0,CHARINDEX (' ',AliciFaturaAdresi,0)) end 
,LastName=cAse when Len(VergiKimlikNumarasi) = 10 Then '' Else Replace (AliciFaturaAdresi,SUBSTRING(AliciFaturaAdresi,0,CHARINDEX (' ',AliciFaturaAdresi,0)),'') end 
,IsIndividualAcc=cAse when Len(VergiKimlikNumarasi) = 10 Then 'false' Else 'true' end 
,IdentityNum=cAse when Len(VergiKimlikNumarasi) = 10 Then '' Else'11111111111' end
,TaxNumber=cAse when Len(VergiKimlikNumarasi) = 10 Then VergiKimlikNumarasi Else '' end 
,TaxOfficeCode=''
,CurrencyCode='TRY'
,OfficeCode='M'
,IsSubjectToEInvoice= Case When (Select TaxID from e_SubjectToEInvoice where TaxId =VergiKimlikNumarasi) is null then 'false' else 'true' end 
--,WholeSalePriceGroupCode=Case When  UlkeField = 'Türkiye' Then 'PSF' else 'RCM_STD' end 
--,RetailSalePriceGroupCode=Case When  UlkeField = 'Türkiye' Then '' else 'RCM_STD' end 
,WholeSalePriceGroupCode=''
,RetailSalePriceGroupCode=''
--,CustomerTypeCode=0
,PostalAddresses=(select top 1 
AddressTypeCode = 1
,CountryCode = 'TR'
,StateCode = (
SELECT top 1 StateCode 
FROM cdCity
LEFT OUTER JOIN cdCityDesc ON cdCityDesc.CityCode = cdCity.CityCode
AND cdCityDesc.LangCode = 'TR'
and cdCity.CityCode like 'TR%'
WHERE (select top 1 FaturaAdresi from ZTMSGTrendyolSiparis as  a  where a.SiparisNumarasi =ZTMSGTrendyolSiparis.SiparisNumarasi)  LIKE '%' + cdCityDesc.CityDescription + '%'
)
,CityCode = (
SELECT top 1 cdCity.CityCode 
FROM cdCity
LEFT OUTER JOIN cdCityDesc ON cdCityDesc.CityCode = cdCity.CityCode
AND cdCityDesc.LangCode = 'TR'
and cdCity.CityCode like 'TR%'
WHERE (select top 1 FaturaAdresi from ZTMSGTrendyolSiparis as  a  where a.SiparisNumarasi =ZTMSGTrendyolSiparis.SiparisNumarasi)  LIKE '%' + cdCityDesc.CityDescription + '%'
)
,DistrictCode = 
(SELECT top 1 cdDistrict.DistrictCode 
FROM cdDistrict
LEFT OUTER JOIN cdDistrictDesc ON cdDistrictDesc.DistrictCode = cdDistrict.DistrictCode
AND cdDistrictDesc.LangCode = 'TR'
and cdDistrict.CityCode like 'TR%'
WHERE (select top 1 FaturaAdresi from ZTMSGTrendyolSiparis) LIKE '%' + cdDistrictDesc.DistrictDescription + '%'
and cdDistrict.CityCode = (
SELECT top 1 cdCity.CityCode 
FROM cdCity
LEFT OUTER JOIN cdCityDesc ON cdCityDesc.CityCode = cdCity.CityCode
AND cdCityDesc.LangCode = 'TR'
and cdCity.CityCode like 'TR%'
WHERE (select top 1 FaturaAdresi from ZTMSGTrendyolSiparis as  a  where a.SiparisNumarasi =ZTMSGTrendyolSiparis.SiparisNumarasi)  LIKE '%' + cdCityDesc.CityDescription + '%'
)
)
,Address = Convert(nvarchar(500),ZTMSGTrendyolSiparis.FaturaAdresi)

FROM ZTMSGTrendyolSiparis as a where a.SiparisNumarasi =ZTMSGTrendyolSiparis.SiparisNumarasi  For json Path)

,Communications=(select top 1 CommunicationTypeCode = 3,CommAddress = EPosta FROM ZTMSGTrendyolSiparis as a where a.SiparisNumarasi =ZTMSGTrendyolSiparis.SiparisNumarasi  For json Path)
from   ZTMSGTrendyolSiparis 
where ZTMSGTrendyolSiparis.EPosta not in (select Commaddress from prCurrAcccommunication)
and Fatura = 'Evet'
Group by SirketIsmi,ZTMSGTrendyolSiparis.VergiKimlikNumarasi,ZTMSGTrendyolSiparis.AliciFaturaAdresi,ZTMSGTrendyolSiparis.SiparisNumarasi, Convert(nvarchar(500),ZTMSGTrendyolSiparis.FaturaAdresi)

--select * from ZTMSGTrendyolSiparis where AliciFaturaAdresi like '% gülsüm durmuş%'
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxResim]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxResim] 

AS

select Marka,Url=XML from ZTMSGTicXmlUrl where Tur = 'Resim' 

--select * from ZTMSGTicXmlUrl
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxSiparisList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec MSG_TicimaxSiparisList''

	CREATE PROCEDURE [dbo].[MSG_TicimaxSiparisList](@StoreCode nvarchar(50))
	
AS
select Photo='\\192.168.2.38\Nebim Resim\'+prItemBarcode.ItemCode+'\ColorPhotos\'+prItemBarcode.ItemCode+'_'+prItemBarcode.ColorCode+'.jpg',ZTMSGTicSiparisList.SiparisID,AdiSoyadi,SiparisNo,Barkod,Adet,MagazaKodu,MarketPlaceKampanyaKodu,Siparistarihi,cdItemDesc.ItemCode,cdItemDesc.ItemDescription,cdColordesc.ColorCode,cdColorDesc.ColorDescription,Itemdim1code from ZTMSGTicSiparisList
Left Outer Join ZTMSGTicSiparisListDetay on ZTMSGTicSiparisListDetay.SiparisID = ZTMSGTicSiparisList.SiparisID
Left Outer Join prItemBarcode on prItemBarcode.Barcode = ZTMSGTicSiparisListDetay.Barkod
Left Outer Join cdItemDesc on cdItemDesc.Itemcode = prItemBarcode.ItemCode
and cdItemDesc.LangCode = 'TR'
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = prItemBarcode.ColorCode
and cdColorDesc.LangCode = 'TR'
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxStokCikar]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--054-855
--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxStokCikar] 

AS

select 
top 1
ModelType = 142,
OfficeCode='M'
,StoreCode='M01'
,WarehouseCode='M02'
,CompanyCode=1
,InnerProcessType=3
,Lines=ISNULL((
Select * from (
select top 30
ItemTypeCode=1
,UsedBarcode=Barcode
,Qty1=CAST(((StokAdedi-ISNULL(Envanter,0))*-1) AS DECIMAL(16,0)) 
,Qty2=0

from prItemBarcode
Inner Join (select Barkod,StokKodu,StokAdedi=SUM(StokAdedi) from ZTMSGTicSecenekler
where Barkod != ''
Group by Barkod,StokKodu) as b on b.Barkod = prItembarcode.Barcode
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'


Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code
where StokKodu in (select StokKodu from (
select 
ZTMSGTicSecenekler.StokKodu,
barkod,
Qty1=StokAdedi-ISNULL(Envanter,0)
,Qty2=0

from ZTMSGTicSecenekler
Inner Join prItemBarcode on prItemBarcode.Barcode = ZTMSGTicSecenekler.Barkod
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'
Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code
) as a where a.Qty1 <0) ) as a where a.Qty1 >0
 for json path),SPACE(0))
from ZTMSGTicSecenekler
where StokKodu in (
Select StokKodu from (
select top 30
ItemTypeCode=1
,StokKodu
,UsedBarcode=Barcode
,Qty1=CAST(((StokAdedi-ISNULL(Envanter,0))*-1) AS DECIMAL(16,0)) 
,Qty2=0

from prItemBarcode
Inner Join (select Barkod,StokKodu,StokAdedi=SUM(StokAdedi) from ZTMSGTicSecenekler
where Barkod != ''
Group by Barkod,StokKodu) as b on b.Barkod = prItembarcode.Barcode
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'


Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code
where StokKodu in (select StokKodu from (
select 
ZTMSGTicSecenekler.StokKodu,
barkod,
Qty1=StokAdedi-ISNULL(Envanter,0)
,Qty2=0

from ZTMSGTicSecenekler
Inner Join prItemBarcode on prItemBarcode.Barcode = ZTMSGTicSecenekler.Barkod
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'
Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code
) as a where a.Qty1 <0) ) as a where a.Qty1 >0

)
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxStokEkle]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--054-855
--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxStokEkle] 

AS

select 
top 1
ModelType = 142,
OfficeCode='M'
,StoreCode='M01'
,WarehouseCode='M02'
,CompanyCode=1
,InnerProcessType=2
,Lines=(select top 200 * from (select
ItemTypeCode=1
,UsedBarcode=Barcode
,Qty1=CAST((StokAdedi-ISNULL(Envanter,0)) AS DECIMAL(16,0)) 
,Qty2=0

from ZTMSGTicSecenekler
Inner Join prItemBarcode on prItemBarcode.Barcode = ZTMSGTicSecenekler.Barkod
Inner Join cdItem on CdItem.ItemCode = prItemBarcode.ItemCode
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'
Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code 
where  cdItem.UseInternet= 1
and cdItem.UseStore = 1
) as b
where b.Qty1 >0


 for json path)
from ZTMSGTicSecenekler
where StokKodu in (select StokKodu from (
select 
ZTMSGTicSecenekler.StokKodu,
Qty1=StokAdedi-ISNULL(Envanter,0)
,Qty2=0

from ZTMSGTicSecenekler
Inner Join prItemBarcode on prItemBarcode.Barcode = ZTMSGTicSecenekler.Barkod
LEft Outer Join (select Itemcode ,Colorcode,ItemDim1Code,Envanter =SUM(In_qty1-Out_Qty1) from trStock 
where WarehouseCode = 'M02'
Group by Itemcode ,Colorcode,ItemDim1Code
) as a on a.ItemCode = prItemBarcode.ItemCode
and a.ColorCode =  prItemBarcode.ColorCode
and a.ItemDim1Code = prItemBarcode.ItemDim1Code
) as a where a.Qty1 >0

)
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxUrun]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxUrun] 

AS

select Marka,Url=XML from ZTMSGTicXmlUrl where marka  = ''

--select top 1 Marka,Url=XML from ZTMSGTicXmlUrl where Tur = 'Urun'  and CreatedDate <= GETDATE()-'01:00:00.000'
--update ZTMSGTicXmlUrl set CreatedDate = GETDATE() where CreatedDate <= GETDATE()-'01:00:00.000'

--and XML in (select top 1 XML from ZTMSGTicXmlUrl where Tur = 'Urun'  and CreatedDate <= GETDATE()-'01:00:00.000')

--select * from ZTMSGTicXmlUrl
GO
/****** Object:  StoredProcedure [dbo].[MSG_TicimaxUrunListesi]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--054-855
--exec USP_MSZTTrendyolUrun '3452969287294','dasdas','dasdas',1,1,'dasdas',1,1,'dasdas',1,'dasdas',100,100.20,1
CREATE PROCEDURE [dbo].[MSG_TicimaxUrunListesi] 

AS

select colorcode= (select top 1 ColorCode from cdColor where Colorcode not like 'MON%' ORder by ColorCode desc)+(ROW_NUMBER() OVER(ORDER BY cdColorDesc.colorcode)), Deger into ztdeger from ZTMSGTicOzellikler
Left Outer Join cdColorDesc on cdColorDesc.ColorDescription = ZTMSGTicOzellikler.Deger
and cdColorDesc.LangCode = 'TR'
where Tanim ='Renk'
and cdColorDesc.ColorDescription is null
and cdColorDesc.ColorCode not like 'MON%'
Group by Deger,cdColorDesc.colorcode
Insert Into cdColor(ColorCode,ColorHex,ColorCatalogCode1,ColorCatalogCode2,ColorCatalogCode3,IsBlocked)
select colorcode,ColorHex='',ColorCatalogCode1='',ColorCatalogCode2='',ColorCatalogCode3='',IsBlocked=0 from ztdeger
Insert Into cdColorDesc(ColorCode,LangCode,ColorDescription)
select colorcode,'TR',Deger from ztdeger
Drop Table ztdeger

select  ModelType=4, ItemTypeCode=1, ItemCode=(select top 1 KisaKod from ZTMSGTicXmlUrl where ZTMSGTicXmlUrl.Marka = b.Marka)+a.StokKodu
, ItemDescription=UrunAdi, ItemDimTypeCode=2
, ItemTaxGrCode='%8',
ProductHierarchyID=ISNULL(ZTMSGTicKategoriler.NebimKategoriID,0)
,UsePOS='True'
,UseStore='True'
,UseInternet = 'True'
,UnitOfMeasureCode1= 'AD',
UseBatch='False'
,UseInternet='True'
,UseManufacturing='False'
,UsePOS='True'
,UseRoll='False'
,UseSerialNumber='False'
,

Variant=(

Select ColorCode=cdColorDesc.ColorCode, ItemDim1Code =ISNULL((beden.Deger),SPACE(0))  
from ZTMSGTicUrunler
Left Outer Join ZTMSGTicSecenekler on ZTMSGTicSecenekler.UrunKartiID = ZTMSGTicUrunler.UrunKartiID
LEft Outer Join ZTMSGTicOzellikler on ZTMSGTicOzellikler.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
and ZTMSGTicOzellikler.Tanim = 'Renk'
Left Outer Join cdColorDesc on cdColorDesc.ColorDescription = ZTMSGTicOzellikler.Deger
and cdColorDesc.LangCode = 'TR'
LEft Outer Join ZTMSGTicOzellikler as beden on beden.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
and beden.Tanim = 'Beden'
where ColorCode not like 'MON%'
and ZTMSGTicSecenekler.UrunKartiID = b.UrunKartiID
for json path)

,ProductLots= (select DeleteWithProductLotBarcode = 'False',IsDefault='True' , LotCode = OzelAlan2 from ZTMSGTicUrunler as a where a.UrunKartiID = b.UrunKartiID   for Json path)
,BasePrices=(
select * from (
select BasePriceCode = 8 ,CountryCode='TR',CurrencyCode='TRY',Price=SatisFiyati,PriceDate=convert(varchar, getdate(), 105) from ZTMSGTicSecenekler as Satis where satis.UrunKartiID = b.UrunKartiID
Group by SatisFiyati
UNION ALL
select BasePriceCode = 7 ,CountryCode='TR',CurrencyCode='TRY',Price=IndirimliFiyat,PriceDate=convert(varchar, getdate(), 105) from ZTMSGTicSecenekler as indirim where indirim.UrunKartiID = b.UrunKartiID
Group by IndirimliFiyat
UNION ALL
select BasePriceCode = 2 ,CountryCode='TR',CurrencyCode='TRY',Price=AlisFiyati,PriceDate=convert(varchar, getdate(), 105) from ZTMSGTicSecenekler as alis where alis.UrunKartiID = b.UrunKartiID
Group by AlisFiyati) as a
for json path)
,Barcodes =(select Barcode =barkod,BarcodeTypeCode='AEAN13',Colorcode,ItemDim1Code =beden.deger,Qty=1,UnitOfMeasureCode='AD' from ZTMSGTicSecenekler
LEft Outer Join ZTMSGTicOzellikler on ZTMSGTicOzellikler.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
and ZTMSGTicOzellikler.Tanim = 'Renk'
and ZTMSGTicOzellikler.Marka = ZTMSGTicSecenekler.Marka
LEft Outer Join ZTMSGTicOzellikler as beden on beden.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
and beden.Tanim = 'Beden'
and beden.Marka = ZTMSGTicSecenekler.Marka
Left Outer Join cdColorDesc on cdColorDesc.ColorDescription = ZTMSGTicOzellikler.Deger
and cdColorDesc.LangCode = 'TR'
where  ColorCode not like 'MON%' 
and ZTMSGTicSecenekler.UrunKartiID = b.UrunKartiID
for json path)

,Descriptions= (Select DataLanguageCode ='TR',Description=UrunAdi from ZTMSGTicUrunler as Urun where Urun.UrunKartiID = b.UrunKartiID for json path)
,ItemNotes = (select LangCode='TR',Notes=Aciklama,PlainText=Aciklama from ZTMSGTicUrunler as Acik where Acik.UrunKartiID = b.UrunKartiID for json path)
from ZTMSGTicUrunler as b
Left Outer Join ZTMSGTicSecenekler as a on a.UrunKartiID = b.UrunKartiID
and a.Marka = b.Marka
LEft Outer Join ZTMSGTicOzellikler on ZTMSGTicOzellikler.VaryasyonID = a.VaryasyonID
and ZTMSGTicOzellikler.Tanim = 'Renk'
and ZTMSGTicOzellikler.Marka = a.Marka
Left Outer Join cdColorDesc on cdColorDesc.ColorDescription = ZTMSGTicOzellikler.Deger
and cdColorDesc.LangCode = 'TR'
LEft Outer Join ZTMSGTicOzellikler as beden on beden.VaryasyonID = a.VaryasyonID
and beden.Tanim = 'Beden'
and beden.Marka = a.Marka
Left Outer Join prItemBarcode on prItemBarcode.Barcode = a.Barkod
Left Outer Join ZTMSGTicKategoriler on ZTMSGTicKategoriler.KategoriID = b.KategoriID
where cdColorDesc.ColorCode not like 'MON%' 
and a.Barkod != ''
and prItemBarcode.Barcode is null

Group by a.StokKodu,UrunAdi,b.UrunKartiID, b.Marka
,ZTMSGTicKategoriler.NebimKategoriID
GO
/****** Object:  StoredProcedure [dbo].[MSG_TrendyolResimIndirListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec ZTTrendyolResimIndir '3452969287294','https://www.sampleadress/path/folder/image_1.jpg'
CREATE PROCEDURE [dbo].[MSG_TrendyolResimIndirListe] 


AS

--select * from ZTMSGTicUrunler 
--select * from ZTMSGTicSecenekler


drop table ZTMSGTicResimlerYedek
select ID=ZTMSGTicResimler.UrunKartiID,barcode =MAX(ZTMSGTicSecenekler.Barkod),url=ZTMSGTicResimler.ResimAdresi,IndirmeDurumu,ZTMSGTicResimler.Marka into ZTMSGTicResimlerYedek from ZTMSGTicResimler 
Inner Join (

select ZTMSGTicSecenekler.UrunKartiID,VaryasyonID=MAX(ZTMSGTicSecenekler.VaryasyonID),deger from ZTMSGTicSecenekler
Left Outer Join ZTMSGTicOzellikler on ZTMSGTicOzellikler.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
where  Tanim = 'Renk' 
Group by ZTMSGTicSecenekler.UrunKartiID,deger


) as a on a.UrunKartiID = ZTMSGTicResimler.UrunKartiID

Left Outer Join ZTMSGTicSecenekler on ZTMSGTicSecenekler.UrunKartiId = ZTMSGTicResimler.UrunKartiID
--where ZTMSGTicResimler.ResimAdresi = 'https://static.ticimax.cloud/37827/Uploads/UrunResimleri/buyuk/boydan-boya-kurklu-agraf-kapamali-kisa-4-2d44.jpg'
Group by ZTMSGTicResimler.UrunKartiID,ZTMSGTicResimler.ResimAdresi,ZTMSGTicResimler.Marka,ZTMSGTicResimler.IndirmeDurumu--,ZTMSGTicResimler.VaryasyonID
ORder by ZTMSGTicResimler.UrunKartiID


delete ZTMSGTicResimler
Insert Into ZTMSGTicResimler(UrunKartiID,VaryasyonID,ResimAdresi,IndirmeDurumu,Marka)
Select ID,0,Url,IndirmeDurumu,Marka from ZTMSGTicResimlerYedek


select ID=ZTMSGTicResimler.UrunKartiID,barcode =MAX(ZTMSGTicSecenekler.Barkod),url=ZTMSGTicResimler.ResimAdresi,ZTMSGTicResimler.Marka  from ZTMSGTicResimler 
Inner Join (

select ZTMSGTicSecenekler.UrunKartiID,VaryasyonID=MAX(ZTMSGTicSecenekler.VaryasyonID),deger from ZTMSGTicSecenekler
Left Outer Join ZTMSGTicOzellikler on ZTMSGTicOzellikler.VaryasyonID = ZTMSGTicSecenekler.VaryasyonID
where  Tanim = 'Renk' 
Group by ZTMSGTicSecenekler.UrunKartiID,deger


) as a on a.UrunKartiID = ZTMSGTicResimler.UrunKartiID

Left Outer Join ZTMSGTicSecenekler on ZTMSGTicSecenekler.UrunKartiId = ZTMSGTicResimler.UrunKartiID
where ZTMSGTicResimler.IndirmeDurumu = 'Başarısız'
--where ZTMSGTicResimler.ResimAdresi = 'https://static.ticimax.cloud/37827/Uploads/UrunResimleri/buyuk/boydan-boya-kurklu-agraf-kapamali-kisa-4-2d44.jpg'
Group by ZTMSGTicResimler.UrunKartiID,ZTMSGTicResimler.ResimAdresi,ZTMSGTicResimler.Marka--,ZTMSGTicResimler.VaryasyonID
ORder by ZTMSGTicResimler.UrunKartiID

GO
/****** Object:  StoredProcedure [dbo].[MSG_UrunListe]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from prItemBarcode
--select * from ZTMSRAFSAYIM
--exec Get_MSRAFSAYIMOffline '1234567891234','D-G-01-02',0
--exec Get_MSRAFSAYIMOffline 'D-G-01-02','D-G-01-02',0

--exec Get_MSSiparisToplaUrun '4455A886-E096-450F-9F6B-2716ACE3E8F5','FG 848-012 F L',1
--select * from  Get_MSSiparisTopla where CategoryDescription like '%Mikro%'
	CREATE PROCEDURE [dbo].[MSG_UrunListe]

AS
Insert Into  cdDataLanguage(DataLanguageCode,IsRequired,IsBlocked) 
Select 'EN',0,0 where 'EN' not in (Select DataLanguageCode from cdDataLanguage)
Insert Into  cdDataLanguage(DataLanguageCode,IsRequired,IsBlocked)
Select 'RU',0,0 where 'RU' not in (Select DataLanguageCode from cdDataLanguage)
Insert Into  cdDataLanguage(DataLanguageCode,IsRequired,IsBlocked)
Select 'AR',0,0 where 'AR' not in (Select DataLanguageCode from cdDataLanguage)
Insert Into  cdDataLanguage(DataLanguageCode,IsRequired,IsBlocked)
Select 'FR',0,0 where 'FR' not in (Select DataLanguageCode from cdDataLanguage)
Insert Into  cdDataLanguage(DataLanguageCode,IsRequired,IsBlocked)
Select 'DE',0,0 where 'DE' not in (Select DataLanguageCode from cdDataLanguage)


select * from (

select cdItemDesc.ItemCode,cdItemDesc.ItemDescription from cdItemDesc
Left Outer Join cdItemDesc as EN on EN.ItemCode = cdItemDesc.ItemCode
and EN.LangCode in ('EN')
where cdItemDesc.LangCode = 'TR'
and EN.ItemCode is null
and cdItemDesc.ItemTypeCode = 1
UNION ALL 

select cdItemDesc.ItemCode,cdItemDesc.ItemDescription from cdItemDesc
Left Outer Join cdItemDesc as EN on EN.ItemCode = cdItemDesc.ItemCode
and EN.LangCode in ('RU' )
where cdItemDesc.LangCode = 'TR'
and EN.ItemCode is null
and cdItemDesc.ItemTypeCode = 1
UNION ALL 

select cdItemDesc.ItemCode,cdItemDesc.ItemDescription from cdItemDesc
Left Outer Join cdItemDesc as EN on EN.ItemCode = cdItemDesc.ItemCode
and EN.LangCode in ('AR' )
where cdItemDesc.LangCode = 'TR'
and EN.ItemCode is null
and cdItemDesc.ItemTypeCode = 1
UNION ALL 

select cdItemDesc.ItemCode,cdItemDesc.ItemDescription from cdItemDesc
Left Outer Join cdItemDesc as EN on EN.ItemCode = cdItemDesc.ItemCode
and EN.LangCode in ( 'FR')
where cdItemDesc.LangCode = 'TR'
and EN.ItemCode is null
and cdItemDesc.ItemTypeCode = 1
UNION ALL 

select cdItemDesc.ItemCode,cdItemDesc.ItemDescription from cdItemDesc
Left Outer Join cdItemDesc as EN on EN.ItemCode = cdItemDesc.ItemCode
and EN.LangCode in ( 'DE' )
where cdItemDesc.LangCode = 'TR'
and EN.ItemCode is null
and cdItemDesc.ItemTypeCode = 1
) as a
where a.ItemDescription not in ('','.',',')
and Itemcode like 'MS%'
Group by Itemcode,ItemDescription
GO
/****** Object:  StoredProcedure [dbo].[MSGMusteriUrunList]    Script Date: 21.02.2024 02:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[MSGMusteriUrunList]
                                                 	
  
AS



select 

[Ürün Kodu]=cdItem.ItemCode
,[Ürün Adi]=cdItemDesc.ItemDescription
,[Renk Kodu]= prItemVariant.ColorCode
,ColorDescription
,Beden= prItemVariant.ItemDim1Code
,Barkod=prItemBarcode.Barcode
,Envanter=ISNULL((Select SUM(In_Qty1-Out_Qty1) from trStock 
where trStock.ITemcode = prITemvariant.Itemcode
and trStock.Colorcode = prItemvariant.Colorcode
and trStock.Itemdim1code = prItemvariant.Itemdim1code ),0)
,[Misigo Web Satış]=ISNULL((prItemBasePrice.Price),0)
,[Misigo Web Minimum Satış]=ISNULL((prItemBasePrice.Price),0)
,[Misigo Pazaryeri Satış]=ISNULL((prItemBasePrice.Price),0)
,[Misigo Pazaryeri Minimum Satış]=ISNULL((prItemBasePrice.Price),0)
,ProductHierarchyLevel01
,ProductHierarchyLevel02
,ProductHierarchyLevel03
,ProductHierarchyLevel04
,ProductHierarchyLevel05
,ProductAtt01Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 1),SPACE(0))
,ProductAtt01Desc
,ProductAtt02Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 2),SPACE(0))
,ProductAtt02Desc
,ProductAtt03Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 3),SPACE(0))
,ProductAtt03Desc
,ProductAtt04Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 4),SPACE(0))
,ProductAtt04Desc
,ProductAtt05Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 5),SPACE(0))
,ProductAtt05Desc
,ProductAtt06Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 6),SPACE(0))
,ProductAtt06Desc
,ProductAtt07Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 7),SPACE(0))
,ProductAtt07Desc
,ProductAtt08Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 8),SPACE(0))
,ProductAtt08Desc
,ProductAtt09Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 9),SPACE(0))
,ProductAtt09Desc
,ProductAtt10Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 10),SPACE(0))
,ProductAtt10Desc
,ProductAtt11Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 11),SPACE(0))
,ProductAtt11Desc
,ProductAtt12Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 12),SPACE(0))
,ProductAtt12Desc
,ProductAtt13Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 13),SPACE(0))
,ProductAtt13Desc
,ProductAtt14Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 14),SPACE(0))
,ProductAtt14Desc
,ProductAtt15Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 15),SPACE(0))
,ProductAtt15Desc
,ProductAtt16Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 16),SPACE(0))
,ProductAtt16Desc
,ProductAtt17Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 17),SPACE(0))
,ProductAtt17Desc
,ProductAtt18Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 18),SPACE(0))
,ProductAtt18Desc
,ProductAtt19Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 19),SPACE(0))
,ProductAtt19Desc
,ProductAtt20Type = ISNULL((select AttributeTypeDescription from cdItemAttributeTypeDesc where LangCode = 'TR' and ItemTypeCode = 1 and AttributeTypeCode = 20),SPACE(0))
,ProductAtt20Desc
from  cdItem
Left Outer Join cdItemDesc  on cdItemdesc.Itemcode = cdItem.ItemCode
and cdItemDesc.LangCode = 'TR'
Left Outer Join prItemVariant on prItemVariant.ItemCode = cdItem.ItemCode
Left Outer Join prItemBarcode on prItemBarcode.ItemCode = prItemVariant.ItemCode
and prItemBarcode.ColorCode = prItemVariant.ColorCode
and prItemBarcode.ItemDim1Code = prItemVariant.ItemDim1Code
and prItemBarcode.BarcodeTypeCode = 'AEAN13'
Left Outer Join prItemBasePrice on prItemBasePrice.ItemCode = cdItem.ItemCode
and prItemBasePrice.BasePriceCode = 7
Left Outer Join  ProductHierarchy('TR') on ProductHierarchy.ProductHierarchyID = cdItem.ProductHierarchyID
Left Outer Join ProductAttributeDescriptions('TR') on ProductAttributeDescriptions.ItemTypeCode = cdItem.ItemTypeCode
and ProductAttributeDescriptions.ItemCode = cdItem.ItemCode
Left Outer Join cdColorDesc on cdColorDesc.ColorCode = prItemVariant.ColorCode
and cdColorDesc.LangCode = 'TR'

where cdItem.ItemCode not like  'MS%'
and cdItem.Itemcode in (select Itemcode from sp_Product_Ticimax_ItemLastUpdated_V1_0_0_1FN(GETDATE()-'12:00:00.000','TR','M02'))
GO
