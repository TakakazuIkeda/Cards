using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bet : MonoBehaviour
{
    public Chip Chip;
    public bool CheckBet(int betNum, bool isPlayer)
    {
        if (isPlayer)
        {
            // Playerのbet枚数が手持ち枚数を下回ること
            return Chip.PlayerChip > betNum;
        }
        else
        {
            // CPUのbet枚数が手持ち枚数を下回ること
            return Chip.CPUChip > betNum;
        }
    }

    public void ChipBet(int betNum, bool isPlayer)
    {
        if (!CheckBet(betNum, isPlayer))
        {
            Debug.LogError("betすることができません");
            return;
        }

        if (isPlayer)
        {
            // Playerの手持ち枚数からbet枚数を引く
            Chip.PlayerChip -= betNum;
        }
        else
        {
            // CPUの手持ち枚数からbet枚数を引く
            Chip.CPUChip -= betNum;
        }
        // 場に出ているチップ枚数に両者がbetした枚数を加える
        Chip.GameChip += betNum;
    }
}
