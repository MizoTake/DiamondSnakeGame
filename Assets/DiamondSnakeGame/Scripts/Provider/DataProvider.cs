using DiamondSnakeGame.Scripts.Data;
using DiamondSnakeGame.Scripts.Provider.Interface;
using Zenject;

namespace DiamondSnakeGame.Scripts.Provider
{
    public class DataProvider : IDataProvider
    {
        
        private ModelData modelData;
        public ModelData ModelData => modelData;
        
        [Inject]
        private void Injection(ModelData modelData)
        {
            this.modelData = modelData;
        }
    }
}
