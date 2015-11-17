using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AudioTimeReader : MonoBehaviour
{
    #region Attributes

        // File path
        [SerializeField]
        private string m_Filepath = "";

        // Time per sample
        [SerializeField]
        private float m_TimePerSample = 1;

        // Button A label
        [SerializeField]
        private string m_ButtonALabel = "Snare";

        // Button B label
        [SerializeField]
        private string m_ButtonBLabel = "HH";

        // Button C label
        [SerializeField]
        private string m_ButtonCLabel = "Bell";

        // Button D label
        [SerializeField]
        private string m_ButtonDLabel = "Kick";

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            ReadFile();
        }

        // Update is called once per frame
        void Update()
        {

        }

    #endregion

    #region Private Manipulators

        private void ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(m_Filepath);

                string line = "";

                AudioTimeManager audioTimeManager = new AudioTimeManager();

                while ((line = sr.ReadLine()) != null)
                {
                    AudioInputSettings settings = new AudioInputSettings();

					settings.buttonIDList = new List<AudioButton.EButtonID>();

                    // Read button label
                    if (line.ToLower().Contains(m_ButtonALabel.ToLower()))
                    {
                        settings.buttonIDList.Add(AudioButton.EButtonID.ButtonA);
                    }

                    if (line.ToLower().Contains(m_ButtonBLabel.ToLower()))
                    {
                        settings.buttonIDList.Add(AudioButton.EButtonID.ButtonB);
                    }

                    if (line.ToLower().Contains(m_ButtonCLabel.ToLower()))
                    {
                        settings.buttonIDList.Add(AudioButton.EButtonID.ButtonC);
                    }

                    if (line.ToLower().Contains(m_ButtonDLabel.ToLower()))
                    {
                        settings.buttonIDList.Add(AudioButton.EButtonID.ButtonD);
                    }

					// Demo ON / OFF
					settings.isDemoOn = (line.ToLower().Contains("demo on"));

                    // Read time
                    if ((line = sr.ReadLine()) != null)
                    {
                        float time;
                        if (float.TryParse(line, out time))
                        {
                            float minTime = time - m_TimePerSample * 0.5f;
                            float maxTime = time + m_TimePerSample * 0.5f;

                            settings.minTouchTime = minTime;
                            settings.maxTouchTime = maxTime;
                        }
                    }

					audioTimeManager.GetAudioInputSettings().Add(settings);
                }

                if (GameplayAudioManager.GetInstance() != null)
                {
                    GameplayAudioManager.GetInstance().SetAudioTimeManager(audioTimeManager);
                }
            }
            catch (System.Exception err)
            {
                Debug.LogError(err);
            }
        }

    #endregion
}
