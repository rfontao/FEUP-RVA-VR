using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColKeepRotation : MonoBehaviour
{

    [SerializeField]
    private Transform rockRbTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = rockRbTransform.position;
    }
}
