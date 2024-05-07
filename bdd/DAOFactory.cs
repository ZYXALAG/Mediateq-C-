using System;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.metier;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Fournit des méthodes pour créer et gérer la connexion à la base de données MySQL.
    /// </summary>
    class DAOFactory
    {
        /// <summary>
        /// Objet de connexion à la base de données MySQL.
        /// </summary>
        private static MySqlConnection connexion;

        /// <summary>
        /// Crée la connexion à la base de données MySQL avec les paramètres par défaut.
        /// </summary>
        public static void creerConnection()
        {
            string serverIp = "localhost";
            string username = "mediateq-app";
            string password = "root";
            string databaseName = "mediateq-c";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            try
            {
                connexion = new MySqlConnection(dbConnectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur connexion BDD", e.Message);
            }
        }

        /// <summary>
        /// Ouvre la connexion à la base de données MySQL.
        /// </summary>
        public static void connecter()
        {
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionSIO(2, "Problème ouverture connexion BDD", e.Message);
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données MySQL.
        /// </summary>
        public static void deconnecter()
        {
            connexion.Close();
        }

        /// <summary>
        /// Exécute une requête de lecture SQL et retourne un MySqlDataReader.
        /// </summary>
        /// <param name="requete">La requête SQL à exécuter.</param>
        /// <returns>Un objet MySqlDataReader contenant les résultats de la requête.</returns>
        public static MySqlDataReader execSQLRead(string requete)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            return dataReader;
        }

        /// <summary>
        /// Exécute une requête d'écriture (Insert ou Update) sans retour.
        /// </summary>
        /// <param name="requete">La requête SQL à exécuter.</param>
        public static void execSQLWrite(string requete)
        {
            MySqlCommand command;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            command.ExecuteNonQuery();
        }
    }
}
