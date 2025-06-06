using System;
using System.Collections.Generic;
using UnityEngine;

namespace YarnSpinner_clase.Scripts
{
    /// <summary>
    /// Clase que asigna un nombre a cada pose de un personaje.
    /// </summary>
    [Serializable]
    public class DialogueCharacterPose
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        
        public string Name => name;
        public Sprite Sprite => sprite;
    }
    
    /// <summary>
    /// Clase tipo Scriptable Object (abreviado, SO) que permite almacenar datos que podemos reutilizar en cualquier escena.
    /// CreateAssetMenu es necesario para cualquier SO que se quiera crear manualmente desde el contexto Create (visto
    /// apretando click derecho en la ventana de proyecto).
    ///
    /// Tener en cuenta que los valores de un SO persisten durante la ejecución del juego (en build) y durante la sesión
    /// de Unity actual (hasta que se cierre el programa).
    /// </summary>
    [CreateAssetMenu(fileName = "New Dialogue Character Data", menuName = "Scriptable Objects/Dialogue/Dialogue Character Data")]
    public class DialogueCharacterData : ScriptableObject
    {
        // Array para almacenar todas las poses de un personaje.
        [SerializeField] private DialogueCharacterPose[] poses;

        // Diccionario que permite obtener una pose de personaje a base de un nombre definido.
        private readonly Dictionary<string, Sprite> _poses = new();

        /// <summary>
        /// Método para inicializar este SO que contiene los datos de un personaje.
        /// </summary>
        public void SetUp()
        {
            // Inicializar el diccionario de poses tomando como llave el nombre de la pose y como valor
            // el sprite asociado.
            foreach (var pose in poses)
            {
                _poses[pose.Name] = pose.Sprite;
            }
        }

        /// <summary>
        /// Método para limpiar valores innecesarios al terminar una prueba en Play Mode.
        /// </summary>
        public void Dispose()
        {
            // Limpiar el diccionario, ya que un SO no va a eliminar sus valores hasta cerrar Unity o el build.
            _poses.Clear();
        }
        
        /// <summary>
        /// Obtener el sprite correspondiente al nombre de una pose.
        /// </summary>
        /// <param name="poseName">Nombre de la pose que se desea obtener.</param>
        /// <returns>El sprite de pose correspondiente al nombre brindado.</returns>
        public Sprite GetPose(string poseName)
        {
            return _poses[poseName];
        }
    }
}