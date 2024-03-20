namespace Autors_Books_EF_DatabaseFirst
{
    public partial class FormChangeBook : Form
    {
        LibraryContext _context;
        public FormChangeBook(LibraryContext context)
        {
            InitializeComponent();
            _context = context;

            // Загрузка списка авторов из базы данных
            var books = _context.Books.ToList();

            foreach (var book in books)
            {
                comboBoxTitle.Items.Add(book.Title);
            }

            var authors = _context.Authors.ToList();

            foreach (var author in authors)
            {
                comboBoxAuthor.Items.Add(author.Name);
            }

            comboBoxTitle.SelectedIndex = 0;
            //comboBoxAuthor.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTitle = comboBoxTitle.SelectedItem.ToString();

            // Находим соответствующую книгу в базе данных
            var book = _context.Books.FirstOrDefault(b => b.Title == selectedTitle);

            
            if (book != null)
            {
                textBoxNewTitle.Text = book.Title;
                comboBoxAuthor.SelectedItem = book.Author.Name;
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNewTitle.Text) && comboBoxAuthor.SelectedItem != null)
            {
                string selectedAuthorName = comboBoxAuthor.SelectedItem.ToString();

                // Находим соответствующего автора в базе данных
                var author = _context.Authors.FirstOrDefault(a => a.Name == selectedAuthorName);

                Book newBook = new Book
                {
                    Title = textBoxNewTitle.Text,
                    AuthorId = author.AuthorId // Устанавливаем связь с автором
                };

                // Добавляем новую книгу в контекст и сохраняем изменения в базе данных
                _context.Books.Add(newBook);
                _context.SaveChanges();

                MessageBox.Show("Книга успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Введите название книги и выберите автора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string selectedTitle = comboBoxTitle.SelectedItem.ToString();

            var book = _context.Books.FirstOrDefault(b => b.Title == selectedTitle);

            if (book != null)
            {
                string selectedAuthorName = comboBoxAuthor.SelectedItem.ToString();

                var author = _context.Authors.FirstOrDefault(a => a.Name == selectedAuthorName);

                book.Title = textBoxNewTitle.Text;
                book.AuthorId = author.AuthorId;

                _context.SaveChanges();

                MessageBox.Show("Данные книги успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Книга не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedTitle = comboBoxTitle.SelectedItem.ToString();
            var book = _context.Books.FirstOrDefault(b => b.Title == selectedTitle);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

                MessageBox.Show("Книга успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Книга не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
