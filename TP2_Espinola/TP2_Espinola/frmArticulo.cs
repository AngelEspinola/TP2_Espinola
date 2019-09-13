using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP2_Espinola
{
    public partial class frmArticulo : Form
    {
        public frmArticulo()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cbxMarca.SelectedIndex = -1;
            cbxCategoria.SelectedIndex = -1;
            txtPrecio.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevoArt = new Articulo();

                nuevoArt.Codigo = txtCodigo.Text;
                nuevoArt.Nombre = txtNombre.Text;
                nuevoArt.Descripcion = txtDescripcion.Text;
                nuevoArt.Precio = int.Parse(txtPrecio.Text);
                nuevoArt.Marca = new CodigoDescripcion();
                nuevoArt.Marca.Id = cbxMarca.SelectedIndex;
                nuevoArt.Marca.Descripcion = cbxMarca.SelectedText;
                nuevoArt.Categoria = new CodigoDescripcion();
                nuevoArt.Categoria.Id = cbxCategoria.SelectedIndex;
                nuevoArt.Categoria.Descripcion = cbxCategoria.SelectedText;
                nuevoArt.Imagen = "jpg";

                negocio.agregarArticulo(nuevoArt); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
