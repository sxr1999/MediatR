namespace MediatR;

public class Listen2 : NotificationHandler<PostNotification>
{
    protected override void Handle(PostNotification notification)
    {
        Console.WriteLine("listen2:"+notification.Body);
    }
}