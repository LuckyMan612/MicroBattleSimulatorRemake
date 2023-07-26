/*
         ___            _____       __       _    
        /   |          |____ |     /  |     | |   
 _ __  / /| |_ __ ___      / /_ __ `| |  ___| | __
| '_ \/ /_| | '_ ` _ \     \ \ '_ \ | | / __| |/ /
| | | \___  | | | | | |.___/ / | | || || (__|   < 
|_| |_|   |_/_| |_| |_|\____/|_| |_\___/\___|_|\_\

- n4m3n1ck was here                                     
- Lucky was here too
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelectorDemo : MonoBehaviour
{
    public TMP_Dropdown levelDropdown;
    private void Start() {
        SelectLevel();
    }
    public void SelectLevel(){
        Debug.Log("Selected level "+levelDropdown.options[levelDropdown.value].text);
        DataHolder.currentLevel = Int16.Parse(levelDropdown.options[levelDropdown.value].text)-1;
    }
}
