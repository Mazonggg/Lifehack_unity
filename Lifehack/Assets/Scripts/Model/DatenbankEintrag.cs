using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model {
    
    public abstract class DatenbankEintrag {

        private int id; 
        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }

        protected DatenbankEintrag(int id ) {
            this.id = id;
        }

        abstract public TabellenName Tabelle();
    }
}

