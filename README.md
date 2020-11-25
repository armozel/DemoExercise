# DemoExercise
.Net Core 3.1 MVC app

## System Requirements
Visual Studio 2017/2019 (community edition should work)<br/>
Install the following: 
  * ASP.NET and web development
  * Data storage and processing
  * SQL Server Express 2016 LocalDB (Found under “Individual components” tab at the top)
.Net Core 3.1 <br/>

## Setup
Please fork this repo and clone your fork onto your pc. <br/>

You will have to mount the mdf file to MSSqlLocalDb. Easiest way to do that is through Server Explorer in VS. 
* Right Click "Data Connections"
* Click "Add Connection"
* Click Browse button and navigate to `<GitFolderLocation>\DemoExercise\DemoExercise\DemoExample.mdf`

## Requirements
This exercise is intended to mimic a real-life programming environment. As such, there are no restrictions on or penalties for web searches, consulting Stack Overflow, and so on. We do ask that you try and timebox yourself to 2-3 hours to complete the task.


This exercise asks you to frame out a simple login workflow using ASP.NET Core MVC. Very broadly, the layout should look similar to the ones 
shown in the screenshots below, but you should not attempt to mimic anything too exactly. We don’t need all the extra links and text in headers and footers. 


You will be provided with an empty ASP.NET Core project that provides structure for your code files. You will also have a settings file with a database connection string to a 
local instance of SQL Server, where you can (if you wish and have time) create a table for user login information. An ideal solution, if you have time, would involve the front-end 
design and a back end that implements the workflow and actually authenticates a user. 


You can prioritize your time how you like to show off your skills to the best advantage. We don’t expect you to finish everything, and if you have any questions feel free to reach out to Scott Johnson at sjohnson@ncco.com 


## Example pages
![Username view](/documentation/username.png)

![Password view](/documentation/password.png)

## After completeing assessment
Once complete, please push your changes to your repository then create a pull request from your master branch to `johsco:Master` branch