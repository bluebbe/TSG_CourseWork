USE master;
GO

if exists (select * from sysdatabases where name='HotelReservationSystem2')
begin
 DECLARE @kill varchar(8000) = ''; 
 SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' 
 FROM sys.dm_exec_sessions
 WHERE database_id = db_id('HotelReservationSystem2')
 EXEC(@kill)
 
 DROP DATABASE HotelReservationSystem2
end
GO