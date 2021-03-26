using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EnableAnimations : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Animator anim1, anim2, anim3, anim4;
    public ParticleSystem p1, p2;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.TRACKED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            // Play  when target is found
            anim1.enabled = true;
            anim2.enabled = true;
            anim3.enabled = true;
            anim4.enabled = true;
            p1.Play();
            p2.Play();
            Debug.Log("인식?");
        }
        else {
            // Stop  when target is lost
            anim1.enabled = false;
            anim2.enabled = false;
            anim3.enabled = false;
            anim4.enabled = false;
            p1.Stop();
            p2.Stop();
        }
    }
}