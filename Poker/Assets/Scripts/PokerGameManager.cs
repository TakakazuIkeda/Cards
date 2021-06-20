using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerGameManager : MonoBehaviour
{
    public enum GameState
    {
        Init = 0,
        Start,
        Deal,
        Bet,
        CardChange,
        ShowDown,
        Result
    }

    public GameState gameState = GameState.Init;

    public Dealer Dealer;
    public Player Player;
    public CPUPlayer CPUPlayer;
    public Chip Chip;
    
    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Init:
                // ������������̂�����Ώ���������Start��
                gameState = GameState.Start;
                break;
            case GameState.Start:
                // �e�v���C���[���Q���`�b�v�P��������ɏo���B�I����Deal��
                gameState = GameState.Deal;
                break;
            case GameState.Deal:
                // ���v���C���[�ւT�����J�[�h��z��B�I����Bet��
                Dealer.CardDeal();
                Dealer.CardView();
                gameState = GameState.Bet;
                break;
            case GameState.Bet:
                // ���͔C�Ӄ`�b�v�����̃r�b�g�����s�A���̓R�[�������C�Y��I���B
                // ���C�Y�̏ꍇ�A���̓R�[�����h���b�v��I���B�I����CardChange��
                Player.PlayerChipBet(1);
                CPUPlayer.CPUChipBet(1);
                gameState = GameState.CardChange;
                break;
            case GameState.CardChange:
                // ��D�T�����������]�ގD��I�����A�R�D�ƌ�������B�I����ShowDown��
                if (Player.CardChange)
                {
                    Dealer.CardChange(Player.CardChanges);
                    Dealer.CardView();
                    gameState = GameState.ShowDown;
                }
                break;
            case GameState.ShowDown:
                // ��D�����J���A���̗D��ɂ�菟�s�𔻒肷��B�I����Result��
                Dealer.GameJudge();
                gameState = GameState.Result;
                break;
            case GameState.Result:
                break;
        }     
    }
}
