using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une parution, c'est-à-dire une édition d'une revue ou d'un magazine.
    /// </summary>
    class Parution
    {
        /// <summary>
        /// Le numéro de la parution.
        /// </summary>
        private int numero;

        /// <summary>
        /// La date de la parution.
        /// </summary>
        private DateTime dateParution;

        /// <summary>
        /// Le chemin ou le nom du fichier de la photo associée à la parution.
        /// </summary>
        private string photo;

        /// <summary>
        /// L'identifiant de la revue à laquelle la parution appartient.
        /// </summary>
        private string idRevue;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Parution"/> avec un numéro, une date de parution, une photo, et un identifiant de revue.
        /// </summary>
        /// <param name="numero">Le numéro de la parution.</param>
        /// <param name="dateParution">La date de la parution.</param>
        /// <param name="photo">Le chemin ou le nom du fichier de la photo associée à la parution.</param>
        /// <param name="idRevue">L'identifiant de la revue à laquelle la parution appartient.</param>
        public Parution(int numero, DateTime dateParution, string photo, string idRevue)
        {
            this.numero = numero;
            this.dateParution = dateParution;
            this.photo = photo;
            this.idRevue = idRevue;
        }

        /// <summary>
        /// Obtient ou définit le numéro de la parution.
        /// </summary>
        public int Numero
        {
            get => numero;
            set => numero = value;
        }

        /// <summary>
        /// Obtient ou définit la date de la parution.
        /// </summary>
        public DateTime DateParution
        {
            get => dateParution;
            set => dateParution = value;
        }

        /// <summary>
        /// Obtient ou définit le chemin ou le nom du fichier de la photo associée à la parution.
        /// </summary>
        public string Photo
        {
            get => photo;
            set => photo = value;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la revue à laquelle la parution appartient.
        /// </summary>
        public string IdRevue
        {
            get => idRevue;
            set => idRevue = value;
        }
    }
}
