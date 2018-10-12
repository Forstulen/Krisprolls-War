using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FixedQueue<T> : Queue<T> {
	private int limit = -1;
	
	public int Limit { get; set; }
	
	public FixedQueue(int limit) : base(limit) {
		this.Limit = limit;
	}
	
	public new void Enqueue(T item) {
		if (this.Count >= this.Limit) {
			this.Dequeue();
		}
		base.Enqueue(item);
	}

	public T	Peek(int index) {
		if (this.Count <= index) {
			throw new System.IndexOutOfRangeException();
		}
		return this.ElementAt(index);
	}
}