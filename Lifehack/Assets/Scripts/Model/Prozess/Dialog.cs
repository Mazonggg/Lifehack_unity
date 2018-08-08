
namespace Lifehack.Model.Prozess {

    public class Dialog {

        string menueText;
        public string MenueText {
            get { return this.menueText; }
            set { this.menueText = value; }
        }
        string anspracheText;
        public string AnspracheText {
            get { return this.anspracheText; }
            set { this.anspracheText = value; }
        }
        string antwortText;
        public string AntwortText {
            get { return this.antwortText; }
            set { this.antwortText = value; }
        }
        string erfuellungsText;
        public string ErfuellungsText {
            get { return this.erfuellungsText; }
            set { this.erfuellungsText = value; }
        }
        string scheiternText;
        public string ScheiternText {
            get { return this.scheiternText; }
            set { this.scheiternText = value; }
        }

        public override string ToString() {
            return "DIALOG: menueText: " + this.menueText + "; anspracheText: " + this.anspracheText + "; antwortText: " + this.antwortText + "; erfuellungsText: " + this.erfuellungsText + "; scheiternText: " + this.scheiternText + " ";
        }
    }
}
