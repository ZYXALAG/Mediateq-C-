using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un utilisateur avec des détails tels que l'identifiant, le login, le mot de passe, le nom, le prénom et l'identifiant du service.
    /// </summary>
    class User
    {
        /// <summary>
        /// L'identifiant unique de l'utilisateur.
        /// </summary>
        private int id;

        /// <summary>
        /// Le login de l'utilisateur.
        /// </summary>
        private string login;

        /// <summary>
        /// Le mot de passe de l'utilisateur.
        /// </summary>
        private string password;

        /// <summary>
        /// Le nom de l'utilisateur.
        /// </summary>
        private string nom;

        /// <summary>
        /// Le prénom de l'utilisateur.
        /// </summary>
        private string prenom;

        /// <summary>
        /// L'identifiant du service auquel l'utilisateur est associé.
        /// </summary>
        private int id_service;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="User"/> avec des détails spécifiques.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur.</param>
        /// <param name="login">Le login de l'utilisateur.</param>
        /// <param name="password">Le mot de passe de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="id_service">L'identifiant du service auquel l'utilisateur est associé.</param>
        public User(int id, string login, string password, string nom, string prenom, int id_service)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.prenom = prenom;
            this.id_service = id_service;
        }

        /// <summary>
        /// Retourne l'identifiant de l'utilisateur.
        /// </summary>
        /// <returns>L'identifiant de l'utilisateur.</returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Retourne le login de l'utilisateur.
        /// </summary>
        /// <returns>Le login de l'utilisateur.</returns>
        public string getLogin()
        {
            return login;
        }

        /// <summary>
        /// Retourne le mot de passe de l'utilisateur.
        /// </summary>
        /// <returns>Le mot de passe de l'utilisateur.</returns>
        public string getPassword()
        {
            return password;
        }

        /// <summary>
        /// Retourne le nom de l'utilisateur.
        /// </summary>
        /// <returns>Le nom de l'utilisateur.</returns>
        public string getNom()
        {
            return nom;
        }

        /// <summary>
        /// Retourne le prénom de l'utilisateur.
        /// </summary>
        /// <returns>Le prénom de l'utilisateur.</returns>
        public string getPrenom()
        {
            return prenom;
        }

        /// <summary>
        /// Retourne l'identifiant du service associé à l'utilisateur.
        /// </summary>
        /// <returns>L'identifiant du service.</returns>
        public int getId_Service()
        {
            return id_service;
        }
    }
}
