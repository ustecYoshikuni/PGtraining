CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderNo] NCHAR(8) NOT NULL, 
    [StudyDate] NCHAR(8) NOT NULL, 
    [ProcessingType] NCHAR(1) NOT NULL, 
    [InspectionType] NVARCHAR(8) NOT NULL, 
    [InspectionName] NVARCHAR(32) NOT NULL, 
    [PatientId] NCHAR(10) NOT NULL, 
    [PatientNameKanji] NVARCHAR(64) NOT NULL, 
    [PatientNameKana] NVARCHAR(64) NOT NULL, 
    [PatientBirth] NCHAR(8) NOT NULL, 
    [PatientSex] NCHAR(1) NOT NULL 
)
