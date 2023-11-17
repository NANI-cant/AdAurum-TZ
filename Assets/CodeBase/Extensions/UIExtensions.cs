using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Extensions {
    public static class UIExtensions {
        public static void Subscribe(this Button button, UnityAction action) => button.onClick.AddListener(action);
        public static void Unsubscribe(this Button button, UnityAction action) => button.onClick.RemoveListener(action);
    }
}