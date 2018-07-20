using System;

namespace Lifehack.Model.Prozess {
    
    public class Dialog {

        private string menueText;
        public string MenueText {
            get { return this.menueText; }
        }
        private string anspracheText;
        public string AnspracheText {
            get { return this.anspracheText; }
        }
        private string antwortText;
        public string AntwortText {
            get { return this.antwortText; }
        }
        private string erfuellungsText;
        public string ErfuellungsText {
            get { return this.erfuellungsText; }
        }
        private string scheiternText;
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
    }
}
