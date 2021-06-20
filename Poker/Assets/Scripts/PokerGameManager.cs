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
                // 初期化するものがあれば初期化してStartへ
                gameState = GameState.Start;
                break;
            case GameState.Start:
                // 各プレイヤーが参加チップ１枚ずつを場に出す。終わればDealへ
                gameState = GameState.Deal;
                break;
            case GameState.Deal:
                // 両プレイヤーへ５枚ずつカードを配る。終わればBetへ
                Dealer.CardDeal();
                Dealer.CardView();
                gameState = GameState.Bet;
                break;
            case GameState.Bet:
                // 先手は任意チップ枚数のビットを実行、後手はコールかレイズを選択。
                // レイズの場合、先手はコールかドロップを選択。終わればCardChangeへ
                Player.PlayerChipBet(1);
                CPUPlayer.CPUChipBet(1);
                gameState = GameState.CardChange;
                break;
            case GameState.CardChange:
                // 手札５枚から交換を望む札を選択し、山札と交換する。終わればShowDownへ
                if (Player.CardChange)
                {
                    Dealer.CardChange(Player.CardChanges);
                    Dealer.CardView();
                    gameState = GameState.ShowDown;
                }
                break;
            case GameState.ShowDown:
                // 手札を公開し、役の優劣により勝敗を判定する。終わればResultへ
                Dealer.GameJudge();
                gameState = GameState.Result;
                break;
            case GameState.Result:
                break;
        }     
    }
}
