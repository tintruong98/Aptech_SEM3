using System.Collections.Generic;
using System.Linq;
using RailwaySystem.Data;
using RailwaySystem.Models;
using RailwaySystem.Repository;

namespace RailwaySystem.Services
{
    public class HomeServices : IHomeServices
    {
        private DatabaseContext context;
        public HomeServices(DatabaseContext _context)
        {
            context = _context;
        }

        //----------------------------------------------------------------------------------------------------------

        public List<LoginDetails> GetLoginDetails()
        {
            var result = from tb
                         in context.LoginDetailsContext
                         select tb;
            return result.ToList();
        }
        //-----
        public LoginDetails GetLoginDetailsOne(int varLocal)
        {
            var pList = (from pr in context.LoginDetailsContext
                         where pr.UserId == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        //-----
        public LoginDetails PostLoginDetails(LoginDetails varTable)
        {
            context.LoginDetailsContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        //-----
        public LoginDetails PutLoginDetails(LoginDetails varTable)
        {
            var pList = (from pr
              in context.LoginDetailsContext
                         where pr.UserId == varTable.UserId
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.Email = varTable.Email;
                pList.Username = varTable.Username;
                pList.Password = varTable.Password;
                pList.Name = varTable.Name;
                pList.DateOfBirth = varTable.DateOfBirth;
                pList.Gender = varTable.Gender;
                pList.PhoneNo = varTable.PhoneNo;
                pList.Role = varTable.Role;
                context.SaveChanges();
                return pList;
            }
            return null;
        }
        //-----
        public bool DeleteLoginDetails(int varLocal)
        {
            var pList = (from pr
              in context.LoginDetailsContext
                         where pr.UserId == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.LoginDetailsContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //-----
        public List<Resetpass> GetResetpass()
        {
            var result = from tb
                         in context.ResetpassContext
                         select tb;
            return result.ToList();
        }
        public Resetpass GetResetpassOne(int varLocal)
        {
            var pList = (from pr
             in context.ResetpassContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public Resetpass PostResetpass(Resetpass varTable)
        {
            context.ResetpassContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public Resetpass PutResetpass(Resetpass varTable)
        {
            var pList = (from pr
             in context.ResetpassContext
                         where pr.Id == varTable.Id
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.m_Email = varTable.m_Email;
                pList.m_Token = varTable.m_Token;
                pList.m_Time = varTable.m_Time;
                pList.m_Numcheck = varTable.m_Numcheck;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteResetpass(int varLocal)
        {
            var pList = (from pr
              in context.ResetpassContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.ResetpassContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //----------------------------------------------------------------------------------------------------------
        public List<TrainDetails> GetTrainDetails()
        {
            var result = from tb
                         in context.TrainDetailsContext
                         select tb;
            return result.ToList();
        }
        public TrainDetails GetTrainDetailsOne(int varLocal)
        {
            var pList = (from pr
             in context.TrainDetailsContext
                         where pr.TrainNo == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public TrainDetails PostTrainDetails(TrainDetails varTable)
        {
            context.TrainDetailsContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public TrainDetails PutTrainDetails(TrainDetails varTable)
        {
            var pList = (from pr
             in context.TrainDetailsContext
                         where pr.TrainNo == varTable.TrainNo
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.TrainName = varTable.TrainName;
                pList.Source = varTable.Source;
                pList.Destination = varTable.Destination;
                pList.Departure = varTable.Departure;
                pList.NoOfCompartment = varTable.NoOfCompartment;
                pList.FirstClass = varTable.FirstClass;
                pList.SecondClass = varTable.SecondClass;
                pList.ThirdClass = varTable.ThirdClass;
                pList.SleepRoom = varTable.SleepRoom;
                pList.General = varTable.General;
                pList.Status = varTable.Status;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteTrainDetails(int varLocal)
        {
            var pList = (from pr
              in context.TrainDetailsContext
                         where pr.TrainNo == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.TrainDetailsContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //----------------------------------------------------------------------------------------------------------

        public List<PriceDetails> GetPriceDetails()
        {
            var result = from tb
                         in context.PriceDetailsContext
                         select tb;
            return result.ToList();
        }
        public PriceDetails GetPriceDetailsOne(string varLocal)
        {
            var pList = (from pr
             in context.PriceDetailsContext
                         where pr.SeatCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public PriceDetails PostPriceDetails(PriceDetails varTable)
        {
            context.PriceDetailsContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public PriceDetails PutPriceDetails(PriceDetails varTable)
        {
            var pList = (from pr
             in context.PriceDetailsContext
                         where pr.SeatCode == varTable.SeatCode
                         select pr).SingleOrDefault();
            if (pList != null)
            {

                pList.ClassName = varTable.ClassName;
                pList.Price = varTable.Price;

                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeletePriceDetails(string varLocal)
        {
            var pList = (from pr
              in context.PriceDetailsContext
                         where pr.SeatCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.PriceDetailsContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //----------------------------------------------------------------------------------------------------------
        public List<PassengerDetails> GetPassengerDetails()
        {
            var result = from tb
                         in context.PassengerDetailsContext
                         select tb;
            return result.ToList();
        }
        public PassengerDetails GetPassengerDetailsOne(int varLocal)
        {
            var pList = (from pr
             in context.PassengerDetailsContext
                         where pr.PNR == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public PassengerDetails PostPassengerDetails(PassengerDetails varTable)
        {
            context.PassengerDetailsContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public PassengerDetails PutPassengerDetails(PassengerDetails varTable)
        {
            var pList = (from pr
             in context.PassengerDetailsContext
                         where pr.PNR == varTable.PNR
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.UserID = varTable.UserID;
                pList.Name = varTable.Name;
                pList.Gender = varTable.Gender;
                pList.PhoneNo = varTable.PhoneNo;
                pList.Email = varTable.Email;
                pList.Source = varTable.Source;
                pList.Destination = varTable.Destination;
                pList.Departure = varTable.Departure;
                pList.TrainNo = varTable.TrainNo;
                pList.Compartment = varTable.Compartment;
                pList.SeatCode = varTable.SeatCode; 
                pList.Price = varTable.Price;
                pList.BookingDate = varTable.BookingDate;

                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeletePassengerDetails(int varLocal)
        {
            var pList = (from pr
              in context.PassengerDetailsContext
                         where pr.PNR == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.PassengerDetailsContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------
        public List<StationDep> GetStationDep()
        {
            var result = from tb
                         in context.StationDepContext
                         select tb;
            return result.ToList();
        }
        public StationDep GetStationDepOne(string varLocal)
        {
            var pList = (from pr
             in context.StationDepContext
                         where pr.StationCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public StationDep PostStationDep(StationDep varTable)
        {
            context.StationDepContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public StationDep PutStationDep(StationDep varTable)
        {
            var pList = (from pr
             in context.StationDepContext
                         where pr.StationCode == varTable.StationCode
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.StationName = varTable.StationName;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteStationDep(string varLocal)
        {
            var pList = (from pr
              in context.StationDepContext
                         where pr.StationCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.StationDepContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------
        public List<StationArr> GetStationArr()
        {
            var result = from tb
                         in context.StationArrContext
                         select tb;
            return result.ToList();
        }
        public StationArr GetStationArrOne(string varLocal)
        {
            var pList = (from pr
             in context.StationArrContext
                         where pr.StationCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public StationArr PostStationArr(StationArr varTable)
        {
            context.StationArrContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public StationArr PutStationArr(StationArr varTable)
        {
            var pList = (from pr
             in context.StationArrContext
                         where pr.StationCode == varTable.StationCode
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.StationName = varTable.StationName;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteStationArr(string varLocal)
        {
            var pList = (from pr
              in context.StationArrContext
                         where pr.StationCode == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.StationArrContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------
        public List<Disprice> GetDisprice()
        {
            var result = from tb
                         in context.DispriceContext
                         select tb;
            return result.ToList();
        }
        public Disprice GetDispriceOne(int varLocal)
        {
            var pList = (from pr
             in context.DispriceContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public Disprice PostDisprice(Disprice varTable)
        {
            context.DispriceContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public Disprice PutDisprice(Disprice varTable)
        {
            var pList = (from pr
             in context.DispriceContext
                         where pr.Id == varTable.Id
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.Source = varTable.Source;
                pList.Destination = varTable.Destination;
                pList.Price = varTable.Price;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteDisprice(int varLocal)
        {
            var pList = (from pr
              in context.DispriceContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.DispriceContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //----------------------------------------------------------------------------------------------------------
        public List<SeatDiagram> GetSeatDiagram()
        {
            var result = from tb
                         in context.SeatDiagramContext
                         select tb;
            return result.ToList();
        }
        public SeatDiagram GetSeatDiagramOne(int varLocal)
        {
            var pList = (from pr
             in context.SeatDiagramContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                return pList;
            }
            return null;
        }
        public SeatDiagram PostSeatDiagram(SeatDiagram varTable)
        {
            context.SeatDiagramContext.Add(varTable);
            context.SaveChanges();
            return varTable;
        }
        public SeatDiagram PutSeatDiagram(SeatDiagram varTable)
        {
            var pList = (from pr
             in context.SeatDiagramContext
                         where pr.Id == varTable.Id
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                pList.TrainNo = varTable.TrainNo;
                pList.Compartment = varTable.Compartment;
                pList.SeatCode = varTable.SeatCode;
                pList.SeatOrder = varTable.SeatOrder;
                pList.Price = varTable.Price;
                pList.UserId = varTable.UserId;
                pList.Status = varTable.Status;
                context.SaveChanges();
                return varTable;
            }
            return null;
        }
        public bool DeleteSeatDiagram(int varLocal)
        {
            var pList = (from pr
              in context.SeatDiagramContext
                         where pr.Id == varLocal
                         select pr).SingleOrDefault();
            if (pList != null)
            {
                context.SeatDiagramContext.Remove(pList);
                context.SaveChanges();
                return true;
            }
            return false;
        }






        //----------------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------------






    }
}
