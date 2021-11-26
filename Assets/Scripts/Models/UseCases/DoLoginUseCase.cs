using Code;
using UnityEngine;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IFirebaseLoginService firebaseLoginService;
    private readonly IEventDispatcherService _eventDispatcherService;

    public DoLoginUseCase(IFirebaseLoginService _firebaseLoginService,
        IEventDispatcherService eventDispatcherService)
    {
        firebaseLoginService = _firebaseLoginService;
        _eventDispatcherService = eventDispatcherService;
        _eventDispatcherService.Subscribe<LogConnectionEvent>(AlreadyConnected);
    }
    public void Login()
    {
        firebaseLoginService.LoginApp();

        _eventDispatcherService.Dispatch<LogEvent>(new LogEvent(firebaseLoginService.GetID()));
    }
    public void AlreadyConnected(LogConnectionEvent data)
    {
        if (data.isConnected)
        {
            _eventDispatcherService.Dispatch<LogEvent>(new LogEvent(firebaseLoginService.GetID()));
        }
    }
}
