using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashSprite : MonoBehaviour
{
    #region Attributes

        // Frequency
        [SerializeField]
        private float m_Frequency = 0.1f;

        // Duration
        [SerializeField]
        private float m_Duration = 1;

        // Timer
        private float m_Timer = 0;

        // Sprite A
        [SerializeField]
        private Sprite m_SpriteA = null;

        // Sprite B
        [SerializeField]
        private Sprite m_SpriteB = null;

        // Effect enabled
        private bool m_IsEffectEnabed = false;

        // Image component
        private Image m_Image = null;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Get image component
            m_Image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_IsEffectEnabed)
            {
                // Update timer
                UpdateTimer();

                // Switch sprite
                SwitchSprite();
            }
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Stop switch
        /// </summary>
        private void StopEffect()
        {
            m_IsEffectEnabed = false;
            m_Timer = 0;

            if (m_Image != null)
            {
                m_Image.sprite = m_SpriteA;
            }
        }

        /// <summary>
        /// Switch sprite
        /// </summary>
        private void SwitchSprite()
        {
            if (m_Timer > m_Frequency)
            {
                if (m_Image != null)
                {
                    if (m_Image.sprite == m_SpriteA)
                    {
                        m_Image.sprite = m_SpriteB;
                    }
                    else
                    {
                        m_Image.sprite = m_SpriteA;
                    }
                }
                m_Timer = 0;
            }
        }

        /// <summary>
        /// Update timer
        /// </summary>
        private void UpdateTimer()
        {
            m_Timer += Time.deltaTime;
        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Enable effect
        /// </summary>
        public void EnableEffect()
        {
            m_IsEffectEnabed = true;

            Invoke("StopEffect", m_Duration);
        }

    #endregion
}
