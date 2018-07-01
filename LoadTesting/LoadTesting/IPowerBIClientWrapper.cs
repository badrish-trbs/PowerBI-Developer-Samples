﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LoadTesting
{
    public interface IPowerBIClientWrapper : IDisposable
    {
        Task<string> EnsureGroupSpace(TestSettings testSettings);

        Task<string> Import(string groupId, MemoryStream memoryStream, string datasetName);
        Task<ImportResult> GetImportById(string groupId, string importId);

        Task SetConnections(string groupSpace, string datasetKey, string connectionString);

        Task<IEnumerable<DataSource>> GetDatasources(string groupId, string datasetId);
        Task UpdateDatasource(string groupId, string gatewayId, string bindingId, string sqlUsername, string sqlPassword);

        Task<string> GenerateToken(string groupId, string reportKey);
    }

    public class ImportResult
    {
        public string Id { get; set; }
        public string ImportState { get; set; }
        public IEnumerable<ImportDataset> Datasets { get; set; }
        public IEnumerable<ImportReport> Reports { get; set; }
    }

    public class ImportDataset
    {
        public string Id { get; set; }
    }

    public class ImportReport
    {
        public string Id { get; set; }
        public string DataSetId { get; set; }
        public string EmbedUrl { get; set; }
    }

    public class DataSource
    {
        public string GatewayId { get; set; }
        public string Id { get; set; }
    }
}