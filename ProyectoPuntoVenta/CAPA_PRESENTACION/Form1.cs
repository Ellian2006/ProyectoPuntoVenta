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

namespace ProyectoPuntoVenta
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        //metodo para listar
        private void listar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Categoria.listar();
                lblTotal.Text = "Total registros :" + Convert.ToString(dataCategoria.Rows.Count);
                this.formato();
                this.limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //metodo para darle formato a la tabla del datagridview
        private void formato()
        {
            dataCategoria.Columns[0].Visible = false;
            dataCategoria.Columns[1].Visible = false;
            dataCategoria.Columns[2].Width = 150;
            dataCategoria.Columns[3].Width = 300;
            dataCategoria.Columns[3].HeaderText = "Descripción";
            dataCategoria.Columns[4].Width = 100;
        }
        //metodo para limpiar
        private void limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            errorProvider1.Clear(); //quitamos el mensaje del errorProvider

            dataCategoria.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;

        }
        //metodo para buscar
        private void buscar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Categoria.Buscar(txtBuscar.Text);
                lblTotal.Text = "Total registros :" + Convert.ToString(dataCategoria.Rows.Count);
                this.formato();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            this.listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }
        //metodos para el control de mensajes
        private void mensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Punto de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeCorrecto(string mensaje)
        {
            MessageBox.Show(mensaje, "Punto de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == string.Empty)
                {
                    this.mensajeError("Falta el ingreso de datos a la cartegoria, se le indicara el campo faltante");
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre de la categoria");
                }
                else
                {
                    respuesta = Negocios_Categoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Categoria registrada");
                        this.limpiar();
                        this.listar();
                    }
                    else
                    {
                        this.mensajeError(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
        private string NombreAnt;
        private void dataCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = dataCategoria.CurrentRow.Cells["ID"].Value.ToString();
                this.NombreAnt = dataCategoria.CurrentRow.Cells["Nombre"].Value.ToString();
                txtNombre.Text = dataCategoria.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataCategoria.CurrentRow.Cells["Descripcion"].Value.ToString();
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda Nombre de la categoria");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == string.Empty || txtId.Text == string.Empty)
                {
                    this.mensajeError("Falta el ingreso de datos a la cartegoria, se le indicara el campo faltante");
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre de la categoria");
                }
                else
                {
                    respuesta = Negocios_Categoria.Actualizar(Convert.ToInt32(txtId.Text), this.NombreAnt, txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Se actualizo el registro registrada");
                        this.limpiar();
                        this.listar();
                    }
                    else
                    {
                        this.mensajeError(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked) 
            {
                dataCategoria.Columns[0].Visible = true;
                btnEliminar.Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
            }
            else
            {
                dataCategoria.Columns[0].Visible = false;
                btnEliminar.Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
            }
        }

        private void dataCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataCategoria.Columns["Seleccionar"].Index) 
            {
                DataGridViewCheckBoxCell eliminar = (DataGridViewCheckBoxCell)dataCategoria.Rows[e.RowIndex].Cells["Seleccionar"];
                eliminar.Value = !Convert.ToBoolean(eliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try 
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar los registros seleccionados?", "Punto de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";
                    foreach (DataGridViewRow fila in dataCategoria.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Negocios_Categoria.Eliminar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                this.mensajeCorrecto("Se elimino el registro"+ Convert.ToString(fila.Cells[2].Value));
                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
                    this.limpiar();
                    this.listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea activar los registros seleccionados?", "Punto de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";
                    foreach (DataGridViewRow fila in dataCategoria.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Negocios_Categoria.Activar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                this.mensajeCorrecto("Se activo el registro" + Convert.ToString(fila.Cells[2].Value));
                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
                    this.limpiar();
                    this.listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea desactivar los registros seleccionados?", "Punto de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";
                    foreach (DataGridViewRow fila in dataCategoria.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(fila.Cells[1].Value);
                            respuesta = Negocios_Categoria.Desactivar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                this.mensajeCorrecto("Se desactivo el registro" + Convert.ToString(fila.Cells[2].Value));
                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
                    this.limpiar();
                    this.listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
    
}




