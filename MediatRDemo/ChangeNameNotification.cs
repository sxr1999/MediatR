namespace MediatR;

public record ChangeNameNotification(string OldName,string NewName) : INotification;