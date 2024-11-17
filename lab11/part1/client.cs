using System.Net.Sockets;
using System.Text;


using var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await tcpClient.ConnectAsync("127.0.0.1", 8888);


    var message = "AACI\n";
    // ����������� ������ � ������ ����
    byte[] requestData = Encoding.UTF8.GetBytes(message);
    // ���������� ������
    await tcpClient.SendAsync(requestData);
    Console.WriteLine("��������� ����������");


    // ����� ��� ���������� ������
    byte[] data = new byte[512];


    int bytes = await tcpClient.ReceiveAsync(data);

    string time = Encoding.UTF8.GetString(data, 0, bytes);
    Console.WriteLine($"����: {time}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}