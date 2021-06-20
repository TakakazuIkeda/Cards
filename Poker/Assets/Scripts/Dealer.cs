using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    // 5���ɂȂ�܂Ŕz�z
    public const int DealNum = 5;

    public List<Card> GameDeck = new List<Card>();
    // ���҂�5������z�z
    public Image[] PlayerCards = new Image[5];
    public Image[] EnemyCards = new Image[5];

    public SpriteAtlas spriteAtlas;

    public GameResult GameResult;

    public Player Player;

    public CPUPlayer CPUPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        // Deck��Shuffle
        GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
    }

    public void CardDeal()
    {
        Player.PlayerHand.Clear();
        // Deck�̖������A���ꂩ��z�z���閇����菭�Ȃ��Ƃ��ADeck����Shuffle
        if (GameDeck.Count < DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        // Deck�̖������A���ꂩ��z�z���閇���ȏ�̎��ADeck����Player�Ɏ�D��z�z����
        for (int i = 0; i < DealNum; i++)
        {
            Player.PlayerHand.Add(Deck.GetCard(GameDeck));
        }

        CPUPlayer.CPUHand.Clear();
        // Deck�̖������A���ꂩ��z�z���閇����菭�Ȃ��Ƃ��ADeck����Shuffle
        if (GameDeck.Count < DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        // Deck�̖������A���ꂩ��z�z���閇���ȏ�̎��ADeck����CPUPlayer�Ɏ�D��z�z����
        for (int i = 0; i < DealNum; i++)
        {
            CPUPlayer.CPUHand.Add(Deck.GetCard(GameDeck));
        }
    }
    //�e�v���C���[�����߂����������D�������s��
    public void CardChange(int[] changeNum)
    {
        for (int i = 0; i < changeNum.Length; i++)
        {
            if (changeNum[i] != -1)
            {
                // Player�����߂�����������D�����菜��
                Player.PlayerHand.RemoveAt(changeNum[i]);
                // �R�D����V���Ɏ�D�։�����
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
            // Log��Player��D��Suit��Number��\��
            Debug.Log($"Player:{Player.PlayerHand[i].CardSuit}:{Player.PlayerHand[i].CardNumber}");
        }

        for (int i = 0; i < CPUPlayer.CPUHand.Count; i++)
        {
            EnemyCards[i].sprite = spriteAtlas.GetSprite(
                $"Card_{(int)CPUPlayer.CPUHand[i].CardSuit * 13 + Player.PlayerHand[i].CardNumber - 1}");
            // Log��CPU��D��Suit��Number��\��
            Debug.Log($"{CPUPlayer.CPUHand[i].CardSuit}:{CPUPlayer.CPUHand[i].CardNumber}");
        }
    }

        public void GameJudge()
        {
            //Log�ɗ��҂̎����\��
            Debug.Log($"�����̎����{PokerHand.CardHand(Player.PlayerHand)}");
            Debug.Log($"����̎����{PokerHand.CardHand(Player.PlayerHand)}");
            GameResult.GameResultTextView(PokerHand.CardHand(CPUPlayer.CPUHand) < PokerHand.CardHand(Player.PlayerHand));
        }
    
}