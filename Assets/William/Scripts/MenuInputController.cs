using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Player;
using UnityEngine;

public class MenuInputController : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private MenuManager _menuManager;
    private void OnEnable()
    {
        if (_menuManager == null)
            _menuManager = GetComponent<MenuManager>();
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();
            // _playerInputs.PlayerActions.Movement.performed +=
            //   (val) => _menuManager.HandleMovement(val.ReadValue<Vector2>());
            //_playerInputs.PlayerActions.Jump.performed += (val) => _playerController.HandleJump();
            //_playerInputs.PlayerActions.Jump.canceled += (val) => _playerController.CancelJump();
            _playerInputs.Menu.Select.performed += (val) => _menuManager.HandleSelect(val.ReadValue<Vector2>());
            _playerInputs.Menu.Confirm.performed += (val) => _menuManager.HandleConfirm();


        }
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
