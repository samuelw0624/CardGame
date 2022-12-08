using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCommand : CommandManager.ICommand
{
    GameObject card;
    int index;

    public CardCommand(int slotIndex)
    {
        index = slotIndex;
    }

    public void Execute()
    {

    }
}
