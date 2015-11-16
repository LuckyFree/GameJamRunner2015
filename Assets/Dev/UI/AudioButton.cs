using UnityEngine;
using System.Collections;

public class AudioButton : MonoBehaviour
{
    #region Enums

        // Button identifiant enum
        public enum EButtonID
        {
            ButtonA,
            ButtonB,
            ButtonC,
            ButtonD
        }

    #endregion

    #region Attributes

        // Button identifiant
        [SerializeField]
        private EButtonID m_ButtonID = EButtonID.ButtonA;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// On button click
        /// </summary>
        public void OnClick()
        {
            Debug.Log(m_ButtonID + " clicked");
        }

    #endregion
}
