namespace Autors_Books_EF_DatabaseFirst
{
    public partial class FormChangeAuthor : Form
    {
        LibraryContext _context;
        public FormChangeAuthor(LibraryContext context)
        {
            InitializeComponent();
            _context = context;

            // Загрузка списка авторов из базы данных
            var authors = _context.Authors.ToList();

            foreach (var author in authors)
            {
                comboBox1.Items.Add(author.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                
                Author newAuthor = new Author
                {
                    Name = textBox1.Text
                };

              
                _context.Authors.Add(newAuthor);
                _context.SaveChanges();

                comboBox1.Items.Add(newAuthor.Name);

                MessageBox.Show("Автор успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Введите имя автора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            
            string selectedAuthorName = comboBox1.SelectedItem.ToString();

            
            var author = _context.Authors.FirstOrDefault(a => a.Name == selectedAuthorName);

            
            if (author != null)
            {
                
                author.Name = textBox1.Text;

                
                _context.SaveChanges();

                
                comboBox1.Items[comboBox1.SelectedIndex] = textBox1.Text;

                MessageBox.Show("Имя автора успешно изменено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Автор не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            string selectedAuthorName = comboBox1.SelectedItem.ToString();

            
            var author = _context.Authors.FirstOrDefault(a => a.Name == selectedAuthorName);

            
            if (author != null)
            {
                
                _context.Authors.Remove(author);
                _context.SaveChanges();

                
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);

                comboBox1.SelectedIndex = 0;
                MessageBox.Show("Автор успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Автор не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
