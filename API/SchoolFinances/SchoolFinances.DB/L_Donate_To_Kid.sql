CREATE TABLE [dbo].[l_donate_to_kid]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [class_id] INT NOT NULL, 
    [donate_id] INT NOT NULL, 
    [kid_id] INT NOT NULL, 
    [active] BIT NOT NULL, 
    CONSTRAINT [FK_l_donate_to_kid_ToClass] FOREIGN KEY ([class_id]) REFERENCES [classes]([class_id]), 
    CONSTRAINT [FK_l_donate_to_kid_ToDonate] FOREIGN KEY ([donate_id]) REFERENCES [donates]([donate_id]), 
    CONSTRAINT [FK_l_donate_to_kid_ToKid] FOREIGN KEY ([kid_id]) REFERENCES [kids]([kid_id])
)
