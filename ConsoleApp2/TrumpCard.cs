using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class TrumpCard_
    {
        private int[] trumpCardSet;     //카드세트
        private string[] trumpCardMark;

        public void SetupTrumpCards()
        {
            trumpCardSet = new int[52];
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;
            } // 카드를 셋업하는 루프

            trumpCardMark = new string[4] {"♥","♠","◈","♣"};
        }
        public void ShuffleCards()
        {
            ShuffleCards(200);
        } //Shufflecards

        public int ReRollCard_()
        {
            ShuffleCards();
            return Rollcard_();
        }
        
        public int Rollcard_()
        {
            int card = trumpCardSet[0];
            string cardMark = trumpCardMark[(card-1) / 13];
            //int cardNumber = (int)Math.Ceiling(card % 13.1);
            string cardNumber = Math.Ceiling(card % 13.1).ToString();

            switch(cardNumber)
            {
                case "11":
                    cardNumber= "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
                default:
                    break;
            }

            Console.WriteLine("내가 뽑은 카드는 {0}{1}입니다.",cardMark, cardNumber);
            Console.WriteLine(" -------");
            Console.WriteLine("|{0}{1}\t|", cardMark, cardNumber);
            Console.WriteLine("|       |");
            Console.WriteLine("|       |");
            Console.WriteLine("|       |");
            Console.WriteLine("|       |");
            Console.WriteLine(" -------");

            return (int)Math.Ceiling(card % 13.1);
        } //Rollcard

        public void PrintCardSet()
        {
            foreach (int card in trumpCardSet)
            {
                Console.Write(" {0} ", card);
            }
        } //PrintCardSet
        private int[] ShuffleOnce(int[] intArray)
        {
            Random random= new Random();
            int sourindex = random.Next(0, intArray.Length);
            int destindex = random.Next(0, intArray.Length);

            int tempVariable = intArray[sourindex];
            intArray[sourindex] = intArray[destindex];
            intArray[destindex] = tempVariable;

            return intArray;
        } //ShuffleOnce

        private void ShuffleCards(int howManyLoop)
        {
            for (int i = 0; i < howManyLoop; i++)
            {
                trumpCardSet = ShuffleOnce(trumpCardSet);
            }
        } //ShuffleCards

    }
}
