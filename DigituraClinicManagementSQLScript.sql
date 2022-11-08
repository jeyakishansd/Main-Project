create database DigituraClinic
use DigituraClinic
go
create table Users(
UserName varchar(20),
FirstName varchar(20),
LastName varchar(20),
Password varchar(20),
constraint PK_UserName primary key (UserName)
)
insert into Users values('jeykee','Jeya','Kishan','jeykee');
select *from Users

create table DoctorList(
DoctorID int identity(201,1)primary key,
FirstName varchar(20),
LastName varchar(20),
Sex varchar(20),
Specialization varchar(30),
VisitingHours Varchar(30)
)
select * from DoctorList
drop table DoctorList
create table PatientList(
PatientID int identity(701,1)primary key,
FirstName varchar(20),
LastName varchar(20),
Sex varchar(20),
Age int,
DateOfBirth date,
)
select*from PatientList

create table ScheduleAppointment(
AppointmentNumber int identity (501,1) primary key,
PatientID  int,
Specialization varchar(30),
DoctorID int ,
AppointmentDate date,
AppointmentTime varchar(40),
)
select*from ScheduleAppointment

