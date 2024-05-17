using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string NewTeam(string name)
        {

            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
            }

            var team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, teams.GetType().Name);

        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != typeof(Goalkeeper).Name &&
                typeName !=typeof(CenterBack).Name && 
                typeName !=typeof(ForwardWing).Name)
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name,
                    players.GetModel(name).GetType().Name);
            }


            switch (typeName)
            {
                case "Goalkeeper":
                    players.AddModel(new Goalkeeper(name));
                    break;
                case "CenterBack":
                    players.AddModel(new CenterBack(name));
                    break;
                case "ForwardWing":
                    players.AddModel(new ForwardWing(name));
                    break;

            }

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, players.GetType().Name);
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, teamName, teams.GetType().Name);
            }
            var player = players.GetModel(playerName);

            if (player.Team is not null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            var team = teams.GetModel(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var firstTeam = teams.GetModel(firstTeamName);
            var secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }

            if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }

            firstTeam.Draw();
            secondTeam.Draw();

            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);

        }

        public string PlayerStatistics(string teamName)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\"***{teamName}***");

            var teamPlayers = teams.GetModel(teamName).Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name);
            foreach (var player in teamPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            var sortedTeams = teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name).ToList();

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
