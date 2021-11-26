using UniRx;

public class LoginPanelController : Controller
{
    private readonly LoginPanelViewModel loginPanelViewModel;
    private readonly IDoLoginUseCase loginUseCase;

    public LoginPanelController(LoginPanelViewModel _loginPanelViewModel, IDoLoginUseCase _loginUseCase)
    {
        loginPanelViewModel = _loginPanelViewModel;
        loginUseCase = _loginUseCase;

        loginPanelViewModel.LoginButtonPressed.Subscribe((_) =>
        {
            loginUseCase.Login();
            loginPanelViewModel.IsVisible.Value = false;
        })
        .AddTo(_disposables);
    }
}