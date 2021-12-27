 <# Set-ExecutionPolicy -ExecutionPolicy AllSigned -Scope Process #>

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/tickets' -Method Get
$Response   

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/tickets/12345' -Method Get
$Response

$Body = @{
            ProjectId = 1
            Title = "This is my first bug"
            Description = "This is very strange!"
         }

$jsonbody = ConvertTo-Json -InputObject $Body 


$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/tickets' -Method Post -ContentType 'application/json' -Body $jsonbody
$Response


$PutBody = @{
            TicketId = 1
            ProjectId = 1
            Title = "This is my first bug"
            Description = "This is very strange!"
         }

$jsonPutbody = ConvertTo-Json -InputObject $PutBody 

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/tickets' -Method Put -ContentType 'application/json' -Body $jsonPutbody
$Response

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/tickets/12345' -Method Delete
$Response

#######################################################################################################

$Response = "Project Apis"


$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/Projects' -Method Get
$Response   

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/Projects/12345' -Method Get
$Response

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/Projects' -Method Post
$Response

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/Projects' -Method Put
$Response

$Response = Invoke-RestMethod -Uri 'https://localhost:44361/api/Projects/12345' -Method Delete
$Response

