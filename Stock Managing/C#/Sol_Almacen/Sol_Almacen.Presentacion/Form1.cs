using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Almacen.Presentacion
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "Mis variables"

        int nCodigo_ar = 0;
        int nEstadoguarda = 0;
        int nCodigo_ca = 0;
        int nCodigo_um = 0;

        #endregion

        #region "Mis metodos"

        private void Formato_ar()
        {
            dgv_articulo.Columns[0].Width = 80;
            dgv_articulo.Columns[0].HeaderText = "Código";
            dgv_articulo.Columns[1].Width = 250;
            dgv_articulo.Columns[1].HeaderText = "Articulo";
            dgv_articulo.Columns[2].Width = 150;
            dgv_articulo.Columns[2].HeaderText = "Marca";
            dgv_articulo.Columns[3].Width = 80;
            dgv_articulo.Columns[3].HeaderText = "Medida";
            dgv_articulo.Columns[4].Width = 150;
            dgv_articulo.Columns[4].HeaderText = "Categoria";
            dgv_articulo.Columns[5].Width = 150;
            dgv_articulo.Columns[5].HeaderText = "Stock Actual";
            dgv_articulo.Columns[6].Visible = false;
            dgv_articulo.Columns[7].Visible = false;
        }

        private void Listado_ar(string cTexto)
        {
            D_Articulos Datos = new D_Articulos();
            dgv_articulo.DataSource = Datos.Listado_ar(cTexto);
            this.Formato_ar();
        }

        private void Estado_Texto(bool L_Estado)
        {
            Txt_articulo.ReadOnly = !L_Estado;
            Txt_Marca.ReadOnly = !L_Estado;
            Txt_Stock.ReadOnly = !L_Estado;
        }

        private void Estado_Botones_Procesos(bool L_Estados)
        {
            Btn_lupa_um.Enabled = L_Estados;
            Btn_lupa_ca.Enabled = L_Estados;

            Btn_Cancelar.Visible = L_Estados;
            Btn_Guardar.Visible = L_Estados;

            Txt_Buscar.ReadOnly = L_Estados;
            Btn_Buscar.Enabled = !L_Estados;
            dgv_articulo.Enabled = !L_Estados;

        }

        private void Estado_Botones_Principales(bool L_Estados)
        {
            Btn_Nuevo.Enabled = L_Estados;
            Btn_Eliminar.Enabled = L_Estados;
            Btn_Actualizar.Enabled = L_Estados;
            Btn_Reporte.Enabled = L_Estados;
            Btn_Salir.Enabled = L_Estados;
        }

        private void Limpia_texto()
        {
            Txt_articulo.Text = "";
            Txt_Marca.Text = "";
            Txt_Stock.Text = "0";
            Txt_descripcion_ca.Text = "";
            Txt_Descripcion_um.Text = "";
        }

        private void Selecciona_Item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_articulo.CurrentRow.Cells["codigo_ar"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                 "Aviso del sistema",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            else 
            {

                this.nCodigo_ar = Convert.ToInt32(dgv_articulo.CurrentRow.Cells["codigo_ar"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(dgv_articulo.CurrentRow.Cells["descripcion_ca"].Value);
                Txt_Marca.Text = Convert.ToString(dgv_articulo.CurrentRow.Cells["marca_ar"].Value);
                Txt_Descripcion_um.Text = Convert.ToString(dgv_articulo.CurrentRow.Cells["descripcion_um"].Value);
                Txt_articulo.Text = Convert.ToString(dgv_articulo.CurrentRow.Cells["descripcion_ar"].Value);
                Txt_Stock.Text = Convert.ToString(dgv_articulo.CurrentRow.Cells["stock_actual"].Value);
                this.nCodigo_um = Convert.ToInt32(dgv_articulo.CurrentRow.Cells["codigo_um"].Value);
                this.nCodigo_ca = Convert.ToInt32(dgv_articulo.CurrentRow.Cells["codigo_ca"].Value);

            }

        }

        #endregion

        #region "Metodos medidas y categorias"

        private void Formato_um()
        {
            Dgv_um.Columns[0].Width = 200;
            Dgv_um.Columns[0].HeaderText = "Medidas";
            Dgv_um.Columns[1].Visible = false;
            
        }

        private void Listado_um()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_um.DataSource = Datos.Listado_um();
            this.Formato_um();
        }

        private void Formato_ca()
        {
            Dgv_ca.Columns[0].Width = 200;
            Dgv_ca.Columns[0].HeaderText = "Categorias";
            Dgv_ca.Columns[1].Visible = false;

        }

        private void Listado_ca()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_ca.DataSource = Datos.Listado_ca();
            this.Formato_ca();
        }

        private void Selecciona_Item_um()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_um.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("Selecciona un elemento de la lista",
                                 "Aviso del sistema",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            else
            {

                this.nCodigo_um = Convert.ToInt32(Dgv_um.CurrentRow.Cells["codigo_um"].Value);
                Txt_Descripcion_um.Text = Convert.ToString(Dgv_um.CurrentRow.Cells["descripcion_um"].Value);
                

            }

        }

        private void Selecciona_Item_ca()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("Selecciona un elemento de la lista",
                                 "Aviso del sistema",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            else
            {

                this.nCodigo_ca = Convert.ToInt32(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_ca.CurrentRow.Cells["descripcion_ca"].Value);


            }

        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
            this.Listado_ca();
            this.Listado_um();

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ar("%"+Txt_Buscar.Text.Trim()+"%");
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 1; //Nuevo registro
            this.Limpia_texto();
            this.Estado_Texto(true);
            this.Estado_Botones_Procesos(true);
            this.Estado_Botones_Principales(false);
            Txt_articulo.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            nCodigo_ar = 0;
            nEstadoguarda = 0;
            this.Limpia_texto();
            this.Estado_Texto(false);
            this.Estado_Botones_Procesos(false);
            this.Estado_Botones_Principales(true);
            Txt_Buscar.Focus();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string Rpta = "";
            P_Articulos oAr = new P_Articulos();
            oAr.Codigo_ar = nCodigo_ar;
            oAr.Descripcion_ar = Txt_articulo.Text.Trim();
            oAr.Marca_ar = Txt_Marca.Text.Trim();
            oAr.Codigo_um = this.nCodigo_um;
            oAr.Codigo_ca = this.nCodigo_ca;
            oAr.Stock_actual = Convert.ToDecimal(Txt_Stock.Text);
            oAr.Fecha_crea = DateTime.Now.ToString("yyyy-MM-dd");
            oAr.Fecha_modifica = DateTime.Now.ToString("yyyy-MM-dd");

            D_Articulos Datos = new D_Articulos();
            Rpta = Datos.Guardar_ar(nEstadoguarda, oAr);

            if(Rpta.Equals("OK"))
            {

                this.Estado_Texto(false);
                this.Estado_Botones_Procesos(false);
                this.Estado_Botones_Principales(true);
                this.Listado_ar("%");
                nCodigo_ar = 0;
                nEstadoguarda = 0;
                nCodigo_ca = 0;
                nCodigo_um = 0; 

                MessageBox.Show("Los datos han sido guardados correctamente",
                                 "Aviso del sistema",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Rpta,
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 2; //Actualizar registro
            this.Estado_Texto(true);
            this.Estado_Botones_Procesos(true);
            this.Estado_Botones_Principales(false);
            Txt_articulo.Focus();
        }

        private void dgv_articulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_articulo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (nCodigo_ar > 0)
            {
                string Rpta = "";
                D_Articulos Datos = new D_Articulos();
                Rpta = Datos.Eliminar_ar(nCodigo_ar);
                if (Rpta.Equals("OK"))
                {
                    this.Limpia_texto();
                    this.Listado_ar("%");
                    nCodigo_ar = 0;
                    MessageBox.Show("Registro eliminado correctamente",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("No se tiene seleccionado ningun registro",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            Frm_Rpt_articulos oRpt = new Frm_Rpt_articulos();
            oRpt.ShowDialog();
        }

        private void Btn_retornar_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Visible = false;
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Location = Btn_lupa_um.Location;
            Pnl_um.Visible = true;
        }

        private void Btn_lupa_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Location = Btn_lupa_ca.Location;
            Pnl_ca.Visible = true;
        }

        private void Btn_retornar_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Visible=false;
        }

        private void Dgv_um_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_Descripcion_um_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_um_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item_um();
            Pnl_um.Visible=false;
        }

        private void Dgv_ca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item_ca();
            Pnl_ca.Visible = false;
        }
    }
}
