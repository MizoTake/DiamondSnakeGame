using DiamondSnakeGame.Scripts.Data;
using UnityEngine;
using Zenject;

namespace DiamondSnakeGame.Scripts.Installer
{
    [CreateAssetMenu( fileName = nameof(ModelDataInstaller), menuName = "Installers/ModelDataInstaller" )]
    public class ModelDataInstaller : ScriptableObjectInstaller<ModelDataInstaller>
    {
        public ModelData modelData;

        public override void InstallBindings()
        {
            Container.BindInstance(modelData);
        }
    }
}
