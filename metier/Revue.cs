using System;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une revue ou un magazine avec des détails tels que l'identifiant, le titre, l'empruntabilité, la périodicité, la date de fin d'abonnement, et d'autres propriétés.
    /// </summary>
    public class Revue
    {
        /// <summary>
        /// L'identifiant unique de la revue.
        /// </summary>
        private string id;

        /// <summary>
        /// Le titre de la revue.
        /// </summary>
        private string titre;

        /// <summary>
        /// Indique si la revue est empruntable ("oui" ou "non").
        /// </summary>
        private string empruntable;

        /// <summary>
        /// La périodicité de la revue (par exemple, "mensuelle", "hebdomadaire").
        /// </summary>
        private string periodicite;

        /// <summary>
        /// La date à laquelle l'abonnement à la revue prend fin.
        /// </summary>
        private DateTime dateFinAbonnement;

        /// <summary>
        /// Le délai avant que la revue soit disponible après sa parution, en jours.
        /// </summary>
        private int delaiMiseADispo;

        /// <summary>
        /// L'identifiant du descripteur associé à la revue.
        /// </summary>
        private string idDescripteur;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Revue"/> avec des informations spécifiques.
        /// </summary>
        /// <param name="id">L'identifiant de la revue.</param>
        /// <param name="titre">Le titre de la revue.</param>
        /// <param name="empruntable">Indique si la revue est empruntable.</param>
        /// <param name="periodicite">La périodicité de la revue.</param>
        /// <param name="dateFinAbonnement">La date de fin de l'abonnement.</param>
        /// <param name="delaiMiseADispo">Le délai avant que la revue soit disponible après sa parution.</param>
        /// <param name="idDescripteur">L'identifiant du descripteur associé à la revue.</param>
        public Revue(string id, string titre, string empruntable, string periodicite, DateTime dateFinAbonnement, int delaiMiseADispo, string idDescripteur)
        {
            this.id = id;
            this.titre = titre;
            this.empruntable = empruntable;
            this.periodicite = periodicite;
            this.dateFinAbonnement = dateFinAbonnement;
            this.delaiMiseADispo = delaiMiseADispo;
            this.idDescripteur = idDescripteur;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la revue.
        /// </summary>
        public string Id
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Obtient ou définit le titre de la revue.
        /// </summary>
        public string Titre
        {
            get => titre;
            set => titre = value;
        }

        /// <summary>
        /// Obtient ou définit si la revue est empruntable.
        /// </summary>
        public string Empruntable
        {
            get => empruntable;
            set => empruntable = value;
        }

        /// <summary>
        /// Obtient ou définit la périodicité de la revue.
        /// </summary>
        public string Periodicite
        {
            get => periodicite;
            set => periodicite = value;
        }

        /// <summary>
        /// Obtient ou définit la date de fin de l'abonnement à la revue.
        /// </summary>
        public DateTime DateFinAbonnement
        {
            get => dateFinAbonnement;
            set => dateFinAbonnement = value;
        }

        /// <summary>
        /// Obtient ou définit le délai de mise à disposition de la revue, en jours.
        /// </summary>
        public int DelaiMiseADispo
        {
            get => delaiMiseADispo;
            set => delaiMiseADispo = value;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du descripteur associé à la revue.
        /// </summary>
        public string IdDescripteur
        {
            get => idDescripteur;
            set => idDescripteur = value;
        }
    }
}
