using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SimpleAccess.MySql;

namespace Agenda
{
    public partial class Evento : MaterialForm
    {
        public String fecha;
        int idE = 0;
        int idR;
        int flagFechaR = 0;
        DateTime fechaR = DateTime.Now.Date;
        public Eventos_dia evD;
        public Evento()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private async Task mandarRecordatorios()
        {
            folder();
            String[] fechaC = fecha.Split('/');
            string fechaNFormato = fechaC[2] + "/" + fechaC[1] + "/" + fechaC[0];
            DateTime fechis = Convert.ToDateTime(fechaNFormato);
            fechaR = fechis.Date;
            crearEvento();
            crearRecordatorio("09:00");
            switch (cbRec.SelectedIndex)
            {
                case 0:
                    flagFechaR = 0;
                    break;
                case 1:
                    fechaR = fechis.Date.AddDays(-1);
                    flagFechaR = 1;
                    break;
                case 2:
                    fechaR = fechis.Date.AddDays(-2);
                    flagFechaR = 1;
                    break;
                case 3:
                    fechaR = fechis.Date.AddDays(-7);
                    flagFechaR = 1;
                    break;
            }
            await Task.Run(() =>
            {
                DateTime FechAc = DateTime.Now.Date;
                DateTime hora = timeR.Value;
                int horaR = hora.Hour;
                int minutoR = hora.Minute;
                String horaCR = horaR + ":" + minutoR;
                if (flagFechaR != 0)
                {
                    if (fechaR > FechAc)
                    {
                        crearRecordatorio(horaCR);
                    }
                    else
                    {
                        MessageBox.Show("La fecha del recordatorio es menor a la actual");
                    }
                }
            });
        }

        private void folder()
        {
            string path = Path.Combine(Application.StartupPath, @"Eventos");
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void crearRecordatorio(String horaR)
        {
            String[] fechaC = fechaR.ToShortDateString().Split('/');
            string fechaBD = fechaC[2] + "/" + fechaC[1] + "/" + fechaC[0];
            String archivo = fechaC[0] + "-" + fechaC[1] + "-" + fechaC[2];
            String path = Path.Combine(Application.StartupPath, @"Eventos\" + "R" + archivo + ".age");
            string conexion = "Data Source=localhost;Initial Catalog=agenda;Allow User Variables=True;Persist Security Info=True;User ID=root;Password=";
            MySqlSimpleAccess simpleAccess = new MySqlSimpleAccess(conexion);
            string sql = "call agregarRecordatorio('" + idE + "','" + fechaBD + "','" + horaR + "')";
            simpleAccess.ExecuteNonQuery(sql);
            sql = "SELECT MAX(idR) as id from recordatorio";
            var idRR = simpleAccess.ExecuteReader(sql);
            while (idRR.Read())
            {
                idR = (int)idRR["id"];
            }
            if (File.Exists(path))
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("idR+" + idR);
                    writer.WriteLine("-idE+" + idE);
                    writer.WriteLine("-fechaR+" + fechaBD);
                    writer.WriteLine("-horaR+" + horaR);
                    writer.WriteLine("-evento+" + mTxtNombre.Text);
                    writer.WriteLine("-estado+" + "1");
                    writer.WriteLine(";");
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("idR+" + idR);
                    writer.WriteLine("-idE+" + idE);
                    writer.WriteLine("-fechaR+" + fechaR);
                    writer.WriteLine("-horaR+" + horaR);
                    writer.WriteLine("-evento+" + mTxtNombre.Text);
                    writer.WriteLine("-estado+" + "1");
                    writer.WriteLine(";");
                    writer.Close();
                }
            }
        }
        private void crearEvento()
        {
            String[] fechaC = fecha.Split('/');
            string fechaNFormato = fechaC[2] + "/" + fechaC[1] + "/" + fechaC[0];
            String archivo = fechaC[0] + "-" + fechaC[1] + "-" + fechaC[2];
            String path = Path.Combine(Application.StartupPath, @"Eventos\" + archivo + ".age");
            String nombre = mTxtNombre.Text;
            string conexion = "Data Source=localhost;Initial Catalog=agenda;Allow User Variables=True;Persist Security Info=True;User ID=root;Password=";
            MySqlSimpleAccess simpleAccess = new MySqlSimpleAccess(conexion);
            string sql = "call insertarEvento('" + nombre + "','" + fechaNFormato + "')";
            simpleAccess.ExecuteNonQuery(sql);
            sql = "SELECT MAX(idE) as id FROM evento";
            var idEe = simpleAccess.ExecuteReader(sql);
            while (idEe.Read())
            {
                idE = (int)idEe["id"];
            }
            simpleAccess.CloseDbConnection();
            if (File.Exists(path))
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("idE+" + idE);
                    writer.WriteLine("-nombre+" + nombre);
                    writer.WriteLine("-fechaInicio+" + fechaNFormato);
                    writer.WriteLine(";");
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("idE+" + idE);
                    writer.WriteLine("-nombre+" + nombre);
                    writer.WriteLine("-fechaInicio+" + fechaNFormato);
                    writer.WriteLine(";");
                    writer.Close();
                }
            }
            MessageBox.Show("Evento registrado");
        }
        private void Evento_LoadAsync(object sender, EventArgs e)
        {
            String[] fechaC = fecha.Split('/');
            int annio = Convert.ToInt32(fechaC[2]);
            int mes = Convert.ToInt32(fechaC[1]);
            int dia = Convert.ToInt32(fechaC[0]);
            mLblFecha.Text = fecha;
            cbRec.SelectedIndex = 0;
            timeR.ShowUpDown = true;
        }

        private void mRBtnGuardar_Click(object sender, EventArgs e)
        {
            mandarRecordatorios();
        }

        private void mRbtnVolver_Click(object sender, EventArgs e)
        {
            evD.Show();
            evD.llenarTree();
            this.Hide();
        }
    }
}
