using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        InfoPanel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;

        public Image backGround;

        public bool startHided = false;

        [Header("Animatrion")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.2f;

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Show");
        }

        private void HideObjects()
        {
            backGround.enabled = false;
            listOfObjects.ForEach(i => i.gameObject.SetActive(false)); //Desligar os Objetos da Lista
            
        }

        private void ShowObjects()
        {
            for(int i =0; i < listOfObjects.Count; i++)
            {
                //Liga o objeto deixa na escala zero e faz a animaçao de DoScale
                var obj = listOfObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfPhrases.Count);
            backGround.enabled = false;

        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
                
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true)); //Liga os Objetos da Lista
            backGround.enabled = false;


        }


    }

}
