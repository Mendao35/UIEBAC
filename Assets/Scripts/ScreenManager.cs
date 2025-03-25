using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBase;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;
                     

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);           
        }

        public void ShowByType(ScreenType type)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide();
            }

            var nextScreen = screenBase.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBase.ForEach(i => i.Hide()); //Percorre a lista ScreenBase e chama o Metodo Hide em cada um dos elementos da lista
        }
    }



}

