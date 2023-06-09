using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bear
{
    public class Animation : MonoBehaviour
    {

        private string[] m_buttonNames = new string[] { "Idle", "Run", "Dead" };

        private Animator m_animator;

        void Start()
        {

            m_animator = GetComponent<Animator>();

        }

        void Update()
        {

        }

        private void OnGUI()
        {
            GUI.BeginGroup(new Rect(0, 0, 150, 1000));

            for (int i = 0; i < m_buttonNames.Length; i++)
            {
                if (GUILayout.Button(m_buttonNames[i], GUILayout.Width(150)))
                {
                    m_animator.SetInteger("AnimIndex", i);
                    m_animator.SetTrigger("Next");
                }
            }

            GUI.EndGroup();
        }
    }
}
