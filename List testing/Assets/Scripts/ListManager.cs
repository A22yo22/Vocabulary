using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListManager : MonoBehaviour
{
    //referance to the Save Script
    public SaveScript saveScript;

    //reference to inputField English and German
    public TMP_InputField inputFieldEnglish;
    public TMP_InputField inputFieldGerman; 

    //text from the inputs
    public string vocEnglish;
    public string vocGerman;

    //these are the lists for the vocabulary
    public List<string> VocabularyListEnglish = new List<string>();
    public List<string> VocabularyListGerman = new List<string>();

    //Mods
    public GameObject WriteMode;
    public GameObject ReadMode;

    //gets the input from the textFields
    public void ReadEnglish(string s)
    {
        vocEnglish = s;
    }
    public void ReadGerman(string s)
    {
        vocGerman = s;
    }

    //Submits the text to the list
    public void Submit()
    {
        VocabularyListEnglish.Add(vocEnglish);
        VocabularyListGerman.Add(vocGerman);
        inputFieldEnglish.text = "";
        inputFieldGerman.text = "";
        saveScript.SaveGame(VocabularyListEnglish, VocabularyListGerman);
    }

    //changes the write to read mode or around
    bool Read = true;

    public void SwitschModes()
    {
        if (Read)
        {
            ReadMode.SetActive(false);
            WriteMode.SetActive(true);
            Read = false;
        }
        else
        {
            ReadMode.SetActive(true);
            WriteMode.SetActive(false);
            Read = true;
        }
    }
}
