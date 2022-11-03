using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballGame
{
    class Program
    {
        string getNum()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<int> numList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                numList.Add(i);
            }
            string str = "";
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(0, 10 - i);
                str += numList[index];
                numList.RemoveAt(index);
            }
            return str;
        }
        static void Main(string[] args)
        {
            Program p = new Program();

            bool end = false; ;
            bool retry = false;
            while (true)
            {
                if (end) break;
                Console.WriteLine("야구게임\n"+
                    "1. 0~9까지 서로 다른 숫자로 이루어진 세자리 숫자가 나옵니다.\n"+
                    "2. 숫자는 맞지만 위치가 틀렸을 때는 볼\n" +
                    "3. 숫자와 위치가 전부 맞으면 스트라이크\n" +
                    "4. 숫자와 위치가 전부 틀리면 아웃\n" +
                    "5. 세자리 숫자를 맞추면 승리입니다."
                    );
                Console.WriteLine("시작하기: Y         종료하기: N");

                while (true) 
                {
                    char key = Console.ReadKey(true).KeyChar;
                    if (key == 'n' || key == 'N')
                    {
                        end = true;
                        break;
                    }
                    else if (key == 'y' || key == 'Y') break;
                }
                if (end) break;
                Console.Clear();

                string sol = p.getNum();
                int cnt = 0;
                int s = 0;
                int b = 0;
                int o = 0;
                while (true)
                {
                    Console.WriteLine($"Strike: {s}   Ball: {b}   Out: {o}");
                    String input = Console.ReadLine();
                    int ans;
                    if (!Int32.TryParse(input, out ans))
                    {
                        Console.Clear();
                        Console.WriteLine("숫자를 입력해주세요");
                        char key = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                    }
                    else if(input.Length != 3)
                    {
                        Console.Clear();
                        Console.WriteLine("3자리 숫자를 입력해주세요");
                        char key = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                    }
                    else if(input[0] == input[1] || input[1] == input[2] || input[2] == input[0])
                    {
                        Console.Clear();
                        Console.WriteLine("서로 다른 숫자를 입력해주세요");
                        char key = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                    }
                    else
                    {
                        cnt++;
                        int ss = 0;
                        int bb = 0;
                        int oo = 0;
                        for(int i = 0; i < 3; i++)
                        {
                            if (sol[i] == input[i]) ss++;
                            else if (sol.Contains(input[i])) bb++;
                            else oo++;
                        }

                        if (ss == 3)
                        {
                            end = true;
                            Console.Clear();
                            Console.WriteLine($"정답입니다! 시도 횟수: {cnt}회\n"+
                                "다시하시겠습니까? (y/n)");
       
                            while (true)
                            {
                                char key = Console.ReadKey(true).KeyChar;
                                if (key == 'n' || key == 'N')
                                {
                                    retry = false; ;
                                    break;
                                }
                                else if (key == 'y' || key == 'Y')
                                {
                                    retry = true;
                                    break;
                                }
                                if (retry) break;
                            }
                            if (retry) end = false;
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            s = ss;
                            b = bb;
                            o = oo;
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }
}
