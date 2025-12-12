using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Controller
{
    public override Vector2 GetMovementInput() => _moveDir;

    public void MoveForward() => _moveDir = Vector2.up;
    public void MoveBack() => _moveDir = Vector2.down;
    public void MoveLeft() => _moveDir = Vector2.left;
    public void MoveRight() => _moveDir = Vector2.right;
    public void MoveStatic() => _moveDir = Vector2.zero;
}
