using Any_Deck_Builder_MAUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace Any_Deck_Builder_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}