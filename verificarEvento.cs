using System;
using System.Collections;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using SimpleAccess.MySql;

namespace Agenda
{
    public partial class verificarEvento : MaterialForm
    {
        public string idE;
        public verificarEvento()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue300, Primary.BlueGrey300,
                Primary.Blue300, Accent.LightBlue100,
                TextShade.WHITE
            );
        }

        private void VerificarEvento_Load(object sender, EventArgs e)
        {
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Today;
            string fechaFormateada;
            int dia = fechaHoy.Day;
            int mes = fechaHoy.Month;
            int annio = fechaHoy.Year;
            if (dia <= 9)
            {
                string diaTexto = "0" + dia;
                fechaFormateada = diaTexto + "-" + mes + "-" + annio;
            }
            else
            {
                fechaFormateada = dia + "-" + mes + "-" + annio;
            }
            string pathR = Path.Combine(Application.StartupPath, @"Eventos\" + "R" + fechaFormateada + ".age");
            string sLine = "", completo = "";
            StreamReader objRead = new StreamReader(pathR);
            ArrayList lineasTexto = new ArrayList();
            while (sLine != null)
            {
                sLine = objRead.ReadLine();
                if (sLine != null)
                {
                    lineasTexto.Add(sLine);
                }
            }
            objRead.Close();
            foreach (String linea in lineasTexto)
            {
                completo += linea;
            }
            string[] recordatorios = completo.Split(';');
            File.Delete(pathR);
            foreach (string recordatorio in recordatorios)
            {
                if (recordatorio != "")
                {
                    string[] claves = recordatorio.Split('-');
                    //Se obtiene fecha y hora del recordatorio
                    string[] eventoId = claves[0].Split('+');
                    if (eventoId[1] == idE)
                    {
                        using (StreamWriter writer = File.AppendText(pathR))
                        {
                            int repeticion = 0;
                            foreach (string clave in claves)
                            {
                                if (repeticion == 0)
                                {
                                    string[] valores = clave.Split('+');
                                    writer.WriteLine(valores[0] + "+" + valores[1]);
                                }
                                else if (repeticion == 5)
                                {
                                    string[] valores = clave.Split('+');
                                    writer.WriteLine("-" + valores[0] + "+0");
                                }
                                else
                                {
                                    string[] valores = clave.Split('+');
                                    writer.WriteLine("-" + valores[0] + "+" + valores[1]);
                                }
                                repeticion++;
                            }
                            writer.WriteLine(";");
                            writer.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = File.AppendText(pathR))
                        {
                            int repeticion = 0;
                            foreach (string clave in claves)
                            {
                                if (repeticion == 0)
                                {
                                    string[] valores = clave.Split('+');
                                    writer.WriteLine(valores[0] + "+" + valores[1]);
                                }
                                else
                                {
                                    string[] valores = clave.Split('+');
                                    writer.WriteLine("-" + valores[0] + "+" + valores[1]);
                                }
                                repeticion++;
                            }
                            writer.WriteLine(";");
                            writer.Close();
                        }
                    }
                    this.Hide();
                }
            }
            string conexion = "Data Source=localhost;Initial Catalog=agenda;Persist Security Info=True;User ID=root;Password=";
            MySqlSimpleAccess simpleAccess = new MySqlSimpleAccess(conexion);
            string sql = "call desactivarR(" + idE + ")";
            simpleAccess.ExecuteNonQuery(sql);
            simpleAccess.CloseDbConnection();
        }
    }
}
