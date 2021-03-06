using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bet Bet;
    public List<Card> PlayerHand = new List<Card>();
    // 配列（int型の塊）を５つ用意、初期段階では[-1,-1,-1,-1,-1]
    // その中の-1だったら引数の数値を代入して処理を抜ける
    public int[] CardChanges = new int[5];
    public bool CardChange = false;

    private void Start()
    {
        ResetCardChanges();
    }

    public void CardChangeChoice(int changeNum)
    {
        // 札交換を１枚以上実施した際
        for (int i = 0; i < CardChanges.Length; i++)
        {
            if (CardChanges[i] == -1)
            {
                CardChanges[i] = changeNum;
                break;
            }
        }
    }

    // 札交換が実施された際
    public void CardChangeDone()
    {
        CardChange = true;
    }

    // 
    public void ResetCardChanges()
    {
        for (int i = 0; i < CardChanges.Length; i++)
        {
            CardChanges[i] = -1;
        }
    }

    // bet枚数を確認
    public void PlayerChipBet(int BetNum)
    {
        Bet.ChipBet(BetNum, true);
    }
}
