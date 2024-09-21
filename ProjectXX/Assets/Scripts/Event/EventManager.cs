using System;
using System.Collections.Generic;

namespace Event
{
    public enum EventString
    {
        OnActionComplete,
        OnPlayerActionEnd,
        OnPlayerChange,
        OnPreSettleEnd,
        OnRoundEnd,
        ActionTimeUpdate,
        RoundInit,
        OnBattleBegin
    }
    // 定义自定义的事件参数类，避免与系统的 EventArgs 冲突

    public class EventManager : Singleton<EventManager>
    {
        // 使用字典存储事件名称和对应的事件处理程序链
        private Dictionary<EventString, Delegate> eventHandlers = new Dictionary<EventString, Delegate>();

        // 初始化方法
        public void Init()
        {
        }

        // 订阅事件
        public void Subscribe<T>(EventString eventName, Action<object, T> handler)
        {
            if (handler == null)
            {
                throw new Exception("传入的事件处理程序为空，无法注册事件...");
            }

            // 如果事件已经存在，将新的处理程序附加到已有的处理程序链中
            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = Delegate.Combine(eventHandlers[eventName], handler);
            }
            else
            {
                // 否则，添加新的事件处理程序
                eventHandlers.Add(eventName, handler);
            }
            
        }


        // 取消订阅事件
        public void UnSubscribe<T>(EventString eventName, Action<object, T> handler)
        {
            if (eventHandlers.TryGetValue(eventName, out Delegate eventHandler))
            {
                // 从事件处理程序链中移除处理程序
                eventHandler = Delegate.Remove(eventHandler,handler);

                // 如果处理程序链为空，则移除该事件
                if (eventHandler == null)
                {
                    eventHandlers.Remove(eventName);
                }
                else
                {
                    eventHandlers[eventName] = eventHandler;
                }
            }
        }

        // 触发事件
        public void Fire<T>(EventString eventName, object sender , T args)
        {
            if (eventHandlers.TryGetValue(eventName, out Delegate eventHandler))
            {
                if (eventHandler is Action<object, T> action)
                {
                    action.Invoke(sender, args);
                }
            }
        }

        public void Fire<T>(EventString eventName,T args)
        {
            Fire(eventName, null, args);
        }

        public void Fire(EventString eventName)
        {
            Fire<object>(eventName, null, null);
        }
    }
}
