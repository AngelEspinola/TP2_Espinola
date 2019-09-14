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
        CodigoDescripcionNegocio codDesc;
        private Articulo articuloLocal = null;
        public frmArticulo()
        {
            InitializeComponent();
        }
        public frmArticulo(Articulo articulo)
        {
            InitializeComponent();
            articuloLocal = articulo;
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
                nuevoArt.Marca.Id = ((CodigoDescripcion)cbxMarca.SelectedItem).Id;
                nuevoArt.Marca.Descripcion = ((CodigoDescripcion)cbxMarca.SelectedItem).Descripcion;
                nuevoArt.Categoria = new CodigoDescripcion();
                nuevoArt.Categoria.Id = ((CodigoDescripcion)cbxCategoria.SelectedItem).Id;
                nuevoArt.Categoria.Descripcion = ((CodigoDescripcion)cbxCategoria.SelectedItem).Descripcion;
                nuevoArt.Imagen = "jpg";

                negocio.agregarArticulo(nuevoArt); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            codDesc = new CodigoDescripcionNegocio();
            try
            {
                cbxCategoria.DataSource = codDesc.listarCodigoDescripcion("Categorias");
                cbxCategoria.SelectedIndex = -1;
                cbxMarca.DataSource = codDesc.listarCodigoDescripcion("Marcas");
                cbxMarca.SelectedIndex = -1;
                if(articuloLocal != null)
                {
                    txtCodigo.Text = articuloLocal.Codigo;
                    txtDescripcion.Text = articuloLocal.Descripcion;
                    txtNombre.Text = articuloLocal.Nombre;
                    txtPrecio.Text = articuloLocal.Precio.ToString();
                    cbxCategoria.SelectedIndex = cbxCategoria.Items.IndexOf(articuloLocal.Categoria.Id);
                    //cbxMarca.SelectedText = articuloLocal.Marca.Descripcion;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
