using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Book_Store.Entities;
using Book_Store.Extensions;
using Book_Store.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Image = Book_Store.Entities.Image;

namespace Book_Store
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool? _hasImageOfBook;
        private Account currentAccount;

        public MainWindow()
        {
            InitializeComponent();

            using (var db = new BookStoreContext())
            {
                db.Database.Migrate();
            }

            LogEntryList.ItemsSource = LogEntryLoggerProvider.LogEntites;

            LogOut();
            Authorization();

            LoginText.Text = "admin";
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // skip bubbling event
            if (e.Source is not System.Windows.Controls.TabControl)
                return;

            var header = (TabControl.SelectedItem as TabItem).Header.ToString();

            if (header == MainWindowStrings.TabItemBooks)
                UpdateBooks();
            else if (header == MainWindowStrings.TabItemAuthors)
                UpdateAuthors();
            else if (header == MainWindowStrings.TabItemPublisher)
                UpdatePublishers();
            else if (header == MainWindowStrings.TabItemGenre)
                UpdateGenres();
            else if (header == "Discounts")
                UpdateDiscounts();
            else if (header == "Showcase") UpdateShowcase();
        }

        private void UpdateShowcase()
        {
            using var db = new BookStoreContext();

            ShowcaseListView.ItemsSource = db.Books.Include(x => x.Author).Include(nameof(Genre)).Include(nameof(Publisher))
                .Include(nameof(Image)).ToList();

            GuestFirstName.Text = string.Empty;
            GuestLastName.Text = string.Empty;
            GuestPhone.Text = string.Empty;
        }

        private void UpdateAuthors()
        {
            using (var db = new BookStoreContext())
            {
                ListViewAuthors.ItemsSource = (from author in db.Authors
                    orderby author.FirstName, author.LastName
                    select author).ToList();
            }

            FirstNameText.Text = string.Empty;
            LastNameText.Text = string.Empty;
            PatronymicText.Text = string.Empty;
        }

        private void UpdateBooks()
        {
            using var db = new BookStoreContext();

            var books = db.Books
                .Include(nameof(Author))
                .Include(nameof(Genre))
                .Include(nameof(Publisher))
                .Include(nameof(Image));

            if (!string.IsNullOrEmpty(SearchBookText.Text)) books = books.Where(x => x.Name.Contains(SearchBookText.Text));

            if (ShowDecommissionBooksCheckBox.IsChecked == false)
                books = books.Where(x => !db.DecommissionedBooks.Select(x => x.BookId).Contains(x.Id));

            ListViewBooks.ItemsSource = books.OrderBy(x => x.Name).ToList();

            NameBookText.Text = string.Empty;

            AuthorComboBox.ItemsSource = db.Authors.ToList();
            AuthorComboBox.SelectedIndex = 0;

            PublisherCheckBox.IsChecked = false;
            PublisherComboBox.IsEnabled = false;
            PublisherComboBox.ItemsSource = db.Publishers.ToList();
            PublisherComboBox.SelectedIndex = -1;

            PagesBookText.Text = string.Empty;

            GenreCheckBox.IsChecked = false;
            GenreComboBox.IsEnabled = false;
            GenreComboBox.ItemsSource = db.Genres.ToList();
            GenreComboBox.SelectedIndex = -1;

            YearPublishingText.Text = string.Empty;
            CostPriceText.Text = string.Empty;
            PriceText.Text = string.Empty;

            PreviousBookCheckBox.IsChecked = false;
            PreviousBookComboBox.ItemsSource = db.Books.ToList();

            DeleteBookButton.IsEnabled = false;
            ChangeBookButton.IsEnabled = false;
            DecommissionBookButton.IsEnabled = false;

            ImageViewer.Source = new BitmapImage().GetImage(DefaultBookCovers.default_book_cover);
            _hasImageOfBook = false;
        }

        private void UpdatePublishers()
        {
            using (var db = new BookStoreContext())
            {
                ListViewPublisher.ItemsSource = (from publisher in db.Publishers
                    orderby publisher.Name
                    select publisher).ToList();
            }

            PublisherNameText.Text = string.Empty;
        }

        private void UpdateGenres()
        {
            using (var db = new BookStoreContext())
            {
                ListViewGenre.ItemsSource = (from genre in db.Genres
                    orderby genre.Name
                    select genre).ToList();
            }

            GenreNameText.Text = string.Empty;
        }

        private void UpdateDiscounts()
        {
            using (var db = new BookStoreContext())
            {
                ListViewDiscountsDiscount.ItemsSource = db.Discounts.OrderBy(x => x.Percent).ToList();
            }

            ListViewDiscountsBooksIncluded.Items.Clear();
            UpdateDiscountsBooksNoIncluded();

            DiscountNameText.Text = string.Empty;
            DiscountPercentUpDown.Value = DiscountPercentUpDown.Minimum;
            DiscountStartPicker.SelectedDate = DateTime.Now;
            DiscountEndPicker.SelectedDate = DateTime.Now.AddDays(1);

            DeleteDiscountButton.IsEnabled = false;
            ChangeDiscountButton.IsEnabled = false;
        }

        private void UpdateDiscountsBooksNoIncluded()
        {
            using (var db = new BookStoreContext())
            {
                var included = ListViewDiscountsBooksIncluded.Items.OfType<Book>().Select(x => x.Id).ToArray();

                ListViewDiscountsBooksNoIncluded.ItemsSource = db.Books
                    .Include(nameof(Author))
                    .Include(nameof(Genre))
                    .Include(nameof(Publisher))
                    .AsEnumerable()
                    .Where(x => !included.Contains(x.Id))
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        // ---------------------------------------------------------------------------------------- //


        private void listViewAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewAuthors.SelectedIndex == -1)
                return;

            var author = ListViewAuthors.SelectedItem as Author;

            FirstNameText.Text = author.FirstName;
            LastNameText.Text = author.LastName ?? string.Empty;
            PatronymicText.Text = author.Patronymic ?? string.Empty;
        }

        private void listViewBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewBooks.SelectedIndex == -1)
                return;

            var book = ListViewBooks.SelectedItem as Book;

            NameBookText.Text = book.Name;
            AuthorComboBox.SelectedItem = book.Author;
            PagesBookText.Text = book.Pages.ToString();
            YearPublishingText.Text = book.YearPublishing.Year.ToString();
            CostPriceText.Text = string.Format("{0:0.00}", book.CostPrice);
            PriceText.Text = string.Format("{0:0.00}", book.Price);
            ChangeBookButton.IsEnabled = true;
            DeleteBookButton.IsEnabled = true;

            if (book.Publisher is not null)
            {
                PublisherCheckBox.IsChecked = true;
                PublisherComboBox.SelectedItem = book.Publisher;
            }
            else
            {
                PublisherCheckBox.IsChecked = false;
                PublisherComboBox.SelectedIndex = -1;
            }

            if (book.Genre is not null)
            {
                GenreCheckBox.IsChecked = true;
                GenreComboBox.SelectedItem = book.Genre;
            }
            else
            {
                GenreCheckBox.IsChecked = false;
                GenreComboBox.SelectedIndex = -1;
            }

            // continuation and decommissioned books, image
            Book previousBook;
            //Entities.Image image;
            bool isDecommissionedBook;

            using (var db = new BookStoreContext())
            {
                PreviousBookComboBox.ItemsSource = (from x in db.Books
                    where x.Id != book.Id && x.Id != (from y in db.ContinuationBooks
                        where book.Id == y.PredecessorBookId
                        select y.BookId).FirstOrDefault()
                    select x).ToList();

                previousBook = (from x in PreviousBookComboBox.ItemsSource.OfType<Book>()
                    where x.Id == (from b in db.ContinuationBooks
                        where b.BookId == book.Id
                        select b.PredecessorBookId).FirstOrDefault()
                    select x).FirstOrDefault();

                isDecommissionedBook = (from x in db.DecommissionedBooks
                    where x.BookId == book.Id
                    select x).Any();

                ImageViewer.Source = new BitmapImage().GetImage(book.ImageId != null
                    ? book.Image.ImageData
                    : db.Images.First(x => x.ImageTitle == "default").ImageData);
                _hasImageOfBook = book.ImageId != null;
            }

            if (previousBook is not null)
            {
                PreviousBookCheckBox.IsChecked = true;
                PreviousBookComboBox.SelectedItem = previousBook;
            }
            else
            {
                PreviousBookCheckBox.IsChecked = false;
                PreviousBookComboBox.SelectedIndex = -1;
            }

            DecommissionBookButton.IsEnabled = true;
            DecommissionBookButton.Content = isDecommissionedBook ? "Return" : "Decommission";
        }

        private void listViewPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewPublisher.SelectedIndex == -1)
                return;

            var publisher = ListViewPublisher.SelectedItem as Publisher;

            PublisherNameText.Text = publisher.Name;
        }

        private void listViewGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewGenre.SelectedIndex == -1)
                return;

            var genre = ListViewGenre.SelectedItem as Genre;

            GenreNameText.Text = genre.Name;
        }


        private void listViewDiscountsDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewDiscountsDiscount.SelectedIndex == -1)
                return;

            var discount = ListViewDiscountsDiscount.SelectedItem as Discount;
            DiscountNameText.Text = discount.Name;
            DiscountPercentUpDown.Value = (int)discount.Percent;
            DiscountStartPicker.SelectedDate = discount.StartDate;
            DiscountEndPicker.SelectedDate = discount.EndDate;

            ChangeDiscountButton.IsEnabled = true;
            DeleteDiscountButton.IsEnabled = true;

            ListViewDiscountsBooksIncluded.Items.Clear();

            using (var db = new BookStoreContext())
            {
                var includedBooksId = db.BookDiscounts.Where(x => x.DiscountId == discount.Id).Select(y => y.BookId).ToList();

                var includedBooks = db.Books.Include(nameof(Author))
                    .Include(nameof(Genre)).Include(nameof(Publisher)).AsEnumerable()
                    .Where(x => includedBooksId.Contains(x.Id)).ToList();

                foreach (var book in includedBooks) ListViewDiscountsBooksIncluded.Items.Add(book);
            }

            UpdateDiscountsBooksNoIncluded();
        }


        // ---------------------------------------------------------------------------------------- //


        private void addAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameText.Text == string.Empty)
            {
                MessageBox.Show("First name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Authors.Add(new Author
                    {
                        FirstName = FirstNameText.Text != string.Empty ? FirstNameText.Text : null,
                        LastName = LastNameText.Text != string.Empty ? LastNameText.Text : null,
                        Patronymic = PatronymicText.Text != string.Empty ? PatronymicText.Text : null
                    });

                    db.SaveChanges();
                    UpdateAuthors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changeAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameText.Text == string.Empty)
            {
                MessageBox.Show("First name is empty!", MainWindowStrings.WindowTitle, MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    var author = db.Authors.First(a => a.Id == (ListViewAuthors.SelectedItem as Author).Id);
                    author.FirstName = FirstNameText.Text != string.Empty ? FirstNameText.Text : null;
                    author.LastName = LastNameText.Text != string.Empty ? LastNameText.Text : null;
                    author.Patronymic = PatronymicText.Text != string.Empty ? PatronymicText.Text : null;

                    db.SaveChanges();
                    UpdateAuthors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Authors.Remove(ListViewAuthors.SelectedItem as Author);
                    db.SaveChanges();
                    UpdateAuthors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void decommissionBookButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    if (DecommissionBookButton.Content.ToString() == "Decommission")
                        db.DecommissionedBooks.Add(new DecommissionedBook
                        {
                            BookId = (ListViewBooks.SelectedItem as Book).Id
                        });
                    else if (DecommissionBookButton.Content.ToString() == "Return")
                        db.DecommissionedBooks.Remove(db.DecommissionedBooks.First(
                            x => x.BookId == (ListViewBooks.SelectedItem as Book).Id
                        ));

                    db.SaveChanges();
                    UpdateBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void updateDbBookButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBookText.Text = string.Empty;
            UpdateBooks();
        }

        private void addPublisherButton_Click(object sender, RoutedEventArgs e)
        {
            if (PublisherNameText.Text == string.Empty)
            {
                MessageBox.Show("publisher name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Publishers.Add(new Publisher
                    {
                        Name = PublisherNameText.Text
                    });

                    db.SaveChanges();
                    UpdatePublishers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changePublisherButton_Click(object sender, RoutedEventArgs e)
        {
            if (PublisherNameText.Text == string.Empty)
            {
                MessageBox.Show("publisher name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    var publisher = db.Publishers.First(a => a.Id == (ListViewPublisher.SelectedItem as Publisher).Id);
                    publisher.Name = PublisherNameText.Text;

                    db.SaveChanges();
                    UpdatePublishers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deletePublisherButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Publishers.Remove(ListViewPublisher.SelectedItem as Publisher);
                    db.SaveChanges();
                    UpdatePublishers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenreNameText.Text == string.Empty)
            {
                MessageBox.Show("genre name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Genres.Add(new Genre
                    {
                        Name = GenreNameText.Text
                    });

                    db.SaveChanges();
                    UpdateGenres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changeGenreButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenreNameText.Text == string.Empty)
            {
                MessageBox.Show("genre name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new BookStoreContext())
            {
                try
                {
                    var genre = db.Genres.First(a => a.Id == (ListViewGenre.SelectedItem as Genre).Id);
                    genre.Name = GenreNameText.Text;

                    db.SaveChanges();
                    UpdateGenres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteGenreButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Genres.Remove(ListViewGenre.SelectedItem as Genre);
                    db.SaveChanges();
                    UpdateGenres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxsOfBook())
                return;

            using (var db = new BookStoreContext())
            {
                try
                {
                    var newBook = db.Books.Add(new Book
                    {
                        Name = NameBookText.Text,
                        AuthorId = (AuthorComboBox.SelectedItem as Author).Id,
                        PublisherId = PublisherCheckBox.IsChecked == true ? (PublisherComboBox.SelectedItem as Publisher).Id : null,
                        Pages = int.Parse(PagesBookText.Text),
                        GenreId = GenreCheckBox.IsChecked == true ? (GenreComboBox.SelectedItem as Genre).Id : null,
                        YearPublishing = new DateTime(int.Parse(YearPublishingText.Text), 1, 1),
                        CostPrice = decimal.Parse(CostPriceText.Text),
                        Price = decimal.Parse(PriceText.Text),
                        Image = _hasImageOfBook == true
                            ? new Image { ImageData = (ImageViewer.Source as BitmapImage).GetBytes() }
                            : null
                    });

                    if (PreviousBookCheckBox.IsChecked == true)
                        db.ContinuationBooks.Add(new ContinuationBook
                        {
                            Book = newBook.Entity,
                            PredecessorBookId = (PreviousBookComboBox.SelectedItem as Book).Id
                        });

                    db.SaveChanges();
                    UpdateBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changeBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxsOfBook())
                return;

            using (var db = new BookStoreContext())
            {
                try
                {
                    var book = db.Books.First(x => x.Id == (ListViewBooks.SelectedItem as Book).Id);

                    book.Name = NameBookText.Text;
                    book.AuthorId = (AuthorComboBox.SelectedItem as Author).Id;
                    book.PublisherId = PublisherCheckBox.IsChecked == true ? (PublisherComboBox.SelectedItem as Publisher).Id : null;
                    book.Pages = int.Parse(PagesBookText.Text);
                    book.GenreId = GenreCheckBox.IsChecked == true ? (GenreComboBox.SelectedItem as Genre).Id : null;
                    book.YearPublishing = new DateTime(int.Parse(YearPublishingText.Text), 1, 1);
                    book.CostPrice = decimal.Parse(CostPriceText.Text);
                    book.Price = decimal.Parse(PriceText.Text);

                    if (_hasImageOfBook == true)
                        book.Image = new Image { ImageData = (ImageViewer.Source as BitmapImage).GetBytes() };
                    else
                        book.ImageId = null;

                    var continuationBook = (from x in db.ContinuationBooks where book.Id == x.BookId select x).FirstOrDefault();
                    if (PreviousBookCheckBox.IsChecked == true)
                    {
                        if (continuationBook is not null)
                            continuationBook.PredecessorBookId = (PreviousBookComboBox.SelectedItem as Book).Id;
                        else
                            db.ContinuationBooks.Add(new ContinuationBook
                            {
                                Book = book,
                                PredecessorBookId = (PreviousBookComboBox.SelectedItem as Book).Id
                            });
                    }
                    else
                    {
                        if (continuationBook is not null)
                            db.ContinuationBooks.Remove(continuationBook);
                    }

                    db.SaveChanges();
                    UpdateBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Books.Remove(ListViewBooks.SelectedItem as Book);
                    db.SaveChanges();
                    UpdateBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxsOfDiscount())
                return;

            using (var db = new BookStoreContext())
            {
                try
                {
                    var discount = db.Discounts.Add(new Discount
                    {
                        Name = DiscountNameText.Text,
                        Percent = DiscountPercentUpDown.Value.Value,
                        StartDate = DiscountStartPicker.SelectedDate.Value,
                        EndDate = DiscountEndPicker.SelectedDate.Value
                    });

                    foreach (Book item in ListViewDiscountsBooksIncluded.Items)
                        db.BookDiscounts.Add(new BookDiscount
                        {
                            Discount = discount.Entity,
                            BookId = item.Id
                        });

                    db.SaveChanges();
                    UpdateDiscounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreContext())
            {
                try
                {
                    db.Discounts.Remove(ListViewDiscountsDiscount.SelectedItem as Discount);

                    db.SaveChanges();
                    UpdateDiscounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changeDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxsOfDiscount())
                return;

            using (var db = new BookStoreContext())
            {
                var discount = db.Discounts.First(x => x.Id == (ListViewDiscountsDiscount.SelectedItem as Discount).Id);

                try
                {
                    discount.Name = DiscountNameText.Text;
                    discount.Percent = DiscountPercentUpDown.Value.Value;
                    discount.StartDate = DiscountStartPicker.SelectedDate.Value;
                    discount.EndDate = DiscountEndPicker.SelectedDate.Value;

                    db.BookDiscounts.RemoveRange(db.BookDiscounts.Where(x => x.DiscountId == discount.Id));

                    foreach (Book item in ListViewDiscountsBooksIncluded.Items)
                        db.BookDiscounts.Add(new BookDiscount
                        {
                            Discount = discount,
                            BookId = item.Id
                        });

                    db.SaveChanges();
                    UpdateDiscounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        // ---------------------------------------------------------------------------------------- //


        private bool CheckTextBoxsOfBook()
        {
            if (NameBookText.Text == string.Empty)
            {
                MessageBox.Show("book name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (PagesBookText.Text == string.Empty)
            {
                MessageBox.Show("pages field is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (CostPriceText.Text == string.Empty)
            {
                MessageBox.Show("cost price field is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (PriceText.Text == string.Empty)
            {
                MessageBox.Show("price field is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (YearPublishingText.Text == string.Empty || int.Parse(YearPublishingText.Text) < 1
                                                        || int.Parse(YearPublishingText.Text) > 9999)
            {
                MessageBox.Show("year of publishing is not correct!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool CheckTextBoxsOfDiscount()
        {
            if (DiscountNameText.Text == string.Empty)
            {
                MessageBox.Show("discount name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (DiscountEndPicker.SelectedDate < DiscountStartPicker.SelectedDate)
            {
                MessageBox.Show("end date < start date!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            //if ((from x in listViewDiscountsDiscount.ItemsSource.OfType<Discount>() select x.Name).Contains())
            //{
            //    MessageBox.Show("name is already exist!", Properties.MainWindowStrings.WindowTitle,
            //        MessageBoxButton.OK, MessageBoxImage.Error);
            //    return false;
            //}

            return true;
        }

        private bool CheckTextBoxsOfMakeOrder()
        {
            if (GuestFirstName.Text == string.Empty)
            {
                MessageBox.Show("first name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (GuestLastName.Text == string.Empty)
            {
                MessageBox.Show("last name is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (GuestPhone.Text == string.Empty)
            {
                MessageBox.Show("phone is empty!", MainWindowStrings.WindowTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        // ---------------------------------------------------------------------------------------- //


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FloatValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9.,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void genreCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GenreComboBox.IsEnabled = true;
        }

        private void publisherCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PublisherComboBox.IsEnabled = true;
        }

        private void publisherCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PublisherComboBox.IsEnabled = false;
        }

        private void genreCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GenreComboBox.IsEnabled = false;
        }

        private void previousBookCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PreviousBookComboBox.IsEnabled = true;
        }

        private void previousBookCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PreviousBookComboBox.IsEnabled = false;
        }

        private void searchBookText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void showDecommissionBooksCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateBooks();
        }

        private void showDecommissionBooksCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBooks();
        }

        private void updateDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDiscounts();
        }

        private void discountBookUpButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Book book in ListViewDiscountsBooksNoIncluded.SelectedItems) ListViewDiscountsBooksIncluded.Items.Add(book);

            UpdateDiscountsBooksNoIncluded();
        }

        private void discountBookDownButton_Click(object sender, RoutedEventArgs e)
        {
            var oldBooks = ListViewDiscountsBooksIncluded.SelectedItems.OfType<Book>().ToList();
            foreach (var book in oldBooks) ListViewDiscountsBooksIncluded.Items.Remove(book);

            UpdateDiscountsBooksNoIncluded();
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
            Authorization();
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogOut();
            Authorization();
        }

        private void Authorization()
        {
            foreach (TabItem item in TabControl.Items) item.Visibility = Visibility.Collapsed;

            switch ((RoleType)currentAccount.RoleId)
            {
                case RoleType.ADMIN:
                    TabItemBooks.Visibility = Visibility.Visible;
                    TabItemDiscounts.Visibility = Visibility.Visible;
                    TabItemAuthors.Visibility = Visibility.Visible;
                    TabItemPublisher.Visibility = Visibility.Visible;
                    TabItemGenre.Visibility = Visibility.Visible;
                    TabItemAuth.Visibility = Visibility.Visible;
                    TabItemLogs.Visibility = Visibility.Visible;
                    LogOutButton.IsEnabled = true;
                    LoginLabel.Content = currentAccount.Login;
                    break;
                case RoleType.USER:
                    break;
                case RoleType.GUEST:
                    TabItemAuth.Visibility = Visibility.Visible;
                    TabItemShowcase.Visibility = Visibility.Visible;
                    LogOutButton.IsEnabled = false;
                    LoginLabel.Content = "guest";
                    break;
            }
        }

        private void LogIn()
        {
            using var db = new BookStoreContext();
            var user = db.Accounts.FirstOrDefault(x => x.Login.ToLower() == LoginText.Text.ToLower());

            if (user is not null) currentAccount = user;

            LoginText.Text = string.Empty;
            PasswordText.Password = string.Empty;
        }

        private void LogOut()
        {
            currentAccount = new Account { RoleId = (int)RoleType.GUEST };
            PasswordText.Password = string.Empty;
        }

        private void addCoverBookButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                var selectedFileName = dlg.FileName;
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();

                ImageViewer.Source = bitmap;
                _hasImageOfBook = true;
            }
        }

        private void deleteCoverBookButton_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer.Source = new BitmapImage().GetImage(DefaultBookCovers.default_book_cover);
            _hasImageOfBook = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var book = ShowcaseListView.SelectedItem as Book;
            ShowcaseListView.Items.OfType<Book>().First(x => x.Id == book.Id).IsBought = true;
            ShowcaseListView.Items.Refresh();
        }

        private void makeOrederButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxsOfMakeOrder())
                return;

            using (var db = new BookStoreContext())
            {
                try
                {
                    var customer = db.Customers.Add(new Customer
                        { FirstName = GuestFirstName.Text, LastName = GuestLastName.Text, Phone = GuestPhone.Text });
                    foreach (var book in ShowcaseListView.Items.OfType<Book>().Where(x => x.IsBought).ToList())
                        db.Orders.Add(new Order { Customer = customer.Entity, BookId = book.Id });

                    db.SaveChanges();
                    UpdateShowcase();
                    MessageBox.Show("order is made!", MainWindowStrings.WindowTitle, MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), MainWindowStrings.WindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

    public class SwitchBindingExtension : Binding
    {
        public SwitchBindingExtension()
        {
            Initialize();
        }

        public SwitchBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        public SwitchBindingExtension(string path, object valueIfTrue, object valueIfFalse)
            : base(path)
        {
            Initialize();
            ValueIfTrue = valueIfTrue;
            ValueIfFalse = valueIfFalse;
        }

        [ConstructorArgument("valueIfTrue")] public object ValueIfTrue { get; set; }

        [ConstructorArgument("valueIfFalse")] public object ValueIfFalse { get; set; }

        private void Initialize()
        {
            ValueIfTrue = DoNothing;
            ValueIfFalse = DoNothing;
            Converter = new SwitchConverter(this);
        }

        private class SwitchConverter : IValueConverter
        {
            private readonly SwitchBindingExtension _switch;

            public SwitchConverter(SwitchBindingExtension switchExtension)
            {
                _switch = switchExtension;
            }

            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    var b = System.Convert.ToBoolean(value);
                    return b ? _switch.ValueIfTrue : _switch.ValueIfFalse.ToString() == "_" ? "" : _switch.ValueIfFalse;
                }
                catch
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DoNothing;
            }

            #endregion
        }
    }
}