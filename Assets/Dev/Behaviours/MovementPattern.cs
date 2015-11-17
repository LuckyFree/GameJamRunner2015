using UnityEngine;
using System.Collections;

public class MovementPattern : MonoBehaviour
{
    #region Attributes

        // Movement speed
        [SerializeField]
        private float m_MovementSpeed = 1;

        // Start transform
        [SerializeField]
        private Transform m_StartTransform = null;

        // End transform
        [SerializeField]
        private Transform m_EndTransform = null;

        // Transform to move
        private Transform m_TransformToMove = null;

        // Lerp t
        private float m_LerpT = 0;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Init position
            transform.position = m_StartTransform.position;

            // Init transform to move
            m_TransformToMove = m_EndTransform;
        }

        // Update is called once per frame
        void Update()
        {
            // Move
            Move();
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Move between specified transforms
        /// </summary>
        private void Move()
        {
            // Set transform to move
            if (m_StartTransform != null && m_EndTransform != null)
            {
                if (transform.position == m_StartTransform.position)
                {
                    m_TransformToMove = m_EndTransform;
                    m_LerpT = 0;
                }
                else if (transform.position == m_EndTransform.position)
                {
                    m_TransformToMove = m_StartTransform;
                    m_LerpT = 0;
                }
            }

            // Move to transform
            Transform startMoveTransform = (m_TransformToMove == m_StartTransform) ? m_EndTransform : m_StartTransform;
            m_LerpT += Time.deltaTime * m_MovementSpeed;
            transform.position = Vector3.Lerp(startMoveTransform.position, m_TransformToMove.position, m_LerpT);
        }

    #endregion
}
