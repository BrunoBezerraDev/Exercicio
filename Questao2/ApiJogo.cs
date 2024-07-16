using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ApiJogo
    {
        private const string BaseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

        //buscar todas as partidas de um time em um ano específico
        public async Task<List<DadosPartida>> ObterPartidasTime1Async(int ano, string time)
        {
            var partidas = new List<DadosPartida>();
            int pagina = 1;

            while (true)
            {
                string url = $"{BaseUrl}?year={ano}&team1={time}&page={pagina}";
                using var cliente = new HttpClient();
                var resposta = await cliente.GetAsync(url);
                resposta.EnsureSuccessStatusCode();
                string corpoResposta = await resposta.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<Root>(corpoResposta);

                var totalPaginas = (int)dados.total_pages;
                foreach (var partida in dados.data)
                {
                    partidas.Add(new DadosPartida
                    {
                        team1 = partida.team1,
                        team2 = partida.team2,
                        team1goals = partida.team1goals,
                        team2goals = partida.team2goals,
                        year = ano
                    });
                }

                if (pagina >= totalPaginas)
                    break;

                pagina++;
            }

            return partidas;
        }

        public async Task<List<DadosPartida>> ObterPartidasTime2Async(int ano, string time)
        {
            var partidas = new List<DadosPartida>();
            int pagina = 1;

            while (true)
            {
                string url = $"{BaseUrl}?year={ano}&team2={time}&page={pagina}";
                using var cliente = new HttpClient();
                var resposta = await cliente.GetAsync(url);
                resposta.EnsureSuccessStatusCode();
                string corpoResposta = await resposta.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<Root>(corpoResposta);

                var totalPaginas = (int)dados.total_pages;
                foreach (var partida in dados.data)
                {
                    partidas.Add(new DadosPartida
                    {
                        team1 = partida.team1,
                        team2 = partida.team2,
                        team1goals = partida.team1goals,
                        team2goals = partida.team2goals,
                        year = ano
                    });
                }

                if (pagina >= totalPaginas)
                    break;

                pagina++;
            }

            return partidas;
        }

        // obter o total de gols marcados por um time em um ano específico
        public async Task<int> ObterTotalGolsAsync(string time, int ano)
        {
            int totalGols = 0;
            var jogos = await ObterPartidasTime1Async(ano, time);
            jogos.AddRange(await ObterPartidasTime2Async(ano, time));

            foreach (var partida in jogos)
            {
                if (partida.team1 == time)
                {
                    totalGols += Convert.ToInt32(partida.team1goals);
                }
                if (partida.team2 == time)
                {
                    totalGols += Convert.ToInt32(partida.team2goals);
                }

            }
            return totalGols;
        }
    }

}
