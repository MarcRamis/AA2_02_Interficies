using UniRx;

public class LoginPanelController : Controller
{
    LoginPanelViewModel _loginPanelViewModel;
    IDoLoginUseCase _doLoginUseCase;

    public LoginPanelController(LoginPanelViewModel loginPanelViewModel,
        IDoLoginUseCase doLoginUseCase)
    {
        _loginPanelViewModel = loginPanelViewModel;
        _doLoginUseCase = doLoginUseCase;
        
        _loginPanelViewModel.IsVisible.Value = true;
        _loginPanelViewModel.LoginButtonPressed.Subscribe((_) =>
        {
            _doLoginUseCase.Login();
            //loginPanelViewModel.IsVisible.Value = false;
        })
        .AddTo(_disposables);
    }
}
