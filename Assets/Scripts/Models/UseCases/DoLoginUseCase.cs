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
    
    //public void Init()
    //{
    //    Debug.Log("MakeInit");
    //    _firebaseLoginService.Init();
    //    _eventDispatcherService.Subscribe<LogConnectionEvent>(AlreadyConnected);
    //}
    public void Login()
    {
        firebaseLoginService.LoginApp();

        var ID = firebaseLoginService.GetID();
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
            var ID = firebaseLoginService.GetID();
            var logEvent = new LogEvent(ID);
            _eventDispatcherService.Dispatch<LogEvent>(logEvent);
            Debug.Log("Dispatch come from AlreadyConnected");
        }
    }
    public bool UserExists()
    {
        return firebaseLoginService.IDAppExist();
    }
}
