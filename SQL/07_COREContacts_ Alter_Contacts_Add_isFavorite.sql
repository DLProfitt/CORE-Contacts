USE [COREContacts]

ALTER TABLE [dbo].[contacts]
ADD [isFavorite] BIT DEFAULT 0 NOT NULL;
