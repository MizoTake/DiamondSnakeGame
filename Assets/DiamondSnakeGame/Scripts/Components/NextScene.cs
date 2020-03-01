using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DiamondSnakeGame.Components
{
    public class NextScene : MonoBehaviour
    {

        [SerializeField] private SceneObject next;

        public void Next()
        {
            SceneManager.LoadScene(next);
        }
        
        public async UniTask NextAsync()
        {
            await SceneManager.LoadSceneAsync(next);
        }
    }
}
