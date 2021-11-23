//using Code;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;
    [SerializeField] private LoginPanelView _loginPanelPrefab;
    
    private void Awake()
    {
        var loginPanelView = Instantiate(_loginPanelPrefab, _canvasParent);
        var loginPanelViewModel = new LoginPanelViewModel();

        loginPanelView.SetViewModel(loginPanelViewModel);
        new LoginPanelController(loginPanelViewModel);
        // aqui va el presenter
        
        //taskRespoitory
        //var eventDispatcher = new EventDispatcherService();
    }
}
