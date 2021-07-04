using System;
using UnityEngine;

namespace loja
{
    public abstract class Espaco : MonoBehaviour
    {
        public bool MouseDentro(Vector3 vec) => GetComponent<Collider2D>().OverlapPoint(vec);

        public abstract void Click();
    }
}