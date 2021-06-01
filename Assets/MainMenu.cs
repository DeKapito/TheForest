using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public void PlayGame()
    {
        menu.SetActive(false);
    }
}
