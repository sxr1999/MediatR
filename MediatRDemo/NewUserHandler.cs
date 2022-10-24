namespace MediatR;

public class NewUserHandler : NotificationHandler<NewUserNotification>
{
    protected override void Handle(NewUserNotification notification)
    {
        Console.WriteLine($"在{notification.DateTime}时，新建用户:{notification.UserName}");
    }
}