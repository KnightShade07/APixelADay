**************************
 1.  GENERAL PROJECT NOTES
**************************

How to create READMEs so you don't forget:

1. (Optional) You don't have to do this, but I like to do it for organization sake, create a folder for all your ReadME's, title it something like "Project Notes".
2. Right click in the Solution Explorer, go to Add, New Item, then select "Text File", click Add.
3. Rename the ReadME to whatever is necessary for your project.

**************************
 2.  ABOUT THIS PROJECT
**************************

This project is a pixel art gallery that functions using an SQL Database and BLOB (Binary Large Object, OB = Object) Storage for image handling

**************************
 3.  CREATING AN ACCOUNT
**************************

In order to use the website, the user must create an account. A username must be chosen, and a password must be created.
The password must be at least 10 characters long.

**************************
 4.  ASP.NET CORE
**************************

ASP .NET CORE is the framework used for this project, it allows for security features to be added to a project, like roles, and blocking off certain
pages from roles that do not have permission to view those pages.

(Ex: User tries to access page where new pixel art entries are created and added to the gallery,
access is denied because they do not have the role required to perform those actions)