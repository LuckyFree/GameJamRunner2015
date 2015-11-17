using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(FlashSprite))]
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

        // Flash sprite
        private FlashSprite m_FlashSprite = null;

        // Audio button list
        private static List<AudioButton> s_AudioButtonList = new List<AudioButton>();

        // Image
        private Image m_Image = null;

        // Disable color
        [SerializeField]
        private Color m_DisableColor;

    #endregion

    #region MonoBehaviour

        // Called at creation
        void Awake()
        {
            s_AudioButtonList.Add(this);
        }

        // Use this for initialization
        void Start()
        {
            // Get flash sprite component
            m_FlashSprite = GetComponent<FlashSprite>();

            // Get image component
            m_Image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {

        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Set enable mode. Based on color tint
        /// </summary>
        /// <param name="mode"></param>
        public void SetEnableMode(bool mode)
        {
            if (m_Image != null)
            {
                if (mode)
                {
                    m_Image.color = Color.white;
                }
                else
                {
                    m_Image.color = m_DisableColor;
                }
            }   
        }

        /// <summary>
        /// Fail effect on flash sprite
        /// </summary>
        public void FailEffect()
        {
            if (m_FlashSprite != null)
            {
                m_FlashSprite.EnableEffect();
            }
        }

        /// <summary>
        /// On button click
        /// </summary>
        public void OnClick()
        {
            Debug.Log(m_ButtonID + " clicked");

            if (GameplayAudioManager.GetInstance() != null)
            {
                GameplayAudioManager.GetInstance().OnButtonClicked(this);
            }
        }

    #endregion

    #region Getters & Setters

        /// <summary>
        /// Get audio button ID
        /// </summary>
        /// <returns></returns>
        public EButtonID GetAudioButtonID()
        {
            return m_ButtonID;
        }

    #endregion

    #region Static Manipulators

        /// <summary>
        /// Get audio button with specified ID
        /// </summary>
        /// <param name="ID">ID filter</param>
        /// <returns>Audio button with specified ID</returns>
        public static AudioButton GetAudioButtonWithID(EButtonID ID)
        {
            for (int i = 0; i < s_AudioButtonList.Count; i++)
            {
                if (s_AudioButtonList[i].m_ButtonID == ID)
                {
                    return s_AudioButtonList[i];
                }
            }

            return null;
        }

    #endregion
}
