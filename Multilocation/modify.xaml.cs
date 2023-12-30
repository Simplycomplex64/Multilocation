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
    /// Interaction logic for modify.xaml
    /// </summary>
    public partial class modify : Window
    {
        bool ouverture = false;
        SqlConnection connexion;
        UtilisateurActif utilisateur;
        SqlCommand commande;
        int locationId;
        public modify(UtilisateurActif actif, int locationId)
        {
            InitializeComponent();
            utilisateur = actif;
            Title += "--" + utilisateur.Nom + " " + utilisateur.Prenom;

            connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            bool ouverture = true;

            this.locationId = locationId;

            PopulateFields();
        }

        private void PopulateFields()
        {
            try
            {
                connexion.Open();

                string selectQuery = "SELECT * FROM tbl_Locations WHERE Location_id = @Location_id";
                using (SqlCommand command = new SqlCommand(selectQuery, connexion))
                {
                    command.Parameters.AddWithValue("@Location_id", locationId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the fields with the existing data for the given Location_id
                            rentalIdTextBox.Text = reader["Location_id"].ToString();
                            debut_location.Text = reader["Debut_location"].ToString();
                            date1erPaiement.SelectedDate = Convert.ToDateTime(reader["Premier_paiement"]);
                            _1erPaiement.Text = reader["Montant_1er_Paiement"].ToString();
                            totalPaiement.Text = reader["Nbr_Paiement"].ToString();
                            Vehicule_vise.Text = reader["Vehicule_vise"].ToString();
                            concernedClient.Text = reader["Client_vise"].ToString();
                            termes_location.Text = reader["Termes_Location"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve rental data. Please try again.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            this.Close();
                        }
                    }
                }
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

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
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

                DateTime DebutLocation;
                if (!DateTime.TryParse(debut_location.Text, out DebutLocation))
                {
                    MessageBox.Show("Please enter a valid Start Date.");
                    return;
                }

                DateTime PremierPaiement;
                if (!DateTime.TryParse(date1erPaiement.Text, out PremierPaiement))
                {
                    MessageBox.Show("Please enter a valid First Payment Date.");
                    return;
                }

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
                    MessageBox.Show("Please enter a valid Terms of Location.");
                    return;
                }

                using (SqlConnection connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                {
                    connexion.Open();

                    // Check if the rental ID exists in the database
                    string checkIfExistQuery = "SELECT COUNT(*) FROM tbl_Locations WHERE Location_id = @Location_id";
                    using (SqlCommand command = new SqlCommand(checkIfExistQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@Location_id", id);
                        int existingCount = (int)command.ExecuteScalar();

                        if (existingCount == 0)
                        {
                            MessageBox.Show("This rental ID does not exist in the database. Please enter a valid rental ID.");
                            return;
                        }
                    }

                    // Update the rental record in the database
                    string updateQuery = "UPDATE tbl_Locations SET Debut_location = @Debut_location, Premier_paiement = @Premier_paiement, Montant_1er_Paiement = @Montant_1er_Paiement, Nbr_Paiement = @Nbr_Paiement, Vehicule_vise = @Vehicule_vise, Client_vise = @Client_vise, Termes_Location = @Termes_Location WHERE Location_id = @Location_id";
                    using (SqlCommand command = new SqlCommand(updateQuery, connexion))
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
                            MessageBox.Show("Data updated successfully!");
                            // Optionally, you can refresh the DataGrid in the MultilocationUI window to reflect the changes
                            MultilocationUI gestionMultilocation = new MultilocationUI(utilisateur);
                            gestionMultilocation.Show();
                            ouverture = false;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update data. Please try again.");
                        }
                    }
                }
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
    }
}
