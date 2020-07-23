using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Drive.v3;
using MaterialSkin;
using MaterialSkin.Controls;
using SimpleAccess.MySql;

namespace Agenda
{
    public partial class Login : MaterialForm
    {
        UserCredential credential;
        public Login()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo300, Primary.BlueGrey500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private async Task iniciarSesionAsync()
        {
            var secrets = new ClientSecrets { ClientId = "338943711113-vevkfkdq9rtfd84q8isbsj6nq2dssvci.apps.googleusercontent.com", ClientSecret = "3nHVlB5FtNYvFVeXcEbpQ0vR" };
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new[] { DriveService.Scope.Drive }, "user", CancellationToken.None);
            if (credential.Token.IsExpired(credential.Flow.Clock))
            {
                try
                {
                    if (credential.RefreshTokenAsync(CancellationToken.None).Result)
                    {
                        MessageBox.Show("Token refrescado");
                        Calendario cal = new Calendario();
                        cal.credentials = credential;
                        cal.Show();
                        timer1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El token expiro pero no se pudo refrescar,por favor volver a iniciar sesion");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Calendario cal = new Calendario();
                cal.credentials = credential;
                cal.Show();
                timer1.Enabled = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Enabled = false;
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            iniciarSesionAsync();
        }

        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            Calendario cal = new Calendario();
            cal.materialFlatButton1.Visible = false;
            cal.materialFlatButton2.Visible = false;
            cal.Show();
            this.Hide();
        }
    }
}
