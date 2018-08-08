
namespace Lifehack.Model.Prozess {
    public class SimpleDiaglogFabrik {

        public static Dialog ErzeugeDialog(
            string menueText,
            string anspracheText,
            string antwortText,
            string erfuellungsText,
            string scheiternText) {

            var dialog = new Dialog();
            dialog.MenueText = menueText;
            dialog.AnspracheText = anspracheText;
            dialog.AntwortText = antwortText;
            dialog.ErfuellungsText = erfuellungsText;
            dialog.ScheiternText = scheiternText;

            return dialog;
        }
    }
}

