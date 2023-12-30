using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multilocation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        bool ouverture = false;
        public MainWindow()
        {
            InitializeComponent();
            connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            usernameTxtBox.Focus();
            ouverture = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string authentification = "SELECT * FROM tbl_Utilisateurs WHERE NomUtilisateur = '" + usernameTxtBox.Text + "' AND MotDePasse = '" + passwordBox.Password + "'";
                commande = new SqlCommand(authentification, connexion);
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                        UtilisateurActif utilisateur = new UtilisateurActif();

                        utilisateur.IdUtilisateur = lecteur["IdUtilisateur"].ToString();
                        utilisateur.Prenom = lecteur["Prenom"].ToString();
                        utilisateur.Nom = lecteur["Nom"].ToString();

                        MessageBox.Show("Bienvenue " + utilisateur.Nom + " " + utilisateur.Prenom);

                    MultilocationUI gestionMultilocation = new MultilocationUI(utilisateur);
                    gestionMultilocation.Show();
                    ouverture = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Desole, les informations de connection ne sont pas valides.");
                    usernameTxtBox.Text = string.Empty;
                    passwordBox.Password = string.Empty;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }
    }
}
