using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Mediateq_AP_SIO2;
using MySql.Data.MySqlClient;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe responsable des opérations de connexion et d'inscription des utilisateurs.
    /// </summary>
    class DAOConnexion
    {
        /// <summary>
        /// Inscrit un nouvel utilisateur dans la base de données avec un login, un mot de passe haché et salé, un prénom, un nom, et un identifiant de service.
        /// </summary>
        /// <param name="login">Le login de l'utilisateur.</param>
        /// <param name="password">Le mot de passe en clair de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="idService">L'identifiant du service associé à l'utilisateur.</param>
        /// <returns>Vrai si l'inscription a réussi, sinon faux.</returns>
        public static bool InscrireUser(string login, string password, string prenom, string nom, int idService)
        {
            DAOFactory.connecter(); // Connexion à la base de données

            // Génère un sel et hache le mot de passe avec ce sel
            string salt = Hash.GenerateSalt();
            string hashedPassword = Hash.HashPassword(password, salt);

            try
            {
                // Requête SQL pour insérer un nouvel utilisateur
                string query = "INSERT INTO utilisateurs (id_utilisateur, login, mot_de_passe, salt, nom, prenom, service) " +
                               "VALUES (" + 0 + ",'" + login + "', '" + hashedPassword + "', '" + salt + "', '" + nom + "', '" + prenom + "', " + idService + ")";
                DAOFactory.execSQLWrite(query); // Exécution de la requête d'écriture
                return true; // Retourne vrai si l'inscription a réussi
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
        /// Vérifie si un utilisateur avec le login donné et le mot de passe correspondant existe dans la base de données.
        /// </summary>
        /// <param name="login">Le login de l'utilisateur à vérifier.</param>
        /// <param name="password">Le mot de passe en clair de l'utilisateur à vérifier.</param>
        /// <returns>Un objet <see cref="User"/> si l'utilisateur est trouvé et le mot de passe correspond, sinon <c>null</c>.</returns>
        public static User verifUser(string login, string password)
        {
            DAOFactory.connecter(); // Connexion à la base de données

            // Requête SQL pour trouver l'utilisateur avec le login donné
            string query = "SELECT id_utilisateur, login, mot_de_passe, salt, nom, prenom, service.id_service FROM utilisateurs JOIN service ON service.id_service = utilisateurs.service WHERE login = '" + login + "';";

            MySqlDataReader reader = DAOFactory.execSQLRead(query); // Exécution de la requête de lecture

            if (reader.Read())
            {
                // Hacher le mot de passe donné avec le sel de la base de données
                string hashedPassword = Hash.HashPassword(password, reader["salt"].ToString());

                // Vérifier si le mot de passe haché correspond au mot de passe stocké
                if (hashedPassword == reader["mot_de_passe"].ToString())
                {
                    // Créer un objet User pour l'utilisateur connecté
                    User connectedUser = new User(
                        Convert.ToInt32(reader["id_utilisateur"]),
                        reader["login"].ToString(),
                        reader["mot_de_passe"].ToString(),
                        reader["nom"].ToString(),
                        reader["prenom"].ToString(),
                        Convert.ToInt32(reader["id_service"])
                    );

                    DAOFactory.deconnecter(); // Déconnexion de la base de données
                    return connectedUser; // Retourner l'utilisateur connecté
                }
                else
                {
                    DAOFactory.deconnecter(); // Déconnexion de la base de données
                    return null; // Le mot de passe ne correspond pas
                }
            }
            else
            {
                DAOFactory.deconnecter(); // Déconnexion de la base de données
                return null; // L'utilisateur n'a pas été trouvé
            }
        }
    }
}
