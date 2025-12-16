using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : Controller
{
    public override Vector2 GetMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        return moveInput;
    }
}
