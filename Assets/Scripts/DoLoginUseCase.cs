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

    public void Login(string textID)
    {
        //var ID = _firebaseLoginService.GetID();

        var logEvent = new LogEvent(textID);
        _eventDispatcherService.Dispatch<LogEvent>(logEvent);
    }
}
