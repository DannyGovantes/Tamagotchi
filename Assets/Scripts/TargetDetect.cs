using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetDetect : MonoBehaviour
{

    private TrackableBehaviour theTrackable;
    private TrackableBehaviour.StatusInfo lastStatus;
    private PetController petController;
    private GameObject parent;
    private GameObject HUD;
    

    private void Awake()
    {
        HUD = FindObjectOfType<HUDController>().gameObject;
        
    }
    


    private void Start()
    {
        theTrackable = GetComponent<TrackableBehaviour>();
        lastStatus = theTrackable.CurrentStatusInfo;
        petController = transform.parent.GetComponent<PetController>();
        parent = transform.GetChild(0).gameObject;
        HUD.SetActive(false);
    }


    private void Update()
    {
        if (theTrackable.CurrentStatusInfo == lastStatus) return;
        if(theTrackable.CurrentStatusInfo == TrackableBehaviour.StatusInfo.NORMAL)
        {
            
            petController.LoadPetByTarget(parent, theTrackable.TrackableName);
            
            lastStatus = theTrackable.CurrentStatusInfo;
            HUD.SetActive(true);
            
        }
        else if (theTrackable.CurrentStatusInfo == TrackableBehaviour.StatusInfo.UNKNOWN)
        {
            petController.UnloadPetByTarget(theTrackable.TrackableName);
            
            lastStatus = theTrackable.CurrentStatusInfo;
            HUD.SetActive(false);
        }

    }

}
