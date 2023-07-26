/*
         ___            _____       __       _    
        /   |          |____ |     /  |     | |   
 _ __  / /| |_ __ ___      / /_ __ `| |  ___| | __
| '_ \/ /_| | '_ ` _ \     \ \ '_ \ | | / __| |/ /
| | | \___  | | | | | |.___/ / | | || || (__|   < 
|_| |_|   |_/_| |_| |_|\____/|_| |_\___/\___|_|\_\

- n4m3n1ck was here first        
- Lucky was here too
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> enemyUnits;
    public List<GameObject> playerUnits;
    public delegate void OnGameStart();
    public static event OnGameStart OnGameStarted;
    public bool battleStarted;
    public GridClickSpawner gridClickSpawner;
    public GameObject buildUI;
    public GameObject battleUI;
    private void Start() {
        battleStarted = false;
    }
    public void StartGame(){
        gridClickSpawner.canSpawn = false;
        if(buildUI) buildUI.SetActive(false);
        if(battleUI) battleUI.SetActive(true);
        battleStarted = true;
        OnGameStarted();
    }
}
