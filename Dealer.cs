using System;
namespace hiloGame
{
    class Card
    {
        public int cardValue;

        /// Make a class that pulls a random card
        public void getNewCard(){
            Random randomGenerator = new Random();
            cardValue = randomGenerator.Next(1,14);
        }
    }
}