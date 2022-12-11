using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class ArrowHit : MonoBehaviour, IArrowHittable
{

    private AudioSource audioSource;
    
    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField] private int hp = 1;
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    public void Hit(Arrow arrow)
    {
        hp--;
        
        if(!tag.Equals("DeadEnemy"))
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);

        if (hp <= 0 && !tag.Equals("DeadEnemy"))
        {
            animator.SetTrigger("Die");
            this.tag = "DeadEnemy";
            this.gameObject.GetComponent<EnemyMovement>().Stop();
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossSpawner>().UpdateDeadSlimes();
        }
    }

    public void HitByRock()
    {
        hp--;

        if(!tag.Equals("DeadEnemy"))
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);

        if (hp <= 0 && !tag.Equals("DeadEnemy"))
        {
            animator.SetTrigger("Die");
            this.tag = "DeadEnemy";
            this.gameObject.GetComponent<EnemyMovement>().Stop();
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossSpawner>().UpdateDeadSlimes();
        }
    }
}
