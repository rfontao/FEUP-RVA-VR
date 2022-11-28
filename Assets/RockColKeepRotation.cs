using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColKeepRotation : MonoBehaviour
{

    private Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(parentTransform.rotation);
    }
}
