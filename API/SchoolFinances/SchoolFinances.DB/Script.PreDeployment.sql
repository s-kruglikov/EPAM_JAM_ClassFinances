/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS dbo.l_donate_to_class;

DROP TABLE IF EXISTS dbo.l_donate_to_kid;

DROP TABLE IF EXISTS dbo.l_user_to_class;

DROP TABLE IF EXISTS dbo.l_user_to_kid;

DROP TABLE IF EXISTS dbo.classes;

DROP TABLE IF EXISTS dbo.kids;

DROP TABLE IF EXISTS dbo.donates;

DROP TABLE IF EXISTS dbo.users;
