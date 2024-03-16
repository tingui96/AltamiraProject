﻿using Contracts.Repository;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ImageService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public Task<string> GetImageAsync(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var result = await _repositoryManager.Images.Upload(file);
            return await Task.FromResult(result);
        }
        public void DeleteImageAsync(string path)
        {
            _repositoryManager.Images.Delete(path);
        }   
    }
}