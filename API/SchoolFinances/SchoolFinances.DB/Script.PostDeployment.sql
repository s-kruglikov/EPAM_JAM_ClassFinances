
/* Fill [users] */
SET IDENTITY_INSERT [dbo].[users] ON

INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (1, N'Аникеева', N'Мария', N'Mary', N'OIU987', N'375295123654', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (2, N'Бобриковa', N'Александра', N'Alex', N'QWS667', N'375295123699', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (3, N'Буд-Гусаим', N'Вадим', N'Vadim', N'Vadim', N'375294588636', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (4, N'Буд-Гусаим', N'Светлана', N'SBG', N'POI789', N'375298878955', N'user', 1);
INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (5, N'Гриневич', N'Наталья', N'SuperMother', N'TTY987', N'375293554897', N'user', 1);

INSERT INTO [dbo].[users] ([user_id], [last_name], [first_name], [user_name], [password], [phone_number], [role], [active]) VALUES (6, N'admin', N'admin', N'admin', N'admin', N'375291112233', N'admin', 1);

SET IDENTITY_INSERT [dbo].[users] OFF

/* Fill [classes] */
SET IDENTITY_INSERT [dbo].[classes] ON

INSERT INTO [dbo].[classes] ([class_id], [class_name]) VALUES (1, N'1A СШ №50');
INSERT INTO [dbo].[classes] ([class_id], [class_name]) VALUES (2, N'6 гр ДДУ 230');

SET IDENTITY_INSERT [dbo].[classes] OFF

/* Fill [kids] */
SET IDENTITY_INSERT [dbo].[kids] ON

INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (1, N'Аникеева', N'Дарья', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (2, N'Бобриков', N'Иван', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (3, N'Борисенко', N'Дмитрий', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (4, N'Буд-Гусаим', N'Анна', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (5, N'Гриневич', N'Саша', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (6, N'Гриневич', N'Пётр', 1);
INSERT INTO [dbo].[kids] ([kid_id], [last_name], [first_name], [active]) VALUES (7, N'Дрозд', N'Катя', 1);

SET IDENTITY_INSERT [dbo].[kids] OFF