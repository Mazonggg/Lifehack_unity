
namespace Lifehack.Model.Konstanten {
    public static class StringHelfer {
        public static string Ucfirst(string zeichenkette) {
            return char.ToUpper(zeichenkette[0]) + zeichenkette.Substring(1);
        }
    }
}

