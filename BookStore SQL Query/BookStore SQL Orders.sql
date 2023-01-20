---------------Create Order Table----------------------------------
create table Orders(
	OrderId int identity(1,1) primary key,
	OrderQty int not null,
	TotalPrice float not null,
	OrderDate Date not null,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Book(BookId),
	AddressId int not null FOREIGN KEY REFERENCES Address(AddressId)
	)

select * from Orders
-----------------Sp For Add Orders----------------------------------

create or alter procedure AddOrders(
	@UserId int,
	@BookId int,
	@AddressId int
	)
as
	declare @TotalPrice int;
	declare @OrderQty int;
begin
		set @TotalPrice = (select DiscountPrice from Book where BookId = @BookId);
		set @OrderQty = (select BookQuantity from Cart where BookId = @BookId); 

		set @TotalPrice = @OrderQty*@TotalPrice;
		
		insert into Orders values(@OrderQty,@TotalPrice,GETDATE(),@UserId,@BookId,@AddressId);
		update Book set BookQuantity = (BookQuantity - @OrderQty) where BookId = @BookId;
		delete from Cart where BookId = @BookId and UserId = @UserId; 
end
	


--	create or alter procedure AddOrders(
--	@UserId int,
--	@BookId int,
--	@AddressId int
--	)
--as
--	declare @TotalPrice int;
--	declare @OrderQty int;
--begin
--		set @TotalPrice = (select DiscountPrice from Book where BookId = @BookId);
--		set @OrderQty = (select BookQuantity from Cart where BookId = @BookId); 

--		set @TotalPrice = @OrderQty*@TotalPrice;
		
--		insert into Orders values(@OrderQty,@TotalPrice,GETDATE(),@UserId,@BookId,@AddressId);
--		update Book set BookQuantity = (BookQuantity - @OrderQty) where BookId = @BookId;
--		delete from Cart where BookId = @BookId and UserId = @UserId; 
--end
	

--------------SP for Get All Orders------------------------------------
create procedure spGetAllOrders
(
@UserId int
)
as
begin
	select 
		Orders.OrderId, Orders.UserId, Orders.AddressId, Book.BookId,
		Orders.TotalPrice, Orders.OrderQty, Orders.OrderDate,
		Book.BookName, Book.AuthorName, Book.BookImage
		from Book 
		inner join Orders on Orders.BookId = Book.BookId 
		where Orders.UserId = @UserId; 
end

----------------- Sp for Delete Order------------------------------
create procedure spDeleteOrder(@OrderId int)
as
begin
	delete from Orders where OrderId=@OrderId;
end
----------------------------------------------------------