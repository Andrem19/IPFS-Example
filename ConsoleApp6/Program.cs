using Ipfs.Http;
using Ipfs.CoreApi;
using System.Text;
using ConsoleApp6;

namespace MainT
{
    public class Program
    {
        public static async Task Main()
        {
            string path = @"C:\Users\72555\Desktop\index.html";
            string body = @"<h1>Hello World</h1>";
            using (FileStream file = new FileStream(path, FileMode.Append))
            using (StreamWriter stream = new StreamWriter(file))
                stream.WriteLine(body);
            var ipfs = new IpfsClient();
            var cid = await ipfs.FileSystem.AddFileAsync(@"C:\Users\72555\Desktop\index.html"); /*AddTextAsync("I'm so cool");*/
            Console.WriteLine((string)cid.Id);
            //var test = await ipfs.FileSystem.AddDirectoryAsync(@"C:\Users\72555\Desktop\Projects\C#\ConsoleApp6\ConsoleApp6\bin\Debug\net6.0");
            //CustomIpfsFileReader worker = new CustomIpfsFileReader(ipfs);
            //var res = await worker.ListFileAsync("QmYxtgURbxYd9TuNuMNz5iPRaKvxQZiKEd3sLcGcgHi8Zy");
            //var res = await worker.ReadAllTextAsync((string)cid.Id);
            ////string text = StreamToString(res);
            //Console.WriteLine(res);
        }
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        public static string StreamToString(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}