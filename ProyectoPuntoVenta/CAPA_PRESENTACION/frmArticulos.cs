using ProyectoPuntoVenta.CAPA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta.CAPA_PRESENTACION
{
    public partial class frmArticulos : Form
    {
        //declaramos unas variables publicas
        private string rutaOrigen;
        private string rutaDestino;
        private string Directorio = "C:\\Directorio\\";
        private string NombreAnt;
        public frmArticulos()
        {
            InitializeComponent();
        }

        //metodo para listar
        private void listar()
        {
            try
            {
                dataCategoria.DataSource = Negocios_Articulo.listar();
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
            dataCategoria.Columns[0].Width = 100;
            dataCategoria.Columns[1].Width = 50;
            dataCategoria.Columns[2].Visible = false;
            dataCategoria.Columns[3].Width = 100;
            dataCategoria.Columns[3].HeaderText = "Categoria";
            dataCategoria.Columns[4].Width = 100;
            dataCategoria.Columns[4].HeaderText = "Codigo";
            dataCategoria.Columns[5].Width = 150;
            dataCategoria.Columns[6].Width = 100;
            dataCategoria.Columns[6].HeaderText = "Precio Venta";
            dataCategoria.Columns[7].Width = 100;
            dataCategoria.Columns[8].Width = 100;
            dataCategoria.Columns[8].HeaderText = "Descripcion";
            dataCategoria.Columns[9].Width = 100;
        }
        //metodo para limpiar
        private void limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtCodigo.Clear();
            txtImagen.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            pictureBox1.Image = null;
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            errorProvider1.Clear(); //quitamos el mensaje del errorProvider
            btnGuardar.Enabled = false;

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
                dataCategoria.DataSource = Negocios_Articulo.Buscar(txtBuscar.Text);
                lblTotal.Text = "Total registros :" + Convert.ToString(dataCategoria.Rows.Count);
                this.formato();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            this.listar();
            this.CargarCategoria();
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
        //metodo para llenar el cuadro combinado
        private void CargarCategoria()
        {
            try
            {
                cmbCategoria.DataSource = Negocios_Categoria.Seleccionar();
                cmbCategoria.ValueMember = "idcategoria";
                cmbCategoria.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                // Validamos los campos vacíos
                if ((cmbCategoria.Text == string.Empty) || (txtNombre.Text == string.Empty) ||
                    (txtPrecioVenta.Text == string.Empty) || (txtStock.Text == string.Empty))
                {
                    this.mensajeError("Falta el ingreso de datos al registro de Artículos. Se le indicará el campo faltante.");
                    errorProvider1.SetError(cmbCategoria, "Seleccione la categoría");
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre del artículo");
                    errorProvider1.SetError(txtPrecioVenta, "Ingrese el precio de venta");
                    errorProvider1.SetError(txtStock, "Ingrese el stock del artículo");
                }
                else
                {
                    respuesta = Negocios_Articulo.Insertar(
                        Convert.ToInt32(cmbCategoria.SelectedValue),
                        txtCodigo.Text.Trim(),
                        txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecioVenta.Text),
                        Convert.ToInt32(txtStock.Text),
                        txtDescripcion.Text.Trim(),
                        txtImagen.Text.Trim()
                    );

                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Artículo registrado correctamente");

                        // Código para guardar la imagen en el directorio
                        if (txtImagen.Text != string.Empty)
                        {
                            this.rutaDestino = Path.Combine(this.Directorio, txtImagen.Text);

                            if (!File.Exists(this.rutaDestino))
                            {
                                File.Copy(this.rutaOrigen, this.rutaDestino);
                            }
                            else
                            {
                                MessageBox.Show("El archivo ya existe en el directorio. Por favor seleccione otra imagen o cambie el nombre del archivo.",
                                                "Archivo existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog(); // permite mostrar una ventana de cuadroo de dialo para abrir las imagenes 
            //Indicar el tipo de imagenes que vamos a permintir 
            archivo.Filter = "Imagenes (*.jpg; *.png,*jpeg, * jpe,*jfif)|*.jpg; *.png,*jpeg, * jpe,*jfif";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(archivo.FileName); //cargamos la imagen seleccionada
                //Obtener el nombre de la imagen
                txtImagen.Text = archivo.FileName.Substring(archivo.FileName.LastIndexOf("\\") + 1); //guardamos la ruta de la imagen
                this.rutaOrigen = archivo.FileName; //guardamos la ruta de la imagen


            }
        }

        private void dataCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["ID"].Value);
                cmbCategoria.SelectedValue = Convert.ToInt32(dataCategoria.CurrentRow.Cells["IdCategoria"].Value);
                txtCodigo.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt = Convert.ToString(dataCategoria.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Nombre"].Value);
                txtPrecioVenta.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["PrecioVenta"].Value);
                txtStock.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Stock"].Value);
                txtDescripcion.Text = Convert.ToString(dataCategoria.CurrentRow.Cells["Descripcion"].Value);
                string imagen;
                imagen = Convert.ToString(dataCategoria.CurrentRow.Cells["Imagen"].Value);
                if (imagen != string.Empty)
                {
                    pictureBox1.Image = Image.FromFile(this.Directorio + imagen); //"C\Directorio\nombre la de imagen"
                    txtImagen.Text = imagen;
                }
                else
                {
                    pictureBox1.Image = null;
                    txtImagen.Text = "";
                }
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda Nombre del Articulo" + "|Error:" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                //validamos los campos vacios
                if ((txtId.Text == string.Empty) || (cmbCategoria.Text == string.Empty) || (txtNombre.Text == string.Empty) || (txtPrecioVenta.Text == string.Empty) ||
                    (txtStock.Text == string.Empty))
                {
                    this.mensajeError("Falta el ingreso de datos a al registro de Articulos"
                        + " se le indicara el campo faltante");
                    errorProvider1.SetError(cmbCategoria, "Seleccione la categoria");
                    errorProvider1.SetError(txtNombre, "Ingrese el nombre del articulo");
                    errorProvider1.SetError(txtPrecioVenta, "Ingrese el precio de venta");
                    errorProvider1.SetError(txtStock, "Ingrese el stock del articulo");
                }
                else
                {
                    respuesta = Negocios_Articulo.Actualizar(Convert.ToInt32(txtId.Text),Convert.ToInt32(cmbCategoria.SelectedValue), txtCodigo.Text.Trim(),this.NombreAnt, txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecioVenta.Text), Convert.ToInt32(txtStock.Text), txtDescripcion.Text.Trim(), txtImagen.Text.Trim());
                    if (respuesta.Equals("OK"))
                    {
                        this.mensajeCorrecto("Articulo actualizo correctamente");
                        //Codigo para guardar la imagen en el directorio
                        if (txtImagen.Text != string.Empty && this.rutaOrigen != string.Empty)
                        {
                            this.rutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(this.rutaOrigen, this.rutaDestino, true); //copiamos la imagen de la ruta origen a la ruta destino

                        }
                        this.limpiar();
                        this.listar();
                        tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        this.mensajeCorrecto(respuesta);
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

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            //crear un objeto para el codigo de barras 
            BarcodeLib.Barcode codigoB = new BarcodeLib.Barcode();
            codigoB.IncludeLabel = true; //muestra una etiqueta con el nombre del articulo debajo del codigo de barras 
            CodigoBarras.BackgroundImage = codigoB.Encode(BarcodeLib.TYPE.CODE128,txtCodigo.Text, Color.Black,Color.White, 300,100);
            btnGuardar.Enabled = true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)CodigoBarras.BackgroundImage.Clone();
            SaveFileDialog guardarCodigos = new SaveFileDialog();
            guardarCodigos.AddExtension = true;
            guardarCodigos.Filter = "Image PNG(*.png)|*png";
            guardarCodigos.ShowDialog();
            if (string.IsNullOrEmpty(guardarCodigos.FileName))
            {
                imgFinal.Save(guardarCodigos.FileName, ImageFormat.Png);
            }
            //HAY QUE CREAR UNA CARPETA EN EL DISCO C: PARA ALMACENAR LOS CODIGOS DE BARRAS CREADOS 
            imgFinal.Dispose();
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
                    string imagen = "";
                    foreach (DataGridViewRow fila in dataCategoria.Rows)
                    {
                        if (Convert.ToBoolean(fila.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(fila.Cells[1].Value);
                            imagen = Convert.ToString(fila.Cells[9].Value);
                            respuesta = Negocios_Articulo.Eliminar(codigo);
                            if (respuesta.Equals("OK"))
                            {
                                string imagen1 = Convert.ToString(Convert.ToString(dataCategoria.CurrentRow.Cells["imagen"].Value));
                                if (imagen1 == string.Empty)
                                {
                                    this.mensajeCorrecto("Se elimino el registro" + Convert.ToString(fila.Cells[5].Value));
                                }
                                else
                                {
                                    this.mensajeCorrecto("Se elimino el registro" + Convert.ToString(fila.Cells[5].Value));
                                    File.Delete(this.Directorio + imagen);
                                }

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
                            respuesta = Negocios_Articulo.Desactivar(codigo);
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
                            respuesta = Negocios_Articulo.Activar(codigo);
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

