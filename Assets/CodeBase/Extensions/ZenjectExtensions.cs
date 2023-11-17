using Zenject;

namespace CodeBase.Extensions {
    public static class ZenjectExtensions {
        public static void BindService<TService>(this DiContainer container) {
            container
                .BindInterfacesAndSelfTo<TService>()
                .AsSingle()
                .NonLazy();
        }
    }
}