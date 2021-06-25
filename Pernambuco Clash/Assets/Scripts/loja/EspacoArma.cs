using UnityEngine;

namespace loja
{
    public class EspacoArma : Espaco
    {
        //greatest outcast
        public GameObject canhao;
        public override void Click()
        {
            gameObject.SetActive(false);
            var go = Instantiate(canhao);
            go.transform.position = transform.position;
        }
    }
}