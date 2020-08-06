--insert user
insert into dbo.Users (Email,Password,Fullname,Mobileno)
values ('Jason@gmail.com', 'test123', 'Jason Williams', '3234886807')
, ('James@gmail.com', 'test123', 'James Harden', '3234886803')
, ('Bruce@gmail.com', 'test123', 'Bruce Lee', '3234886805')
--insert tasks
insert into dbo.Tasks (userId, Title,Description, DueDate,Priority,Remarks)
values('2','Task1','Test','8/6/2020','5','testRemarks')
,('2','Task2','Test','8/6/2020','3','testRemarks')
,('3','Task4','Test','8/20/2020','1','testRemarks')
,('4','Task5','Test','10/6/2020','4','testRemarks')
,('4','Task6','Test','8/11/2020','3','testRemarks')