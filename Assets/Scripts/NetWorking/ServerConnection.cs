﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

public static class ServerConnection
{
    public static People people;
    public static Town town;

    private static string address = "188.68.221.63";
    private static int port = 10000;

    public static async void GetTownRequest()
    {
        TcpClient client = new TcpClient(address, port);
        string json = "{\"token\":\"3\", \"action\":\"get_town\"}";
        byte[] data = Encoding.UTF8.GetBytes(json);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);

        byte[] readingData = new byte[256];
        string responseData = "";
        StringBuilder completeMessage = new StringBuilder();
        int numberOfBytesRead = 0;
        do
        {
            numberOfBytesRead = stream.Read(readingData, 0,readingData.Length);
            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
            responseData = completeMessage.ToString();


        stream.Close();
        client.Close();

        town = JsonUtility.FromJson<Town>(responseData);
    }

    public static async void GetPeopleRequest()
    {
        TcpClient client = new TcpClient(address, port);
        string json = "{\"token\":\"3\", \"action\":\"get_people\"}";
        byte[] data = Encoding.UTF8.GetBytes(json);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);

        byte[] readingData = new byte[256];
        string responseData = "";
        StringBuilder completeMessage = new StringBuilder();
        int numberOfBytesRead = 0;
        do
        {
            numberOfBytesRead = stream.Read(readingData, 0,readingData.Length);
            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
            responseData = completeMessage.ToString();


        stream.Close();
        client.Close();

        people = JsonUtility.FromJson<People>(responseData);
    }

}
