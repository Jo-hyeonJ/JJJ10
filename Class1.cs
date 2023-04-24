using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJJ10
{
    // 서로 다른 객체에게 비슷한 행위를 하는 함수를 여러개 추가하는 상황
    // 어떤 객체에게 초점을 맞췄는지, 그 객체가 가진 함수는 무엇인지를 알수가 없다.
    
    // 상속 : 물려받는 것, 확장의 의미


    // 인터페이스를 상속한 클래스는 내부 멤버를 '무조건' 구현해야한다. 같은 이름의 함수나 변수

    // 같은 이름의 변수의 트리거를 하나로 묶어 호출을 용이하게 하는 역할
    // 인터페이스는 다중상속이 가능하다.

    public interface Interact
    {
        void OnInteract();
    }
    public interface Destory
    {
        void OnDestory();
    }


    class Door : Interact, Destory
    {
        bool isOpen;
        public void OnInteract()
        {
            if (isOpen)
            Console.WriteLine("문이 열렸다.");
            else
            Console.WriteLine("문이 닫혔다.");
        
        }

        public void OnDestory()
        {
            Console.WriteLine("문이 부서짐");
        }

    }

    class Box : Interact, Destory
    {
        public void OnInteract()
        {
            int itemCount = 2;
            if (itemCount != 0)
            {
                itemCount--;
                Console.WriteLine("상자를 뒤져 아이템을 발견했다.");
            }
            else
                Console.WriteLine("상자에 아이템이 없다.");
        }

        public void OnDestory()
        {
            Console.WriteLine("상자가 부서짐");
        }

    }

    class NPC : Interact
    {
        int index = 0;
        public void OnInteract()
        {
            switch(index%2)
            {
                case 0:
                    Console.WriteLine("ㅎㅇ");
                    break;
                case 1:
                    Console.WriteLine("ㄴㄴ");
                    break;
            }
            index += 1;
        }


    }


}
