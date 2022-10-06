using System;
using System.Collections.Generic;

namespace hiloGame
{
    public class Director
    {
        List<Card> cards = new List<Card>();
        bool isPlaying = true;
        int winningBonus = 100;
        int wrongGuess = 75;
        int totalScore = 300;

        int currentCard;
        int nextCard;
        public Director()
        {
            for (int i = 0; i < 1; i++){
                Card card = new Card();
                cards.Add(card);

            }
        }

        ///Starts hilo game,
        public void StartGame()
        {
            foreach (Card card in cards){
                card.getNewCard();
                currentCard = card.cardValue;
            }
            while (isPlaying)
            {
                MainGame();
                GameCheck();
            }
        }

        public void MainGame(){
            Console.WriteLine($"The card is {currentCard}");
            if (!isPlaying)
            {
                return;
            }

            foreach (Card card in cards){
                card.getNewCard();
                nextCard = card.cardValue;
            }
            Console.Write("Higher or Lower: [h/l]  ");
            string cardGuess = Console.ReadLine();
            Console.WriteLine($"The next card was:{nextCard}");
            if (cardGuess.Equals("h") && currentCard < nextCard){
                totalScore += winningBonus;
            }
            else if(cardGuess.Equals("l") && currentCard > nextCard){
                totalScore += winningBonus;
            }
            else if(cardGuess.Equals("h") && currentCard > nextCard){
                totalScore -= wrongGuess;
                if (totalScore < 0){
                    totalScore = 0;
                }
            }
            else if(cardGuess.Equals("l") && currentCard < nextCard){
                totalScore -= wrongGuess;
                if (totalScore < 0){
                    totalScore = 0;
                }
            }

        }

        /// See if the player can keep playing from their score
        public void GameCheck(){
            Console.WriteLine($"Your score is: {totalScore}");
            if (totalScore == 0){
                isPlaying = false;
            }
            if (!isPlaying)
            {
                return;
            }

            currentCard = nextCard;
            Console.Write("Keep Playing? [y/n] ");
            string rollDice = Console.ReadLine();
            isPlaying = (rollDice == "y");
        }
    }
}