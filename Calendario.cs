using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;
using SimpleAccess.MySql;

namespace Agenda
{
    public partial class Calendario : MaterialForm
    {
        public UserCredential credentials;
        String pathP = Path.Combine(Application.StartupPath, @"Eventos\" + "parent" + ".age");
        String recordatorioF = "";
        string idE = "";
        int nRec = 1;
        public Calendario()
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

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            String fecha = monthCalendar1.SelectionRange.Start.ToShortDateString();
            DialogResult dr = MessageBox.Show("Fecha seleccionada: " + fecha + " \n¿Es correcta?", "Confirmacion", MessageBoxButtons.YesNo,
        MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Eventos_dia evD = new Eventos_dia();
                if (monthCalendar1.SelectionRange.Start < DateTime.Today)
                {
                    evD.mRBtnAgregar.Visible = false;
                    evD.mLblFecha.Text = fecha;
                    evD.cal = this;
                    evD.Show();
                    this.Hide();
                }
                else
                {
                    evD.mLblFecha.Text = fecha;
                    evD.cal = this;
                    evD.Show();
                    this.Hide();
                }
            }
        }
        private async void Calendario_Load(object sender, EventArgs e)
        {
            await convertirFechas();
        }
        private async Task convertirFechas()
        {
            DateTime fechaHoy = DateTime.Today;
            string fechaF = obtenerFecha(fechaHoy);
            string pathR = Path.Combine(Application.StartupPath, @"Eventos\" + "R" + fechaF + ".age"); ;
            await Task.Run(() =>
            {
                if (File.Exists(pathR))
                {
                    buscarRecordatorios(pathR);
                }
            });


        }
        private void buscarRecordatorios(string pathR)
        {
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
            foreach (string recordatorio in recordatorios)
            {
                Thread.Sleep(3000);
                if (recordatorio != "")
                {
                    string[] clave = recordatorio.Split('-');
                    //Se obtiene fecha y hora del recordatorio
                    string[] recordatorioId = clave[0].Split('+');
                    string[] fecha = clave[2].Split('+');
                    string[] hora = clave[3].Split('+');
                    string[] evento = clave[4].Split('+');
                    string[] estado = clave[5].Split('+');
                    idE = recordatorioId[1];
                    string fechita = fecha[1];
                    string horita = hora[1];
                    string eventico = evento[1];
                    int estadito = Convert.ToInt32(estado[1]);
                    recordatorioF = "Evento: " + eventico + "\nA la hora: " + horita;
                    mostrarNotificaciones(estadito);
                }
            }
        }
        private string obtenerFecha(DateTime fechita)
        {
            string fechaFormateada;
            int dia = fechita.Day;
            int mes = fechita.Month;
            int annio = fechita.Year;
            if (dia <= 9)
            {
                string diaTexto = "0" + dia;
                fechaFormateada = diaTexto + "-" + mes + "-" + annio;
            }
            else
            {
                fechaFormateada = dia + "-" + mes + "-" + annio;
            }

            return fechaFormateada;
        }
        private void mostrarNotificaciones(int flag)
        {
            if (recordatorioF != "")
            {
                if (flag != 0)
                {
                    switch (nRec)
                    {
                        case 1:
                            {
                                try
                                {
                                    string imagepath = Path.Combine(Application.StartupPath, @"..\..\imagenes\icono.ico");
                                    Notificaciones.Icon = new System.Drawing.Icon(imagepath);
                                    Notificaciones.Text = "Recordatorio de evento";
                                    Notificaciones.Tag = idE;
                                    Notificaciones.Visible = true;
                                    Notificaciones.BalloonTipTitle = "Recordatorio de evento: " + recordatorioF;
                                    Notificaciones.BalloonTipText = "Pulsame para mas detalles";
                                    Notificaciones.ShowBalloonTip(10000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            }
                        case 2:
                            {
                                try
                                {
                                    string imagepath = Path.Combine(Application.StartupPath, @"..\..\imagenes\icono.ico");
                                    notifyIcon1.Icon = new System.Drawing.Icon(imagepath);
                                    notifyIcon1.Text = "Recordatorio de evento";
                                    notifyIcon1.Tag = idE;
                                    notifyIcon1.Visible = true;
                                    notifyIcon1.BalloonTipTitle = "Recordatorio de evento: " + recordatorioF;
                                    notifyIcon1.BalloonTipText = "Pulsame para mas detalles";
                                    notifyIcon1.ShowBalloonTip(10000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            }
                        case 3:
                            {
                                try
                                {
                                    string imagepath = Path.Combine(Application.StartupPath, @"..\..\imagenes\icono.ico");
                                    notifyIcon2.Icon = new System.Drawing.Icon(imagepath);
                                    notifyIcon2.Text = "Recordatorio de evento";
                                    notifyIcon2.Tag = idE;
                                    notifyIcon2.Visible = true;
                                    notifyIcon2.BalloonTipTitle = "Recordatorio de evento: " + recordatorioF;
                                    notifyIcon2.BalloonTipText = "Pulsame para mas detalles";
                                    notifyIcon2.ShowBalloonTip(10000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            }
                        case 4:
                            {
                                try
                                {
                                    string imagepath = Path.Combine(Application.StartupPath, @"..\..\imagenes\icono.ico");
                                    notifyIcon3.Icon = new System.Drawing.Icon(imagepath);
                                    notifyIcon3.Text = "Recordatorio de evento";
                                    notifyIcon3.Tag = idE;
                                    notifyIcon3.Visible = true;
                                    notifyIcon3.BalloonTipTitle = "Recordatorio de evento: " + recordatorioF;
                                    notifyIcon3.BalloonTipText = "Pulsame para mas detalles";
                                    notifyIcon3.ShowBalloonTip(10000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            }
                        case 5:
                            {
                                try
                                {
                                    string imagepath = Path.Combine(Application.StartupPath, @"..\..\imagenes\icono.ico");
                                    notifyIcon4.Icon = new System.Drawing.Icon(imagepath);
                                    notifyIcon4.Text = "Recordatorio de evento";
                                    notifyIcon4.Tag = idE;
                                    notifyIcon4.Visible = true;
                                    notifyIcon4.BalloonTipTitle = "Recordatorio de evento: " + recordatorioF;
                                    notifyIcon4.BalloonTipText = "Pulsame para mas detalles";
                                    notifyIcon4.ShowBalloonTip(10000);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            }
                    }
                    nRec++;
                }
            }
        }

        private async Task leerTxt()
        {
            await Task.Run(() =>
            {
                string idParent = "";
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credentials,
                    ApplicationName = "Agenda",
                });
                service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
                if (File.Exists(pathP))
                {
                    StreamReader objRead = new StreamReader(pathP);
                    ArrayList lineasTexto = new ArrayList();
                    string sLine = "";
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
                        idParent += linea;
                    }
                }
                else
                {
                    string path = Path.Combine(Application.StartupPath, @"Eventos");
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Crear carpeta Google drive
                    Google.Apis.Drive.v3.Data.File bodyC = new Google.Apis.Drive.v3.Data.File();
                    bodyC.Name = "Agenda";
                    bodyC.Description = "Datos sobre tu agenda,no borrar";
                    bodyC.MimeType = "application/vnd.google-apps.folder";
                    Google.Apis.Drive.v3.Data.File file = service.Files.Create(bodyC).Execute();
                    idParent = file.Id;
                    using (StreamWriter writer = File.CreateText(pathP))
                    {
                        writer.WriteLine(idParent);
                        writer.Close();
                    }
                }
                Boolean existe = validarParent(service, idParent);
                if (existe)
                {
                    archivosTxt(idParent, service);
                }
                else
                {
                    File.Delete(pathP);
                    //Crear carpeta Google drive
                    Google.Apis.Drive.v3.Data.File bodyC = new Google.Apis.Drive.v3.Data.File();
                    bodyC.Name = "Agenda";
                    bodyC.Description = "Datos sobre tu agenda,no borrar";
                    bodyC.MimeType = "application/vnd.google-apps.folder";
                    Google.Apis.Drive.v3.Data.File file = service.Files.Create(bodyC).Execute();
                    idParent = file.Id;
                    using (StreamWriter writer = File.CreateText(pathP))
                    {
                        writer.WriteLine(idParent);
                        writer.Close();
                    }
                    archivosTxt(idParent, service);
                }
                MessageBox.Show("No cierre la aplicacion mientras se realiza la copia de seguridad");

            });
        }

        private async Task archivosTxt(string idParent, DriveService service)
        {
            await Task.Run(() =>
            {
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 40;
                listRequest.Fields = "nextPageToken, files(id, name)";
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string[] nombreA = file.Name.Split('.');
                        if (nombreA.Length > 1)
                        {
                            if (nombreA[1] == "age")
                            {
                                //Verifica los archivos guardados en drive y borra los antiguos
                                service.Files.Delete(file.Id).Execute();
                            }
                        }
                    }
                }
                var txtFiles = Directory.EnumerateFiles(Path.Combine(Application.StartupPath, @"Eventos"), "*.age");
                //Sube los nuevos archivos
                foreach (string currentFile in txtFiles)
                {
                    //Subir archivos Google drive
                    string path = currentFile;
                    Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                    body.Name = System.IO.Path.GetFileName(path);
                    body.Description = "Datos de tu agenda";
                    body.MimeType = "";
                    body.Parents = new List<string> { idParent };
                    byte[] byteArray = System.IO.File.ReadAllBytes(path);
                    MemoryStream stream = new MemoryStream(byteArray);
                    FilesResource.CreateMediaUpload archivo = service.Files.Create(body, stream, "");
                    archivo.Upload();
                }
                MessageBox.Show("Copia de seguridad hecha con exito");
            }
            );
        }

        private bool validarParent(DriveService service, string id)
        {
            Boolean existe;
            try
            {
                Google.Apis.Drive.v3.Data.File file = service.Files.Get(id).Execute();
                existe = true;
            }
            catch (Exception e)
            {
                existe = false;
            }
            return existe;
        }

        private void descargarArchivo(string remoteName, DriveService Service, Google.Apis.Drive.v3.Data.File fFile)
        {
            var fileId = fFile.Id;
            var request = Service.Files.Get(fileId);
            var stream = new MemoryStream();
            request.Execute();
            request.Download(stream);
            string path = Path.Combine(Application.StartupPath, @"Eventos\" + remoteName);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async Task restaura()
        {
            await Task.Run(() =>
            {
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credentials,
                    ApplicationName = "Agenda",
                });
                service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 100;
                listRequest.Fields = "nextPageToken, files(id, name)";
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
                string path = Path.Combine(Application.StartupPath, @"Eventos");
                Directory.CreateDirectory(path);
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string[] nombreA = file.Name.Split('.');
                        if (nombreA.Length > 1)
                        {
                            if (nombreA[1] == "age")
                            {
                                descargarArchivo(file.Name, service, file);
                            }
                        }
                    }
                    bd();
                }
                else
                {
                    MessageBox.Show("No tienes copia de seguridad guardada.");
                }
            });
        }

        private async Task bd()
        {
            string conexion = "Data Source=localhost;Initial Catalog=agenda;Persist Security Info=True;User ID=root;Password=";
            MySqlSimpleAccess simpleAccess = new MySqlSimpleAccess(conexion);
            var txtFiles = Directory.EnumerateFiles(Path.Combine(Application.StartupPath, @"Eventos"), "*.age");
            await Task.Run(() =>
            {
                simpleAccess.ExecuteNonQuery("call reiniciar()");
                foreach (string txt in txtFiles)
                {
                    StreamReader objRead = new StreamReader(txt);
                    ArrayList lineasTexto = new ArrayList();
                    string sLine = "";
                    string evento = "";
                    string sql = "";
                    if (txt.Contains("parent"))
                    {
                        while (sLine != null)
                        {
                            sLine = objRead.ReadLine();
                            if (sLine != null)
                            {
                                sql = "call insertarParent('" + sLine.ToString() + "')";
                            }
                        }
                        objRead.Close();
                        simpleAccess.ExecuteNonQuery(sql);
                    }
                    else if (txt.Contains("R"))
                    {
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
                            evento += linea;
                        }
                        string[] eventos = evento.Split(';');
                        foreach (string eventoCompleto in eventos)
                        {
                            if (eventoCompleto != "")
                            {
                                string[] linea = eventoCompleto.Split('-');
                                string[] idrCV = linea[0].Split('+');
                                string[] ideCV = linea[1].Split('+');
                                string[] fechaCV = linea[2].Split('+');
                                string[] horaCV = linea[3].Split('+');
                                string[] estadoCV = linea[5].Split('+');
                                sql = "call registroRecordatorioRespaldo('" + idrCV[1] + "','" + ideCV[1] + "','" + fechaCV[1] + "','" + horaCV[1] + "','" + estadoCV[1] + "')";
                                simpleAccess.ExecuteNonQuery(sql);
                            }
                        }
                    }
                    else
                    {
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
                            evento += linea;
                        }
                        string[] eventos = evento.Split(';');
                        foreach (string eventoCompleto in eventos)
                        {
                            if (eventoCompleto != "")
                            {
                                string[] linea = eventoCompleto.Split('-');
                                string[] idCV = linea[0].Split('+');
                                string[] nombreCV = linea[1].Split('+');
                                string[] fechaCV = linea[2].Split('+');
                                sql = "call insertarEventoRespaldo('" + idCV[1] + "','" + nombreCV[1] + "','" + fechaCV[1] + "')";
                                simpleAccess.ExecuteNonQuery(sql);
                            }
                        }
                    }
                }
                simpleAccess.CloseDbConnection();
                MessageBox.Show("Eventos restaurados");
            });
        }

        private void Notificaciones_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = Notificaciones.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            //Lee los txt de los eventos
            leerTxt();
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No cierres la aplicacion mientras se restauran los eventos");
            restaura();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = notifyIcon1.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon2_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = notifyIcon2.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon3_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = notifyIcon3.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon4_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = notifyIcon4.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon5_BalloonTipClicked(object sender, EventArgs e)
        {
            string tag = notifyIcon5.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void Notificaciones_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = Notificaciones.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = notifyIcon1.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon2_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = notifyIcon2.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon3_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = notifyIcon3.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon4_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = notifyIcon4.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void notifyIcon5_BalloonTipClosed(object sender, EventArgs e)
        {
            string tag = notifyIcon5.Tag.ToString();
            verificarEvento veE = new verificarEvento();
            veE.idE = tag;
            veE.Show();
        }

        private void Calendario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
