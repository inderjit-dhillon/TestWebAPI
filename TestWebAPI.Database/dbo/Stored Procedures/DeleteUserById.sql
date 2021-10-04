Create Proc [dbo].[DeleteUserById]
@UserId int
As
Begin
	update [dbo].[User] set IsDelete=1 where UserId=@UserId

End