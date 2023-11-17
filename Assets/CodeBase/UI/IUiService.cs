using UnityEngine;

namespace CodeBase.UI {
    public interface IUiService {
        void SetRoot(Canvas uiRoot);
        TScreen OpenScreen<TScreen>() where TScreen: MonoBehaviour;
        void CloseScreen(MonoBehaviour screen);
    }
}