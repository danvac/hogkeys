using System;
using System.Globalization;
using System.Reflection;

namespace net.willshouse.HogKeys.IO
{

    public class SimMessageEventArgs : EventArgs
    {
        public SimMessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

   

    public abstract class SimListenerBase<T> where T : class
    {
        protected bool listening;
        public delegate void SimMessageEventHandler(object sender, SimMessageEventArgs e);
        public static event SimMessageEventHandler MessageReceived;

        public int Port { get; set; }
        public string Host { get; set; }
        public  bool Listening
        {
            get { return listening; }
        }

        /// <summary>
        /// A protected constructor which is accessible only to the sub classes.
        /// </summary>
        protected SimListenerBase() { }

        /// <summary>
        /// Gets the singleton instance of this class.
        /// </summary>
        public static T Instance
        {
            get { return SingletonFactory.Instance; }
        }

        public abstract void StartListening();
        

        protected void OnMessage(string currentMessage)
        {
            if (MessageReceived != null)
            {
                MessageReceived(null, new SimMessageEventArgs(currentMessage));
            }
        }

        public abstract void StopListening();
        
             
                
        
        



        /// <summary>
        /// The singleton class factory to create the singleton instance.
        /// </summary>
        class SingletonFactory
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static SingletonFactory() { }

            // Prevent the compiler from generating a default constructor.
            SingletonFactory() { }

            internal static readonly T Instance = GetInstance();

            static T GetInstance()
            {
                var theType = typeof(T);

                T inst;

                try
                {
                    inst = (T)theType
                        .InvokeMember(theType.Name,
                        BindingFlags.CreateInstance | BindingFlags.Instance
                        | BindingFlags.NonPublic,
                        null, null, null,
                        CultureInfo.InvariantCulture);
                }
                catch (MissingMethodException ex)
                {
                    throw new TypeLoadException(string.Format(
                        CultureInfo.CurrentCulture,
                        "The type '{0}' must have a private constructor to " +
                        "be used in the Singleton pattern.", theType.FullName)
                        , ex);
                }

                return inst;
            }
        }
    }
}
