using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu( fileName = "event_", menuName = "ScriptableObjects/Game Event" ) ]
public class GameEvent : ScriptableObject
{
	readonly List< EventListener > event_listeners = new List< EventListener >();

	public void Raise()
	{
		for( int i = event_listeners.Count - 1; i >= 0; i-- )
			event_listeners[ i ].OnEventRaised();
	}

	public void RegisterListener( EventListener listener )
	{
		if( !event_listeners.Contains( listener ) )
			event_listeners.Add( listener );
	}

	public void UnregisterListener( EventListener listener )
	{
		if( event_listeners.Contains( listener ) )
			event_listeners.Remove( listener );
	}
}