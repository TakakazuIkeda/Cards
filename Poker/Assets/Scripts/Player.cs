using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bet Bet;
    public List<Card> PlayerHand = new List<Card>();
    // �z��iint�^�̉�j���T�p�ӁA�����i�K�ł�[-1,-1,-1,-1,-1]
    // ���̒���-1������������̐��l�������ď����𔲂���
    public int[] CardChanges = new int[5];
    public bool CardChange = false;

    private void Start()
    {
        ResetCardChanges();
    }

    public void CardChangeChoice(int changeNum)
    {
        // �D�������P���ȏ���{������
        for (int i = 0; i < CardChanges.Length; i++)
        {
            if (CardChanges[i] == -1)
            {
                CardChanges[i] = changeNum;
                break;
            }
        }
    }

    // �D���������{���ꂽ��
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

    // bet�������m�F
    public void PlayerChipBet(int BetNum)
    {
        Bet.ChipBet(BetNum, true);
    }
}
