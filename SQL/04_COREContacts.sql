USE COREContacts;

ALTER TABLE [dbo].[contacts]
DROP CONSTRAINT [CHK_Email];

ALTER TABLE [dbo].[contacts]
DROP CONSTRAINT [CHK_TwitterUsername];