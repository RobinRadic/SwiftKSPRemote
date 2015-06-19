namespace csharp KerbalApi.Api

enum ErrorCode
{
    /** If a parameter was invalid */
    INVALID_REQUEST = 0,
    /** Authentication failed */
    INVALID_AUTHSTRING = 1,
    /** Requested data could not be found */
    NOT_FOUND = 2,
    /** Something went wrong during a download operation */
    DOWNLOAD_ERROR = 3,
    /** Something went wrong during a file operation */
    FILE_ERROR = 4,
    /** Could not read a file */
    NO_READ = 5,
}

/** This exception is thrown when something data-related went wrong */
exception EDataException {
    /** Detailed reason for the exception */
	1: ErrorCode code,
    /** A message that describes the exception */
	2: string errorMessage,
}

/** Thrown when authentication fails, this is thrown */
exception EAuthException {
    /** Detailed reason for the exception */
	1: ErrorCode code,
    /** A message that describes the exception */
	2: string errorMessage,
}


enum GameScenes {
    CREDITS,
    EDITOR,
    FLIGHT,
    LOADING,
    LOADINGBUFFER,
    MAINMENU,
    PSYSTEM,
    SETTINGS,
    SPACECENTER,
    TRACKSTATION
}

enum GameStatus {
    COMPLETED,
    FAILED_OR_ABORTED,
    ONGOING,
    UNSTARTED
}

enum GameModes {
    CAREER,
    SANDBOX,
    SCENARIO,
    SCENARIO_NON_RESUMABLE,
    SCIENCE_SANDBOX
}

enum EditorFacility {
    None,
    SPH,
    VAB
}

struct Game {
    1: string title,
    2: GameStatus status,
    3: GameScenes startScene,
    4: GameModes mode,
    // HighLogic
    5: GameScenes loadedScene
}

struct Vector3d {
    1: double x,
    2: double y,
    3: double z,
    4: double magnitude,
    5: double sqrMagnitude,
    6: string asString
}

struct CelestialBody {
    1: string name,
    2: double mass,
    3: list<CelestialBody> sattelites,
    4: double gravitationalParameter,
    5: double surfaceGravity,
    6: double rotationalSpeed,
    7: double rotationPeriod,
    8: double equatorialRadius,
    9: double sphereOfInfluence,
    10: bool hasAtmosphere,
    11: double atmosphereDepth,
    12: bool hasAtmosphericOxygen,
    13: Orbit orbit
}

struct Orbit {
    2: double apoasis,
    3: double periapsis,
    4: double apoasisAltitude,
    5: double periapsisAltitude,
    7: double semiMajorAxis,
    8: double semiMinorAxis,
    9: double radius,
    10: double speed,
    11: double period,
    12: double timeToApoasis,
    13: double timeToPeriapsis,
    14: double eccentricity,
    15: double inclination,
    16: double longitudeOfAscendingNode,
    17: double argumentOfPeriapsis,
    18: double meanAnomalyAtEpoch,
    19: double epoch,
    20: double meanAnomaly,
    21: double eccentricAnomaly
}





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


struct Vessel {
    1: string id,
    2: string name,
    3: Vector3d position,
    4: VesselType type,
    5: VesselSituation situation,
    6: Vessel target,
    7: Orbit orbit,


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


    32: Parts parts
}


struct FlightGlobals {
    1: Vessel activeVessel,
    2: list<Vessel> vessels,
    3: list<CelestialBody> bodies,
    4: CelestialBody currentMainBody,

    30: optional Part activeTarget
}

service KerbalApiService {
    oneway void evaluateCSCodeNoResponse(1:string authString),
    bool evaluateCSCode(1:string authString) throws (1:EAuthException aex),

    Game getGame(1:string authString) throws (1:EAuthException aex),

    // todo: rename to getActiveVessel
    Vessel activeVessel(1:string authString) throws (1:EAuthException aex),

    // todo: rename to getFlightGlobals
    FlightGlobals flightGlobals(1:string authString) throws (1:EAuthException aex),
   /*   oneway modifier keyword may be added to a void function, which will generate code that does not wait for a response.    Note that a pure void function will return a response to the client which guarantees that the operation has completed on the server side.    With oneway method calls the client will only be guaranteed that the request succeeded at the transport layer.    */   oneway void zip()

}
