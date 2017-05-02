select * from syscolumns where id=(select id from sysobjects where name='amEventLog')

exec sp_help 'dbo.amEventLog'