using Microsoft.EntityFrameworkCore;

namespace Autors_Books_EF_DatabaseFirst
{
    public partial class FormMain : Form
    {
        private LibraryContext _context;

        public FormMain()
        {
            InitializeComponent();
            _context = new LibraryContext();
            UpdateAuthorSubmenus();
            DisplayAllBooks();
        }


        private void DisplayAllAuthors()
        {
            var allAuthors = _context.Authors.ToList();

            dataGridView1.DataSource = allAuthors.Select(a => new
            {
                Автор = a.Name,
            }).ToList();

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void DisplayAllBooks()
        {
            var booksWithAuthors = _context.Books
                .Include(b => b.Author)
                .ToList();

            dataGridView1.DataSource = booksWithAuthors
                .Select(b => new
                {
                    Название = b.Title,
                    Автор = b.Author.Name
                })
                .ToList();

            // Устанавливаем заголовки столбцов
            dataGridView1.Columns[0].HeaderText = "Название";
            dataGridView1.Columns[1].HeaderText = "Автор";

            // Устанавливаем автоматическое изменение ширины столбцов
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void UpdateAuthorSubmenus()
        {
            // Очистить все существующие дочерние элементы
            displayAuthorsBooksToolStripMenuItem.DropDownItems.Clear();

            // Добавление дочерних подменю для каждого автора
            foreach (var author in _context.Authors)
            {
                var authorToolStripMenuItem = new ToolStripMenuItem(author.Name);
                authorToolStripMenuItem.Click += AuthorToolStripMenuItem_Click;
                displayAuthorsBooksToolStripMenuItem.DropDownItems.Add(authorToolStripMenuItem);
            }
        }

        

        private void AuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedAuthor = ((ToolStripMenuItem)sender).Text;
            var authorBooks = _context.Authors
                                    .Include(a => a.Books)
                                    .Where(a => a.Name == selectedAuthor)
                                    .SelectMany(a => a.Books.Select(b => b.Title))
                                    .ToList();
            if (authorBooks != null)
            {
                dataGridView1.DataSource = authorBooks.Select(title => new { Название = title }).ToList();
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void displayAllBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAllBooks();
        }

        private void displayAllAuthorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAllAuthors();
        }

        private void changeAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangeAuthor formChangeAuthor = new FormChangeAuthor(_context);
            formChangeAuthor.ShowDialog();
            UpdateAuthorSubmenus();
        }

        private void changeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangeBook formChangeBook = new FormChangeBook(_context);
            formChangeBook.ShowDialog();
        }
    }
}
