using Ipfs;
using Ipfs.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class CustomIpfsFileReader
    {
		private readonly IpfsClient ipfs;

		internal CustomIpfsFileReader(IpfsClient ipfs)
		{
			this.ipfs = ipfs;
		}

		public async Task<string> ReadAllTextAsync(string path, CancellationToken cancel = default)
		{
			await using Stream data = await this.ReadFileAsync(path, cancel);
			using StreamReader reader = new StreamReader(data);
			return await reader.ReadToEndAsync();
		}

		public Task<Stream> ReadFileAsync(string path, CancellationToken cancel = default)
		{
			return this.ipfs.PostDownloadAsync("cat", cancel, path);
		}

		public Task<Stream> ReadFileAsync(string path, long offset, long length = 0, CancellationToken cancel = default)
		{
			return this.ipfs.PostDownloadAsync("cat", cancel, path, $"offset={offset}", $"length={length}");
		}

		public Task<IFileSystemNode> ListFileAsync(string path, CancellationToken cancel = default)
		{
			return this.ipfs.FileSystem.ListFileAsync(path, cancel);
		}

		public Task<Stream> GetAsync(string path, bool compress = false, CancellationToken cancel = default)
		{
			return this.ipfs.FileSystem.GetAsync(path, compress, cancel);
		}
	}
}
