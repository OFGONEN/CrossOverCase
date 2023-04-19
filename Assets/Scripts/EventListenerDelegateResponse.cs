[ System.Serializable ]
public class EventListenerDelegateResponse : EventListener
{
	public GameEvent gameEvent;

	public UnityEngine.Events.UnityAction response;

	public override void OnEnable()
	{
		gameEvent.RegisterListener( this );
	}

	public override void OnDisable()
	{
		gameEvent.UnregisterListener( this );
	}

	public override void OnEventRaised()
	{
		response();
	}
}