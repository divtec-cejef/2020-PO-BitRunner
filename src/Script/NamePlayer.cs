using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlayer : MonoBehaviour
{
    public string namePlayer;
    public GameObject inputField;

    // Ecris le nom du joueur dans les fichiers du joueur
    public void getPlayerName ()
    {
        namePlayer = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString("namePlayer", namePlayer);
    }
}
