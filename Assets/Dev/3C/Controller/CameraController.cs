using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	#region Attributes

		// Movement speed
		[SerializeField]
		private float m_MovementSpeed = 1;

		// Instance
		private static CameraController s_Instance = null;

		// Camera acceleration
		[SerializeField]
		private float m_Acceleration = 1;

	#endregion

	void Awake()
	{
		if (s_Instance != null)
		{
			Debug.LogWarning("2 camera in scene, last removed");
			GameObject.Destroy(gameObject);
		}
		else
		{
			s_Instance = this;
		}
	}

	// Use this for initialization
	// Use this for initialization
	void Start()
	{
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		Screen.SetResolution(256, 240, true);
		float targetaspect = 256.0f / 240.0f;

		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;

		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();

		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}
	}
	// Update is called once per frame
	void Update()
	{
		// Move in right direction
		Move();
	}

	#region Private Manipulators

		/// <summary>
		/// Auto move in right direction
		/// </summary>
		private void Move()
		{
			m_MovementSpeed += Time.deltaTime * m_Acceleration;
			Vector3 direction = Vector3.right * m_MovementSpeed;
			transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime);
		}

	#endregion

	#region Static Manipulators

		public static CameraController GetInstance()
		{
			return s_Instance;
		}

	#endregion
}
