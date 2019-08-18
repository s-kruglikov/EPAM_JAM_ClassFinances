CREATE TABLE [dbo].[l_user_to_class] (
    [id]       INT            IDENTITY (1, 1) NOT NULL,
    [user_id]  INT            NOT NULL,
    [class_id] INT            NOT NULL,
    [role]     NVARCHAR (MAX) NOT NULL,
    [active]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_l_user_to_class_ToUsers] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([user_id]),
    CONSTRAINT [FK_l_user_to_class_ToClasses] FOREIGN KEY ([class_id]) REFERENCES [dbo].[classes] ([class_id])
);

