using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    #region Attributes

        // Offset multiplier dec on collision
        [SerializeField]
        private float m_TrainOffsetMultiplierIncOnCollision = 0.25f;

        // Destroy object on collision
        [SerializeField]
        private bool m_DestroyObjectOnCollision = true;

    #endregion

    #region MonoBehaviour

        // On collision enter
        void OnCollisionEnter2D(Collision2D collision)
        {
            CharacterManager character = collision.gameObject.GetComponent<CharacterManager>();

            if (character != null)
            {
                // Inc train offset multiplier
				TrainController train = TrainController.GetInstance();

				if (train != null)
				{
					train.IncOffsetMultiplier(m_TrainOffsetMultiplierIncOnCollision);
				}

                // Destroy
                if (m_DestroyObjectOnCollision)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }

    #endregion
}
