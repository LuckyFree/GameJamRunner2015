using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameplayAudioManager : MonoBehaviour
{
    #region Attributes

        // Instance
        public static GameplayAudioManager s_Instance = null;

        // Timer
        private float m_Timer = 0;

        // Audio time manager
        [SerializeField]
        private AudioTimeManager m_AudioTimeManager = null;

        [Header("Fail settings")]

        // Number of consecutive fail needed to decrease speed
        [SerializeField]
        private int m_NbFailToDecOffset = 3;

        // Speed multiplier dec on fail
        [SerializeField]
        private float m_OffsetMultiplierDecOnFail = 0.25f;

        [Header("Success settings")]

        // Number of consecutive success to increase speed
        [SerializeField]
        private int m_NbSuccessToIncOffset = 3;

        // Speed multiplier inc on success
        [SerializeField]
        private float m_OffsetMultiplierIncOnSuccess = 0.25f;

        // Current nb fail / success
        private int m_CurrentNbFail = 0;
        private int m_CurrentNbSuccess = 0;

        // Success base score
        [SerializeField]
        private int m_SuccessBaseScore = 1;

    #endregion

    #region MonoBehaviour

        // Called after game object creation
        void Awake()
        {
            if (s_Instance != null)
            {
                Debug.LogWarning("2 GameplayAudioManager in scene. Last removed");
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
            // Audio buttons visibility
            if (m_AudioTimeManager != null)
            {
                m_AudioTimeManager.SetAudioButtonsVisibility(m_Timer);
            }

            // Check missing inputs
            CheckMissingInputs();

            // Update timer
            UpdateTimer();
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Apply success imapct. Increase speed multiplier
        /// </summary>
        private void ApplySuccessImpact()
        {
            //Debug.LogError("BIG SUCCESS");

            // Reset nb success
            m_CurrentNbSuccess = 0;

            // Change speed multiplier
			TrainController train = TrainController.GetInstance();

            if (train != null)
            {
                train.IncOffsetMultiplier(m_OffsetMultiplierIncOnSuccess);
            }
        }

        /// <summary>
        /// Apply fail impact. Reduce speed multiplier
        /// </summary>
        private void ApplyFailImpact()
        {
            //Debug.LogError("BIG FAIL");

            // Reset nb fail
            m_CurrentNbFail = 0;

			// Change speed multiplier
			TrainController train = TrainController.GetInstance();

            if (train != null)
            {
                train.DecOffsetMultiplier(m_OffsetMultiplierDecOnFail);
            }
        }

        /// <summary>
        /// Check missing input
        /// </summary>
        private void CheckMissingInputs()
        {
            if (m_AudioTimeManager != null)
            {
                List<AudioButton> missedAudioButtonList;
				bool demoOn;

                while (m_AudioTimeManager.CheckMissingInput(m_Timer, out missedAudioButtonList, out demoOn))
                {
					if (!demoOn)
					{
						OnFail(missedAudioButtonList);
					}
					else
					{
						break;
					}
                }
            }
        }

        /// <summary>
        /// On input failed
        /// </summary>
        private void OnFail(AudioButton audioButton)
        {
            Debug.LogWarning("FAIL");

            // Inc nb fail
            m_CurrentNbFail++;

            // Apply fail
            if (m_CurrentNbFail >= m_NbFailToDecOffset)
            {
                ApplyFailImpact();
            }

            // Reset nb success
            m_CurrentNbSuccess = 0;

            // Effect
            audioButton.FailEffect();
        }

        /// <summary>
        /// On input failed
        /// </summary>
        private void OnFail(List<AudioButton> audioButtonList)
        {
            //Debug.LogWarning("FAIL");

            // Inc nb fail
            m_CurrentNbFail++;

            // Apply fail
            if (m_CurrentNbFail >= m_NbFailToDecOffset)
            {
                ApplyFailImpact();
            }

            // Reset nb success
            m_CurrentNbSuccess = 0;

            // Effect
            for (int i = 0; i < audioButtonList.Count; i++)
            {
                audioButtonList[i].FailEffect();
            }
        }

        /// <summary>
        /// On input success
        /// </summary>
        private void OnSuccess()
        {
            Debug.LogWarning("SUCCESS");

            // Inc nb success
            m_CurrentNbSuccess++;

            // Apply success
            if (m_CurrentNbSuccess >= m_NbSuccessToIncOffset)
            {
                ApplySuccessImpact();
            }

            // Reset nb fail
            m_CurrentNbFail = 0;

            // Score
            ScoreManager scoreManager = ScoreManager.GetInstance();
            scoreManager.AddTopPlayerScore(m_SuccessBaseScore);
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
        /// On audio button clicked
        /// </summary>
        /// <param name="audioButton">Audio button clicked</param>
        public void OnButtonClicked(AudioButton audioButton)
        {
            if (m_AudioTimeManager != null)
            {
				bool demoOn;
                if (m_AudioTimeManager.IsInputValid(audioButton, m_Timer, out demoOn))
                {
					if (!demoOn)
					{
						// Success
						OnSuccess();
					}
                }
                else
                {
					if (!demoOn)
					{
						// Fail
						OnFail(audioButton);
					}
                }
            }
        }

    #endregion

    #region Getters & Setters

        // Set audio time manager
        public void SetAudioTimeManager(AudioTimeManager audioTimeManager)
        {
            m_AudioTimeManager = audioTimeManager;
        }

    #endregion

    #region Static Manipulators

    /// <summary>
    /// Get instance
    /// </summary>
    /// <returns>GameplayAudioManager instance</returns>
    public static GameplayAudioManager GetInstance()
        {
            return s_Instance;
        }

    #endregion
}
