use BookStoreAppDB

--------------------Book Table----------------------
Create Table Book
(
	BookId int identity(1,1) primary key,
	BookName varchar(100) not null,
	AuthorName varchar(100) not null,
	Rating float,
	ReviewerCount int,
	DiscountPrice int not null,
	OriginalPrice int not null,
	BookDetail varchar(max) not null,
	BookImage varchar(max) not null,
	BookQuantity int not null 
)
select * from Book;
-----------------------Stored Procedures------------

-----------------------Adding Book------------------
create procedure spAddBook(
	@BookName varchar(100),
	@AuthorName varchar(100),
	@Rating float,
	@ReviewerCount int,
	@DiscountPrice int,
	@OriginalPrice int,
	@BookDetail varchar(max),
	@BookImage varchar(max),
	@BookQuantity int
	)
as
begin
	insert into Book
	values(@BookName,@AuthorName,@Rating,@ReviewerCount,@DiscountPrice,@OriginalPrice,@BookDetail,@BookImage,@BookQuantity);
end

--------------------Update Book--------------------

create procedure spUpdateBook(
	@BookId int,
	@BookName varchar(100),
	@AuthorName varchar(100),
	@Rating float,
	@ReviewerCount int,
	@DiscountPrice int,
	@OriginalPrice int,
	@BookDetail varchar(max),
	@BookImage varchar(max),
	@BookQuantity int
	)
as 
begin
	update Book set 
	BookName= @BookName,
	AuthorName= @AuthorName,
	Rating = @Rating,
	ReviewerCount= @ReviewerCount,
	DiscountPrice = @DiscountPrice,
	OriginalPrice = @OriginalPrice,
	BookDetail= @BookDetail,
	BookImage = @BookImage,
	BookQuantity = @BookQuantity
	where BookId = @BookId;
end

-------------------Delete Book----------------------

create procedure spDeleteBook(
	@BookId int
	)
as
begin
	delete from Book where BookId=@BookId;
end

--------------------Get All Books-------------------
create procedure spGetAllBooks
as
begin
	select * from Book;
end

------------------Get Book By BookId-----------------

create procedure spGetBookByBookId(
	@BookId int
	)
as
begin
	select * from Book where BookId=@BookId;
end
------------------------------------------------------