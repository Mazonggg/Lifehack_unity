using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model {

    public abstract class DatenbankEintrag : IDatenbankEintrag {

        private int id;
        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public DatenbankEintrag() { }

        abstract public T Tabelle<T>() where T : struct, IConvertible;
    }
}

