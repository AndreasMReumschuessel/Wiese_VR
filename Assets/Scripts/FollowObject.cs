using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    protected Animator animator;

    public Transform headLookObject;
    public Transform leftHandObject;
    public Transform rightHandObject;

    private Dictionary<Transform, AvatarIKGoal> bodyDict;

    private void TrackHead()
    {
        if (headLookObject)
        {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(headLookObject.position);
        }
    }

    private void TrackBodyPart(Transform bodyPart)
    {
        AvatarIKGoal goal;
        if (bodyPart && bodyDict.TryGetValue(bodyPart, out goal))
        {
            animator.SetIKPositionWeight(goal, 1);
            animator.SetIKRotationWeight(goal, 1);
            animator.SetIKPosition(goal, bodyPart.position);
            animator.SetIKRotation(goal, bodyPart.rotation);
        }
    }

    private void Awake()
    {
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

        TrackBodyPart(leftHandObject);
        TrackBodyPart(rightHandObject);
    }
}
