using System.Collections.Generic;
using System.Linq;
using Configuration;
using UnityEngine;

namespace Missions
{
    public class StepMatarEnemigos : Step
    {
        private readonly StepMatarEnemigosConfiguration _configuration;
        private readonly Dictionary<string, int> _enemigosParaMatar;

        public StepMatarEnemigos(StepMatarEnemigosConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            _enemigosParaMatar = new Dictionary<string, int>(_configuration.EnemigosaMatar.Count);

            foreach (var datosDeEnemigosAMatar in _configuration.EnemigosaMatar)
            {
                _enemigosParaMatar.Add(datosDeEnemigosAMatar.TipoEnemigo, datosDeEnemigosAMatar.Cantidad);
            }
        }

        public override void Init()
        {
            Debug.Log("Step matar enemigos empezado");
            EventDispatcherService.Instance.Subscribe<EnemigoMuerto>(EnemigoMuerto);
        }

        private void EnemigoMuerto(Signal signal)
        {
            var data = (EnemigoMuerto)signal;

            var ExisteElEnemigoEnElStep = _enemigosParaMatar.ContainsKey(data.EnemyId);
            if (!ExisteElEnemigoEnElStep)
            {
                return;
            }

            DecrementarCantidadEnemigo(data);

            var estanTodosLosEnemigosMuertos = _enemigosParaMatar[data.EnemyId] == 0;
            if (!estanTodosLosEnemigosMuertos)
            {
                return;
            }

            EliminarTipoDeEnemigo(data);

            ComprobarMisionCompletada();
        }

        private void EliminarTipoDeEnemigo(EnemigoMuerto data)
        {
            _enemigosParaMatar.Remove(data.EnemyId);
        }

        private void ComprobarMisionCompletada()
        {
            var quedanEnemigosPorMatar = _enemigosParaMatar.Count > 0;
            if (!quedanEnemigosPorMatar)
            {
                OnStepCompleted?.Invoke(this);
            }
        }

        private void DecrementarCantidadEnemigo(EnemigoMuerto data)
        {
            _enemigosParaMatar[data.EnemyId] -= 1;
        }

        public override void Release()
        {
            Debug.Log("Step matar enemigos terminado");
            EventDispatcherService.Instance.Unsubscribe<EnemigoMuerto>(EnemigoMuerto);
        }
    }
}