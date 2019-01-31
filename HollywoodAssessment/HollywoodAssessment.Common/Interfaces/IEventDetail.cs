using System;
using System.Collections.Generic;
using System.Text;
using HollywoodAssessment.Data.Models;

namespace HollywoodAssessment.Common.Interfaces
{
  public interface IEventDetail
  {
    void CreateEventDetails(EventDetail eventDetail);
    void UpdateEventDetails(int id, EventDetail eventDetail);
    void RemoveEventDetails(int id);

    EventDetail GetEventDetail(int id);
  }
}
