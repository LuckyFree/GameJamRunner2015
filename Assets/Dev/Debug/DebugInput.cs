using UnityEngine;
using System.Collections;

public class DebugInput : MonoBehaviour
{
    #region Attributes

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Check inputs
            CheckInputs();
        }

    #endregion

    #region Private Manipulators

        private void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AudioButton.GetAudioButtonWithID(AudioButton.EButtonID.ButtonA).OnClick();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                AudioButton.GetAudioButtonWithID(AudioButton.EButtonID.ButtonB).OnClick();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioButton.GetAudioButtonWithID(AudioButton.EButtonID.ButtonC).OnClick();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                AudioButton.GetAudioButtonWithID(AudioButton.EButtonID.ButtonD).OnClick();
            }
        }

    #endregion
}
