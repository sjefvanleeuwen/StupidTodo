﻿using Microsoft.WindowsAzure.Storage.Table;
using StupidTodo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTodo.Data.AzureTableStorage
{
    /// <summary>
    /// Implementation of IEventRecord for use with Azure Storage Table.
    /// </summary>
    public class EventRecordTableEntity : TableEntity, IEventRecord
    {
        public string EventData { get; set; }
        public string EventType { get; set; }
        public string Id { get; set; }
        public string OwnerId { get; set; }
    }
}
