using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe responsable des opérations de base de données liées aux commandes.
    /// </summary>
    class DAOCommande
    {
        /// <summary>
        /// Récupère toutes les commandes de la base de données.
        /// </summary>
        /// <returns>Une liste de commandes.</returns>
        public static List<Commande> getAllCommande()
        {
            List<Commande> LesCommandes = new List<Commande>();
            try
            {
                // Requête SQL pour récupérer toutes les commandes avec leur état.
                string req = "SELECT commande.id, nomDoc, nbExemplaire, libelle, dateCommande FROM commande JOIN etat_commande on commande.etat = etat_commande.id";

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et ajouter les commandes à la liste
                while (reader.Read())
                {
                    int id_commande = reader.GetInt32(0);
                    string nomDocument = reader.GetString(1);
                    int nbrExemplaire = reader.GetInt32(2);
                    string etat = reader.GetString(3);
                    DateTime dateCommande = reader.GetDateTime(4);

                    Commande commande = new Commande(id_commande, nomDocument, nbrExemplaire, etat, dateCommande);

                    LesCommandes.Add(commande);
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return LesCommandes; // Retourner la liste des commandes
        }

        /// <summary>
        /// Récupère tous les états des commandes de la base de données.
        /// </summary>
        /// <returns>Une liste des états de commande.</returns>
        public static List<string> getAllEtatCommande()
        {
            List<string> LesEtats = new List<string>();
            try
            {
                // Requête SQL pour récupérer tous les états des commandes.
                string req = "SELECT * FROM etat_commande";

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et ajouter les états à la liste
                while (reader.Read())
                {
                    string etat = reader.GetString(1); // Lecture de l'état

                    LesEtats.Add(etat); // Ajouter à la liste des états
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return LesEtats; // Retourner la liste des états
        }

        /// <summary>
        /// Ajoute une nouvelle commande dans la base de données.
        /// </summary>
        /// <param name="nomDoc">Le nom du document à commander.</param>
        /// <param name="nbrExemplaire">Le nombre d'exemplaires à commander.</param>
        /// <returns>Vrai si l'ajout a réussi, sinon faux.</returns>
        public static bool ajoutCommande(string nomDoc, int nbrExemplaire)
        {
            try
            {
                // Requête SQL pour ajouter une nouvelle commande.
                String req = "INSERT INTO commande (nomDoc, nbExemplaire, etat, dateCommande) VALUES ('" + nomDoc + "', " + nbrExemplaire + ", 1, CURDATE());";

                DAOFactory.connecter(); // Connexion à la base de données

                DAOFactory.execSQLWrite(req); // Exécution de la requête d'écriture

                DAOFactory.deconnecter(); // Déconnexion de la base de données

                return true; // Retourne vrai si l'ajout a réussi
            }
            catch
            {
                DAOFactory.deconnecter(); // Assurez-vous de déconnecter en cas d'erreur
                return false; // Retourne faux si une erreur s'est produite
            }
        }

        /// <summary>
        /// Met à jour l'état d'une commande dans la base de données.
        /// </summary>
        /// <param name="id">L'identifiant de la commande à mettre à jour.</param>
        /// <param name="etat">Le nouvel état de la commande.</param>
        /// <returns>Vrai si la mise à jour a réussi, sinon faux.</returns>
        public static bool updateCommande(int id, int etat)
        {
            try
            {
                // Requête SQL pour mettre à jour l'état d'une commande.
                String req = "UPDATE commande SET etat = " + etat + " WHERE id = " + id + " ;";

                DAOFactory.connecter(); // Connexion à la base de données

                DAOFactory.execSQLWrite(req); // Exécution de la requête d'écriture

                DAOFactory.deconnecter(); // Déconnexion de la base de données

                return true; // Retourne vrai si la mise à jour a réussi
            }
            catch
            {
                DAOFactory.deconnecter(); // Assurez-vous de déconnecter en cas d'erreur
                return false; // Retourne faux si une erreur s'est produite
            }
        }
    }
}
