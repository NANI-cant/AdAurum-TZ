using UnityEngine;

namespace CodeBase.Infrastructure {
    public interface IInstantiateService {
        GameObject Instantiate(GameObject template, Transform parent = null);
    }
}