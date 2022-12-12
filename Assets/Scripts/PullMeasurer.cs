﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.XR.Interaction.Toolkit;

public class PullMeasurer : XRBaseInteractable
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    public GameObject[] Bows { get; private set; }
    public float PullAmount { get; private set; } = 0.0f;

    public bool hasArrow = false;
    public Vector3 PullPosition => Vector3.Lerp(start.position, end.position, PullAmount);

    private XRDirectInteractor leftController;
    private XRDirectInteractor rightController;
    private XRDirectInteractor interactor;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        //.GetComponent<Bow>()
        Bows = GameObject.FindGameObjectsWithTag("Bow");
        
        base.OnSelectEntered(args);
        interactor = args.interactorObject as XRDirectInteractor;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        interactor = null;
        PullAmount = 0;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            // Update pull values while the measurer is grabbed
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                UpdatePull();
        }
    }

    private void UpdatePull()
    {
        // Use the interactor's position to calculate amount
        Vector3 interactorPosition = firstInteractorSelecting.transform.position;

        // Figure out the new pull value, and it's position in space
        PullAmount = CalculatePull(interactorPosition);

        if (Bows[0].GetComponent<Bow>().isSelected || Bows[1].GetComponent<Bow>().isSelected || Bows[2].GetComponent<Bow>().isSelected)
        {
            // Send haptic feedback to the controller pulling the string
            interactor.SendHapticImpulse(PullAmount, 0.1f);
        }
    }

    private float CalculatePull(Vector3 pullPosition)
    {
        // Direction, and length
        Vector3 pullDirection = pullPosition - start.position;
        Vector3 targetDirection = end.position - start.position;

        // Figure out out the pull direction
        float maxLength = targetDirection.magnitude;
        targetDirection.Normalize();

        // What's the actual distance?
        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0.0f, 1.0f);
    }

    private void OnDrawGizmos()
    {
        // Draw line from start to end point
        if (start && end)
            Gizmos.DrawLine(start.position, end.position);
    }
}
