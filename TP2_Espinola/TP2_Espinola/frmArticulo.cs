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
                    cbxCategoria.SelectedIndex = cbxCategoria.FindString(articuloLocal.Categoria.Descripcion);
                    cbxMarca.SelectedIndex = cbxMarca.FindString(articuloLocal.Marca.Descripcion);
                    //cbxMarca.SelectedText = articuloLocal.Marca.Descripcion;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                if(articuloLocal == null)
                {
                    articuloLocal = new Articulo();
                }

                articuloLocal.Codigo = txtCodigo.Text;
                articuloLocal.Nombre = txtNombre.Text;
                articuloLocal.Descripcion = txtDescripcion.Text;
                articuloLocal.Precio = decimal.Parse(txtPrecio.Text);
                articuloLocal.Marca = new CodigoDescripcion();
                articuloLocal.Marca.Id = ((CodigoDescripcion)cbxMarca.SelectedItem).Id;
                articuloLocal.Marca.Descripcion = ((CodigoDescripcion)cbxMarca.SelectedItem).Descripcion;
                articuloLocal.Categoria = new CodigoDescripcion();
                articuloLocal.Categoria.Id = ((CodigoDescripcion)cbxCategoria.SelectedItem).Id;
                articuloLocal.Categoria.Descripcion = ((CodigoDescripcion)cbxCategoria.SelectedItem).Descripcion;
                articuloLocal.Imagen = "jpg";

                if (articuloLocal.Id != 0)
                {
                    negocio.modificarArticulo(articuloLocal);
                }
                else
                {
                    negocio.agregarArticulo(articuloLocal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
