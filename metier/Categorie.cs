namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une catégorie avec un identifiant et un libellé.
    /// </summary>
    class Categorie
    {
        /// <summary>
        /// L'identifiant unique de la catégorie.
        /// </summary>
        private string id;

        /// <summary>
        /// Le libellé de la catégorie.
        /// </summary>
        private string libelle;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Categorie"/> avec un identifiant et un libellé.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie.</param>
        /// <param name="libelle">Le libellé de la catégorie.</param>
        public Categorie(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la catégorie.
        /// </summary>
        public string Id
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Obtient ou définit le libellé de la catégorie.
        /// </summary>
        public string Libelle
        {
            get => libelle;
            set => libelle = value;
        }
    }
}
