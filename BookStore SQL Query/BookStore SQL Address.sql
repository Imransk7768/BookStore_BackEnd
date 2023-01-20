-------------Create AddressType Table-------------
create table AddressType
(
TypeId int identity(1,1) primary key,
AddType varchar(100)
)

-----------------Adding Types--------------------

insert into AddressType values('Home');
insert into AddressType values('Work');
insert into AddressType values('Other');

---------------Select Table-------------------------
select * from AddressType;

----------------Create Address Table----------------

create table Address
(
AddressId int identity(1,1) primary key,
Address varchar(max) not null,	
City varchar(100) not null,
State varchar(100) not null,
Add Fullname varchar(100),
MobileNumber Bigint,
TypeId int not null foreign key (TypeId) references AddressType(TypeId),
UserId int not null foreign key (UserId) references Users(UserId)
)

select * from Address;
select * from AddressType;

-------------Add Address SP-------------------------------------

create or alter procedure spAddAddress(
	@Address varchar(max),
	@City varchar(100),
	@State varchar(100),
	@TypeId int,
	@UserId int,
	@Fullname varchar(100),
	@MobileNumber BigInt
	)
as
begin
	insert into Address
	values(@Address,@City,@State,@TypeId,@UserId,@Fullname,@MobileNumber);
end

-------------------- Sp for Update Address---------------------------
create or alter procedure spUpdateAddress(
	@AddressId int,
	@Address varchar(max),
	@Fullname varchar(100),
	@MobileNumber INT,
	@City varchar(100),
	@State varchar(100),
	@TypeId int,
	@UserId int
	)
as
begin
	update Address set
	Address=@Address,Fullname=@Fullname,MobileNumber=@MobileNumber,City=@City,State=@State,TypeId=@TypeId where UserId=@UserId and AddressId=@AddressId;
end

----------------Sp for Delete Address----------------------------

create procedure spDeleteAddress
@AddressId int
as
begin
	delete from Address where AddressId = @AddressId;
end
------------------------------------------------------------------