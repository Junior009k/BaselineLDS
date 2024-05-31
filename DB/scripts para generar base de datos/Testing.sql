


SELECT TOP (1000) [id]
      ,[name]
      ,[username]
      ,[password]
  FROM [BLOG].[dbo].[User]


update [User] set [User].[password]='e10adc3949ba59abbe56e057f20f883e' where [username] like 'junior009k'
update [User] set [User].[password]='PRUEBA' where [username] like 'junior009k'

update [User] set [User].[name]='Junior Aquino' where [username] like 'junior009k'
update [User] set [User].[name]='PRUEBA' where [username] like 'junior009k'

delete [User]  where [username] like 'junior0010k'