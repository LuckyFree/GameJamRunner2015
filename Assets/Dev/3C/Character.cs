using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    #region Attributes

        [Header("Auto movement settings")]

        // Base speed
        [SerializeField]
        private float m_BaseSpeed = 6;

        // Speed multiplier
        private float m_SpeedMultiplier = 1;

        // Max speed multiplier
        [SerializeField]
        private float m_MaxSpeedMultiplier = 10;

        // Instance
        public static Character s_Instance = null;

    #endregion

    #region MonoBehaviour

        // Called at game creation
        void Awake()
        {
            if (s_Instance != null)
            {
                Debug.LogWarning("2 characters in scene, last removed");
                GameObject.Destroy(gameObject);
            }
            else
            {
                s_Instance = this;
            }
        }

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
        /// Set speed mulitplier. Clamp the value in limits
        /// </summary>
        /// <param name="value"></param>
        public void SetSpeedMultiplier(float value)
        {
            float speedMultiplier = Mathf.Clamp(value, 1, m_MaxSpeedMultiplier);
            m_SpeedMultiplier = speedMultiplier;
        }

    #endregion

    #region Static Manipulators

        /// <summary>
        /// Get character instance
        /// </summary>
        /// <returns>Character instance</returns>
        public static Character GetCharacter()
        {
            return s_Instance;
        }

    #endregion
}
