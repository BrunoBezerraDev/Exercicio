using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        var totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

  

    // obter o total de gols marcados por um time em um ano
    public static async Task<int> getTotalScoredGoals(string time, int ano)
    {
        var api = new ApiJogo();
        int totalGols = await api.ObterTotalGolsAsync(time, ano);
        return totalGols;
    }

}