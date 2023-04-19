[ System.Serializable ]
public abstract class EventListener
{
    public abstract void OnEnable();
    public abstract void OnDisable();
    public abstract void OnEventRaised();
}