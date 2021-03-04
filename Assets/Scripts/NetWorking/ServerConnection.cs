using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public static class ServerConnection
{
    public static People people;
    public static Town town;

    private const string Address = "188.68.221.63";
    private const int Port = 10000;

    public static async void GetTownData()
    {
        await Task.Run(sendTownRequest);
    }

    public static async void GetPeopleData()
    {
        await Task.Run(sendPeopleRequest); 
    }

    private static void sendTownRequest()
    {
        TcpClient client = new TcpClient(Address, Port);
        const string json = "{\"token\":\"3\", \"action\":\"get_town\"}";
        byte[] data = Encoding.UTF8.GetBytes(json);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);

        byte[] readingData = new byte[256];
        string responseData = "";
        StringBuilder completeMessage = new StringBuilder();
        do
        {
            int numberOfBytesRead = stream.Read(readingData, 0,readingData.Length);
            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
            responseData = completeMessage.ToString();


        stream.Close();
        client.Close();

        town = JsonUtility.FromJson<Town>(responseData);
    }

    private static void sendPeopleRequest()
    {
        TcpClient client = new TcpClient(Address, Port);
        const string json = "{\"token\":\"3\", \"action\":\"get_people\"}";
        byte[] data = Encoding.UTF8.GetBytes(json);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);

        byte[] readingData = new byte[256];
        string responseData = "";
        StringBuilder completeMessage = new StringBuilder();
        do
        {
            int numberOfBytesRead = stream.Read(readingData, 0,readingData.Length);
            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
            responseData = completeMessage.ToString();


        stream.Close();
        client.Close();

        people = JsonUtility.FromJson<People>(responseData);
    }

}
