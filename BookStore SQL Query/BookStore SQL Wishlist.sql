Use BookStoreAppDB

-----------------Wishlist Table----------------------
create table Wishlist
(
	WishlistId int identity (1,1) primary key,
	UserId int not null foreign key (UserId) references Users(UserId),
	BookId int not null foreign key (BookId) references Book(BookId)
)

select * from Wishlist;

----------------Add to wishlist-----------------------
create procedure spAddWishList(
	@BookId bigint,
	@UserId int
	)
as
begin
	select * from Wishlist where BookId=@BookId and UserId=@UserId
	begin
		insert into Wishlist
		values(@UserId,@BookId);
	end
end

--------------Remove from wishlist---------------------
create procedure spDeleteWishList(
	@WishlistId int
	)
as
begin
	delete from Wishlist where WishlistId = @WishlistId;
end

------------Get All Wishlist---------------------------
create procedure spGetAllWishlistItem(
	@UserId int
	)
as
begin
	select wish.WishlistId,wish.BookId,wish.UserId,
		books.BookName,books.BookImage,books.AuthorName,books.DiscountPrice,books.OriginalPrice		
		from WishList wish inner join Book books
		on wish.BookId = books.BookId
		where wish.UserId = @UserId;
end
--------------------------------------------------------