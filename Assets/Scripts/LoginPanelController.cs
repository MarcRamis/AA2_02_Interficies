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
        
        loginPanelViewModel.LoginButtonPressed.Subscribe((textID) =>
        {
            loginPanelViewModel.IsVisible.Value = false;
            doLoginUseCase.Login(textID);
            //loginPanelViewModel.TextID.SetValueAndForceNotify("User ID: " + textID);
        });
    }
}
