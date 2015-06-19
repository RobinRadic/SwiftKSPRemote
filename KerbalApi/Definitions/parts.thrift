/*
 * parts.thrift :: Contains definitions for parts and modules
 * depends on: base
 */


namespace csharp KerbalApi.Api


struct Module {
    1: string name,
    2: bool enabled,
    11: i64 partId,
    12: string vesselId
}

struct Decoupler {
    1: bool decoupled,
    2: double impulse,
    10: i64 partId
}

enum DockingPortState { Ready, Docked, Docking, Undocking, Shielded, Moving }
struct DockingPort {
    2: DockingPortState state,
    10: i64 partId,
    21: double reEngageDistance,
    22: bool hasShield,
    23: bool shielded
    31: optional i64 dockedPart,
}

struct Engine {
    1: bool active,
    10: i64 partId,
    11: double thrust,
    12: double availableThrust,
    13: double maxThrust,
    14: double maxVacThrust,
    15: double thrustLimit,

    18: double specificImpulse,
    19: double vacuumSpecificImpulse,
    20: double kerbinSeaLevelSpecificImpulse,

    21: list<string> propellants,
    22: map<string, double> propellantRatios,
    23: bool hasFuel,
    24: double throttle,
    25: bool throttleLocked,
    26: bool canRestart,
    27: bool canShutdown,
    28: bool gimballed,
    29: double gimbalRange,
    30: bool gimbalLocked,
    31: double gimbalLimit
}

enum LandingGearStates { DEPLOYING, DEPLOYED, RETRACTING, RETRACTED, UNDEFINED }
struct LandingGear {
    1: LandingGearStates state,
    2: bool deployed,
    10: i64 partId
}

enum LandingLegStates { DEPLOYED, RETRACTED, DEPLOYING, RETRACTING, BROKEN, REPAIRING }
struct LandingLeg {
    1: LandingLegStates state,
    2: bool deployed,
    10: i64 partId
}

struct LaunchClamp {}
struct Light {
    1: bool active,
    2: double powerUsage,
    10: i64 partId
}

enum ParachuteState { ACTIVE, CUT, DEPLOYED, SEMIDEPLOYED, STOWED }
struct Parachute {
    1: ParachuteState state,
    2: bool deployed,
    3: double deployAltitude,
    4: double deployMinPressure,
    10: i64 partId
}

struct ReactionWheel {
    1: bool active,
    2: bool broken,
    3: double pitchTorque,
    4: double yawTorque,
    5: double rollTorque,
    10: i64 partId
}

struct Sensor {
    1: bool active,
    2: string value
    3: double powerUsage,
    10: i64 partId
}

enum SolarPanelState { BROKEN, EXTENDED, EXTENDING, RETRACTED, RETRACTING }
struct SolarPanel {
    1: bool deployed,
    2: SolarPanelState state,
    3: double energyFlow,
    4: double sunExposure,
    10: i64 partId
}

enum PartStates { ACTIVE, DEACTIVATED, DEAD, IDLE }
struct Part {
    1: i64 id,
    2: string name,
    3: string title,
    4: double cost,
    5: PartStates state,

    11: i64 parentId,
    12: list<i64> children,

    21: bool axiallyAttached,
    22: bool radiallyAttached,
    23: i32 stage,
    24: i32 decoupleStage,
    25: bool massless,
    26: double mass,
    27: double dryMass,
    28: double impactTolerance,
    29: double temperature,
    30: double maxTemperature,
    31: bool crossfeed,
    32: list<i64> fuelLinesFrom,
    33: list<i64> fuelLinesTo,
    34: list<Module> modules,

    51: bool isDecoupler,
    52: bool isDockingPort,
    53: bool isEngine,
    54: bool isLandingGear,
    55: bool isLandingLeg,
    56: bool isLaunchClamp,
    57: bool isLight,
    58: bool isParachute,
    59: bool isSensor,
    60: bool isReactionWheel,
    61: bool isSolarPanel,


    81: optional Decoupler decoupler,
    82: optional DockingPort dockingPort,
    83: optional Engine engine,
    84: optional LandingGear landingGear,
    85: optional LandingLeg landingLeg,
    86: optional LaunchClamp launchClamp,
    87: optional Light light,
    88: optional Parachute parachute,
    89: optional Sensor sensor,
    90: optional ReactionWheel reactionWheel,
    91: optional SolarPanel solarPanel
}

struct Parts {
    1: i32 capacity,
    2: i32 count,
    3: Part root,
    11: list<Part> all,

    21: list<Decoupler> decouplers,
    22: list<DockingPort> dockingPorts,
    23: list<Engine> engines,
    24: list<LandingGear> landingGear,
    25: list<LandingLeg> landingLegs,
    26: list<LaunchClamp> launchClamps,
    27: list<Light> lights,
    28: list<Parachute> parachutes,
    29: list<ReactionWheel> reactionWheels,
    30: list<Sensor> sensors,
    31: list<SolarPanel> solarPanels
}
