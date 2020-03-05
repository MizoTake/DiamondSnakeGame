using DiamondSnakeGame.Scripts.Character.Interface;
using DiamondSnakeGame.Scripts.Components;
using UnityEngine;
using UnityEngine.AI;

namespace DiamondSnakeGame.Scripts.Character
{

    public class CharacterView : MonoBehaviour, ICharacterView
    {

        [SerializeField] private NavMeshAgent agent;
        
        private Animator animator;

        public void Setup(GameObject childPrefab)
        {
            var child = Instantiate(childPrefab, transform);
            animator = child.GetComponent<Animator>();
        }

        public void NextPosition(Vector2 addPos)
        {
            agent.speed = animator.speed;
            var dt = Time.deltaTime;
            var controller = addPos;
            var x = controller.x * dt * agent.speed;
            var y = controller.y * dt * agent.speed;
            var camera = CameraAccessor.MainCamera;
            var cameraForward = Vector3.Scale (camera.transform.forward, new Vector3 (1, 0, 1)).normalized;
            var moveForward = cameraForward * y + camera.transform.right * x;
            agent.Move(moveForward);
            if (moveForward == Vector3.zero) return;
            transform.localRotation = Quaternion.LookRotation(moveForward);
        }
    }
}
