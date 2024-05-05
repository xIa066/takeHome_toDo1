## How to Run

1. Open .sln from visual studio, start the backend, remember to port number it's running.
2. Open Client folder using visual studio code, cd into takeHomeToDoClient\todo-app\src\app\app.component.ts, change the 'BASE_API_URL' into the port number that the backend is running
3. ng serve, start the client
4.  Remember the port number that the Client is running, change this line in your Program.cs     

app.UseCors(options =>
    {
        options.WithOrigins("http://localhost:<YOUR CLIENT PORT>")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

5. Restart the backend
6. Refresh the frontEnd, now frontend and backend is connected for local development
