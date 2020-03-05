using System.Linq;
using DiamondSnakeGame.Scripts.Character.Interface;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UnityEngine;
using Zenject;

namespace DiamondSnakeGame.Scripts.Character
{
    public class CharacterViewModel : ICharacterViewModel
    {
        
        private IDataProvider provider;

        public GameObject CharacterModelPrefab => provider.ModelData.model.First();

        [Inject]
        private void Injection(IDataProvider provider)
        {
            this.provider = provider;
        }

        public CharacterViewModel()
        {
            
        }
    }
}
