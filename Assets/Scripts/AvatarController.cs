using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {
    #region Public Variables
    public Transform cameraRigTransform;
    public Transform headTransform;
    public Transform cameraAnchorPoint;

    public float rotationBorder = 60f;
    #endregion

    #region Private Variables
    private Transform avatarTransform;
    private float avatarRotationY;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        avatarTransform = this.gameObject.transform;
        avatarRotationY = avatarTransform.rotation.eulerAngles.y;
    }

    // Use this for initialization
    void Start () {
        PlaceRig();		
	}

    private void FixedUpdate()
    {
        RotateBody();
    }

    // Update is called once per frame
    void Update () {
        FollowCamera();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// This places the camera rig to the position of the avatar
    /// </summary>
    private void PlaceRig()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;

        Vector3 anchorPoint = cameraAnchorPoint.position;
        anchorPoint.y = cameraRigTransform.position.y;
        cameraRigTransform.position = anchorPoint + difference;
    }

    /// <summary>
    /// The avatar follows the position and also the height of the camera.
    /// </summary>
    private void FollowCamera()
    {
        Vector3 difference = avatarTransform.position - cameraAnchorPoint.position;

        avatarTransform.position = headTransform.position + difference;
    }

    private void RotateBody()
    {
        Quaternion headRotation = avatarTransform.Find("Armature/Belly/Chest/Neck/Head").rotation;
        float headRotationAngleY = headRotation.eulerAngles.y;

        if (headRotationAngleY <= (avatarRotationY - rotationBorder) || headRotationAngleY >= (avatarRotationY + rotationBorder))
        {
            avatarTransform.eulerAngles = new Vector3(0, headRotationAngleY, 0);
            avatarRotationY = avatarTransform.rotation.eulerAngles.y;
        }
    }
    #endregion
}
