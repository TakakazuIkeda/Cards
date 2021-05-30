using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {

    public Suit CardSuit;
    public int CardNumber;

    public Card(Suit suit, int cardNumber) {
        this.CardSuit = suit;
        this.CardNumber = cardNumber;
    }

    /// <summary>
    /// クラブ、ダイアなどの役
    /// </summary>
    public enum Suit
    {
        Invalid = -1,
        Club,
        Dia,
        Heart,
        Spade,
        Max
    };


    public static Suit CardSuitJudge(int cardNum)
    {
        int suitNumber = 0;
        // cardNumを割って余りを除去した数字をenum型のSuitにキャストして返します
        for (int i = 0; i < (int)Suit.Max; i++)
        {
            if (cardNum / 13 == i)
            {
                suitNumber = i;
            }
        }
        return (Suit)suitNumber;
    }

    public static int CardNumJudge(int cardNum)
    {
        int cardNumber = 0;
        //cardNumを割ったあまりを返します
        for (int i = 0; i < 13; i++)
        {
            if (cardNum % 13 == i)
            {
                cardNumber = i + 1;
            }
        }
        return cardNumber;
    }
}