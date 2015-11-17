using UnityEngine;
using System.Collections;

public class AudioButtonSwapper : MonoBehaviour
{
	#region Attributes

		// Swap translation duration
		[SerializeField]
		private float m_SwapTranslationDuration = 1;

		// Instance
		private static AudioButtonSwapper s_Instance = null;

	#endregion

	#region MonoBehaviour

		// Awake
		void Awake()
		{
			if (s_Instance != null)
			{
				Debug.LogWarning("2 audio button swapper in scene, last removed");
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
			// Debug
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Swap();
			}
		}

	#endregion

	#region Public Manipulators

		/// <summary>
		/// Random swap audio buttons
		/// </summary>
		public void Swap()
		{
			int randA = Random.Range(0, 4);
			int randB;

			do
			{
				randB = Random.Range(0, 4);
			}
			while (randB == randA);

			AudioButton buttonA = AudioButton.GetAudioButtonWithID((AudioButton.EButtonID)randA);
			AudioButton buttonB = AudioButton.GetAudioButtonWithID((AudioButton.EButtonID)randB);

			Swap(buttonA, buttonB);
		}

	#endregion

	#region Private Manipulators

		/// <summary>
		/// Swap 2 audio button
		/// </summary>
		/// <param name="leftButton"></param>
		/// <param name="rightButton"></param>
		private void Swap(AudioButton leftButton, AudioButton rightButton)
		{
			/*Vector3 temp = leftButton.transform.position;
			leftButton.transform.position = rightButton.transform.position;
			rightButton.transform.position = temp;*/

			StartCoroutine(CR_SwapTranslation(leftButton, rightButton));
		}

	#endregion

	#region Coroutines

		private IEnumerator CR_SwapTranslation(AudioButton leftButton, AudioButton rightButton)
		{
			float t = 0;
			Vector3 oldLeft = leftButton.transform.position;
			Vector3 oldRight = rightButton.transform.position;

			while (t < m_SwapTranslationDuration)
			{
				t += Time.deltaTime;

				leftButton.transform.position = Vector3.Lerp(oldLeft, oldRight, t / m_SwapTranslationDuration);
				rightButton.transform.position = Vector3.Lerp(oldRight, oldLeft, t / m_SwapTranslationDuration);

				yield return null;
			}
		}

	#endregion

	#region Static Manipulators

		/// <summary>
		/// Get instance
		/// </summary>
		/// <returns></returns>
		public static AudioButtonSwapper GetInstance()
		{
			return s_Instance;
		}

	#endregion
}
