using System;
using System.Collections.Generic;
using System.Linq;
using loja;
using UnityEngine;

namespace mundo
{
    [DisallowMultipleComponent]
    public class Controlador:MonoBehaviour
    {
        private LinkedList<Espaco> espacos = new LinkedList<Espaco>();
        private bool clicado;
        private void Start()
        {
            foreach (var o in GameObject.FindGameObjectsWithTag("Espaço"))
            {
                espacos.AddLast(o.GetComponent<Espaco>());
            }
            foreach (var o in GameObject.FindGameObjectsWithTag("MiniMenu"))
            {
                espacos.AddLast(o.GetComponent<Espaco>());
            }
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var espaco = espacos.Where(e => e.MouseDentro(pos));
            if(!espaco.Any()) return;
            var esp = espaco.First();
            if(esp.gameObject.activeInHierarchy)
                esp.Click();
        }
    }
}