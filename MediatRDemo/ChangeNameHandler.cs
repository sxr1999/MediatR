namespace MediatR;

public class ChangeNameHandler : NotificationHandler<ChangeNameNotification>
{
    protected override void Handle(ChangeNameNotification notification)
    {
        Console.WriteLine($"用户名从 {notification.OldName}跟改为 {notification.NewName}");
    }
}