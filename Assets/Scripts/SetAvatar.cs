using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vr.Wiese
{
    public class SetAvatar : MonoBehaviour
    {
        #region Public Variables
        public string AvatarPrefabName;
        #endregion

        #region Private Variables
        // Store the Avatar Key to avoid typos
        static string AvatarPrefKey = "Avatar";
        #endregion

        #region MonoBehaviour CallBacks
        void Awake()
        {
            //PlayerPrefs.SetString(AvatarPrefKey, "Avatar_Boy");
        }
        #endregion

        #region Public Methods
        public void SetAvatarPrefab(string avatarPrefabName)
        {
            PlayerPrefs.SetString(AvatarPrefKey, avatarPrefabName);
            Debug.Log("AvatarChoosen: " + avatarPrefabName);
        }
        #endregion
    }
}