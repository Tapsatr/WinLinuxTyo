using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        ListViewItem item;
        private bool confirmation = false;
        public string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WinLinux;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            SetListViews();
            RefreshListViewHenkilot();
            RefreshListViewProjektit();
            RefreshListViewTehtavat();


        }
        private void RefreshListViewHenkilot()
        {

            listViewHenkilot.Items.Clear();
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(@"SELECT HenkiloTiedot.Henkilo_Id, HenkiloTiedot.Nimi, HenkiloTiedot.Email, HenkiloTiedot.Puhelin, ProjektiTiedot.ProjektiNimi, Tehtavat.TehtavaTyyppi ProjektiTiedot
                                                FROM ((((HenkiloTiedot LEFT OUTER JOIN ProjektiHenkilot ON HenkiloTiedot.Henkilo_Id = ProjektiHenkilot.Henkilo_Id)
                                                LEFT OUTER JOIN ProjektiTiedot ON ProjektiTiedot.Projekti_Id = ProjektiHenkilot.Projekti_Id)
                                                LEFT OUTER JOIN ProjektiTehtavat ON ProjektiTehtavat.Henkilo_Id = HenkiloTiedot.Henkilo_Id)
                                                LEFT OUTER JOIN Tehtavat ON ProjektiTehtavat.Tehtava_Id = Tehtavat.Tehtava_Id)", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("myTable");
            da.Fill(table);
           
            listViewHenkilot.View = View.Details;
            ListViewItem iItem;
            foreach (DataRow row in table.Rows)
            {
                iItem = new ListViewItem();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i == 0)
                        iItem.Text = row.ItemArray[i].ToString();
                    else
                        iItem.SubItems.Add(row.ItemArray[i].ToString());
                }
                listViewHenkilot.Items.Add(iItem);
            }
        }
        private void RefreshListViewProjektit()
        {

            listViewProjektit.Items.Clear();
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM ProjektiTiedot", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("myTable");
            da.Fill(table);

            listViewProjektit.View = View.Details;
            ListViewItem iItem;
            foreach (DataRow row in table.Rows)
            {
                iItem = new ListViewItem();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i == 0)
                        iItem.Text = row.ItemArray[i].ToString();
                    else
                        iItem.SubItems.Add(row.ItemArray[i].ToString());
                }
                listViewProjektit.Items.Add(iItem);
            }
        }

        private void RefreshListViewTehtavat()
        {

            listViewTehtavat.Items.Clear();
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Tehtavat", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("myTable");
            da.Fill(table);

            listViewTehtavat.View = View.Details;
            ListViewItem iItem;
            foreach (DataRow row in table.Rows)
            {
                iItem = new ListViewItem();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i == 0)
                        iItem.Text = row.ItemArray[i].ToString();
                    else
                        iItem.SubItems.Add(row.ItemArray[i].ToString());
                }
                listViewTehtavat.Items.Add(iItem);
            }
        }

        private void HenkiloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Values = ShowDialog("Uusi Henkilo", "Nimi", "Email", "Puhelin Numero");

            if (confirmation == false)
            {
                return;
            }
            else if (string.IsNullOrWhiteSpace(Values.Item1) || string.IsNullOrWhiteSpace(Values.Item2) || string.IsNullOrWhiteSpace(Values.Item3))
            {
                confirmation = false;
                MessageBox.Show("Arvo/arvoja puuttuu!");
            }

            if (confirmation == true)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("INSERT into HenkiloTiedot(Nimi,Email,Puhelin) values(@name,@email,@puhelin)"+ "SELECT CAST (scope_identity() AS int)", con);
                cmd.Parameters.AddWithValue("@name", Values.Item1);
                cmd.Parameters.AddWithValue("@email", Values.Item2);
                cmd.Parameters.AddWithValue("@puhelin", Values.Item3);
                con.Open();
             //   int i = cmd.ExecuteNonQuery();
                int id = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = @"INSERT into ProjektiHenkilot(Henkilo_Id, Projekti_Id) values(@id,@projId);
                                    INSERT into ProjektiTehtavat(Henkilo_Id, Projekti_Id, Tehtava_Id) values(@id,@projId, @tehtId)";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@projId", Values.Item4);
                cmd.Parameters.AddWithValue("@tehtId", Values.Item5);

                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Lisäys tietokantaan onnistui!");
                }

                RefreshListViewHenkilot();
                confirmation = false;

            }    
        }
        private void ProjektiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var Values = ShowDialog("Uusi Projekti", "Nimi", "Aloitus Päivämäärä", "Loppu Päivämäärä");

            if(confirmation == false)
            {
                return;
            }
            else if (string.IsNullOrWhiteSpace(Values.Item1) || string.IsNullOrWhiteSpace(Values.Item2) || string.IsNullOrWhiteSpace(Values.Item3))
            {
                confirmation = false;
                MessageBox.Show("Arvo/arvoja puuttuu!");
            }
            if (confirmation == true)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("insert into ProjektiTiedot(ProjektiNimi,ProjektiAlkupvm,ProjektiLoppuPvm) values(@name,@email,@puhelin)", con);
                //  cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", Values.Item1);
                cmd.Parameters.AddWithValue("@email", Values.Item2);
                cmd.Parameters.AddWithValue("@puhelin", Values.Item3);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Lisäys tietokantaan onnistui!");
                    RefreshListViewProjektit();
                }
                confirmation = false;
            }

        }

        private void TehtavaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var Values = ShowDialog("Uusi Tehtava", "Tehtävä Tyyppi", "", "");

            if (confirmation == false)
            {
                return;
            }
            else if (string.IsNullOrWhiteSpace(Values.Item1))
            {
                confirmation = false;
                MessageBox.Show("Arvo/arvoja puuttuu!");
            }

            if (confirmation == true)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("insert into Tehtavat(TehtavaTyyppi) values(@name)", con);
                //  cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", Values.Item1);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Lisäys tietokantaan onnistui!");
                    RefreshListViewTehtavat();
                }
                confirmation = false;
            }
        }

        public (string,string,string, int, int) ShowDialog( string caption, string text0, string text1, string text2)
        {
            string value1 = "", value2 = "";
            int key = 0, key2 = 0;

            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 250;
            prompt.Text = caption;
         
                
            Label textLabel0 = new Label() { Left = 50, Top = 20, Text = text0 };
            Label textLabel1 = new Label() { Left = 50, Top = 80, Text = text1 };
            Label textLabel2 = new Label() { Left = 50, Top = 140, Text = text2 };
                // NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 100 };
            TextBox textBox0 = new TextBox() { Left = 50, Top = 50, Width = 100 };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 150 };
            confirmation.Click += new EventHandler(Confirmation_Click);
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel0);
            prompt.Controls.Add(textLabel1);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(textBox0);

            if (caption.Equals("Uusi Henkilo"))
            {
                TextBox textBox1 = new TextBox() { Left = 50, Top = 105, Width = 100 };
                TextBox textBox2 = new TextBox() { Left = 50, Top = 165, Width = 100 };
                ComboBox comboBox = new ComboBox() { Left = 350, Top = 50, Width = 100 };
                ComboBox comboBoxTeht = new ComboBox() { Left = 350, Top = 105, Width = 100 };

                comboBoxTeht.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;


                prompt.Controls.Add(textBox1);
                prompt.Controls.Add(textBox2);
                prompt.Controls.Add(comboBox);
                prompt.Controls.Add(comboBoxTeht);

                Dictionary<int, string> comboSourceb = new Dictionary<int, string>();
                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                foreach (ListViewItem itemb in listViewTehtavat.Items)
                {
                    comboSourceb.Add(Int32.Parse(itemb.SubItems[0].Text), itemb.SubItems[1].Text);

                }
                comboBoxTeht.DataSource = new BindingSource(comboSourceb, null);
                comboBoxTeht.DisplayMember = "Value";
                comboBoxTeht.ValueMember = "Key";

                

                foreach (ListViewItem item in listViewProjektit.Items)
                {
                    comboSource.Add(Int32.Parse(item.SubItems[0].Text), item.SubItems[1].Text);
                    
                }
                comboBox.DataSource = new BindingSource(comboSource, null);
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";

                prompt.ShowDialog();

                value1 = textBox1.Text;
                value2 = textBox2.Text;
                key = ((KeyValuePair<int, string>)comboBox.SelectedItem).Key;
                key2 = ((KeyValuePair<int, string>)comboBoxTeht.SelectedItem).Key;
            }
            else if (caption.Equals("Uusi Projekti"))
            {
                DateTimePicker dateTimePicker0 = new DateTimePicker() { Left = 50, Top = 105, Width = 140 };
                DateTimePicker dateTimePicker1 = new DateTimePicker() { Left = 50, Top = 165, Width = 140 };
                prompt.Controls.Add(dateTimePicker0);
                prompt.Controls.Add(dateTimePicker1);
                prompt.ShowDialog();
                value1 = dateTimePicker0.Text;
                value2 = dateTimePicker1.Text;
            }
            else if (caption.Equals("Uusi Tehtava"))
            {
                prompt.ShowDialog();
            }

            // prompt.Controls.Add(inputBox);

            //int id = (int)inputBox.Value;


            string value0 = textBox0.Text;

     

            return (value0, value1, value2, key, key2);
        }
        private void Confirmation_Click(object sender, EventArgs e)
        {
            confirmation = true;
        
        }
        private void tabPageHenkilo_Click(object sender, EventArgs e)
        {

        }

        private void listBoxHenkilo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewProjektit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewProjektit.SelectedItems.Count == 0)
                return;

            item = listViewProjektit.SelectedItems[0];
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void listViewHenkilot_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewHenkilot.SelectedItems.Count == 0)
                return;

             item = listViewHenkilot.SelectedItems[0];
      

        }
        private void listViewTehtavat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTehtavat.SelectedItems.Count == 0)
                return;

            item = listViewTehtavat.SelectedItems[0];
        }



        private void SetListViews()
        {
            listViewHenkilot.View = View.Details;
            listViewHenkilot.GridLines = true;
            listViewHenkilot.FullRowSelect = true;

            listViewTehtavat.View = View.Details;
            listViewTehtavat.GridLines = true;
            listViewTehtavat.FullRowSelect = true;
            listViewProjektit.View = View.Details;
            listViewProjektit.GridLines = true;
            listViewProjektit.FullRowSelect = true;


            listViewProjektit.Columns.Add("ID", 100);
            listViewProjektit.Columns.Add("Nimi", 100);
            listViewProjektit.Columns.Add("Alku Pvm", 100);
            listViewProjektit.Columns.Add("Loppu Pvm", 100);

            listViewTehtavat.Columns.Add("ID", 100);
            listViewTehtavat.Columns.Add("Tehtava Tyyppi", 100);

            listViewHenkilot.Columns.Add("ID", 100);
            listViewHenkilot.Columns.Add("Nimi", 100);
            listViewHenkilot.Columns.Add("Email", 100);
            listViewHenkilot.Columns.Add("Puhelin", 100);
            listViewHenkilot.Columns.Add("Projekti", 100);
            listViewHenkilot.Columns.Add("Tehtävä", 100);
        }

        private void poistaBtn_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(@"DELETE FROM ProjektiTehtavat WHERE Henkilo_Id = @id;
                                                  DELETE FROM ProjektiHenkilot WHERE Henkilo_Id = @id; DELETE FROM HenkiloTiedot WHERE Henkilo_Id = @id", con);
                cmd.Parameters.AddWithValue("@id", item.SubItems[0].Text);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    RefreshListViewHenkilot();
                    MessageBox.Show("Poisto onnistui!");

                }
            }
            else
            {
                MessageBox.Show("Valitse poistettava kohde!");
            }
        }

        private void poistaProjBtn_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand($"DELETE FROM ProjektiTehtavat WHERE Projekti_Id = @id;DELETE FROM ProjektiHenkilot WHERE Projekti_Id = @id;DELETE FROM ProjektiTiedot WHERE Projekti_Id = @id", con);
                cmd.Parameters.AddWithValue("@id", item.SubItems[0].Text);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    RefreshListViewHenkilot();
                    RefreshListViewTehtavat();
                    RefreshListViewProjektit();
                    MessageBox.Show("Poisto onnistui!");

                }
            }
            else
            {
                MessageBox.Show("Valitse poistettava kohde!");
            }
        }

        private void poistaTehtavatBtn_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand($"DELETE FROM ProjektiTehtavat WHERE Tehtava_Id = @id;DELETE FROM Tehtavat WHERE Tehtava_Id = @id", con);
                cmd.Parameters.AddWithValue("@id", item.SubItems[0].Text);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    RefreshListViewTehtavat();
                    MessageBox.Show("Poisto onnistui!");

                }
            }
            else
            {
                 MessageBox.Show("Valitse poistettava kohde!");
            }
        }

        private void etsiNimiButton_Click(object sender, EventArgs e)
        {
            // Call FindItemWithText, sending output to MessageBox.
            ListViewItem item1 = listViewHenkilot.FindItemWithText(henkiloTextBox.Text);
            if (item1 != null)
            {
                listViewHenkilot.SelectedItems.Clear();
                item1.Selected = true;
                item1.Focused = true;
                item1.EnsureVisible();
                listViewHenkilot.Select();
            }
            else
            {
                MessageBox.Show("Ei loytynyt!");
            }
        }

        private void etsiProjektiBtn_Click(object sender, EventArgs e)
        {
            ListViewItem item1 = listViewProjektit.FindItemWithText(projektiTextBox.Text);
            if (item1 != null)
            {
                listViewProjektit.SelectedItems.Clear();
                item1.Selected = true;
                item1.Focused = true;
                item1.EnsureVisible();
                listViewProjektit.Select();
            }
            else
            {
                MessageBox.Show("Ei loytynyt!");
            }
        }

        private void tehtavaBtn_Click(object sender, EventArgs e)
        {
            ListViewItem item1 = listViewTehtavat.FindItemWithText(tehtavaTextBox.Text);
            if (item1 != null)
            {
                listViewTehtavat.SelectedItems.Clear();
                item1.Selected = true;
                item1.Focused = true;
                item1.EnsureVisible();
                listViewTehtavat.Select();
            }
            else
            {
                MessageBox.Show("Ei loytynyt!");
            }
        }

        private void henkiloMuokkaaBtn_Click(object sender, EventArgs e)
        {
            if (listViewHenkilot.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewHenkilot.SelectedItems[0];
                int id = Int32.Parse(item.Text);

                var Values = ShowMuokkaaDialog("Muokkaa Henkiloa", "Nimi", "Email", "Puhelin Numero", item);

                if (confirmation == false)
                {
                    return;
                }
                else if (string.IsNullOrWhiteSpace(Values.Item1) || string.IsNullOrWhiteSpace(Values.Item2) || string.IsNullOrWhiteSpace(Values.Item3))
                {
                    confirmation = false;
                    MessageBox.Show("Arvo/arvoja puuttuu!");
                }

                if (confirmation == true)
                {

                    SqlConnection con = new SqlConnection(conString);

                    SqlCommand cmd = new SqlCommand("SELECT count(*) from ProjektiHenkilot WHERE Henkilo_Id = @id", con);
                    
                    
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", Values.Item1);
                    cmd.Parameters.AddWithValue("@email", Values.Item2);
                    cmd.Parameters.AddWithValue("@puhelin", Values.Item3);
                    cmd.Parameters.AddWithValue("@pId", Values.Item4);
                    cmd.Parameters.AddWithValue("@tId", Values.Item5);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // UPDATE
                        cmd.CommandText = @"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                            UPDATE ProjektiHenkilot SET Projekti_Id = @pId WHERE Henkilo_Id = @id;";
                     
                        /* SqlCommand cmd = new SqlCommand(@"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                                      INSERT INTO ProjektiHenkilot (Henkilo_Id, Projekti_Id) VALUES (@id, @pId) ON DUPLICATE KEY UPDATE
                                                        Projekti_Id = @pId, Henkilo_Id = @id", con);*/
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                            INSERT INTO ProjektiHenkilot(Henkilo_Id, Projekti_Id) VALUES(@id, @pId);";
                    }

                    cmd.CommandText = "SELECT count(*) from ProjektiTehtavat WHERE Henkilo_Id = @id";

                    count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // UPDATE
                        cmd.CommandText = @"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                            UPDATE ProjektiTehtavat SET Projekti_Id = @pId, Tehtava_Id = @tId WHERE Henkilo_Id = @id;";


                        /* SqlCommand cmd = new SqlCommand(@"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                                      INSERT INTO ProjektiHenkilot (Henkilo_Id, Projekti_Id) VALUES (@id, @pId) ON DUPLICATE KEY UPDATE
                                                        Projekti_Id = @pId, Henkilo_Id = @id", con);*/
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE HenkiloTiedot SET Nimi = @name, Email = @email, Puhelin = @puhelin WHERE Henkilo_Id = @id;
                                            INSERT INTO ProjektiTehtavat(Henkilo_Id, Projekti_Id, Tehtava_Id) VALUES(@id, @pId, @tId)";
                    }



                    Debug.WriteLine(Values.Item4);
                    Debug.WriteLine(id);


                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i != 0)
                    {
                        RefreshListViewHenkilot();
                        MessageBox.Show("Muokkaus onnistui!");
                    }
                    confirmation = false;
                }
            }
            else
            {
                MessageBox.Show("Ei valittu muokattavaa tietoa!");
            }
        }

        private void projektiMuokkaaBtn_Click(object sender, EventArgs e)
        {
            if (listViewProjektit.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewProjektit.SelectedItems[0];
                int id = Int32.Parse(item.Text);

                var Values = ShowMuokkaaDialog("Muokkaa Projektia", "Nimi", "Aloitus Päivämäärä", "Loppu Päivämäärä", item);

                if (confirmation == false)
                {
                    return;
                }
                else if (string.IsNullOrWhiteSpace(Values.Item1) || string.IsNullOrWhiteSpace(Values.Item2) || string.IsNullOrWhiteSpace(Values.Item3))
                {
                    confirmation = false;
                    MessageBox.Show("Arvo/arvoja puuttuu!");
                }
                if (confirmation == true)
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("UPDATE ProjektiTiedot SET ProjektiNimi = @name, ProjektiAlkuPvm = @apvm, ProjektiLoppuPvm = @lpvm WHERE Projekti_Id = @id", con);
                    cmd.Parameters.AddWithValue("@name", Values.Item1);
                    cmd.Parameters.AddWithValue("@apvm", Values.Item2);
                    cmd.Parameters.AddWithValue("@lpvm", Values.Item3);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i != 0)
                    {
                        RefreshListViewProjektit();
                        MessageBox.Show("Muokkaus onnistui!");
                    }
                    confirmation = false;
                }
            }
            else
            {
                MessageBox.Show("Ei valittu muokattavaa tietoa!");
            }
        }

        private void tehtavaMuokkaaBtn_Click(object sender, EventArgs e)
        {
            if (listViewTehtavat.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewTehtavat.SelectedItems[0];
                int id = Int32.Parse(item.Text);

                var Values = ShowMuokkaaDialog("Muokkaa Tehtavaa", "Tehtävä tyyppi", "", "", item);


                if (confirmation == false)
                {
                    return;
                }
                else if (string.IsNullOrWhiteSpace(Values.Item1))
                {
                    confirmation = false;
                    MessageBox.Show("Arvo/arvoja puuttuu!");
                }

                if (confirmation == true)
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("UPDATE Tehtavat SET TehtavaTyyppi = @name WHERE Tehtava_Id = @id", con);
                    cmd.Parameters.AddWithValue("@name", Values.Item1);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i != 0)
                    {
                        RefreshListViewTehtavat();
                        MessageBox.Show("Muokkaus onnistui!");
                    }
                    confirmation = false;
                }
            }
            else
            {
                MessageBox.Show("Ei valittu muokattavaa tietoa!");
            }
        }
        public (string, string, string, int, int) ShowMuokkaaDialog(string caption, string text0, string text1, string text2, ListViewItem item)
        {
            string value1 = "", value2 = "";
            int key = 0, key2 = 0;

            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 250;
            prompt.Text = caption;


            Label textLabel0 = new Label() { Left = 50, Top = 20, Text = text0 };
            Label textLabel1 = new Label() { Left = 50, Top = 80, Text = text1 };
            Label textLabel2 = new Label() { Left = 50, Top = 140, Text = text2 };
            // NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 100 };
            TextBox textBox0 = new TextBox() { Left = 50, Top = 50, Width = 100, Text = item.SubItems[1].Text };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 150 };
            confirmation.Click += new EventHandler(Confirmation_Click);
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel0);
            prompt.Controls.Add(textLabel1);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(textBox0);

            if (caption.Equals("Muokkaa Henkiloa"))
            {
                
                TextBox textBox1 = new TextBox() { Left = 50, Top = 105, Width = 100, Text = item.SubItems[2].Text };
                TextBox textBox2 = new TextBox() { Left = 50, Top = 165, Width = 100, Text = item.SubItems[3].Text };
                prompt.Controls.Add(textBox1);
                prompt.Controls.Add(textBox2);

                ComboBox comboBox = new ComboBox() { Left = 350, Top = 50, Width = 100 };
                ComboBox comboBoxTeht = new ComboBox() { Left = 350, Top = 105, Width = 100 };

                comboBoxTeht.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;


                prompt.Controls.Add(textBox1);
                prompt.Controls.Add(textBox2);
                prompt.Controls.Add(comboBox);
                prompt.Controls.Add(comboBoxTeht);

                Dictionary<int, string> comboSourceb = new Dictionary<int, string>();
                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                if (listViewTehtavat.Items.Count > 0)
                {
                    foreach (ListViewItem itemb in listViewTehtavat.Items)
                    {
                        comboSourceb.Add(Int32.Parse(itemb.SubItems[0].Text), itemb.SubItems[1].Text);

                    }
                    comboBoxTeht.DataSource = new BindingSource(comboSourceb, null);
                    comboBoxTeht.DisplayMember = "Value";
                    comboBoxTeht.ValueMember = "Key";
                }



                if (listViewProjektit.Items.Count > 0)
                {
                    foreach (ListViewItem itema in listViewProjektit.Items)
                    {
                        comboSource.Add(Int32.Parse(itema.SubItems[0].Text), itema.SubItems[1].Text);

                    }
                    comboBox.DataSource = new BindingSource(comboSource, null);
                    comboBox.DisplayMember = "Value";
                    comboBox.ValueMember = "Key";
                }

                prompt.ShowDialog();

                value1 = textBox1.Text;
                value2 = textBox2.Text;
                key = ((KeyValuePair<int, string>)comboBox.SelectedItem).Key;
                key2 = ((KeyValuePair<int, string>)comboBoxTeht.SelectedItem).Key;
            }
            else if (caption.Equals("Muokkaa Projektia"))
            {
                DateTimePicker dateTimePicker0 = new DateTimePicker() { Left = 50, Top = 105, Width = 140 };
                DateTimePicker dateTimePicker1 = new DateTimePicker() { Left = 50, Top = 165, Width = 140 };
                prompt.Controls.Add(dateTimePicker0);
                prompt.Controls.Add(dateTimePicker1);
                prompt.ShowDialog();
                value1 = dateTimePicker0.Text;
                value2 = dateTimePicker1.Text;
            }
            else if (caption.Equals("Muokkaa Tehtavaa"))
            {
                prompt.ShowDialog();
            }

            // prompt.Controls.Add(inputBox);

            //int id = (int)inputBox.Value;
            string value0 = textBox0.Text;
            

            return (value0, value1, value2, key, key2);
        }

        private void henkiloTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                etsiNimiButton_Click(this, new EventArgs());
            }
        }

        private void projektiTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                etsiProjektiBtn_Click(this, new EventArgs());
            }
        }

        private void tehtavaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tehtavaBtn_Click(this, new EventArgs());
            }
        }
    }

}
