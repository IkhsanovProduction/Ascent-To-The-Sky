using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferCenter : InteractableItemBase
{
    public override void OnInteract()
    {
        if(GameManager.Instance.Player.IsHaveSupplier == true)
        {
            GameManager.Instance.Player.IsHaveGiveToCenter = true;
            GameManager.Instance.Player.IsHaveSupplier = false;
        }
    }
}
