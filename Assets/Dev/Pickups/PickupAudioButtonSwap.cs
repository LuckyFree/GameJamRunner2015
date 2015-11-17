using UnityEngine;
using System.Collections;
using System;

public class PickupAudioButtonSwap : Pickup
{
	#region Pickup Override

		/// <summary>
		/// On pick. Swap audio buttons
		/// </summary>
		protected override void OnPick()
		{
			AudioButtonSwapper swapper = AudioButtonSwapper.GetInstance();

			if (swapper != null)
			{
				swapper.Swap();
			}
        }

	#endregion
}
