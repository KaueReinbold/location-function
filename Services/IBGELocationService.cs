using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<IEnumerable<IBGECity>> GetCities(string initials)
        {
            var response = await this.httpClient.GetAsync($"localidades/estados/{initials}/municipios");

            if (response.StatusCode == HttpStatusCode.NotFound ||
                response.StatusCode == HttpStatusCode.InternalServerError)
                throw new ArgumentException("Invalid state was informed, please check the Initials field on List of States call.");

            var cities = await response.Content.ReadAsAsync<List<IBGECity>>();

            return cities;
        }
    }
}