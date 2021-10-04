Create Proc [dbo].[GetUserById]
@UserId int
As
Begin
select UserId,Name,Email,City,Mobile from [dbo].[User] where IsDelete!=1 and UserId=@UserId

End