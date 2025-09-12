namespace SocialMediaAppMaui;

public partial class CreatePostPage : ContentPage
{
    SocialMediaViewModel _socialMediaViewModel;
    public CreatePostPage(SocialMediaViewModel socialMediaViewModel)
    {
        InitializeComponent();
        _socialMediaViewModel = socialMediaViewModel;

    }


    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        // Create and navigate to the image selection page
        var imageSelectionPage = new ImageSelectionPage(OnImageSelected);
        await Navigation.PushAsync(imageSelectionPage);
    }

    // Callback method to receive selected image
    private void OnImageSelected(string selectedImage)
    {
        if (!string.IsNullOrEmpty(selectedImage))
        {
            postImage.Source = selectedImage;
            postImage.IsVisible = true;
        }
    }

    private void OnPostClicked(object sender, EventArgs e)
    {

        var caption = captionEditor.Text;

        FileImageSource imageSource = (FileImageSource)postImage.Source;

        if (imageSource is not null)
        {
            imageSource = imageSource.File.ToString();
        }

        if (string.IsNullOrEmpty(caption) && string.IsNullOrEmpty(imageSource))
        {
            DisplayAlert("Incomplete", "Please add a caption or select an image.", "OK");
            return;
        }

        var newPost = new Post
        {
            Caption = caption,
            PostImage = imageSource,
            ProfileImage = _socialMediaViewModel.Profile.ProfileImage,
            Likes = 0,
            Comments = 0,
            UserName = "You" // Or fetch from logged-in user
        };

        _socialMediaViewModel.Posts.Insert(0, newPost);
        _socialMediaViewModel.UserPosts.Insert(0, newPost);

        Navigation.PopAsync(); // Go back to main page

    }
}