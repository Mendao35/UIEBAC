using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = 0.1f;
    public string phrase;

    private void Awake()
    {
        textMesh.text = "";
    }

    [Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }


    IEnumerator Type(string s)
    {
        textMesh.text = "";

        foreach(char i in s.ToCharArray())
        {
            textMesh.text += i;
            yield return new WaitForSeconds(timeBetweenLetters);
        }

    
    }
    
}
