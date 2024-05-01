using UnityEngine;

namespace Hotari
{
    /// <summary>
    /// Rigidbodyのアタッチを保証する基底クラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class RigidbodyEntity : MonoBehaviour
    {
        protected Rigidbody _rigidbody = default!;

        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
