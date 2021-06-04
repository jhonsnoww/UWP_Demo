using SideBarDemo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SideBarDemo
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Book> Books;
        public ObservableCollection<User> Users;

        public MainPage()
        {
            this.InitializeComponent();
            Books = BookManager.GetBooks();
            Users = new ObservableCollection<User>();
            // Books = new ObservableCollection<Book>();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ClickedItem = (Book)e.ClickedItem;

            ResutText.Text = ClickedItem.Author;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book
            {
                Id = int.Parse(Id.Text),
                Name = Name.Text,
                Author = Author.Text
            });
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private async void FetchAllUser_Click(object sender, RoutedEventArgs e)
        {
            refresh.Visibility = Visibility.Visible;
            refresh.IsActive = true;

            Icon.Visibility = Visibility.Collapsed;
            var result = await UserManager.GetAllUsers();
            Icon.Visibility = Visibility.Visible;
            refresh.IsActive = false;
            refresh.Visibility = Visibility.Collapsed;
            if (result is List<User>)
            {
                List<User> users = result as List<User>;
                UserLength.Visibility = Visibility.Collapsed;
                Users.Clear();
                users.ForEach ((user) => Users.Add(user));
              
            }
            else
            {
                UserLength.Text = result.GetType().ToString();
            }
        }
    }
}