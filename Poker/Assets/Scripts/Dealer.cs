using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    // 5枚になるまで配布
    public const int DealNum = 5;

    public List<Card> GameDeck = new List<Card>();
    // 両者に5枚ずつを配布
    public Image[] PlayerCards = new Image[5];
    public Image[] EnemyCards = new Image[5];

    public SpriteAtlas spriteAtlas;

    public GameResult GameResult;

    public Player Player;

    public CPUPlayer CPUPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        // DeckをShuffle
        GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
    }

    public void CardDeal()
    {
        Player.PlayerHand.Clear();
        // Deckの枚数が、これから配布する枚数より少ないとき、Deckを再Shuffle
        if (GameDeck.Count < DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        // Deckの枚数が、これから配布する枚数以上の時、DeckからPlayerに手札を配布する
        for (int i = 0; i < DealNum; i++)
        {
            Player.PlayerHand.Add(Deck.GetCard(GameDeck));
        }

        CPUPlayer.CPUHand.Clear();
        // Deckの枚数が、これから配布する枚数より少ないとき、Deckを再Shuffle
        if (GameDeck.Count < DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        // Deckの枚数が、これから配布する枚数以上の時、DeckからCPUPlayerに手札を配布する
        for (int i = 0; i < DealNum; i++)
        {
            CPUPlayer.CPUHand.Add(Deck.GetCard(GameDeck));
        }
    }
    //各プレイヤーが求めた枚数だけ札交換を行う
    public void CardChange(int[] changeNum)
    {
        for (int i = 0; i < changeNum.Length; i++)
        {
            if (changeNum[i] != -1)
            {
                // Playerが求めた枚数だけ手札から取り除く
                Player.PlayerHand.RemoveAt(changeNum[i]);
                // 山札から新たに手札へ加える
                Player.PlayerHand.Insert(changeNum[i],Deck.GetCard(GameDeck));
            }
        }
    }

    public void CardView()
    {
        for (int i = 0; i < Player.PlayerHand.Count; i++)
        {
            PlayerCards[i].sprite = spriteAtlas.GetSprite(
                $"Card_{(int)Player.PlayerHand[i].CardSuit * 13 + Player.PlayerHand[i].CardNumber - 1}");
            // LogにPlayer手札のSuitとNumberを表示
            Debug.Log($"Player:{Player.PlayerHand[i].CardSuit}:{Player.PlayerHand[i].CardNumber}");
        }

        for (int i = 0; i < CPUPlayer.CPUHand.Count; i++)
        {
            EnemyCards[i].sprite = spriteAtlas.GetSprite(
                $"Card_{(int)CPUPlayer.CPUHand[i].CardSuit * 13 + Player.PlayerHand[i].CardNumber - 1}");
            // LogにCPU手札のSuitとNumberを表示
            Debug.Log($"{CPUPlayer.CPUHand[i].CardSuit}:{CPUPlayer.CPUHand[i].CardNumber}");
        }
    }

        public void GameJudge()
        {
            //Logに両者の手役を表示
            Debug.Log($"自分の手役は{PokerHand.CardHand(Player.PlayerHand)}");
            Debug.Log($"相手の手役は{PokerHand.CardHand(Player.PlayerHand)}");
            GameResult.GameResultTextView(PokerHand.CardHand(CPUPlayer.CPUHand) < PokerHand.CardHand(Player.PlayerHand));
        }
    
}