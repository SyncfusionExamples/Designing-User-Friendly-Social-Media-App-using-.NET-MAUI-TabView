using System.Collections.ObjectModel;

namespace SocialMediaAppMaui;


public partial class ImageSelectionPage : ContentPage
{
    private readonly Action<string> _onImageSelected;

    public ObservableCollection<string> ImageList { get; set; }
    private string _selectedImage;

    public ImageSelectionPage(Action<string> onImageSelected)
    {
        InitializeComponent();
        _onImageSelected = onImageSelected;

        ImageList = new ObservableCollection<string>
            {
                "animals.png", "artist.png", "scenerymobile.png", "kids.png",
                "brazil.jpg", "bird11.png", "dancemonkey.png", "dotnet_bot.png"
            };

        BindingContext = this;

        ImageListView.SelectionChanged += (s, e) =>
        {
            if (e.AddedItems.Count > 0)
                _selectedImage = e.AddedItems[0] as string;
        };
    }

    private async void OnOkClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_selectedImage))
        {
            _onImageSelected?.Invoke(_selectedImage);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("No Selection", "Please select an image first.", "OK");
        }
    }
}
