using System;
using System.Collections;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using SimpleAccess.MySql;
using MySql.Data.MySqlClient;

namespace Agenda
{
    public partial class Eventos_dia : MaterialForm
    {
        String rcompleto = "";
        public Calendario cal;
        public Eventos_dia()
        {
            InitializeComponent();
        }

        private void Eventos_dia_Load(object sender, EventArgs e)
        {
            llenarTree();
        }

        public void llenarTree()
        {
            treeView1.Nodes.Clear();
            //Se obtiene la fecha en base al label para nombrar el archivo
            String fecha = mLblFecha.Text;
            String[] fechaC = fecha.Split('/');
            string fechaForm = fechaC[2] + "/" + fechaC[1] + "/" + fechaC[0];
            string conexion = "Data Source=localhost;Initial Catalog=agenda;Allow Zero Datetime=true;Persist Security Info=True;User ID=root;Password=";
            MySqlSimpleAccess simpleAccess = new MySqlSimpleAccess(conexion);
            string sql = "call verEvento('" + fechaForm + "')";
            var datos = simpleAccess.ExecuteReader(sql);
            treeView1.BeginUpdate();
            int r = 0;
            while (datos.Read())
            {
                string nombre = (string)datos["nombre"];
                int id = (int)datos["idE"];
                string nodoP = nombre.Trim();
                treeView1.Nodes.Add(nodoP);
                sql = "call recordatoriosEvento(" + id + ")";
                MySqlSimpleAccess otroAccess = new MySqlSimpleAccess(conexion);
                var recordatorios = otroAccess.ExecuteReader(sql);
                while (recordatorios.Read())
                {
                    string fechaR = recordatorios["fechaRecordatorio"].ToString();
                    TimeSpan horaR = (TimeSpan)recordatorios["horaRecordatorio"];
                    String recordatorioF = ("Recordatorio " + fechaR + " " + horaR).Trim();
                    treeView1.Nodes[r].Nodes.Add(recordatorioF);
                }
                r++;
                otroAccess.CloseDbConnection();
            }
            treeView1.EndUpdate();
            simpleAccess.CloseDbConnection();
        }
        private void mRBtnAgregar_Click(object sender, EventArgs e)
        {
            Evento ev = new Evento();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.BlueGrey500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
            ev.fecha = mLblFecha.Text;
            ev.evD = this;
            ev.Show();
            this.Hide();
        }

        private void mRBtnVolver_Click(object sender, EventArgs e)
        {
            cal.Show();
            this.Hide();
        }
    }
}
