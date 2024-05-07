namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un document avec des propriétés telles que l'identifiant, le titre, l'image, et la catégorie.
    /// </summary>
    class Document
    {
        /// <summary>
        /// L'identifiant unique du document.
        /// </summary>
        private string idDoc;

        /// <summary>
        /// Le titre du document.
        /// </summary>
        private string titre;

        /// <summary>
        /// Le chemin ou le nom du fichier de l'image associée au document.
        /// </summary>
        private string image;

        /// <summary>
        /// La catégorie du document.
        /// </summary>
        private string laCategorie;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Document"/> avec un identifiant, un titre, et une image.
        /// </summary>
        /// <param name="unId">L'identifiant du document.</param>
        /// <param name="unTitre">Le titre du document.</param>
        /// <param name="uneImage">Le chemin ou le nom du fichier de l'image associée au document.</param>
        public Document(string unId, string unTitre, string uneImage)
        {
            idDoc = unId;
            titre = unTitre;
            image = uneImage;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du document.
        /// </summary>
        public string IdDoc
        {
            get => idDoc;
            set => idDoc = value;
        }

        /// <summary>
        /// Obtient ou définit le titre du document.
        /// </summary>
        public string Titre
        {
            get => titre;
            set => titre = value;
        }

        /// <summary>
        /// Obtient ou définit le chemin ou le nom du fichier de l'image associée au document.
        /// </summary>
        public string Image
        {
            get => image;
            set => image = value;
        }

        /// <summary>
        /// Obtient ou définit la catégorie du document.
        /// </summary>
        public string LaCategorie
        {
            get => laCategorie;
            set => laCategorie = value;
        }
    }
}
