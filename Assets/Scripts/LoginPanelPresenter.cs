using Code;

public class LoginPanelPresenter 
{
    private readonly IEventDispatcherService _eventDispatcherService;
    private readonly IDoLoginUseCase _doLoginUseCase;
    private readonly LoginPanelViewModel _viewModel;

    public LoginPanelPresenter(LoginPanelViewModel viewModel,
        IDoLoginUseCase doLoginUseCase,
        IEventDispatcherService eventDispatcherService)
    {
        _viewModel = viewModel;
        _eventDispatcherService = eventDispatcherService;
        _doLoginUseCase = doLoginUseCase;
        
        _eventDispatcherService.Subscribe<LogEvent>(OnLogID);
    }

    private void OnLogID(LogEvent data)
    {
        _viewModel.TextID.SetValueAndForceNotify("User ID: " + data.Text);
        _viewModel.IsVisible.Value = false;
    }
}