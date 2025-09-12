using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAppMaui
{
    public class Post : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string PostImage { get; set; }
        public string Caption { get; set; }

        private int comments { get; set; }
        private int shares { get; set; }
        private int likes;
        private bool isLiked { get; set; }

        public int Likes
        {
            get => likes;
            set { likes = value; OnPropertyChanged(nameof(Likes)); }
        }

        public bool IsLiked
        {
            get => isLiked;
            set { isLiked = value; OnPropertyChanged(nameof(IsLiked)); }
        }

        public int Comments
        {
            get => comments;
            set { comments = value; OnPropertyChanged(nameof(Comments)); }
        }

        public int Shares
        {
            get => shares;
            set { shares = value; OnPropertyChanged(nameof(Shares)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    public class Message
    {
        public string Sender { get; set; }
        public string SenderImage { get; set; }
        public string LastMessage { get; set; }
        public bool IsUnread { get; set; }
        public string UnreadMessageCount { get; set; }
    }

    public class UserProfile
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public ObservableCollection<Post> UserPosts { get; set; }
    }
}
