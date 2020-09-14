CREATE VIEW [dbo].[OrderView]
	AS
    Select
 O.[OrderNo]
,O.[StudyDate]
,O.[ProcessingType]
,O.[InspectionType]
,O.[InspectionName]
,O.[PatientId]
,O.[PatientNameKanji]
,O.[PatientNameKana]
,O.[PatientBirth]
,O.[PatientSex]
,M.codes AS MenuCodes
,M.names As MenuNames
from Orders As O
 INNER JOIN 
  (SELECT Main.OrderNo,
   LEFT(Main.names,Len(Main.names)-1) As "names"
 , LEFT(Main.codes,Len(Main.codes)-1) As "codes"
FROM
    (

        SELECT DISTINCT M.OrderNo, 
            (
                SELECT M1.MenuName + ',' AS [text()]
                FROM Menu as M1
                WHERE M1.OrderNo = M.OrderNo
                ORDER BY M1.OrderNo
                FOR XML PATH ('')
            ) names,
            (
                SELECT M1.MenuCode + ',' AS [text()]
                FROM Menu as M1
                WHERE M1.OrderNo = M.OrderNo
                ORDER BY M1.OrderNo
                FOR XML PATH ('')
            ) codes
        FROM Menu  as  M
    ) as Main)
 as M 
	ON O.OrderNo = M.OrderNo
    
		
