# CheckDBConnectivity
1.	Create the following sample table in the database

      CREATE TABLE dbo.tblSample
      (
      Name VARCHAR(50) NOT NULL,
      LastUpdatedDate DATETIME DEFAULT GETUTCDATE()
      )

      We will be doing insert and select on the above table. If you want to use your own table, then change the select and insert queries in #7 below. 
2.	Now, go to the WebJobs section under the App Service

 <img width="574" alt="image" src="https://user-images.githubusercontent.com/79462763/162824342-5904369a-9e4a-4ce0-bf67-ad723cc5bdf8.png">

3.	Click on ‘Add’ under WebJobs and Upload the contents of Release folder after rebuilding the project and zipping them

 <img width="636" alt="image" src="https://user-images.githubusercontent.com/79462763/162824528-1d9ef67e-d244-4bff-9b99-2afaa56ba4bf.png">


 
4.	Select Triggered as Type and give the below CRON expression and click OK.
0/30 * * * * *
(This will trigger the job every 30 seconds)

<img width="308" alt="image" src="https://user-images.githubusercontent.com/79462763/162824564-66d86c52-294f-487a-8137-033c054588c1.png">


5.	Once Webjob is added, we need to change the connection string settings for this job.
The job will be uploaded in the following path in Kudu Console- D:\home\site\wwwroot\App_Data\jobs\triggered\CheckDBConnection
 <img width="679" alt="image" src="https://user-images.githubusercontent.com/79462763/162824609-38e9302a-b558-4bd8-9628-083da702c914.png">

6.	Edit the file - CheckDBConnectivity.exe.config
 <img width="736" alt="image" src="https://user-images.githubusercontent.com/79462763/162824647-97ec9fce-5f0f-4242-958a-c8e8ef5d04d1.png">

7.	Replace servername, database, userid, password in the connection string. 
8.	We can check the logs on the webjob now by going back to portal and selecting Logs
 <img width="764" alt="image" src="https://user-images.githubusercontent.com/79462763/162824674-b9abb6dc-00c9-4087-b6bd-e7648c228904.png">

9.	If it is successful, we should see the Status as “Success” else we will see Failed -
 <img width="658" alt="image" src="https://user-images.githubusercontent.com/79462763/162824683-851f4c91-2487-4a90-8be3-9aedbdd534a0.png">


10.	If you click on the row, you should see that the logs that data is selected, inserted if successful. Else we will see error logs/exception
 
 <img width="720" alt="image" src="https://user-images.githubusercontent.com/79462763/162824717-37cab2cc-dd64-4e01-8b13-71eac6f8e9f8.png">
<img width="650" alt="image" src="https://user-images.githubusercontent.com/79462763/162824732-4f6b5644-f2a4-433c-8210-338d10f5e03a.png">

11.	In the database, you should see the rows inserted every 30 seconds in the table. 
 <img width="516" alt="image" src="https://user-images.githubusercontent.com/79462763/162824777-d46cfaf3-bb7b-4ce6-8040-87630d12f5b0.png">

