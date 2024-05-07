using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.metier;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe responsable des opérations de base de données liées à la presse, telles que les revues et les parutions.
    /// </summary>
    class DAOPresse
    {
        /// <summary>
        /// Récupère toutes les revues de la base de données.
        /// </summary>
        /// <returns>Une liste de revues.</returns>
        public static List<Revue> getAllRevues()
        {
            List<Revue> lesRevues = new List<Revue>();
            string req = "SELECT * FROM revue"; // Requête SQL pour obtenir toutes les revues

            DAOFactory.connecter(); // Connexion à la base de données

            MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

            // Boucle pour lire les résultats et créer des objets Revue
            while (reader.Read())
            {
                Revue revue = new Revue(
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    DateTime.Parse(reader[5].ToString()),
                    int.Parse(reader[4].ToString()),
                    reader[6].ToString()
                );
                lesRevues.Add(revue);
            }

            DAOFactory.deconnecter(); // Déconnexion de la base de données

            return lesRevues; // Retourner la liste des revues
        }
        
        /// <summary>
        /// Récupère toutes les parutions associées à une revue spécifique.
        /// </summary>
        /// <param name="pTitre">La revue pour laquelle obtenir les parutions.</param>
        /// <returns>Une liste de parutions.</returns>
        public static List<Parution> getParutionByTitre(Revue pTitre)
        {
            List<Parution> lesParutions = new List<Parution>();
            string req = "SELECT * FROM parution WHERE idRevue = " + pTitre.Id; // Requête SQL pour obtenir toutes les parutions associées à une revue

            DAOFactory.connecter(); // Connexion à la base de données

            MySqlDataReader reader = DAOFactory.execSQLRead(req); // Exécution de la requête de lecture

            // Boucle pour lire les résultats et créer des objets Parution
            while (reader.Read())
            {
                Parution parution = new Parution(
                    int.Parse(reader[1].ToString()),
                    DateTime.Parse(reader[2].ToString()),
                    reader[3].ToString(),
                    pTitre.Id
                );
                lesParutions.Add(parution);
            }

            DAOFactory.deconnecter(); // Déconnexion de la base de données

            return lesParutions; // Retourner la liste des parutions
        }
    }
}
