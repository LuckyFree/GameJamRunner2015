using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AudioInputSettings
{
    public List<AudioButton.EButtonID> buttonIDList;
    public float minTouchTime = 0;
    public float maxTouchTime = 0;
    private bool isCompleted = false;

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }
}

public class AudioTimeManager
{
    #region Attributes

        // Audio input settings list
        //[SerializeField]
        private List<AudioInputSettings> m_AudioInputSettings = new List<AudioInputSettings>();

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Set audio buttons visibility. Active color if in time
        /// </summary>
        /// <param name="time">Timer</param>
        public void SetAudioButtonsVisibility(float time)
        {
            for (int i = 0; i < 4; i++)
            {
                AudioButton audioButton = AudioButton.GetAudioButtonWithID((AudioButton.EButtonID)i);
                audioButton.SetEnableMode(false);
            }

            for (int i = 0; i < m_AudioInputSettings.Count; i++)
            {
                // Check not completed
                if (!m_AudioInputSettings[i].IsCompleted)
                {
                    // Check time
                    if (time >= m_AudioInputSettings[i].minTouchTime && time <= m_AudioInputSettings[i].maxTouchTime)
                    {
                        for (int j = 0; j < m_AudioInputSettings[i].buttonIDList.Count; j++)
                        {
                            AudioButton audioButton = AudioButton.GetAudioButtonWithID(m_AudioInputSettings[i].buttonIDList[j]);
                            audioButton.SetEnableMode(true);
                        }
                    }
                }
            }
    }

        /// <summary>
        /// Check missing input
        /// </summary>
        /// <param name="time">Timer</param>
        /// <returns></returns>
        public bool CheckMissingInput(float time, out List<AudioButton> audioButtonListMissed)
        {
            audioButtonListMissed = new List<AudioButton>();

            for (int i = 0; i < m_AudioInputSettings.Count; i++)
            {
                // Check not completed
                if (!m_AudioInputSettings[i].IsCompleted)
                {
                    // Check max time elapsed
                    if (time > m_AudioInputSettings[i].maxTouchTime)
                    {
                        m_AudioInputSettings[i].IsCompleted = true;

                        for (int j = 0; j < m_AudioInputSettings[i].buttonIDList.Count; j++)
                        {
                            AudioButton audioButton = AudioButton.GetAudioButtonWithID(m_AudioInputSettings[i].buttonIDList[j]);
                            audioButtonListMissed.Add(audioButton);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if input is valid, based on button ID comaprison and touch time comparison 
        /// </summary>
        /// <param name="audioButton"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsInputValid(AudioButton audioButton, float time)
        {
            for (int i = 0; i < m_AudioInputSettings.Count; i++)
            {
                // Check not completed
                if (!m_AudioInputSettings[i].IsCompleted)
                {
                    // Check button ID
                    if (m_AudioInputSettings[i].buttonIDList.Contains(audioButton.GetAudioButtonID()))
                    {
                        // Check time
                        if (time >= m_AudioInputSettings[i].minTouchTime && time <= m_AudioInputSettings[i].maxTouchTime)
                        {
                            m_AudioInputSettings[i].IsCompleted = true;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    #endregion

    #region Getters & Setters

        // Get audio input settings
        public List<AudioInputSettings> GetAudioInputSettings()
        {
            return m_AudioInputSettings;
        }

    #endregion
}
