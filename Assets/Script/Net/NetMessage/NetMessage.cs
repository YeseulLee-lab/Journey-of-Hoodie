using Unity.Networking.Transport;
using UnityEngine;

public class NetMessage
{
    public OpCode Code { set; get; }

    public virtual void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code);
    }
    public virtual void Deserialize(DataStreamReader reader)
    {

    }
    public virtual void ReceicedOnClient()
    {

    }
    public virtual void ReceicedOnServer(NetworkConnection cnn)
    {
        
    }
}
