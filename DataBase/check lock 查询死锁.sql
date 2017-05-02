-------------------------------------------------------11111--------------------------------------------------
--�������
--������������ˣ�������ôȥ�����巢��������������SQL����洢���̣�
--��ʱ���ǿ���ʹ�����´洢��������⣬�Ϳ��Բ�����������Ľ��̺�SQL��䡣SQL Server�Դ���ϵͳ�洢����sp_who��sp_lockҲ����������������������, ��û��������ܵķ������á�
use master
go
create procedure sp_who_lock
as
begin
declare @spid int,@bl int,
 @intTransactionCountOnEntry int,
  @intRowcount int,
  @intCountProperties int,
  @intCounter int
 create table #tmp_lock_who (
 id int identity(1,1),
 spid smallint,
 bl smallint)
 IF @@ERROR<>0 RETURN @@ERROR
 insert into #tmp_lock_who(spid,bl) select 0 ,blocked
 from (select * from sysprocesses where blocked>0 ) a 
 where not exists(select * from (select * from sysprocesses where blocked>0 ) b 
 where a.blocked=spid)
 union select spid,blocked from sysprocesses where blocked>0
 IF @@ERROR<>0 RETURN @@ERROR 
-- �ҵ���ʱ��ļ�¼��
 select @intCountProperties = Count(*),@intCounter = 1
 from #tmp_lock_who
 IF @@ERROR<>0 RETURN @@ERROR 
 if @intCountProperties=0
 select '����û��������������Ϣ' as message
-- ѭ����ʼ
while @intCounter <= @intCountProperties
begin
-- ȡ��һ����¼
 select @spid = spid,@bl = bl
 from #tmp_lock_who where Id = @intCounter 
 begin
 if @spid =0 
   select '�������ݿ���������: '+ CAST(@bl AS VARCHAR(10)) + '���̺�,��ִ�е�SQL�﷨����'
 else
   select '���̺�SPID��'+ CAST(@spid AS VARCHAR(10))+ '��' + '���̺�SPID��'+ CAST(@bl AS VARCHAR(10)) +'����,�䵱ǰ����ִ�е�SQL�﷨����'
 DBCC INPUTBUFFER (@bl )
 end
-- ѭ��ָ������
 set @intCounter = @intCounter + 1
end
drop table #tmp_lock_who
return 0
end
go



-------------------------------------------------------2222222--------------------------------------------------
--ɱ�����ͽ���
--���ȥ�ֶ���ɱ�����̺�������򵥵İ취�������������񡣵�������Ҫ����һ���洢���̣�ͨ����ʽ�ĵ��ã�����ɱ�����̺�����
use master
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[p_killspid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[p_killspid]
GO
create proc p_killspid
@dbname varchar(200) --Ҫ�رս��̵����ݿ���
as
 declare @sql nvarchar(500) 
 declare @spid nvarchar(20)
 declare #tb cursor for
  select spid=cast(spid as varchar(20)) from master..sysprocesses where dbid=db_id(@dbname)
 open #tb
 fetch next from #tb into @spid
 while @@fetch_status=0
 begin
  exec('kill '+@spid)
  fetch next from #tb into @spid
 end
 close #tb
 deallocate #tb
go
--�÷� 
--exec p_killspid 'newdbpy'


-------------------------------------------------------3333333--------------------------------------------------
--�鿴����Ϣ
--��β鿴ϵͳ������������ϸ��Ϣ������ҵ����������У����ǿ��Կ���һЩ���̺�������Ϣ�������������һ�ַ�����
--�鿴����Ϣ
create table #t(req_spid int,obj_name sysname)
declare @s nvarchar(4000)
 ,@rid int,@dbname sysname,@id int,@objname sysname
declare tb cursor for
 select distinct req_spid,dbname=db_name(rsc_dbid),rsc_objid
 from master..syslockinfo where rsc_type in(4,5)
open tb
fetch next from tb into @rid,@dbname,@id
while @@fetch_status=0
begin
 set @s='select @objname=name from ['+@dbname+']..sysobjects where id=@id'
 exec sp_executesql @s,N'@objname sysname out,@id int',@objname out,@id
 insert into #t values(@rid,@objname)
 fetch next from tb into @rid,@dbname,@id
end
close tb
deallocate tb
select ����id=a.req_spid
 ,���ݿ�=db_name(rsc_dbid)
 ,����=case rsc_type when 1 then 'NULL ��Դ��δʹ�ã�'
  when 2 then '���ݿ�'
  when 3 then '�ļ�'
  when 4 then '����'
  when 5 then '��'
  when 6 then 'ҳ'
  when 7 then '��'
  when 8 then '��չ����'
  when 9 then 'RID���� ID)'
  when 10 then 'Ӧ�ó���'
 end
 ,����id=rsc_objid
 ,������=b.obj_name
 ,rsc_indid
 from master..syslockinfo a left join #t b on a.req_spid=b.req_spid
go
drop table #t

--select
--request_session_id spid, 
--OBJECT_NAME(resource_associated_entity_id) tableName 
--from
--sys.dm_tran_locks 
--where
--resource_type='OBJECT'


--exec sp_who_lock

--kill 52