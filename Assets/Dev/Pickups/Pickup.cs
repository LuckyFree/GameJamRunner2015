using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Pickup : MonoBehaviour
{
	#region MonoBehaviour

		// On trigger enter
		private void OnTriggerEnter2D(Collider2D collider)
		{
			CharacterManager character = collider.gameObject.GetComponent<CharacterManager>();

			if (character != null)
			{
				OnPick();
			}
		}
	
		// On colliosion enter
		private void OnCollisionEnter2D(Collision2D collision)
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
