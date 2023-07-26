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

public enum UnitType{
Melee,
Ranged
}
public class UnitAI : MonoBehaviour
{
    GameManager gm;
    public bool isEnemyUnit;
    public float movementSpeed;
    public float attackDamage;
    public float delayBetweenAttacks;
    public float health;
    public float unitCost;
    public float targetReachedDistance;
    public UnitType unitType;
    //Settings for ranged units
    public GameObject rangedProjectile;
    public float rangedShootForce;
    [HideInInspector]
    public Transform target;
    public float rotationSpeed = 10f;
    Rigidbody rb;
    [HideInInspector]
    public bool reachedTarget;
    bool startedAttack=false;
    private void Start() {
        startedAttack = false;
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
        if(isEnemyUnit){
            gm.enemyUnits.Add(gameObject);
        }else{
            gm.playerUnits.Add(gameObject);
        }
    }
    private void OnEnable() {
        GameManager.OnGameStarted += GetTarget;
    }
    private void OnDisable() {
        GameManager.OnGameStarted -= GetTarget;
    }
    //Finds closest enemy object;
    public void GetTarget(){
        if(isEnemyUnit){
            GetTargetFromList(gm.playerUnits);
        }else{
            GetTargetFromList(gm.enemyUnits);
        }
    }
    public void GetTargetFromList(List<GameObject> objects){
        Transform closest=null;
        foreach(GameObject g in objects){
            if(closest==null){
                closest = g.transform;
            }
            if(Vector3.Distance(transform.position, closest.position)>Vector3.Distance(transform.position,g.transform.position)){
                closest = g.transform;
            }
        }
        target = closest;
    }
    private void Update() {
        if(target){
            reachedTarget = Vector3.Distance(transform.position,target.position) <= targetReachedDistance && gm.battleStarted;
        }else{
            GetTarget();
        }
        if(target&&reachedTarget&&!startedAttack){
            StartCoroutine(AttackCoroutine());
            startedAttack=true;
        }
        if(gm.battleStarted&&target){
            Vector3 dir = transform.position-target.position;
            Vector3 _direction = (target.position - transform.position).normalized;
            Quaternion _lookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
        }
        if(health<=0){
            Die();
        }   
    }
    IEnumerator AttackCoroutine(){
        yield return new WaitForSeconds(delayBetweenAttacks);
        if(reachedTarget&&target){
            if(unitType == UnitType.Melee){
            MeleeAttack();
            } else if(unitType == UnitType.Ranged){
                RangedAttack();
            }
            StartCoroutine(AttackCoroutine());
        }else{
            startedAttack = false;
        }
        
    }
    public void RangedAttack(){
        //Good luck here
    }
    public void MeleeAttack(){
        target.GetComponent<UnitAI>().GetDamaged(attackDamage);
    }
    private void FixedUpdate() {
        if(target&&gm.battleStarted&&!reachedTarget){
            rb.MovePosition(transform.position+transform.forward*movementSpeed*Time.fixedDeltaTime);
        }
    }
    public void GetDamaged(float damage){
        Debug.Log("Damage received");
        health-=damage;
    }
    public void Die(){
        if(isEnemyUnit){
            gm.enemyUnits.Remove(gameObject);
        }else{
            gm.playerUnits.Remove(gameObject);
        }
        Debug.Log("Unit died");
        Destroy(gameObject);
    }
}
