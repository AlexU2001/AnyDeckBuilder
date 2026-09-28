using Any_Deck_Builder_MAUI.Models;
using Any_Deck_Builder_MAUI.PageModels;

namespace Any_Deck_Builder_MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}