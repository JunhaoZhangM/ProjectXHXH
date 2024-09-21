using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using System;
using UnityEngine.Events;

public class SpineEventHelper : MonoBehaviour
{

    [Serializable]
    public class SpineFrameKey
    {
        [SpineEvent] public string key;
        public UnityEvent handler;
    }
    [SerializeField] private List<SpineFrameKey> handlers;
    private Dictionary<string, UnityEvent> keyFrameEventDict = new Dictionary<string, UnityEvent>();
    public const string START_EVENT = "START_EVENT", END_EVENT = "END_EVENT";
    private SkeletonAnimation skeletonAnimation;
    private void Start()
    {
        Bind();
    }
    private void Bind()
    {
        skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        if (skeletonAnimation == null) return;
        skeletonAnimation.AnimationState.Event += HandleEvent;
        skeletonAnimation.AnimationState.Start += delegate (TrackEntry trackEntry)
        {
            if (keyFrameEventDict.TryGetValue(START_EVENT, out UnityEvent @event))
            {
                @event.Invoke();
            }
        };
        skeletonAnimation.AnimationState.End += delegate
        {
            if (keyFrameEventDict.TryGetValue(END_EVENT, out UnityEvent @event))
            {
                @event.Invoke();
            }
        };
        foreach (var handler in handlers)
        {
            keyFrameEventDict[handler.key] = handler.handler;
        }
    }
    /// <summary>
    /// 添加自定义的帧事件
    /// </summary>
    /// <param name="key"> 帧名称 </param>
    /// <param name="handler"> 处理的方法 </param>
    public void AddCustomEventHandler(string key, UnityAction handler)
    {
        if (keyFrameEventDict.TryGetValue(key, out UnityEvent ev))
        {
            ev.AddListener(handler);
        }
        else
        {
            var ue = new UnityEvent();
            ue.AddListener(handler);
            keyFrameEventDict.Add(key, ue);
        }
    }
    /// 移除自定义的帧事件
    /// </summary>
    /// <param name="key"> 指定帧名称 </param>
    /// <param name="handler"> 处理的方法 如果忽略则移除key的所有帧事件 </param>
    public void RemoveCustomEventHandler(string key, UnityAction handler = null)
    {
        if (keyFrameEventDict.TryGetValue(key, out UnityEvent ev))
        {
            if (handler == null)
            {
                ev.RemoveAllListeners();
            }
            else
            {
                ev.RemoveListener(handler);
            }
        }
    }
    /// <summary>
    /// 添加动画开始事件
    /// </summary>
    /// <param name="handler"> 开始处理事件的方法 </param>
    public void AddStartEventHandler(UnityAction handler)
    {
        if (keyFrameEventDict.TryGetValue(START_EVENT, out UnityEvent ev))
        {
            ev.AddListener(handler);
        }
        else
        {
            var ue = new UnityEvent();
            ue.AddListener(handler);
            keyFrameEventDict.Add(START_EVENT, ue);
        }
    }
    /// <summary>
    /// 移除开始帧事件
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveStartEventHandler(UnityAction handler)
    {
        if (keyFrameEventDict.TryGetValue(START_EVENT, out UnityEvent ev))
        {
            ev.RemoveListener(handler);
        }
    }
    /// <summary>
    /// 添加结束帧事件
    /// </summary>
    /// <param name="handler"></param>
    public void AddEndEventHandler(UnityAction handler)
    {
        if (keyFrameEventDict.TryGetValue(END_EVENT, out UnityEvent ev))
        {
            ev.AddListener(handler);
        }
        else
        {
            var ue = new UnityEvent();
            ue.AddListener(handler);
            keyFrameEventDict.Add(END_EVENT, ue);
        }
    }
    /// <summary>
    /// 移除结束帧事件
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveEndEventHandler(UnityAction handler)
    {
        if (keyFrameEventDict.TryGetValue(END_EVENT, out UnityEvent ev))
        {
            ev.RemoveListener(handler);
        }
    }
    private void HandleEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (keyFrameEventDict.TryGetValue(e.Data.Name, out UnityEvent @event))
        {
            @event.Invoke();
        }
    }
    /// <summary>
    /// 清理所有帧事件 
    /// </summary>
    public void Clear()
    {
        keyFrameEventDict.Clear();
    }
    private void OnDestroy()
    {
        Clear();
    }
}
