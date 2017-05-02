-- sql agent must be running
-- Change Data Capture is Enterprise Edition

--1. enable CDC
declare @rc int
exec @rc = sys.sp_cdc_enable_db
select @rc --return 0 if successful and 1 if it fails
-- new column added to sys.databases: is_cdc_enabled
select name, is_cdc_enabled from sys.databases

--2. create CDC on customer table.
create table dbo.customer
(
id int identity not null
, name varchar(50) not null
, state varchar(2) not null
, constraint pk_customer primary key clustered (id)
)

exec sys.sp_cdc_enable_table 
    @source_schema = 'dbo', 
    @source_name = 'customer' ,
    @role_name = 'public',
    @supports_net_changes = 1
--@source_schema is the schema name of the table that you want to enable for CDC 
--@source_name is the table name that you want to enable for CDC 
--@role_name is a database role which will be used to determine whether a user can access the CDC data; the role will be created if it doesnt exist.  You can add users to this role as required; you only need to add users that arent already members of the db_owner fixed database role. 
--@supports_net_changes determines whether you can summarize multiple changes into a single change record; set to 1 to allow, 0 otherwise. 
--@capture_instance is a name that you assign to this particular CDC instance; you can have up two instances for a given table. 
--@index_name is the name of a unique index to use to identify rows in the source table; you can specify NULL if the source table has a primary key. 
--@captured_column_list is a comma-separated list of column names that you want to enable for CDC; you can specify NULL to enable all columns. 
--@filegroup_name allows you to specify the FILEGROUP to be used to store the CDC change tables. 
--@partition_switch allows you to specify whether the ALTER TABLE SWITCH PARTITION command is allowed; i.e. allowing you to enable partitioning (TRUE or FALSE).

select name, type, type_desc, is_tracked_by_cdc from sys.tables

select o.name, o.type, o.type_desc from sys.objects o
join sys.schemas  s on s.schema_id = o.schema_id
where s.name = 'cdc'

--disable CDC on a particular table 
--exec sys.sp_cdc_disable_table 
--  @source_schema = 'dbo', 
--  @source_name = 'customer',
--  @capture_instance = 'dbo_customer' -- or 'all'


--disable CDC on database level
declare @rc int
exec @rc = sys.sp_cdc_disable_db
select @rc
-- show databases and their CDC setting
select name, is_cdc_enabled from sys.databases

--3. create sample data
insert customer values ('abc company', 'md')
insert customer values ('xyz company', 'de')
insert customer values ('xox company', 'va')
update customer set state = 'pa' where id = 1
delete from customer where id = 3


--4.show records of the above changes
declare @begin_lsn binary(10), @end_lsn binary(10)
-- get the first LSN for customer changes
select @begin_lsn = sys.fn_cdc_get_min_lsn('dbo_customer')
-- get the last LSN for customer changes
select @end_lsn = sys.fn_cdc_get_max_lsn()
-- get net changes; group changes in the range by the pk
select * from cdc.fn_cdc_get_net_changes_dbo_customer(@begin_lsn, @end_lsn, 'all'); 
-- get individual changes in the range
select * from cdc.fn_cdc_get_all_changes_dbo_customer( @begin_lsn, @end_lsn, 'all');
--$operation column values are: 1 = delete, 2 = insert,  3 = update (values before update), 4 = update (values after update).

--extend this example to handle periodically extracting changed rows
create table dbo.customer_lsn (
last_lsn binary(10)
)

create function dbo.get_last_customer_lsn() 
returns binary(10)
as
begin
 declare @last_lsn binary(10)
 select @last_lsn = last_lsn from dbo.customer_lsn
 select @last_lsn = isnull(@last_lsn, sys.fn_cdc_get_min_lsn('dbo_customer'))
 return @last_lsn
end

declare @begin_lsn binary(10), @end_lsn binary(10)
-- get the next LSN for customer changes
select @begin_lsn = dbo.get_last_customer_lsn()
-- get the last LSN for customer changes
select @end_lsn = sys.fn_cdc_get_max_lsn()
-- get the net changes; group all changes in the range by the pk
select * from cdc.fn_cdc_get_net_changes_dbo_customer(
 @begin_lsn, @end_lsn, 'all'); 
-- get all individual changes in the range
select * from cdc.fn_cdc_get_all_changes_dbo_customer(
 @begin_lsn, @end_lsn, 'all'); 
-- save the end_lsn in the customer_lsn table
update dbo.customer_lsn
set last_lsn = @end_lsn
if @@ROWCOUNT = 0
insert into dbo.customer_lsn values(@end_lsn)