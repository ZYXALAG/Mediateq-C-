namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un DVD, héritant de la classe <see cref="Document"/>, avec des propriétés supplémentaires telles que le synopsis, le réalisateur, et la durée.
    /// </summary>
    class DVD : Document
    {
        /// <summary>
        /// Le synopsis du DVD.
        /// </summary>
        private string synopsis;

        /// <summary>
        /// Le nom du réalisateur du DVD.
        /// </summary>
        private string realisateur;

        /// <summary>
        /// La durée du DVD, en minutes.
        /// </summary>
        private int duree;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DVD"/> avec un identifiant, un titre, un synopsis, un réalisateur, une durée, et une image.
        /// </summary>
        /// <param name="unId">L'identifiant du DVD.</param>
        /// <param name="unTitre">Le titre du DVD.</param>
        /// <param name="unSynopsis">Le synopsis du DVD.</param>
        /// <param name="unRealisateur">Le réalisateur du DVD.</param>
        /// <param name="uneDuree">La durée du DVD en minutes.</param>
        /// <param name="uneImage">Le chemin ou le nom du fichier de l'image associée au DVD.</param>
        public DVD(string unId, string unTitre, string unSynopsis, string unRealisateur, int uneDuree, string uneImage)
            : base(unId, unTitre, uneImage)
        {
            this.synopsis = unSynopsis;
            this.realisateur = unRealisateur;
            this.duree = uneDuree;
        }

        /// <summary>
        /// Obtient ou définit le synopsis du DVD.
        /// </summary>
        public string Synopsis
        {
            get => synopsis;
            set => synopsis = value;
        }

        /// <summary>
        /// Obtient ou définit le nom du réalisateur du DVD.
        /// </summary>
        public string Realisateur
        {
            get => realisateur;
            set => realisateur = value;
        }

        /// <summary>
        /// Obtient ou définit la durée du DVD en minutes.
        /// </summary>
        public int Duree
        {
            get => duree;
            set => duree = value;
        }
    }
}
