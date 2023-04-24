using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace JJJ10
{
    internal class Program
    {
        static private float CircleRound(float radius)
        {
            return radius * 2f * 3.141519f;
        }

        static void Main(string[] args)
        {
            // 1교시 (확장 메소드)
            #region
            /* 
               // 확장 메소드
               // = 특정 자료형을 대상으로 함수를 추가하는 기능

               float radius = 3.5f;
               Console.WriteLine("멤버 함수 호출 : " + CircleRound(radius));
               Console.WriteLine("확장 메소드 호출 : " + radius.CirCleRound());


               // Array 클래스는 무슨 자료형이 들어올지 명확하지 않다. 때문에 Tostring 함수가 포함 되어 있지 않다.
               // 그렇기에 메소드를 활용하여 문자열로 표현 해줄수 있는 함수를 확장해주어야한다.
               string[] strArray = { "AAA", "BBB", "CCC" };
               Console.WriteLine(strArray);

               Console.WriteLine($"ToString() 호출 시 : {strArray}");
               Console.WriteLine($"ToStringArray() 호출 시 : {strArray.ToStringArray()}");

               // Q. int자료형에 대해 제곱수를 반환하는 함수를 확장하라.

               int a = 99;
               Console.WriteLine($"{a}의 제곱수 : {a.SquareInt()}");

               a = 20;
               Console.WriteLine($"{a}를 4로 나눈 값은 : {a.Remainder(4)}");

   */
            #endregion

            // 2교시
            #region
            /*
                        // 문자열 다루기
                        string str = "Today is monday";

                        // Split (문자열 나누기)
                        // 무엇을 기준으로 나눌 것인가를 매개변수로 선택한다. 값을 받는 변수는 string이어야한다.
                        // csv형태로 잘린 문서를 읽을 때 사용한다.
                        string[] strArray2 = str.Split(' ');
                        for (int i = 0; i < strArray2.Length; i++)
                        {
                            Console.WriteLine($"{i}번째 문자열은 "+ strArray2[i]);
                        }

                        // IndexOf() (인덱스 찾기)
                        // 특정 문자열(문자) 가 몇번째 인덱스부터 시작하는지 int 값을 리턴한다.
                        // 통상적으로 -1을 리턴받으면 잘못되었거나 값이 없다는 등의 뜻이다.
                        Console.WriteLine($"monday는 {str.IndexOf("monday")}번째부터 시작합니다.");
                        Console.WriteLine($"monday는 {str.IndexOf("is")}번째부터 시작합니다.");
                        Console.WriteLine($"monday는 {str.IndexOf("Today")}번째부터 시작합니다.");

                        // SubString (문자열 자르기)
                        // 
                        Console.WriteLine();
                        Console.WriteLine($"3번부터 자르면 : {str.Substring(3)}");
                        Console.WriteLine($"3번부터 4개만 자르라 : {str.Substring(3,4)}");

                        // Replace(문자열 대체)
                        // 특정 문자를 원하는 문자로 바꿔준다.
                        Console.WriteLine($"Replace : {str.Replace("monday", "friday")}");

                        // 대소문자 변경
                        str = "Hello world";
                        Console.WriteLine($"str == Hello World : {str.ToLower() == "hello world"}");
                        Console.WriteLine($"Upper : {str.ToUpper ()}");
                        Console.WriteLine($"Lower : {str.ToLower ()}");

                        // Trim (공백 제거하기)
                        str = "Hello World";
                        string compare = "hello world";
                        str = str.Trim();       // 양측 공백 제거
                        str = str.TrimEnd();    // 뒤쪽 공백 제거
                        str = str.TrimStart();  // 앞쪽 공백 제거

                        Console.WriteLine($"str : {str}");
                        Console.WriteLine($"compare : {compare}");
                        Console.WriteLine($"(str == compare) : {str.ToLower() == compare.ToLower()}");
            */
            #endregion

            // 3교시

            // 인터페이스
            // = 클래스간의 약속

            Door door = new Door();


            // 인터페이스 변수 입장에서 대입되는 대상이 어떠한 클래스이건 상관없다.
            // 인터페이스를 상속하고만 있으면 적어도 해당 함수가 있다는 사실을 알 수 있다.


            Interact target = door;
            target.OnInteract();
            Destory des = door;


            // 0번째 박스는 Destory를 구현하고 있는가? (is)
            if (door is Destory)
                (door as Destory).OnDestory();
            else
                Console.WriteLine("dd");

            // 배열 (값 형, 참조 형)
            int[] array1 = new int[3];
            // 값형의 배열을 만들었을 때, C#의 기본 값인 0을 받는다.
            // 하지만 참조형 배열은 NULL 값을 가지고 있기 때문에 존재하지 않는 형태이다. (참조하려는 준비만이 된 상태) 

            Door[] doors = new Door[3] { new Door(), new Door(), new Door() };
            // 위와 같은 형태로 따로 자료형에 대한 선언을 해주어 힙 메모리에 실체를 만들어야한다.

            des = doors[0];

            Console.WriteLine(des);

            if (des is Destory)
                Console.WriteLine("gg");

        }
    }

    class Simple
    {
        void start()
        {
            // CircleRound() Simple은 Program.CircleRound에 접근할 수 없다. (서로 다른 클래스이기 때문)
        }
    }

    static class Method
    {
        public static float CirCleRound(this float radius) // float라는 자료형으로 한정하여 radius라는 함수가 추가 된 것
        {
            return 2 * 3.141519f * radius;
        }

        // 배열 형태의 변수에 한해 문자열을 반환하는 함수를 확장하고 싶다.
        // 1. 확장을 위해서는 스태틱 클래스 내부에 있는 스태틱 멤버 함수여야만 한다.
        // 2. 확장하는 함수는 접근을 위해 public으로 설정해주어야한다. (그렇지 않으면 외부에서 확장 메소드를 호출할 수 없다.)
        // 3. static class는 top level, 특정 클래스 내부에 있지 않아야한다.

        public static string ToStringArray(this string[] array)
        {
            /*
            string str = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                // string.Concat (params string[] a) : string
                str = string.Concat(str, ",", array[i]);
                // str의 Empty값과 array[i]를 합친다. 전체 순환으로 합쳐진 문자열을 얻게된다.
            }
            return str;
            */

            // 변수명(매개변수) : 반환되는 자료형 식으로 함수를 정리 표현함
            // Join(string, params string[]) : string
            // 가변길이로 문자열을 받아서 각 문자열 사이를 separator로 구분한다는 뜻.
            return string.Join(",", array);
        }

        public static int SquareInt(this int num)
        {
            return num * num;
        }
        // 참조 형태로 바꾸는 방법
        // 확장 메소드 또한 ref 키워드를 이용해 참조 형식으로 매개변수를 받을 수 있다.
        public static void Double(this ref int num)
        {
            num *= 2;
        }

        // 확장 메소드의 함수 또한 일반 매개변수를 받을 수 있다.
        // 확장 메소드의 매개변수는 [확장하는 대상, 매개변수...] 식으로 추가 된다.
        public static int Remainder(this int num, int divison)
        {

            return num / divison;
        }



    }


}
