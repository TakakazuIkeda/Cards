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
            // Player��bet�������莝������������邱��
            return Chip.PlayerChip > betNum;
        }
        else
        {
            // CPU��bet�������莝������������邱��
            return Chip.CPUChip > betNum;
        }
    }

    public void ChipBet(int betNum, bool isPlayer)
    {
        if (!CheckBet(betNum, isPlayer))
        {
            Debug.LogError("bet���邱�Ƃ��ł��܂���");
            return;
        }

        if (isPlayer)
        {
            // Player�̎莝����������bet����������
            Chip.PlayerChip -= betNum;
        }
        else
        {
            // CPU�̎莝����������bet����������
            Chip.CPUChip -= betNum;
        }
        // ��ɏo�Ă���`�b�v�����ɗ��҂�bet����������������
        Chip.GameChip += betNum;
    }
}
