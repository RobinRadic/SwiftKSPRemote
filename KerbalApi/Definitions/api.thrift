include "base.thrift"
include "game.thrift"
include "parts.thrift"
include "vessel.thrift"

namespace csharp KerbalApi.Api

service GameService {

    game.Game getGame(1:string authString) throws (1:base.EAuthException aex),

}

service VesselService {

    vessel.Vessel getActiveVessel(1:string authString) throws (1:base.EAuthException aex),

    vessel.FlightGlobals getFlightGlobals(1:string authString) throws (1:base.EAuthException aex),   

    bool setVesselName(1: string authString, 2: optional string id) throws (1:base.EAuthException aex, 2:base.EDataException dex)
}