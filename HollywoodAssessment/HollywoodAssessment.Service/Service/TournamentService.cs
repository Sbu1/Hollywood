using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HollywoodAssessment.Common.Interfaces;
using HollywoodAssessment.Data.Models;

namespace HollywoodAssessment.Service.Service
{
  public class TournamentService : ITournamentService
  {
    public HollywoodAssessmentDbContext db;

    public TournamentService(HollywoodAssessmentDbContext hollywoodAssessmentDb)
    {
      db = hollywoodAssessmentDb;
    }
    public void CreateTournament(Tournament tournament)
    {
      db.Tournament.Add(tournament);
      db.SaveChanges();
    }

    public void UpdateTournament(int id, Tournament tournament)
    {
      var result = GetTournament(id);
      result.TournamentName = tournament.TournamentName;
      db.SaveChanges();
    }

    public void DeleteTournament(int id)
    {
      var result = GetTournament(id);
      db.Remove(result);
    }

    public Tournament GetTournament(int id)
    {
      var result = db.Tournament.FirstOrDefault(x => x.TournamentId == id);
      //Throw exception for null

      return result;
    }
  }
}
