///
/// FILE : Server
/// PROJECT : PROG2110 - Assignment #1
/// PROGRAMMER : Attila Katona & Trevor Allain
/// FIRST VERSION : 2018-09-22
/// DESCRIPTION : This is the server application which accetps incoming tcpip connections
///               and connects to that client while also threading after a connection is made.
///               The server also parses client information depending on the message source (via flag)
///               and stores it into a local database and then into a text file.
///



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

/// <summary>
/// Server Name Space
/// Holds the methods to run the Server
/// </summary>
namespace Server
{
    /// <summary>
    /// Database Class
    /// Holds the methods to run the Server
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// The member ID for the client as an int
        /// </summary>
        public int MemberID { get; set; }
        /// <summary>
        /// The First Name for the client as a string
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The Last Name for the client as a string
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The Date of Birth for the client as a string
        /// </summary>
        public string DateOfBirth { get; set; }
        /// The edit flag for the client as an int
        /// </summary>
        public int isEdit { get; set; }
    }




    /// <summary>
    /// This is the Server class which contains all the methods and memebrs required
    /// for using the server
    /// </summary>
    class Server
    {
        /// <summary>
        /// Keeps the mutex variable
        /// </summary>
        static private Mutex m;

        /// <summary>
        /// Keeps the ip address variable
        /// </summary>
        static private IPAddress addr;
        /// <summary>
        /// Keeps the ID number variable
        /// </summary>
        static private int idNumber;
        /// <summary>
        /// Keeps the file location variable
        /// </summary>
        static private string clientFile = "clientInfo.txt";


        static void Main(string[] args)
        {

            //the creation of a client list 
            List<DataBase> clientInfoListDB = new List<DataBase>();

            //intantiate new client databse
            DataBase newClientDB = new DataBase();

            //create new mutex for ciritcal region access (file write and database read)
            m = new Mutex();

            //hostname
            String strHostName = string.Empty;

            //hardcoded port
            int port = 5001;

            //get hostname of computer
            strHostName = Dns.GetHostName();
            Console.WriteLine("Host Name: {0}", strHostName);

            //get IPV4 addresses via loop 
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            //loop through each IP and get the first one
            foreach (IPAddress ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    addr = ip;
                    Console.WriteLine("IP Address: {0} ", addr.ToString());
                    break;

                }
            }

            //create listener server
            TcpListener server = new TcpListener(addr, port); //ipv4 
            TcpClient client = default(TcpClient);

            //convert IP address to string (for ease)
            Console.WriteLine("Port: {0} ", port.ToString());

            //load all file info into list
            if (File.Exists(clientFile))
            {
                using (System.IO.StreamReader inputStream = new System.IO.StreamReader(clientFile))
                {
                    while (!inputStream.EndOfStream)
                    {
                        string stringToSplit = inputStream.ReadLine();
                        string[] arrayOfSplits = stringToSplit.Split(new char[] { '*' });
                        clientInfoListDB.Add(new DataBase { MemberID = Convert.ToInt32(arrayOfSplits[0]), FirstName = arrayOfSplits[1], LastName = arrayOfSplits[2], DateOfBirth = arrayOfSplits[3], isEdit = 0 });
                        idNumber = clientInfoListDB.Count;
                    }
                }
            }

            //error checking for server start failure
            try
            {
                server.Start();
                Console.WriteLine("Server has started...");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }

            //while loop to always listen for incoming client data
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient(); //accept connection from client
                    client.NoDelay = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR " + e.ToString());
                }

                handleClient Newclient = new handleClient();
                Newclient.startClient(client, clientInfoListDB, m);
            }

        }

    }

    /// <summary>
    /// Class that creates threads for new connections and their assigned
    /// </summary>
    public class handleClient
    {
        /// <summary>
        /// TCPIP class for the client
        /// </summary>
        TcpClient clientSocket;
        string stringSendMessage = "";
        string stringRecvMessage = "";

        /// <summary>
        /// database for all client information
        /// </summary>
        List<DataBase> clientInfoListDB;

        int idNumber;
        Mutex m;
        string clientFile = "clientInfo.txt";
        /// <summary>
        /// Validates the users input for IP address and Port. Sends 40000 messages of user data to server
        /// </summary>
        /// <param name="inClientSocket">The current client connected</param>
        /// <param name="TEMPclientInfoListDB">The temporary list to hold the client info</param>
        /// <param name="m2">The mutex to prevent access to critical regions of the databse and text file backup</param>
        public void startClient(TcpClient inClientSocket, List<DataBase> TEMPclientInfoListDB, Mutex m2)
        {
            this.clientSocket = inClientSocket;
            this.clientInfoListDB = TEMPclientInfoListDB;

            Thread ctThread = new Thread(ServerRun);
            ctThread.Start();
            this.m = m2;
        }

        /// <summary>
        /// The main part of the server code that threads clients and parses all
        /// incoming data from external IP addresses
        /// </summary>
        public void ServerRun()
        {

            //get incoming data from client
            NetworkStream streamToClient = clientSocket.GetStream(); //get stream from client
            byte[] messageBuffer = new byte[100]; //change max size later (message receive

            while (streamToClient.CanRead)
            {
                //read message
                int bytesRead = streamToClient.Read(messageBuffer, 0, messageBuffer.Length);

                //only process messages greater than 0
                if (bytesRead > 0)
                {

                    byte[] messageSendBuffer = new byte[100];
                    stringRecvMessage = Encoding.ASCII.GetString(messageBuffer, 0, bytesRead);
                    //parse incoming message and flag
                    string messageRecvSplit = stringRecvMessage;
                    string[] arrayOfSplits = messageRecvSplit.Split(new char[] { '*' });
                    string messageFlag = (arrayOfSplits[0]);
                    stringRecvMessage = arrayOfSplits[1];

                    //Searching for user ID
                    if (messageFlag == "1")
                    {
                        DataBase clientID = clientInfoListDB.Find(idSearch => idSearch.MemberID == Convert.ToInt32(stringRecvMessage));

                        if (clientID != null)
                        {
                            stringSendMessage = "ID: " + clientID.MemberID + " found!\n"
                                  + "First: " + clientID.FirstName + "\n"
                                  + "Last: " + clientID.LastName + "\n"
                                  + "DOB: " + clientID.DateOfBirth;
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);

                        }
                        else
                        {
                            stringSendMessage = "Sorry, the ID: " + stringRecvMessage + " was not found!";
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);

                        }
                    }
                    //bulk data dump flag (insert)
                    else if (messageFlag == "B")
                    {

                        m.WaitOne();

                        idNumber = clientInfoListDB.Count();

                        //Console.WriteLine(clientInfoListDB.Count());
                        clientInfoListDB.Add(new DataBase { MemberID = idNumber, FirstName = arrayOfSplits[1], LastName = arrayOfSplits[2], DateOfBirth = arrayOfSplits[3], isEdit = 0 });

                        if (idNumber >= 40000)
                        {
                            using (StreamWriter clientWrite = File.AppendText(clientFile))
                            {

                                stringSendMessage = "FF";
                                messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                                streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);
                                foreach (DataBase item in clientInfoListDB)
                                {
                                    clientWrite.WriteLine(item.MemberID + "*" + item.FirstName + "*" + item.LastName + "*" + item.DateOfBirth);
                                }
                                //streamToClient.Close();                       


                                clientWrite.Close();
                            }



                        }
                        else
                        {
                            stringSendMessage = "S";
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);
                        }


                        m.ReleaseMutex();

                    }
                    //update flag
                    else if (messageFlag == "U")
                    {

                        var index = clientInfoListDB.FindIndex(searchID => searchID.MemberID == Convert.ToInt32(arrayOfSplits[1]));

                        try
                        {

                            if (clientInfoListDB[index].isEdit == 1)
                            {
                                throw new InvalidOperationException("Sorry! Access Denied! - Currently accessed by another client!");
                            }

                            //set edit flag to one (is being edited)
                            clientInfoListDB[index].isEdit = 1;

                            //add new updated info into the list
                            clientInfoListDB[index] = new DataBase { MemberID = Convert.ToInt32(arrayOfSplits[1]), FirstName = arrayOfSplits[2], LastName = arrayOfSplits[3], DateOfBirth = arrayOfSplits[4] };

                            //mutex around critical region for delete and repopulate
                            m.WaitOne();

                            //delete file
                            File.Delete(clientFile);

                            //write contents of database to file
                            using (StreamWriter clientWrite = File.AppendText(clientFile))
                            {
                                //repopulate database file
                                foreach (var item in clientInfoListDB)
                                {
                                    clientWrite.WriteLine(item.MemberID + "*" + item.FirstName + "*" + item.LastName + "*" + item.DateOfBirth);

                                }

                            }

                            //release mutex around critical region 
                            m.ReleaseMutex();

                            //set edit flag back to zero after data is successfully written
                            clientInfoListDB[index].isEdit = 0;

                            //sending message success to server console and client
                            Console.WriteLine("Update Successful!");
                            stringSendMessage = "Updated Complete!\n" +
                                "First Name: " + clientInfoListDB[index].FirstName +
                                "\nLast Name: " + clientInfoListDB[index].LastName +
                                "\nDOB: " + clientInfoListDB[index].DateOfBirth;
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);
                        }
                        catch (InvalidOperationException inval)
                        {
                            //error sent to server console and client
                            Console.WriteLine("Server Error: " + inval.ToString());
                            stringSendMessage = inval.ToString();
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);

                        }
                        catch (Exception e)
                        {

                            //error sent to server console and client
                            Console.WriteLine("Server Error: " + e.ToString());
                            stringSendMessage = "Update in progress, please try again later...";
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);

                        }

                    }

                    //delete client info
                    else if (messageFlag == "D")
                    {
                        try
                        {
                            var index = clientInfoListDB.FindIndex(searchID => searchID.MemberID == Convert.ToInt32(arrayOfSplits[1]));
                            if (index <= 0)
                            {
                                throw new Exception("Entry was not found! This is most likely because it has already been removed!");
                            }

                            //remove client info
                            clientInfoListDB.RemoveAt(index);

                            //wait fo mutex
                            m.WaitOne();

                            //delete file
                            File.Delete(clientFile);

                            using (StreamWriter clientWrite = File.AppendText(clientFile))
                            {
                                //repopulate database file
                                foreach (var item in clientInfoListDB)
                                {
                                    clientWrite.WriteLine(item.MemberID + "*" + item.FirstName + "*" + item.LastName + "*" + item.DateOfBirth);
                                }

                            }

                            //release mutex after leaving critical region
                            m.ReleaseMutex();

                            //sending message success to server console and client
                            Console.WriteLine("Delete Successful!");
                            stringSendMessage = "Delete Complete!\n";
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);

                        }
                        catch (Exception e)
                        {
                            //error sent to server console and client
                            Console.WriteLine("Server Error: " + e.ToString());
                            stringSendMessage = "Server Error: Could not delete client!\n --> " + e.ToString();
                            messageSendBuffer = Encoding.ASCII.GetBytes(stringSendMessage);
                            streamToClient.Write(messageSendBuffer, 0, messageSendBuffer.Length);
                        }

                    }

                }

            }

        }

    }
}
