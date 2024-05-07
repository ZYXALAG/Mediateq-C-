using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un descripteur avec un identifiant et un libellé.
    /// </summary>
    class Descripteur
    {
        /// <summary>
        /// L'identifiant du descripteur.
        /// </summary>
        private string id;

        /// <summary>
        /// Le libellé du descripteur.
        /// </summary>
        private string libelle;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Descripteur"/> avec un identifiant et un libellé.
        /// </summary>
        /// <param name="id">L'identifiant du descripteur.</param>
        /// <param name="libelle">Le libellé du descripteur.</param>
        public Descripteur(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du descripteur.
        /// </summary>
        public string Id
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Obtient ou définit le libellé du descripteur.
        /// </summary>
        public string Libelle
        {
            get => libelle;
            set => libelle = value;
        }
    }
}
