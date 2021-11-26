using UnityEngine;
public class LoginPanelPresenter
{
    private readonly IEventDispatcherService eventDispatcherService;
    private readonly LoginPanelViewModel viewModel;

    public LoginPanelPresenter(LoginPanelViewModel _viewModel, IEventDispatcherService _eventDispatcherService)
    {
        viewModel = _viewModel;
        eventDispatcherService = _eventDispatcherService;

        eventDispatcherService.Subscribe<LogEvent>(OnLogID);
    }

    private void OnLogID(LogEvent data)
    {
        viewModel.IsVisible.Value = false;
        viewModel.TextID.SetValueAndForceNotify("User ID: " + data.Text);
    }
}