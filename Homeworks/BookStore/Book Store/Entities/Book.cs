using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;
using Book_Store.Extensions;
using Book_Store.Properties;

namespace Book_Store.Entities
{
    public class Book
    {
        public Book()
        {
            BookDiscounts = new HashSet<BookDiscount>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int Pages { get; set; }
        public int? GenreId { get; set; }
        public DateTime YearPublishing { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }


        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual DecommissionedBook DecommissionedBook { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<BookDiscount> BookDiscounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        public BitmapImage BitmapImage
        {
            get
            {
                if (ImageId != null)
                    return new BitmapImage().GetImage(Image.ImageData);
                return new BitmapImage().GetImage(DefaultBookCovers.default_book_cover);
            }
        }

        [NotMapped] public bool IsBought { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}