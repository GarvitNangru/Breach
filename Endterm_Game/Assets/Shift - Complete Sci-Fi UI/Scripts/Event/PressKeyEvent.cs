using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Shift
{
    public class PressKeyEvent : MonoBehaviour
    {
        [Header("KEY")]
        [SerializeField]
        public KeyCode hotkey;
        public bool pressAnyKey;
		public bool invokeAtStart;

        public PlayerController playerController;
        public RifleGun rifleGun;

        [Header("KEY ACTION")]
        [SerializeField]
        public UnityEvent pressAction;
		
		void Start()
        {
            if (invokeAtStart == true)
                pressAction.Invoke();
        }

        void Update()
        {
            if (pressAnyKey == true)
            {
                if (Input.anyKeyDown)
                    pressAction.Invoke();
            }

            else
            {
                if (Input.GetKeyDown(hotkey))
                    pressAction.Invoke();
            }
        }
        public void pauseGame()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            rifleGun.enabled = false;
            playerController.enabled = false;
        }
        public void ResumeGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            rifleGun.enabled = true;
            playerController.enabled = true;
        }
    }
}