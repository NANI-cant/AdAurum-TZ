using UnityEngine;

namespace CodeBase.Infrastructure.Impl {
    public class UnityInstantiateService : IInstantiateService {
        public GameObject Instantiate(GameObject template, Transform parent = null) => GameObject.Instantiate(template, parent);
    }
}