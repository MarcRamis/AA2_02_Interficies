using Code;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IFirebaseLoginService _firebaseLoginService;
    private readonly IEventDispatcherService _eventDispatcherService;

    public DoLoginUseCase(IFirebaseLoginService firebaseLoginService,
        IEventDispatcherService eventDispatcherService)
    {
        _firebaseLoginService = firebaseLoginService;
        _eventDispatcherService = eventDispatcherService;
    }

    public void Login()
    {
        var ID = _firebaseLoginService.GetID();
        
        var logEvent = new LogEvent(ID);
        _eventDispatcherService.Dispatch<LogEvent>(logEvent);
    }
    public bool UserExists()
    {
        return _firebaseLoginService.IDAppExist();
    }
}
