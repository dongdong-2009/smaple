--1
--create table #Data(name varchar(100),row varchar(100),reserved varchar(100),data varchar(100),index_size varchar(100),unused varchar(100)) 
 
--declare @name varchar(100) 
--declare cur cursor  for 
--    select name from sysobjects where xtype='u' order by name 
--open cur 
--fetch next from cur into @name 
--while @@fetch_status=0 
--begin 
--    insert into #data 
--    exec sp_spaceused   @name 
--    print @name 
 
--    fetch next from cur into @name 
--end 
--close cur 
--deallocate cur 
 
--create table #DataNew(name varchar(100),row int,reserved int,data int,index_size int,unused int) 
 
--insert into #dataNew 
--select name,convert(int,row) as row,convert(int,replace(reserved,'KB','')) as reserved,convert(int,replace(data,'KB','')) as data, 
--convert(int,replace(index_size,'KB','')) as index_size,convert(int,replace(unused,'KB','')) as unused from #data  
 
--select * from #dataNew order by data desc    



--2
--SELECT   a.name, b.rows
--FROM      sysobjects AS a INNER JOIN
--                 sysindexes AS b ON a.id = b.id
--WHERE   (a.type = 'u') AND (b.indid IN (0, 1))
--ORDER BY b.rows DESC


--3
--create table tmp(
--    name varchar(50),
--    rows int,
--    reserved varchar(50),  
--    data varchar(50),
--    index_size varchar(50),
--    unused varchar(50)
--);
  
--insert into tmp (
--    name, rows, reserved, data, index_size, unused
--) exec sp_MSforeachtable @command1="sp_spaceused '?'";

--select * from tmp where name <> 'tmp' order by rows desc  ;

--drop table tmp ;



--4
--CREATE TABLE [dbo].#tableinfo(
--表名 [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--记录数 [int] NULL,
--预留空间 [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--使用空间 [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--索引占用空间 [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
--未用空间 [varchar](50) COLLATE Chinese_PRC_CI_AS NULL
--)
--insert into #tableinfo(表名, 记录数, 预留空间, 使用空间, 索引占用空间, 未用空间)
--exec sp_MSforeachtable "exec sp_spaceused '?'"
--select * from #tableinfo
--order by 记录数 desc
--drop table #tableinfo
 