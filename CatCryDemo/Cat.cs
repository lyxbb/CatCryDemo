using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace CatCryDemo
{
    /// <summary>
    /// Cat类
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// 定义委托
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void Crying(object sender, EventArgs eventArgs);

        /// <summary>
        /// 定义猫叫事件
        /// </summary>
        public event Crying Cry;

        /// <summary>
        /// 猫叫方法
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnCry(EventArgs e)
        {
            Cry?.Invoke(this, e);
        }

        /// <summary>
        /// 猫开始叫
        /// </summary>
        public void StartCry()
        {
            Console.WriteLine("猫开始叫了");
            OnCry(new EventArgs());
        }
    }

    /// <summary>
    /// 老鼠类
    /// </summary>
    public class Mouse
    {
        public delegate void Runing(object sender, EventArgs enArgs);

        /// <summary>
        /// 定义事件
        /// </summary>
        public event Runing Run;

        /// <summary>
        /// 老鼠跑方法
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void OnRun(EventArgs e)
        {
            Run?.Invoke(this, e);
        }

        /// <summary>
        /// 注册.
        /// </summary>
        /// <param name="c">The c.</param>
        public Mouse(Cat c)
        {
            c.Cry += new Cat.Crying(C_Cry); //注册了猫叫事件，老鼠听到猫叫则逃跑
        }

        /// <summary>
        /// 老鼠跑
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void C_Cry(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("老鼠吓跑了");
        }
    }

    /// <summary>
    /// 人类
    /// </summary>
    public class People
    {
        private static string _name;

        public static string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public People(Cat c)
        {
            c.Cry += new Cat.Crying(c_Cry);//注册了猫叫事件，人听到猫叫则惊醒
        }

        public void c_Cry(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("主人被惊醒了");
        }
    }

}
