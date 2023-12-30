using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;

namespace Multilocation
{
    /// <summary>
    /// Interaction logic for MultilocationUI.xaml
    /// </summary>
    public partial class MultilocationUI : Window
    {
        bool ouverture = false;
        SqlConnection connexion;
        UtilisateurActif utilisateur;
        SqlCommand commande;

        public MultilocationUI(UtilisateurActif actif)
        {
            InitializeComponent();
            utilisateur = actif;

            Title += "--" + utilisateur.Nom + " " + utilisateur.Prenom;
            connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            FillDataGrid();
            ouverture = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (ValueToSearch.Text != string.Empty)
            {
                try
                {
                    string valueToSearch = ValueToSearch.Text;
                    connexion.Open();
                    string query = "SELECT dbo.tbl_Locations.Location_id, dbo.tbl_Vehicules.Marque, dbo.tbl_Locations.Debut_location, dbo.tbl_Locations.Premier_paiement, dbo.tbl_Locations.Montant_1er_Paiement, dbo.tbl_Locations.Nbr_Paiement, dbo.tbl_Vehicules.NIV, dbo.tbl_Modeles.Modele, dbo.tbl_Vehicules.Annee, dbo.tbl_CLients.Client_id, dbo.tbl_CLients.Nom, dbo.tbl_CLients.Prenom,dbo.tbl_CLients.NomComplet, dbo.tbl_CLients.Numero_de_telephone," +
                   "dbo.tbl_Termes_location.KM_MAX_PERMIS,dbo.tbl_Termes_location.Supprime FROM dbo.tbl_Locations INNER JOIN dbo.tbl_Termes_location ON dbo.tbl_Locations.Termes_Location=dbo.tbl_Termes_location.Termes_location_id INNER JOIN dbo.tbl_CLients ON dbo.tbl_Locations.Client_vise = dbo.tbl_CLients.Client_id INNER JOIN dbo.tbl_Vehicules ON dbo.tbl_Locations.Vehicule_vise = dbo.tbl_Vehicules.NIV INNER JOIN dbo.tbl_Modeles ON dbo.tbl_Modeles.Modele_id = dbo.tbl_Vehicules.Modele WHERE Location_id LIKE @ValueToSearch OR Nom LIKE @ValueToSearch OR Prenom LIKE @ValueToSearch";
                    using (SqlCommand commande = new SqlCommand(query, connexion))
                    {
                        commande.Parameters.AddWithValue("@valueToSearch", "%" + valueToSearch + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(commande);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    ValueToSearch.Clear();
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
            else
            {
                MessageBox.Show("You can not search with an empty field", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showAllBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connexion.Open();
                ValueToSearch.Clear();
                FillDataGrid();
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

        public void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string cmdString = string.Empty;
            using (SqlConnection conn = new SqlConnection(ConString))
            {
                string search = ValueToSearch.Text;
                cmdString = "SELECT dbo.tbl_Locations.Location_id, dbo.tbl_Vehicules.Marque, dbo.tbl_Locations.Debut_location, dbo.tbl_Locations.Premier_paiement, dbo.tbl_Locations.Montant_1er_Paiement, dbo.tbl_Locations.Nbr_Paiement, dbo.tbl_Vehicules.NIV, dbo.tbl_Modeles.Modele, dbo.tbl_Vehicules.Annee, dbo.tbl_CLients.Client_id, dbo.tbl_CLients.Nom, dbo.tbl_CLients.Prenom,dbo.tbl_CLients.NomComplet, dbo.tbl_CLients.Numero_de_telephone," +
                   "dbo.tbl_Termes_location.KM_MAX_PERMIS,dbo.tbl_Termes_location.Supprime FROM dbo.tbl_Locations INNER JOIN dbo.tbl_Termes_location ON dbo.tbl_Locations.Termes_Location=dbo.tbl_Termes_location.Termes_location_id INNER JOIN dbo.tbl_CLients ON dbo.tbl_Locations.Client_vise = dbo.tbl_CLients.Client_id INNER JOIN dbo.tbl_Vehicules ON dbo.tbl_Locations.Vehicule_vise = dbo.tbl_Vehicules.NIV INNER JOIN dbo.tbl_Modeles ON dbo.tbl_Modeles.Modele_id = dbo.tbl_Vehicules.Modele";
                SqlCommand cmd = new SqlCommand(cmdString, connexion);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("tbl_Locations");
                sda.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void addNewRental_Click(object sender, RoutedEventArgs e)
        {
            AddRentalPage newRental = new AddRentalPage(utilisateur);
            newRental.Show();
            ouverture = false;
            this.Close();
        }

        private void OnUpdateButtonClick(object sender, RoutedEventArgs e)
        {
            // Check if a row is selected in the DataGrid
            if (DataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a rental record to update.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the Location_id from the selected row in the DataGrid
            DataRowView selectedRow = (DataRowView)DataGrid.SelectedItem;
            int locationId = Convert.ToInt32(selectedRow["Location_id"]);

            // Open the modify window and pass the Location_id to it
            modify modifyRental = new modify(utilisateur, locationId);
            modifyRental.Show();
            ouverture = false;
            this.Close();
        }
    }
}