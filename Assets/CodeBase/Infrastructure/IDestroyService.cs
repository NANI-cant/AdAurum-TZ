using UnityEngine;

namespace CodeBase.Infrastructure {
    public interface IDestroyService {
        void Destroy(GameObject gameObject, float delay = 0);
    }
}