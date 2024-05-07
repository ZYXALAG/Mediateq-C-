using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe responsable des opérations de base de données liées aux documents tels que les livres, les DVD, les revues, etc.
    /// </summary>
    class DAODocuments
    {
        /// <summary>
        /// Récupère toutes les catégories de la base de données.
        /// </summary>
        /// <returns>Une liste de catégories.</returns>
        public static List<Categorie> getAllCategories()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            try
            {
                string req = "SELECT * FROM public"; // Requête SQL pour obtenir toutes les catégories

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et créer des objets Categorie
                while (reader.Read())
                {
                    Categorie categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
                    lesCategories.Add(categorie);
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return lesCategories; // Retourner la liste des catégories
        }

        /// <summary>
        /// Récupère tous les descripteurs de la base de données.
        /// </summary>
        /// <returns>Une liste de descripteurs.</returns>
        public static List<Descripteur> getAllDescripteurs()
        {
            List<Descripteur> lesDescripteurs = new List<Descripteur>();
            try
            {
                string req = "SELECT * FROM descripteur"; // Requête SQL pour obtenir tous les descripteurs

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et créer des objets Descripteur
                while (reader.Read())
                {
                    Descripteur descripteur = new Descripteur(reader[0].ToString(), reader[1].ToString());
                    lesDescripteurs.Add(descripteur);
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return lesDescripteurs; // Retourner la liste des descripteurs
        }

        /// <summary>
        /// Récupère tous les livres de la base de données.
        /// </summary>
        /// <returns>Une liste de livres.</returns>
        public static List<Livre> getAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();
            try
            {
                string req = "SELECT l.idDocument, l.ISBN, l.auteur, d.titre, d.image, l.collection FROM livre l JOIN document d ON l.idDocument = d.id"; // Requête SQL pour obtenir tous les livres

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et créer des objets Livre
                while (reader.Read())
                {
                    Livre livre = new Livre(
                        reader[0].ToString(),
                        reader[3].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[5].ToString(),
                        reader[4].ToString()
                    );
                    lesLivres.Add(livre);
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return lesLivres; // Retourner la liste des livres
        }

        /// <summary>
        /// Récupère la catégorie associée à un livre spécifique.
        /// </summary>
        /// <param name="pLivre">Le livre pour lequel obtenir la catégorie.</param>
        /// <returns>Un objet <see cref="Categorie"/> ou <c>null</c> si la catégorie n'est pas trouvée.</returns>
        public static Categorie getCategorieByLivre(Livre pLivre)
        {
            Categorie categorie;
            try
            {
                string req = "SELECT p.id, p.libelle FROM public p, document d WHERE p.id = d.idPublic AND d.id = '" + pLivre.IdDoc + "'"; // Requête SQL pour obtenir la catégorie associée au livre

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                if (reader.Read()) // Vérifie si des données sont présentes
                {
                    categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
                }
                else
                {
                    categorie = null; // Retourne null si aucune catégorie n'est trouvée
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return categorie; // Retourner la catégorie trouvée ou null
        }

        /// <summary>
        /// Récupère tous les DVD de la base de données.
        /// </summary>
        /// <returns>Une liste de DVD.</returns>
        public static List<DVD> getAllDVD()
        {
            List<DVD> lesDVD = new List<DVD>();
            try
            {
                string req = "SELECT d.idDocument, d.synopsis, d.réalisateur, doc.titre, doc.image, d.duree FROM dvd d JOIN document doc ON d.idDocument = doc.id"; // Requête SQL pour obtenir tous les DVD

                DAOFactory.connecter(); // Connexion à la base de données

                MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

                // Boucle pour lire les résultats et créer des objets DVD
                while (reader.Read())
                {
                    DVD dvd = new DVD(
                        reader[0].ToString(),
                        reader[3].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        Int32.Parse(reader[5].ToString()),
                        reader[4].ToString()
                    );
                    lesDVD.Add(dvd);
                }

                DAOFactory.deconnecter(); // Déconnexion de la base de données
            }
            catch (Exception exc)
            {
                throw exc; // Relancer l'exception en cas d'erreur
            }
            return lesDVD; // Retourner la liste des DVD
        }

        /// <summary>
        /// Ajoute une nouvelle revue dans la base de données.
        /// </summary>
        /// <param name="titre">Le titre de la revue.</param>
        /// <param name="empruntable">Indique si la revue est empruntable.</param>
        /// <param name="periodicite">La périodicité de la revue.</param>
        /// <param name="delaisDispo">Le délai de mise à disposition de la revue.</param>
        /// <param name="dateFinAbo">La date de fin d'abonnement.</param>
        /// <param name="idDescripteur">L'identifiant du descripteur associé à la revue.</param>
        /// <returns>Vrai si l'ajout a réussi, sinon faux.</returns>
        public static bool ajoutRevue(string titre, string empruntable, string periodicite, int delaisDispo, DateTime dateFinAbo, int idDescripteur)
        {
            try
            {
                // Requête SQL pour ajouter une nouvelle revue
                string req = $"INSERT INTO revue (titre, empruntable, periodicite, delai_miseadispo, dateFinAbonnement, idDescripteur) " +
                             $"VALUES ('{titre}', '{empruntable}', '{periodicite}', {delaisDispo}, '{dateFinAbo.ToString("yyyy-MM-dd")}', {idDescripteur})";

                DAOFactory.connecter(); // Connexion à la base de données

                DAOFactory.execSQLWrite(req); // Exécution de la requête d'écriture

                DAOFactory.deconnecter(); // Déconnexion de la base de données

                return true; // Retourne vrai si l'ajout a réussi
            }
            catch
            {
                return false; // Retourne faux en cas d'erreur
            }
            finally
            {
                DAOFactory.deconnecter(); // Assurez-vous de déconnecter de la base de données
            }
        }

        /// <summary>
        /// Récupère une revue par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la revue.</param>
        /// <returns>Un objet <see cref="Revue"/> si trouvé, sinon <c>null</c>.</returns>
        public static Revue getRevueById(int id)
        {
            try
            {
                // Requête SQL pour obtenir une revue par son identifiant
                string req = "SELECT * FROM revue WHERE id = " + id;

                DAOFactory.connecter(); // Connexion à la base de données

                using (MySqlDataReader reader = DAOFactory.execSQLRead(req))
                {
                    if (reader.Read())
                    {
                        // Récupérer les détails de la revue
                        DateTime dateFinAbonnement = DateTime.Parse(reader["dateFinAbonnement"].ToString());
                        string revueId = reader["id"].ToString();
                        string titre = reader["titre"].ToString();
                        string empruntable = reader["empruntable"].ToString();
                        string periodicite = reader["periodicite"].ToString();
                        int delaiMiseADispo = int.Parse(reader["delai_miseadispo"].ToString());
                        string idDescripteur = reader["idDescripteur"].ToString();

                        Revue revue = new Revue(revueId, titre, empruntable, periodicite, dateFinAbonnement, delaiMiseADispo, idDescripteur);
                        return revue; // Retourner la revue trouvée
                    }
                    return null; // Retourner null si aucune revue n'est trouvée
                }
            }
            catch (Exception ex)
            {
                return null; // Retourner null en cas d'erreur
            }
            finally
            {
                DAOFactory.deconnecter(); // Assurez-vous de déconnecter de la base de données
            }
        }

        /// <summary>
        /// Renouvelle l'abonnement d'une revue pour un nombre de mois donné.
        /// </summary>
        /// <param name="id">L'identifiant de la revue à renouveler.</param>
        /// <param name="nbMois">Le nombre de mois pour lequel renouveler l'abonnement.</param>
        /// <returns>Vrai si le renouvellement a réussi, sinon faux.</returns>
        public static bool renouvellement(string id, string nbMois)
        {
            try
            {
                // Requête SQL pour renouveler l'abonnement
                string req = "UPDATE revue SET dateFinAbonnement = DATE_ADD(dateFinAbonnement, INTERVAL " + nbMois + " MONTH) WHERE id = " + id;

                DAOFactory.connecter(); // Connexion à la base de données

                DAOFactory.execSQLWrite(req); // Exécution de la requête d'écriture

                return true; // Retourne vrai si le renouvellement a réussi
            }
            catch
            {
                return false; // Retourne faux en cas d'erreur
            }
            finally
            {
                DAOFactory.deconnecter(); // Assurez-vous de déconnecter de la base de données
            }
        }
    }
}
