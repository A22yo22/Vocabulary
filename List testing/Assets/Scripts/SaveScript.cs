using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveScript : MonoBehaviour
{
    //reference to the ListManager to lode the game data
    public ListManager listManager;

    //reference to the voc prefab
    public GameObject vocPrefab;

    //reference to the View port
    public GameObject viewPort;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    //Saves the Game
    public void SaveGame(List<string> vocEng, List<string> vocGer)
    {
        //delets all player prefs

        PlayerPrefs.SetInt("VocENGLength", vocEng.Count);

        for (int i = 0; i < vocEng.Count; i++)
        {
            PlayerPrefs.SetString("VocENG"+i, vocEng[i]);
            PlayerPrefs.SetString("VocGER"+i, vocGer[i]);
        }
    }

    //loads the game data
    public void LoadGame()
    {
        int length = PlayerPrefs.GetInt("VocENGLength");

        //clears the list before saveing

        for (int i = 0; i < length; i++)
        {
            listManager.VocabularyListEnglish.Add(PlayerPrefs.GetString("VocENG"+i));
            listManager.VocabularyListGerman.Add(PlayerPrefs.GetString("VocGER"+i));
        }

        SpawnVocabularyOBJs();
    }

    public List<GameObject> spawnedVocs = new List<GameObject>();

    public void SpawnVocabularyOBJs()
    {
        Vector3 spawnPos = new Vector3(0, 50, 0);

        //removes all vocs that got spawned
        for (int i = 0; i < spawnedVocs.Count; i++)
        {
            Destroy(spawnedVocs[0]);
        }

        //clears the list
        for (int i = 0; i < spawnedVocs.Count; i++)
        {
            spawnedVocs.RemoveRange(0, spawnedVocs.Count);
        }

        //spawns vocs
        for (int i = 0; i < listManager.VocabularyListEnglish.Count; i++)
        {
            GameObject voc = Instantiate(vocPrefab);

            voc.transform.SetParent(viewPort.transform);

            voc.transform.localScale = new Vector3(1, 1, 1);

            spawnPos.y -= 150;

            spawnedVocs.Add(voc);

            voc.GetComponent<VocabalObjectScript>().SetObjectNames(PlayerPrefs.GetString("VocENG" + i), PlayerPrefs.GetString("VocGER" + i));

            voc.transform.localPosition = spawnPos;
            Debug.Log(spawnPos);
            Debug.Log(voc.transform.localPosition);
        }
    }
}