﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Lpr4dev.Server
{
    public interface ITaskQueue
    {
        Task QueueTask(Action action, bool priority);
        void Start();
    }

    public class TaskQueue : ITaskQueue
    {
        private BlockingCollection<Action> processingQueue = new BlockingCollection<Action>();

        private BlockingCollection<Action> priorityProcessingQueue = new BlockingCollection<Action>();

        public Task QueueTask(Action action, bool priority)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            Action wrapper = () =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());

                    tcs.SetException(e);
                }
            };


            if (priority)
            {
                priorityProcessingQueue.Add(wrapper);
            }
            else
            {
                processingQueue.Add(wrapper);
            }

            return tcs.Task;
        }

        private Task ProcessingTaskWork()
        {
            while (!processingQueue.IsCompleted && !priorityProcessingQueue.IsCompleted)
            {
                Action nextItem;
                try
                {
                    BlockingCollection<Action>.TakeFromAny(new[] {priorityProcessingQueue, processingQueue}, out nextItem);
                }
                catch (InvalidOperationException)
                {
                    if (processingQueue.IsCompleted || priorityProcessingQueue.IsCompleted)
                    {
                        break;
                    }

                    throw;
                }

                nextItem();
            }

            return Task.CompletedTask;
        }

        public void Start()
        {
            Task.Run(ProcessingTaskWork);
        }
    }
}