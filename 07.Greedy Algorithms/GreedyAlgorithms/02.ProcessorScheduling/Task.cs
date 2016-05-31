namespace _02.ProcessorScheduling
{
    using System;

    public class Task : IComparable<Task>
    {
        public Task(int taskNumber, int taskValue, int taskDeadLine)
        {
            this.TaskNumber = taskNumber;
            this.TaskValue = taskValue;
            this.TaskDeadLine = taskDeadLine;
        }

        public int TaskNumber { get; set; }
        public int TaskValue { get; set; }
        public int TaskDeadLine { get; set; }

        public int CompareTo(Task other)
        {
            return this.TaskValue.CompareTo(other.TaskValue);
        }

        public override string ToString()
        {
            return string.Format("value: {0}; deadline: {1}", this.TaskValue, this.TaskDeadLine);
        }
    }
}
