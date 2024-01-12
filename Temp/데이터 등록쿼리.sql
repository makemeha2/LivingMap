USE [LivingMapDB]
/*
	App 공통코드 등록
	select * from CommonCode
*/
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV01', N'의류수거함', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV02', N'폐의약품', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV03', N'폐건전지', 1)
GO
INSERT [dbo].[CommonCode] ([CodeGroup], [Code], [CodeName], [UseYN]) VALUES (N'DIV_GRP', N'DIV04', N'흡연구역', 1)

/*
	행정구역 마스터 코드 등록
	select * from AdmCode
*/
insert into AdmCode(Area1Code, Area1Name, Area2Code, Area2Name, CreateDate)
select F1, max(F2), F3, max(F4), GETDATE() 
from [dbo].['2023년6월$'] 
where f1 is not null 
group by F1, F3 
order by f1, F3

/*
	행정구역별 수거함 주소 정보 등록 (수기 등록, 추후 UI 관리)

	//select max(area1Code) from AdmCode where Area1Name = '강원특별자치도'
	select max(area1Code), max(area2Code) from AdmCode where Area1Name = '서울특별시' and Area2Name = '성동구'
*/


insert into AddrExtrInfo(Div, Area1Code, Area2Code, FileName, FilePath, FileRegistDate, IFSuccessYN, IFDate, ExtractType, ReflectionClsName, AddressIndex)
values
	('DIV01', '32', '010', N'강원도 춘천시_의류수거함 현황_20221128.csv', N'C:\99_TEMP\의류수거함 정보파일\강원도 춘천시_의류수거함 현황_20221128.csv', getdate(), 0, null, 'Custom', null, -1),
	('DIV01', '11', '210', N'서울특별시 관악구_의류수거함위치_20210121.csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 관악구_의류수거함위치_20210121.csv', getdate(), 0, null, 'Custom', null, -1),
	('DIV01', '11', '200', N'서울특별시 동작구_의류수거함 위치 데이터_20230822.csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 동작구_의류수거함 위치 데이터_20230822.csv', getdate(), 0, null, 'Custom', null, -1),
	('DIV01', '11', '130', N'서울특별시 서대문구_서대문구 의류수거함 위치현황_20201005 (1).csv', N'C:\99_TEMP\의류수거함 정보파일\서울특별시 서대문구_서대문구 의류수거함 위치현황_20201005 (1).csv', getdate(), 0, null, 'Custom', null, -1),
	('DIV01', '11', '040', N'', N'', getdate(), 0, null, 'None', '', -1)