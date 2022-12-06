using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour, IArrowHittable
{

    private AudioSource audioSource;
    
    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

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

    public void Hit(Arrow arrow)
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
        animator.SetTrigger("Die");
        this.tag = "DeadEnemy";
        GameObject.FindGameObjectWithTag("Boss").GetComponent<BossSpawner>().UpdateDeadSlimes();
    }
}
