using ProyectoPuntoVenta.CAPA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta.CAPA_PRESENTACION
{
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }
        private void listar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Rol.listar();
                lblTotal.Text = "Total registros :" + Convert.ToString(dataCategoria.Rows.Count);
                this.formato();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void formato()
        {
            dataCategoria.Columns[0].Visible = false;
            dataCategoria.Columns[1].Width = 100;
            dataCategoria.Columns[1].HeaderText  = "ID";
            dataCategoria.Columns[2].Width = 200;
            dataCategoria.Columns[2].HeaderText = "Nombre";
            
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            this.listar();
        }
    }
}
