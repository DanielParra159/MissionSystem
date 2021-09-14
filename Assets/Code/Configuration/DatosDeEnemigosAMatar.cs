using System;
using UnityEngine;

namespace Configuration
{
    [Serializable]
    public class DatosDeEnemigosAMatar
    {
        [SerializeField]
        private string _tipoEnemigo;
        [SerializeField]
        private int _cantidad;

        public string TipoEnemigo => _tipoEnemigo;

        public int Cantidad => _cantidad;
    }
}