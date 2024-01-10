USE [LivingMapDB]
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV01', N'의류수거함', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV02', N'폐의약품', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV03', N'폐건전지', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV04', N'흡연구역', 1)
GO
SET IDENTITY_INSERT [dbo].[InterfaceTarget] ON 
GO
INSERT [dbo].[InterfaceTarget] ([Idx], [Div], [Area1], [Area2], [FileName], [FilePath], [CompletedIF], [RegistDate], [IFDate]) VALUES (1, N'DIV01', N'강원도', N'춘천시', N'강원도 춘천시_의류수거함 현황_20221128.csv', N'C:\99_TEMP\의류수거함 정보파일\강원도 춘천시_의류수거함 현황_20221128.csv', 1, CAST(N'2024-01-04' AS Date), CAST(N'2024-01-05' AS Date))
GO
INSERT [dbo].[InterfaceTarget] ([Idx], [Div], [Area1], [Area2], [FileName], [FilePath], [CompletedIF], [RegistDate], [IFDate]) VALUES (2, N'DIV01', N'서울특별시', N'관악구', N'서울특별시 관악구_의류수거함위치_20210121.csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 관악구_의류수거함위치_20210121.csv', 1, CAST(N'2024-01-04' AS Date), CAST(N'2024-01-05' AS Date))
GO
INSERT [dbo].[InterfaceTarget] ([Idx], [Div], [Area1], [Area2], [FileName], [FilePath], [CompletedIF], [RegistDate], [IFDate]) VALUES (3, N'DIV01', N'서울특별시', N'동작구', N'서울특별시 동작구_의류수거함 위치 데이터_20230822.csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 동작구_의류수거함 위치 데이터_20230822.csv', 1, CAST(N'2024-01-04' AS Date), CAST(N'2024-01-05' AS Date))
GO
INSERT [dbo].[InterfaceTarget] ([Idx], [Div], [Area1], [Area2], [FileName], [FilePath], [CompletedIF], [RegistDate], [IFDate]) VALUES (4, N'DIV01', N'서울특별시', N'서대문구', N'서울특별시 서대문구_서대문구 의류수거함 위치현황_20201005 (1).csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 서대문구_서대문구 의류수거함 위치현황_20201005 (1).csv', 1, CAST(N'2024-01-04' AS Date), CAST(N'2024-01-05' AS Date))
GO
SET IDENTITY_INSERT [dbo].[InterfaceTarget] OFF
GO


insert into InterfaceTargetConfig(TargetIdx, ExtractType, ExtractFuncName, Area1Index, Area2Index, Area3Index, AddressIndex, LatitudeIndex, LongitudeIndex) values
	(1, 'Custom', 'DataRegister.ExtractService.Custom.Chuncheonsi', null, null, null, null, null, null),
	(2, 'Custom', 'DataRegister.ExtractService.Custom.Kwanakku', null, null, null, null, null, null),
	(3, 'Auto', '', null, null, 1, 2, null, null),
	(4, 'Auto', '', null, null, 3, 4, null, null),
	(5, 'None', '', null, null, null, null, null, null)
