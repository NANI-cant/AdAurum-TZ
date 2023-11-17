using UnityEngine;

namespace CodeBase.Infrastructure.Impl {
    public class UnityDestroyService : IDestroyService {
        public void Destroy(GameObject gameObject, float delay = 0) => GameObject.Destroy(gameObject, delay);
    }
}