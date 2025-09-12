using System.Collections.ObjectModel;

namespace SocialMediaAppMaui;

public partial class ProfileImageSelectionPage : ContentPage
{
    private readonly Action<string> _onImageSelected;

    public ObservableCollection<string> ImageList { get; set; }
    private string _selectedImage;

    public ProfileImageSelectionPage(Action<string> onImageSelected)
    {
        InitializeComponent();
        _onImageSelected = onImageSelected;

        ImageList = new ObservableCollection<string>
            {
                "profile1.png", "brazil.png", "dancemonkey.png", "kids.png",
                "animals.jpg", "birds.png", "myheadmyheart.png", "sports.png"
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