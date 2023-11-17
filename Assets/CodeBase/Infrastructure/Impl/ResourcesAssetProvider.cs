using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Impl {
    public class ResourcesAssetProvider : IAssetProvider {
        private readonly Dictionary<string, Object> _cashedAssets = new();

        public TAsset Load<TAsset>(string key) where TAsset: Object{
            if (!_cashedAssets.ContainsKey(key)) {
                _cashedAssets[key] = Resources.Load<TAsset>(key);
            }

            return (TAsset)_cashedAssets[key];
        }
    }
}