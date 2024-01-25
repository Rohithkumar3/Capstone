create table AdminInfo
(AdminId int primary key,
EmailId nvarchar(50) not null,
Password nvarchar(50) not null)
insert into AdminInfo values (1,'admin@gmail.com','admin321')
insert into AdminInfo values (2,'admin@example.com','Admin@321')
insert into AdminInfo values (3,'user@example.com','user321')

create table EmpInfo
(EmpInfoId int primary key,
EmailId nvarchar(50) not null,
Name nvarchar(50) not null,
DateofJoining dateTime ,
Passcode int )
insert into EmpInfo values (1,'Rohithkumar@gmail.com','Rohith','06-05-2022',2)
insert into EmpInfo values (2,'Shyam@gmail.com','Shyam','09-01-2023',3)

create table BlogInfo
(BlogInfoId int primary key,
Title nvarchar(50) not null,
Subject nvarchar(50) not null,
DateofCreation dateTime,
BlogUrl nvarchar(50) not null,
EmpEmailId nvarchar(50) not null)
insert into BlogInfo values (1,'Html basics','HTML','12-12-2020','https://www.w3schools.com/html/html_basic.asp','Rohithkumar@gmail.com')