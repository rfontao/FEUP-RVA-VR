using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour, IArrowHittable
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit(Arrow arrow)
    {
        animator.SetTrigger("Die");
        this.tag = "DeadEnemy";
        GameObject.FindGameObjectWithTag("Boss").GetComponent<BossSpawner>().UpdateDeadSlimes();
    }
}
