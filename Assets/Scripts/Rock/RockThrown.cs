using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RockThrown : MonoBehaviour
{

    bool hasPhysics = false;
    bool hasHitATargetOrGround = false;

    Rigidbody rb;

    [SerializeField]
    [Header("After being thrown: time between htting the ground or an enemy the first time until turning its physics off.")]
    float hitGroundToTurnOffPhysicsTime = 5f;

    float curTime;

    bool stopRockPhysicsNextCollision = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curTime = hitGroundToTurnOffPhysicsTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPhysics && hasHitATargetOrGround && !stopRockPhysicsNextCollision){
            curTime -= Time.deltaTime;
            if(curTime < 0){
                stopRockPhysicsNextCollision = true;
            }
        }
    }

    public void OnRockThrow(){

        hasPhysics = true;
        hasHitATargetOrGround = false;
        stopRockPhysicsNextCollision = false;

    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Terrain")){
            if(hasPhysics && !hasHitATargetOrGround){
                hasHitATargetOrGround = true;
                curTime = hitGroundToTurnOffPhysicsTime;
            }
            else if(hasHitATargetOrGround && stopRockPhysicsNextCollision){
                ResetRockState();
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Enemy"){
            if(!hasHitATargetOrGround && hasPhysics){
                hasHitATargetOrGround = true;
                curTime = hitGroundToTurnOffPhysicsTime;
                
                if (collider.transform.TryGetComponent(out IArrowHittable hittable)){
                    hittable.HitByRock();
                }
            }
        }
    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.CompareTag("Terrain")){
            if(hasHitATargetOrGround && stopRockPhysicsNextCollision){
                ResetRockState();
            }
        }
    }

    void ResetRockState(){
        stopRockPhysicsNextCollision = false;
        hasHitATargetOrGround = false;
        hasPhysics = false;
        rb.isKinematic = true;
        curTime = hitGroundToTurnOffPhysicsTime;
    }

    public void PickupRock(){
        stopRockPhysicsNextCollision = false;
        hasHitATargetOrGround = false;
        hasPhysics = false;
        rb.isKinematic = true;
        curTime = hitGroundToTurnOffPhysicsTime;
    }

}
