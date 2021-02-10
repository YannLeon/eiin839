using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }

            // Create a listener.
            HttpListener listener = new HttpListener();

            // Trap Ctrl-C and exit 
            Console.CancelKeyPress += delegate
            {
                listener.Stop();
                System.Environment.Exit(0);
            };

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine($"Received request for {request.Url}");
                Console.WriteLine(documentContents);
                //Console.WriteLine(request.Headers);
                Header h = new Header(request.Headers);
                //Console.WriteLine(request.Headers.AllKeys);
                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                //Print a specific header
                h.printHeader(HttpRequestHeader.Accept);
                h.printHeader(HttpRequestHeader.Connection);

                //Print all headers
                //h.printAllHeaders();
                

                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ...
            // listener.Stop();
        }
    }
    public class Header{
        System.Collections.Specialized.NameValueCollection headersCollection;
        public Header(System.Collections.Specialized.NameValueCollection headersCollection) {
            this.headersCollection = headersCollection;
         }

        public void printHeader(HttpRequestHeader req)
        {
            Console.WriteLine(req.ToString() + " :");
            String s = headersCollection.Get(req.ToString());
            if (s.Length == 0)
            {
                s = "No data";
            }
            Console.WriteLine(s);
        }

        public void printAllHeaders()
        {
            Console.WriteLine(headersCollection);
        }
    }
}