using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

namespace Vr.Wiese
{
    public class MenuController : MonoBehaviour
    {
        #region Public Variables
        [Tooltip("The controller which handles the menu. (Currently optimized for the left controller.)")]
        public VRTK_ControllerEvents controllerEvents;
        [Space]
        public GameObject MenuPanel;
        [Space]
        public GameObject LobbyPanel;
        public GameObject CalendarPanel;
        #endregion

        #region Private Variables
        private bool menuState;
        #endregion

        #region MonoBehaviour CallBakcks
        private void OnEnable()
        {
            controllerEvents.ButtonTwoPressed += TriggerMenu;
        }
        #endregion

        #region Public Methods
        public void OpenLobby()
        {
            CalendarPanel.SetActive(false);
            LobbyPanel.SetActive(true);
        }

        public void OpenCalendar()
        {
            LobbyPanel.SetActive(false);
            CalendarPanel.SetActive(true);
        }

        public void LoadRoom(string roomName)
        {
            SceneManager.LoadScene(roomName);
        }
        #endregion

        #region Private Methods
        private void TriggerMenu(object sender, ControllerInteractionEventArgs e)
        {
            Debug.Log("Button2 has been pressed!");
            menuState = !menuState;
            MenuPanel.SetActive(menuState);
        }
        #endregion
    }
}
