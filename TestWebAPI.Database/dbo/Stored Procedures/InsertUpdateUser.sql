CREATE proc [InsertUpdateUser]
@UserId int=0,
@Name nvarchar(100),
@Email nvarchar(100),
@City nvarchar(100),
@Mobile nvarchar(20),
@IsUpdate bit			
As
Begin
Declare @Status int,@Msg nvarchar(100)
	if(@IsUpdate=1)
	Begin
		Update [dbo].[User]
		Set Name=@Name,
		Email=@Email,
		City=@City,
		Mobile=@Mobile
		where UserId=@UserId
		set @Status=2
		set @Msg='User updated successfully'
	END
	Else
	Begin
		Insert into [dbo].[User](Name,Email,City,Mobile,IsDelete)
		Values(@Name,@Email,@City,@Mobile,0)
		set @Status=2
		set @Msg='User Inserted successfully'
	End

	select @Status Status,@Msg Message
ENd