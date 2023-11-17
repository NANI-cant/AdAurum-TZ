using System;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure {
    public interface IAssetProvider {
        TAsset Load<TAsset>(string key) where TAsset: Object;
    }
}