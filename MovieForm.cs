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
            btnAdapter.Text = id == 0 ? "ADD NEW MOVIE" : "UPDATE MOVIE DATA";

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
            while (reader.Read()) cbxGenres.Items.Add(reader["Name"]);
        }

        private void BtnAdapter_Click(object? sender, EventArgs e)
        {
            using MySqlConnection connection = new(Program.ConnectionString);
            connection.Open();
            MySqlDataAdapter adapter = new();

            string msbText = string.Empty;

            if (ID == 0)
            {
                adapter.InsertCommand = new(
                    "INSERT INTO Movies (Title, ReleaseYear, GenreID) VALUES " +
                    $"('{txbTitle.Text}', {nudYear.Value}, {selectedGenreID});",
                    connection);
                adapter.InsertCommand.ExecuteNonQuery();

                msbText = $"new movie added successfully!";
            }
            else
            {
                adapter.UpdateCommand = new(
                    "UPDATE Movies SET " +
                    $"Title = '{txbTitle.Text}', " +
                    $"ReleaseYear = {nudYear.Value}, " +
                    $"GenreID = {selectedGenreID} " +
                    $"WHERE ID = {ID};",
                    connection);
                adapter.UpdateCommand.ExecuteNonQuery();

                msbText = $"movie data successfully modified!";
            }

            _ = MessageBox.Show(
                caption: "SUCCESS!",
                text: msbText,
                icon: MessageBoxIcon.Information,
                buttons: MessageBoxButtons.OK);

            this.Close();
        }
    }
}
