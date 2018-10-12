using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class AModel<T> {

	public 	List<T>	modelList { get; private set; }
	
	public AModel() {
		modelList = new List<T> ();
	}

	public abstract void DisplayModel();
		
	public void		AddModel(T model) {
		modelList.Add (model);
	}
	
	public T	RetrieveModelByIndex(int index) {		
		if (modelList.Count > 0 && modelList.Count > index) {
			return modelList[index];
		}
		
		return default(T);
	}

	public void	RemoveModelByIndex(int index) {
		if (modelList.Count > index) {
			modelList.RemoveAt(index);
		}
	}
}
