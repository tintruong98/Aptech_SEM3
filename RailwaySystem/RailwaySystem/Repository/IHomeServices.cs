using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaySystem.Models;

namespace RailwaySystem.Repository
{
    public interface IHomeServices
    {
        //-----
        List<LoginDetails> GetLoginDetails();
        LoginDetails GetLoginDetailsOne(int varLocal);
        LoginDetails PostLoginDetails(LoginDetails varTable);
        LoginDetails PutLoginDetails(LoginDetails varTable);
        bool DeleteLoginDetails(int varLocal);

        //-----
        List<Resetpass> GetResetpass();
        Resetpass GetResetpassOne(int varLocal);
        Resetpass PostResetpass(Resetpass varTable);
        Resetpass PutResetpass(Resetpass varTable);
        bool DeleteResetpass(int varLocal);


        //-----
        List<TrainDetails> GetTrainDetails();
        TrainDetails GetTrainDetailsOne(int varLocal);
        TrainDetails PostTrainDetails(TrainDetails varTable);
        TrainDetails PutTrainDetails(TrainDetails varTable);
        bool DeleteTrainDetails(int varLocal);


        //-----

        List<PriceDetails> GetPriceDetails();
        PriceDetails GetPriceDetailsOne(string varLocal);
        PriceDetails PostPriceDetails(PriceDetails varTable);
        PriceDetails PutPriceDetails(PriceDetails varTable);
        bool DeletePriceDetails(string varLocal);

        //-----
        List<PassengerDetails> GetPassengerDetails();
        PassengerDetails GetPassengerDetailsOne(int varLocal);
        PassengerDetails PostPassengerDetails(PassengerDetails varTable);
        PassengerDetails PutPassengerDetails(PassengerDetails varTable);
        bool DeletePassengerDetails(int varLocal);


        //-----
        List<StationDep> GetStationDep();
        StationDep GetStationDepOne(string varLocal);
        StationDep PostStationDep(StationDep varTable);
        StationDep PutStationDep(StationDep varTable);
        bool DeleteStationDep(string varLocal);

        //-----
        List<StationArr> GetStationArr();
        StationArr GetStationArrOne(string varLocal);
        StationArr PostStationArr(StationArr varTable);
        StationArr PutStationArr(StationArr varTable);
        bool DeleteStationArr(string varLocal);

        //-----
        List<Disprice> GetDisprice();
        Disprice GetDispriceOne(int varLocal);
        Disprice PostDisprice(Disprice varTable);
        Disprice PutDisprice(Disprice varTable);
        bool DeleteDisprice(int varLocal);

        //-----
        List<SeatDiagram> GetSeatDiagram();
        SeatDiagram GetSeatDiagramOne(int varLocal);
        SeatDiagram PostSeatDiagram(SeatDiagram varTable);
        SeatDiagram PutSeatDiagram(SeatDiagram varTable);
        bool DeleteSeatDiagram(int varLocal);




        //-----

    }
}
