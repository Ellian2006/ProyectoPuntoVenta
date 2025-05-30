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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //generamos unas instacia para frmCategoria
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //generamos unas instacia para frmCategoria
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //generamos unas instacia para frmArticulos
            frmArticulos frmArticulos = new frmArticulos();
            frmArticulos.MdiParent = this;
            frmArticulos.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //genremos unas instancia para frmRol
            FrmRol frmRol = new FrmRol();
            frmRol.MdiParent = this;
            frmRol.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario Usuario = new FrmUsuario();
            Usuario.MdiParent = this;
            Usuario.Show();
        }
    }
}
