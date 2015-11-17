using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    #region Attributes

        // Offset multiplier dec on collision
        [SerializeField]
        private float m_OffsetMulitplierDecOnCollision = 0.25f;

        // Destroy object on collision
        [SerializeField]
        private bool m_DestroyObjectOnCollision = true;

    #endregion

    #region MonoBehaviour

        // On collision enter
        void OnCollisionEnter(Collision collision)
        {
            CharacterManager character = collision.gameObject.GetComponent<CharacterManager>();

            if (character != null)
            {
                // Dec character offset multiplier
                character.DecOffsetMultiplier(m_OffsetMulitplierDecOnCollision);

                // Destroy
                if (m_DestroyObjectOnCollision)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }

    #endregion
}
