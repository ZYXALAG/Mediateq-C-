using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mediateq_AP_SIO2.metier;
using Mediateq_AP_SIO2.modele;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Représente le formulaire principal de l'application Mediateq, gérant les interactions de l'utilisateur avec l'interface graphique.
    /// </summary>
    public partial class FrmMediateq : Form
    {
        #region Variables globales

        /// <summary>
        /// Contient toutes les catégories disponibles.
        /// </summary>
        static List<Categorie> lesCategories;

        /// <summary>
        /// Contient tous les descripteurs disponibles.
        /// </summary>
        static List<Descripteur> lesDescripteurs;

        /// <summary>
        /// Contient toutes les revues disponibles.
        /// </summary>
        static List<Revue> lesRevues;

        /// <summary>
        /// Contient tous les livres disponibles.
        /// </summary>
        static List<Livre> lesLivres;

        /// <summary>
        /// Contient tous les DVD disponibles.
        /// </summary>
        static List<DVD> lesDVD;

        /// <summary>
        /// Contient toutes les commandes disponibles.
        /// </summary>
        static List<Commande> lesCommandes;

        #endregion

        #region Procédures évènementielles

        /// <summary>
        /// Constructeur du formulaire principal.
        /// </summary>
        public FrmMediateq()
        {
            InitializeComponent(); // Initialisation des composants de l'interface utilisateur
        }

        /// <summary>
        /// Évènement déclenché au chargement du formulaire.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void FrmMediateq_Load(object sender, EventArgs e)
        {
            try
            {
                // Création de la connexion avec la base de données
                DAOFactory.creerConnection();

                // Chargement des objets nécessaires au démarrage
                lesDescripteurs = DAODocuments.getAllDescripteurs();
                lesRevues = DAOPresse.getAllRevues();
                lesCommandes = DAOCommande.getAllCommande();

                // Initialisation des onglets de l'interface utilisateur
                tabControl.TabPages.Remove(tabParutions);
                tabControl.TabPages.Remove(tabTitres);
                tabControl.TabPages.Remove(tabLivres);
                tabControl.TabPages.Remove(tabDVD);
                tabControl.TabPages.Remove(tabAboRevues);
                tabControl.TabPages.Remove(tabCommande);

                // Désactivation du bouton de déconnexion par défaut
                buttonDeconnexion.Enabled = false;
            }
            catch (ExceptionSIO exc)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show(exc.NiveauExc + " - " + exc.LibelleExc + " - " + exc.Message);
            }
        }

        #endregion


        #region Parutions
        //-----------------------------------------------------------
        // ONGLET "PARUTIONS"
        //-----------------------------------------------------------

        /// <summary>
        /// Évènement déclenché lorsque l'onglet "Parutions" est activé.
        /// Initialise la source de données de la liste déroulante des titres avec toutes les revues.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabParutions_Enter(object sender, EventArgs e)
        {
            cbxTitres.DataSource = lesRevues; // Associe les revues à la liste déroulante
            cbxTitres.DisplayMember = "titre"; // Définit le champ à afficher comme "titre"
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur change de titre dans la liste déroulante.
        /// Met à jour le DataGridView avec les parutions associées au titre sélectionné.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void cbxTitres_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtenir la liste des parutions pour le titre sélectionné
            List<Parution> lesParutions;

            Revue titreSelectionne = (Revue)cbxTitres.SelectedItem; // Titre sélectionné dans la liste déroulante
            lesParutions = DAOPresse.getParutionByTitre(titreSelectionne); // Récupérer les parutions pour le titre

            // Réinitialisation du DataGridView
            dgvParutions.Rows.Clear(); // Efface les lignes existantes

            // Parcourt les parutions et ajoute les détails au DataGridView
            foreach (Parution parution in lesParutions)
            {
                dgvParutions.Rows.Add(parution.Numero, parution.DateParution, parution.Photo); // Ajoute une ligne pour chaque parution
            }
        }

        #endregion


        #region Revues
        //-----------------------------------------------------------
        // ONGLET "TITRES"
        //-----------------------------------------------------------

        /// <summary>
        /// Évènement déclenché lorsque l'onglet "Titres" (Revues) est activé.
        /// Initialise la liste déroulante des domaines avec les descripteurs disponibles.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabTitres_Enter(object sender, EventArgs e)
        {
            cbxDomaines.DataSource = lesDescripteurs; // Associe les descripteurs à la liste déroulante
            cbxDomaines.DisplayMember = "libelle"; // Définit le champ à afficher comme "libelle"
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur change de domaine dans la liste déroulante.
        /// Met à jour le DataGridView avec les revues associées au descripteur sélectionné.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void cbxDomaines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Objet Descripteur sélectionné dans la liste déroulante
            Descripteur domaineSelectionne = (Descripteur)cbxDomaines.SelectedItem;

            // Réinitialisation du DataGridView
            dgvTitres.Rows.Clear(); // Efface les lignes existantes

            // Parcourt la collection des revues et ajoute les revues qui correspondent au domaine sélectionné
            foreach (Revue revue in lesRevues)
            {
                if (revue.IdDescripteur == domaineSelectionne.Id)
                {
                    dgvTitres.Rows.Add(
                        revue.Id,
                        revue.Titre,
                        revue.Empruntable,
                        revue.DateFinAbonnement,
                        revue.DelaiMiseADispo
                    ); // Ajoute une ligne pour chaque revue correspondant au descripteur sélectionné
                }
            }
        }

        #endregion

        #region Livres
        //-----------------------------------------------------------
        // ONGLET "LIVRES"
        //-----------------------------------------------------------

        /// <summary>
        /// Évènement déclenché lorsque l'onglet "Livres" est activé.
        /// Charge en mémoire les catégories, les descripteurs, et les livres disponibles.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabLivres_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesLivres = DAODocuments.getAllLivres();
        }

        /// <summary>
        /// Évènement déclenché lorsqu'on clique sur le bouton "Rechercher".
        /// Recherche un livre par son numéro de document et met à jour les labels avec ses détails.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // Réinitialise les labels
            lblNumero.Text = "";
            lblTitre.Text = "";
            lblAuteur.Text = "";
            lblCollection.Text = "";
            lblISBN.Text = "";
            lblImage.Text = "";

            bool trouve = false;

            // Recherche le livre correspondant au numéro de document saisi
            foreach (Livre livre in lesLivres)
            {
                if (livre.IdDoc == txbNumDoc.Text) // Si le numéro correspond
                {
                    // Met à jour les labels avec les détails du livre
                    lblNumero.Text = livre.IdDoc;
                    lblTitre.Text = livre.Titre;
                    lblAuteur.Text = livre.Auteur;
                    lblCollection.Text = livre.LaCollection;
                    lblISBN.Text = livre.ISBN1;
                    lblImage.Text = livre.Image;
                    trouve = true; // Indique que le livre a été trouvé
                }
            }

            // Affiche un message d'erreur si le livre n'a pas été trouvé
            if (!trouve)
            {
                MessageBox.Show("Document non trouvé dans les livres");
            }
        }

        /// <summary>
        /// Évènement déclenché lorsque le texte du champ de titre change.
        /// Met à jour le DataGridView avec les livres dont le titre correspond à la saisie.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void txbTitre_TextChanged(object sender, EventArgs e)
        {
            dgvLivres.Rows.Clear(); // Efface les lignes existantes dans le DataGridView

            // Parcourt tous les livres et affiche ceux dont le titre contient le texte saisi
            foreach (Livre livre in lesLivres)
            {
                // Convertit le texte saisi et le titre du livre en minuscules pour comparaison insensible à la casse
                string saisieMinuscules = txbTitre.Text.ToLower();
                string titreMinuscules = livre.Titre.ToLower();

                // Si le titre du livre contient la saisie
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection); // Ajoute le livre au DataGridView
                }
            }
        }

        #endregion

        #region DVD
        //-----------------------------------------------------------
        // ONGLET "DVD"
        //-----------------------------------------------------------

        private void tabDVD_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesDVD = DAODocuments.getAllDVD();
        }

        private void btnRechercherDVD_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            lblNumeroDVD.Text = "";
            lblTitreDVD.Text = "";
            lblRealisateurDVD.Text = "";
            lblDureeDVD.Text = "";
            lblSynopsisDVD.Text = "";
            lblImageDVD.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (DVD dvd in lesDVD)
            {
                if (dvd.IdDoc == txbNumDocDVD.Text)
                {
                    // On affiche les informations du DVD
                    lblNumeroDVD.Text = dvd.IdDoc;
                    lblTitreDVD.Text = dvd.Titre;
                    lblRealisateurDVD.Text = dvd.Realisateur;
                    lblDureeDVD.Text = dvd.Duree.ToString();
                    lblSynopsisDVD.Text = dvd.Synopsis;
                    lblImageDVD.Text = dvd.Image;
                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les dvds");
        }

        private void txbTitreDVD_TextChanged(object sender, EventArgs e)
        {
            dgvDVD.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (DVD dvd in lesDVD)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txbTitreDVD.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = dvd.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvDVD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Realisateur, dvd.Synopsis, dvd.Duree);
                }
            }
        }
        #endregion

        #region Connexion
        //-----------------------------------------------------------
        // ONGLET "CONNEXION"
        //-----------------------------------------------------------

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le titre du DVD (vide, sans fonction actuellement).
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void lblTitreDVD_Click(object sender, EventArgs e)
        {
            // Cet événement est actuellement sans action associée.
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton de connexion.
        /// Gère le processus de connexion de l'utilisateur et l'activation des onglets appropriés si la connexion réussit.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            // Récupérer le mot de passe de l'utilisateur
            string mdp = textBoxPassword.Text.ToString();

            // Vérifier les informations de connexion
            User connectedUser = DAOConnexion.verifUser(textBoxMail.Text.ToString(), textBoxPassword.Text.ToString());

            if (connectedUser != null) // Si l'utilisateur est trouvé
            {
                // Afficher les informations de l'utilisateur connecté
                labelnom.Text = connectedUser.getNom();
                labelprenom.Text = connectedUser.getPrenom();

                // Afficher les onglets pertinents pour l'utilisateur connecté
                tabControl.TabPages.Add(tabParutions);
                tabControl.TabPages.Add(tabTitres);
                tabControl.TabPages.Add(tabLivres);
                tabControl.TabPages.Add(tabDVD);
                tabControl.TabPages.Add(tabAboRevues);
                tabControl.TabPages.Add(tabCommande);

                // Désactiver le bouton de connexion et activer le bouton de déconnexion
                buttonConnexion.Enabled = false;
                buttonDeconnexion.Enabled = true;
            }
            else // Si l'utilisateur n'est pas trouvé
            {
                // Afficher un message d'erreur
                labelnom.Text = "erreur";
            }
        }

        #endregion


        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        #region Inscription
        //-----------------------------------------------------------
        // ONGLET "Inscription"
        //-----------------------------------------------------------

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton d'inscription.
        /// Tente de créer un nouvel utilisateur avec les informations saisies.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void buttonInscription_Click(object sender, EventArgs e)
        {
            // Récupération des informations de l'utilisateur à partir des champs de saisie
            string mail = TBInscriptionMail.Text; // Adresse email (login)
            string mdp = TBInscriptionMDP.Text;   // Mot de passe
            string prenom = TBInscriptionPrenom.Text; // Prénom
            string nom = TBInscriptionNom.Text; // Nom
            int service = comboBoxService.SelectedIndex; // Index du service choisi

            // Essayer de créer un nouvel utilisateur avec les informations fournies
            if (DAOConnexion.InscrireUser(mail, mdp, prenom, nom, service))
            {
                MessageBox.Show("Compte créé"); // Afficher un message si la création a réussi
            }
            else
            {
                MessageBox.Show("Erreur lors de la création"); // Afficher un message d'erreur si la création a échoué
            }
        }

        #endregion


        // 
        /// <summary>
        /// Évènement déclenché lorsque l'onglet "Abo Revues" est activé.
        /// Affiche les revues dont l'abonnement expire dans moins de 60 jours.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabAboRevues_Enter(object sender, EventArgs e)
        {
            DGVRevues.Rows.Clear(); // Efface les lignes existantes dans le DataGridView

            foreach (Revue revue in lesRevues)
            {
                if (revue.DateFinAbonnement < DateTime.Now.AddDays(60)) // Si l'abonnement expire dans moins de 60 jours
                {
                    // Ajoute la revue au DataGridView
                    DGVRevues.Rows.Add(revue.Id, revue.Titre, revue.DateFinAbonnement.ToString("yyyy-MM-dd"));
                }
            }
        }

        /// <summary>
        /// Évènement déclenché lorsqu'une cellule du DataGridView "Revues" est cliquée.
        /// Actuellement sans action associée.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void DGVRevues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cet événement n'a pas d'action associée
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton d'ajout de revue.
        /// Tente d'ajouter une nouvelle revue avec les détails fournis et met à jour le DataGridView des revues.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void buttonAjoutRevue_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupère les détails de la nouvelle revue
                string titre = TBTitreRevue.Text;
                string empruntable = radioButtonOui.Checked ? "O" : "N"; // "O" pour oui, "N" pour non
                string periodicite = CBPeriodicite.Text;
                int delaisDispo = int.Parse(TBDelais.Text);
                DateTime dateFinAbo = dateTimePickerDateFinAbo.Value;
                int idDescripteur = CBTypeRevue.SelectedIndex; // Index du descripteur associé

                // Tente d'ajouter la nouvelle revue
                if (DAODocuments.ajoutRevue(titre, empruntable, periodicite, delaisDispo, dateFinAbo, idDescripteur))
                {
                    MessageBox.Show("Revue ajoutée avec succès"); // Message de succès

                    // Met à jour le DataGridView avec les revues actualisées
                    DGVRevues.Rows.Clear();
                    lesRevues = DAOPresse.getAllRevues();
                    foreach (Revue revue in lesRevues)
                    {
                        if (revue.DateFinAbonnement < DateTime.Now.AddDays(60))
                        {
                            DGVRevues.Rows.Add(revue.Id, revue.Titre, revue.DateFinAbonnement.ToString("yyyy-MM-dd")); // Ajoute la revue au DataGridView
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la création de la revue"); // Message d'erreur si la création échoue
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}"); // Afficher l'exception en cas d'erreur
            }
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur un bouton pour rechercher une revue par identifiant.
        /// Met à jour les labels avec les détails de la revue trouvée.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Récupère la revue par son identifiant
            Revue revueSelected = DAODocuments.getRevueById(Convert.ToInt32(TBIdRevue.Text));

            if (revueSelected == null) // Si la revue n'est pas trouvée
            {
                MessageBox.Show("Revue introuvable"); // Afficher un message d'erreur
            }
            else // Si la revue est trouvée
            {
                // Met à jour les labels avec les détails de la revue
                labelTitreRevue.Text = revueSelected.Titre;
                labelDateFinAbo.Text = revueSelected.DateFinAbonnement.ToString("yyyy-MM-dd");
            }
        }


        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton pour ajouter des mois à l'abonnement.
        /// Tente de renouveler l'abonnement d'une revue pour un nombre de mois donné.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void buttonAjoutMois_Click(object sender, EventArgs e)
        {
            if (DAODocuments.renouvellement(TBIdRevue.Text, TBAjoutMois.Text))
            {
                MessageBox.Show("Renouvellement de " + TBAjoutMois.Text + " mois réussi");

                // Réinitialise le DataGridView des revues
                DGVRevues.Rows.Clear();
                lesRevues = DAOPresse.getAllRevues();
                foreach (Revue revue in lesRevues)
                {
                    if (revue.DateFinAbonnement < DateTime.Now.AddDays(60))
                    {
                        DGVRevues.Rows.Add(revue.Id, revue.Titre, revue.DateFinAbonnement.ToString("yyyy-MM-dd"));
                    }
                }
            }
            else
            {
                MessageBox.Show("Erreur lors du renouvellement");
            }
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton de déconnexion.
        /// Retire les onglets de l'utilisateur connecté et réinitialise les informations de connexion.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void buttonDeconnexion_Click(object sender, EventArgs e)
        {
            // Retire les onglets de l'utilisateur connecté
            tabControl.TabPages.Remove(tabParutions);
            tabControl.TabPages.Remove(tabTitres);
            tabControl.TabPages.Remove(tabLivres);
            tabControl.TabPages.Remove(tabDVD);
            tabControl.TabPages.Remove(tabAboRevues);

            // Réinitialise les labels des informations de connexion
            labelnom.Text = "";
            labelprenom.Text = "";

            // Active/désactive les boutons de connexion et de déconnexion
            buttonDeconnexion.Enabled = false;
            buttonConnexion.Enabled = true;
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton pour ajouter une nouvelle commande.
        /// Tente de créer une nouvelle commande avec les détails fournis.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void btnCommande_Click(object sender, EventArgs e)
        {
            string nomDoc = textBoxNomDoc.Text;
            int nbrExemplaire = (int)numericUpDownNbrExemplaire.Value;

            if (DAOCommande.ajoutCommande(nomDoc, nbrExemplaire))
            {
                MessageBox.Show("Commande ajoutée avec succès");
            }
            else
            {
                MessageBox.Show("Erreur lors de la création de la commande");
            }
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur une cellule du DataGridView.
        /// Met à jour le champ de texte avec le numéro de la commande sélectionnée.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TBNumeroCommande.Text = DGVCommande.Rows[e.RowIndex].Cells[0].Value.ToString(); // Met à jour le champ de texte
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur l'onglet "Suivi Commande" (actuellement sans action).
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabSuiviCommande_Click(object sender, EventArgs e)
        {
            // Cet événement n'a pas d'action associée actuellement
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur l'onglet "Commande".
        /// Met à jour le DataGridView avec toutes les commandes et les états disponibles.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void tabCommande_Click(object sender, EventArgs e)
        {
            DGVCommande.Rows.Clear(); // Efface les lignes existantes dans le DataGridView

            // Récupère toutes les commandes et les ajoute au DataGridView
            var commandes = DAOCommande.getAllCommande();
            foreach (var commande in commandes)
            {
                DGVCommande.Rows.Add(
                    commande.IdDocument,
                    commande.NomDocument,
                    commande.NbrExemplaire,
                    commande.Etat,
                    commande.DateCommande.Date
                );
            }

            // Met à jour la liste déroulante des états de commande
            CBEtat.Items.Clear();
            var etats = DAOCommande.getAllEtatCommande();
            foreach (var etat in etats)
            {
                CBEtat.Items.Add(etat);
            }
        }

        /// <summary>
        /// Évènement déclenché lorsque l'utilisateur clique sur le bouton de validation de modification de commande.
        /// Met à jour l'état de la commande sélectionnée.
        /// </summary>
        /// <param name="sender">L'objet source qui a déclenché l'évènement.</param>
        /// <param name="e">Les arguments de l'évènement.</param>
        private void BtnValidationModifCommande_Click(object sender, EventArgs e)
        {
            try
            {
                // Met à jour l'état de la commande
                DAOCommande.updateCommande(int.Parse(TBNumeroCommande.Text), CBEtat.SelectedIndex + 1);

                MessageBox.Show("Commande modifiée avec succès"); // Afficher un message de succès

                // Met à jour le DataGridView avec toutes les commandes
                DGVCommande.Rows.Clear();
                var commandes = DAOCommande.getAllCommande();
                foreach (var commande in commandes)
                {
                    DGVCommande.Rows.Add(
                        commande.IdDocument,
                        commande.NomDocument,
                        commande.NbrExemplaire,
                        commande.Etat,
                        commande.DateCommande.Date
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de modification"); // Afficher un message d'erreur en cas de problème
            }
        }
    }
}
