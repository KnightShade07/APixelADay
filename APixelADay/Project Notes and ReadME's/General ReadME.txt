**************************
 1.  GENERAL PROJECT NOTES
**************************

How to create READMEs so you don't forget:

1. (Optional) You don't have to do this, but I like to do it for organization sake, create a folder for all your ReadME's, title it something like "Project Notes".
2. Right click in the Solution Explorer, go to Add, New Item, then select "Text File", click Add.
3. Rename the ReadME to whatever is necessary for your project.

How to display images in your website:
1. (Optional) Create an "images" folder.
2. Path to the image on the page you want it displayed on.
Ex: (<img src ="~/images/APixelADay Logo Transparent.png" />)

**************************
 2.  ABOUT THIS PROJECT
**************************

This project is a pixel art gallery that functions using an SQL Database and BLOB (Binary Large Object, OB = Object) Storage for image handling

**************************
 3.  CREATING AN ACCOUNT
**************************

In order to use the website, the user/administrator must create an account. A username must be chosen, and a password must be created.
The password must be at least 10 characters long.

**************************
 4.  ASP.NET CORE
**************************

ASP .NET CORE is the framework used for this project, it allows for security features to be added to a project, like roles, and blocking off certain
pages from roles that do not have permission to view those pages.

(Ex: User tries to access page where new pixel art entries are created and added to the gallery,
access is denied because they do not have the role required to perform those actions)

**************************
 5. CREATING AUTO GENERATED CRUD PAGES ("Views")
**************************

CRUD stands for "Create,Edit/Update, Delete", and it's how you design website pages to add data functionality.

In order to add CRUD Pages, you will need to:

1. Go to your folder where you want to create the pages, typically people put it in Views.
2. Right Click on the folder, select "Add".
3. Select "View", and click "Add".
4. Depending on your situation and context, you will either want an Empty Razor Page or a regular Razor Page.
5. Select your Template Type from the dropdown list.
6. Select the class your CRUD Page/View will be working with.
7. You may or may not need a Data Context Class, depending on the situation. If you don't, then skip this step.
8. DO NOT FORGET to give your View a name!!!! You can rename it with a right click, but its better to get it right the first time!
9. Click Add, and then you've just created a CRUD Page!