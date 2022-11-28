using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HighlightRock: MonoBehaviour
{

/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void Highlight(){
        Debug.Log("Highlight");
        gameObject.layer = LayerMask.NameToLayer("Highlight");
    }

    public void Unhighlight()
    {
        Debug.Log("UnHighlight");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }



}
