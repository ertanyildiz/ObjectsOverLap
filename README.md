#  Document Management System for Friss Programming Assignment.

This Project aims to pass the programming assignment of Friss based on given requirements.
Document Management System has 3 sections. ASP.NET WEB API, MS SQL Database and Angular UI. ASP.NET Web API is divided to 2 part in its structure. API and Unit Test. Each method of API has Unit Test and all should be passed. Requirements:
1)	ASP.NET REST Web API that has endpoints for uploading/downloading documents
•	There are 3 WEB API methods for uploading/downloading and listing the file in the UI. These methods are written in the DmsApiController.cs file that is in the Contorller Folder
2)	Burası değişecek System saves file’s metadata
3)	Document storage solution, this could be the file system for now but could be changed later.
•	This requiremens is connected with Dependecy Injection criteria. (I guess) So i have coded 2 different classes that are implements an interface. With a constructor class, client only gives the necassary service (file system or database) and constructor method calls the method based on client chose. 
•	The same pattern is developed for listing files. Since files can be saved on file system or Database, Listing method have also Constructor Injection.
4)	Simple web interface to show a user’s uploaded documents, sorted by date accessed in descending order. This could be a standard ASP.NET MVC or a SinglePage Application (SPA).
•	I have developed Angular Application using Angular 8.2.0. The UI 2 navigation that are upload and download. Download page is default home. 


