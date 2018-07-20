
using SimpleJSON;

namespace Lifehack.Model.Fabrik {

    public interface IDatenbankEintragFabrik<T> where T : IDatenbankEintrag {

        T ErzeugeDantebankEintrag(JSONObject json);
    }
}
