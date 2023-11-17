using UnityEngine;

namespace CodeBase.Extensions {
    public static class GameObjectExtensions {
        public static void Activate(this GameObject gameObject) => gameObject.SetActive(true);
        public static void Deactivate(this GameObject gameObject) => gameObject.SetActive(false);

        public static void Enable(this Behaviour component) => component.enabled = true;
        public static void Disable(this Behaviour component) => component.enabled = false;
    }
}