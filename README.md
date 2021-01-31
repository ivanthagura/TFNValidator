# TFNValidator
Web based Australian Tax File Number (TFN) validation tool developed in /Net Core and React

To run the project : 

Open project in VS Code or Visual Studio

To build and run API project:
     1. cd .\API\ 
     2. dotnet watch run
     3. make a Postman request to the tfn endpoint: http://localhost:5000/api/tfn/{tfnNumber}
            ex: http://localhost:5000/api/tfn/443459871
            
To run client app:
    1. open a new terminal
    2. cd .\client-app\
    3. npm start
    
To build client app:
    1. open a new terminal
    2. cd .\client-app\
    3. npm build - This will build the project into the wwwroot folder inside API project
    4. Publish API project and it will bundle the client app inside wwwroot folder into the project
