using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio;
using AccesoDatos;
using Negocio;

namespace TP2_Espinola
{
    public partial class Principal : Form
    {
        List<Articulo> listaArticulos = new List<Articulo>();

        public Principal()
        {
            InitializeComponent();
        }
    
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            frmArticulo nuevoFrm = new frmArticulo();
            nuevoFrm.ShowDialog();
            cargarGrilla();
            filtrarGrilla();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            frmArticulo nuevoFrm = new frmArticulo((Articulo)dgv_listaArticulos.CurrentRow.DataBoundItem);
            nuevoFrm.ShowDialog();
            cargarGrilla();
            filtrarGrilla();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            filtrarGrilla();

        }   
        private void cargarGrilla()
        {
            ArticuloNegocio articulos = new ArticuloNegocio();
            try
            {
                listaArticulos = articulos.listarArticulos();
                dgv_listaArticulos.DataSource = articulos.listarArticulos();
                dgv_listaArticulos.Columns[0].Visible = false;
                dgv_listaArticulos.Columns[6].Visible = false;

                //.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                int id = ((Articulo)dgv_listaArticulos.CurrentRow.DataBoundItem).Id;
                negocio.eliminarArticulo(id);
                cargarGrilla();
                filtrarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
        public void filtrarGrilla()
        {
            if (txtBuscar.Text == "")
            {
                cargarGrilla();
            }
            else
            {
                ArticuloNegocio articulos = new ArticuloNegocio();
                listaArticulos = articulos.listarArticulos();
                if (cbxFiltro.Text == "Codigo")
                {
                    dgv_listaArticulos.DataSource = listaArticulos.FindAll(X => X.Codigo.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                }
                if (cbxFiltro.Text == "Nombre")
                {
                    dgv_listaArticulos.DataSource = listaArticulos.FindAll(X => X.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                }
                if (cbxFiltro.Text == "Descripcion")
                {
                    dgv_listaArticulos.DataSource = listaArticulos.FindAll(X => X.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                }
                if (cbxFiltro.Text == "Marca")
                {
                    dgv_listaArticulos.DataSource = listaArticulos.FindAll(X => X.Marca.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                }
                if (cbxFiltro.Text == "Categoria")
                {
                    dgv_listaArticulos.DataSource = listaArticulos.FindAll(X => X.Categoria.Descripcion.ToUpper().Contains(txtBuscar.Text));
                }
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarGrilla();
        }
    }
}
