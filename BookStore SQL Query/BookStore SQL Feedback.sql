
-----------------Create Feedback Table-----------------------------
create table Feedback(
	FeedbackId int identity (1,1) primary key,
	Rating float not null,
	Comment varchar(max) not null,
	BookId int not null foreign key (BookId) references Book(BookId),
	UserId int not null foreign key (UserId) references Users(UserId)
	)

select * from Feedback

----------------------Stored procedure Add Feedback-----------------------
create or alter procedure spAddFeedback(
	@Rating float,
	@Comment varchar(max),
	@BookId int,
	@UserId int
	)
as
	declare @TotalRating float;
begin
	
		insert into Feedback values(@Rating,@Comment,@BookId,@UserId);
end

-----------------------Get Feedback Stored procedure ------------------
create procedure spGetFeedback(
	@BookId int
	)
as
begin
	select Feedback.FeedbackId,Feedback.Comment,Feedback.BookId,Feedback.Rating,Feedback.UserId,Users.FullName
	from Users
	inner join Feedback
	on Feedback.UserId = Users.UserId where BookId=@BookId;
end

---------------------------------------------------------------------------------------