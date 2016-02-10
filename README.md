# ConsoleAppCallWebService
Console Application Call Rest Web Service


  
    DECLARE @Command VARCHAR(8000)
    DECLARE @RetInfo VARCHAR(8000)
    SELECT @Command ='Caller.exe  http://localhost/webservice.aspx arg1=9  arg1=name'
    EXEC @RetInfo=MASTER.dbo.xp_cmdshell @Command
    PRINT @RetInfo
