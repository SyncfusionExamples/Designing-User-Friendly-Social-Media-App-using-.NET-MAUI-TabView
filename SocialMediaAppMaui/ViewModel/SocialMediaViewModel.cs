using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAppMaui
{
    public class SocialMediaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Post> Posts { get; set; }
        public ObservableCollection<Post> UserPosts { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public ObservableCollection<Post> ExplorePosts { get; set; }

        public UserProfile Profile { get; set; }

        public SocialMediaViewModel()
        {
            // Sample posts

            Posts = new ObservableCollection<Post>
            {
                new Post { UserName = "Alice", ProfileImage = "profile9.png", PostImage = "animals.png", Caption = "Wildlife moments!", Likes = 120, Comments = 15, Shares = 5, IsLiked=true },
                new Post { UserName = "Bob", ProfileImage = "profile2.png", PostImage = "artist.png", Caption = "Creative vibes!", Likes = 200, Comments = 30, Shares = 10 },
                new Post { UserName = "Charlie", ProfileImage = "profile3.png", PostImage = "scenerymobile.png", Caption = "Nature is healing 🌿", Likes = 180, Comments = 22, Shares = 8, IsLiked=true },
                new Post { UserName = "Diana", ProfileImage = "profile4.png", PostImage = "kids.png", Caption = "Family time ❤️", Likes = 250, Comments = 40, Shares = 12 },
                new Post { UserName = "Ethan", ProfileImage = "profile5.png", PostImage = "brazil.jpg", Caption = "Beachside bliss!", Likes = 300, Comments = 35, Shares = 14 },
                new Post { UserName = "Fiona", ProfileImage = "profile6.png", PostImage = "bird11.png", Caption = "Birdwatching day 🐦", Likes = 95, Comments = 10, Shares = 3, IsLiked=true },
                new Post { UserName = "George", ProfileImage = "profile7.png", PostImage = "dancemonkey.png", Caption = "Dance like nobody's watching!", Likes = 400, Comments = 50, Shares = 20 },
                new Post { UserName = "Hannah", ProfileImage = "profile8.png", PostImage = "dotnet_bot.png", Caption = "Coding with .NET Bot 🤖", Likes = 150, Comments = 18, Shares = 7 },
                new Post { UserName = "Ian", ProfileImage = "profile9.png", PostImage = "hospital5.png", Caption = "Healthcare heroes!", Likes = 220, Comments = 25, Shares = 11 },
                new Post { UserName = "Jane", ProfileImage = "profile1.png", PostImage = "hotel6.png", Caption = "Staycation goals 🏨", Likes = 310, Comments = 42, Shares = 16 },
                new Post { UserName = "Kevin", ProfileImage = "profile2.png", PostImage = "musical.png", Caption = "Live music night 🎶", Likes = 275, Comments = 33, Shares = 13 },
                new Post { UserName = "Lily", ProfileImage = "profile3.png", PostImage = "myheadmyheart.png", Caption = "On repeat 🎧", Likes = 180, Comments = 20, Shares = 9 , IsLiked=true},
                new Post { UserName = "Mike", ProfileImage = "profile4.png", PostImage = "sculpture.png", Caption = "Art in stone 🗿", Likes = 145, Comments = 17, Shares = 6 },
                new Post { UserName = "Nina", ProfileImage = "profile5.png", PostImage = "thebusiness.png", Caption = "Work hard, play harder 💼", Likes = 330, Comments = 38, Shares = 15 },
                new Post { UserName = "Oscar", ProfileImage = "profile6.png", PostImage = "wonders07.png", Caption = "Wonders of the world 🌍", Likes = 500, Comments = 60, Shares = 25 }
            };

            // Sample user posts
            UserPosts = new ObservableCollection<Post>
            {
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "fitnessimage.png", Caption = "Fitness goals in action 💪", Likes = 120, Comments = 15, Shares = 5 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "heatwaves.png", Caption = "heatwave vibes!", Likes = 200, Comments = 30, Shares = 10 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "hotel7.png", Caption = "Luxury stay at its finest 🏨", Likes = 180, Comments = 22, Shares = 8 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "kids.png", Caption = "Family time ❤️", Likes = 250, Comments = 40, Shares = 12 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "levitating.jpg", Caption = "Floating into the weekend 🎈", Likes = 300, Comments = 35, Shares = 14 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "bird16.png", Caption = "Spotting rare birds in nature 🐦", Likes = 95, Comments = 10, Shares = 3 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "sculpture.png", Caption = "Admiring timeless art 🏛️", Likes = 400, Comments = 50, Shares = 20 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "dotnet_bot.png", Caption = "Coding with .NET Bot 🤖", Likes = 150, Comments = 18, Shares = 7 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "hospital5.png", Caption = "Healthcare heroes!", Likes = 220, Comments = 25, Shares = 11 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "vehicles.png", Caption = "Cruising through the city 🚗", Likes = 310, Comments = 42, Shares = 16 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "musical.png", Caption = "Live music night 🎶", Likes = 275, Comments = 33, Shares = 13 },
                new Post { UserName = "John Doe", ProfileImage = "profile1.png", PostImage = "myheadmyheart.png", Caption = "Emotional beats on repeat 🎧", Likes = 180, Comments = 20, Shares = 9 },
            };

            // Sample explore posts

            ExplorePosts = new ObservableCollection<Post>
            {
                new Post { PostImage = "animals.png", UserName = "WildLifeLover" },
                new Post { PostImage = "artist.png", UserName = "CreativeSoul" },
                new Post { PostImage = "scenerymobile.png", UserName = "NatureSnap" },
                new Post { PostImage = "kids.png", UserName = "FamilyMoments" },
                new Post { PostImage = "brazil.jpg", UserName = "TravelBug" },
                new Post { PostImage = "bird11.png", UserName = "BirdWatcher" },
                new Post { PostImage = "dancemonkey.png", UserName = "DanceVibes" },
                new Post { PostImage = "dotnet_bot.png", UserName = "Techie" },
                new Post { PostImage = "hospital5.png", UserName = "HealthCarePro" },
                new Post { PostImage = "hotel6.png", UserName = "LuxuryLife" },
                new Post { PostImage = "wonders07.png", UserName = "Explorer" },
                new Post { PostImage = "musical.png", UserName = "MusicManiac" },
                new Post { PostImage = "myheadmyheart.png", UserName = "EmoArtist" },
                new Post { PostImage = "sculpture.png", UserName = "ArtCollector" },
                new Post { PostImage = "thebusiness.png", UserName = "StartupGuru" },
                new Post { PostImage = "bird16.png", UserName = "BirdLover" },
                new Post { PostImage = "wonders07.png", UserName = "WondersLove" },
                new Post { PostImage = "cameraaccessories.png", UserName = "PhotoGrapher" },
                new Post { PostImage = "kids.png", UserName = "FamilyMoments" },
                new Post { PostImage = "yourlove.png", UserName = "Explorer" },
                new Post { PostImage = "bird11.png", UserName = "Nature" },
            };


            // Sample messages
            Messages = new ObservableCollection<Message>
            {
                new Message { Sender = "Emily", SenderImage = "profile5.png", LastMessage = "Hey, are you free this weekend?", IsUnread = true, UnreadMessageCount="3" },
                new Message { Sender = "Frank", SenderImage = "profile6.png", LastMessage = "Meeting at 3 PM confirmed."},
                new Message { Sender = "Grace", SenderImage = "profile7.png", LastMessage = "Loved your last post!", IsUnread = true , UnreadMessageCount="2"},
                new Message { Sender = "Henry", SenderImage = "profile8.png", LastMessage = "Let's catch up soon.", IsUnread = true},
                new Message { Sender = "Isla", SenderImage = "profile5.png", LastMessage = "Check out this link!", IsUnread = true, UnreadMessageCount="4" },
                new Message { Sender = "Alice", SenderImage = "profile9.png", LastMessage = "Did you see the new art exhibit?" },
                new Message { Sender = "John", SenderImage = "profile4.png", LastMessage = "Lunch tomorrow at our usual spot?"},
                new Message { Sender = "Mike", SenderImage = "profile1.png", LastMessage = "I just uploaded a new photo!"},
                new Message { Sender = "Fiona", SenderImage = "profile2.png", LastMessage = "Let's plan the weekend trip.",IsUnread = true, UnreadMessageCount="1" },
                new Message { Sender = "Diana", SenderImage = "profile7.png", LastMessage = "New design is ready!", },
                new Message { Sender = "Alex", SenderImage = "profile4.png", LastMessage = "The kids loved the zoo visit!"},
                new Message { Sender = "James", SenderImage = "profile6.png", LastMessage = "Check out this link!",},
                new Message { Sender = "Amelia", SenderImage = "profile5.png", LastMessage = "Let's catch up soon.",},
                new Message { Sender = "Irene", SenderImage = "profile7.png" , LastMessage = "Meeting at 10 AM confirmed."},
            };

            Profile = new UserProfile
            {
                Name = "John Doe",
                ProfileImage = "profile1.png",
                Bio = "Passionate about photography and travel.",
                Followers = 1200,
                Following = 300,
                UserPosts = UserPosts
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
