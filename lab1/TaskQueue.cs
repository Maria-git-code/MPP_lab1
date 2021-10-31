using System.Collections.Generic;
using System.Threading;

namespace lab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();

        private readonly Queue<TaskDelegate> _tasksQueue = new();

        public TaskQueue(int threadsCount)
        {
            var threads = new Thread[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                var thread = new Thread(Process) {Name = $"{i + 1}"};
                thread.Start();
                threads[i] = thread;
            }
        }

        private void Process()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                TaskDelegate task = null;
                lock (_tasksQueue)
                {
                    if (_tasksQueue.Count > 0)
                    {
                        task = _tasksQueue.Dequeue();
                    }
                }
                task?.Invoke();
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            lock (_tasksQueue)
            {
                _tasksQueue.Enqueue(task);
            }
        }
    }
}