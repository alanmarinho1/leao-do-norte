using System;
using System.IO;
using System.Linq;
using inimigo;
using Unity.Collections;
using UnityEngine;

namespace mundo
{
    [DisallowMultipleComponent]
    public class Gerador :MonoBehaviour
    {
        [Header("Configuração do nivel")]
        [Tooltip("Local de onde onde os inimigos serão instanciados")]
        public GameObject local;
        //[HideInInspector]
        public int index;

        [Header("Configuração dos inimigos")]
        [Tooltip("Caminho pro arquivo de criação de monstro")]
        public string caminho;
        
        [Tooltip("lista de inimigos que serão instanciados bem como tempo para o proximo")]
        [ReadOnly]
        public Instanciacao[] _instanciacao;

        
        private void Start()
        {
            _instanciacao = Instanciacao.ApartirDeArquivo(caminho);
            index = 0;
            Gerar();
        }

        private void Update()
        {
            if (index >= _instanciacao.Length) return;
            if (!_instanciacao[index].tick()) return;
            ++index;
            Gerar();
        }

        protected void Gerar()
        {
            if(index >= _instanciacao.Length) return;
            if(_instanciacao[index].prefab == null) return;
            var prefab = Instantiate(_instanciacao[index].prefab);
            prefab.transform.position = local.transform.position;
        }
    }
}