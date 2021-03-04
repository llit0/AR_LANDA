public static class NetworkEvents
{
    public delegate void ReceiveNetworkData();
    public static event ReceiveNetworkData townDataReceive;
    public static event ReceiveNetworkData peopleDataReceive;

    public static void onTownDataReceive()
    {
        townDataReceive?.Invoke();
    }

    public static void onPeopleDataReceive()
    {
        peopleDataReceive?.Invoke();
    }
}
