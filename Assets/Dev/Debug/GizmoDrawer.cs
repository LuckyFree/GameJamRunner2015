using UnityEngine;
using System.Collections;

public class GizmoDrawer : MonoBehaviour
{
    #region Attributes

        // Gizmo scale
        [SerializeField]
        private float m_GizmosScale = 1;

    #endregion

    #region MonoBehaviour

        // Gizmos
        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, m_GizmosScale);
        }

    #endregion
}
