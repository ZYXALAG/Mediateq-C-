using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une commande de documents avec des détails sur le document, le nombre d'exemplaires, l'état, et la date de commande.
    /// </summary>
    class Commande
    {
        /// <summary>
        /// L'identifiant du document associé à la commande.
        /// </summary>
        private int id_document;

        /// <summary>
        /// Le nom du document associé à la commande.
        /// </summary>
        private string nomDocument;

        /// <summary>
        /// Le nombre d'exemplaires commandés.
        /// </summary>
        private int nbrExemplaire;

        /// <summary>
        /// L'état de la commande (par exemple, "En cours", "Livrée").
        /// </summary>
        private string etat;

        /// <summary>
        /// La date à laquelle la commande a été passée.
        /// </summary>
        private DateTime dateCommande;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Commande"/> avec les détails de la commande.
        /// </summary>
        /// <param name="id_document">L'identifiant du document.</param>
        /// <param name="nomDocument">Le nom du document.</param>
        /// <param name="nbrExemplaire">Le nombre d'exemplaires commandés.</param>
        /// <param name="etat">L'état de la commande.</param>
        /// <param name="dateCommande">La date de la commande.</param>
        public Commande(int id_document, string nomDocument, int nbrExemplaire, string etat, DateTime dateCommande)
        {
            this.id_document = id_document;
            this.nomDocument = nomDocument;
            this.nbrExemplaire = nbrExemplaire;
            this.etat = etat;
            this.dateCommande = dateCommande;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du document associé à la commande.
        /// </summary>
        public int IdDocument
        {
            get => id_document;
            set => id_document = value;
        }

        /// <summary>
        /// Obtient ou définit le nom du document associé à la commande.
        /// </summary>
        public string NomDocument
        {
            get => nomDocument;
            set => nomDocument = value;
        }

        /// <summary>
        /// Obtient ou définit le nombre d'exemplaires commandés.
        /// </summary>
        public int NbrExemplaire
        {
            get => nbrExemplaire;
            set => nbrExemplaire = value;
        }

        /// <summary>
        /// Obtient ou définit l'état de la commande.
        /// </summary>
        public string Etat
        {
            get => etat;
            set => etat = value;
        }

        /// <summary>
        /// Obtient ou définit la date de la commande.
        /// </summary>
        public DateTime DateCommande
        {
            get => dateCommande;
            set => dateCommande = value;
        }
    }
}
