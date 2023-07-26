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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StrategyGrid))]
public class GridClickSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Quaternion objectRotationOnSpawn;
    StrategyGrid grid;
    public Camera mainCamera;
    public GameObject gridGround;
    public LayerMask groundLayer;
    float gridMinX;
    float gridMaxX;
    float gridMinZ;
    float gridMaxZ;
    public bool canSpawn;
    private void Start() {
        canSpawn = true;
        grid = GetComponent<StrategyGrid>();
        gridMinX = grid.transform.position.x;
        gridMaxX = gridMinX+grid.xCount*grid.cellSize;
        gridMinZ = grid.transform.position.z;
        gridMaxZ = gridMinZ+grid.zCount*grid.cellSize;
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0) && !IsPointerOverUICheck.IsPointerOverUIObject()&&canSpawn){
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit raycastHit, float.MaxValue, groundLayer)){
                if(isInsideOfGrid(raycastHit.point)){
                    /*Vector3 spawnPosition = CalculateSnapPosition(raycastHit.point);
                    Debug.Log(spawnPosition);
                    grid.SpawnObjectAtPosition(objectToSpawn,spawnPosition,objectRotationOnSpawn);*/
                    grid.SpawnObjectAtPosition(objectToSpawn,new Vector3(raycastHit.point.x,raycastHit.point.y+grid.ySpawnOffset,raycastHit.point.z),objectRotationOnSpawn);
                }else{
                    Debug.Log("Clicked Outside of the grid");
                }
            }
        }
    }
    public bool isInsideOfGrid(Vector3 position){
        if(position.x > gridMinX && position.x < gridMaxX&&position.z > gridMinZ&&position.z < gridMaxZ){
            return true;
        }
        return false;
    }
    /*I didnt have time to fix this. If you want the units to snap Good Luck!
    public Vector3 CalculateSnapPosition(Vector3 pos){
        pos.y = grid.ySpawnOffset+grid.transform.position.y;
        pos.x = Mathf.RoundToInt(pos.x / grid.xCount) * grid.xCount;
        pos.z = Mathf.RoundToInt(pos.z / grid.zCount) * grid.xCount;
        return pos;
    }
    */
}
