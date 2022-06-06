using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class VocabalObjectScript : MonoBehaviour
{
    //reference to the Vocabulary text
    public TMP_Text engText;
    public TMP_Text gerText;


    //sets the german and englisch voc text
    public void SetObjectNames(string eng, string ger)
    {
        engText.text = eng;
        gerText.text = ger;
    }
}
