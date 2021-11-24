using UniRx;

public class LoginPanelController
{
    LoginPanelViewModel _loginPanelViewModel;

    public LoginPanelController(LoginPanelViewModel loginPanelViewModel)
    {
        _loginPanelViewModel = loginPanelViewModel;
        loginPanelViewModel.IsVisible.Value = true;

        loginPanelViewModel.LoginButtonPressed.Subscribe((_) =>
        {
            loginPanelViewModel.IsVisible.Value = false;
            //_loginPanelViewModel.TextID.SetValueAndForceNotify(_textId);
        });
    }
}
