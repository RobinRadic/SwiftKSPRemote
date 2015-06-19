/*
 * vessel.thrift :: Contains definitions for vessel
 * depends on: base, game, parts
 */

include "game.thrift"
include "parts.thrift"

namespace csharp KerbalApi.Api


enum VesselType {
    Ship,
    Station,
    Lander,
    Probe,
    Rover,
    Base,
    Debris
}

enum VesselSituation {
    DOCKED,
    ESCAPING,
    FLYING,
    LANDED,
    ORBITING,
    PRELAUNCH,
    SPLASHED,
    SUB_ORBITAL
}

struct Vessel {
    1: string id,
    2: string name,
    3: game.Vector3d position,
    4: VesselType type,
    5: VesselSituation situation,
    6: Vessel target,
    7: game.Orbit orbit,


    11: double MET,
    12: double mass,
    13: double dryMass,
    14: double thrust,
    15: double availableThrust,
    16: double maxThrust,
    17: double maxVacThrust,
    18: double specificImpulse,
    19: double vacuumSpecificImpulse,
    20: double kerbinSeaLevelSpecificImpulse


    32: parts.Parts parts
}


struct FlightGlobals {
    1: Vessel activeVessel,
    2: list<Vessel> vessels,
    3: list<game.CelestialBody> bodies,
    4: game.CelestialBody currentMainBody,

    30: optional parts.Part activeTarget
}