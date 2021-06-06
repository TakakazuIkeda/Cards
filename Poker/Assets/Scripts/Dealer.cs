using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{

    public const int PlayerDealNum = 5;
    public List<Card> GameDeck = new List<Card>();
    public List<Card> PlayerHand = new List<Card>();

    // Start is called before the first frame update
    private void Start()
    {
        GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CardDeal();
        }
    }


    private void CardDeal()
    {
        PlayerHand.Clear();

        if (GameDeck.Count > PlayerDealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }

        for (int i = 0; i < PlayerDealNum; i++)
        {
            PlayerHand.Add(Deck.GetCard(GameDeck));
        }

        foreach(var card in PlayerHand) {
            Debug.Log($"{card.CardSuit}:{card.CardNumber}");
        }

        Debug.Log(PokerHand.CardHand(PlayerHand));

    }
    

}
