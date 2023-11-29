using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "new" + nameof(ScriptableEventInt), menuName = "Inputs/Scriptable Input")]
public class ScriptableInput : ScriptableObject
{
   public Action OnPerformed;

   public void Invoke(InputAction.CallbackContext callbackContext)
   {
      if (callbackContext.performed)
      {
         OnPerformed?.Invoke();
      }
   }
}
