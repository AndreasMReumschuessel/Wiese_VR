using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    protected Animator animator;

    private Transform headLookObject;
    private Transform leftHandObject;
    private Transform rightHandObject;

    private Dictionary<Transform, AvatarIKGoal> bodyDict;

    private void TrackHead()
    {
        if (headLookObject)
        {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(headLookObject.position);
        }
    }

    private void TrackBodyPart(Transform bodyPart, float rotation)
    {
        AvatarIKGoal goal;
        if (bodyPart && bodyDict.TryGetValue(bodyPart, out goal))
        {
            // Rotate the hand to get a more realistic feeling
            Quaternion finalRotation = Quaternion.Euler(bodyPart.rotation.eulerAngles + new Vector3(0, 0, rotation));

            animator.SetIKPositionWeight(goal, 1);
            animator.SetIKRotationWeight(goal, 1);
            animator.SetIKPosition(goal, bodyPart.position);
            animator.SetIKRotation(goal, finalRotation);
        }
    }

    private void Awake()
    {
        headLookObject = GameObject.FindGameObjectWithTag("LookGoal").transform;
        leftHandObject = GameObject.FindGameObjectWithTag("LeftController").transform;
        rightHandObject = GameObject.FindGameObjectWithTag("RightController").transform;

        bodyDict = new Dictionary<Transform, AvatarIKGoal>();
        bodyDict.Add(leftHandObject, AvatarIKGoal.LeftHand);
        bodyDict.Add(rightHandObject, AvatarIKGoal.RightHand);
    }

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (!animator)
        {
            return;
        }

        TrackHead();

        TrackBodyPart(leftHandObject, 90);
        TrackBodyPart(rightHandObject, -90);
    }
}
