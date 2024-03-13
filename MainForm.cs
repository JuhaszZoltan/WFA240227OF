using MySql.Data.MySqlClient;

namespace WFA240227OF
{
    public partial class MainForm : Form
    {
        private int id = 0;

        public MainForm()
        {
            InitializeComponent();
            // event, ami akkor fut le, amikor betöltõdik ennek a Form-nak egy példánya
            // [objektumneve].[esemény] += [eseménykezelõ neve];
            // += begépelése után tab -> legenerálja az üres metódust
            this.Load += MainForm_Load;

            dgv.CellClick += Dgv_CellClick;

            btnInsert.Click += BtnInsert_Click;
            btnModifies.Click += BtnModifies_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            using MySqlConnection connection = new(Program.ConnectionString);
            connection.Open();

            MySqlDataAdapter adapter = new()
            {
                DeleteCommand = new(
                    $"DELETE FROM Movies WHERE ID = {id};",
                    connection),
            };

            DialogResult result = MessageBox.Show(
                caption: "DELETE WARNING",
                text: "Are you sure you want to delete this movie?\n" +
                $"({dgv.SelectedRows[0].Cells[1].Value})",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Warning);

            if (result == DialogResult.Yes && id != 0)
                adapter.DeleteCommand.ExecuteNonQuery();
            MainForm_Load(this, e);
        }

        private void Dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            id = (int)dgv[columnIndex: 0, rowIndex: e.RowIndex].Value;
        }

        private void BtnModifies_Click(object? sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;


            //a modifies-nek kell az ID, ezért "rejtett oszlop"ként betesszük a táblázatba
            _ = new MovieForm(id: id).ShowDialog();
            MainForm_Load(this, e);
        }

        private void BtnInsert_Click(object? sender, EventArgs e)
        {
            _ = new MovieForm().ShowDialog();
            MainForm_Load(this, e);
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            dgv.Rows.Clear();

            // def. az adatbázis kapcsolatot:
            // (mivel IDisposable, ezért használunk elõtte using-ot)

            // a mysqlconnection példányosítása vár egy paramétert: a connection string-et, vagyis azt a sort, ami tartalmazza az adatbázisserver címét és autentikációs adatait
            // ezt a Program.cs-ben rögzítettük statikus field-ként, hogy mindenhonnan elérjük
            using MySqlConnection connection = new(Program.ConnectionString);

            //def. után meg kell nyitni:
            connection.Open();

            // innentõl tudunk SQL commandokat (utasításokat) def.ni a provider számára:

            // a command 2 paramétert vár:
            // - a konkrét SQL utasítás stringként,
            // - a kapcsolat, amin ezt majd érvényesíteni akarjuk

            string commandString =
                "SELECT Movies.ID, Movies.Title, Movies.ReleaseYear, Genres.Name " +
                "FROM Movies INNER JOIN Genres ON Movies.GenreID = Genres.ID " +
                "ORDER BY Title ASC;";

            MySqlCommand command = new(commandString, connection);

            // reader: a "select"-es lekérdezések eredményének olvasására
            // adapter: a módosító utasítások érvényesítésére

            // az executereader példány szintû függvény az adott commandból készít egy sql reader példányt.
            MySqlDataReader reader = command.ExecuteReader();

            //a reader példány használható asszociatív vektorként, vektorként és vannak példány szintû tagfüggvényei is

            //elõször kell egy ciklis, ami bejárja a lekérdezés eredménytáblájának összes sorát

            // a reader.read() -> visszatér egy logikai értékkel, hogy került-e adat a readerbe, vagy sem
            // tehát ha "false" akkor nincs eredmény, nincs több sor, ezért:

            while (reader.Read())
            {
                // a .read() minden iterációban meghívódik, közben populálja a readert (mintha egy vektor lenne) az adott lekérdezési sor adataivel, így a ciklus törzsén belül ki lehet belõle olvasni

                object id = reader[0];
                object title = reader[1];
                object year = reader[2];
                object genre = reader[3];

                // ezt követõen a dgv-hez hozzá tudunk adni egy új sort, ami rendre tartalmazza a kiolvasott adattagokat:

                // a "params object[] values" várt paraméter azt jelenti, hogy bár az add metódus egy object vektort vár, de ezt úgy is át lehet neki adni (params kulcsszó), hogy a vektor elemeit vesszõvel elválasztva adom át a metódusnak:
                dgv.Rows.Add(id, title, year, genre);

                //a paraméterek rorrendje meghatározza, hogy a dgv melyik oszlopába kerül az adat az új sor hozzáadásánál:
                // 1. paraméter: 1. oszlopba, 2. a 2.-ba, és így tovább.
            }


            // hibaüzenet, ami azt takarja, hogy még nincs megírva ez a függvény
            // (amikor megírjuk, "célszerû" törölni)
            // throw new NotImplementedException();

            dgv.ClearSelection();
        }
    }
}
