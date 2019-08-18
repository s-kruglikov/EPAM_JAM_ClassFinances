CREATE TABLE [dbo].[l_donate_to_class]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [class_id] INT NOT NULL, 
    [user_id] INT NOT NULL, 
    CONSTRAINT [FK_l_donation_to_class_ToClass] FOREIGN KEY ([class_id]) REFERENCES [classes]([class_id]), 
    CONSTRAINT [FK_l_donation_to_class_ToUser] FOREIGN KEY ([user_id]) REFERENCES [users]([user_id])
)
