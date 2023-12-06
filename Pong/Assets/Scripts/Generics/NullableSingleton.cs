using UnityEngine;

namespace Pilgrims.Generics
{
    public class NullableSingleton<T> : MonoBehaviour where T : Component
    {
        private static T m_instance;
        public static T Instance
        {
            get => m_instance;
            private set
            {
                m_instance = value;
            }
        }

        private void Awake()
        {
            OnAwake();
        }

        public void OnAwake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (m_instance == this)
            {
                m_instance = null;
            }
        }
    }
}
