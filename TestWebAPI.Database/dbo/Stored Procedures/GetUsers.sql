CREATE Proc [dbo].[GetUsers]
As
Begin
select UserId,Name,Email,City,Mobile from [dbo].[User] where IsDelete!=1

End