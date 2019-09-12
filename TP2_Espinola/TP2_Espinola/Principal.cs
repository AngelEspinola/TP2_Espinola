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
        List<Articulo> listapersonas = new List<Articulo>();

        public Principal()
        {
            InitializeComponent();
        }
    
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            frmArticulo nuevoFrm = new frmArticulo();
            nuevoFrm.Show();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            frmArticulo nuevoFrm = new frmArticulo();
            nuevoFrm.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulos = new ArticuloNegocio();
            dgv_listaArticulos.DataSource = articulos.listarArticulos();
        }
    }
}
