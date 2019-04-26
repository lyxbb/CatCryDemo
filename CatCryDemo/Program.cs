using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CatCryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //try the five second method with a 6 second timeout
            Console.WriteLine("开始执行方法");
            bool ss = CallWithTimeout(FiveSecondMethod, 5000, 3000);
            Console.WriteLine($"方法执行完成:{ss}");
            //try the five second method with a 4 second timeout
            //this will throw a timeout exception
            //CallWithTimeout(FiveSecondMethod, 4000);
            return;

            MethodInvoker method = () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(20);
                    Console.WriteLine($"当前读到{i},时间是：" + DateTime.Now);
                }
            };
            method.BeginInvoke(null, null);

            Thread.Sleep(1000);
            Console.WriteLine($"1.1开始执行验证：{DateTime.Now}");

            Cats c = new Cats();
            Mouses m = new Mouses(c);
            Peoples p = new Peoples(c);
            c.Cry();
            Console.ReadLine();
            //return;

            People.Name = "张三";
            People.Name = "李四";
            Cat cat = new Cat();
            Mouse mouse = new Mouse(cat);
            People people = new People(cat);

            cat.StartCry();
            Console.ReadLine();
        }

        #region 多线程检测方法执行是否超时
        static bool FiveSecondMethod(int time = 5000)
        {
            Thread.Sleep(time);
            return false;
        }
        /// <summary>
        /// 检测方法是否执行超时
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="timeoutMilliseconds">The timeout milliseconds.</param>
        static bool CallWithTimeout(Func<int, bool> action, int arg, int timeoutMilliseconds)
        {
            Thread threadToKill = null;
            Func<bool> wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                return action(arg);
            };

            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
                Console.WriteLine($"线程执行了:{timeoutMilliseconds}");
            }
            else
            {
                threadToKill.Abort();
                Console.WriteLine("方法执行超时");
                return false;
            }
            return true;
        }
        #endregion
    }
}
