using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform canvasParent;
    [SerializeField] private LoginPanelView loginPrefab;

    FirebaseLoginService firebaseLoginService;
    private void Awake()
    {
        // Views
        var loginView = Instantiate(loginPrefab, canvasParent);
        
        // Views Models
        var loginViewModel = new LoginPanelViewModel();
        loginView.SetViewModel(loginViewModel);

        // Services
        var eventDispatcherService = new EventDispatcherService();
        firebaseLoginService = new FirebaseLoginService(eventDispatcherService);

        // Use cases
        var loginUseCase = new DoLoginUseCase(firebaseLoginService, eventDispatcherService);

        // Controllers
        new LoginPanelController(loginViewModel, loginUseCase);

        // Presenters
        new LoginPanelPresenter(loginViewModel, eventDispatcherService);
    }

    private void Start()
    {
        firebaseLoginService.Init();
    }
}
