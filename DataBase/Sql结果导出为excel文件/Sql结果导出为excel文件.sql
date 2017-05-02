---导出到Excel
---使用说明：
--        1.执行时所连接的服务器决定文件存放在哪个服务器
--        2.远程查询语句中，要加上数据库名
alter PROC ExportFile 
     @QuerySql VARCHAR(max) 
    ,@Server VARCHAR(20)='.' 
    ,@User VARCHAR(20) ='sa'
    ,@Password VARCHAR(20) = 'sa' 
    ,@FilePath NVARCHAR(100) = 'c:\ExportFile.xls'
AS
    DECLARE @tmp VARCHAR(50)
	set @tmp = '[##Table' + CONVERT(VARCHAR(36),NEWID())+']';
    BEGIN TRY
        DECLARE @Sql VARCHAR(max),@DataSource VARCHAR(max);
		set @Sql = ''
		set @DataSource = ''
        --判断是否为远程服务器
        IF @Server <> '.' AND @Server <> '127.0.0.1'
            SET @DataSource = 'OPENDATASOURCE(''SQLOLEDB'',''Data Source='+@Server+';User ID='+@User+';Password='+@Password+''').'
        --将结果集导出到指定的数据库
        SET @Sql = REPLACE(@QuerySql,' from ',' into '+@tmp+ ' from ' + @DataSource)
        EXEC(@Sql)
		print @tmp
        DECLARE @Columns VARCHAR(max),@Data NVARCHAR(max)
		set @Columns = ''
		set @Data = ''
        SELECT @Columns = @Columns + ',''' + name +''''--获取列名（xp_cmdshell导出文件没有列名）
            ,@Data = @Data + ',Convert(Nvarchar,[' +name +'])'--将结果集所在的字段更新为nvarchar（避免在列名和数据union的时候类型冲突）
        FROM tempdb.sys.columns WHERE object_id = OBJECT_ID('tempdb..'+@tmp)
        SELECT @Data  = 'SELECT ' + SUBSTRING(@Data,2,LEN(@Data)) + ' FROM ' + @tmp
        SELECT @Columns =  'Select ' + SUBSTRING(@Columns,2,LEN(@Columns))
        --使用xp_cmdshell的bcp命令将数据导出
        EXEC sp_configure 'xp_cmdshell',1
        RECONFIGURE
        DECLARE @cmd NVARCHAR(4000) 
		set @cmd = 'bcp "' + @Columns+' Union All ' + @Data+'" queryout ' + @FilePath + ' -c -T'
        PRINT @cmd
        exec sys.xp_cmdshell @cmd
        EXEC sp_configure 'xp_cmdshell',0
        RECONFIGURE
        EXEC('DROP TABLE ' + @tmp)
    END TRY
    BEGIN CATCH
        --处理异常
        IF OBJECT_ID('tempdb..'+@tmp) IS NOT NULL
            EXEC('DROP TABLE ' + @tmp)
        EXEC sp_configure 'xp_cmdshell',0
        RECONFIGURE
        
        SELECT ERROR_MESSAGE()
    END CATCH



----本地导出
--EXEC dbo.ExportFile @QuerySql = 'select * from football.dbo.AsiaCompany'
--
----远程导出
--EXEC dbo.ExportFile @QuerySql = 'select * from football.dbo.AsiaCompany', -- varchar(max)
--    @Server = '192.168.0.18', 
--    @User = 'sa', 
--    @Password = 'sa', 
--    @FilePath = N'c:\52objects.xls' 
