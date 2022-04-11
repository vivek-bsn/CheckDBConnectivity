# CheckDBConnectivity
1.	Create the following sample table in the database
CREATE TABLE dbo.tblSample
(
Name VARCHAR(50) NOT NULL,
LastUpdatedDate DATETIME DEFAULT GETUTCDATE()
)

We will be doing insert and select on the above table
If you want to use your own table, then change the select and insert queries in #6 below. 
2.	Now, go to the WebJobs section under the App Service
 
3.	Click on ‘Add’ under WebJobs and Upload the attached file
 

 
4.	Select Triggered as Type and give the below CRON expression and click OK.
0/30 * * * * *
(This will trigger the job every 30 seconds)



 

5.	Once Webjob is added, we need to change the connection string settings for this job.
The job will be uploaded in the following path in Kudu Console- D:\home\site\wwwroot\App_Data\jobs\triggered\CheckDBConnection
 
6.	Edit the file - CheckDBConnectivity.exe.config
 
7.	Replace servername, database, userid, password in the connection string. 
8.	We can check the logs on the webjob now by going back to portal and selecting Logs
 
9.	If it is successful, we should see the Status as “Success” else we will see Failed -
 

10.	If you click on the row, you should see that the logs that data is selected, inserted if successful. Else we will see error logs/exception
 
 
11.	In the database, you should see the rows inserted every 30 seconds in the table. 
 
