using Code;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;
    [SerializeField] private LoginPanelView _loginPanelPrefab;

    IFirebaseLoginService firebaseLoginService;

    private List<IDisposable> _disposables = new List<IDisposable>();
    
    private void Awake()
    {
        // Views
        var loginPanelView = Instantiate(_loginPanelPrefab, _canvasParent);
        
        // ModelViews
        var loginPanelViewModel = new LoginPanelViewModel();
        loginPanelView.SetViewModel(loginPanelViewModel);

        // Services
        var eventDispatcherService = new EventDispatcherService();
        firebaseLoginService = new FirebaseLoginService(eventDispatcherService);

        // Use cases
        var doLoginUseCase = new DoLoginUseCase(firebaseLoginService, eventDispatcherService);
        
        // Controllers
        new LoginPanelController(loginPanelViewModel, doLoginUseCase);
        // Presenters
        new LoginPanelPresenter(loginPanelViewModel, doLoginUseCase, eventDispatcherService);
    }

    private void Start()
    {
        firebaseLoginService.Init();
    }
    private void OnDestroy()
    {
        foreach (IDisposable disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
