using UnityEngine;

namespace DiamondSnakeGame.Scripts.Data
{
    [CreateAssetMenu(menuName="Data/ModelData")]
    public class ModelData : ScriptableObject
    {
        public GameObject[] model;
    }
}
