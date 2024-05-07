using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Représente une exception personnalisée pour le système SIO avec des niveaux de gravité et des libellés spécifiques.
    /// </summary>
    class ExceptionSIO : Exception
    {
        /// <summary>
        /// Le niveau de gravité de l'exception.
        /// </summary>
        private int niveauExc;

        /// <summary>
        /// Le libellé ou la description de l'exception.
        /// </summary>
        private string libelleExc;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ExceptionSIO"/> avec un niveau de gravité, un libellé, et un message d'exception.
        /// </summary>
        /// <param name="pNiveau">Le niveau de gravité de l'exception.</param>
        /// <param name="pLibelle">Le libellé ou la description de l'exception.</param>
        /// <param name="pMessage">Le message de l'exception.</param>
        public ExceptionSIO(int pNiveau, string pLibelle, string pMessage)
            : base(pMessage)
        {
            niveauExc = pNiveau;
            libelleExc = pLibelle;
        }

        /// <summary>
        /// Obtient ou définit le niveau de gravité de l'exception.
        /// </summary>
        public int NiveauExc
        {
            get => niveauExc;
            set => niveauExc = value;
        }

        /// <summary>
        /// Obtient ou définit le libellé ou la description de l'exception.
        /// </summary>
        public string LibelleExc
        {
            get => libelleExc;
            set => libelleExc = value;
        }
    }
}
