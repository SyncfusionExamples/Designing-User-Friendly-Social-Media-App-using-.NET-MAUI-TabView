namespace SocialMediaAppMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLikeTapped(object sender, TappedEventArgs e)
        {
            var post = (sender as Label).BindingContext as Post;
            if (post.IsLiked)
            {
                post.Likes--;
            }
            else
            {
                post.Likes++;
            }

            post.IsLiked = !post.IsLiked;
        }

        private async void OnCommentsTapped(object sender, TappedEventArgs e)
        {
            var post = (sender as Label).BindingContext as Post;
            post.Comments++;

            await this.DisplayAlert("Comments", "Comments added successfully!", "Okay");
        }

        private async void OnSharedTapped(object sender, TappedEventArgs e)
        {
            var post = (sender as Label).BindingContext as Post;
            post.Shares++;
            await this.DisplayAlert("Share", "Post shared successfully!", "Okay");
        }

        SearchBar senderSearchBar = null;
        private void OnSenderTextChanged(object sender, TextChangedEventArgs e)
        {
            senderSearchBar = (sender as SearchBar);
            if (messagesListView.DataSource != null)
            {
                this.messagesListView.DataSource.Filter = FilterContacts;
                this.messagesListView.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (senderSearchBar == null || senderSearchBar.Text == null)
                return true;

            var taskInfo = obj as Message;
            if (taskInfo.Sender.ToLower().Contains(senderSearchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        SearchBar exploreSearchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            exploreSearchBar = (sender as SearchBar);
            if (explorePostsListView.DataSource != null)
            {
                this.explorePostsListView.DataSource.Filter = FilterExploreContacts;
                this.explorePostsListView.DataSource.RefreshFilter();
            }
        }

        private bool FilterExploreContacts(object obj)
        {
            if (exploreSearchBar == null || exploreSearchBar.Text == null)
                return true;

            var taskInfo = obj as Post;
            if (taskInfo.UserName.ToLower().Contains(exploreSearchBar.Text.ToLower()) || taskInfo.PostImage.ToLower().Contains(exploreSearchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            // Create and navigate to the image selection page
            var imageSelectionPage = new ProfileImageSelectionPage(OnImageSelected);
            await Navigation.PushAsync(imageSelectionPage);
        }

        // Callback method to receive selected image
        private void OnImageSelected(string selectedImage)
        {
            if (!string.IsNullOrEmpty(selectedImage))
            {
                profileImage.Source = selectedImage;
            }
        }

        private async void OnCenterbuttonTapped(object sender, EventArgs e)
        {
            if (BindingContext is SocialMediaViewModel socialMediaViewModel)
            {
                Navigation.PushAsync(new CreatePostPage(socialMediaViewModel));
            }
        }
    }

}
