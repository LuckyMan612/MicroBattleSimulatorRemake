/*
         ___            _____       __       _    
        /   |          |____ |     /  |     | |   
 _ __  / /| |_ __ ___      / /_ __ `| |  ___| | __
| '_ \/ /_| | '_ ` _ \     \ \ '_ \ | | / __| |/ /
| | | \___  | | | | | |.___/ / | | || || (__|   < 
|_| |_|   |_/_| |_| |_|\____/|_| |_\___/\___|_|\_\

- n4m3n1ck was here                                     
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [TextArea(5,15)]

    public List<string> levels;
    public StringParser stringParser;
    private void Awake() {
        stringParser.stringToParse = levels[DataHolder.currentLevel];
    }
}
