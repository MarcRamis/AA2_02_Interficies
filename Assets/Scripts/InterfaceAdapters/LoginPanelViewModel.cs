using UniRx;

public class LoginPanelViewModel : ViewModel
{
    public readonly ReactiveCommand LoginButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<string> TextID;

    public LoginPanelViewModel()
    {
        LoginButtonPressed = new ReactiveCommand()
            .AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>()
            .AddTo(_disposables);
        TextID = new ReactiveProperty<string>(string.Empty)
            .AddTo(_disposables);
    }
}