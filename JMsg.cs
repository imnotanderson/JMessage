using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class JMsg  {
	
	static JMsg mMsg = null;
	public static JMsg instance{
		get{ 
			if (mMsg == null) {
				mMsg = new JMsg ();
			}
			return mMsg;
		}
	}

	private JMsg(){}

	public Dictionary<object,List<object>>msgDict = new Dictionary<object, List<object>>();

	public void ListenMsg(object obj,Action action){
		if (msgDict.ContainsKey (obj) == false) {
			msgDict [obj] = new List<object> ();
		}
		msgDict [obj].Add (action);
	}

	public void ListenMsg<T>(object obj,Action<T> action){
		if (msgDict.ContainsKey (obj) == false) {
			msgDict [obj] = new List<object> ();
		}
		msgDict [obj].Add (action);
	}

	public void ListenMsg<T1,T2>(object obj,Action<T1,T2> action){
		if (msgDict.ContainsKey (obj) == false) {
			msgDict [obj] = new List<object> ();
		}
		msgDict [obj].Add (action);
	}

	public void RemoveMsg(object obj,Action action){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		msgDict [obj].Remove (action);
	}

	public void RemoveMsg<T>(object obj,Action<T> action){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		msgDict [obj].Remove (action);
	}

	public void RemoveMsg<T1,T2>(object obj,Action<T1,T2> action){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		msgDict [obj].Remove (action);
	}


	public void SendMsg(object obj){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		foreach (var func in msgDict[obj]) {
			if (func is Action) {
				Action action = (Action)func;
				action ();
			}
		}
	}

	public void SendMsg<T>(object obj,T t){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		foreach (var func in msgDict[obj]) {
			if (func is Action<T>) {
				Action<T> action = (Action<T>)func;
				action (t);
			}
		}
	}

	public void SendMsg<T1,T2>(object obj,T1 t1,T2 t2){
		if (msgDict.ContainsKey (obj) == false) {
			return;
		}
		foreach (var func in msgDict[obj]) {
			if (func is Action<T1,T2>) {
				Action<T1,T2> action = (Action<T1,T2>)func;
				action (t1,t2);
			}
		}
	}
}
