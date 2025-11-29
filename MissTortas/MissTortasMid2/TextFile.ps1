#Write-Output params(0)
#params(post

$postObject = @{
	name = "test"
	description = "testing post"
} | ConvertTo-Json -Depth 1


# Invoke-WebRequest  -Uri https://localhost:7254/tasks/ -Method Post   -ContentType "application/json"  -Body '{"name": "test", "description":"testing post"}'
# Write-Host $postObject["name"]
$test=(Invoke-RestMethod -Method Post -Body $postObject -Uri https://localhost:7254/tasks/ -ContentType "application/json")

Write-Host $test


# Invoke-WebRequest  -Uri https://localhost:7254/tasks/1 -Method Get