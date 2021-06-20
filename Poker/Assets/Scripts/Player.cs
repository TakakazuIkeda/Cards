using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bet Bet;
    public List<Card> PlayerHand = new List<Card>();
    // ”z—ñiintŒ^‚Ì‰òj‚ğ‚T‚Â—pˆÓA‰Šú’iŠK‚Å‚Í[-1,-1,-1,-1,-1]
    // ‚»‚Ì’†‚Ì-1‚¾‚Á‚½‚çˆø”‚Ì”’l‚ğ‘ã“ü‚µ‚Äˆ—‚ğ”²‚¯‚é
    public int[] CardChanges = new int[5];
    public bool CardChange = false;

    private void Start()
    {
        ResetCardChanges();
    }

    public void CardChangeChoice(int changeNum)
    {
        // DŒğŠ·‚ğ‚P–‡ˆÈãÀ{‚µ‚½Û
        for (int i = 0; i < CardChanges.Length; i++)
        {
            if (CardChanges[i] == -1)
            {
                CardChanges[i] = changeNum;
                break;
            }
        }
    }

    // DŒğŠ·‚ªÀ{‚³‚ê‚½Û
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

    // bet–‡”‚ğŠm”F
    public void PlayerChipBet(int BetNum)
    {
        Bet.ChipBet(BetNum, true);
    }
}
