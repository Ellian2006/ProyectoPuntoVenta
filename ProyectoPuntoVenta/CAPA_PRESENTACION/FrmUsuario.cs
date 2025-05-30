using ProyectoPuntoVenta.CAPA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta.CAPA_PRESENTACION
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        //metodo para listar
        private void listar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Usuario.listar();
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
            dataCategoria.Columns[2].Visible = false;
            dataCategoria.Columns[1].Width = 50;
            dataCategoria.Columns[3].Width = 150;
            dataCategoria.Columns[4].Width = 170;
            dataCategoria.Columns[5].Width = 100;
            dataCategoria.Columns[5].HeaderText = "Documento";
            dataCategoria.Columns[6].Width = 100;
            dataCategoria.Columns[6].HeaderText = "Numero Doc";
            dataCategoria.Columns[7].Width = 150;
            dataCategoria.Columns[7].HeaderText = "Direccion";
            dataCategoria.Columns[8].Width = 100;
            dataCategoria.Columns[8].HeaderText = "Telefono";
            dataCategoria.Columns[9].Width = 100;
        }
        private void buscar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Usuario.Buscar(txtBuscar.Text);
                lblTotal.Text = "Total registros :" + Convert.ToString(dataCategoria.Rows.Count);
                this.formato();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //metodo para limpiar
        private void limpiar()
        {
            
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtNumDoc.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtClave.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            errorProvider1.Clear(); //quitamos el mensaje del errorProvider

            dataCategoria.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;

        }
        //metodo para cargar los roles en el cuadro combinado
        private void CargarRol() 
        {
            try
            {
                cmbRol.DataSource = Negocios_Rol.listar();
                cmbRol.ValueMember = "idrol";
                cmbRol.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.listar();
            this.CargarRol();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }
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

                // Validamos los campos vacíos
                if ((cmbRol.Text == string.Empty) || (txtNombre.Text == string.Empty) ||
                    (txtEmail.Text == string.Empty) || (txtClave.Text == string.Empty))
                {
                    this.mensajeError("Falta el ingreso de datos al registro de Usuario. Se le indicará el campo faltante.");
                    errorProvider1.SetError(cmbRol, "Seleccione el rol" );
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre del artículo");
                    errorProvider1.SetError(txtEmail, "Ingrese el Email");
                    errorProvider1.SetError(txtClave, "Ingrese la Clave");
                }
                else
                {
                    respuesta = Negocios_Usuario.Insertar(
                        Convert.ToInt32(cmbRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cmbTipoDoc.Text,
                        txtNumDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim()
                    );

                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Se inserto registrado del usuario correctamente");
                        this.limpiar();
                        this.listar();
                    }
                    else
                    {
                        this.mensajeError(respuesta);
                        txtNombre.Clear();
                        txtNombre.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }
        private string Emailant;

        private void dataCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["ID"].Value);
                cmbRol.SelectedValue = Convert.ToString(dataCategoria.CurrentRow.Cells["Idrol"].Value);
                txtNombre.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Nombre"].Value);
                cmbTipoDoc.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Tipo_Documento"].Value);
                txtNumDoc.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Num_Documento"].Value);
                txtDireccion.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Direccion"].Value);
                txtTelefono.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Telefono"].Value);
                this.Emailant = Convert.ToString(dataCategoria.CurrentRow.Cells["Email"].Value);
                txtEmail.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Email"].Value);
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda Nombre del Usuario" + "|Error:" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                // Validamos los campos vacíos
                if ((txtId.Text == string.Empty) || (cmbRol.Text == string.Empty) || (txtNombre.Text == string.Empty) ||
                    (txtEmail.Text == string.Empty))
                {
                    this.mensajeError("Falta el ingreso de datos al registro de Usuario. Se le indicará el campo faltante.");
                    errorProvider1.SetError(cmbRol, "Seleccione el rol");
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre del artículo");
                    errorProvider1.SetError(txtEmail, "Ingrese el Email");
                }
                else
                {
                    respuesta = Negocios_Usuario.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        Convert.ToInt32(cmbRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cmbTipoDoc.Text,
                        txtNumDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        this.Emailant, // Email anterior para verificar si ha cambiado
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim()
                    );

                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Se Actualizo registrado del usuario correctamente");
                        this.limpiar();
                        tabControl1.SelectedIndex = 0; 
                        this.listar();
                    }
                    else
                    {
                        this.mensajeError(respuesta);
                        txtNombre.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSeleccionar.Checked)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            tabControl1.SelectedIndex = 0;
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
                            respuesta = Negocios_Usuario.Eliminar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                    this.mensajeCorrecto("Se elimino el registro : " + Convert.ToString(fila.Cells[4].Value));

                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
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
                            respuesta = Negocios_Usuario.Activar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                this.mensajeCorrecto("Se activo el registro : " + Convert.ToString(fila.Cells[4].Value));
                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
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
                            respuesta = Negocios_Usuario.Desactivar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                this.mensajeCorrecto("Se desactivo el registro :" + Convert.ToString(fila.Cells[4].Value));
                            }
                            else
                            {
                                this.mensajeError(respuesta);
                            }
                        }
                    }
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

