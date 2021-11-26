using UnityEngine;
public class LoginUseCase : ILoginUseCase
{
    private readonly IFirebaseLoginService firebaseLoginService;
    private readonly IEventDispatcherService eventDispatcherService;

    public LoginUseCase(IFirebaseLoginService _firebaseLoginService, IEventDispatcherService _eventDispatcherService)
    {
        firebaseLoginService = _firebaseLoginService;
        eventDispatcherService = _eventDispatcherService;
        eventDispatcherService.Subscribe<LogConnectionEvent>(AlreadyConnected);
    }

    public void Login()
    {
        firebaseLoginService.Login();
    }

    public void AlreadyConnected(LogConnectionEvent data)
    {
        if (data.isConnected)
        {
            eventDispatcherService.Dispatch(new LogEvent(firebaseLoginService.GetID()));
        }
    }
}