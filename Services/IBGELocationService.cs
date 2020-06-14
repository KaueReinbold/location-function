using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LocationFunction.Interfaces;
using LocationFunction.Models;

namespace LocationFunction.Services
{
    public class IBGELocationService
        : IIBGELocationService
    {
        private readonly HttpClient httpClient;

        public IBGELocationService(HttpClient httpClient) =>
            this.httpClient = httpClient;

        public async Task<IEnumerable<IBGEState>> GetStates()
        {
            var response = await this.httpClient.GetAsync("localidades/estados");

            var states = await response.Content.ReadAsAsync<List<IBGEState>>();

            return states;
        }
    }
}