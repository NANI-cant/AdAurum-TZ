using UnityEngine.SceneManagement;

namespace CodeBase.SceneManagement.Impl {
    public class UnitySceneLoadService : ISceneLoadService {
        public void LoadAsync(string sceneName) {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}