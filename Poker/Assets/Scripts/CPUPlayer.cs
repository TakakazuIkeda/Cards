using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPlayer : MonoBehaviour
{
    public Bet Bet;
    public List<Card> CPUHand = new List<Card>();
    public int[] CardChanges = new int[5];

    public bool CardChangeDone = false;

    private void Start()
    {
        ResetCardChanges();
    }

    public void CardChangeChoice(int changeNum)
    {
        for (int i = 0; i < CardChanges.Length; i++)
        {
            if (CardChanges[i] == -1)
            {
                CardChanges[i] = changeNum;
                break;
            }
        }
    }

    public void ResetCardChanges()
    {
        for (int i = 0; i < CardChanges.Length; i++)
        {
            CardChanges[i] = -1;
        }
    }

    public void CPUChipBet(int BetNum)
    {
        Bet.ChipBet(BetNum, false);
    }
}
