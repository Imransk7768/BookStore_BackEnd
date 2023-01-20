-----------------Create Cart Table--------------------------------
create table Cart
(
	CartId int identity(1,1) primary key ,
	BookQuantity int default 1,
	UserId int foreign key (UserId) references Users(UserId),
	BookId int foreign key (BookId) references Book(BookId)
)

select * from Cart

---------------- Sp Adding Cart---------------------------------
create or alter procedure spAddCart(
	@BookId int,
	@BookQuantity int,
	@UserId int
	)
as
begin
	select * from Cart where BookId=@BookId and UserId=@UserId
	begin
		insert into Cart(BookId,UserId)
		values(@BookId,@UserId);
	end
end

-------------------Update Cart------------------------------------

create procedure spUpdateCart(
	@CartId int,
	@BookQuantity int
	)
as
begin
	update Cart set BookQuantity=@BookQuantity where CartId=@CartId;
end

--------------------Delete from cart--------------------------------

create procedure spDeleteCart(
	@CartId int
	)
as
begin
	delete from Cart where CartId=@CartId;
end

---------------Retrieve All Carts---------------------------
create procedure spGetAllCart(
	@UserId int
	)
as
begin
	select cart.CartId,cart.BookId,cart.BookQuantity,cart.UserId,
		books.BookName,books.BookImage,books.AuthorName,books.DiscountPrice,books.OriginalPrice from Cart cart inner join Book books 
		on books.BookId=cart.BookId where cart.UserId = @UserId;
end
------------------------------------------------------------------