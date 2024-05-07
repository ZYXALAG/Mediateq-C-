namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente un livre, hérité de la classe <see cref="Document"/>, avec des propriétés spécifiques telles que l'ISBN, l'auteur et la collection.
    /// </summary>
    class Livre : Document
    {
        /// <summary>
        /// Le numéro ISBN du livre.
        /// </summary>
        private string ISBN;

        /// <summary>
        /// Le nom de l'auteur du livre.
        /// </summary>
        private string auteur;

        /// <summary>
        /// Le nom de la collection à laquelle appartient le livre.
        /// </summary>
        private string laCollection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Livre"/> avec un identifiant, un titre, un ISBN, un auteur, une collection, et une image.
        /// </summary>
        /// <param name="unId">L'identifiant du livre.</param>
        /// <param name="unTitre">Le titre du livre.</param>
        /// <param name="unISBN">Le numéro ISBN du livre.</param>
        /// <param name="unAuteur">Le nom de l'auteur du livre.</param>
        /// <param name="uneCollection">Le nom de la collection du livre.</param>
        /// <param name="uneImage">Le chemin ou le nom du fichier de l'image associée au livre.</param>
        public Livre(string unId, string unTitre, string unISBN, string unAuteur, string uneCollection, string uneImage)
            : base(unId, unTitre, uneImage)
        {
            ISBN1 = unISBN;
            Auteur = unAuteur;
            LaCollection = uneCollection;
        }

        /// <summary>
        /// Obtient ou définit le numéro ISBN du livre.
        /// </summary>
        public string ISBN1
        {
            get => ISBN;
            set => ISBN = value;
        }

        /// <summary>
        /// Obtient ou définit le nom de l'auteur du livre.
        /// </summary>
        public string Auteur
        {
            get => auteur;
            set => auteur = value;
        }

        /// <summary>
        /// Obtient ou définit le nom de la collection à laquelle appartient le livre.
        /// </summary>
        public string LaCollection
        {
            get => laCollection;
            set => laCollection = value;
        }
    }
}
