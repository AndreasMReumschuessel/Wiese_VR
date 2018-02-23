using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vr.Wiese
{
    [RequireComponent(typeof(Text))]
    public class SetUsernameText : MonoBehaviour
    {
        #region Public Variables
        public Text usernameText;
        #endregion

        #region Private Variables
        // Store the PlayerPref Key to avoid typos
        static string NicknamePrefKey = "Nickname";
        #endregion

        private void Awake()
        {
            usernameText.text = PlayerPrefs.GetString(NicknamePrefKey);
        }
    }
}
