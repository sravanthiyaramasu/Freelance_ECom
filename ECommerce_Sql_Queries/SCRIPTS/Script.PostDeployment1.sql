/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select * from Roles where RoleName='Admin')
INSERT INTO Roles VALUES(1, 'Admin')
if not exists (select * from Roles where RoleName='Customer')
INSERT INTO Roles VALUES(2, 'Customer')
DELETE FROM Roles WHERE RoleName = 'Reader' OR RoleName = 'write'

--if not exists (select * from Roles where RoleName='Reader')
--INSERT INTO Roles VALUES(3, 'Reader')
--if not exists (select * from Roles where RoleName='write')
--INSERT INTO Roles VALUES(4, 'write')
--if exists (select * from Roles where RoleName='write')
--Update Roles set RoleName = 'Write' where RoleId = (select RoleId from Roles where RoleName = 'write')
