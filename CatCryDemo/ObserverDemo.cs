using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace CatCryDemo
{
    public interface IObserver
    {
        void Response();
    }

    public interface ISubject
    {
        void AddObserver(IObserver obj);
    }

    public class Cats : ISubject
    {
        private List<IObserver> objList;

        public Cats()
        {
            objList = new List<IObserver>();
        }
        public void AddObserver(IObserver obj)
        {
            objList.Add(obj);
        }

        public void Cry()
        {
            Console.WriteLine("猫开始叫了。。。" + DateTime.Now);
            foreach (IObserver obj in objList)
            {
                obj.Response();
            }
        }
    }

    public class Mouses : IObserver
    {
        public Mouses(Cats cat)
        {
            cat.AddObserver(this);
        }

        public void Response()
        {
            Console.WriteLine("老鼠开始逃跑了。。。" + DateTime.Now);
        }
    }

    public class Peoples : IObserver
    {
        public Peoples(Cats cat)
        {
            cat.AddObserver(this);
        }

        public void Response()
        {
            Console.WriteLine("人醒了。。。" + DateTime.Now);
        }
    }
}
