using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_de_datos_conexion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool nuevo;
        

        private void CargarDataGrid()
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ESCUELA;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);



            string query = "Select * from Alumnos";
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();
        }

        private void Activar()
        {
            btnFind.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
            btnDel.Enabled = true;

            txtNoControl.Enabled = false;
            txtNombre.Enabled = true;
            txtAmaterno.Enabled = true;
            txtApaterno.Enabled = true;
        }

        private void Inactivar()
        {
            btnFind.Enabled = true;
            btnNew.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;

            txtNoControl.Text = "";
            txtNombre.Text = "";
            txtAmaterno.Text = "";
            txtApaterno.Text = "";

            txtNoControl.Enabled = true;
            txtNombre.Enabled = false;
            txtAmaterno.Enabled = false;
            txtApaterno.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

                btnNew.Enabled = true;
                btnFind.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnDel.Enabled = false;
                btnUpdate.Enabled = false;

                txtNoControl.Enabled = true;
                txtNombre.Enabled = false;
                txtAmaterno.Enabled = false;
                txtApaterno.Enabled = false;

                CargarDataGrid();

            
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            Inactivar();
            txtNoControl.Enabled = true;
            txtNombre.Enabled = true;
            txtApaterno.Enabled = true;
            txtAmaterno.Enabled = true;
            txtNoControl.Focus();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Inactivar();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ESCUELA;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "INSERT INTO Alumnos (no_control, nombre, apaterno, amaterno)" + "VALUES ('" + txtNoControl.Text + "', '" + txtNombre.Text + "', '" + txtApaterno.Text + "', '" + txtAmaterno.Text + "')";
            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ESCUELA;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "DELETE FROM Alumnos WHERE no_control= " + txtNoControl.Text;
            //"' where no_control= " + txtNoControl.Text;

            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            string conexionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True";
            SqlConnection conexion;

            conexion = new SqlConnection(conexionString);

            SqlCommand comando;

            SqlDataReader dataReader;

            string query = "SELECT * FROM Alumnos WHERE no_control=" + txtNoControl.Text;
            conexion.Open();
            comando = new SqlCommand(query, conexion); try
            {
                dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnDel.Enabled = true;
                    btnFind.Enabled = false;
                    btnUpdate.Enabled = true;

                    txtNoControl.Enabled = false;
                    txtNombre.Enabled = true;
                    txtApaterno.Enabled = true;
                    txtAmaterno.Enabled = true;

                    //txtNoControl.Focus();
                    txtNoControl.Text = dataReader[0].ToString();
                    txtNombre.Text = dataReader[1].ToString();
                    txtApaterno.Text = dataReader[2].ToString();
                    txtAmaterno.Text = dataReader[3].ToString();
                    nuevo = false;
                }
                else
                    MessageBox.Show("No se encontro registro !");

                //MessageBox.Show(datos);

                comando.Dispose();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ESCUELA;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "UPDATE Alumnos set nombre ='" + txtNombre.Text + "' , apaterno ='" + txtApaterno.Text + "', amaterno='" + txtAmaterno.Text + "' where no_control= " + txtNoControl.Text;

            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();
                nuevo = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }






 
        



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            txtNoControl.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtApaterno.Text = row.Cells[2].Value.ToString();
            txtAmaterno.Text = row.Cells[3].Value.ToString();
            Activar();
        }
    }
}
