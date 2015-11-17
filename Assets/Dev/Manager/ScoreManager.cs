using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    #region Attributes

        // Top player score
        private int m_TopPlayerScore = 0;

        // Top player score UI
        [SerializeField]
        private ScoreUI m_TopPlayerScoreUI = null;

        // Bottom player score
        private int m_BottomPlayerScore = 0;

        // Bottom player score UI
        [SerializeField]
        private ScoreUI m_BottomPlayerScoreUI = null;

    #endregion

    #region MonoBehaviour

        // Update is called once per frame
        void Update()
        {
            // Update score UI
            if (m_TopPlayerScoreUI != null)
            {
                m_TopPlayerScoreUI.SetText(m_TopPlayerScore.ToString());
            }

            if (m_BottomPlayerScoreUI != null)
            {
                m_BottomPlayerScoreUI.SetText(m_BottomPlayerScore.ToString());
            }
        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Add bottom player score value
        /// </summary>
        /// <param name="value">Value to add</param>
        public void AddBottomPlayerScore(int value)
        {
            m_BottomPlayerScore += Mathf.Abs(value);
        }

        /// <summary>
        /// Add top player score value
        /// </summary>
        /// <param name="value">Value to add</param>
        public void AddTopPlayerScore(int value)
        {
            m_TopPlayerScore += Mathf.Abs(value);
        }

    #endregion
}
