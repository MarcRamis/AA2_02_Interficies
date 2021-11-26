using Code;
using UnityEngine;

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
    
    public void Init()
    {
        Debug.Log("MakeInit");
        _firebaseLoginService.Init();
        _eventDispatcherService.Subscribe<LogConnectionEvent>(AlreadyConnected);
    }
    public void Login()
    {
        _firebaseLoginService.LoginApp();

        var ID = _firebaseLoginService.GetID();
        var logEvent = new LogEvent(ID);
        _eventDispatcherService.Dispatch<LogEvent>(logEvent);
        Debug.Log("Dispatch come from Login");
    }
    public void AlreadyConnected(LogConnectionEvent data)
    {
        Debug.Log("Is Connected variable: " + data.isConnected);

        if (data.isConnected)
        {
            Debug.Log("Now is connected");
            var ID = _firebaseLoginService.GetID();
            var logEvent = new LogEvent(ID);
            _eventDispatcherService.Dispatch<LogEvent>(logEvent);
            Debug.Log("Dispatch come from AlreadyConnected");
        }
    }
    public bool UserExists()
    {
        return _firebaseLoginService.IDAppExist();
    }
}
