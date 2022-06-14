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

    //settings object
    public GameObject TabsForSettings;
    public GameObject viewPort;
    public GameObject TabsButton;

    public int TabsClosedButtonPos = -885;
    public int TabsOpenedButtonPos = -690;

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

    bool settingsOpened = false;
    //opens the settings
    public void Settings()
    {
        if(settingsOpened)
        {
            settingsOpened = false;

            TabsForSettings.SetActive(false);
            viewPort.SetActive(true);
            TabsButton.transform.position = TabsButton.transform.position + new Vector3(-1.8f, 0, 0);
        }
        else
        {
            settingsOpened = true;

            TabsForSettings.SetActive(true);
            viewPort.SetActive(false);
            TabsButton.transform.position = TabsButton.transform.position + new Vector3(1.8f, 0, 0);
        }
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
            Debug.Log("Write mode");
        }
        else
        {
            ReadMode.SetActive(true);
            WriteMode.SetActive(false);
            Read = true;
            saveScript.SpawnVocabularyOBJs();
            Debug.Log("Read mode");
        }
    }

    public void TrainMode()
    {

    }
}
