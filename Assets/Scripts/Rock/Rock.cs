using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rock : XRGrabInteractable
{
    [SerializeField] private float speed = 2000.0f;

    [SerializeField]
    private List<HighlightRock> highlightRocks = new List<HighlightRock>();

    private bool grabbable = true;

    protected override void OnHoverEntering(HoverEnterEventArgs args)
    {
        Debug.Log("Hover enter");
        base.OnHoverEntering(args);

        if(grabbable){
            foreach(HighlightRock rock in highlightRocks){
                rock.Highlight();
            }
        }
    }

    protected override void OnHoverExiting(HoverExitEventArgs args)
    {
        Debug.Log("Hover exit");
        base.OnHoverExiting(args);

        if(grabbable){
            foreach(HighlightRock rock in highlightRocks){
                rock.Unhighlight();
            }
        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args){
        Debug.Log("Select enter");
        base.OnSelectEntering(args);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args){
        Debug.Log("Select exit");
        base.OnSelectExited(args);
        grabbable = false;

        //Debug.Log("Args.iscancelled: " + args.isCanceled);
        //if(args.isCanceled)
        //    return;
            

        //Debug.Log("Object: " + args.interactorObject);
    }

    void OnCollisionEnter(Collision collision){
        grabbable = true;
    }

}
