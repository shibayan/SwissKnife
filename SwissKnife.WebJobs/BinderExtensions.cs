using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;

namespace SwissKnife.WebJobs
{
    public static class BinderExtensions
    {
        public static T BindBlob<T>(this IBinder binder, string blobPath, FileAccess access)
        {
            var attribute = new BlobAttribute(blobPath, access);

            return binder.Bind<T>(attribute);
        }

        public static Task<T> BindBlobAsync<T>(this IBinder binder, string blobPath, FileAccess access)
        {
            var attribute = new BlobAttribute(blobPath, access);

            return binder.BindAsync<T>(attribute);
        }

        public static T BindQueue<T>(this IBinder binder, string queueName)
        {
            var attribute = new QueueAttribute(queueName);

            return binder.Bind<T>(attribute);
        }

        public static Task<T> BindQueueAsync<T>(this IBinder binder, string queueName)
        {
            var attribute = new QueueAttribute(queueName);

            return binder.BindAsync<T>(attribute);
        }

        public static T BindTable<T>(this IBinder binder, string tableName)
        {
            var attribute = new TableAttribute(tableName);

            return binder.Bind<T>(attribute);
        }

        public static T BindTable<T>(this IBinder binder, string tableName, string partitionKey, string rowKey)
        {
            var attribute = new TableAttribute(tableName, partitionKey, rowKey);

            return binder.Bind<T>(attribute);
        }

        public static Task<T> BindTableAsync<T>(this IBinder binder, string tableName, string partitionKey, string rowKey)
        {
            var attribute = new TableAttribute(tableName, partitionKey, rowKey);

            return binder.BindAsync<T>(attribute);
        }
    }
}
