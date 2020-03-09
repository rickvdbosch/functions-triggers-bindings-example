using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ExampleFunctionProject.Models
{
    public class SomeEntity : TableEntity
    {
        #region Fields

        public const string PARTITION_KEY = "<PARTITION-KEY>";

        #endregion

        #region Constructors

        public SomeEntity()
        {
            PartitionKey = PARTITION_KEY;
            RowKey = Guid.NewGuid().ToString();
        }

        #endregion

        public string Name { get; set; }

        public string Description { get; set; }

        public int SomeNumber { get; set; }
    }
}