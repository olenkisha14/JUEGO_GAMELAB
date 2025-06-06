using System;
using UnityEngine;
using Yarn.Unity;

namespace YarnSpinner_clase.Scripts
{
    public class DialogueCharacterManager : MonoBehaviour
    {
        // new DialogueCharacterController[0];
        [SerializeField] private DialogueCharacterController[] charactersInScene = Array.Empty<DialogueCharacterController>();
        [SerializeField] private DialogueRunner dialogueRunner;

        private void Awake()
        {
            dialogueRunner.AddCommandHandler<string>(
                "active_character",
                ToggleCharacter
                );
        }

        private void OnDestroy()
        {
            dialogueRunner.RemoveCommandHandler("active_character");
        }

        private void ToggleCharacter(string characterName)
        {
            foreach (var character in charactersInScene)
            {
                character.ToggleCharacter(character.name == characterName);
            }
        }
    }
}