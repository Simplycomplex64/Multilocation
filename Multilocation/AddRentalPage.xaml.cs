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
using System.Windows.Shapes;

namespace Multilocation
{
    /// <summary>
    /// Interaction logic for AddRentalPage.xaml
    /// </summary>
    public partial class AddRentalPage : Window
    {
        bool ouverture = false;
        SqlConnection connexion;
        UtilisateurActif utilisateur;
        SqlCommand commande;
        public AddRentalPage(UtilisateurActif actif)
        {
            InitializeComponent();
            utilisateur = actif;
            Title += "--" + utilisateur.Nom + " " + utilisateur.Prenom;

            connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            bool ouverture = true;
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connexion.Open();
                MultilocationUI gestionMultilocation = new MultilocationUI(utilisateur);
                gestionMultilocation.Show();
                ouverture = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        private void AddRentalBtn_Click(object sender, EventArgs e)
        {

            try
            {
                // Parse the input values
                int id;
                if (!int.TryParse(rentalIdTextBox.Text, out id))
                {
                    MessageBox.Show("Please enter a valid Rental ID.");
                    return;
                }

                DateTime DebutLocation = DateTime.Now; // Use appropriate value here

                DateTime PremierPaiement = DateTime.Now; // Use appropriate value here

                int Montant_1er_paiement;
                if (!int.TryParse(_1erPaiement.Text, out Montant_1er_paiement))
                {
                    MessageBox.Show("Please enter a valid 1st Payment Amount.");
                    return;
                }

                int Nbr_paiement;
                if (!int.TryParse(totalPaiement.Text, out Nbr_paiement))
                {
                    MessageBox.Show("Please enter a valid Total Payments.");
                    return;
                }

                string vehicule_vise = Vehicule_vise.Text;
                int concerned_Client;
                if (!int.TryParse(concernedClient.Text, out concerned_Client))
                {
                    MessageBox.Show("Please enter a valid Concerned Client.");
                    return;
                }

                int Termes;
                if (!int.TryParse(termes_location.Text, out Termes))
                {
                    MessageBox.Show("Please enter a valid Termes of Location.");
                    return;
                }

                // Check for empty fields
                if (string.IsNullOrWhiteSpace(rentalIdTextBox.Text) ||
                    string.IsNullOrWhiteSpace(_1erPaiement.Text) ||
                    string.IsNullOrWhiteSpace(totalPaiement.Text) ||
                    string.IsNullOrWhiteSpace(Vehicule_vise.Text) ||
                    string.IsNullOrWhiteSpace(concernedClient.Text) ||
                    string.IsNullOrWhiteSpace(termes_location.Text))
                {
                    MessageBox.Show("Please fill in all the required fields.");
                    return;
                }

                using (SqlConnection connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connexion.Open();

                    string checkIfExistQuery = "SELECT COUNT(*) FROM tbl_Locations WHERE Location_id = @Location_id";
                    using (SqlCommand command = new SqlCommand(checkIfExistQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@Location_id", id);
                        command.Parameters.AddWithValue("@Debut_location", DebutLocation);
                        command.Parameters.AddWithValue("@Premier_paiement", PremierPaiement);
                        command.Parameters.AddWithValue("@Montant_1er_Paiement", Montant_1er_paiement);
                        command.Parameters.AddWithValue("@Nbr_Paiement", Nbr_paiement);
                        command.Parameters.AddWithValue("@Vehicule_vise", vehicule_vise);
                        command.Parameters.AddWithValue("@Client_vise", concerned_Client);
                        command.Parameters.AddWithValue("@Termes_Location", Termes);
                        int existingCount = (int)command.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("This rental ID already exist in the database. Please try another.");
                            return;
                        }
                    }
                    string insertQuery = "INSERT INTO tbl_Locations (Location_id, Debut_location, Premier_paiement, Montant_1er_Paiement, Nbr_Paiement, Vehicule_vise, Client_vise, Termes_Location) VALUES(@Location_id, @Debut_location, @Premier_paiement, @Montant_1er_Paiement, @Nbr_Paiement, @Vehicule_vise, @Client_vise, @Termes_Location)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@Location_id", id);
                        command.Parameters.AddWithValue("@Debut_location", DebutLocation);
                        command.Parameters.AddWithValue("@Premier_paiement", PremierPaiement);
                        command.Parameters.AddWithValue("@Montant_1er_Paiement", Montant_1er_paiement);
                        command.Parameters.AddWithValue("@Nbr_Paiement", Nbr_paiement);
                        command.Parameters.AddWithValue("@Vehicule_vise", vehicule_vise);
                        command.Parameters.AddWithValue("@Client_vise", concerned_Client);
                        command.Parameters.AddWithValue("@Termes_Location", Termes);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                            MultilocationUI gestionMultilocation = new MultilocationUI(utilisateur);
                            gestionMultilocation.Show();
                            ouverture = false;
                            this.Close();
                        }
                    }
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

        private void DEBUT_LOCATION(object sender, RoutedEventArgs e)
        {
            DateTime Debut_location = DateTime.Now; // Initialize Debut_location with the current local time
            debut_location.Text = Debut_location.ToString("yyyy-MM-dd");
        }

        private void DateTextBox_Initialized(object sender, EventArgs e)
        {

        }

        private void active(object sender, EventArgs e)
        {
            date1erPaiement.SelectedDate = DateTime.Now;
        }
    }
}
