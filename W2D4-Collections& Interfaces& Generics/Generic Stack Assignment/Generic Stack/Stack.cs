using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Stack
{
    class Stacks<T>
    {
		private T[] data;
		private int top;
		private int size;

		public Stacks(int size)
		{
			this.size = size;
			data = new T[size];
			top = -1;
		}

		public bool IsFull() => top == size - 1;
		public bool IsEmpty() => top == -1;

		public void Push(T value)
		{
			if (IsFull())
			{
				Console.WriteLine("Stack is full.");
				return;
			}
			data[++top] = value;
			Console.WriteLine($"Pushed: {value}");
		}

		public void Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty.");
				return;
			}
			Console.WriteLine($"Popped: {data[top--]}");
		}

		public void Display()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty.");
				return;
			}
			Console.WriteLine("Stack :");
			for (int i = top; i >= 0; i--)
				Console.WriteLine(data[i]);
		}
	}
}
