using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    #region Attributes

        // Text component
        private Text m_Text = null;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Get text component
            m_Text = GetComponent<Text>();
        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Set text to display
        /// </summary>
        /// <param name="text">Text to display</param>
        public void SetText(string text)
        {
            if (m_Text != null)
            {
                m_Text.text = text;
            }
        }

    #endregion
}
