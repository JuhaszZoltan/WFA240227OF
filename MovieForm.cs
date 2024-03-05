using MySql.Data.MySqlClient;

namespace WFA240227OF
{
    public partial class MovieForm : Form
    {
        public int ID { get; }
        private int selectedGenreID = 0;
        public MovieForm(int id = 0)
        {
            ID = id;
            InitializeComponent();
            this.Load += MovieForm_Load;
            cbxGenres.SelectedIndexChanged += CbxGenres_SelectedIndexChanged;
            btnAdapter.Click += BtnAdapter_Click;
        }

        private void CbxGenres_SelectedIndexChanged(object? sender, EventArgs e)
        {
            using MySqlConnection connection = new(Program.ConnectionString);
            connection.Open();
            MySqlDataReader reader = new MySqlCommand(
                $"SELECT ID FROM Genres WHERE Name LIKE '{cbxGenres.SelectedItem}';",
                connection).ExecuteReader();
            reader.Read();
            selectedGenreID = (int)reader["ID"];
            MessageBox.Show($"{selectedGenreID}");
        }

        private void MovieForm_Load(object? sender, EventArgs e)
        {
            FillGenresCBX();

            if (ID != 0)
            {
                txbID.Text = $"{ID}";
                using MySqlConnection connection = new(Program.ConnectionString);
                connection.Open();

                MySqlDataReader reader = new MySqlCommand(
                    $"SELECT Title, ReleaseYear, Genres.Name FROM Movies " +
                    $"INNER JOIN Genres ON GenreID = Genres.ID " +
                    $"WHERE Movies.ID = {ID};",
                    connection).ExecuteReader();
                reader.Read();

                nudYear.Value = (int)reader["ReleaseYear"];
                txbTitle.Text = (string)reader["Title"];
                cbxGenres.SelectedItem = reader["Name"];
            }
        }

        private void FillGenresCBX()
        {
            using MySqlConnection connection = new(Program.ConnectionString);
            connection.Open();
            MySqlDataReader reader = new MySqlCommand(
                "SELECT * FROM Genres ORDER BY Name;",
                connection).ExecuteReader();
            while (reader.Read())
            {
                cbxGenres.Items.Add(reader["Name"]);
            }
        }

        private void BtnAdapter_Click(object? sender, EventArgs e)
        {
            if (ID == 0)
            {
                //INSERT
            }
            else
            {
                //UPDATE
            }
        }
    }
}
