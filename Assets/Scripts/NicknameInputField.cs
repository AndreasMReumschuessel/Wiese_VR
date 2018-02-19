using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vr.Wiese
{
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class NicknameInputField : MonoBehaviour
    {
        #region Private Variables
        // Store the PlayerPref Key to avoid typos
        static string NicknamePrefKey = "Nickname";
        #endregion

        #region MonoBehaviour CallBacks
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        private void Start()
        {
            string defaultName = "";
            InputField _inputField = this.GetComponent<InputField>();

            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(NicknamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(NicknamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.playerName = defaultName;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// </summary>
        /// <param name="name">The name of the player</param>
        public void SetPlayerName(string name)
        {
            // #Important
            PhotonNetwork.playerName = name + " "; // force a trailing space string in case value is an empty string, else playerName would not be updated.

            PlayerPrefs.SetString(NicknamePrefKey, name);
        }
        #endregion
    }
}