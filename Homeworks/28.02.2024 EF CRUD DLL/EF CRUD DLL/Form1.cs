using CountryContextLibrary;
using CountryContextLibrary._26._02._2024_Entity_Framework;
using CountryLibrary;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace EF_CRUD_DLL
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            UpdateComboBoxes();
        }

        public void UpdateComboBoxes()
        {
            try
            {
                using (var db = new CountryContext())
                {
                    var queryForParts = from b in db.PartOfTheWorlds
                                        select b;
                    comboBoxPartName.DataSource = queryForParts.ToList();
                    comboBoxPartName.DisplayMember = "Name";

                    comboBoxPartForCountry.DataSource = queryForParts.ToList();
                    comboBoxPartForCountry.DisplayMember = "Name";

                    var queryForCountries = from b in db.Countries
                                            select b;
                    comboBoxCountryName.DataSource = queryForCountries.ToList();
                    comboBoxCountryName.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
     

        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private void HandleOutput(string output)
        {
            MessageBox.Show(output);
        }

        private void comboBoxPartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PartOfTheWorld? selectedPart = comboBoxPartName.SelectedItem as PartOfTheWorld;
            if (selectedPart != null)
            {
                textBoxPartName.Text = selectedPart.Name;
            }

        }
        private void comboBoxCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country? selectedCountry = comboBoxCountryName.SelectedItem as Country;
            if (selectedCountry != null)
            {
                textBoxCountryName.Text = selectedCountry.Name;
                textBoxCapital.Text = selectedCountry.Capital;
                numericUpDownPopulation.Value = selectedCountry.Population;
                numericUpDownArea.Value = selectedCountry.Area;


                int partIndex = comboBoxPartForCountry.FindStringExact(selectedCountry.PartOfTheWorld.Name);

                // Установить SelectedIndex
                comboBoxPartForCountry.SelectedIndex = partIndex;
            }
        }
        
        
        
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            try
            {
                string newPartOfTheWorldName = textBoxPartName.Text.Trim();
                if (string.IsNullOrEmpty(newPartOfTheWorldName))
                {
                    HandleOutput("Не задано название части света!");
                    return;
                }
                using (var db = new CountryContext())
                {
                    bool isPartOfTheWorldExists = db.PartOfTheWorlds.Any(p => p.Name == newPartOfTheWorldName);
                    if (isPartOfTheWorldExists)
                    {
                        HandleOutput("Часть света с таким именем уже есть");
                        return;
                    }


                    var partOfTheWorld = new PartOfTheWorld { Name = newPartOfTheWorldName };


                    db.PartOfTheWorlds.Add(partOfTheWorld);
                    db.SaveChanges();
                    UpdateComboBoxes();
                    
                    HandleOutput($"Часть света {newPartOfTheWorldName} добавлена!");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            if (comboBoxPartName.Items.Count == 0)
                return;
            try
            {
                using (var db = new CountryContext())
                {
                    List<PartOfTheWorld> list = comboBoxPartName.DataSource as List<PartOfTheWorld>;
                    string partOfTheWorldName = list[comboBoxPartName.SelectedIndex].Name;
                    var query = from b in db.PartOfTheWorlds
                                where b.Name == partOfTheWorldName
                                select b;
                    db.PartOfTheWorlds.RemoveRange(query);
                    db.SaveChanges();

                  
                    UpdateComboBoxes();

                    if (comboBoxPartName.Items.Count == 0)
                    {
                        comboBoxPartName.SelectedIndex = -1;
                        textBoxPartName.Text = "";
                        comboBoxPartName.Text = "";
                    }

                    if (comboBoxCountryName.Items.Count == 0)
                    {
                        textBoxCountryName.Text = "";
                        textBoxCapital.Text = "";
                        numericUpDownArea.Value = 0;
                        numericUpDownPopulation.Value = 0;
                        comboBoxPartForCountry.SelectedIndex = -1;
                    }

                    HandleOutput($"Часть света {partOfTheWorldName} удалена!");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnChangePart_Click(object sender, EventArgs e)
        {
            try
            {
                string partName = textBoxPartName.Text.Trim();
                if (partName == "")
                {
                    MessageBox.Show("Не задано название группы!");
                    return;
                }
                using (var db = new CountryContext())
                {
                    bool isPartOfTheWorldExists = db.PartOfTheWorlds.Any(p => p.Name == partName);
                    if (isPartOfTheWorldExists)
                    {
                        HandleOutput("Часть света с таким именем уже существует");
                        return;
                    }

                    List<PartOfTheWorld> list = comboBoxPartName.DataSource as List<PartOfTheWorld>;
                    string partNameWhatChange = list[comboBoxPartName.SelectedIndex].Name;
                    var query = (from b in db.PartOfTheWorlds
                                 where b.Name == partNameWhatChange
                                 select b).Single();
                    query.Name = partName;
                    db.SaveChanges();

                    UpdateComboBoxes();
                    int partIndex = comboBoxPartName.FindStringExact(partName);
                    if (partIndex != -1) comboBoxPartName.SelectedIndex = partIndex;

                    HandleOutput("Часть света переименована!");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }


        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            try
            {
                string countryName = textBoxCountryName.Text.Trim();
                string capital = textBoxCapital.Text.Trim();
                int area = (int)numericUpDownArea.Value;
                int population = (int)numericUpDownPopulation.Value;
                if (countryName == "" || capital == "")
                {
                    HandleOutput("Не указано название страны или столица!");
                    return;
                }
                if (comboBoxPartForCountry.Items.Count == 0)
                {
                    HandleOutput("Не создано ни одной части света!");
                    return;
                }
               
                if (area == 0)
                {
                    HandleOutput("Площадь не может быть нулём!");
                    return;
                }


                if (population == 0)
                {
                    HandleOutput("Население не может быть нулём!");
                    return;
                }

                using (var db = new CountryContext())
                {
                    bool isPartOfTheWorldExists = db.Countries.Any(p => p.Name == countryName);
                    if (isPartOfTheWorldExists)
                    {
                        HandleOutput("Страна с таким названием уже существует");
                        return;
                    }


                    List<PartOfTheWorld> list = comboBoxPartName.DataSource as List<PartOfTheWorld>;
                    string partName = list[comboBoxPartName.SelectedIndex].Name;
                    var query = (from b in db.PartOfTheWorlds
                                 where b.Name == partName
                                 select b).Single();

                    

                    var country = new Country
                    {
                        Name = countryName,
                        Capital = capital,
                        Population = population,
                        Area = area,
                        PartOfTheWorld = query
                    };
                    db.Countries.Add(country);
                    db.SaveChanges();
                    UpdateComboBoxes();



                    HandleOutput($"Страна {countryName} добавлен!");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnDeleteCountry_Click(object sender, EventArgs e)
        {
            if (comboBoxCountryName.Items.Count == 0) return;
            try
            {
                using (var db = new CountryContext())
                {
                    // Удаляем страну
                    List<Country>? list = comboBoxCountryName.DataSource as List<Country>;
                    string countryName = list[comboBoxCountryName.SelectedIndex].Name;
                    var query = from b in db.Countries
                                where b.Name == countryName
                                select b;
                    db.Countries.RemoveRange(query);
                    db.SaveChanges();
                    UpdateComboBoxes();



                    if (comboBoxCountryName.Items.Count == 0)
                    {
                        textBoxCountryName.Text = "";
                        textBoxCapital.Text = "";
                        numericUpDownPopulation.Value = 0;
                        numericUpDownArea.Value = 0;
                        comboBoxPartForCountry.SelectedIndex = -1;
                        comboBoxCountryName.Text = "";
                    }
                    HandleOutput($"Страна {countryName} удалена");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnChangeCountry_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxCountryName.Text.Trim();
                string capital = textBoxCapital.Text.Trim();
                int population = (int)numericUpDownPopulation.Value;
                int area = (int)numericUpDownArea.Value;
                PartOfTheWorld? partOfTheWorld = comboBoxPartForCountry.SelectedItem as PartOfTheWorld;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(capital))
                {
                    HandleOutput("Не указано название страны или столица!");
                    return;
                }
                if (partOfTheWorld == null)
                {
                    HandleOutput("Не выбрана часть света!");
                    return;
                }
                if (population == 0 || area == 0)
                {
                    HandleOutput("Население или площадь не могут равняться нулю!");
                    return;
                }

                using (var db = new CountryContext())
                {
                    List<PartOfTheWorld>? list = comboBoxPartForCountry.DataSource as List<PartOfTheWorld>;
                    string partOfTheWorldName = list[comboBoxPartForCountry.SelectedIndex].Name;
                    var queryToGetPartOfTheWorld = (from b in db.PartOfTheWorlds
                                                    where b.Name == partOfTheWorldName
                                                    select b).Single();

                    if (queryToGetPartOfTheWorld == null) return;


                    List<Country>? countryList = comboBoxCountryName.DataSource as List<Country>;
                    string countryName = countryList[comboBoxCountryName.SelectedIndex].Name;
                    var queryToGetCountry = (from b in db.Countries
                                  where b.Name == countryName
                                  select b).Single();

                    queryToGetCountry.Name = name;
                    queryToGetCountry.Capital = capital;
                    queryToGetCountry.Population = population;
                    queryToGetCountry.Area = area;
                    queryToGetCountry.PartOfTheWorld = queryToGetPartOfTheWorld;
                    db.SaveChanges();

                    UpdateComboBoxes();

                    HandleOutput($"Данные о стране {name} изменены");

                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
