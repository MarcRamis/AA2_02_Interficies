using Code;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;
    [SerializeField] private LoginPanelView _loginPanelPrefab;

    IDoLoginUseCase doLoginUseCase;

    private void Awake()
    {
        // Views
        var loginPanelView = Instantiate(_loginPanelPrefab, _canvasParent);
        
        // ModelViews
        var loginPanelViewModel = new LoginPanelViewModel();
        loginPanelView.SetViewModel(loginPanelViewModel);

        // Services
        var eventDIspatcherService = new EventDispatcherService();
        var firebaseLoginService = new FirebaseLoginService(eventDIspatcherService);

        // Use cases
        doLoginUseCase = new DoLoginUseCase(firebaseLoginService, eventDIspatcherService);
        doLoginUseCase.Init();
        // Controllers
        new LoginPanelController(loginPanelViewModel, doLoginUseCase);
        // Presenters
        new LoginPanelPresenter(loginPanelViewModel, doLoginUseCase, eventDIspatcherService);
    }
    private void Start()
    {
        
    }
}
