using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vr.Wiese
{
    public class AvatarManager : MonoBehaviour
    {
        #region Public Variables
        public Transform SpawnPoint;
        #endregion

        #region Private Variables
        // Store the Avatar Key to avoid typos
        static string AvatarPrefKey = "Avatar";

        private GameObject avatar;
        #endregion

        #region MonoBehaviour CallBacks
        // Use this for initialization
        void Awake()
        {
            SpawnAvatar();
        }
        #endregion

        #region Public Methods
        public void SpawnAvatar()
        {
            if (avatar != null)
            {
                Destroy(avatar);
            }
            string avatarName = PlayerPrefs.GetString(AvatarPrefKey);
            Debug.Log("Avatar: " + avatarName);
            avatar = (GameObject) Instantiate(Resources.Load(avatarName), SpawnPoint);
        }
        #endregion
    }
}