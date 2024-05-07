using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Fournit des méthodes pour générer des valeurs de sel et pour hacher des mots de passe avec des algorithmes cryptographiques.
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Génère un sel cryptographique de la longueur spécifiée.
        /// </summary>
        /// <param name="length">La longueur du sel à générer. Par défaut, 16 octets.</param>
        /// <returns>Le sel généré, encodé en Base64.</returns>
        public static string GenerateSalt(int length = 16)
        {
            byte[] salt = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Génère des octets aléatoires pour le sel
            }
            return Convert.ToBase64String(salt); // Retourne le sel sous forme de chaîne encodée en Base64
        }

        /// <summary>
        /// Hache un mot de passe avec le sel spécifié en utilisant l'algorithme SHA-256.
        /// </summary>
        /// <param name="password">Le mot de passe à hacher.</param>
        /// <param name="salt">Le sel à utiliser pour le hachage, encodé en Base64.</param>
        /// <returns>Le hachage du mot de passe et du sel, encodé en Base64.</returns>
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt); // Convertit le sel Base64 en tableau d'octets

            using (var sha256 = new SHA256Managed()) // Utilisation de SHA-256 pour le hachage
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password); // Convertit le mot de passe en octets
                byte[] saltedPassword = new byte[passwordBytes.Length + saltBytes.Length]; // Crée un tableau pour le mot de passe salé

                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length); // Copie le mot de passe dans le tableau
                Buffer.BlockCopy(saltBytes, 0, saltedPassword, passwordBytes.Length, saltBytes.Length); // Copie le sel dans le tableau

                byte[] hash = sha256.ComputeHash(saltedPassword); // Calcule le hachage

                return Convert.ToBase64String(hash); // Retourne le hachage sous forme de chaîne encodée en Base64
            }
        }
    }
}
