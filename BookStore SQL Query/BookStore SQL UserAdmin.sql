create database BookStoreAppDB
use BookStoreAppDB

----------------------------------USER TABLE-----------------------
create table Users 
(
	UserId int identity (1,1) primary key,
	FullName varchar(100) not null,
	EmailId varchar(100) not null,
	Password varchar(100) not null,
	MobileNumber varchar(100) not null
);
select * from Users

-----------------Stored Procedures --------------------------------

-----------------Register------------------------------------------
create procedure spRegister(
	@FullName varchar(100),
	@EmailId varchar(100),
	@Password varchar(100),
	@MobileNumber varchar(100)
	)
as
begin
		insert into Users
		values(@FullName,@EmailId,@Password,@MobileNumber);
end

----------------Login------------------------------------------------
create procedure spLogin
	(
	@EmailId varchar(100),
	@Password varchar(100)
	)
as
begin
	select * from Users where EmailId=@EmailId and Password=@Password;
end

----------------Forget Password--------------------------------------
create or alter procedure spForgetPassword
@EmailId varchar(50)
as
begin
	select * from Users where EmailId=@EmailId
end

---------------Reset Password----------------------------------------
create or alter procedure spResetPassword
@EmailId varchar(50),
@Password varchar(100)
as
begin
	update Users set Password=@Password where  EmailId=@EmailId
END

--------------Get all User Detail------------------------------------
create or alter procedure spGetUser
	@UserId INT
as 
begin
	select UserId,FullName,MobileNumber from Users where UserId = @UserId;
end

--------------spGetUser-----------------------------------------------
----------------------------------------------------------------------

---------------------Admin table--------------------------------------
create table Admin(
	AdminId int identity (1,1) primary key,
	FullName varchar(100) not null,
	EmailId varchar(100) not null,
	Password varchar(100) not null,
	MobileNumber bigint not null
);

select * from Admin

-----------------Inserting Admin Data---------------------------------

insert into Admin 
values('Admin','admin@gmail.com','Admin@123',90123456789);

------------------Admin Login------------------------------------------

create procedure spAdminLogin(
	@EmailId varchar(100),
	@Password varchar(100)
	)
as
begin
	select * from Admin where EmailId=@EmailId and Password = @Password;
end
-------------------------------------------------------------------------