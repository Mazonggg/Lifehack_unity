using System;

namespace Lifehack.Model.Prozess {

    public class Dialog {

        readonly string menueText;
        public string MenueText {
            get { return this.menueText; }
        }
        readonly string anspracheText;
        public string AnspracheText {
            get { return this.anspracheText; }
        }
        readonly string antwortText;
        public string AntwortText {
            get { return this.antwortText; }
        }
        readonly string erfuellungsText;
        public string ErfuellungsText {
            get { return this.erfuellungsText; }
        }
        readonly string scheiternText;
        public string ScheiternText {
            get { return this.scheiternText; }
        }

        public Dialog(
            string menueText,
            string anspracheText,
            string antwortText,
            string erfuellungsText,
            string scheiternText) {

            this.menueText = menueText;
            this.anspracheText = anspracheText;
            this.antwortText = antwortText;
            this.erfuellungsText = erfuellungsText;
            this.scheiternText = scheiternText;
        }

        public override string ToString() {
            return "DIALOG: menueText: " + this.menueText + "; anspracheText: " + this.anspracheText + "; antwortText: " + this.antwortText + "; erfuellungsText: " + this.erfuellungsText + "; scheiternText: " + this.scheiternText + " ";
        }
    }
}
