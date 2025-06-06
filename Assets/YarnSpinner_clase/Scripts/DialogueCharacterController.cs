using UnityEngine;
using Yarn.Unity;

namespace YarnSpinner_clase.Scripts
{
    /// <summary>
    /// Componente que permite controlar las propiedades del personaje durante la escena de diálogo.
    /// RequireComponent es un atributo de Unity que lo obliga a añadir un componente del tipo especificado
    /// como parámetro.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class DialogueCharacterController : MonoBehaviour
    {
        // Referencia al SO de datos del personaje, contiene las poses y funcionalidades necesarias para obtener los datos.
        [SerializeField] private DialogueCharacterData data;
        [SerializeField] private Color activeColor = Color.white;
        [SerializeField] private Color inactiveColor = Color.white;

        private SpriteRenderer _renderer;
        
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            data.SetUp();
        }

        private void OnDestroy()
        {
            data.Dispose();
        }

        private void Start()
        {
            ToggleCharacter(false);
        }

        /// <summary>
        /// Método que permite cambiar la pose de un personaje en escena.
        /// </summary>
        /// <param name="poseName">Nombre de la pose deseada.</param>
        [YarnCommand("change_pose")]
        public void ChangePose(string poseName)
        {
            _renderer.sprite = data.GetPose(poseName);
        }

        /// <summary>
        /// Método que permite cambiar el estado del personaje para indicar si está activo o no, o sea,
        /// quién es el que está hablando en ese instante.
        /// </summary>
        /// <param name="active"></param>
        [YarnCommand("toggle_character")]
        public void ToggleCharacter(bool active)
        {
            _renderer.color = active ? activeColor : inactiveColor;
        }
    }
}