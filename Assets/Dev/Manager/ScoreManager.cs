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

        // Instance
        private static ScoreManager s_Instance = null;

    #endregion

    #region MonoBehaviour

        // Called at creation
        void Awake()
        {
            if (s_Instance != null)
            {
                Debug.LogWarning("2 score manager in scene. Last removed");
                GameObject.Destroy(gameObject);
            }
            else
            {
                s_Instance = this;
            }
        }

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

    #region Static Manipulators

        /// <summary>
        /// Get instance
        /// </summary>
        /// <returns></returns>
        public static ScoreManager GetInstance()
        {
            return s_Instance;
        }

    #endregion
}
