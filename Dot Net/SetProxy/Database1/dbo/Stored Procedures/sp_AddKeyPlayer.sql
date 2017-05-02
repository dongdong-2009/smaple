
CREATE PROCEDURE [dbo].[sp_AddKeyPlayer] 
	@lid int,
	@team varchar(20),
	@playername varchar(20),	
	@ability varchar(100)
AS
BEGIN
declare @count int
	select @count = count(1) from TeamPlayerData where lid = @lid and PlayerName = @playername and team = @team
	if @count = 0
	begin
		INSERT INTO [TeamPlayerData]
           ([lid]
           ,[Team]
           ,[PlayerName]
           ,[Ability])
     VALUES
           (@lid
           ,@team
           ,@playername
           ,@ability)
	end
	else
	begin
		update [TeamPlayerData] set Ability = Ability + ','+@ability  where lid = @lid and PlayerName = @playername and team = @team
	end

END
