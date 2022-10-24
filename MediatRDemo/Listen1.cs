namespace MediatR;

public class Listen1 : NotificationHandler<PostNotification>
{
    protected override void Handle(PostNotification notification)
    {
        Console.WriteLine("listem1 "+notification.Body);
    }
}