using MySql.Data.MySqlClient;

namespace WFA240227OF
{
    public partial class MainForm : Form
    {
        private int id = 0;

        public MainForm()
        {
            InitializeComponent();
            // event, ami akkor fut le, amikor bet�lt�dik ennek a Form-nak egy p�ld�nya
            // [objektumneve].[esem�ny] += [esem�nykezel� neve];
            // += beg�pel�se ut�n tab -> legener�lja az �res met�dust
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


            //a modifies-nek kell az ID, ez�rt "rejtett oszlop"k�nt betessz�k a t�bl�zatba
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

            // def. az adatb�zis kapcsolatot:
            // (mivel IDisposable, ez�rt haszn�lunk el�tte using-ot)

            // a mysqlconnection p�ld�nyos�t�sa v�r egy param�tert: a connection string-et, vagyis azt a sort, ami tartalmazza az adatb�zisserver c�m�t �s autentik�ci�s adatait
            // ezt a Program.cs-ben r�gz�tett�k statikus field-k�nt, hogy mindenhonnan el�rj�k
            using MySqlConnection connection = new(Program.ConnectionString);

            //def. ut�n meg kell nyitni:
            connection.Open();

            // innent�l tudunk SQL commandokat (utas�t�sokat) def.ni a provider sz�m�ra:

            // a command 2 param�tert v�r:
            // - a konkr�t SQL utas�t�s stringk�nt,
            // - a kapcsolat, amin ezt majd �rv�nyes�teni akarjuk

            string commandString =
                "SELECT Movies.ID, Movies.Title, Movies.ReleaseYear, Genres.Name " +
                "FROM Movies INNER JOIN Genres ON Movies.GenreID = Genres.ID " +
                "ORDER BY Title ASC;";

            MySqlCommand command = new(commandString, connection);

            // reader: a "select"-es lek�rdez�sek eredm�ny�nek olvas�s�ra
            // adapter: a m�dos�t� utas�t�sok �rv�nyes�t�s�re

            // az executereader p�ld�ny szint� f�ggv�ny az adott commandb�l k�sz�t egy sql reader p�ld�nyt.
            MySqlDataReader reader = command.ExecuteReader();

            //a reader p�ld�ny haszn�lhat� asszociat�v vektork�nt, vektork�nt �s vannak p�ld�ny szint� tagf�ggv�nyei is

            //el�sz�r kell egy ciklis, ami bej�rja a lek�rdez�s eredm�nyt�bl�j�nak �sszes sor�t

            // a reader.read() -> visszat�r egy logikai �rt�kkel, hogy ker�lt-e adat a readerbe, vagy sem
            // teh�t ha "false" akkor nincs eredm�ny, nincs t�bb sor, ez�rt:

            while (reader.Read())
            {
                // a .read() minden iter�ci�ban megh�v�dik, k�zben popul�lja a readert (mintha egy vektor lenne) az adott lek�rdez�si sor adataivel, �gy a ciklus t�rzs�n bel�l ki lehet bel�le olvasni

                object id = reader[0];
                object title = reader[1];
                object year = reader[2];
                object genre = reader[3];

                // ezt k�vet�en a dgv-hez hozz� tudunk adni egy �j sort, ami rendre tartalmazza a kiolvasott adattagokat:

                // a "params object[] values" v�rt param�ter azt jelenti, hogy b�r az add met�dus egy object vektort v�r, de ezt �gy is �t lehet neki adni (params kulcssz�), hogy a vektor elemeit vessz�vel elv�lasztva adom �t a met�dusnak:
                dgv.Rows.Add(id, title, year, genre);

                //a param�terek rorrendje meghat�rozza, hogy a dgv melyik oszlop�ba ker�l az adat az �j sor hozz�ad�s�n�l:
                // 1. param�ter: 1. oszlopba, 2. a 2.-ba, �s �gy tov�bb.
            }


            // hiba�zenet, ami azt takarja, hogy m�g nincs meg�rva ez a f�ggv�ny
            // (amikor meg�rjuk, "c�lszer�" t�r�lni)
            // throw new NotImplementedException();

            dgv.ClearSelection();
        }
    }
}
