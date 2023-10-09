This file contains information about using the Forum Application.

It took 10 hours to come up with this solution. Having more time few thing could be added like editing and removing comment. More work on the frontend was possible. XML comments could be added to the backend. Like Post/Comments etc could be added.

Mainly you need VS Code to run the application but can use VS for the documentation(Swagger)

Install 
VS Code (code.visualstudio.com)
.NET 6 SDK (dot.net)
Node latest LTS (nodejs.org)

Open visual studio code and click clone repository. Paste the following link and chose destination folder. Click on "Yes, I trust the authors" and agree to other prompts you get.

https://github.com/MadihaGul/ForumApplication

Once the project is opened in VS Code, go to Terminal and choose New Terminal. Type following commands to get started.

1.	Type and press enter : dotnet dev-certs https --trust
2.	Type and press enter : dotnet tool install --global dotnet-ef (If not installed already)
3.	Type and press enter : cd ForumApplication
4.	Now type and press enter : dotnet ef database update
5.	dotnet run
6.	Now click "+" sign located on top of terminal window
7.	Type : cd .\ReactWeb\
8.	Then write : npm install
9.	Lastly type: npm start
10.	Finally Application will open in a browser! Here you can view, add, edit, delete Posts and comment.