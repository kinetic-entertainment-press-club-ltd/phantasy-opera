
using System;
using System.Collections;
using System.Collections.Generic;

public class FiniteStack<T> : IEnumerable<T>
{
	private LinkedList<T> m_container;
	private int m_capacity;

	/// <summary>
	/// Called when the stack runs out of space and removes
	/// the first item (bottom of stack) to make room.
	/// </summary>
	public event Action<T> OnRemoveBottomItem;

	public FiniteStack(int capacity)
	{
		m_container = new LinkedList<T>();
		m_capacity = capacity;
	}

	public void Push(T value)
	{
		m_container.AddLast(value);

		// Out of room, remove the first element in the stack.
		if (m_container.Count == m_capacity) {

			T first = m_container.First.Value;
			m_container.RemoveFirst();

			if (OnRemoveBottomItem != null)
				OnRemoveBottomItem(first);
		}
	}

	public T Peek()
	{
		return m_container.Last.Value;
	}

	public T Pop()
	{
		var lastVal = m_container.Last.Value;
		m_container.RemoveLast();

		return lastVal;
	}

	public void Clear()
	{
		m_container.Clear();
	}

	public int Count
	{
		get { return m_container.Count; }
	}

	public IEnumerator<T> GetEnumerator()
	{
		return m_container.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_container.GetEnumerator();
	}
}