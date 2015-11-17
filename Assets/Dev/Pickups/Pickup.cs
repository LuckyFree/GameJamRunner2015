using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Pickup : MonoBehaviour
{
	#region MonoBehaviour
	
		// On colliosion enter
		private void OnCollisionEnter(Collision collision)
		{
			CharacterManager character = collision.gameObject.GetComponent<CharacterManager>();

			if (character != null)
			{
				OnPick();
			}
		}

	#endregion

	#region Private Manipulators

		/// <summary>
		/// On pick
		/// </summary>
		protected abstract void OnPick();

	#endregion
}
