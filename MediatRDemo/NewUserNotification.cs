namespace MediatR;

public record NewUserNotification(string UserName,DateTime DateTime): INotification
{
    
}