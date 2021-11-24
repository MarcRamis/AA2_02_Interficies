using UniRx;

public class LoginPanelViewModel
{
    public readonly ReactiveCommand<string> LoginButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<string> TextID;

    public LoginPanelViewModel()
    {
        LoginButtonPressed = new ReactiveCommand<string>();
        IsVisible = new ReactiveProperty<bool>();
        TextID = new ReactiveProperty<string>(string.Empty);
    }
}