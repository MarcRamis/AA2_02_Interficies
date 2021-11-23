using UniRx;

public class LoginPanelViewModel
{
    public readonly ReactiveCommand LoginButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    //public readonly ReactiveProperty<string> TextID;

    public LoginPanelViewModel(/*string _textId*/)
    {
        LoginButtonPressed = new ReactiveCommand();
        IsVisible = new ReactiveProperty<bool>();
        //TextID = new ReactiveProperty<string>(_textId);
    }
}
