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

public class StringParser : MonoBehaviour
{
    [Header("Info on how to use in code.")]
    /*
        String Parser will help to automate creation of levels and simplify placement of units.
        Use / to separate index of objects and use any non-numerical character for empty object.
        Index will be used to get gameObject from gameObjects list
        You can seperate rows with enter key.
        Make sure the amount of objects is the same as amount of cells in the grid.
    */
    //This character is used to split the string into separate units
    public char separateUnitCharacter = '/';
    [TextArea(15,20)]
    public string stringToParse;
    [SerializeField]
    public List<GameObject> gameObjects;
    public StrategyGrid strategyGrid;
    public Quaternion rotationToSpawn;
    private void Start() {
        LoadFromString(stringToParse);
    }
    public void LoadFromString(string s){
        string [] units = s.Split(separateUnitCharacter);
        int cur_x = 0;
        int cur_z = 0;
        for(int i=0;i<units.Length;i++){
            cur_x += 1;
            
            if(int.TryParse(units[i], out int n)){
                strategyGrid.SpawnObjectAtCell(gameObjects[Int16.Parse(units[i])],new Vector2Int(cur_x,cur_z),rotationToSpawn);
            }
            if((i+1)%strategyGrid.xCount==0){
                cur_z-=1;
                cur_x=0;
            }
        }
    }

}











//Here is a ctf challange for someone who finds this: Arire tbaan tvir lbh hc