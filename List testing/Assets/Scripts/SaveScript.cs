using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    //reference to the ListManager to lode the game data
    public ListManager listManager;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        PlayerPrefs.DeleteAll();
    }

    //Saves the Game
    public void SaveGame(List<string> vocEng, List<string> vocGer)
    {
        //delets all player prefs

        PlayerPrefs.SetInt("VocENGLength", vocEng.Count);

        for (var i = 0; i < vocEng.Count; i++)
        {
            PlayerPrefs.SetString("VocENG"+i, vocEng[i]);
            PlayerPrefs.SetString("VocGER"+i, vocGer[i]);
        }
    }

    //loads the game data
    public void LoadGame()
    {
        int length = PlayerPrefs.GetInt("VocENGLength");

        //clears the list before s

        for (var i = 0; i < length; i++)
        {
            listManager.VocabularyListEnglish.Add(PlayerPrefs.GetString("VocENG"+i));
            listManager.VocabularyListGerman.Add(PlayerPrefs.GetString("VocGER"+i));
        }
    }
}
