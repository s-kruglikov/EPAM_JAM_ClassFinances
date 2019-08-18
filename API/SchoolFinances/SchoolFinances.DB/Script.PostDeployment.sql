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

SET IDENTITY_INSERT [dbo].[users] ON

INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (1, N'Аникеева', N'Мария', N'Mary', N'OIU987', N'375295123654', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (2, N'Бобриковa', N'Александра', N'Alex', N'QWS667', N'375295123699', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (3, N'Буд-Гусаим', N'Вадим', N'Vadim', N'Vadim', N'375294588636', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (4, N'Буд-Гусаим', N'Светлана', N'SBG', N'POI789', N'375298878955', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (5, N'Гриневич', N'Наталья', N'SuperMother', N'TTY987', N'375293554897', N'user', 1);

INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (6, N'admin', N'admin', N'admin', N'admin', N'375291112233', N'admin', 1);

SET IDENTITY_INSERT [dbo].[users] OFF

SET IDENTITY_INSERT [dbo].[classes] ON

INSERT INTO [dbo].[classes] ([class_id], [class_name]) VALUES (1, N'1A СШ №50');
INSERT INTO [dbo].[classes] ([class_id], [class_name]) VALUES (2, N'6 гр ДДУ 230');

SET IDENTITY_INSERT [dbo].[classes] OFF