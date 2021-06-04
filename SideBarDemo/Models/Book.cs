using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideBarDemo.Models
{
   public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

    }

    
    public class  BookManager
    {
        public static ObservableCollection<Book> GetBooks()
        {
           return new ObservableCollection<Book>() {
                new Book { Id = 1,Name= "Book 1",Author= "Auhtor 1" },
                new Book { Id = 2, Name = "Book 2", Author = "Auhtor 2" },
                new Book { Id = 3, Name = "Book 3", Author = "Auhtor 3" },
                new Book { Id = 4, Name = "Book 4", Author = "Auhtor 4" },
                new Book { Id = 5, Name = "Book 5", Author = "Auhtor 5" }
            };
            
        }
    }
}
