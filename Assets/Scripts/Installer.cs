using UnityEngine;
using System.Collections.Generic;
using System;
using UniRx;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform canvasParent;
    [SerializeField] private LoginPanelView loginPrefab;

    private FirebaseLoginService firebaseLoginService;
    private DoLoginUseCase loginUseCase;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        // Views
        var loginView = Instantiate(loginPrefab, canvasParent);
        
        // Views Models
        var loginViewModel = new LoginPanelViewModel()
            .AddTo(_disposables);
        loginView.SetViewModel(loginViewModel);

        // Services
        var eventDispatcherService = new EventDispatcherService();
        firebaseLoginService = new FirebaseLoginService(eventDispatcherService);

        // Use cases
        loginUseCase = new DoLoginUseCase(firebaseLoginService, eventDispatcherService);

        // Controllers
        new LoginPanelController(loginViewModel, loginUseCase)
            .AddTo(_disposables);

        // Presenters
        new LoginPanelPresenter(loginViewModel, eventDispatcherService)
            .AddTo(_disposables);
    }

    private void Start()
    {
        firebaseLoginService.Init();
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
        
        loginUseCase.Dispose();
    }
}
