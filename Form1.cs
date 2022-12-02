using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    { private int value;
        public Form1()
        {
            InitializeComponent();
        }


        ////Pour Access----  using System.Data.OleDb;
        //OleDbConnection AccesConnection = new OleDbConnection();
        //OleDbDataAdapter AccesAdapter = new OleDbDataAdapter();
        //String AccesChaineConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\BDAcces.mdb;Persist Security Info=True";

        ////Pour SQL Server----using System.Data.SqlClient;


        ////Pour MySQL-----using MySql.Data.MySqlClient;
        //MySqlConnection MySQLConnection = new MySqlConnection();
        //MySqlDataAdapter MySQLAdapter = new MySqlDataAdapter();
        //String MySQLChaineConnection = "server=localhost; user id=root;password= ;database=BdMySQL";

        ////Pour Oracle---------using System.Data.OracleClient;
        //OracleConnection OracleConnection = new OracleConnection();
        //OracleDataAdapter OracleAdapter = new OracleDataAdapter();
        //String OracleChaineConnection = "Data Source=BdOracle;User Id=hr;Password=hr";//;DBA Privilege=SYSDBA



        static string chaine = @"Data Source=DESKTOP-PQOLN1N\SQLEXPRESS;Initial Catalog=mydatabase;Integrated Security=True";
        //"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\App_Data\VotreBD.mdf;Integrated Security=True;User Instance=True"
        //"Server=.\SQLEXPRESS; DataBase=VotreBD;USER ID=sa; PASSWORD="
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            validate.Enabled=false;
            cancel.Enabled = false;
            txtId_dossier.Enabled = false;
            txtNom_dossier.Enabled=false;
            txtType_dossier.Enabled=false ;
            comboBox1.Enabled = false;

        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
  
            cnx.Close();
            btnInsert.Enabled=false;
            btnUpdate.Enabled=false;
            btnDelete.Enabled=false;
            validate.Enabled= true;
            cancel.Enabled=true;
            button4.Enabled = false;
            txtNom_dossier.Enabled=true;
            txtType_dossier.Enabled=true;
            txtId_dossier.Enabled=true ;
            txtNom_dossier.Clear();
            txtId_dossier.Clear();
            txtType_dossier.Clear();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            value = 2;
            cnx.Open();
            cmd.Connection = cnx;

          
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            validate.Enabled = true;
            cancel.Enabled = true;
            button4.Enabled = false;
            txtNom_dossier.Enabled = true;
            txtType_dossier.Enabled = true;
            txtId_dossier.Enabled = true;
            txtNom_dossier.Clear();
            txtId_dossier.Clear();
            txtType_dossier.Clear();
            cnx.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {  value=3;
            cnx.Open();
            cmd.Connection = cnx;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            validate.Enabled = true;
            cancel.Enabled = true;
            button4.Enabled = false;
            txtNom_dossier.Enabled = true;
            txtType_dossier.Enabled = true;
            txtId_dossier.Enabled = true;
            txtNom_dossier.Clear();
            txtId_dossier.Clear();
            txtType_dossier.Clear();
            cnx.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            value = 1;
            cnx.Open();
            cmd.CommandText = "select * from movie";
            cmd.Connection = cnx;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            button4.Enabled = false;
            validate.Enabled = false;
            cancel.Enabled=false;
            txtId_dossier.Enabled = false;
            txtNom_dossier.Enabled = false;
            txtType_dossier.Enabled = false;
            comboBox1.Enabled = true;
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id_movie";
            txtNom_dossier.DataBindings.Clear();
            txtId_dossier.DataBindings.Clear();
            txtType_dossier.DataBindings.Clear();
            txtNom_dossier.DataBindings.Add("text",comboBox1.DataSource,"nom");
            txtId_dossier.DataBindings.Add("text", comboBox1.DataSource, "id_movie");
            txtType_dossier.DataBindings.Add("text", comboBox1.DataSource, "type");
            cnx.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void validate_Click(object sender, EventArgs e)
        {
            if (value == 1) {
                cnx.Open();
                cmd.Connection = cnx;
                if (txtId_dossier.Text == "" || txtNom_dossier.Text == "" || txtType_dossier.Text == "")
                { MessageBox.Show("motherfucker enter the inputs"); }
                else
                {
                    cmd.CommandText = "insert into movie(id_movie, nom,type) values('" + txtId_dossier.Text + "','" + txtNom_dossier.Text + "','" + txtType_dossier.Text + "') ";
                    cmd.ExecuteNonQuery();
                    button4.Enabled = true;
                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    validate.Enabled = false;
                    cancel.Enabled = false;
                    txtId_dossier.Enabled = false;
                    txtNom_dossier.Enabled = false;
                    txtType_dossier.Enabled = false;
                    comboBox1.Enabled = false;
                }
            }
            else if (value == 2)
            {
                if (txtId_dossier.Text == "" || txtNom_dossier.Text == "" || txtType_dossier.Text == "")
                { MessageBox.Show("motherfucker enter the inputs"); }
                else
                {
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.CommandText = "update movie set nom ='" + txtNom_dossier.Text + "', type ='" + txtType_dossier.Text + "' where id_movie='" + txtId_dossier.Text + "' ";
                    cmd.ExecuteNonQuery();
                    button4.Enabled = true;
                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    validate.Enabled = false;
                    cancel.Enabled = false;
                    txtId_dossier.Enabled = false;
                    txtNom_dossier.Enabled = false;
                    txtType_dossier.Enabled = false;
                    comboBox1.Enabled = false;
                    cnx.Close();
                }
            }
            else if (value == 3)
            {
                if (txtId_dossier.Text == "" || txtNom_dossier.Text == "" || txtType_dossier.Text == "")
                { MessageBox.Show(" enter the inputs"); }
                else
                {
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.CommandText = "delete from movie where id_movie='" + txtId_dossier.Text + "' ";
                    cmd.ExecuteNonQuery();
                    button4.Enabled = true;
                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    validate.Enabled = false;
                    cancel.Enabled = false;
                    txtId_dossier.Enabled = false;
                    txtNom_dossier.Enabled = false;
                    txtType_dossier.Enabled = false;
                    comboBox1.Enabled = false;
                    cnx.Close();
                }
            }


        }

        private void cancel_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            validate.Enabled = false;
            cancel.Enabled = false;
            txtId_dossier.Enabled = false;
            txtNom_dossier.Enabled = false;
            txtType_dossier.Enabled = false;
            comboBox1.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
