using UniRx;

public class LoginPanelController
{
    LoginPanelViewModel _loginPanelViewModel;
    IDoLoginUseCase _doLoginUseCase;

    public LoginPanelController(LoginPanelViewModel loginPanelViewModel,
        IDoLoginUseCase doLoginUseCase)
    {
        _loginPanelViewModel = loginPanelViewModel;
        _doLoginUseCase = doLoginUseCase;
        loginPanelViewModel.IsVisible.Value = true;

        loginPanelViewModel.LoginButtonPressed.Subscribe((_) =>
        {
            doLoginUseCase.Login();
            loginPanelViewModel.IsVisible.Value = false;
        });
    }
}
