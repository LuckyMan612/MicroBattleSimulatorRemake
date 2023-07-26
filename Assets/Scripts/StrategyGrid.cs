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

public class StrategyGrid : MonoBehaviour
{
    public int xCount;
    public int zCount;
    public float cellSize = 1;
    public float ySpawnOffset;
    // Will spawn object g at x,z where x = v.x, z = v.y
    public void SpawnObjectAtCell(GameObject g, Vector2Int v, Quaternion rot){
        Instantiate(g,new Vector3(transform.position.x+v.x*cellSize,transform.position.y+ySpawnOffset,transform.position.z + v.y*cellSize),rot);
    }
    public void SpawnObjectAtPosition(GameObject g, Vector3 v, Quaternion rot){
        Instantiate(g,v,rot);
    }
}
