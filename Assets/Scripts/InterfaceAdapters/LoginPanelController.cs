using UniRx;

public class LoginPanelController
{
    private readonly LoginPanelViewModel loginPanelViewModel;
    private readonly ILoginUseCase loginUseCase;

    public LoginPanelController(LoginPanelViewModel _loginPanelViewModel, ILoginUseCase _loginUseCase)
    {
        loginPanelViewModel = _loginPanelViewModel;
        loginUseCase = _loginUseCase;

        loginPanelViewModel.IsVisible.Value = true;

        loginPanelViewModel.LoginButtonPressed.Subscribe((_) =>
        {
            loginUseCase.Login();
            loginPanelViewModel.IsVisible.Value = false;
        });
    }
}