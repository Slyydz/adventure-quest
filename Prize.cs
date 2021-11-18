using System;

namespace adventure_quest
{
    public class Prize
    {
        private string _text = "";

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer user)
        {
            if (user.Awesomeness > 0)
            {
                for (int i = 0; i < user.Awesomeness; i++)
                {
                    Console.WriteLine(_text);
                }
            }
            else
            {
                Console.WriteLine("Ughhh no prize for you");
            }
        }
    }
}
