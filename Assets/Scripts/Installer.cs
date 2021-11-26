using Code;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;
    [SerializeField] private LoginPanelView _loginPanelPrefab;
    
    private void Awake()
    {
        // Views
        var loginPanelView = Instantiate(_loginPanelPrefab, _canvasParent);
        
        // ModelViews
        var loginPanelViewModel = new LoginPanelViewModel();
        loginPanelView.SetViewModel(loginPanelViewModel);


        // Services
        var firebaseLoginService = new FirebaseLoginService();
        var eventDIspatcherService = new EventDispatcherService();

        // Use cases
        var doLoginUseCase = new DoLoginUseCase(firebaseLoginService, eventDIspatcherService);

        //if (doLoginUseCase.UserExists()) { loginPanelViewModel.IsVisible.Value = false; }
        //else { loginPanelViewModel.IsVisible.Value = true; }    

        // Controllers
        new LoginPanelController(loginPanelViewModel, doLoginUseCase);
        // Presenters
        new LoginPanelPresenter(loginPanelViewModel, doLoginUseCase, eventDIspatcherService);
    }
}
