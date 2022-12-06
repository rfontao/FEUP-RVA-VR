using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : XRGrabInteractable
{
    [SerializeField] private float speed = 2000.0f;

    private new Rigidbody rigidbody;
    private ArrowCaster caster;

    private bool launched = false;

    private RaycastHit hit;

    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        rigidbody = GetComponent<Rigidbody>();
        caster = GetComponent<ArrowCaster>();

        audioSource = GameObject.FindGameObjectWithTag("Bow").GetComponent<AudioSource>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is Notch notch)
        {
            if (notch.CanRelease)
                LaunchArrow(notch);
        }
    }

    private void LaunchArrow(Notch notch)
    {
        launched = true;
        ApplyForce();

        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);

        StartCoroutine(LaunchRoutine());
    }

    private void ApplyForce()
    {
        rigidbody.AddForce(transform.forward * speed);
    }

    private IEnumerator LaunchRoutine()
    {
        // Set direction while flying
        while (!caster.CheckForCollision(out hit))
        {
            SetDirection();
            yield return null;
        }

        // Once the arrow has stopped flying
        DisablePhysics();
        ChildArrow(hit);
        CheckForHittable(hit);
    }

    private void SetDirection()
    {
        if (rigidbody.velocity.z > 0.5f)
            transform.forward = rigidbody.velocity;
    }

    private void DisablePhysics()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

    private void ChildArrow(RaycastHit hit)
    {
        transform.SetParent(hit.transform);
    }

    private void CheckForHittable(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out IArrowHittable hittable))
            hittable.Hit(this);
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        return base.IsSelectableBy(interactor) && !launched;
    }
}
