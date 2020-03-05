using UnityEngine;
using Zenject;

namespace DiamondSnakeGame.Scripts.Components
{
    public class StateMachineBehaviourInjector : MonoBehaviour
    {
        public void InjectionTo(Animator animator)
        {
            var behaviours = animator.GetBehaviours<UnityEngine.StateMachineBehaviour>();

            if (behaviours == null) return;
            foreach (var behaviour in behaviours)
            {
                ProjectContext.Instance.Container.Inject(behaviour);
            }
        }
    }
}
