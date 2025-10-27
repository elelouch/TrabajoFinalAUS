Invoke-WebRequest `
	-Uri https://localhost:7254/tasks
	-Method Post `
	-ContentType "json" 
	-Body '{"name": "test", "description":"testing post"}'